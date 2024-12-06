using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AOC_03
{
    class Aoc03
    {
        static void Main(string[] args)
        {
            string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string filePath = Path.Combine(projectRoot, "input.txt");

            var lines = File.ReadAllLines(filePath);

            string mulPattern = @"mul\((\d+),(\d+)\)";
            Regex regex = new Regex(mulPattern);

            int[][] mulArray = new int[lines.Length][];
            int totalSum = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                var matches = regex.Matches(lines[i]);
                mulArray[i] = new int[matches.Count * 2]; 

                int k = 0; 
                foreach (Match match in matches)
                {
                    int num1 = int.Parse(match.Groups[1].Value);
                    int num2 = int.Parse(match.Groups[2].Value);

                    mulArray[i][k++] = num1;
                    mulArray[i][k++] = num2;

                    totalSum += num1 * num2;
                }
            }
            Console.WriteLine($"Total Sum: {totalSum}");
        }
    }
}
