using System.Linq;
using FluentValidation;
using cloudCommerce.Admin.Models.DataExchange;
using cloudCommerce.Services.DataExchange.Csv;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.DataExchange
{
	public partial class CsvConfigurationValidator : AbstractValidator<CsvConfigurationModel>
	{
		public CsvConfigurationValidator(ILocalizationService localization)
		{
			RuleFor(x => x.Delimiter)
				.Must(x => !CsvConfiguration.PresetCharacters.Contains(x.ToChar(true)))
				.WithMessage(localization.GetResource("Admin.DataExchange.Csv.Delimiter.Validation"));

			RuleFor(x => x.Quote)
				.Must(x => !CsvConfiguration.PresetCharacters.Contains(x.ToChar(true)))
				.WithMessage(localization.GetResource("Admin.DataExchange.Csv.Quote.Validation"));

			RuleFor(x => x.Escape)
				.Must(x => !CsvConfiguration.PresetCharacters.Contains(x.ToChar(true)))
				.WithMessage(localization.GetResource("Admin.DataExchange.Csv.Escape.Validation"));

			
			RuleFor(x => x.Escape)
				.Must((model, x) => x != model.Delimiter)
				.WithMessage(localization.GetResource("Admin.DataExchange.Csv.EscapeDelimiter.Validation"));

			RuleFor(x => x.Quote)
				.Must((model, x) => x != model.Delimiter)
				.WithMessage(localization.GetResource("Admin.DataExchange.Csv.QuoteDelimiter.Validation"));
		}
	}
}