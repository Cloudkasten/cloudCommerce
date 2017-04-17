using System.Linq;
using cloudCommerce.Core.Infrastructure;
using cloudCommerce.Tests;
using NUnit.Framework;

namespace cloudCommerce.Core.Tests.Infrastructure
{
    [TestFixture]
    public class TypeFinderTests
    {
        [Test]
        public void TypeFinder_Benchmark_Findings()
        {
            var finder = new AppDomainTypeFinder();

            var type = finder.FindClassesOfType<ISomeInterface>();
            type.Count().ShouldEqual(1);
            typeof(ISomeInterface).IsAssignableFrom(type.FirstOrDefault()).ShouldBeTrue();
        }

        public interface ISomeInterface
        {
        }

        public class SomeClass : ISomeInterface
        {
        }
    }
}
