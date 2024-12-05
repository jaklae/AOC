using System;
using System.Text.RegularExpressions;

namespace AOC_01
{
    class Aoc01
    {
        static void Main(string[] args)
        {

            // Part 1
            
            List<string> listLeft = new List<string>();
            List<string> listRight = new List<string>();

            string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string filePath = Path.Combine(projectRoot, "input.txt");

            
            Regex sWhitespace = new Regex(@"\s+");
            
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    string[] parts = sWhitespace.Split(line.Trim());
                    listLeft.Add(parts[0]);
                    listRight.Add(parts[1]);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Reading Lines" + ex.Message);
            }
            
            listLeft.Sort();
            listRight.Sort();
            
            int total = 0;
            
            for (int i = 0; i < listLeft.Count; i++)
            {
                int step = (int.Parse(listLeft[i]) - int.Parse(listRight[i]));
                if (step < 0)
                {
                    step = step * -1;
                    total += step;
                }
                else
                {
                    total += step;
                }
            }
            Console.WriteLine("Total Difference- > " + total);
            
            // Part 2
            
            int sum = 0;
            
            for (int i = 0; i < listLeft.Count; i++)
            {
                foreach (string t in listRight)
                {
                    int ammount = 0;
                    if (int.Parse(t) == int.Parse(listLeft[i]))
                    {
                        ammount++;
                    }
                    sum += ammount*int.Parse(listLeft[i]);
                }
            }
            
            Console.WriteLine("Total Difference Sum Count- > " + sum);
            
        }
    }
}