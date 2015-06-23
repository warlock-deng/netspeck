using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using speck.Web.Common;

namespace speck.Web.Controllers
{

    public class LoginController : BaseController
    {
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AdminLogin()
        {


            return View();
        }

        [HttpPost]
        public int AdminLogin(string userName, string passWord)
        {
            int n = 0;

            return n;
        }


        /// <summary>
        /// 普通用户登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UserLogin()
        {

            return View();
        }
    }
}
