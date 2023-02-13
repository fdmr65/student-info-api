using MediatR;
using StudentInfo.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfo.Application.Queries
{
    public  class StudentsQuery : IRequest<IEnumerable<StudentResponse>>
    {
    }
}
