using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCLearning.Models
{
    /// <summary>
    /// 这个类是相当于JAVA中的@Entity，告诉程序model中哪些是要在数据库中创建的！
    /// 该类一定要继承DbContext，这个类需要引入System.Data.Entity才可以
    /// 在注册Entity的时候，使用property，类型使用DbSet
    /// 了解怎么修改数据库连接字符串
    /// 知道该如何插入数据
    /// 
    /// 另一个问题是migration
    ///     Enable-Migrations -ContextTypeName MVCLearning.Models.DBConnection 
    ///     Add-Migration  Update-Database -Verbose
    ///     Update-Database –TargetMigration: AddBlogUrl 
    ///     
    /// 对于数据库表结构变更，必须使用Update-Database命令才能实现
    /// </summary>
    public class DBConnection : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReviewNew> Views { get; set; }

        public System.Data.Entity.DbSet<MVCLearning.Models.RestaurantReview> RestaurantReviews { get; set; }
    }
}