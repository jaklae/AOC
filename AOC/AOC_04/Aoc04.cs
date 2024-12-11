namespace AOC_04
{
    class Aoc04
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
            int rows = lines.Length;
            int cols = lines[0].Length; 

            char[,] matrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string line = lines[i];
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = line[j];
                }
            }
            /*
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[0, j] + " ");
                
            }
            */
            
            int count = XMAScount(matrix, rows, cols);
            Console.WriteLine($"XMAS horizontal and vertical: {count}");
            
            count = XMAScountDiagonal(matrix, rows, cols);
            Console.WriteLine($"XMAS horizontal and vertical and diagonal: {count}");

        }
        
        static int XMAScount(char[,] matrix, int rows, int cols)
        {
            int count = 0;
            int length = 4;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j <= cols - length; j++)
                {
                    if (matrix[i, j] == 'X' &&
                        matrix[i, j + 1] == 'M' &&
                        matrix[i, j + 2] == 'A' &&
                        matrix[i, j + 3] == 'S')
                    {
                        count++;
                    }
                }
            }

            for (int j = 0; j < cols; j++)
            {
                for (int i = 0; i <= rows - length; i++)
                {
                    if (matrix[i, j] == 'X' &&
                        matrix[i + 1, j] == 'M' &&
                        matrix[i + 2, j] == 'A' &&
                        matrix[i + 3, j] == 'S')
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        static int XMAScountDiagonal(char[,] matrix, int rows, int cols)
        {
            int count = 0;
            string target = "XMAS";
            int length = 4;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    // Horizontal (left to right)
                    if (c <= cols - length &&
                        matrix[r,c]=='X' && matrix[r,c+1]=='M' && matrix[r,c+2]=='A' && matrix[r,c+3]=='S')
                    {
                        count++;
                    }

                    // Horizontal (right to left)
                    if (c >= length - 1 &&
                        matrix[r,c]=='X' && matrix[r,c-1]=='M' && matrix[r,c-2]=='A' && matrix[r,c-3]=='S')
                    {
                        count++;
                    }

                    // Vertical (top to bottom)
                    if (r <= rows - length &&
                        matrix[r,c]=='X' && matrix[r+1,c]=='M' && matrix[r+2,c]=='A' && matrix[r+3,c]=='S')
                    {
                        count++;
                    }

                    // Vertical (bottom to top)
                    if (r >= length - 1 &&
                        matrix[r,c]=='X' && matrix[r-1,c]=='M' && matrix[r-2,c]=='A' && matrix[r-3,c]=='S')
                    {
                        count++;
                    }

                    // Diagonal \ (top-left to bottom-right)
                    if (r <= rows - length && c <= cols - length &&
                        matrix[r,c]=='X' && matrix[r+1,c+1]=='M' && matrix[r+2,c+2]=='A' && matrix[r+3,c+3]=='S')
                    {
                        count++;
                    }

                    // Diagonal / (top-right to bottom-left)
                    if (r <= rows - length && c >= length - 1 &&
                        matrix[r,c]=='X' && matrix[r+1,c-1]=='M' && matrix[r+2,c-2]=='A' && matrix[r+3,c-3]=='S')
                    {
                        count++;
                    }

                    // Diagonal upward \ (bottom-left to top-right)
                    if (r >= length - 1 && c <= cols - length &&
                        matrix[r,c]=='X' && matrix[r-1,c+1]=='M' && matrix[r-2,c+2]=='A' && matrix[r-3,c+3]=='S')
                    {
                        count++;
                    }

                    // Diagonal upward / (bottom-right to top-left)
                    if (r >= length - 1 && c >= length - 1 &&
                        matrix[r,c]=='X' && matrix[r-1,c-1]=='M' && matrix[r-2,c-2]=='A' && matrix[r-3,c-3]=='S')
                    {
                        count++;
                    }
                }
            }

            return count;
        }

    }
}
