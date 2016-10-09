using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCSharp
{

    /// <summary>
    /// struct is a value-type;
    /// if we want to use method in struct, we have to new a person;
    /// or we could just use it directly.
    /// We cannot set value to field in a struct, unless they are declared as const or static.
    /// Struct can implement interface
    /// </summary>
    public struct Person
    {
        private string name;
        public string sex;

        public void setName(string name)
        {
            this.name = name;
        }

        public string getName()
        {
            return this.name;
        }

    }


    class StructsLearning
    {
        public void testStruct()
        {
            Person p = new Person();
            p.setName("Henry");
            p.sex = "male";
        }
    }
}
