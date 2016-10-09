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
        /// ���������ÿ��update-database����ִ�еķ����������������������
        /// 
        /// ���������﷨��Ҫע��
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(MVCLearning.Models.DBConnection context)
        {

            /**
             * ���� r => r.name��ָ�ж��Ƿ��ظ��Ǹ���name
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
