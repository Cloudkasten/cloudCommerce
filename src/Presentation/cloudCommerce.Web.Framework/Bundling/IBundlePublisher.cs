using System.Web.Optimization;

namespace cloudCommerce.Web.Framework.Bundling
{
    public interface IBundlePublisher
    {
        void RegisterBundles(BundleCollection bundles);
    }
}
