using System;
using System.Collections.Generic;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = AoC21Utils.ReadAndSplitByNewLine();

            int nOfInputs = input.Count;
            int oneBitLength = input[0].Length;

            int finalNumber = 0;
            
            // Part 1
            
            for (int i = oneBitLength - 1; i >= 0; i--)
            {
                // First iterate through lines with same index backwards
                int counter = 0;
                int bitIndex =
                    oneBitLength - (i + 1); // Index of a bit in the number (because we iterate from the last bit)

                for (int lineI = 0; lineI < nOfInputs; lineI++)
                {
                    if (input[lineI][i] == '1')
                    {
                        counter++;
                    }

                    if (counter > nOfInputs / 2)
                    {
                        finalNumber += 1 << bitIndex;
                        break; // we care for majority
                    }

                }
                
            }

            ushort binaryNotOfFinalNumber = (ushort) ~finalNumber;
            // short is 16 bit, while our input is larger - need to remove certain amount of bits from the left side
            ushort toSubstract = 0;
            for (int i = (sizeof(ushort)*8)-1; i >= oneBitLength; i--)
            {
                toSubstract += (ushort)(1 << i);
            }

            binaryNotOfFinalNumber -= toSubstract;

            AoC21Utils.PrintResult( (((int)finalNumber) * (int)(binaryNotOfFinalNumber)).ToString() );

            
            // Part 2
            // They are reading from left to right...
            
            

            // Dictionary solution is boring...
            // Dictionary<int, int> bitQuantityDict = new Dictionary<int, int>();
            // // create dictionary
            // for (int i = 0; i < input[0].Length; i++)
            // {
            //     bitQuantityDict[i] = 0;
            // }
            //
            // foreach (var line in input)
            // {
            //     for (int i = 0; i < line.Length; i++)
            //     {
            //         if (line[i] == '1')
            //         {
            //             bitQuantityDict[i]++;
            //         }
            //     }
            // }

        }
        
        
        
        
    }
}