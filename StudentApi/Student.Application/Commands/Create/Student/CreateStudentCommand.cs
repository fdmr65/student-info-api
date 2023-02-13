using MediatR;
using StudentInfo.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfo.Application.Commands.Create.Student
{
    public  class CreateStudentCommand : IRequest<StudentResponse>
    {
        //public CreateStudentCommand()
        //{
        //    Id = Guid.NewGuid();
        //}
        public Guid Id { get; set; }
        public string Name  { get; set; }
        public string Surname { get; set; }
    }
}
