using StudentInfo.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace StudentInfo.Domain.Models
{
    public class Lesson :BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("student_id")]
        [ForeignKey("Student")]
        public Guid StudentId { get; set; }

        public Student Student { get; set; }

        //public IQueryable<LessonNote> LessonNotes { get; set; }
    }
}
