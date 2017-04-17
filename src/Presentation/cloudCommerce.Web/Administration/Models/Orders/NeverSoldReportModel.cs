using System;
using System.ComponentModel.DataAnnotations;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Admin.Models.Orders
{
    public class NeverSoldReportModel : ModelBase
    {
        [SmartResourceDisplayName("Admin.SalesReport.NeverSold.StartDate")]
        public DateTime? StartDate { get; set; }

        [SmartResourceDisplayName("Admin.SalesReport.NeverSold.EndDate")]
        public DateTime? EndDate { get; set; }
    }
}