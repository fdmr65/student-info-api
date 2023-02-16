using StudentInfo.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace StudentInfo.Domain.Models
{
    public class Student : BaseEntity
    {
        [Column("no")]
        public string No { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("surname")]
        public string Surname { get; set; }

        //public IQueryable<Lesson> Lessons { get; set; }

    }
}
