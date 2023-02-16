using MediatR;
using StudentInfo.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfo.Application.Commands.Create.LessonNote
{
    public class CreateLessonNoteCommand  : IRequest<LessonNoteResponse>
    {
        public Guid Id { get; set; }
        public int Note { get; set; }
        public Guid LessonId { get; set; }
    }
}
