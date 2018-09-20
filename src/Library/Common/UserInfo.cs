using System.Collections.Generic;
using JetBrains.Annotations;

namespace Kubernetes.ServiceCatalog.Models
{
    /// <summary>
    /// UserInfo holds information about the user that last changed a resource's spec.
    /// </summary>
    [PublicAPI]
    public class UserInfo
    {
        public string Username { get; set; }
        public string UID { get; set; }
        public string[] Groups { get; set; }
        public Dictionary<string, string[]> Extra { get; set; }
    }
}