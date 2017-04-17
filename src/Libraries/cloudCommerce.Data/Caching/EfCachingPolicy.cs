using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using EFCache;
using cloudCommerce.Core.Domain.Catalog;
using cloudCommerce.Core.Domain.Customers;
using cloudCommerce.Core.Domain.Directory;
using cloudCommerce.Core.Domain.Discounts;
using cloudCommerce.Core.Domain.Localization;
using cloudCommerce.Core.Domain.Logging;
using cloudCommerce.Core.Domain.Messages;
using cloudCommerce.Core.Domain.Orders;
using cloudCommerce.Core.Domain.Payments;
using cloudCommerce.Core.Domain.Security;
using cloudCommerce.Core.Domain.Shipping;
using cloudCommerce.Core.Domain.Stores;
using cloudCommerce.Core.Domain.Tax;
using cloudCommerce.Core.Domain.Themes;
using cloudCommerce.Core.Domain.Topics;

namespace cloudCommerce.Data.Caching
{
	
	/* TODO: (mc)
	 * ========================
	 *		1. Let developers register custom caching policies for single entities (from plugins)
	 *		2. Caching policies should contain expiration info and cacheable rows count
	 *		3. Backend: Let users decide which entities to cache
	 *		4. Backend: Let users purge the cache
	 */
	
	internal class EfCachingPolicy : CachingPolicy
	{
		private static readonly HashSet<string> _cacheableSets = new HashSet<string>
			{
				typeof(AclRecord).Name,
				typeof(ActivityLogType).Name,
				typeof(CategoryTemplate).Name,
				typeof(CheckoutAttribute).Name,
				typeof(CheckoutAttributeValue).Name,
				typeof(Country).Name,
				typeof(Currency).Name,
				typeof(CustomerRole).Name,
				typeof(DeliveryTime).Name,
				typeof(Discount).Name,
				typeof(DiscountRequirement).Name,
				typeof(EmailAccount).Name,
				typeof(Language).Name,
				typeof(ManufacturerTemplate).Name,
				typeof(MeasureDimension).Name,
				typeof(MeasureWeight).Name,
				typeof(MessageTemplate).Name,
				typeof(PaymentMethod).Name,
				typeof(PermissionRecord).Name,
				typeof(ProductTemplate).Name,
				typeof(QuantityUnit).Name,
				typeof(ShippingMethod).Name,
				typeof(StateProvince).Name,
				typeof(Store).Name,
				typeof(StoreMapping).Name,
				typeof(TaxCategory).Name,
				typeof(ThemeVariable).Name,
				typeof(Topic).Name
			};

		protected override bool CanBeCached(ReadOnlyCollection<EntitySetBase> affectedEntitySets, string sql, IEnumerable<KeyValuePair<string, object>> parameters)
		{
			var entitySets = affectedEntitySets.Select(x => x.Name);
			var result = entitySets.All(x => _cacheableSets.Contains(x));
			return result;
		}

		protected override void GetExpirationTimeout(ReadOnlyCollection<EntitySetBase> affectedEntitySets, out TimeSpan slidingExpiration, out DateTimeOffset absoluteExpiration)
		{
			base.GetExpirationTimeout(affectedEntitySets, out slidingExpiration, out absoluteExpiration);
			absoluteExpiration = DateTimeOffset.Now.AddHours(24);
		}

		protected override void GetCacheableRows(ReadOnlyCollection<EntitySetBase> affectedEntitySets, out int minCacheableRows, out int maxCacheableRows)
		{
			base.GetCacheableRows(affectedEntitySets, out minCacheableRows, out maxCacheableRows);
		}
	}
}
