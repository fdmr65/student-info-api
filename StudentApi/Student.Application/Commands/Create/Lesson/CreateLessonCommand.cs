using MediatR;
using StudentInfo.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfo.Application.Commands.Create.Lesson
{
    public  class CreateLessonCommand :  IRequest<LessonResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid StudentId { get; set; }
    }
}
