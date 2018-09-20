using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Kubernetes.ServiceCatalog.Models
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
                var hashCode = (URL != null ? URL.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ InsecureSkipTLSVerify.GetHashCode();
                hashCode = (hashCode * 397) ^ (CABundle != null ? CABundle.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) RelistBehavior;
                hashCode = (hashCode * 397) ^ RelistDuration.GetHashCode();
                hashCode = (hashCode * 397) ^ RelistRequests.GetHashCode();
                hashCode = (hashCode * 397) ^ (CatalogRestrictions != null ? CatalogRestrictions.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AuthInfo != null ? AuthInfo.GetHashCode() : 0);
                return hashCode;
            }
        }
    }

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

    /// <summary>
    /// ClusterBearerTokenAuthConfig provides config for the bearer token
    /// authentication of cluster scoped brokers.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ClusterBearerTokenAuthConfig
    {
        /// <summary>
        /// SecretRef is a reference to a Secret containing information the
        /// catalog should use to authenticate to this ClusterServiceBroker.
        ///
        /// Required field:
        /// - Secret.Data["token"] - bearer token for authentication
        /// </summary>
        public object SecretRef { get; set; }
    }

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

    /// <summary>
    /// CatalogRestrictions is a set of restrictions on which of a broker's services
    /// and plans have resources created for them.
    ///
    /// Some examples of this object are as follows:
    ///
    /// This is an example of a whitelist on service externalName.
    /// Goal: Only list Services with the externalName of FooService and BarService,
    /// Solution: restrictions := ServiceCatalogRestrictions{
    /// 		ServiceClass: ["externalName in (FooService, BarService)"]
    /// }
    ///
    /// This is an example of a blacklist on service externalName.
    /// Goal: Allow all services except the ones with the externalName of FooService and BarService,
    /// Solution: restrictions := ServiceCatalogRestrictions{
    /// 		ServiceClass: ["externalName notin (FooService, BarService)"]
    /// }
    ///
    /// This whitelists plans called "Demo", and blacklists (but only a single element in
    /// the list) a service and a plan.
    /// Goal: Allow all plans with the externalName demo, but not AABBCC, and not a specific service by name,
    /// Solution: restrictions := ServiceCatalogRestrictions{
    /// 		ServiceClass: ["name!=AABBB-CCDD-EEGG-HIJK"]
    /// 		ServicePlan: ["externalName in (Demo)", "name!=AABBCC"]
    /// }
    ///
    /// CatalogRestrictions strings have a special format similar to Label Selectors,
    /// except the catalog supports only a very specific property set.
    ///
    /// The predicate format is expected to be `"property conditional requirement`
    /// Check the *Requirements type definition for which property strings will be allowed.
    /// conditional is allowed to be one of the following: ==, !=, in, notin
    /// requirement will be a string value if `==` or `!=` are used.
    /// requirement will be a set of string values if `in` or `notin` are used.
    /// Multiple predicates are allowed to be chained with a comma (,)
    ///
    /// ServiceClass allowed property names:
    ///   name - the value set to [Cluster]ServiceClass.Name
    ///   spec.externalName - the value set to [Cluster]ServiceClass.Spec.ExternalName
    ///   spec.externalID - the value set to [Cluster]ServiceClass.Spec.ExternalID
    /// ServicePlan allowed property names:
    ///   name - the value set to [Cluster]ServicePlan.Name
    ///   spec.externalName - the value set to [Cluster]ServicePlan.Spec.ExternalName
    ///   spec.externalID - the value set to [Cluster]ServicePlan.Spec.ExternalID
    ///   spec.free - the value set to [Cluster]ServicePlan.Spec.Free
    ///   spec.serviceClassName - the value set to ServicePlan.Spec.ServiceClassRef.Name
    ///   spec.clusterServiceClass.name - the value set to ClusterServicePlan.Spec.ClusterServiceClassRef.Name
    /// </summary>
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class CatalogRestrictions
    {
        /// <summary>
        /// ServiceClass represents a selector for plans, used to filter catalog re-lists.
        /// </summary>
        public string[] ServiceClass { get; set; }

        /// <summary>
        /// ServicePlan represents a selector for classes, used to filter catalog re-lists.
        /// </summary>
        public string[] ServicePlan { get; set; }
    }

    /// <summary>
    /// ServiceBrokerRelistBehavior represents a type of broker relist behavior.
    /// Duration indicates that the broker will be
    /// relisted automatically after the specified duration has passed.
    /// Manual indicates that the broker is only
    /// relisted when the spec of the broker changes.
    /// </summary>
    public enum ServiceBrokerRelistBehavior
    {
        Duration,
        Manual
    }
}
