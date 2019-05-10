using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

namespace Contrib.KubeClient.ServiceCatalog
{
    /// <summary>
    /// ServiceBindingPropertiesState is the state of a
    /// ServiceBinding that the ServiceBroker knows about.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ServiceBindingPropertiesState
    {
        /// <summary>
        /// Parameters is a blob of the parameters and their values that the broker
        /// knows about for this ServiceBinding.  If a parameter was
        /// sourced from a secret, its value will be "redacted" in this blob.
        /// </summary>
        public JObject Parameters { get; set; }

        /// <summary>
        /// ParametersChecksum is the checksum of the parameters that were sent.
        /// </summary>
        public string ParametersChecksum { get; set; }

        /// <summary>
        /// UserInfo is information about the user that made the request.
        /// </summary>
        UserInfo UserInfo { get; set; }
    }
}