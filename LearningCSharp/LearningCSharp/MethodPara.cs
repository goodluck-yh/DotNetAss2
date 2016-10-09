using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCSharp
{
    class MethodPara
    {
        /* You also can send no arguments.
         * If you send no arguments, the length of the params list is zero.
         * No additional parameters are permitted after the params keyword in a method declaration.
         * And only one params keyword is permitted in a method declaration.
         * Compared with an array, params's benefit is that it could be zero.
         */
        public void TestPara(params Object[] list)
        {
            foreach(var i in list)
            {
                Console.Write("{0} ", i);
            }
           
        }


        /**
         * ref means it uses reference pass rather than value pass
         * ref is needed in both calling and called method
         * overloading will not work if the only difference is out and ref
         *  but it will work if one has ref and another one doesn't
         * i must be initilized before this method is called
         * 
         * https://msdn.microsoft.com/en-us/library/14akc2c7.aspx
         * more information is provided by this link
         */
        public void TestRef(ref int i)
        {
            i++;
        }


        /*
         * out is quite similar to ref
         * out value cannot be used unless it is set value in called method
         */
        public void TestOut(out string i)
        {
            //compiler error!
            //Console.WriteLine(i);
            i = "I is set in called method";
            Console.WriteLine(i);
        }

    }
}
