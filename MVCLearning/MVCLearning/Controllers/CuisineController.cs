using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLearning.Controllers
{

    /// <summary>
    /// 1） .net如何Rounting，如何添加Rounting规则？
    /// 2） 如何传递参数
    /// 3） 如何返回文本内容，如何使文本内容更加安全（编码）？
    /// </summary>
    public class CuisineController : Controller
    {
        
        /// <summary>
        /// 理解HttpPost的重要性：
        ///     Search方法可以重载，但是如果没有HttpPost，游览器就不知道该使用哪个！
        /// ActionName可以重命名，但是要注意，如果返回View的话，一定要给view名字！
        /// Route从MVC5以后引入，可以在这定义Route信息，而不用在文件中定义
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AnotherSearch")]
        [Route("search")]
        public ActionResult Search(string name)
        {
            var message = Server.HtmlEncode(name);
            return Content(message);
        }

        [HttpGet]
        public ActionResult Search()
        {
            return Content("Search in get!");
        }
    }
}