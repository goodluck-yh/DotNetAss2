using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLearning.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }


        /// <summary>
        /// 这个prop有个特殊的修饰符，virtual
        ///     virtual的意思是lazy loading
        ///     否则，在view页面中使用Review的时候，会报错！因为没有初始化
        /// </summary>
        public virtual ICollection<RestaurantReviewNew> Reviews { get; set; }
    }
}