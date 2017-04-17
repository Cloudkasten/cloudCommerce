using cloudCommerce.Core.Domain.Tax;
using cloudCommerce.Tests;
using NUnit.Framework;

namespace cloudCommerce.Data.Tests.Tax
{
    [TestFixture]
    public class TaxCategoryPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_taxCategory()
        {
            var taxCategory = new TaxCategory
                               {
                                   Name = "Books",
                                   DisplayOrder = 1
                               };

            var fromDb = SaveAndLoadEntity(taxCategory);
            fromDb.ShouldNotBeNull();
            fromDb.Name.ShouldEqual("Books");
            fromDb.DisplayOrder.ShouldEqual(1);
        }
    }
}