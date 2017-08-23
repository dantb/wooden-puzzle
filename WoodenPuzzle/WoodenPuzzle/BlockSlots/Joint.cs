using System;

namespace WoodenPuzzle
{
    public class Joint : BlockSlot
    {
        public override bool CompatibleWith(BlockSlot other)
        {
            return other is Hole;
        }

        public override string ToString()
        {
            return "*";
        }
    }
}
