using AutoMapper;
using BussinessContracts.Models;
using DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIL
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UserDto, UserModel>().ReverseMap();
                cfg.CreateMap<AssignmentDto, AssignmentModel>().ReverseMap();
                cfg.CreateMap<LaboratoryDto, LaboratoryModel>().ReverseMap();
                cfg.CreateMap<AttendanceDto, AttendanceModel>().ReverseMap();
                cfg.CreateMap<SubmissionDto, SubmissionModel>().ReverseMap();
            });
        }
    }
}
