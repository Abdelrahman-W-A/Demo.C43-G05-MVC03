using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Demo.BLL.Data_Transfer_Objects__DTOs_.EmployeeDTOs;
using Demo.DAL.Models.EmployeeModel;

namespace Demo.BLL.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() : base()
        {
            CreateMap<Employee, GetEmployeeDTO>()
                .ForMember(Dest => Dest.gender, Options => Options.MapFrom(src => src.Gender))
                .ForMember(Dest => Dest.EmployeeType, Options => Options.MapFrom(src => src.EmployeeType));

            CreateMap<Employee, GetEmployeeByIdDTO>()
                .ForMember(Dest => Dest.gender, Options => Options.MapFrom(src => src.Gender))
                .ForMember(Dest => Dest.EmployeeType, Options => Options.MapFrom(src => src.Gender))
                .ForMember(Dest => Dest.HiringDate,Options => Options.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)));

            CreateMap<AddNewEmployeeDTO, Employee>()
                .ForMember(Dest => Dest.HiringDate,Options => Options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));

            CreateMap<UpdatedmployeeDTO, Employee>()
                .ForMember(Dest => Dest.HiringDate, Options => Options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));
        }
    }
}
