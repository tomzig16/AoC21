using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    class Program
    {
        struct BingoCell
        {
            public bool isMarked;
            public int number;
        }
        class BingoBoard
        {
            private const int width = 5;
            private const int height = 5;

            private BingoCell[,] boardArray = new BingoCell[width, height];
            private int lastInsertedRow = 0;

            private bool IsBingo()
            {
                for (int row = 0; row < height; row++)
                {
                    bool isBingo = true;
                    for (int i = 0; i < width; i++)
                    {
                        if (!boardArray[row, i].isMarked)
                        {
                            isBingo = false;
                            break;
                        }
                    }

                    if (isBingo)
                    {
                        return true;
                    }
                }
                for (int col = 0; col < width; col++)
                {
                    bool isBingo = true;
                    for (int i = 0; i < height; i++)
                    {
                        if (!boardArray[i, col].isMarked)
                        {
                            isBingo = false;
                            break;
                        }
                    }

                    if (isBingo)
                    {
                        return true;
                    }  
                }

                return false;
            }
            
            public bool MarkNumberAndCheckIfBingo(int number)
            {
                for (int row = 0; row < height; row++)
                {
                    for (int col = 0; col < width; col++)
                    {
                        if (boardArray[row, col].number == number && !boardArray[row, col].isMarked)
                        {
                            boardArray[row, col].isMarked = true;
                        }
                    }
                }

                return IsBingo();
            }

            public void AddBingoRow(string row)
            {
                string[] cellInfo = row.Split(' ');
                int cellCounter = 0;
                foreach (var info in cellInfo)
                {
                    if(info == "") continue;
                    BingoCell bc = new BingoCell();
                    bc.number = int.Parse(info);
                    bc.isMarked = false;
                    boardArray[lastInsertedRow, cellCounter] = bc;
                    cellCounter++;
                }

                lastInsertedRow++;
            }

            public List<int> GetUnmarkedNumbers()
            {
                List<int> result = new List<int>();
                foreach (var cell in boardArray)
                {
                    if(!cell.isMarked) result.Add(cell.number);
                }

                return result;
            }

            public void UnmarkAllNumbers()
            {
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        boardArray[i, j].isMarked = false;
                    }
                }
            }
        }
        
        static void Main(string[] args)
        {
            List<string> inputLines = AoC21Utils.ReadAndSplitByNewLine();

            List<string> bingoNumberLines = inputLines[0].Split(',').ToList();
            List<BingoBoard> knownBoards = new List<BingoBoard>();

            for (int i = 1; i < inputLines.Count; i+=6)
            {
                var bingoBoard = new BingoBoard();
                for (int j = 1; j <= 5; j++)
                {
                    bingoBoard.AddBingoRow(inputLines[i+j]);
                }
                knownBoards.Add(bingoBoard);
            }

            BingoBoard winningBoard = new BingoBoard();
            int winningNumber = 0;
            bool isWinningFound = false;
            foreach (string number in bingoNumberLines)
            {
                int num = int.Parse(number);
                foreach (var board in knownBoards)
                {
                    if (board.MarkNumberAndCheckIfBingo(num))
                    {
                        winningBoard = board;
                        winningNumber = num;
                        isWinningFound = true;
                        break;
                    }
                }

                if (isWinningFound)
                {
                    break;
                }
            }

            int sum = 0;
            foreach (var num in winningBoard.GetUnmarkedNumbers())
            {
                sum += num;
            }
            AoC21Utils.PrintResult($"{sum * winningNumber}");

            
            foreach (var board in knownBoards)
            {
                board.UnmarkAllNumbers();
            }
            
            // Part 2

            winningNumber = 0;
            Dictionary<BingoBoard, int> usedBingoBoards = new Dictionary<BingoBoard, int>();
            // Winning bingo board and winning number pair
            // Better solution would probably be to simply remove used boards from the original list, but CBA rearranging
            // list.
            foreach (var number in bingoNumberLines)
            {
                int num = int.Parse(number);
                foreach (var board in knownBoards)
                {
                    if(usedBingoBoards.ContainsKey(board)) continue;
                    if (board.MarkNumberAndCheckIfBingo(num))
                    {
                        usedBingoBoards[board] = num;
                        winningBoard = board;
                    }
                }

                if (usedBingoBoards.Count == knownBoards.Count) break;
            }

            winningNumber = usedBingoBoards[winningBoard];
            
            double bigsum = 0;
            foreach (var num in winningBoard.GetUnmarkedNumbers())
            {
                bigsum += num;
            }
            AoC21Utils.PrintResult($"{bigsum * (double)winningNumber}");
            
        }
        
        
    }
}