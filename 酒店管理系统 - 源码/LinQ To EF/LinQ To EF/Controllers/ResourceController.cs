using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinQ_To_EF.Controllers
{
    public class ResourceController : Controller
    {
        //
        // GET: /Resource/
        public ActionResult BackgroundImg()
        {
            var img = Server.MapPath("5.jpg");
            return File( img , "image/jpg");
        }

    }
}
