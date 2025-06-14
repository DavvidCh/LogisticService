using LogisticService.Calculations;
using LogisticService.Requests;

namespace LogisticService.Interfaces
{
    internal interface ICalculationModelConstructor
    {
        Task<CalculationModel> GetCalculationModelAsync(UserRequest userRequest);
    }
}
