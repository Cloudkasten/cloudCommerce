using System.Collections.Generic;
using cloudCommerce.Web.Framework.Modelling;
using cloudCommerce.Web.Models.Media;

namespace cloudCommerce.Web.Models.ShoppingCart
{
    public partial class MiniShoppingCartModel : ModelBase
    {
        public MiniShoppingCartModel()
        {
            Items = new List<ShoppingCartItemModel>();
        }

        public IList<ShoppingCartItemModel> Items { get; set; }
        public int TotalProducts { get; set; }
        public string SubTotal { get; set; }
        public bool DisplayShoppingCartButton { get; set; }
        public bool DisplayCheckoutButton { get; set; }
        public bool CurrentCustomerIsGuest { get; set; }
        public bool AnonymousCheckoutAllowed { get; set; }
        public bool ShowProductImages { get; set; }
        public int ThumbSize { get; set; }
        public int IgnoredProductsCount { get; set; }


        #region Nested Classes

        public partial class ShoppingCartItemModel : EntityModelBase
        {
            public ShoppingCartItemModel()
            {
                Picture = new PictureModel();
                BundleItems = new List<ShoppingCartItemBundleItem>();
            }

            public int ProductId { get; set; }

            public string ProductName { get; set; }

            public string ProductSeName { get; set; }

			public string ProductUrl { get; set; }

            public int Quantity { get; set; }

            public string UnitPrice { get; set; }

            public string AttributeInfo { get; set; }

            public PictureModel Picture { get; set; }

            public IList<ShoppingCartItemBundleItem> BundleItems { get; set; }

        }

        public partial class ShoppingCartItemBundleItem : ModelBase 
        {
            public string PictureUrl { get; set; }
            public string ProductName { get; set; }
            public string ProductSeName { get; set; }
			public string ProductUrl { get; set; }
        }

        #endregion
    }
}