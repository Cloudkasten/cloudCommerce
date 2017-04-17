using System.Collections.Generic;
using System.Linq;
using cloudCommerce.Core.Caching;
using cloudCommerce.Core.Data;
using cloudCommerce.Core.Domain.Localization;
using cloudCommerce.Core.Events;
using cloudCommerce.Core.Domain.Stores;
using cloudCommerce.Services.Configuration;
using cloudCommerce.Services.Customers;
using cloudCommerce.Services.Localization;
using cloudCommerce.Tests;
using NUnit.Framework;
using Rhino.Mocks;
using cloudCommerce.Services.Stores;
using cloudCommerce.Core;

namespace cloudCommerce.Services.Tests.Localization
{
    [TestFixture]
    public class LanguageServiceTests : ServiceTest
    {
        IRepository<Language> _languageRepo;
		IStoreMappingService _storeMappingService;
		IStoreService _storeService;
		IStoreContext _storeContext;
        ILanguageService _languageService;
        ISettingService _settingService;
        IEventPublisher _eventPublisher;
        LocalizationSettings _localizationSettings;

        [SetUp]
        public new void SetUp()
        {
            _languageRepo = MockRepository.GenerateMock<IRepository<Language>>();
            var lang1 = new Language
            {
                Name = "English",
                LanguageCulture = "en-Us",
                FlagImageFileName = "us.png",
                Published = true,
                DisplayOrder = 1
            };
            var lang2 = new Language
            {
                Name = "Russian",
                LanguageCulture = "ru-Ru",
                FlagImageFileName = "ru.png",
                Published = true,
                DisplayOrder = 2
            };

            _languageRepo.Expect(x => x.Table).Return(new List<Language>() { lang1, lang2 }.AsQueryable());

			_storeMappingService = MockRepository.GenerateMock<IStoreMappingService>();
			_storeService = MockRepository.GenerateMock<IStoreService>();
			_storeContext = MockRepository.GenerateMock<IStoreContext>();

            var cacheManager = new NullCache();

            _settingService = MockRepository.GenerateMock<ISettingService>();

            _eventPublisher = MockRepository.GenerateMock<IEventPublisher>();
            _eventPublisher.Expect(x => x.Publish(Arg<object>.Is.Anything));

            _localizationSettings = new LocalizationSettings();
			_languageService = new LanguageService(
				cacheManager, 
				_languageRepo,
				_settingService, 
				_localizationSettings, 
				_eventPublisher, 
				_storeMappingService,
				_storeService,
				_storeContext);
        }

        [Test]
        public void Can_get_all_languages()
        {
            var languages = _languageService.GetAllLanguages();
            languages.ShouldNotBeNull();
            (languages.Count > 0).ShouldBeTrue();
        }
    }
}
