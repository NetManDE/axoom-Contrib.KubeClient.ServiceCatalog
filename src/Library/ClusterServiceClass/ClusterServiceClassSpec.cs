using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Kubernetes.ServiceCatalog.Models
{
    /// <summary>
    /// ClusterServiceClass represents an offering in the service catalog.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ClusterServiceClassSpec : IEquatable<ClusterServiceClassSpec>
    {
        /// <summary>
        /// ClusterServiceBrokerName is the reference to the ClusterServiceBroker that provides this ClusterServiceClass.
        /// </summary>
        public string ClusterServiceBrokerName { get; set; }

        /// <summary>
        /// ExternalName is the name of this object that the Service Broker
        /// exposed this Service Class as.
        /// </summary>
        public string ExternalName { get; set; }

        /// <summary>
        /// ExternalID is the identity of this object for use with the OSB API.
        /// </summary>
        public string ExternalID { get; set; }

        /// <summary>
        /// Description is a short description of this ServiceClass.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Bindable indicates whether a user can create bindings to an ServiceInstance
        /// provisioned from this service. ServicePlan has an optional field called
        /// Bindable which overrides the value of this field.
        /// </summary>
        public bool Bindable { get; set; }

        /// <summary>
        /// Currently, this field is ALPHA: it may change or disappear at any time
        /// and its data will not be migrated.
        ///
        /// BindingRetrievable indicates whether fetching a binding via a GET on
        /// its endpoint is supported for all plans.
        /// </summary>
        public bool BindingRetrievable { get; set; }

        /// <summary>
        /// PlanUpdatable indicates whether instances provisioned from this
        /// ServiceClass may change ServicePlans after being provisioned.
        /// </summary>
        public bool PlanUpdatable { get; set; }

        public bool Equals(ClusterServiceClassSpec other)
        {
            if (other == null) return false;
            return ClusterServiceBrokerName == other.ClusterServiceBrokerName
                && ExternalName == other.ExternalName
                && ExternalID == other.ExternalID
                && Description == other.Description
                && Bindable == other.Bindable
                && BindingRetrievable == other.BindingRetrievable
                && PlanUpdatable == other.PlanUpdatable;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return obj.GetType() == GetType() && Equals((ClusterServiceClassSpec)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ClusterServiceBrokerName?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ (ExternalName?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (ExternalID?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (Description?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ Bindable.GetHashCode();
                hashCode = (hashCode * 397) ^ BindingRetrievable.GetHashCode();
                hashCode = (hashCode * 397) ^ PlanUpdatable.GetHashCode();
                return hashCode;
            }
        }
    }
}
