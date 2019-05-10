using Contrib.KubeClient.CustomResources;
using Microsoft.Extensions.DependencyInjection;

namespace Contrib.KubeClient.ServiceCatalog
{
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// Adds an <see cref="ICustomResourceClient{TResource}"/> for <see cref="ClusterServiceClass"/>s.
        /// </summary>
        public static IServiceCollection AddClusterServiceClassClient(IServiceCollection services)
            => services.AddCustomResourceClient<ClusterServiceClass>();

        /// <summary>
        /// Adds an <see cref="ICustomResourceWatcher{TResource}"/> for <see cref="ClusterServiceClass"/>s.
        /// </summary>
        public static IServiceCollection AddClusterServiceClassWatcher(this IServiceCollection services)
            => services.AddCustomResourceWatcher<ClusterServiceClass>();

        /// <summary>
        /// Adds an <see cref="ICustomResourceClient{TResource}"/> for <see cref="ClusterServicePlan"/>s.
        /// </summary>
        public static IServiceCollection AddClusterServicePlanClient(IServiceCollection services)
            => services.AddCustomResourceClient<ClusterServicePlan>();

        /// <summary>
        /// Adds an <see cref="ICustomResourceWatcher{TResource}"/> for <see cref="ClusterServicePlan"/>s.
        /// </summary>
        public static IServiceCollection AddClusterServicePlanWatcher(this IServiceCollection services)
            => services.AddCustomResourceWatcher<ClusterServicePlan>();

        /// <summary>
        /// Adds an <see cref="ICustomResourceClient{TResource}"/> for <see cref="ClusterServiceBroker"/>s.
        /// </summary>
        public static IServiceCollection AddClusterServiceBrokerClient(IServiceCollection services)
            => services.AddCustomResourceClient<ClusterServiceBroker>();

        /// <summary>
        /// Adds an <see cref="ICustomResourceWatcher{TResource}"/> for <see cref="ClusterServiceBroker"/>s.
        /// </summary>
        public static IServiceCollection AddClusterServiceBrokerWatcher(this IServiceCollection services)
            => services.AddCustomResourceWatcher<ClusterServiceBroker>();

        /// <summary>
        /// Adds an <see cref="ICustomResourceClient{TResource}"/> for <see cref="ServiceInstance"/>s.
        /// </summary>
        /// <param name="services">The service collection.</param>
        public static IServiceCollection AddServiceInstanceClient(IServiceCollection services)
            => services.AddCustomResourceClient<ServiceInstance>();

        /// <summary>
        /// Adds an <see cref="ICustomResourceWatcher{TResource}"/> for <see cref="ServiceInstance"/>s.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="namespace">The Kubernetes namespace to watch. Leave unset to watch all.</param>
        public static IServiceCollection AddServiceInstanceWatcher(this IServiceCollection services, string @namespace = null)
            => services.AddCustomResourceWatcher<ServiceInstance>(@namespace);

        /// <summary>
        /// Adds an <see cref="ICustomResourceClient{TResource}"/> for <see cref="ServiceBinding"/>s.
        /// </summary>
        /// <param name="services">The service collection.</param>
        public static IServiceCollection AddServiceBindingClient(IServiceCollection services)
            => services.AddCustomResourceClient<ServiceBinding>();

        /// <summary>
        /// Adds an <see cref="ICustomResourceWatcher{TResource}"/> for <see cref="ServiceBinding"/>s.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="namespace">The Kubernetes namespace to watch. Leave unset to watch all.</param>
        public static IServiceCollection AddServiceBindingWatcher(this IServiceCollection services, string @namespace = null)
            => services.AddCustomResourceWatcher<ServiceBinding>(@namespace);
    }
}
