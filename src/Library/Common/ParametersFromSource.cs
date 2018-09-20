using JetBrains.Annotations;

namespace Kubernetes.ServiceCatalog.Models
{
    [PublicAPI]
    public class ParametersFromSource
    {
        /// <summary>
        /// The Secret key to select from.
        /// The value must be a JSON object.
        /// </summary>
        public SecretKey SecretKey { get; set; }
    }
}