using System;
using System.Collections.Generic;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> fileContents = AoC21Utils.SplitStringByNewLines(AoC21Utils.ReadFile("./input.txt"));
            List<int> input = AoC21Utils.TransformStringInputToInts(fileContents);
            
            // Part 1
            
            int lastDepth = input[0];
            int increaseCounter = 0;
            foreach (int depthMeasurement in input)
            {
                if (lastDepth < depthMeasurement)
                {
                    ++increaseCounter;
                }
                lastDepth = depthMeasurement;
            }
            Console.WriteLine($"(Part 1): Increased {increaseCounter} times.");
            
            // Part 2

            lastDepth = input[0] + input[1] + input[2];
            increaseCounter = 0;
            for (int i = 1; i < input.Count - 2; i++)
            {
                int sum = input[i] + input[i + 1] + input[i + 2];
                if (sum > lastDepth)
                {
                    increaseCounter++;
                }

                lastDepth = sum;
            }
            Console.WriteLine($"(Part 2): Increased {increaseCounter} times.");
            
        }
    }
}
