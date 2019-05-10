using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Contrib.KubeClient.ServiceCatalog
{
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
}