using System;
using System.Collections.Generic;
using System.Web.Routing;
using cloudCommerce.Core.Domain.Orders;
using cloudCommerce.Core.Domain.Payments;
using cloudCommerce.Core.Plugins;
using cloudCommerce.OfflinePayment.Settings;
using cloudCommerce.Services.Configuration;
using cloudCommerce.Services.Localization;
using cloudCommerce.Services.Payments;

namespace cloudCommerce.OfflinePayment
{
    [SystemName("cloudCommerce.PurchaseOrderNumber")]
    [FriendlyName("Purchase Order Number")]
    [DisplayOrder(10)]
    public class PurchaseOrderNumberProvider : OfflinePaymentProviderBase<PurchaseOrderNumberPaymentSettings>, IConfigurable
    {
        private readonly ISettingService _settingService;
        private readonly ILocalizationService _localizationService;

        public PurchaseOrderNumberProvider(ISettingService settingService, ILocalizationService localizationService)
        {
            _settingService = settingService;
            _localizationService = localizationService;
        }

        public override ProcessPaymentResult ProcessPayment(ProcessPaymentRequest processPaymentRequest)
        {
            var result = new ProcessPaymentResult();
            var settings = CommonServices.Settings.LoadSetting<ManualPaymentSettings>(processPaymentRequest.StoreId);

            result.AllowStoringCreditCardNumber = true;
            switch (settings.TransactMode)
            {
                case TransactMode.Pending:
                    result.NewPaymentStatus = PaymentStatus.Pending;
                    break;
                case TransactMode.Authorize:
                    result.NewPaymentStatus = PaymentStatus.Authorized;
                    break;
                case TransactMode.Paid:
                    result.NewPaymentStatus = PaymentStatus.Paid;
                    break;
                default:
                    {
                        result.AddError(T("Common.Payment.TranactionTypeNotSupported"));
                        return result;
                    }
            }

            return result;
        }

        public override bool RequiresInteraction
        {
            get
            {
                return true;
            }
        }

        protected override string GetActionPrefix()
        {
            return "PurchaseOrderNumber";
        }

    }
}
