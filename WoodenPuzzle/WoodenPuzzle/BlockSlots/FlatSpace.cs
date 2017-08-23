using System;

namespace WoodenPuzzle
{
    public class FlatSpace : BlockSlot
    {
        public override bool CompatibleWith(BlockSlot other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "-";
        }
    }
}
