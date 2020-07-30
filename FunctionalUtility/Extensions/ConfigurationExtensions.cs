using FunctionalUtility.ResultUtility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FunctionalUtility.Extensions {
    public static class ConfigurationExtensions {
        public static T GetConfig<T> (
                this IConfiguration @this) =>
            @this.GetSection (typeof (T).Name)
            .Get<T> ();

        public static MethodResult<IConfiguration> AddConfig<T> (
                this IConfiguration @this,
                IServiceCollection services) where T : class =>
            @this
            .GetConfig<T> ()
            .TryTee (obj => services.AddSingleton (obj))
            .MapMethodResult (@this);

        public static MethodResult<IConfiguration> AddConfig<T> (
                this MethodResult<IConfiguration> @this,
                IServiceCollection services) where T : class => @this
            .OnSuccess (configuration => configuration.AddConfig<T> (services));
    }
}