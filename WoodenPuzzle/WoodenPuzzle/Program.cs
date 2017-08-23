using static System.Console;

namespace WoodenPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine();
            WriteLine();

            BlockFactory blockFactory = new BlockFactory();
            TenBlocks tenBlocks = blockFactory.GetPuzzleWithTenBlocks();

            WriteLine( tenBlocks.ToString() );

            WriteLine();
            WriteLine();
            WriteLine();

            Block original = tenBlocks[0];
            WriteLine(original.ToString());
            Block reversed = new Block(original);
            WriteLine(reversed.ToString());

            ReadKey();
        }
    }
}
