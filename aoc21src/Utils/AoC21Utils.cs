using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class AoC21Utils
{
    public static string ReadFile(string fileName)
    {
        string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        return System.IO.File.ReadAllText(projectPath + fileName).Trim();
    }

    public static List<string> SplitStringByNewLines(string content)
    {
        return content.Split("\n").ToList();
    }
}
