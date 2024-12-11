using System.Text.RegularExpressions;

namespace AOC_03
{
    class Aoc03
    {
        static void Main(string[] args)
        {
            string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string filePath = Path.Combine(projectRoot, "input.txt");

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"FILE NED DO: {filePath}");
                return;
            }

            string inputData = File.ReadAllText(filePath);

            int totalSumEnabled = CalculateEnabledSumInSequence(inputData);
            Console.WriteLine($"Total Sum Part 3: {totalSumEnabled}");
        }

        static int CalculateEnabledSumInSequence(string input)
        {
            var instructions = new List<(int index, string type, int num1, int num2)>();
            
            Regex mulRegex = new Regex(@"mul\((\d+),(\d+)\)");
            foreach (Match m in mulRegex.Matches(input))
            {
                int num1 = int.Parse(m.Groups[1].Value);
                int num2 = int.Parse(m.Groups[2].Value);
                instructions.Add((m.Index, "mul", num1, num2));
            }
            
            AddSubstrInstructions(input, "do()", "do", instructions);
            AddSubstrInstructions(input, "don't()", "don't", instructions);
            instructions.Sort((a, b) => a.index.CompareTo(b.index));

            bool mulEnabled = true;
            int totalSum = 0;

            foreach (var instr in instructions)
            {
                if (instr.type == "don't")
                {
                    mulEnabled = false;
                }
                else if (instr.type == "do")
                {
                    mulEnabled = true;
                }
                else if (instr.type == "mul")
                {
                    if (mulEnabled)
                    {
                        totalSum += instr.num1 * instr.num2;
                    }
                }
            }
            
            
            
            return totalSum;
        }
        static void AddSubstrInstructions(string input, string substring, string instrType, List<(int index, string type, int num1, int num2)> instructions)
        {
            int startIndex = 0;
            while (true)
            {
                int foundIndex = input.IndexOf(substring, startIndex, StringComparison.Ordinal);
                if (foundIndex == -1)
                    break;

                instructions.Add((foundIndex, instrType, 0, 0));
                startIndex = foundIndex + 1;
            }
        }
    }
}
