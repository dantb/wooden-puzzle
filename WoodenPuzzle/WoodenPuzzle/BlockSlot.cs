using System;

namespace WoodenPuzzle
{
    public abstract class BlockSlot
    {
        public abstract bool CompatibleWith(BlockSlot other);

        /// <summary>
        /// Force subclasses to override ToString()
        /// </summary>
        public abstract override string ToString();
    }

    public class Joint : BlockSlot
    {
        public override bool CompatibleWith(BlockSlot other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "*";
        }
    }

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
