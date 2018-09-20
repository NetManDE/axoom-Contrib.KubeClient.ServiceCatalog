using JetBrains.Annotations;

namespace Kubernetes.ServiceCatalog.Models
{
    [PublicAPI]
    public class SecretKey
    {
        /// <summary>
        /// The name of the secret in the pod's namespace to select from.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The key of the secret to select from.  Must be a valid secret key.
        /// </summary>
        public string Key { get; set; }
    }
}