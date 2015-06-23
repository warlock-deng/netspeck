using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace speck.Web.Controllers.Admin
{
    public class AdminController : BaseController
    {

        public AdminController() { }

        /// <summary>
        /// 新增加管理员
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddAdmin()
        {
            

            return View();
        }

    }
}
