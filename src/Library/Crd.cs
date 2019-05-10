using Contrib.KubeClient.CustomResources;

namespace Contrib.KubeClient.ServiceCatalog
{
    internal static class Crd
    {
        public static CustomResourceDefinition For(string pluralName, string kind)
            => new CustomResourceDefinition("servicecatalog.k8s.io/v1beta1", pluralName, kind);
    }
}
