using System;

namespace WoodenPuzzle
{
    public class Hole : BlockSlot
    {
        public override bool CompatibleWith(BlockSlot other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "o";
        }
    }
}
