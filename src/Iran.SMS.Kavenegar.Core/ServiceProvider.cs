using System;
using System.Net.Http;
using System.Collections.Generic;
using Iran.SMS.Kavenegar.Core;

namespace Microsoft.Extensions.DependencyInjection {

    public static class ServiceProvider {

        /// <summary>
        /// Add <see cref="KavenegarService"/> to send & recieve sms messages 
        /// with provided <paramref name="apiKey"/>
        /// </summary>
        /// <param name="services">Service Collection</param>
        /// <param name="apiKey">Kavenegar API key</param>
        /// <returns>Service Collection</returns>
        public static IServiceCollection AddKavenegarSmsService(
            this IServiceCollection services,
            string apiKey) {

            services.AddHttpClient();
            services.AddSingleton<IHttpRestClient, HttpRestClient>();
            var restClient = services.BuildServiceProvider()
                .GetRequiredService<IHttpRestClient>();
            services.AddScoped<IKavenegarService>(
                _=> new KavenegarService(restClient, apiKey));

            return services;
        }

        /// <summary>
        /// Add <see cref="KavenegarService"/> to send & recieve sms messages
        /// </summary>
        /// <param name="services">Service Collection</param>
        /// <returns>Service Collection</returns>
        public static IServiceCollection AddKavenegarSmsService(
            this IServiceCollection services) {

            services.AddHttpClient();
            services.AddSingleton<IHttpRestClient, HttpRestClient>();
            services.AddScoped<IKavenegarService, KavenegarService>();

            return services;
        }
    }
}
