using AutoMapper;
using StudentInfo.Application.Commands.Create.Student;
using StudentInfo.Application.Commands.Update.Student;
using StudentInfo.Application.Responses;
using StudentInfo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfo.Application.Mapper
{
    public  class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, CreateStudentCommand>().ReverseMap();
            CreateMap<Student,UpdateStudentCommand>().ReverseMap();

            //reverse map olunca çift taraflı mapp işlemi yapılabilir
            CreateMap<Student, StudentResponse>().ReverseMap();
            CreateMap<IEnumerable<StudentResponse>, IEnumerable<Student>>(); ;
        }
    }
}
