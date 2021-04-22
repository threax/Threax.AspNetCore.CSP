using System;
using System.Collections.Generic;
using System.Text;
using Threax.AspNetCore.CSP;

namespace Microsoft.Extensions.DependencyInjection.Extensions
{
    public static class DiExtensions
    {
        /// <summary>
        /// Add a Content Security Policy header when you use the threax-csp tag helper on a view.
        /// The default csp is empty, so you should call some kind of setup on it.
        /// </summary>
        /// <param name="services">Services</param>
        /// <param name="configure">Configuration callback.</param>
        /// <returns>The services passed in.</returns>
        public static IServiceCollection AddThreaxCSP(this IServiceCollection services, Action<CSPOptions> configure)
        {
            var options = new CSPOptions();
            configure?.Invoke(options);

            services.AddSingleton<CSPOptions>(options);
            services.AddScoped<ICspHeaderWriter, CspHeaderWriter>();
            services.AddScoped<INonceProvider>(s => new NonceProvider(options.NonceSizeBytes));

            return services;
        }
    }
}
