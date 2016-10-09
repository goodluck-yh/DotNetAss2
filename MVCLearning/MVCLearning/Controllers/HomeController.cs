using MVCLearning.Filter;
using MVCLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLearning.Controllers
{
    public class HomeController : Controller
    {
        DBConnection db = new DBConnection(); 

        /// <summary>
        /// 学会如何返回值！
        /// 下面列举了常见的返回值！
        /// </summary>
        /// <returns></returns>
        [LogFilter]
        public ActionResult Index(string searchTerm = null)
        {
            /**
             * 下面这个是LINQ，是C#的一个新特性，要注意！
             * 另外一个技巧就是，它返回了一个新的Model，
             *  这样做的原因在于，有些Model是用在DB中的，有些Model 是用在View中的
             */
            var model =
                from r in db.Restaurants
                orderby r.Reviews.Average(review => review.Rating)
                select new RestaurantListViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    City = r.City,
                    Country = r.Country,
                    CountOfReviews = r.Reviews.Count()
                };

            /**
             * 下面的写法是Lamda写法，具体有些地方我还我不明白意思
             */
            //var model =
            //    db.Restaurants
            //    .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
            //    .OrderBy(r => r.Reviews.Average(review => review.Rating))
            //    .Select(r => new RestaurantListViewModel
            //    {
            //        Id = r.Id,
            //        Name = r.Name,
            //        City = r.City,
            //        Country = r.Country,
            //        CountOfReviews = r.Reviews.Count()
            //    });


            return View(model);
            //return new HttpStatusCodeResult(403);
            //return Content("This is a text");
            //return Redirect("http://www.baidu.com");
            //return RedirectToAction("Search","Cuisine",new { name = "Chinese"});
            //return RedirectToRoute("Cuisine", new { name = "Japanese"});
            //return Json(new { name="json"}, JsonRequestBehavior.AllowGet);

        }

        public ActionResult About()
        {
            var controller = RouteData.Values["Controller"];
            var action = RouteData.Values["action"];
            var id = RouteData.Values["id"];
            ViewBag.Message = string.Format("{0}/{1}/{2}", controller, action, id);

            return View();
        }

        /// <summary>
        /// 这里用的是Filter；我理解Filter就是面向切片编程；
        /// 有三个级别的Filter，知道他们每个都怎么配置：
        ///     方法级
        ///     类级
        ///     全局级
        /// 会自己编写Filter,在本类Index方法前加入了自定义
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        /// <summary>
        /// 创建了数据库连接类之后，需要手动关闭资源！
        /// 这个很容易忘记！
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if(db != null)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}