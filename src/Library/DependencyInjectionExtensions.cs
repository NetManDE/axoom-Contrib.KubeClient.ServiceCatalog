using System;
using System.Diagnostics.CodeAnalysis;
using Contrib.KubeClient.CustomResources;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace Kubernetes.ServiceCatalog.Models
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public static class DependencyInjectionExtensions
    {
        private const string AxoomApiVersion = "stable.axoom.com";

        public static IServiceCollection AddClusterServiceClassStore(this IServiceCollection services)
        {
            return services.AddCustomResourceWatcher<ClusterServiceClass, ClusterServiceClassStore>(AxoomApiVersion, "clusterServiceClass")
                           .AddSingleton<IClusterServiceClassStore>(prov => prov.GetRequiredService<ClusterServiceClassStore>());
        }

        public static IServiceProvider UseClusterServiceClassStore(this IServiceProvider provider)
            => UseStore<ClusterServiceClassStore>(provider);

        public static IServiceCollection AddServiceInstanceStore(this IServiceCollection services)
            => services.AddCustomResourceWatcher<ServiceInstance, ServiceInstanceStore>(AxoomApiVersion, "serviceInstance")
                       .AddSingleton<IServiceInstanceStore>(prov => prov.GetRequiredService<ServiceInstanceStore>());

        public static IServiceProvider UseServiceInstanceStore(this IServiceProvider provider)
            => UseStore<ServiceInstanceStore>(provider);

        public static IServiceCollection AddClusterServicePlanStore(this IServiceCollection services)
            => services.AddCustomResourceWatcher<ClusterServicePlan, ClusterServicePlanStore>(AxoomApiVersion, "clusterServicePlan")
                       .AddSingleton<IClusterServicePlanStore>(prov => prov.GetRequiredService<ClusterServicePlanStore>());

        public static IServiceProvider UseClusterServicePlanStore(this IServiceProvider provider)
            => UseStore<ClusterServicePlanStore>(provider);

        public static IServiceCollection AddClusterServiceBrokerStore(this IServiceCollection services)
            => services.AddCustomResourceWatcher<ClusterServiceBroker, ClusterServiceBrokerStore>(AxoomApiVersion, "clusterServiceBroker")
                       .AddSingleton<IClusterServiceBrokerStore>(prov => prov.GetRequiredService<ClusterServiceBrokerStore>());

        public static IServiceProvider UseClusterServiceBrokerStore(this IServiceProvider provider)
            => UseStore<ClusterServiceBrokerStore>(provider);

        public static IServiceCollection AddServiceBindingStore(this IServiceCollection services)
            => services.AddCustomResourceWatcher<ServiceBinding, ServiceBindingStore>(AxoomApiVersion, "serviceBinding")
                       .AddSingleton<IServiceBindingStore>(prov => prov.GetRequiredService<ServiceBindingStore>());

        public static IServiceProvider UseServiceBindingStore(this IServiceProvider provider)
            => UseStore<ServiceBindingStore>(provider);

        public static IServiceProvider UseStore<TCustomResourceStore>(this IServiceProvider provider)
            where TCustomResourceStore : ICustomResourceWatcher
        {
            provider.GetRequiredService<TCustomResourceStore>().StartWatching();
            return provider;
        }
    }
}
