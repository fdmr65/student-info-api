using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfo.Application.Queries
{
    public  class FilterQuery
    {
        public string Field { get; set; }
        public string Operator { get; set; }
        public object Value { get; set; }

    }
}
