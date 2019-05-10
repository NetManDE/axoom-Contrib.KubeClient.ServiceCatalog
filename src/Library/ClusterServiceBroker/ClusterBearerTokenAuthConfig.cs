using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Contrib.KubeClient.ServiceCatalog
{
    /// <summary>
    /// ClusterBearerTokenAuthConfig provides config for the bearer token
    /// authentication of cluster scoped brokers.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ClusterBearerTokenAuthConfig
    {
        /// <summary>
        /// SecretRef is a reference to a Secret containing information the
        /// catalog should use to authenticate to this ClusterServiceBroker.
        ///
        /// Required field:
        /// - Secret.Data["token"] - bearer token for authentication
        /// </summary>
        public object SecretRef { get; set; }
    }
}