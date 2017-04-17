using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using cloudCommerce.Core.Caching;
using cloudCommerce.Core.Infrastructure;
using cloudCommerce.Core.Infrastructure.DependencyManagement;
using cloudCommerce.Data.Setup;
using cloudCommerce.Web.Controllers;
using cloudCommerce.Web.Framework.UI;
using cloudCommerce.Web.Infrastructure.Installation;

namespace cloudCommerce.Web.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
		public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, bool isActiveModule)
        {
			//we cache presentation models between requests
			builder.RegisterType<BlogController>().WithStaticCache();
			builder.RegisterType<CatalogController>().WithStaticCache();
			builder.RegisterType<CountryController>().WithStaticCache();
			builder.RegisterType<CommonController>().WithStaticCache();
			builder.RegisterType<NewsController>().WithStaticCache();
			builder.RegisterType<PollController>().WithStaticCache();
			builder.RegisterType<ShoppingCartController>().WithStaticCache();
			builder.RegisterType<TopicController>().WithStaticCache();

			builder.RegisterType<CatalogHelper>().InstancePerRequest();

			builder.RegisterType<DefaultWidgetSelector>().As<IWidgetSelector>().InstancePerRequest();
            
            // installation localization service
            builder.RegisterType<InstallationLocalizationService>().As<IInstallationLocalizationService>().InstancePerRequest();

            // register app languages for installation
			builder.RegisterType<EnUSSeedData>()
                .As<InvariantSeedData>()
                .WithMetadata<InstallationAppLanguageMetadata>(m =>
                { 
                    m.For(em => em.Culture, "en-US");
                    m.For(em => em.Name, "English");
                    m.For(em => em.UniqueSeoCode, "en");
                    m.For(em => em.FlagImageFileName, "us.png");
                })
                .InstancePerRequest();
            builder.RegisterType<DeDESeedData>()
				.As<InvariantSeedData>()
                .WithMetadata<InstallationAppLanguageMetadata>(m =>
                {
                    m.For(em => em.Culture, "de-DE");
                    m.For(em => em.Name, "Deutsch");
                    m.For(em => em.UniqueSeoCode, "de");
                    m.For(em => em.FlagImageFileName, "de.png");
                })
                .InstancePerRequest();
        }

        public int Order
        {
            get { return 2; }
        }
    }
}
