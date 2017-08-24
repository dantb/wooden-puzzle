using Facet.Combinatorics;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace WoodenPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine();
            WriteLine();

            BlockFactory blockFactory = new BlockFactory();
            TenBlocks tenBlocks = blockFactory.GetPuzzleWithTenBlocks();

            WriteLine( tenBlocks.ToString() );

            WriteLine();

            Combinations<Block> combinations = new Combinations<Block>(tenBlocks, 5);
            foreach (List<Block> combination in combinations)
            {
                // we have a selection of 5 blocks, not ordered. Get permutations since order matters
                List<IEnumerable<Block>> permutations = combination.Permute().ToList();
                foreach (var permutation in permutations)
                {
                    // for each permutation, there 2 ^ 5 = 32 ways to flip the pieces
                    WriteBlockList(permutation);
                }

            }
            
            WriteLine();
            WriteLine();

            Block original = tenBlocks[0];
            WriteLine(original.ToString());
            Block reversed = new Block(original);
            WriteLine(reversed.ToString());

            ReadKey();
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
