using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

namespace Kubernetes.ServiceCatalog.Models
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ClusterServicePlanSpec : IEquatable<ClusterServicePlanSpec>
    {
        /// <summary>
        /// ExternalName is the name of this object that the Service Broker
        /// exposed this Service Plan as. Mutable.
        /// </summary>
        public string ExternalName { get; set; }

        /// <summary>
        /// ExternalID is the identity of this object for use with the OSB API.
        ///
        /// Immutable.
        /// </summary>
        public string ExternalID { get; set; }

        /// <summary>
        /// Description is a short description of this ServicePlan.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Bindable indicates whether a user can create bindings to an ServiceInstance
        /// using this ServicePlan.  If set, overrides the value of the
        /// corresponding ServiceClassSpec Bindable field.
        /// </summary>
        public bool Bindable { get; set; }

        /// <summary>
        /// Free indicates whether this ServicePlan is available at no cost.
        /// </summary>
        public bool Free { get; set; }

        /// <summary>
        /// ExternalMetadata is a blob of information about the plan, meant to be
        /// user-facing content and display instructions.  This field may contain
        /// platform-specific conventional values.
        /// </summary>
        public JObject ExternalMetadata { get; set; }

        /// <summary>
        /// DefaultProvisionParameters are default parameters passed to the broker
        /// when an instance of this plan is provisioned. Any parameters defined on
        /// the instance are merged with these defaults, with instance-defined
        /// parameters taking precedence over defaults.
        /// </summary>
        public JObject DefaultProvisionParameters { get; set; }

        /// <summary>
        /// ClusterServiceBrokerName is the name of the ClusterServiceBroker that offers this
        /// ClusterServicePlan.
        /// </summary>
        public string ClusterServiceBrokerName { get; set; }

        /// <summary>
        /// ClusterServiceClass is a reference to the service class that
        /// owns this plan.
        /// </summary>
        ClusterServiceClass ClusterServiceClass { get; set; }

        public bool Equals(ClusterServicePlanSpec other)
            => other != null
            && ExternalID == other.ExternalID
            && Description == other.Description
            && Bindable == other.Bindable
            && Free == other.Free
            && ClusterServiceBrokerName == other.ClusterServiceBrokerName;

        public override bool Equals(object obj) => obj is ClusterServicePlanSpec other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ExternalName?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ (ExternalID?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (Description?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ Bindable.GetHashCode();
                hashCode = (hashCode * 397) ^ Free.GetHashCode();
                hashCode = (hashCode * 397) ^ (ClusterServiceBrokerName?.GetHashCode() ?? 0);
                return hashCode;
            }
        }
    }
}
