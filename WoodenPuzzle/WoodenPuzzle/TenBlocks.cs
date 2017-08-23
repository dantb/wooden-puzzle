using System;
using System.Collections.Generic;

namespace WoodenPuzzle
{
    public class TenBlocks : List<Block>
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

        public override string ToString()
        {
            string value = this[0].ToString();

            for (int i = 1; i < this.Count; i++)
            {
                value = string.Concat(value, "\n", this[i]);
            }

            return value;
        }
    }
}
