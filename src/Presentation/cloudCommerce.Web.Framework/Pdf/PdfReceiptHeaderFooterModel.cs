using cloudCommerce.Core.Domain.Common;
using cloudCommerce.Web.Framework.Modelling;
using cloudCommerce.Web.Framework.Pdf;

namespace cloudCommerce.Web.Framework.Pdf
{
	public partial class PdfReceiptHeaderFooterModel : ModelBase
    {
		public int StoreId { get; set; }

		public string StoreName { get; set; }
		public string LogoUrl { get; set; }
		public string StoreUrl { get; set; }

		public CompanyInformationSettings MerchantCompanyInfo { get; set; }
		public BankConnectionSettings MerchantBankAccount { get; set; }
		public ContactDataSettings MerchantContactData { get; set; }

		public PdfHeaderFooterVariables Variables { get; set; }
    }
}