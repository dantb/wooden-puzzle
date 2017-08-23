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

            ReadKey();
        }
    }
}
