using System;
using System.Collections.Generic;

namespace WoodenPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {





            Console.ReadKey();

        }
    }

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
    }

    public class Block : List<BlockSlot>
    {
        public Block(List<BlockSlot> blockSlots)
        {
            if (blockSlots.Count != 5)
            {
                throw new ArgumentException("A Block object can only be created with five BlockSlots");
            }
            foreach (BlockSlot slot in blockSlots)
            {
                Add(slot);
            }
        }
    }

    public abstract class BlockSlot
    {
        public abstract bool CompatibleWith(BlockSlot other);
    }

    public class Joint : BlockSlot
    {
        public override bool CompatibleWith(BlockSlot other)
        {
            throw new NotImplementedException();
        }
    }

    public class Hole : BlockSlot
    {
        public override bool CompatibleWith(BlockSlot other)
        {
            throw new NotImplementedException();
        }
    }

    public class FlatSpace : BlockSlot
    {
        public override bool CompatibleWith(BlockSlot other)
        {
            throw new NotImplementedException();
        }
    }
}
