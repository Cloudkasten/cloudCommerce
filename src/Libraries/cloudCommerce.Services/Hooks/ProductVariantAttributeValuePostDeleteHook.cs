using cloudCommerce.Core.Data.Hooks;
using cloudCommerce.Core.Domain.Catalog;
using cloudCommerce.Services.Catalog;

namespace cloudCommerce.Services.Hooks
{
	public class ProductVariantAttributeValuePostDeleteHook : PostDeleteHook<ProductVariantAttributeValue>
	{
		private readonly IProductAttributeService _productAttributeService;

		public ProductVariantAttributeValuePostDeleteHook(IProductAttributeService productAttributeService)
		{
			_productAttributeService = productAttributeService;
		}

		public override void Hook(ProductVariantAttributeValue entity, HookEntityMetadata metadata)
		{
			if (entity != null)
			{
				_productAttributeService.DeleteProductBundleItemAttributeFilter(entity.ProductVariantAttributeId, entity.Id);
			}
		}
	}
}
