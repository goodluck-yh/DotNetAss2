using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCSharp
{
    /// <summary>
    /// 经典例子： https://code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b
    /// </summary>
    class LinqLearning
    {
        /// <summary>
        /// 这个方法测试了group into的用法
        /// 语法是 group i by value into g
        ///     i 跟from 后面变量名字一样
        ///     value是指分组的标准
        ///     g 是指组的名字，在后面select直接跟上g即可
        /// 在显示时，e.Key是组的value值，组的成员各个元素
        /// </summary>
        public void Linq1()
        {
            int[] array = {1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var numGroup =
                from i in array
                group i by i % 3 into g
                select g;

            foreach(var e in numGroup)
            {
                Console.WriteLine("The key in this group is {0}", e.Key);
                foreach (var i in e)
                {
                    Console.WriteLine("{0}", i);
                }
            }
        }

        public void Linq2()
        {
            int[] array = {1, 1, 2, 3, 3, 4, 5, 5 };
            var distinctNum =
                (from a in array
                 select a).Distinct();
            foreach(var num in distinctNum)
            {
                Console.WriteLine("{0}", num);
            }
        }
    }
}
