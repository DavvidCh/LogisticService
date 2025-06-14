using LogisticService.Dtos;
using LogisticService.Mappers;
using LogisticService.Modules;
using LogisticService.Services.EntityServices;
using Microsoft.AspNetCore.Mvc;

namespace LogisticService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarService _carService;

        public CarController(CarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDto>>> Get()
        {
            try
            {
                var cars = await _carService.GetAllAsync();
                return Ok(cars.Select(c => c.ToDto()));
            }
            catch (ArgumentNullException)
            {
                return NotFound("No cars found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("filter")]
        public async Task<ActionResult<CarDto>> GetFiltered(int? id, string? mark)
        {
            try
            {
                Func<Car, bool> predicate = car =>
                    (!id.HasValue || car.Id == id.Value) &&
                    (string.IsNullOrEmpty(mark) || car.Mark == mark);

                var car = await _carService.GetByPredicateAsync(predicate);

                if (car == null)
                    return NotFound("Car not found with given filter.");

                return Ok(car.ToDto());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarDto>> GetById(int id)
        {
            try
            {
                var car = await _carService.GetByPredicateAsync(c => c.Id == id);

                if (car == null)
                    return NotFound($"Car with ID {id} not found.");

                return Ok(car.ToDto());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CarDto carDto)
        {
            if (carDto == null)
                return BadRequest("Input is null.");

            try
            {
                var car = carDto.FromDto();
                await _carService.AddAsync(car);

                return StatusCode(201, "Car created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CarDto carDto)
        {
            if (carDto == null || id != carDto.Id)
                return BadRequest("Invalid data.");

            try
            {
                await _carService.UpdateAsync(carDto.FromDto());
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _carService.RemoveAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
