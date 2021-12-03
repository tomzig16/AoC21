using System;
using System.Collections.Generic;
using System.Linq;

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

            var binaryNotOfFinalNumber = FlipBinaryNumber(finalNumber, oneBitLength);

            AoC21Utils.PrintResult( (((int)finalNumber) * (int)(binaryNotOfFinalNumber)).ToString() );

            
            // Part 2
            // They are reading from left to right

            List<ushort> inputAsRealNumbers = new List<ushort>();
            input.ForEach(x =>
            {
                inputAsRealNumbers.Add(Convert.ToUInt16(x, 2));
            });

            ushort oxygenRating = ReduceListToSingleValue(oneBitLength, inputAsRealNumbers, true);
            
            inputAsRealNumbers.Clear();
            input.ForEach(x =>
            {
                inputAsRealNumbers.Add(Convert.ToUInt16(x, 2));
            });

            ushort co2Rating = ReduceListToSingleValue(oneBitLength, inputAsRealNumbers, false);
            
            AoC21Utils.PrintResult($"{oxygenRating*co2Rating}");
        }

        static ushort FlipBinaryNumber(int number, int oneBitLength)
        {
            ushort binaryNotOfFinalNumber = (ushort) ~number;
            // short is 16 bit, while our input is larger - need to remove certain amount of bits from the left side
            ushort toSubstract = 0;
            for (int i = (sizeof(ushort)*8)-1; i >= oneBitLength; i--)
            {
                toSubstract += (ushort)(1 << i);
            }

            binaryNotOfFinalNumber -= toSubstract;
            return binaryNotOfFinalNumber;
        }

        static ushort ReduceListToSingleValue(int oneBitLength, List<ushort> inputAsRealNumbers, bool sortByOne)
        {
            for (int i = 0; i < oneBitLength; i++)
            {
                int middleValue = 1 << (oneBitLength - (i + 1));
                int counter = inputAsRealNumbers.Count(x => (x & middleValue) >= 1 ); // count how many have "1" in that index
                if (counter >= (double)inputAsRealNumbers.Count / (double)2.0)
                {
                    inputAsRealNumbers = inputAsRealNumbers.Where(x =>
                    {
                        if (sortByOne)
                            return (x & middleValue) >= 1;
                        else
                            return (x & middleValue) < 1;
                    }).ToList();    
                }
                else
                {
                    inputAsRealNumbers = inputAsRealNumbers.Where(x =>
                    {
                        if (sortByOne)
                            return (x & middleValue) < 1;
                        else
                            return (x & middleValue) >= 1;
                    }).ToList();
                }

                if (inputAsRealNumbers.Count == 1)
                {
                    break;
                }
            }

            return inputAsRealNumbers[0];
        }
        
    }
}