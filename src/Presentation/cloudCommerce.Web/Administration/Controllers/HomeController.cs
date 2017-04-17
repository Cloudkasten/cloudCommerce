using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Web.Mvc;
using System.Xml;
using cloudCommerce.Admin.Models.Common;
using cloudCommerce.Core;
using cloudCommerce.Core.Domain.Common;
using cloudCommerce.Services;
using cloudCommerce.Services.Common;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Controllers;
using cloudCommerce.Web.Framework.Security;

namespace cloudCommerce.Admin.Controllers
{
    [AdminAuthorize]
    public class HomeController : AdminControllerBase
    {
        #region Fields

		private readonly ICommonServices _services;
		private readonly CommonSettings _commonSettings;
		private readonly Lazy<IUserAgent> _userAgent;

        #endregion

        #region Ctor

		public HomeController(ICommonServices services, CommonSettings commonSettings, Lazy<IUserAgent> userAgent)
        {
            this._commonSettings = commonSettings;
			this._services = services;
			this._userAgent = userAgent;
        }

        #endregion

        #region Methods

        public ActionResult Index()
        {
            return View();
        }

		public ActionResult About()
		{
			return View();
		}

		public ActionResult UaTester(string ua = null)
		{
			if (ua.HasValue())
			{
				_userAgent.Value.RawValue = ua;
			}
			return View(_userAgent.Value);
		}

        [ChildActionOnly]
        public ActionResult cloudCommerceNews()
        {
            try
            {
                string feedUrl = string.Format("http://www.smartstore.com/NewsRSS.aspx?Version={0}&Localhost={1}&HideAdvertisements={2}&StoreURL={3}",
                    cloudCommerceVersion.CurrentVersion,
                    Request.Url.IsLoopback,
                    _commonSettings.HideAdvertisementsOnAdminArea,
					_services.StoreContext.CurrentStore.Url);

                //specify timeout (5 secs)
                var request = WebRequest.Create(feedUrl);
                request.Timeout = 5000;
                using (WebResponse response = request.GetResponse())
                using (var reader = XmlReader.Create(response.GetResponseStream()))
                {
                    var rssData = SyndicationFeed.Load(reader);
                    return PartialView(rssData);
                }
            }
            catch (Exception)
            {
                return Content("");
            }
        }

		[ChildActionOnly]
		public ActionResult MarketplaceFeed()
		{
			var result = _services.Cache.Get("Dashboard.MarketplaceFeed", () => {
				try
				{
					string url = "http://community.smartstore.com/index.php?/rss/downloads/";
					var request = (HttpWebRequest)WebRequest.Create(url);
					request.Timeout = 3000;
					request.UserAgent = "cloudCommerce.NET {0}".FormatInvariant(cloudCommerceVersion.CurrentFullVersion);

					using (WebResponse response = request.GetResponse())
					{
						using (var reader = XmlReader.Create(response.GetResponseStream()))
						{
							var feed = SyndicationFeed.Load(reader);
							var model = new List<FeedItemModel>();
							foreach (var item in feed.Items)
							{
								if (!item.Id.EndsWith("error=1", StringComparison.OrdinalIgnoreCase))
								{
									var modelItem = new FeedItemModel();
									modelItem.Title = item.Title.Text;
									modelItem.Summary = item.Summary.Text.RemoveHtml().Truncate(150, "...");
									modelItem.PublishDate = item.PublishDate.LocalDateTime.RelativeFormat();

									var link = item.Links.FirstOrDefault();
									if (link != null)
									{
										modelItem.Link = link.Uri.ToString();
									}

									model.Add(modelItem);
								}
							}

							return model;
						}
					}
				}
				catch (Exception ex)
				{
					return new List<FeedItemModel> {new FeedItemModel { IsError = true, Summary = ex.Message } };
				}
			}, 720 /* 12 h */);

			if (result.Any() && result.First().IsError)
			{
				ModelState.AddModelError("", result.First().Summary);
			}

			return PartialView(result);
		}

        [HttpPost]
        public ActionResult cloudCommerceNewsHideAdv()
        {
            _commonSettings.HideAdvertisementsOnAdminArea = !_commonSettings.HideAdvertisementsOnAdminArea;
			_services.Settings.SaveSetting(_commonSettings);
            return Content("Setting changed");
        }

        #endregion
    }
}
