using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass2
{
    class Calculate
    {
        //This stack stores numbers
        private Stack<double> numStack = new Stack<double>();
        //This stack stores operations
        private Stack<String> opStack = new Stack<string>();
        //This is list store all arguments needed in this program
        private List<String> args = new List<string>();

        private const int TWO = 2;


        /*
         * This method is to calculate and print out the result
         * The parameter arg is the expression the program need to calculate
         * It returns the result
         */
        public string Calc(String arg)
        {
            //clear all stack and list
            numStack.Clear();
            opStack.Clear();
            args.Clear();

            //parse the expression and store information into list
            bool result = Parse(arg);
            if (result == false)
            {
                return "Invalid Input";
            }


            //move inforamtion from list to numStack and opStack
            result = InitStack();
            if(result == false)
            {
                return "∞";
            }

            //calculate expression and get result
            result = GetResult();
            if (result == false)
            {
                return "∞";
            }

            //Check whether the result is valid; If so, print it
            if (numStack.Count == 1)
            {
                return numStack.Pop() + "";
            }
            else
            {
                return "Some errors I don't know";
            }
        }


        /*
         * This method is to calculate and get the result
         * It returns whether it resturns successful
         */
        private bool GetResult()
        {
            while(opStack.Count != 0)
            {
                bool isDivByZero = CalcOnlyTwoNumberWithOp();
                if (isDivByZero == false)
                {
                    return false;
                }
            }
            return true;
        }


        /*
         * This method is to initialize stacks. move inforamtion from list to numStack and opStack
         * It returns whether it executes successful
         */
        private bool InitStack()
        {
            for (int i = 0; i < args.Count; i++)
            {
                if (i % TWO == 0)  //deal with numbers
                {
                    InitNumStack(i);
                }
                else if (i % TWO == 1)  //deal with operations
                {
                    bool result = InitOpStack(ref i);
                    if(result == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /*
         * This method is to initialize operation stack
         * The parameter index gives the index in args
         * It returns whether it executes successful
         */
        private bool InitOpStack(ref int index)
        {
            String operation = args[index];
            bool isValid = true;
            switch (operation)
            {
                case "+":
                case "-":
                    isValid = DealWithAddOrMinus(ref index);
                    break;
                case "*":
                case "/":
                case "%":
                    isValid = DealWithMulOrDivOrMod(ref index);
                    break;
                case "^":
                    isValid = DealWithPower(ref index);
                    break;
            }
            return isValid;
        }

        /*
         * This method deal with add operation or minus operation 
         * The parameter index gives the index in args
         * It returns whether it executes successful
         */
        private bool DealWithAddOrMinus(ref int index)
        {
            //calculate previous expression
            while (opStack.Count != 0)
            {
                bool isDivByZero = CalcOnlyTwoNumberWithOp();
                if(isDivByZero == false)
                {
                    return false;
                }
                
            }

            //store operation into stack
            opStack.Push(args[index]);

            return true;
        }
        /*
         * This method deal with multiplication operation or division operation or Mod operation
         * The parameter index gives the index in args
         * It returns whether it executes successful
         */
        private bool DealWithMulOrDivOrMod(ref int index)
        {
            //calculate previous multiplication operation or division operation or Mod operation
            while (opStack.Count != 0 && (opStack.Peek() == "*" || opStack.Peek() == "/" || opStack.Peek() == "%"))
            {
                bool isDivByZero = CalcOnlyTwoNumberWithOp();
                if (isDivByZero == false)
                {
                    return false;
                }

            }

            //store operation into stack
            opStack.Push(args[index]);

            return true;
        }

        /*
         * This method deal with power operation
         * The parameter index gives the index in args
         * It returns whether it executes successful
         */
        private bool DealWithPower(ref int index)
        {
            //get value
            double value = numStack.Pop();

            //get power
            index++;
            double power = Double.Parse(args[index]);

            //get result
            double result = Math.Pow(value, power);
            numStack.Push(result);
            return true;
        }

        /*
         * This method calcualtes only two numbers, such as 1*1 or 2^3
         * It returns whether it executes successful
         */
        private bool CalcOnlyTwoNumberWithOp()
        {
            //get numbers and operation
            double num1 = numStack.Pop();
            double num2 = numStack.Pop();
            String preOperation = opStack.Pop();
            double result = 0.0;

            //calculate 2 numbers
            switch (preOperation)
            {
                case "+":
                    result = num2 + num1;
                    break;
                case "-":
                    result = num2 - num1;
                    break;
                case "*":
                    result = num2 * num1;
                    break;
                case "/":
                    if (num1 == 0)
                    {
                        return false;
                    }
                    else
                    {
                        result = num2 / num1;
                    }
                    break;
                case "%":
                    if (num1 == 0)
                    {
                        return false;
                    }
                    else
                    {
                        result = num2 % num1;
                    }
                    break;
            }

            //store the result
            numStack.Push(result);
            return true;
        }
        
        
        
        /*
         * This method is to initialize numStack 
         * The parameter index gives the index in args
         */
        private void InitNumStack(int index)
        {
            double num = Double.Parse(args.ElementAt(index));
            numStack.Push(num);
        }


        /*
         * This method is to parse the expression 
         * The parameter arg is the expression which need to be calculated
         * It returns whether the expression is parsed successfully
         */
        private bool Parse(String arg)
        {
            bool isNumber = true;
            bool isSuccess = true;
            for (int i = 0; i < arg.Length; i++)
            {
                //parse the number
                if (isNumber == true)
                {
                    isSuccess = ParseNumber(arg, ref i);
                    isNumber = false;
                }
                //parse the operation
                else
                {
                    isSuccess = ParseOper(arg, ref i);
                    isNumber = true;
                }

                if (isSuccess == false)
                {
                    return false;
                }
            }

            return !isNumber;
        }

        /*
         * This method is to parse  operations
         * The parameter arg is the expession which needs to be calculated 
         * The parameter index gives the index in arg
         * It returns whether the expression is parsed successfully
         */
        private bool ParseOper(String arg, ref int index)
        {
            if (CheckIsOperation(arg, index))
            {
                String temp = arg.ElementAt(index).ToString();
                args.Add(temp);
            }
            else
            {
                return false;
            }
            return true;
        }


        /*
         * This method is to parse  numbers
         * The parameter arg is the expession which needs to be calculated 
         * The parameter index gives the index in arg
         * It returns whether the expression is parsed successfully
         */
        private bool ParseNumber(String arg, ref int index)
        {
            //deal with the number with sign, such as +1 or -3
            if (CheckIsSign(arg, index))
            {
                //get sign
                String temp = arg.ElementAt(index).ToString();
                index++;

                //check whether it is out of range
                if (index == arg.Length)
                {
                    return false;
                }
                else
                {
                    //get pure number
                    if (CheckIsNumber(arg, index))
                    {
                        GetPureNumber(arg, ref index, ref temp);
                        args.Add(temp);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            //deal with the number without sign, such as 1 or 3
            else if (CheckIsNumber(arg, index))
            {
                String temp = "";
                GetPureNumber(arg, ref index, ref temp);
                args.Add(temp);
            }
            else
            {
                return false;
            }
            return true;
        }


        /*
         * This method is to check whether it is a operation
         * The parameter arg is the expession which needs to be calculated 
         * The parameter index gives the index in arg
         * It returns whether it is a operation
         */
        private bool CheckIsOperation(String arg, int index)
        {
            if (arg.ElementAt(index) == '+' || arg.ElementAt(index) == '-')
            {
                return true;
            }
            else if (arg.ElementAt(index) == '*' || arg.ElementAt(index) == '/' || arg.ElementAt(index) == '%')
            {
                return true;
            }else if(arg.ElementAt(index) == '^')
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /*
         * This method is to check whether it is a sign
         * The parameter arg is the expession which needs to be calculated 
         * The parameter index gives the index in arg
         * It returns whether it is a sign
         */
        private bool CheckIsSign(String arg, int index)
        {
            if (arg.ElementAt(index) == '+' || arg.ElementAt(index) == '-')
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /*
         * This method is to check whether it is a number
         * The parameter arg is the expession which needs to be calculated 
         * The parameter index gives the index in arg
         * It returns whether it is a number
         */
        private bool CheckIsNumber(String arg, int index)
        {
            if (arg.ElementAt(index) >= '0' && arg.ElementAt(index) <= '9')
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /*
         * This method is to get pure number
         * The parameter arg is the expession which needs to be calculated 
         * The parameter index gives the index in arg
         * The parameter num store number after executing this method
         */
        private void GetPureNumber(String arg, ref int index, ref String number)
        {
            int numOfDot = 0;
            while (index < arg.Length && CheckIsNumberOrDot(arg, index, ref numOfDot))
            {
                number = number + arg.ElementAt(index).ToString();
                index++;
            }
            index--;
        }

        /*
         * This method is to check whether it is a number or a dot
         * The parameter arg is the expession which needs to be calculated 
         * The parameter index gives the index in arg
         * It returns whether it is a number or a dot
         */
        private bool CheckIsNumberOrDot(String arg, int index, ref int numOfDot)
        {
            if (arg.ElementAt(index) >= '0' && arg.ElementAt(index) <= '9')
            {
                return true;
            }
            else if (arg.ElementAt(index) == '.')
            {
                numOfDot++;
                if (numOfDot > 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
