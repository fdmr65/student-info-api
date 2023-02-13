using MediatR;
using StudentInfo.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfo.Application.Commands.Delete.Student
{
    public class DeleteStudentCommand : IRequest<DeletedResponse>
    {
        public Guid Id { get; set; }
    }
}
