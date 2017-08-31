using System;
using System.Collections.Generic;

namespace WoodenPuzzle
{
    public class FiveBlocks : BlockCollectionBase
    {
        public FiveBlocks(List<Block> blocks)
        {
            if (blocks.Count != 5)
            {
                throw new ArgumentException("A FiveBlocks object can only be created with five blocks");
            }
            foreach (Block block in blocks)
            {
                Add(block);
            }
        }

        public bool BlockIsCompatibleAtIndex(Block topBlock, int bottomIndex)
        {
            int topBlockIndex = 0;
            foreach (var block in this)
            {
                if (!block[bottomIndex].CompatibleWith(topBlock[topBlockIndex]))
                {
                    return false;
                }
                topBlockIndex++;
            }
            return true;
        }
    }
}
