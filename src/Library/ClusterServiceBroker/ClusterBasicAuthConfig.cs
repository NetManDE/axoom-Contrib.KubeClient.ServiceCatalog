using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Contrib.KubeClient.ServiceCatalog
{
    /// <summary>
    /// ClusterBasicAuthConfig provides config for the basic authentication of
    /// cluster scoped brokers.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ClusterBasicAuthConfig
    {
        /// <summary>
        /// SecretRef is a reference to a Secret containing information the
        /// catalog should use to authenticate to this ClusterServiceBroker.
        ///
        /// Required at least one of the fields:
        /// - Secret.Data["username"] - username used for authentication
        /// - Secret.Data["password"] - password or token needed for authentication
        /// </summary>
        public object SecretRef { get; set; }
    }
}