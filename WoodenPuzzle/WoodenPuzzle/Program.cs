using System.Collections.Generic;
using static System.Console;

namespace WoodenPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Press any key to calculate the puzzle solution: ");
            ReadKey();

            PuzzleSolver solver = new PuzzleSolver();
            solver.SolveTenBlockPuzzle(out FiveBlocks bottomLayerOfSolution, out FiveBlocks topLayerOfSolution);

            WriteSolutionToConsole(bottomLayerOfSolution, topLayerOfSolution);

            ReadKey();
        }

        private static void WriteSolutionToConsole(FiveBlocks bottomLayerOfSolution, FiveBlocks topLayerOfSolution)
        {
            WriteLine();
            WriteLine("The two layers are as follows, where each row is a block and one layer lies perpendicular on top of the other: ");
            WriteLine();
            WriteBlockList(bottomLayerOfSolution);
            WriteLine();
            WriteBlockList(topLayerOfSolution);
            WriteLine();
        }

        private static void WriteBlockList(IEnumerable<Block> permutation)
        {
            foreach (Block block in permutation)
            {
                WriteLine(block);
            }
            WriteLine();
        }
    }
}
