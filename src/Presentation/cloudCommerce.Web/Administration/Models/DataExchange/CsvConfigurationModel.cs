using System;
using System.Text.RegularExpressions;
using FluentValidation.Attributes;
using cloudCommerce.Admin.Validators.DataExchange;
using cloudCommerce.Services.DataExchange.Csv;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Admin.Models.DataExchange
{
	[Validator(typeof(CsvConfigurationValidator))]
	public class CsvConfigurationModel : ModelBase, ICloneable<CsvConfiguration>
	{
		public CsvConfigurationModel()
		{
		}

		public CsvConfigurationModel(CsvConfiguration config)
		{
			QuoteAllFields = config.QuoteAllFields;
			TrimValues = config.TrimValues;
			SupportsMultiline = config.SupportsMultiline;
			Delimiter = Regex.Escape(config.Delimiter.ToString());
			Quote = Regex.Escape(config.Quote.ToString());
			Escape = Regex.Escape(config.Escape.ToString());
		}

		[SmartResourceDisplayName("Admin.DataExchange.Csv.QuoteAllFields")]
		public bool QuoteAllFields { get; set; }

		[SmartResourceDisplayName("Admin.DataExchange.Csv.TrimValues")]
		public bool TrimValues { get; set; }

		[SmartResourceDisplayName("Admin.DataExchange.Csv.SupportsMultiline")]
		public bool SupportsMultiline { get; set; }

		[SmartResourceDisplayName("Admin.DataExchange.Csv.Delimiter")]
		public string Delimiter { get; set; }

		[SmartResourceDisplayName("Admin.DataExchange.Csv.Quote")]
		public string Quote { get; set; }

		[SmartResourceDisplayName("Admin.DataExchange.Csv.Escape")]
		public string Escape { get; set; }

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public CsvConfiguration Clone()
		{
			var config = new CsvConfiguration();
			config.QuoteAllFields = QuoteAllFields;
			config.TrimValues = TrimValues;
			config.SupportsMultiline = SupportsMultiline;
			config.Delimiter = Delimiter.ToChar(true);
			config.Quote = Quote.ToChar(true);
			config.Escape = Escape.ToChar(true);

			return config;
		}
	}
}