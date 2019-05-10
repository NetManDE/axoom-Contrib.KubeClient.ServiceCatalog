using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Contrib.KubeClient.ServiceCatalog
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ClusterServiceBrokerSpec : IEquatable<ClusterServiceBrokerSpec>
    {
        /// <summary>
        /// URL is the address used to communicate with the ServiceBroker.
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// InsecureSkipTLSVerify disables TLS certificate verification when communicating with this Broker.
        /// This is strongly discouraged.  You should use the CABundle instead.
        /// +optional
        /// </summary>
        public bool InsecureSkipTLSVerify { get; set; }

        /// <summary>
        /// CABundle is a PEM encoded CA bundle which will be used to validate a Broker's serving certificate.
        /// +optional
        /// </summary>
        public byte[] CABundle { get; set; }

        /// <summary>
        /// RelistBehavior specifies the type of relist behavior the catalog should
        /// exhibit when relisting ServiceClasses available from a broker.
        /// </summary>
        public ServiceBrokerRelistBehavior RelistBehavior { get; set; }

        /// <summary>
        /// RelistDuration is the frequency by which a controller will relist the
        /// broker when the RelistBehavior is set to ServiceBrokerRelistBehaviorDuration.
        /// Users are cautioned against configuring low values for the RelistDuration,
        /// as this can easily overload the controller manager in an environment with
        /// many brokers. The actual interval is intrinsically governed by the
        /// configured resync interval of the controller, which acts as a minimum bound.
        /// For example, with a resync interval of 5m and a RelistDuration of 2m, relists
        /// will occur at the resync interval of 5m.
        /// </summary>
        public TimeSpan RelistDuration { get; set; }

        /// <summary>
        /// RelistRequests is a strictly increasing, non-negative integer counter that
        /// can be manually incremented by a user to manually trigger a relist.
        /// </summary>
        public long RelistRequests { get; set; }

        /// <summary>
        /// CatalogRestrictions is a set of restrictions on which of a broker's services
        /// and plans have resources created for them.
        /// </summary>
        CatalogRestrictions CatalogRestrictions { get; set; }

        /// <summary>
        /// AuthInfo contains the data that the service catalog should use to authenticate
        /// with the Service Broker.
        /// </summary>
        ClusterServiceBrokerAuthInfo AuthInfo { get; set; }

        public bool Equals(ClusterServiceBrokerSpec other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(URL, other.URL)
                && InsecureSkipTLSVerify == other.InsecureSkipTLSVerify
                && Equals(CABundle, other.CABundle)
                && RelistBehavior == other.RelistBehavior
                && RelistDuration.Equals(other.RelistDuration)
                && RelistRequests == other.RelistRequests
                && Equals(CatalogRestrictions, other.CatalogRestrictions)
                && Equals(AuthInfo, other.AuthInfo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ClusterServiceBrokerSpec) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = URL?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ InsecureSkipTLSVerify.GetHashCode();
                hashCode = (hashCode * 397) ^ (CABundle?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (int) RelistBehavior;
                hashCode = (hashCode * 397) ^ RelistDuration.GetHashCode();
                hashCode = (hashCode * 397) ^ RelistRequests.GetHashCode();
                hashCode = (hashCode * 397) ^ (CatalogRestrictions?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (AuthInfo?.GetHashCode() ?? 0);
                return hashCode;
            }
        }
    }
}
