using MediatR;
using StudentInfo.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfo.Application.Queries
{
    public  class StudentsQuery : IRequest<IEnumerable<StudentResponse>>
    {
        public List<FilterQuery> FilterQueries { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
