using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mvc.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Server
{
    public static class ApplicationDbDependencyInjection
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddDbContext<ApplicationDbContext>(options => options.UseMongoDb("mongodb://localhost"));
        }
    }
}
