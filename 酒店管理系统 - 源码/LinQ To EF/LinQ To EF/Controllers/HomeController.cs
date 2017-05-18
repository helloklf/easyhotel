using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LinQ_To_EF.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View( new ViewModels._RootLayout() );
        }

        public ActionResult Content()
        {
            return View();
        }

        public ActionResult RoomList()
        {
            return View(new LinQ_To_EF.ViewModels.Home.RoomListVM());
        }

        public ActionResult More()
        {
            return View();
        }
    }
}
