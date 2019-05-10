using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Contrib.KubeClient.ServiceCatalog
{
    /// <summary>
    /// ClusterServiceBrokerAuthInfo is a union type that contains information on
    /// one of the authentication methods the the service catalog and brokers may
    /// support, according to the OpenServiceBroker API specification
    /// (https://github.com/openservicebrokerapi/servicebroker/blob/master/spec.md).
    /// </summary>
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ClusterServiceBrokerAuthInfo
    {
        /// <summary>
        /// ClusterBasicAuthConfig provides configuration for basic authentication.
        /// </summary>
        public ClusterBasicAuthConfig Basic { get; set; }

        /// <summary>
        /// ClusterBearerTokenAuthConfig provides configuration to send an opaque value as a bearer token.
        /// The value is referenced from the 'token' field of the given secret.  This value should only
        /// contain the token value and not the `Bearer` scheme.
        /// </summary>
        public ClusterBearerTokenAuthConfig Bearer { get; set; }
    }
}