using AutoMapper;
using StudentInfo.Application.Commands.Create.Lesson;
using StudentInfo.Application.Commands.Create.LessonNote;
using StudentInfo.Application.Commands.Create.Student;
using StudentInfo.Application.Commands.Update.Lesson;
using StudentInfo.Application.Commands.Update.LessonNote;
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

            CreateMap<Lesson, CreateLessonCommand>().ReverseMap();
            CreateMap<Lesson, UpdateLessonCommand>().ReverseMap();

            CreateMap<LessonNote, CreateLessonNoteCommand>().ReverseMap();
            CreateMap<LessonNote, UpdateLessonNoteCommand>().ReverseMap();

            //reverse map olunca çift taraflı mapp işlemi yapılabilir
            CreateMap<Student, StudentResponse>().ReverseMap();
            CreateMap<Lesson,LessonResponse>().ReverseMap();
            CreateMap<LessonNote, LessonNoteResponse>().ReverseMap();
            CreateMap<IEnumerable<StudentResponse>, IEnumerable<Student>>(); ;
        }
    }
}
