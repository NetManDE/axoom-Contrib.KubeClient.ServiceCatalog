using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Kubernetes.ServiceCatalog.Models
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ClusterServicePlanStatus: IEquatable<ClusterServicePlanStatus>
    {
        /// <summary>
        /// RemovedFromBrokerCatalog indicates that the broker removed the plan
        /// from its catalog.
        /// </summary>
        public bool RemovedFromBrokerCatalog { get; set; }

        public bool Equals(ClusterServicePlanStatus other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return RemovedFromBrokerCatalog == other.RemovedFromBrokerCatalog;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ClusterServicePlanStatus) obj);
        }

        public override int GetHashCode() => RemovedFromBrokerCatalog.GetHashCode();
    }
}
