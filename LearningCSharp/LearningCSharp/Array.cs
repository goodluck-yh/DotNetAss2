using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCSharp
{
    class Array
    {

        public void multiDimentionalArray()
        {
            //how to define
            int[,] array2D = new int[3, 2] { { 1, 2 }, { 2, 2 }, { 3, 3 } };
            int[,] array2D2 = { { 1, 2, 3 }, { 2, 2, 3 }, { 3, 2, 3 } };
            int[,,] array3D = { { { 1, 2 ,3}, { 2, 2,3 } }, { { 3, 2,3 }, { 4, 2 ,3} } };

            //This one is the total length, here is 12
            Console.WriteLine(array3D.Length);
            //This is the number of dimentions, here is 3
            Console.WriteLine(array3D.Rank);
            //This is the length of dimention 1, here is 2
            Console.WriteLine(array3D.GetLength(0));
            //This is the length of dimention 2, here is 2
            Console.WriteLine(array3D.GetLength(1));
            //This is the length of dimention 3, here is 3
            Console.WriteLine(array3D.GetLength(2));
            
            /**
             * We could not use array3D[0].length, because it is not a array
             */

            //foreach will get element one by one
            foreach(var i in array3D)
            {
                Console.Write("{0} ", i);
            }

        }

        public void jaggedArray()
        {
            //how to define
            int[][] array = { new int[] { 1, 2, 3 }, new int[]{2,3,4} };

            //prefer this one
            int[] array1 = { 1, 2, 3 };
            int[] array2 = { 2, 3, 4 };
            int[][] array3 = { array1, array2 };

            //inside a jagged array, there are arrays
            Console.WriteLine(array3[0].Length);
            Console.WriteLine(array3[1].Length);


            //we need a nested foreach to show the element in jagged array
            foreach(var i in array3)
            {
                foreach(var j in i)
                {
                    Console.Write("{0} ", j);
                }
            }
        }
    }

}
