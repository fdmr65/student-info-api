using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudentInfo.Infrastructure.Context;
using System;

namespace StudentInfo.WebAPI.Extensions
{
    public static class MigrationManager
    {

        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetRequiredService<StudentContext>();
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return host;
        }
    }
}
