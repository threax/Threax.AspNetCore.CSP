using System;
using System.Collections.Generic;
using System.Text;
using Threax.AspNetCore.CSP;

namespace Microsoft.Extensions.DependencyInjection.Extensions
{
    public static class DiExtensions
    {
        public static IServiceCollection AddThreaxCSP(this IServiceCollection services, Action<CSPOptions> configure)
        {
            var options = new CSPOptions();
            configure?.Invoke(options);

            services.AddSingleton<CSPString>(options.Build());

            return services;
        }
    }
}
