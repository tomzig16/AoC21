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
        return System.IO.File.ReadAllText(projectPath + fileName).Trim();
    }

    public static List<string> SplitStringByNewLines(string content)
    {
        return content.Split("\n").ToList();
    }

    public static List<int> TransformStringInputToInts(List<string> input)
    {
        return input.Select(int.Parse).ToList();
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
