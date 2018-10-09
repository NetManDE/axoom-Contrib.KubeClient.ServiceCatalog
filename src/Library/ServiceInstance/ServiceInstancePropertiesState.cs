using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

namespace Kubernetes.ServiceCatalog.Models
{
    /// <summary>
    /// ServiceInstancePropertiesState is the state of a ServiceInstance that
    /// the ServiceBroker knows about.
    /// </summary>
    [PublicAPI]
    public class ServiceInstancePropertiesState
    {
        /// <summary>
        /// ClusterServicePlanExternalName is the name of the plan that the broker knows this
        /// ServiceInstance to be on. This is the human readable plan name from the
        /// OSB API.
        /// </summary>
        public string ClusterServicePlanExternalName { get; set; }

        /// <summary>
        /// ClusterServicePlanExternalID is the external ID of the plan that the
        /// broker knows this ServiceInstance to be on.
        /// </summary>
        public string ClusterServicePlanExternalID { get; set; }

        /// <summary>
        /// ServicePlanExternalName is the name of the plan that the broker knows this
        /// ServiceInstance to be on. This is the human readable plan name from the
        /// OSB API.
        /// </summary>
        public string ServicePlanExternalName { get; set; }

        /// <summary>
        /// ServicePlanExternalID is the external ID of the plan that the
        /// broker knows this ServiceInstance to be on.
        /// </summary>
        public string ServicePlanExternalID { get; set; }

        /// <summary>
        /// Parameters is a blob of the parameters and their values that the broker
        /// knows about for this ServiceInstance.  If a parameter was sourced from
        /// a secret, its value will be "redacted" in this blob.
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