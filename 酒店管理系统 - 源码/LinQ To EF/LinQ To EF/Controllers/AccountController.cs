using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LinQ_To_EF.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Login()
        {
            return View(new ViewModels.Account.Login());
        }

        [HttpPost]
        public ActionResult Login(string uid, string pwd, string code)
        {
            using(var db = new TavernManageEntities())
            {
                MD5 md5 = MD5.Create();
                var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes( pwd==null?"":pwd.Trim()));
                var md5Pwd =BitConverter.ToString(bytes);
                var count = db.T_StaffList.Where(a => a.StaffID == uid && a.StaffPwdMD5 == md5Pwd).Count();
                ViewModels._RootLayout.userId = uid;
                if (count > 0)
                    return Content(true.ToString());
                else
                {
                    return Content(false.ToString());
                }
            }
        }

    }
}
