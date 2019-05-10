using JetBrains.Annotations;

namespace Contrib.KubeClient.ServiceCatalog
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