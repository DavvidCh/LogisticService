using LogisticService.Dtos;
using LogisticService.Modules;

namespace LogisticService.Mappers
{
    public static class InsuranceMapper
    {
        public static InsuranceDto ToDto(this Insurance entity)
        {
            return new InsuranceDto(entity.Id, entity.IsIncluded, entity.Coefficient);
        }

        public static Insurance FromDto(this InsuranceDto dto)
        {
            return new Insurance
            {
                Id = dto.Id,
                IsIncluded = dto.IsIncluded,
                Coefficient = dto.Coefficient
            };
        }
    }
}
