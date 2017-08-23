using System;

namespace WoodenPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine();

            BlockFactory blockFactory = new BlockFactory();
            TenBlocks tenBlocks = blockFactory.GetPuzzleWithTenBlocks();

            Console.WriteLine( tenBlocks.ToString() );

            Console.ReadKey();
        }
    }
}
