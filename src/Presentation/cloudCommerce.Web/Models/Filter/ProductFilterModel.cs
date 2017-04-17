using cloudCommerce.Services.Filter;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Web.Models.Filter
{
	public partial class ProductFilterModel : ModelBase
	{
		public FilterProductContext Context { get; set; }

        public bool IsShowAllText { get; set; }

        public int MaxFilterItemsToDisplay { get; set; }

        public bool ExpandAllFilterGroups { get; set; }
	}
}