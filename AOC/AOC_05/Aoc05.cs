namespace AOC_05
{
    class Aoc05
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

            var lines = File.ReadAllLines(filePath);
        }
    }
}
