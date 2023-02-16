using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfo.Application.Responses
{
    public  class LessonNoteResponse
    {
        public Guid Id { get; set; }
        public int Note { get; set; }
        public Guid LessonId { get; set; }
        public LessonResponse LessonResponse { get; set; }
    }
}
