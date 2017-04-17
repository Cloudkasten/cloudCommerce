using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using cloudCommerce.Services.Media;
using cloudCommerce.Services.Security;
using cloudCommerce.Web.Framework.Controllers;
using cloudCommerce.Web.Framework.Security;

namespace cloudCommerce.Admin.Controllers
{
    [AdminAuthorize]
    public class PictureController : AdminControllerBase
    {
        private readonly IPictureService _pictureService;
        private readonly IPermissionService _permissionService;

        public PictureController(IPictureService pictureService,
             IPermissionService permissionService)
        {
            this._pictureService = pictureService;
            this._permissionService = permissionService;
        }

        [HttpPost]
        public ActionResult AsyncUpload(bool isTransient = false)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.UploadPictures))
                return Json(new { success = false, error = "You do not have the required permissions" });

			var postedFile = Request.ToPostedFileResult();

			var picture = _pictureService.InsertPicture(postedFile.Buffer, postedFile.ContentType, null, true, isTransient);

            return Json(
                new { 
                    success = true, 
                    pictureId = picture.Id,
                    imageUrl = _pictureService.GetPictureUrl(picture, 100) 
                });
        }
    }
}
