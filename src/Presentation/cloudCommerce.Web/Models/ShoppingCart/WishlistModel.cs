using System;
using System.Collections.Generic;
using System.Web.Mvc;
using cloudCommerce.Core.Domain.Catalog;
using cloudCommerce.Web.Framework.Modelling;
using cloudCommerce.Web.Models.Media;

namespace cloudCommerce.Web.Models.ShoppingCart
{
    public partial class WishlistModel : ModelBase
    {
        public WishlistModel()
        {
            Items = new List<ShoppingCartItemModel>();
            Warnings = new List<string>();
        }

        public Guid CustomerGuid { get; set; }
        public string CustomerFullname { get; set; }

        public bool EmailWishlistEnabled { get; set; }

        public bool ShowSku { get; set; }

        public bool ShowProductImages { get; set; }

        public bool IsEditable { get; set; }

        public bool DisplayAddToCart { get; set; }

        public IList<ShoppingCartItemModel> Items { get; set; }

        public IList<string> Warnings { get; set; }

        public int ThumbSize { get; set; }
		public int BundleThumbSize { get; set; }
        public int IgnoredProductsCount { get; set; }
		public bool DisplayShortDesc { get; set; }
		public bool ShowProductBundleImages { get; set; }
		public bool ShowItemsFromWishlistToCartButton { get; set; }
        
		#region Nested Classes

        public partial class ShoppingCartItemModel : EntityModelBase
        {
            public ShoppingCartItemModel()
            {
                Picture = new PictureModel();
                AllowedQuantities = new List<SelectListItem>();
                Warnings = new List<string>();
				ChildItems = new List<ShoppingCartItemModel>();
				BundleItem = new BundleItemModel();
            }

            public string Sku { get; set; }

            public PictureModel Picture {get;set;}

            public int ProductId { get; set; }

            public string ProductName { get; set; }

            public string ProductSeName { get; set; }

			public string ProductUrl { get; set; }

			public bool VisibleIndividually { get; set; }

			public ProductType ProductType { get; set; }

            public string UnitPrice { get; set; }

            public string SubTotal { get; set; }

            public string Discount { get; set; }

            public int Quantity { get; set; }
            public List<SelectListItem> AllowedQuantities { get; set; }
            
            public string AttributeInfo { get; set; }

            public string RecurringInfo { get; set; }

            public IList<string> Warnings { get; set; }

			public string ShortDesc { get; set; }

			public bool BundlePerItemPricing { get; set; }
			public bool BundlePerItemShoppingCart { get; set; }
			public BundleItemModel BundleItem { get; set; }
			public IList<ShoppingCartItemModel> ChildItems { get; set; }
        }

		public partial class BundleItemModel : EntityModelBase
		{
			public string PriceWithDiscount { get; set; }
			public int DisplayOrder { get; set; }
			public bool HideThumbnail { get; set; }
		}

		#endregion
    }
}