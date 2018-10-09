using Contrib.KubeClient.CustomResources;
using Microsoft.Extensions.DependencyInjection;

namespace Kubernetes.ServiceCatalog.Models
{
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// Adds an <see cref="ICustomResourceClient{TResource}"/> for <see cref="ClusterServiceClass"/>s.
        /// </summary>
        public static IServiceCollection AddClusterServiceClassClient(this IServiceCollection services)
            => services.AddCustomResourceClient(ClusterServiceClass.Definition);

        /// <summary>
        /// Adds an <see cref="ICustomResourceWatcher{TResource}"/> for <see cref="ClusterServiceClass"/>s.
        /// Remember to call <see cref="Contrib.KubeClient.CustomResources.DependencyInjectionExtensions.UseCustomResourceWatchers"/> during startup.
        /// </summary>
        public static IServiceCollection AddClusterServiceClassWatcher(this IServiceCollection services)
            => services.AddCustomResourceWatcher(ClusterServiceClass.Definition);

        /// <summary>
        /// Adds an <see cref="ICustomResourceClient{TResource}"/> for <see cref="ClusterServicePlan"/>s.
        /// </summary>
        public static IServiceCollection AddClusterServicePlanClient(this IServiceCollection services)
            => services.AddCustomResourceClient(ClusterServicePlan.Definition);

        /// <summary>
        /// Adds an <see cref="ICustomResourceWatcher{TResource}"/> for <see cref="ClusterServicePlan"/>s.
        /// Remember to call <see cref="Contrib.KubeClient.CustomResources.DependencyInjectionExtensions.UseCustomResourceWatchers"/> during startup.
        /// </summary>
        public static IServiceCollection AddClusterServicePlanWatcher(this IServiceCollection services)
            => services.AddCustomResourceWatcher(ClusterServicePlan.Definition);

        /// <summary>
        /// Adds an <see cref="ICustomResourceClient{TResource}"/> for <see cref="ClusterServiceBroker"/>s.
        /// </summary>
        public static IServiceCollection AddClusterServiceBrokerClient(this IServiceCollection services)
            => services.AddCustomResourceClient(ClusterServiceBroker.Definition);

        /// <summary>
        /// Adds an <see cref="ICustomResourceWatcher{TResource}"/> for <see cref="ClusterServiceBroker"/>s.
        /// Remember to call <see cref="Contrib.KubeClient.CustomResources.DependencyInjectionExtensions.UseCustomResourceWatchers"/> during startup.
        /// </summary>
        public static IServiceCollection AddClusterServiceBrokerWatcher(this IServiceCollection services)
            => services.AddCustomResourceWatcher(ClusterServiceBroker.Definition);

        /// <summary>
        /// Adds an <see cref="ICustomResourceClient{TResource}"/> for <see cref="ServiceInstance"/>s.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="namespace">The Kubernetes namespace to watch. Leave unset to watch all.</param>
        public static IServiceCollection AddServiceInstanceClient(this IServiceCollection services, string @namespace = null)
            => services.AddCustomResourceClient(ServiceInstance.Definition);

        /// <summary>
        /// Adds an <see cref="ICustomResourceWatcher{TResource}"/> for <see cref="ServiceInstance"/>s.
        /// Remember to call <see cref="Contrib.KubeClient.CustomResources.DependencyInjectionExtensions.UseCustomResourceWatchers"/> during startup.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="namespace">The Kubernetes namespace to watch. Leave unset to watch all.</param>
        public static IServiceCollection AddServiceInstanceWatcher(this IServiceCollection services, string @namespace = null)
            => services.AddCustomResourceWatcher(ServiceInstance.Definition);

        /// <summary>
        /// Adds an <see cref="ICustomResourceClient{TResource}"/> for <see cref="ServiceBinding"/>s.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="namespace">The Kubernetes namespace to watch. Leave unset to watch all.</param>
        public static IServiceCollection AddServiceBindingClient(this IServiceCollection services, string @namespace = null)
            => services.AddCustomResourceClient(ServiceBinding.Definition);

        /// <summary>
        /// Adds an <see cref="ICustomResourceWatcher{TResource}"/> for <see cref="ServiceBinding"/>s.
        /// Remember to call <see cref="Contrib.KubeClient.CustomResources.DependencyInjectionExtensions.UseCustomResourceWatchers"/> during startup.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="namespace">The Kubernetes namespace to watch. Leave unset to watch all.</param>
        public static IServiceCollection AddServiceBindingWatcher(this IServiceCollection services, string @namespace = null)
            => services.AddCustomResourceWatcher(ServiceBinding.Definition);
    }
}
