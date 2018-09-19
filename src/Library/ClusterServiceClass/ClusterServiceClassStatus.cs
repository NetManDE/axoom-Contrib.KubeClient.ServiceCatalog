using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Kubernetes.ServiceCatalog.Models
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ClusterServiceClassStatus : IEquatable<ClusterServiceClassStatus>
    {
        /// <summary>
        /// RemovedFromBrokerCatalog indicates that the broker removed the service from its
        /// catalog.
        /// </summary>
        public bool RemovedFromBrokerCatalog { get; set; }

        public bool Equals(ClusterServiceClassStatus other)
        {
            if (ReferenceEquals(null, other)) return false;
            return RemovedFromBrokerCatalog == other.RemovedFromBrokerCatalog;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ClusterServiceClassStatus) obj);
        }

        public override int GetHashCode() => RemovedFromBrokerCatalog.GetHashCode();
    }
}
