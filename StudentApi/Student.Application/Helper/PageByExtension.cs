using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentInfo.Application.Helper
{
    public static class PageByExtension
    {
        public static IQueryable<T> PageBy<T>(this IQueryable<T> @this,int skip , int take)
        {
            return @this.Skip(skip).Take(take);
        }
    }
}
