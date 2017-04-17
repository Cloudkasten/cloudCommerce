namespace cloudCommerce.Services.Payments
{
    /// <summary>
    /// Represents a recurring payment type
    /// </summary>
    public enum RecurringPaymentType : int
    {
        /// <summary>
        /// Not supported
        /// </summary>
        NotSupported = 0,
        /// <summary>
        /// Manual
        /// </summary>
        Manual = 10,
        /// <summary>
        /// Automatic (payment is processed on payment gateway site)
        /// </summary>
        Automatic = 20
    }
}
