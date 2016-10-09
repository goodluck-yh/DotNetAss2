using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCSharp
{
    class BaseClass
    {
        private int a, b;
        public BaseClass()
        {
            a = 1;
            b = 2;
        }

        public BaseClass(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public virtual void print()
        {
            Console.WriteLine("a={0} b={1}", a, b);
        }
    }

    /**
     * how to call base constructor
     * how to call base method
     */
    class InheritanceLearning : BaseClass
    {
        private int x, y;
        public InheritanceLearning() : base(3, 4)
        {
            x = 3;
            y = 4;
        }

        /**
         * there is a difference between override and new
         * override calls method based on instance
         * new calls method based on variable
         * 
         * If the method in the derived class is not preceded by new or override keywords, 
         *  the compiler will issue a warning and the method will behave as if the new keyword were present.
         *  So by default, program try to call method based on their variable
         *  https://msdn.microsoft.com/en-us/library/6fawty39.aspx
         *  
         *  class Base {
                public virtual void Test() { ... }
            }
            class Subclass1 : Base {
               public sealed override void Test() { ... }
            }
            class Subclass2 : Subclass1 {
               public override void Test() { ... } // FAILS!
               // If `Subclass1.Test` was not sealed, it would've compiled correctly.
            }
         * 
         */
        public sealed override void print()
        {
            //base doesn't only refer to parent, but also refer to the previous version
            //https://msdn.microsoft.com/en-us/library/6fawty39.aspx
            base.print();
            Console.WriteLine("x={0} y={1}", x, y);
        }
    }
}
