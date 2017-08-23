using System;
using System.Collections.Generic;

namespace WoodenPuzzle
{
    public class Block : List<BlockSlot>
    {
        public Block(List<BlockSlot> blockSlots, int blockId)
        {
            if (blockSlots.Count != 5)
            {
                throw new ArgumentException("A Block object can only be created with five BlockSlots");
            }
            foreach (BlockSlot slot in blockSlots)
            {
                Add(slot);
            }
            BlockId = blockId;
        }

        public override string ToString()
        {
            string value = this[0].ToString();

            for (int i = 1; i < this.Count; i++)
            {
                value = string.Concat(value, " ", this[i]);
            }

            return value;
        }

        public int BlockId { get; }
    }
}
