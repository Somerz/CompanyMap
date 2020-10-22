using System;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml.Schema;

namespace HelloWorld
{
    public class Calculator
    {
        public string DefangIPaddr(string address)
        {
            var temp = "";
            for (int i = 0; i < address.Length; i++)
            {
                if(address[i] == '.')
                {
                    temp += "[.]";
                }

                else
                {
                    temp += address[i];
                }
            }
            return temp;
        }



        public void UserInput()
        {
            do
            {
                Console.Write("\nEnter Number(s) OR type exit to leave: \n");
                var input = Console.ReadLine();

                if (input == "exit")
                {
                    Console.WriteLine("\nK BYE!");
                    Environment.Exit(0);
                }

                var output = "";
                foreach (var strIndex in input)
                {
                    if (strIndex == 43)
                    {
                        output = "+";
                    }
                    if (strIndex == 45)
                    {
                        output = "-";
                    }
                    if (strIndex == 42)
                    {
                        output = "*";
                    }
                    if (strIndex == 47)
                    {
                        output = "/";
                        break;
                    }
                }

                if (output != "+" && output != "-" && output != "*" && output != "/") { output = "noneOfTheAbove"; }

                switch (output)
                {
                    case "+":
                        Console.WriteLine("\n = " + Add(input));
                        break;

                    case "-":
                        Console.WriteLine("\n = " + Sub(input));
                        break;

                    case "*":
                        Console.WriteLine("\n = " + Mult(input));
                        break;

                    case "/":
                        Console.WriteLine("\n = " + Div(input));
                        break;

                    case "noneOfTheAbove":
                        Console.WriteLine("\n = " + input);
                        break;
                }
            } while (true);
        }

        public int Add(string input)
        {
            var addList = new List<int>();
            var number = 0;
            var i = 0;
            foreach (var strIndex in input)
            {
                if (strIndex == 42) //mult
                {
                    var mult = input.Split("+".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    foreach (var index in mult)
                    {
                        if (index.Length > 2)
                        {
                            var callMult = Mult(index);
                            mult[i] = callMult.ToString();
                        }
                        i++;
                    }

                    for (int inc = 0; inc < mult.Length; inc++)
                    {
                        var intInput = Convert.ToInt32(mult[inc]);
                        addList.Add(intInput);
                    }

                    foreach (var num in addList) { number += num; }

                    return number;
                }
            }

            foreach (var strIndex in input)
            {
                if (strIndex == 45) //sub
                {
                    var mult = input.Split("+".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    var help = string.Join(" ", mult);

                    foreach (var index in help)
                    {
                        if (index == '-')
                        {
                            foreach (var addIndex in mult)
                            {
                                if (addIndex.Length > 2)
                                {
                                    var callMult = Sub(addIndex);
                                    mult[i] = callMult.ToString();
                                }
                                i++;
                            }

                        }

                    }

                    for (int inc = 0; inc < mult.Length; inc++)
                    {
                        var intInput = Convert.ToInt32(mult[inc]);
                        addList.Add(intInput);
                    }

                    foreach (var num in addList) { number += num; }

                    return number;
                }
            }

            var eachNum = input.Split("+".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            for(int inc = 0; inc < eachNum.Length; inc++)
            {
                var intInput = Convert.ToInt32(eachNum[inc]);
                addList.Add(intInput);
            }

            foreach (var num in addList) { number += num; }

            return number;
        }

        public int Sub(string input)
        {
            var subList = new List<int>();
            var i = 0;
            var tempNum = 0;

            foreach (var strIndex in input)
            {
                if (strIndex == 43) //add
                {
                    var mult = input.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    var help = string.Join(" ", mult);

                    foreach (var index in help)
                    {
                        if (index == '+')
                        {
                            foreach (var addIndex in mult)
                            {
                                if (addIndex.Length > 2)
                                {
                                    var callMult = Sub(addIndex);
                                    mult[i] = callMult.ToString();
                                }
                                i++;
                            }

                        }

                    }

                    for (int inc = 0; inc < mult.Length; inc++)
                    {
                        var intInput = Convert.ToInt32(mult[inc]);
                        subList.Add(intInput);
                    }

                    tempNum = subList[0];

                    for (int num = 1; num < subList.Count(); num++)
                    {
                        var retVal = tempNum - subList[num];
                        tempNum = retVal;
                    }

                    return tempNum;
                }
            }

            var eachNum = input.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            for (int inc = 0; inc < eachNum.Length; inc++)
            {
                var intInput = Convert.ToInt32(eachNum[inc]);
                subList.Add(intInput);
            }

            var number = subList[0];

            for (int num = 1; num < subList.Count(); num++)
            {
                var retVal = number - subList[num];
                number = retVal;
            }

            return number;
        }

        public int Mult(string input)
        {
            var multList = new List<int>();
            var number = 1;
            var zero = 0;
            var i = 0;
            foreach (var strIndex in input)
            {
                if (strIndex == 43 && input.Length > 4)
                {
                    var mult = input.Split("+".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    foreach (var index in mult)
                    {
                        if(index.Length > 2)
                        {
                            var callMult = Mult(index);
                            mult[i] = callMult.ToString();
                        }
                        i++;
                    }

                    for (int inc = 0; inc < mult.Length; inc++)
                    {
                        var intInput = Convert.ToInt32(mult[inc]);
                        multList.Add(intInput);
                    }

                    foreach (var num in multList) { zero += num; }

                    return zero;
                }

            }

            var eachNum = input.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            for (int inc = 0; inc < eachNum.Length; inc++)
            {
                var intInput = Convert.ToInt32(eachNum[inc]);
                multList.Add(intInput);
            }

            foreach (var num in multList) { number *= num; }

            return number;
        }

        public double Div(string input)
        {
            var divList = new List<double>();
            var eachNum = input.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            double retVal = 0.0;

            for (int inc = 0; inc < eachNum.Length; inc++)
            {
                var intInput = Convert.ToInt32(eachNum[inc]);
                divList.Add(intInput);
            }

            double number = divList[0];

            for(int num = 1; num < divList.Count(); num++)
            {
                retVal = number / divList[num];
                number = retVal;
            }

            return retVal;
        }
    }
}
