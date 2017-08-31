using System;
using System.Collections.Generic;

namespace WoodenPuzzle
{
    public class TenBlocks : BlockCollectionBase
    {
        public TenBlocks(List<Block> blocks)
        {
            if (blocks.Count != 10)
            {
                throw new ArgumentException("A TenBlocks object can only be created with ten blocks");
            }
            foreach (Block block in blocks)
            {
                Add(block);
            }
        }
    }
}
