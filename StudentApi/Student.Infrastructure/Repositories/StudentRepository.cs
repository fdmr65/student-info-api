using StudentInfo.Domain.IRepositories;
using StudentInfo.Domain.Models;
using StudentInfo.Infrastructure.Context;
using StudentInfo.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfo.Infrastructure.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(StudentContext dbContext) : base(dbContext)
        {
        }
    }
}
