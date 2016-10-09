using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCSharp
{
    class ThreadLearning
    {
        static int value1 = 1;
        static int value2 = 2;
        static readonly object _lock = new object();

        /// <summary>
        ///  这个演示了如果创建一个thread
        ///  在创建的时候，必须传入一个delegate
        ///     public delegate void ThreadStart();
        ///     
        ///  Name属性是给这个thread命名
        ///  IsBackground 设置这个Thread是否为后台线程，所谓后台线程是指main线程结束后立即结束
        /// </summary>
        public static void CreateThread()
        {
            Thread thread = new Thread(Go);
            thread.Name = "AnotherThread";
            thread.IsBackground = true;
            thread.Start();
            Go();
        }


        /// <summary>
        /// 有两种方法向Thread传递参数
        /// 比较推荐下面那种
        /// 更多可以参考 http://www.albahari.com/threading/
        /// </summary>
        public static void PassParaToThread()
        {
            Thread thread = new Thread(() => { Print("Hello World"); } );
            thread.Start();
        }

        /// <summary>
        /// 这里使用lock方法给一个对象加锁
        /// </summary>
        public static void Locker()
        {
            lock (_lock)
            {
                if (value2 != 0)
                    Console.WriteLine(value1 / value2);
                Console.WriteLine(0);
            }
        }

        private static void Print(String info)
        {
            Console.WriteLine(info);
        }

        private static void Go()
        {
            Console.WriteLine("Hello");
        }


    }
}
