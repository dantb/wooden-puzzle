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
}
