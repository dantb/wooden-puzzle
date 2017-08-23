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

    public class Block
    {
        public Block(List<BlockSlot> blockSlots)
        {
            BlockSlots = blockSlots;
        }

        public List<BlockSlot> BlockSlots { get;  }
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
