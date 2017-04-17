using cloudCommerce.Core.Domain.Tax;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Web.Models.Common
{
    public partial class TaxTypeSelectorModel : ModelBase
    {
        public bool Enabled { get; set; }

        public TaxDisplayType CurrentTaxType { get; set; }
    }
}