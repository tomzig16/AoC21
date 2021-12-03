using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class AoC21Utils
{
    private static int partCounter = 1;
    public static string ReadFile(string fileName)
    {
        string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        return System.IO.File.ReadAllText(Path.Combine(projectPath, fileName)).Trim();
    }

    public static string ReadInputFile()
    {
        return ReadFile("./input.txt");
    }

    public static List<string> SplitStringByNewLines(string content)
    {
        return content.Split("\n").ToList();
    }

    public static List<string> ReadAndSplitByNewLine(string filename)
    {
        return SplitStringByNewLines(ReadFile(filename));
    }
    
    public static List<string> ReadAndSplitByNewLine()
    {
        return SplitStringByNewLines(ReadInputFile());
    }

    public static List<int> TransformStringInputToInts(List<string> input)
    {
        return input.Select(int.Parse).ToList();
    }

    public static List<ushort> TransformStringInputToUshorts(List<string> input)
    {
        return input.Select(ushort.Parse).ToList();
    }
    
    public static void PrintResult(string result)
    {
        Console.WriteLine($"(Part {partCounter}): {result}");
        partCounter++;
    }
    
    public static void PrintResult(int part, string result)
    {
        Console.WriteLine($"(Part {part}): {result}");
    }
}
