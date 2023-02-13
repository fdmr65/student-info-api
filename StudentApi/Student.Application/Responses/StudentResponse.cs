using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfo.Application.Responses
{
    public class StudentResponse
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
