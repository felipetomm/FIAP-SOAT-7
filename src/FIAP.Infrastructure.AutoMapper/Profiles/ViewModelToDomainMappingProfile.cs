using AutoMapper;

using FIAP.Application.InputModels;
using FIAP.Application.Interfaces;

namespace FIAP.Infrastructure.AutoMapper.Profiles;

public class ViewModelToDomainMappingProfile : Profile
{
    public ViewModelToDomainMappingProfile()
    {
        CreateMap<CreateOrderModel, CreateOrderDto>();
    }
}