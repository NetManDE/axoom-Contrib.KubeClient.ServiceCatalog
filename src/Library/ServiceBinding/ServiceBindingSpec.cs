using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

namespace Kubernetes.ServiceCatalog.Models
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
    public class ServiceBindingSpec: IEquatable<ServiceBindingSpec>
    {
        /// <summary>
        /// ServiceInstanceRef is the reference to the Instance this ServiceBinding is to.#
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
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(ServiceInstanceRef, other.ServiceInstanceRef)
                && Equals(Parameters, other.Parameters)
                && Equals(ParametersFrom, other.ParametersFrom)
                && string.Equals(SecretName, other.SecretName)
                && Equals(SecretTransforms, other.SecretTransforms)
                && string.Equals(ExternalID, other.ExternalID);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ServiceBindingSpec) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (ServiceInstanceRef != null ? ServiceInstanceRef.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Parameters != null ? Parameters.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ParametersFrom != null ? ParametersFrom.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (SecretName != null ? SecretName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (SecretTransforms != null ? SecretTransforms.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ExternalID != null ? ExternalID.GetHashCode() : 0);
                return hashCode;
            }
        }
    }

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

    /// <summary>
    /// RenameKeyTransform specifies that one of the credentials keys returned
    /// from the broker should be renamed
    /// </summary>
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class RenameKeyTransform
    {
        public string From { get; set; }
        public string To { get; set; }
    }

    /// <summary>
    /// AddKeyTransform specifies that Service Catalog should add an
    /// additional entry to the Secret associated with the ServiceBinding.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class AddKeyTransform
    {
        public string Key { get; set; }
        public byte[] Value { get; set; }
        public string StringValue { get; set; }
        public string JSONPathExpression { get; set; }
    }

    /// <summary>
    /// AddKeysFromTransform specifies that Service Catalog should merge
    /// an existing secret into the the Secret associated with the ServiceBinding.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class AddKeysFromTransform
    {
        public object SecretRef { get; set; }
    }

    /// <summary>
    /// RemoveKeyTransform specifies that one of the credentials keys returned
    /// from the broker should not be included in the credentials Secret.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class RemoveKeyTransform
    {
        public string Key { get; set; }
    }
}
