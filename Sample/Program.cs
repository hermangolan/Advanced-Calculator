﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathStaff
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = " ((((( )))))";
            Console.WriteLine(AdvancedCalculator.CountAppearance(text,'('));
            Console.WriteLine(text);
        }
    }
}
