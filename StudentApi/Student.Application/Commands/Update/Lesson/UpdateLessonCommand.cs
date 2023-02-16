using MediatR;
using StudentInfo.Application.Responses;
using System;

namespace StudentInfo.Application.Commands.Update.Lesson
{
    public  class UpdateLessonCommand : IRequest<LessonResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid StudentId { get; set; }
    }
}
