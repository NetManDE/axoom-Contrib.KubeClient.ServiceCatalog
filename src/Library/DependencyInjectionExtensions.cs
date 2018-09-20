using System;
using System.Diagnostics.CodeAnalysis;
using Contrib.KubeClient.CustomResources;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Kubernetes.ServiceCatalog.Models
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddClusterServiceClassCustomResource(this IServiceCollection services)
            => services.AddCustomResourceWatcher<ClusterServiceClass, ClusterServiceClassStore>("stable.axoom.com", "clusterServiceClass")
                       .AddSingleton<IClusterServiceClassStore>(prov => prov.GetRequiredService<ClusterServiceClassStore>());

        public static IServiceProvider UseClusterServiceClassCustomResource(this IApplicationBuilder app)
            => UseCustomResource<ClusterServiceClassStore>(app);

        public static IServiceCollection AddServiceInstanceCustomResource(this IServiceCollection services)
            => services.AddCustomResourceWatcher<ServiceInstance, ServiceInstanceStore>("stable.axoom.com", "serviceInstance")
                       .AddSingleton<IServiceInstanceStore>(prov => prov.GetRequiredService<ServiceInstanceStore>());

        public static IServiceProvider UseServiceInstanceCustomResource(this IApplicationBuilder app)
            => UseCustomResource<ServiceInstanceStore>(app);

        public static IServiceCollection AddClusterServicePlanCustomResource(this IServiceCollection services)
            => services.AddCustomResourceWatcher<ClusterServicePlan, ClusterServicePlanStore>("stable.axoom.com", "clusterServicePlan")
                       .AddSingleton<IClusterServicePlanStore>(prov => prov.GetRequiredService<ClusterServicePlanStore>());

        public static IServiceProvider UseClusterServicePlanCustomResource(this IApplicationBuilder app)
            => UseCustomResource<ClusterServicePlanStore>(app);

        public static IServiceProvider UseCustomResource<TCustomResourceStore>(this IApplicationBuilder app)
            where TCustomResourceStore : ICustomResourceWatcher
        {
            var provider = app.ApplicationServices;
            var store = provider.GetRequiredService<TCustomResourceStore>();
            store.StartWatching();
            return provider;
        }
    }
}