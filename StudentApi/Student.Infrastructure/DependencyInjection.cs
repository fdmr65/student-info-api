using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentInfo.Domain.IRepositories;
using StudentInfo.Domain.IRepositories.Base;
using StudentInfo.Infrastructure.Context;
using StudentInfo.Infrastructure.Repositories;
using StudentInfo.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfo.Infrastructure
{
    public static class DependencyInjection
    {
        public static  IServiceCollection AddInfraStructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<StudentContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("connectionString"),
                                                     b => b.MigrationsAssembly(typeof(StudentContext).Assembly.FullName)),
                                                     ServiceLifetime.Singleton);


            //Add Repositories
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<ILessonRepository, LessonRepository>();
            services.AddTransient<ILessonNoteRepository, LessonNoteRepository>();


            return services;
        }
    }
}
