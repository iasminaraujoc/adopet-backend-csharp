using alura_backend_csharp.Data.Dtos;
using alura_backend_csharp.Models;
using AutoMapper;

namespace alura_backend_csharp.Profiles;

public class TutorProfile : Profile
{
    public TutorProfile() 
    {
        CreateMap<CreateTutorDto, Tutor>();
        CreateMap<Tutor, ReadTutorDto>();
        CreateMap<UpdateTutorDto, Tutor>();
        CreateMap<Tutor, UpdateTutorDto>();
    }
}
