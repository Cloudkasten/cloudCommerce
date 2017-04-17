using cloudCommerce.Core.Data.Hooks;
using cloudCommerce.Core.Domain.Catalog;
using cloudCommerce.Services.Catalog;

namespace cloudCommerce.Services.Hooks
{
	public class ProductVariantAttributePostDeleteHook : PostDeleteHook<ProductVariantAttribute>
	{
		private readonly IProductAttributeService _productAttributeService;

		public ProductVariantAttributePostDeleteHook(IProductAttributeService productAttributeService)
		{
			_productAttributeService = productAttributeService;
		}

		public override void Hook(ProductVariantAttribute entity, HookEntityMetadata metadata)
		{
			if (entity != null)
			{
				_productAttributeService.DeleteProductBundleItemAttributeFilter(entity.Id);
			}
		}
	}
}
