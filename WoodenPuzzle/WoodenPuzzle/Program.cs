using Facet.Combinatorics;
using System.Collections.Generic;
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

            WriteLine(tenBlocks.ToString());
            WriteLine();

            // all variations of true and false:
            //    * true  = not reversed block
            //    * false = reversed block
            Variations<bool> flagVariations = CalculateAndPrintFlagVariations();

            // get a collection of all 5 block variations, to form the bottom of our potential solution
            HashSet<List<Block>> listsOfFiveBlocks = CalculateAllFiveBlockVariationsIncludingReversals(tenBlocks, flagVariations);

            ReadKey();
        }

        private static Variations<bool> CalculateAndPrintFlagVariations()
        {
            List<bool> reverseFlags = new List<bool>
            {
                true,
                false
            };

            var flagVariations = new Variations<bool>(reverseFlags, 5, GenerateOption.WithRepetition);
            foreach (var item in flagVariations)
            {
                foreach (var i in item)
                {
                    Write(i + " ");
                }
                WriteLine();
            }

            return flagVariations;
        }

        private static HashSet<List<Block>> CalculateAllFiveBlockVariationsIncludingReversals(TenBlocks tenBlocks, Variations<bool> flagVariations)
        {
            var blockVariations = new Variations<Block>(tenBlocks, 5);
            HashSet<List<Block>> listsOfFiveBlocks = new HashSet<List<Block>>();

            foreach (var variation in blockVariations)
            {
                // now we have an ordered list of 5 blocks. 
                // for each permutation, there 2 ^ 5 = 32 ways to flip the pieces
                foreach (List<bool> flagVariation in flagVariations)
                {
                    List<Block> finalFixedList = new List<Block>();
                    for (int i = 0; i < flagVariation.Count; i++)
                    {
                        // use the flag to choose reversed block or not
                        // TODO: memoization can easily be used here to not keep reversing the blocks
                        finalFixedList.Add(flagVariation[i] ? variation[i] : new Block(variation[i]));
                    }

                    // final list for the bottom is built
                    listsOfFiveBlocks.Add(finalFixedList);
                }
            }

            return listsOfFiveBlocks;
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
