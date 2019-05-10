using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

namespace Contrib.KubeClient.ServiceCatalog
{
    /// <summary>
    /// ServiceBindingSpec represents the desired state of a
    /// ServiceBinding.
    ///
    /// The spec field cannot be changed after a ServiceBinding is
    /// created.  Changes submitted to the spec field will be ignored.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ServiceBindingSpec : IEquatable<ServiceBindingSpec>
    {
        /// <summary>
        /// ServiceInstanceRef is the reference to the Instance this ServiceBinding is to.
        /// </summary>
        public ServiceInstance ServiceInstanceRef { get; set; }

        /// <summary>
        /// Parameters is a set of the parameters to be passed to the underlying
        /// broker. The inline YAML/JSON payload to be translated into equivalent
        /// JSON object. If a top-level parameter name exists in multiples sources
        /// among `Parameters` and `ParametersFrom` fields, it is considered to be
        /// a user error in the specification.
        ///
        /// The Parameters field is NOT secret or secured in any way and should
        /// NEVER be used to hold sensitive information. To set parameters that
        /// contain secret information, you should ALWAYS store that information
        /// in a Secret and use the ParametersFrom field.
        /// </summary>
        public JObject Parameters { get; set; }

        /// <summary>
        /// List of sources to populate parameters.
        /// If a top-level parameter name exists in multiples sources among
        /// `Parameters` and `ParametersFrom` fields, it is
        /// considered to be a user error in the specification
        /// </summary>
        public ParametersFromSource ParametersFrom { get; set; }

        /// <summary>
        /// SecretName is the name of the secret to create in the ServiceBinding's
        /// namespace that will hold the credentials associated with the ServiceBinding.
        /// </summary>
        public string SecretName { get; set; }

        /// <summary>
        /// List of transformations that should be applied to the credentials returned
        /// by the broker before they are inserted into the Secret
        /// </summary>
        public SecretTransform[] SecretTransforms { get; set; }

        /// <summary>
        /// ExternalID is the identity of this object for use with the OSB API.
        /// </summary>
        public string ExternalID { get; set; }

        public bool Equals(ServiceBindingSpec other)
            => other != null
            && Equals(Parameters, other.Parameters)
            && Equals(ParametersFrom, other.ParametersFrom)
            && SecretName == other.SecretName
            && Equals(SecretTransforms, other.SecretTransforms)
            && ExternalID == other.ExternalID;

        public override bool Equals(object obj) => obj is ServiceBindingSpec other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Parameters?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ (ParametersFrom?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (SecretName?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (SecretTransforms?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (ExternalID?.GetHashCode() ?? 0);
                return hashCode;
            }
        }
    }
}
