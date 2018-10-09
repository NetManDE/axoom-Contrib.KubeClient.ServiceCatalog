using System.Linq;
using Contrib.KubeClient.CustomResources;

namespace Kubernetes.ServiceCatalog.Models
{
    internal static class Crd
    {
        public const string ApiVersion = "servicecatalog.k8s.io/v1beta1";

        public static CustomResourceDefinition<TResource> For<TResource>()
            where TResource : CustomResource
        {
            string typeName = typeof(TResource).Name;
            string pluralName = typeName.First().ToString().ToLowerInvariant() + typeName.Skip(1) + "s";
            return new CustomResourceDefinition<TResource>(ApiVersion, pluralName);
        }
    }
}
