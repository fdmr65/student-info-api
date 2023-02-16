using StudentInfo.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace StudentInfo.Domain.Models
{
    public  class LessonNote : BaseEntity
    {
        [Column("note")]
        public int Note { get; set; }

        [Column("lesson_id")]
        [ForeignKey("Lesson")]
        public Guid LessonId { get; set; }

        //public Lesson Lesson { get; set; }
    }
}
