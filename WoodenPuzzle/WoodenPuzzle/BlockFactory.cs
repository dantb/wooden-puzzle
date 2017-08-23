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

            // creating blocks from real blocks. turning the blocks so that the more "interesting" stuff is on the left, just for ease.
            blocks.Add(
                CreateBlock(
                    1, CreateBlockSlotArray1()));
            blocks.Add(
                CreateBlock(
                    2, CreateBlockSlotArray2()));
            blocks.Add(
                CreateBlock(
                    3, CreateBlockSlotArray3()));
            blocks.Add(
                CreateBlock(
                    4, CreateBlockSlotArray4()));
            blocks.Add(
                CreateBlock(
                    5, CreateBlockSlotArray5()));
            blocks.Add(
                CreateBlock(
                    6, CreateBlockSlotArray6()));
            blocks.Add(
                CreateBlock(
                    7, CreateBlockSlotArray7()));
            blocks.Add(
                CreateBlock(
                    8, CreateBlockSlotArray8()));
            blocks.Add(
                CreateBlock(
                    9, CreateBlockSlotArray9()));
            blocks.Add(
                CreateBlock(
                    10, CreateBlockSlotArray10()));

            TenBlocks tenBlocks = new TenBlocks(blocks);
            return tenBlocks;
        }

        private BlockSlot[] CreateBlockSlotArray1()
        {
            return new BlockSlot[]
            {
                Joint(), FlatSpace(), FlatSpace(), Joint(), FlatSpace()
            };
        }

        private BlockSlot[] CreateBlockSlotArray2()
        {
            return new BlockSlot[]
            {
                Joint(), FlatSpace(), Joint(), FlatSpace(), FlatSpace()
            };
        }

        private BlockSlot[] CreateBlockSlotArray3()
        {
            return new BlockSlot[]
            {
                Joint(), FlatSpace(), Hole(), FlatSpace(), FlatSpace()
            };
        }

        private BlockSlot[] CreateBlockSlotArray4()
        {
            return new BlockSlot[]
            {
                Joint(), Hole(), Joint(), FlatSpace(), FlatSpace()
            };
        }

        private BlockSlot[] CreateBlockSlotArray5()
        {
            return new BlockSlot[]
            {
                Joint(), FlatSpace(), Hole(), FlatSpace(), Hole()
            };
        }

        private BlockSlot[] CreateBlockSlotArray6()
        {
            return new BlockSlot[]
            {
                Hole(), Joint(), Hole(), FlatSpace(), FlatSpace()
            };
        }

        private BlockSlot[] CreateBlockSlotArray7()
        {
            return new BlockSlot[]
            {
                Hole(), Joint(), FlatSpace(), Hole(), FlatSpace()
            };
        }

        private BlockSlot[] CreateBlockSlotArray8()
        {
            return new BlockSlot[]
            {
                Hole(), Joint(), FlatSpace(), Joint(), FlatSpace()
            };
        }

        private BlockSlot[] CreateBlockSlotArray9()
        {
            return new BlockSlot[]
            {
                Hole(), Hole(), FlatSpace(), FlatSpace(), Hole()
            };
        }

        private BlockSlot[] CreateBlockSlotArray10()
        {
            return new BlockSlot[]
            {
                FlatSpace(), Joint(), FlatSpace(), Hole(), FlatSpace()
            };
        }

        private Block CreateBlock(int blockId, params BlockSlot[] slots)
        {
            List<BlockSlot> blockSlots = new List<BlockSlot>();

            foreach (BlockSlot blockSlot in slots)
            {
                blockSlots.Add(blockSlot);
            }

            Block block = new Block(blockSlots, blockId);
            return block;
        }

        private FlatSpace FlatSpace()
        {
            return new FlatSpace();
        }

        private Hole Hole()
        {
            return new Hole();
        }

        private Joint Joint()
        {
            return new Joint();
        }
    }
}
