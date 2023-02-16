using StudentInfo.Domain.IRepositories;
using StudentInfo.Domain.Models;
using StudentInfo.Infrastructure.Context;
using StudentInfo.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfo.Infrastructure.Repositories
{
    public class LessonRepository : Repository<Lesson>, ILessonRepository
    {
        public LessonRepository(StudentContext dbContext) : base(dbContext)
        {
        }
    }
}
