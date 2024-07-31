using FIAP.Application.InputModels;
using FIAP.Application.OutputModels;
using FIAP.Domain.Entities.Store;

namespace FIAP.Application.Interfaces;

public interface IPaymentUseCases
{
    Task<CheckPaymentOutputModel> CheckPaymentAsync(long id);
    Task<Payments> SyncPaymentByGatewayAsync(SyncPaymentByGatewayModel model);
}