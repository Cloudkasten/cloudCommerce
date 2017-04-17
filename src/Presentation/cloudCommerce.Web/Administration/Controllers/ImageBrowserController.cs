using System.IO;
using cloudCommerce.Web.Framework.Controllers;
using cloudCommerce.Web.Framework.Security;
using Telerik.Web.Mvc.UI;

//Original code can be found here http://demos.telerik.com/aspnet-mvc/razor/editor/imagetool
namespace cloudCommerce.Admin.Controllers
{
    [AdminAuthorize]
    public class ImageBrowserController : EditorFileBrowserController
    {
        private const string UploadedImagesFolder = "~/Media/Uploaded/";

        /// <summary>
        /// Gets the base paths from which content will be served.
        /// </summary>
        public override string[] ContentPaths
        {
            get
            {
                var path = Server.MapPath(UploadedImagesFolder);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                return new[] { UploadedImagesFolder };
            }
        }
    }
}
