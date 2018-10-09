using FluentAssertions;
using Xunit;

namespace Kubernetes.ServiceCatalog.Models
{
    public class CrdFacts
    {
        [Fact]
        public void CrdGenerationWorks()
        {
            Crd.For<ServiceInstance>().PluralName.Should().Be("serviceInstances");
        }
    }
}
