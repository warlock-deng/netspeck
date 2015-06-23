using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace speck.Web.Controllers.Home
{
    /// <summary>
    /// 主页控制器
    /// </summary>
    public class HomeController : BaseController
    {

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {


            return View();

        }

    }
}
