using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCSharp
{
    class PropLearning
    {
        private int month;

        /// <summary>
        ///  下面就是一个prop，它不是field，所以不能用out或者ref修饰
        ///  有一个隐藏的参数，value，和prop类型一样
        /// </summary>
        public int Month
        {
            get
            {
                return month;
            }
            set
            {
                month = value;
            }
        }
    }
}
