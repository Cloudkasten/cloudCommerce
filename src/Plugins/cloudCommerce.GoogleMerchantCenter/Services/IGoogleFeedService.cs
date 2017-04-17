using System.Collections.Generic;
using cloudCommerce.GoogleMerchantCenter.Domain;
using cloudCommerce.GoogleMerchantCenter.Models;
using Telerik.Web.Mvc;

namespace cloudCommerce.GoogleMerchantCenter.Services
{
    public partial interface IGoogleFeedService
    {
		GoogleProductRecord GetGoogleProductRecord(int productId);

		List<GoogleProductRecord> GetGoogleProductRecords(int[] productIds);

		void InsertGoogleProductRecord(GoogleProductRecord record);

		void UpdateGoogleProductRecord(GoogleProductRecord record);
		
		void DeleteGoogleProductRecord(GoogleProductRecord record);

		void Upsert(int pk, string name, string value);

		GridModel<GoogleProductModel> GetGridModel(GridCommand command, string searchProductName = null, string touched = null);

		string[] GetTaxonomyList();
    }
}
