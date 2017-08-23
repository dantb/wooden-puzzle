using System;

namespace WoodenPuzzle
{
    public class Hole : BlockSlot
    {
        public override bool CompatibleWith(BlockSlot other)
        {
            return other is Joint;
        }

        public override string ToString()
        {
            return "o";
        }
    }
}
