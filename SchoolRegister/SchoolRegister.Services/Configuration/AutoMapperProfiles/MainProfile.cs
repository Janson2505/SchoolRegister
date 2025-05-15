using AutoMapper;
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM;
using AutoMapper;
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM;
using System.Text.RegularExpressions;
using SchoolRegister.ViewModels.VM;
namespace SchoolRegister.Services.Configuration.AutoMapperProfiles;

public class MainProfile : Profile
{
    public MainProfile()
    {
        // Mapowanie Subject -> SubjectVm z customowymi polami
        CreateMap<Subject, SubjectVm>()
            // Imię i nazwisko nauczyciela w jednym polu
            .ForMember(dest => dest.TeacherName,
                opt => opt.MapFrom(src => src.Teacher == null ? null : $"{src.Teacher.FirstName} {src.Teacher.LastName}"))
            // Mapowanie grup z powiązania
            .ForMember(dest => dest.Groups,
                opt => opt.MapFrom(src => src.SubjectGroups.Select(sg => sg.Group)))
            .ReverseMap(); // Umożliwia mapowanie w obie strony

        // Proste mapowanie VM -> Model
        CreateMap<AddOrUpdateSubjectVm, Subject>().ReverseMap();

        // Mapowanie Group -> GroupVm z customowymi polami
        CreateMap<Group, GroupVm>()
            .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students))
            .ForMember(dest => dest.Subjects, opt => opt.MapFrom(src => src.SubjectGroups.Select(sg => sg.Subject)))
            .ReverseMap();

        // Mapowanie Student -> StudentVm z customowymi polami
        CreateMap<Student, StudentVm>()
            .ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.Group == null ? null : src.Group.Name))
            .ForMember(dest => dest.ParentName, opt => opt.MapFrom(src => src.Parent == null ? null : $"{src.Parent.FirstName} {src.Parent.LastName}"))
            .ReverseMap();

        // Dodaj tu kolejne mapowania zgodnie z potrzebami serwisów
        // CreateMap<SourceType, DestinationType>().ReverseMap();
    }
}
