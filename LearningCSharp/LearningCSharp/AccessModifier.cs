using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCSharp
{
    class Base
    {

    }


    /**
     * There are five different access modifiers. By default, it is internal.
     * Struct cannot use protected
     * AccessModifier could only inheritant Base class with at least the same access
     */
    class AccessModifier : Base
    {
        private int a;
        public int b;
        protected int c;
        protected internal int cd;
        internal int d;
        int e;
    }
}
