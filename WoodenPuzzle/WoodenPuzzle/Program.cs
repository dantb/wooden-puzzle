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

            List<bool> reverseFlags = new List<bool>
            {
                true, //true, true, true, true,
                false, //false, false, false, false
            };

            // all variations of true and false:
            //     true = not reversed block
            //     false = reversed block
            var allVariations = new Variations<bool>(reverseFlags, 5, GenerateOption.WithRepetition);
            foreach (var item in allVariations)
            {
                foreach (var i in item)
                {
                    Write(i + " ");
                }
                WriteLine();
            }

            WriteLine();
            WriteLine();

            // TODO: what I've written here is literally a variation written from scratch - permutations of combinations.
            // just use the Variations object!
            Combinations<Block> combinations = new Combinations<Block>(tenBlocks, 5);
            foreach (List<Block> combination in combinations)
            {
                // we have a selection of 5 blocks, not ordered. Get permutations since order matters
                List<IEnumerable<Block>> permutations = combination.Permute().ToList();
                foreach (var permutation in permutations)
                {
                    List<Block> permutationList = permutation.ToList();
                    
                    // now we have an ordered list of 5 blocks. 
                    // for each permutation, there 2 ^ 5 = 32 ways to flip the pieces
                    foreach (List<bool> variation in allVariations)
                    {
                        List<Block> finalFixedList = new List<Block>();
                        for (int i = 0; i < variation.Count; i++)
                        {
                            // use the flag to choose reversed block or not
                            // TODO: memoization can easily be used here to not keep reversing the blocks
                            finalFixedList.Add(variation[i] ? permutationList[i] : new Block(permutationList[i]));
                        }

                        // final list for the bottom is built
                        // the next step is to try variations of top pieces
                        WriteBlockList(finalFixedList);

                    }
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
