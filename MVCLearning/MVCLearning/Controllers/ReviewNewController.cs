using MVCLearning.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLearning.Controllers
{
    /// <summary>
    /// 这个类和RevieController区别是，后者用的是静态数据，这个用的是数据库数据
    /// </summary>
    public class ReviewNewController : Controller
    {
        DBConnection db = new DBConnection();

        // GET: ReviewNew
        public ActionResult Index([Bind(Prefix = "id")]int restaurantId)
        {
            Restaurant model = db.Restaurants.Find(restaurantId);
            if(model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        /// <summary>
        /// 这里第一个注意事项，这里参数不需要Bing(prefix="")
        /// 在view中，传了一个restaurantId过来，这个非常重要，它让view页面有了默认值！
        /// 如果没有的话就会报错
        /// 这也回答了下面那个问题，所以get提供的参数，似乎可以为表单中提供默认值！
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        public ActionResult Create(int restaurantId)
        {
            return View();
        }

        /// <summary>
        /// 这个问题比较大，主要问题是它怎么知道restaurantId的？
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(RestaurantReviewNew review)
        {
            if(ModelState.IsValid == true)
            {
                db.Views.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index", new {id = review.RestaurantId});
            }
            Console.WriteLine("123");
            return View(review);
        }

        public ActionResult Edit(int id)
        {
            RestaurantReviewNew review = db.Views.Find(id);
            return View(review);
        }

        /// <summary>
        /// 这里由于在edit 中没有传递restaurantId值，所以必须如此写！
        /// Entity更新的方法很奇特，要记住！
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(RestaurantReviewNew review)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }
            Console.WriteLine("123");
            return View(review);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}