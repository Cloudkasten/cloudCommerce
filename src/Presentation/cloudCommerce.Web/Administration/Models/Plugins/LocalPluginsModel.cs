using System.Collections.Generic;
using System.Linq;
using cloudCommerce.Admin.Models.Stores;
using cloudCommerce.Collections;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Admin.Models.Plugins
{

    public class LocalPluginsModel : ModelBase
    {

        public LocalPluginsModel()
        {
            this.Groups = new Multimap<string, PluginModel>();
        }

		public List<StoreModel> AvailableStores { get; set; }

        public Multimap<string, PluginModel> Groups { get; set; }

		public bool IsSandbox { get; set; }
		public bool IsLocalhost { get; set; }

        public ICollection<PluginModel> AllPlugins
        {
            get
            {
                return Groups.SelectMany(k => k.Value).ToList().AsReadOnly();
            }
        }

    }

}