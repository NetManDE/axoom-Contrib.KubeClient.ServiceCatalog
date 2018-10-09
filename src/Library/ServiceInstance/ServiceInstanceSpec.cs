using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

namespace Kubernetes.ServiceCatalog.Models
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ServiceInstanceSpec : IEquatable<ServiceInstanceSpec>
    {
        /// <summary>
        /// ExternalID is the identity of this object for use with the OSB API.
        /// </summary>
        public string ExternalID { get; set; }

        /// <summary>
        /// ClusterServiceClassExternalName is the human-readable name of the
        /// service as reported by the ClusterServiceBroker. Note that if the
        /// ClusterServiceBroker changes the name of the ClusterServiceClass,
        /// it will not be reflected here, and to see the current name of the
        /// ClusterServiceClass, you should follow the ClusterServiceClassRef below.
        /// </summary>
        public string ClusterServiceClassExternalName { get; set; }

        /// <summary>
        /// ClusterServicePlanExternalName is the human-readable name of the plan
        /// as reported by the ClusterServiceBroker. Note that if the
        /// ClusterServiceBroker changes the name of the ClusterServicePlan, it will
        /// not be reflected here, and to see the current name of the
        /// ClusterServicePlan, you should follow the ClusterServicePlanRef below.
        /// </summary>
        public string ClusterServicePlanExternalName { get; set; }

        /// <summary>
        /// ClusterServiceClassExternalID is the ClusterServiceBroker's external id
        /// for the class.
        /// </summary>
        public string ClusterServiceClassExternalID { get; set; }

        /// <summary>
        /// ClusterServicePlanExternalID is the ClusterServiceBroker's external id for
        /// the plan.
        /// </summary>
        public string ClusterServicePlanExternalID { get; set; }

        /// <summary>
        /// ClusterServiceClassName is the kubernetes name of the ClusterServiceClass.
        /// </summary>
        public string ClusterServiceClassName { get; set; }

        /// <summary>
        /// ClusterServicePlanName is kubernetes name of the ClusterServicePlan.
        /// </summary>
        public string ClusterServicePlanName { get; set; }

        /// <summary>
        /// ClusterServiceClass is a reference to the <see cref="ClusterServiceClass"/>
        /// that the user selected. This is set by the controller based on the
        /// cluster-scoped values specified in the PlanReference.
        /// </summary>
        public ClusterServiceClass ClusterServiceClass { get; set; }

        /// <summary>
        /// ClusterServicePlan is a reference to the <see cref="ClusterServicePlan"/>
        /// that the user selected. This is set by the controller based on the
        /// cluster-scoped values specified in the PlanReference.
        /// </summary>
        public ClusterServicePlan ClusterServicePlan { get; set; }

        /// <summary>
        /// Parameters is a set of the parameters to be passed to the underlying
        /// broker. The inline YAML/JSON payload to be translated into equivalent
        /// JSON object. If a top-level parameter name exists in multiples sources
        /// among `Parameters` and `ParametersFrom` fields, it is considered to be
        /// a user error in the specification
        ///
        /// The Parameters field is NOT secret or secured in any way and should
        /// NEVER be used to hold sensitive information. To set parameters that
        /// contain secret information, you should ALWAYS store that information
        /// in a Secret and use the ParametersFrom field.
        /// </summary>
        public JObject Parameters { get; set; }

        /// <summary>
        /// List of sources to populate parameters.
        /// If a top-level parameter name exists in multiples sources among
        /// `Parameters` and `ParametersFrom` fields, it is
        /// considered to be a user error in the specification
        /// </summary>
        public ParametersFromSource ParametersFrom { get; set; }

        /// <summary>
        /// UpdateRequests is a strictly increasing, non-negative integer counter that
        /// can be manually incremented by a user to manually trigger an update. This
        /// allows for parameters to be updated with any out-of-band changes that have
        /// been made to the secrets from which the parameters are sourced.
        /// </summary>
        public long UpdateRequests { get; set; }

        public bool Equals(ServiceInstanceSpec other)
            => other != null
            && ExternalID == other.ExternalID
            && ClusterServiceClassExternalName == other.ClusterServiceClassExternalName
            && ClusterServicePlanExternalName == other.ClusterServicePlanExternalName
            && ClusterServiceClassExternalID == other.ClusterServiceClassExternalID
            && ClusterServicePlanExternalID == other.ClusterServicePlanExternalID
            && ClusterServiceClassName == other.ClusterServiceClassName
            && ClusterServicePlanName == other.ClusterServicePlanName
            && UpdateRequests == other.UpdateRequests;

        public override bool Equals(object obj) => obj is ServiceInstanceSpec other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ExternalID?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ (ClusterServiceClassExternalName?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (ClusterServicePlanExternalName?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (ClusterServiceClassExternalID?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (ClusterServicePlanExternalID?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (ClusterServiceClassName?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (ClusterServicePlanName?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ UpdateRequests.GetHashCode();
                return hashCode;
            }
        }
    }
}
