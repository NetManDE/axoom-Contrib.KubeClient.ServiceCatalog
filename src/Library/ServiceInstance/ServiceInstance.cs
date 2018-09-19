using System;
using System.Diagnostics.CodeAnalysis;
using Contrib.KubeClient.CustomResources;
using JetBrains.Annotations;

namespace Kubernetes.ServiceCatalog.Models
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ServiceInstance : CustomResource<ServiceInstanceSpec, ServiceInstanceStatus>, IEquatable<ServiceInstance>
    {
        public bool Equals(ServiceInstance other)
        {
            if (other == null) return false;
            return Spec.Equals(other.Spec)
                && Status.Equals(other.Status);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return obj.GetType() == GetType() && Equals((ServiceInstance)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Spec?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ (Status?.GetHashCode() ?? 0);
                return hashCode;
            }
        }
    }
}
