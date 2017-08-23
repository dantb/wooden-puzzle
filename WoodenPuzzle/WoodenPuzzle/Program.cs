using Facet.Combinatorics;
using System.Collections.Generic;
using System.Linq;
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

            Combinations<Block> combinations = new Combinations<Block>(tenBlocks, 5);
            foreach (List<Block> combination in combinations)
            {
                // we have a selection of 5 blocks, not ordered. We need to create a skeleton solution based on this
                List<IEnumerable<Block>> permutations = combination.Permute().ToList();
                foreach (var permutation in permutations)
                {
                    foreach (Block block in permutation)
                    {
                        WriteLine(block);

                    }
                    WriteLine();
                }

            }
            
            WriteLine();
            WriteLine();

            Block original = tenBlocks[0];
            WriteLine(original.ToString());
            Block reversed = new Block(original);
            WriteLine(reversed.ToString());

            ReadKey();
        }
    }

    public static class EnumerableExtensions
    {

        public static IEnumerable<IEnumerable<T>> Permute<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null)
            {
                yield break;
            }

            var list = sequence.ToList();

            if (!list.Any())
            {
                yield return Enumerable.Empty<T>();
            }
            else
            {
                var startingElementIndex = 0;

                foreach (var startingElement in list)
                {
                    var remainingItems = list.AllExcept(startingElementIndex);

                    foreach (var permutationOfRemainder in remainingItems.Permute())
                    {
                        yield return startingElement.Concat(permutationOfRemainder);
                    }

                    startingElementIndex++;
                }
            }
        }

        private static IEnumerable<T> Concat<T>(this T firstElement, IEnumerable<T> secondSequence)
        {
            yield return firstElement;
            if (secondSequence == null)
            {
                yield break;
            }

            foreach (var item in secondSequence)
            {
                yield return item;
            }
        }

        private static IEnumerable<T> AllExcept<T>(this IEnumerable<T> sequence, int indexToSkip)
        {
            if (sequence == null)
            {
                yield break;
            }

            var index = 0;

            foreach (var item in sequence.Where(item => index++ != indexToSkip))
            {
                yield return item;
            }
        }
    }
}
