using System;
using System.Collections.Generic;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> fileContents = AoC21Utils.SplitStringByNewLines(AoC21Utils.ReadFile("./input.txt"));
            Console.WriteLine("Done reading");
        }
    }
}
