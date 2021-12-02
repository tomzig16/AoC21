using System;
using System.Collections.Generic;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> fileInput = AoC21Utils.SplitStringByNewLines(AoC21Utils.ReadFile("./input.txt"));

            // Part 1
            
            const string kForw = "forward";
            const string kDown = "down";
            const string kUp = "up";

            int horizontalPos = 0;
            int depth = 0;
            
            foreach (var line in fileInput)
            {
                int value = int.Parse(line.Split(' ')[1]);
                switch (line.Split(' ')[0])
                {
                    case kForw:
                        horizontalPos += value;
                        break;
                    case kDown:
                        depth += value;
                        break;
                    case kUp:
                        depth -= value;
                        break;
                }
            }

            int result = horizontalPos * depth;
            AoC21Utils.PrintResult(result.ToString());
            
            // Part 2

            int aim = 0;
            horizontalPos = 0;
            depth = 0;
            
            foreach (var line in fileInput)
            {
                int value = int.Parse(line.Split(' ')[1]);
                switch (line.Split(' ')[0])
                {
                    case kForw:
                        horizontalPos += value;
                        depth += (aim * value);
                        break;
                    case kDown:
                        aim += value;
                        break;
                    case kUp:
                        aim -= value;
                        break;
                }
            }
            
            result = horizontalPos * depth;
            AoC21Utils.PrintResult(result.ToString());
        }
    }
}
