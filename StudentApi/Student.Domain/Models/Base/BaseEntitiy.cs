using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentInfo.Domain.Models.Base
{
    public abstract class BaseEntity : IBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public virtual Guid Id { get; protected set; }
        [Column("is_active")]
        public virtual bool IsActive { get; protected set; }
        [Column("insert_date")]
        public virtual DateTime InsertDate { get; protected set; }
        [Column("insert_user")]
        public virtual string InsertUser { get; protected set; }
        [Column("update_date")]
        public virtual DateTime UpdateDate { get; protected set; }
        [Column("update_user")]
        public virtual string UpdateUser { get; protected set; }



        public BaseEntity Clone()
        {
            return (BaseEntity)this.MemberwiseClone();
        }
    }
}
