using JetBrains.Annotations;

namespace Kubernetes.ServiceCatalog.Models
{
    /// <summary>
    /// ConditionStatus represents a condition's status.
    /// These are valid condition statuses. "ConditionTrue" means a resource is in
    /// the condition; "ConditionFalse" means a resource is not in the condition;
    /// "ConditionUnknown" means kubernetes can't decide if a resource is in the
    /// condition or not. In the future, we could add other intermediate
    /// conditions, e.g. ConditionDegraded.
    /// </summary>
    [PublicAPI]
	public enum ConditionStatus
    {
        True,
        False,
        Unknown
    }
}
