using System.Collections.Generic;
using cloudCommerce.Core.Domain.Blogs;
using cloudCommerce.Core.Domain.Catalog;
using cloudCommerce.Core.Domain.Customers;
using cloudCommerce.Core.Domain.Forums;
using cloudCommerce.Core.Domain.Localization;
using cloudCommerce.Core.Domain.Messages;
using cloudCommerce.Core.Domain.News;
using cloudCommerce.Core.Domain.Orders;
using cloudCommerce.Core.Domain.Shipping;
using cloudCommerce.Core.Domain.Stores;

namespace cloudCommerce.Services.Messages
{
	public partial interface IMessageTokenProvider
    {
		void AddStoreTokens(IList<Token> tokens, Store store);

		void AddOrderTokens(IList<Token> tokens, Order order, Language language);

        void AddShipmentTokens(IList<Token> tokens, Shipment shipment, Language language);

        void AddOrderNoteTokens(IList<Token> tokens, OrderNote orderNote);

        void AddRecurringPaymentTokens(IList<Token> tokens, RecurringPayment recurringPayment);

        void AddReturnRequestTokens(IList<Token> tokens, ReturnRequest returnRequest, OrderItem orderItem);

        void AddGiftCardTokens(IList<Token> tokens, GiftCard giftCard);

        void AddCustomerTokens(IList<Token> tokens, Customer customer);

        void AddNewsLetterSubscriptionTokens(IList<Token> tokens, NewsLetterSubscription subscription);

        void AddProductReviewTokens(IList<Token> tokens, ProductReview productReview);

        void AddBlogCommentTokens(IList<Token> tokens, BlogComment blogComment);

        void AddNewsCommentTokens(IList<Token> tokens, NewsComment newsComment);

		void AddProductTokens(IList<Token> tokens, Product product, Language language);

		void AddForumTokens(IList<Token> tokens, Forum forum, Language language);

        void AddForumTopicTokens(IList<Token> tokens, ForumTopic forumTopic,
            int? friendlyForumTopicPageIndex = null, int? appendedPostIdentifierAnchor = null);

        void AddForumPostTokens(IList<Token> tokens, ForumPost forumPost);

        void AddPrivateMessageTokens(IList<Token> tokens, PrivateMessage privateMessage);

        void AddBackInStockTokens(IList<Token> tokens, BackInStockSubscription subscription);

        string[] GetListOfCampaignAllowedTokens();

        string[] GetListOfAllowedTokens();

        void AddBankConnectionTokens(IList<Token> tokens);
        
        void AddCompanyTokens(IList<Token> tokens);

        void AddContactDataTokens(IList<Token> tokens);
    }
}
