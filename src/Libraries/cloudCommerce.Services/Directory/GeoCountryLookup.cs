using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using cloudCommerce.Core;
using cloudCommerce.Core.Caching;
using MaxMind.GeoIP;
using SmDir = cloudCommerce.Core.Domain.Directory;

namespace cloudCommerce.Services.Directory
{
    /// <summary>
    /// Country lookup helper
    /// </summary>
    public partial class GeoCountryLookup : IGeoCountryLookup
    {
        private readonly IWebHelper _webHelper;
		private readonly ICountryService _countryService;
		private readonly ICacheManager _cacheManager;

		public GeoCountryLookup(IWebHelper webHelper, ICacheManager cacheManager, ICountryService countryService)
        {
            this._webHelper = webHelper;
			this._cacheManager = cacheManager;
			this._countryService = countryService;
        }

		private MaxMind.GeoIP.LookupService GetLookupService() 
		{
			return _cacheManager.Get("GeoCountryLookup", () => 
			{
				var lookupService = new MaxMind.GeoIP.LookupService(_webHelper.MapPath("~/App_Data/GeoIP.dat"));
				return lookupService;
			});
		}

        public virtual string LookupCountryCode(string str)
        {
            if (String.IsNullOrEmpty(str))
                return string.Empty;

            IPAddress addr;
            try
            {
                addr = IPAddress.Parse(str);
            }
            catch
            {
                return string.Empty;
            }
            return LookupCountryCode(addr);
        }

        public virtual string LookupCountryCode(IPAddress addr)
        {
			try
			{
				var lookupService = GetLookupService();
				var country = lookupService.getCountry(addr);
				var code = country.getCode();
				if (code == "--")
					return string.Empty;

				return code;
			}
			catch 
			{
				return string.Empty;
			}
        }

        public virtual string LookupCountryName(string str)
        {
            if (String.IsNullOrEmpty(str))
                return string.Empty;

            IPAddress addr;
            try
            {
                addr = IPAddress.Parse(str);
            }
            catch
            {
                return string.Empty;
            }
            return LookupCountryName(addr);
        }

        public virtual string LookupCountryName(IPAddress addr)
        {
			try
			{
				var lookupService = GetLookupService();
				var country = lookupService.getCountry(addr);
				return country.getName();
			}
			catch
			{
				return string.Empty;
			}
        }

		public virtual bool IsEuIpAddress(string ipAddress, out SmDir.Country euCountry)
		{
			euCountry = null;

			if (ipAddress.IsEmpty())
				return false;

			euCountry = _cacheManager.Get("GeoCountryLookup.EuCountry.{0}".FormatInvariant(ipAddress), () => 
			{
				var countryCode = LookupCountryCode(ipAddress);
				if (countryCode.IsEmpty())
					return (SmDir.Country)null;

				var country = _countryService.GetCountryByTwoLetterIsoCode(countryCode);
				return country;
			});

			if (euCountry == null)
				return false;

			return euCountry.SubjectToVat;
		}

    }
}