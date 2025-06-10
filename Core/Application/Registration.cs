
using System.Reflection;
using Core.Application.Bases;
using Core.Application.Beheviors;
using Core.Application.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddTransient<ExceptionMiddleware>();
            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));
            services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("en-GB");
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));

        }

        public static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services, Assembly assembly, Type type)
        {
            var types = assembly.GetTypes()
                .Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var t in types)
                services.AddTransient(t);

            return services;
        }
    }
}



