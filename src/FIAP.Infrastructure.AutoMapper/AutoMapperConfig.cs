using AutoMapper;

using FIAP.Infrastructure.AutoMapper.Profiles;


namespace FIAP.Infrastructure.AutoMapper;

public class AutoMapperConfig
{
    public static MapperConfiguration RegisterMappings()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new CommandToDomainMappingProfile());
            cfg.AddProfile(new DomainToCommandMappingProfile());
            cfg.AddProfile(new DomainToViewModelMappingProfile());
            cfg.AddProfile(new ViewModelToCommandMappingProfile());
            cfg.AddProfile(new ViewModelToDomainMappingProfile());
        });
    }
}