using System;
using System.IO;
using System.Linq;

namespace AOC_02
{
    class Aoc02
    {
        static void Main(string[] args)
        {
            string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string filePath = Path.Combine(projectRoot, "input.txt");

            var lines = File.ReadAllLines(filePath);
            int safeReports = 0;
            int safeReportsDeluxe = 0;

            foreach (var line in lines)
            {
                int[] numbers = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

                if (IsSafe(numbers))
                {
                    safeReports++;
                }

                if (IsSafeDeluxe(numbers))
                {
                    safeReportsDeluxe++;
                }
            }
            Console.WriteLine($"Safe reports: {safeReports} / {safeReportsDeluxe}");
        }

        static bool IsSafe(int[] numbers)
        {
            bool? trend = null;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int diff = numbers[i + 1] - numbers[i];
                if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
                {
                    return false;
                }

                if (trend == null)
                {
                    trend = diff > 0;
                }
                else
                {
                    if ((trend == true && diff < 0) || (trend == false && diff > 0))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static bool IsSafeDeluxe(int[] numbers)
        {
            if (IsSafe(numbers))
            {
                return true;
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                int[] modifiedNumbers = numbers.Where((_, index) => index != i).ToArray();
                if (IsSafe(modifiedNumbers))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
