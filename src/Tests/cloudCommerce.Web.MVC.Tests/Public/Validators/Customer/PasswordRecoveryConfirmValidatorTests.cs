using FluentValidation.TestHelper;
using cloudCommerce.Core.Domain.Customers;
using cloudCommerce.Web.Models.Customer;
using cloudCommerce.Web.Validators.Customer;
using NUnit.Framework;

namespace cloudCommerce.Web.MVC.Tests.Public.Validators.Customer
{
    [TestFixture]
    public class PasswordRecoveryConfirmValidatorTests : BaseValidatorTests
    {
        private PasswordRecoveryConfirmValidator _validator;
        private CustomerSettings _customerSettings;
        
        [SetUp]
        public new void Setup()
        {
            _customerSettings = new CustomerSettings();
            _validator = new PasswordRecoveryConfirmValidator(_localizationService, _customerSettings);
        }

        [Test]
        public void Should_have_error_when_newPassword_is_null_or_empty()
        {
            var model = new PasswordRecoveryConfirmModel();
            model.NewPassword = null;
            //we know that new password should equal confirmation password
            model.ConfirmNewPassword = model.NewPassword;
            _validator.ShouldHaveValidationErrorFor(x => x.NewPassword, model);
            model.NewPassword = "";
            //we know that new password should equal confirmation password
            model.ConfirmNewPassword = model.NewPassword;
            _validator.ShouldHaveValidationErrorFor(x => x.NewPassword, model);
        }

        [Test]
        public void Should_not_have_error_when_newPassword_is_specified()
        {
            var model = new PasswordRecoveryConfirmModel();
            model.NewPassword = "new password";
            //we know that new password should equal confirmation password
            model.ConfirmNewPassword = model.NewPassword;
            _validator.ShouldNotHaveValidationErrorFor(x => x.NewPassword, model);
        }

        [Test]
        public void Should_have_error_when_confirmNewPassword_is_null_or_empty()
        {
            var model = new PasswordRecoveryConfirmModel();
            model.ConfirmNewPassword = null;
            _validator.ShouldHaveValidationErrorFor(x => x.ConfirmNewPassword, model);
            model.ConfirmNewPassword = "";
            _validator.ShouldHaveValidationErrorFor(x => x.ConfirmNewPassword, model);
        }

        [Test]
        public void Should_not_have_error_when_confirmNewPassword_is_specified()
        {
            var model = new PasswordRecoveryConfirmModel();
            model.ConfirmNewPassword = "some password";
            //we know that new password should equal confirmation password
            model.NewPassword = model.ConfirmNewPassword;
            _validator.ShouldNotHaveValidationErrorFor(x => x.ConfirmNewPassword, model);
        }

        [Test]
        public void Should_have_error_when_newPassword_doesnot_equal_confirmationPassword()
        {
            var model = new PasswordRecoveryConfirmModel();
            model.NewPassword = "some password";
            model.ConfirmNewPassword = "another password";
            _validator.ShouldHaveValidationErrorFor(x => x.ConfirmNewPassword, model);
        }

        [Test]
        public void Should_not_have_error_when_newPassword_equals_confirmationPassword()
        {
            var model = new PasswordRecoveryConfirmModel();
            model.NewPassword = "some password";
            model.ConfirmNewPassword = "some password";
            _validator.ShouldNotHaveValidationErrorFor(x => x.NewPassword, model);
        }

        [Test]
        public void Should_validate_newPassword_is_length()
        {
            _customerSettings.PasswordMinLength = 5;
            _validator = new PasswordRecoveryConfirmValidator(_localizationService, _customerSettings);

            var model = new PasswordRecoveryConfirmModel();
            model.NewPassword = "1234";
            //we know that new password should equal confirmation password
            model.ConfirmNewPassword = model.NewPassword;
            _validator.ShouldHaveValidationErrorFor(x => x.NewPassword, model);
            model.NewPassword = "12345";
            //we know that new password should equal confirmation password
            model.ConfirmNewPassword = model.NewPassword;
            _validator.ShouldNotHaveValidationErrorFor(x => x.NewPassword, model);
        }
    }
}
