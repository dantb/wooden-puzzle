using Facet.Combinatorics;
using System.Collections.Generic;
using System.Linq;

namespace WoodenPuzzle
{
    public class PuzzleSolver
    {
        public void SolveTenBlockPuzzle(out FiveBlocks bottomLayerOfSolution, out FiveBlocks topLayerOfSolution)
        {
            // get the blocks needed for the 10 piece wooden puzzle
            BlockFactory blockFactory = new BlockFactory();
            TenBlocks tenBlocks = blockFactory.GetPuzzleWithTenBlocks();

            // all variations of true and false:
            //  - true  = not reversed block
            //  - false = reversed block
            Variations<bool> flagVariations = CalculateAndPrintFlagVariations();

            // get a collection of all 5 block variations, to form the bottom of our potential solution
            HashSet<FiveBlocks> listsOfFiveBlocks = CalculateAllFiveBlockVariationsIncludingReversals(tenBlocks, flagVariations);

            CalculateLayerOfSolution(out bottomLayerOfSolution, out topLayerOfSolution, tenBlocks, listsOfFiveBlocks);
        }

        private void CalculateLayerOfSolution(out FiveBlocks bottomLayerOfSolution, out FiveBlocks topLayerOfSolution, TenBlocks tenBlocks, HashSet<FiveBlocks> listsOfFiveBlocks)
        {
            bottomLayerOfSolution = null;
            topLayerOfSolution = null;
            foreach (var bottomFiveBlocks in listsOfFiveBlocks)
            {
                // now get the remaining five blocks
                FiveBlocks topFiveBlocks = new FiveBlocks(tenBlocks.Where(b => !bottomFiveBlocks.Contains(b)).ToList());

                Dictionary<Block, int> blockToIndexMaping = GetTopLayerBlockMappingToBottomLayerIndex(bottomFiveBlocks, topFiveBlocks);

                if (blockToIndexMaping.Count == 5)
                {
                    // this means we've matched all 5! we're done!
                    // print the two layers

                    bottomLayerOfSolution = bottomFiveBlocks;
                    topLayerOfSolution = new FiveBlocks(blockToIndexMaping.Keys.ToList());
                    break;
                }
            }
        }

        private Dictionary<Block, int> GetTopLayerBlockMappingToBottomLayerIndex(FiveBlocks bottomFiveBlocks, FiveBlocks topFiveBlocks)
        {
            Dictionary<Block, int> blockToIndexMaping = new Dictionary<Block, int>();

            // try each block in every variation across the botton five
            foreach (var topBlock in topFiveBlocks)
            {
                bool topBlockFits = false;
                int topBlockIndex = -1;
                bool topBlockReversedFits = false;
                int topBlockReversedIndex = -1;

                for (int i = 0; i < topBlock.Count; i++)
                {
                    // see if this block is compatible at the given index of the bottom 5
                    if (bottomFiveBlocks.BlockIsCompatibleAtIndex(topBlock, i))
                    {
                        topBlockFits = true;
                        topBlockIndex = i;
                    }
                    else if (bottomFiveBlocks.BlockIsCompatibleAtIndex(new Block(topBlock), i))
                    {
                        topBlockReversedFits = true;
                        topBlockReversedIndex = i;
                    }
                }

                if (!topBlockFits && !topBlockReversedFits)
                {
                    // this block hasn't fit anywhere on the bottom five, meaning the bottom five is incorrect
                    break;
                }
                else
                {
                    // we found a way it fits
                    if (topBlockFits)
                    {
                        // non reversed block fits at some index
                        blockToIndexMaping.Add(topBlock, topBlockIndex);
                    }
                    else if (topBlockReversedFits)
                    {
                        // reversed block fits at some index
                        blockToIndexMaping.Add(new Block(topBlock), topBlockReversedIndex);
                    }
                }
            }

            return blockToIndexMaping;
        }

        private Variations<bool> CalculateAndPrintFlagVariations()
        {
            List<bool> reverseFlags = new List<bool>
            {
                true,
                false
            };

            return new Variations<bool>(reverseFlags, 5, GenerateOption.WithRepetition);
        }

        private HashSet<FiveBlocks> CalculateAllFiveBlockVariationsIncludingReversals(TenBlocks tenBlocks, Variations<bool> flagVariations)
        {
            var blockVariations = new Variations<Block>(tenBlocks, 5);
            HashSet<FiveBlocks> listsOfFiveBlocks = new HashSet<FiveBlocks>();

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
                    listsOfFiveBlocks.Add(new FiveBlocks(finalFixedList));
                }
            }

            return listsOfFiveBlocks;
        }
    }
}
