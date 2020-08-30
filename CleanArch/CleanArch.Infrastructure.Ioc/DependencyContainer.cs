using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Domain.CommandHandlers;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;
using CleanArch.Infrastructure.Bus;
using CleanArch.Infrastructure.Data.Context;
using CleanArch.Infrastructure.Data.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infrastructure.Ioc
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain InMemoryBus MediatR
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Domain Handlers
            services.AddScoped<IRequestHandler<CreateCourseCommand, bool>, CourseCommandHandler>();

            // application layer
            services.AddScoped<ICourseService, CourseService>();

            // infrastructure data layer
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<UniversityDBContext>();
        }

    }
}
