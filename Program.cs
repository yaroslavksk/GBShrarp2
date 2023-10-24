using System;
using static GBShrarp2.IbitsT;

namespace GBShrarp2
{
    class Program
    {

        static void Main()
        {
            long a = 123123123;
            int b = 0;
            byte c = 1;
            Bits bits = c;
            Console.WriteLine(bits.ToString());
        }
    }
}