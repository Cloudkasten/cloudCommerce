using System.Web.Optimization;

namespace cloudCommerce.Web.Framework.Bundling
{
    public interface IBundleProvider
    {
        void RegisterBundles(BundleCollection bundles);

        int Priority { get; }
    }
}
