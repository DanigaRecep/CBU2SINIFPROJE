﻿
using CBU2SINIFPROJE.BLL.Concrete;
using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.DAL.Concrete.MemoryDatabase.Repositories;
using CBU2SINIFPROJE.DAL.Interfaces;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CBU2SINIFPROJE.BLL.Containers.MicrosoftIOC
{
    public static class MicrosoftIocExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped(typeof(IGenericRepository<>), typeof(MDGenericRepository<>));

            services.AddScoped<IActorService, ActorManager>();
            services.AddScoped<IOfficeWorkerService, OfficeWorkerManager>();
            services.AddScoped<ICompanyService, CompanyManager>();
            services.AddScoped<IProjectService, ProjectManager>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IAccountingService, AccountingManager>();

            services.AddScoped<ICompanyDal, MDCompanyDal>();

        }
    }
}
