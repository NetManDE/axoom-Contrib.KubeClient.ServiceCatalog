using System.Linq;
using Contrib.KubeClient.CustomResources;

namespace Kubernetes.ServiceCatalog.Models
{
    internal static class Crd
    {
        public const string ApiVersion = "servicecatalog.k8s.io/v1beta1";

        public static CustomResourceDefinition<TResource> For<TResource>(string pluralName)
            where TResource : CustomResource
            => new CustomResourceDefinition<TResource>(ApiVersion, pluralName);
    }
}
