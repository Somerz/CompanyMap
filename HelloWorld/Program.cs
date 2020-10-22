using System;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //var calculate = new Calculator();
            //calculate.UserInput();

            var companies = new Companies();
            companies.pseudoMain();
        }
    }
}
