using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfo.Domain.Models.Base
{
    public  interface IBaseEntity
    {
        Guid Id { get; }

    }
}
