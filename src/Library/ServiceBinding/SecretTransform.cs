using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Contrib.KubeClient.ServiceCatalog
{
    /// <summary>
    /// SecretTransform is a single transformation of the credentials returned
    /// from the broker
    /// </summary>
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class SecretTransform
    {
        public RenameKeyTransform RenameKey { get; set; }
        public AddKeyTransform AddKey { get; set; }
        public AddKeysFromTransform AddKeysFrom { get; set; }
        public RemoveKeyTransform RemoveKey { get; set; }
    }
}