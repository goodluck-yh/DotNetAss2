namespace MVCLearning.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCLearning.Models.DBConnection>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MVCLearning.Models.DBConnection";
        }


        /// <summary>
        /// 这个方法是每次update-database都会执行的方法，可以在这里插入数据
        /// 
        /// 这里插入的语法需要注意
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(MVCLearning.Models.DBConnection context)
        {

            /**
             * 这里 r => r.name是指判断是否重复是根据name
             */
            context.Restaurants.AddOrUpdate(r => r.Name,
                new Models.Restaurant
                {
                    Name = "Restaurant1",
                    City = "Shanghai",
                    Country = "China"
                },
                new Models.Restaurant
                {
                    Name = "Restaurant2",
                    City = "New York",
                    Country = "US"
                },
                new Models.Restaurant
                {
                    Name = "Restaurant3",
                    City = "Sydney",
                    Country = "Australia",
                    Reviews = new List<RestaurantReviewNew>
                    {
                        new RestaurantReviewNew {Rating=8, Body="It is good!", ReviewerName="Henry" }
                    }
                });
        }
    }
}
