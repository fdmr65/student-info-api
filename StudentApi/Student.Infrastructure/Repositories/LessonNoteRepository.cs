using StudentInfo.Domain.IRepositories;
using StudentInfo.Domain.Models;
using StudentInfo.Infrastructure.Context;
using StudentInfo.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfo.Infrastructure.Repositories
{
    public class LessonNoteRepository : Repository<LessonNote>, ILessonNoteRepository
    {
        public LessonNoteRepository(StudentContext dbContext) : base(dbContext)
        {
        }
    }
}
