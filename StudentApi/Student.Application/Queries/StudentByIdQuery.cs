using MediatR;
using StudentInfo.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfo.Application.Queries
{
    public class StudentByIdQuery : IRequest<StudentResponse>
    {
        public Guid Id { get; set; }
        public StudentByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
