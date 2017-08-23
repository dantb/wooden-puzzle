using System;

namespace WoodenPuzzle
{
    public class FlatSpace : BlockSlot
    {
        public override bool CompatibleWith(BlockSlot other)
        {
            return other is FlatSpace;
        }

        public override string ToString()
        {
            return "-";
        }
    }
}
