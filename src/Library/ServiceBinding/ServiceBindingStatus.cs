using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Contrib.KubeClient.ServiceCatalog
{
    /// <summary>
    /// ServiceBindingStatus represents the current status of a ServiceBinding.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public class ServiceBindingStatus
    {
        public ServiceBindingCondition Conditions { get; set; }

        /// <summary>
        /// CurrentOperation is the operation the Controller is currently performing
        /// on the ServiceBinding.
        /// </summary>
        public ServiceBindingOperation CurrentOperation { get; set; }

        /// <summary>
        /// ReconciledGeneration is the 'Generation' of the
        /// ServiceBindingSpec that was last processed by the controller.
        /// The reconciled generation is updated even if the controller failed to
        /// process the spec.
        /// </summary>
        public long ReconciledGeneration { get; set; }

        /// <summary>
        /// OperationStartTime is the time at which the current operation began.
        /// </summary>
        public DateTime? OperationStartTime { get; set; }

        /// <summary>
        /// InProgressProperties is the properties state of the
        /// ServiceBinding when a Bind is in progress. If the current
        /// operation is an Unbind, this will be nil.
        /// </summary>
        public ServiceBindingPropertiesState InProgressProperties { get; set; }

        /// <summary>
        /// ExternalProperties is the properties state of the
        /// ServiceBinding which the broker knows about.
        /// </summary>
        public ServiceBindingPropertiesState ExternalProperties { get; set; }

        /// <summary>
        /// OrphanMitigationInProgress is a flag that represents whether orphan
        /// mitigation is in progress.
        /// </summary>
        public bool OrphanMitigationInProgress { get; set; }

        /// <summary>
        /// UnbindStatus describes what has been done to unbind a ServiceBinding
        /// </summary>
        public string UnbindStatus { get; set; }
    }
}
