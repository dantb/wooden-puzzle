using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodenPuzzle
{
    public class BlockFactory
    {
        public TenBlocks GetPuzzleWithTenBlocks()
        {
            List<Block> blocks = new List<Block>();

            


            TenBlocks tenBlocks = new TenBlocks(blocks);
            return tenBlocks;
        }

        private Block CreateBlock(params BlockSlot[] slots)
        {
            List<BlockSlot> blockSlots = new List<BlockSlot>();

            foreach (BlockSlot blockSlot in slots)
            {
                blockSlots.Add(blockSlot);
            }

            Block block = new Block(blockSlots);
            return block;
        }
    }
}
