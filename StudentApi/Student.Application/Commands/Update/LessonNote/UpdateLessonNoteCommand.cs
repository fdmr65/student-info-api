using MediatR;
using StudentInfo.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfo.Application.Commands.Update.LessonNote
{
    public  class UpdateLessonNoteCommand  : IRequest<LessonNoteResponse>
    {
        public Guid Id { get; set; }
        public int Note { get; set; }
        public Guid LessonId { get; set; }
    }
}
