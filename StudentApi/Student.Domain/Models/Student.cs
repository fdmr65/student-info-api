using StudentInfo.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentInfo.Domain.Models
{
    public class Student : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }
        [Column("surname")]
        public string Surname { get; set; }

    }
}
