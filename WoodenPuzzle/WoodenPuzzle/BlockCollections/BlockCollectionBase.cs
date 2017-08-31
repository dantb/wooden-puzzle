using System.Collections.Generic;

namespace WoodenPuzzle
{
    public abstract class BlockCollectionBase : List<Block>
    {
        public override string ToString()
        {
            string value = this[0].ToString();

            for (int i = 1; i < this.Count; i++)
            {
                value = string.Concat(value, "\n", this[i]);
            }

            return value;
        }

    }
}
