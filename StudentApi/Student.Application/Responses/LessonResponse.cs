using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfo.Application.Responses
{
    public  class LessonResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid StudentId { get; set; }
        public StudentResponse StudentResponse { get; set; }
    }
}
