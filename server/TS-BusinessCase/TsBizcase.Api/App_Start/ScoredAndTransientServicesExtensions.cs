using Microsoft.Extensions.DependencyInjection;
using System;
using TsBizcase.Application.Factories;
using TsBizcase.Core.Repositories;
using TsBizcase.Core.Repositories.Base;
using TsBizcase.Infrastructure.Repositories;
using TsBizcase.Infrastructure.Repositories.Base;

namespace TsBizcase.Api.App_Start
{
    public static class ScoredAndTransientServicesExtensions
    {
        public static void AddScopedAndTransientServices(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IAppUserRepository, AppUserRepository>();
            services.AddTransient<ITenderRepository, TenderRepository>();
            services.AddTransient<IQueryMaker, QueryMaker>();
        }
    }
}
