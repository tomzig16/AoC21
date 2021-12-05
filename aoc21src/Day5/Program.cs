using System;
using System.Collections.Generic;
using System.Linq;

namespace Day5
{
    class Program
    {
        class Point
        {
            public int x;
            public int y;

            public bool isOverlapping = false;
            
            public Point(int _x, int _y)
            {
                x = _x;
                y = _y;
            }
            
            public Point(string _x, string _y)
            {
                x = int.Parse(_x);
                y = int.Parse(_y);
            }
            
            
        }
        
        static void Main(string[] args)
        {
            List<string> inputContent = AoC21Utils.ReadAndSplitByNewLine();

            const string arrow = " -> ";

            List<Point> knownPoints = new List<Point>();

            // Very inefficient solution
            // Probably possible to solve it with simple vector intersection method (for diagonal ones)
            // And some math logic for linear.
            // TODO - try to solve mathematically in the future
            
            foreach (var line in inputContent)
            {
                string[] values = line.Split(arrow);
                string x1 = values[0].Split(',')[0];
                string y1 = values[0].Split(',')[1];
                string x2 = values[1].Split(',')[0];
                string y2 = values[1].Split(',')[1];
                bool isDiagonal = !(x1 == x2 || y1 == y2);
                Point startingPoint = new Point(x1, y1);
                Point endPoint = new Point(x2, y2);

                int stepX = endPoint.x - startingPoint.x == 0 ? 0 :
                    endPoint.x - startingPoint.x > 0 ? 1 : -1;

                int stepY = endPoint.y - startingPoint.y == 0 ? 0 :
                    endPoint.y - startingPoint.y > 0 ? 1 : -1;

                if (isDiagonal)
                {
                    int j = startingPoint.y;
                    for (int i = startingPoint.x; i != endPoint.x + stepX; i += stepX, j += stepY)
                    {
                        Point tPoint = new Point(i, j);
                        var samePoints = knownPoints.Where(p => p.x == tPoint.x && p.y == tPoint.y).ToList();
                        if (samePoints.Count > 0)
                        {
                            // is overlaping
                            samePoints[0].isOverlapping = true;
                        }
                        else
                        {
                            knownPoints.Add(tPoint);
                        }
                    }
                }
                else
                {
                    for (int i = startingPoint.x; i != endPoint.x + stepX; i += stepX)
                    {
                        Point tPoint = new Point(i, startingPoint.y);
                        var samePoints = knownPoints.Where(p => p.x == tPoint.x && p.y == tPoint.y).ToList();
                        if (samePoints.Count > 0)
                        {
                            // is overlaping
                            samePoints[0].isOverlapping = true;
                        }
                        else
                        {
                            knownPoints.Add(tPoint);
                        }
                    }

                    for (int j = startingPoint.y; j != endPoint.y + stepY; j += stepY)
                    {
                        Point tPoint = new Point(startingPoint.x, j);
                        var samePoints = knownPoints.Where(p => p.x == tPoint.x && p.y == tPoint.y).ToList();
                        if (samePoints.Count > 0)
                        {
                            // is overlaping
                            samePoints[0].isOverlapping = true;
                        }
                        else
                        {
                            knownPoints.Add(tPoint);
                        }
                    }
                }
            }

            int overlapCounter = knownPoints.Count(p => p.isOverlapping);
            AoC21Utils.PrintResult($"{overlapCounter}");
        }
    }
}
