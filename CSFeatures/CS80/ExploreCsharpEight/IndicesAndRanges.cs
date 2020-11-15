//
// Samples form:  https://github.com/dotnet/try-samples/tree/master/csharp8
//

using System;
using System.Linq;

namespace ExploreCsharpEight
{
    class IndicesAndRanges
    {
        // TODO: replace in IndicesAndRanges.md when non-editable blocks are supported.
        #region IndicesAndRanges_Initialization

        private string[] words = new string[]
        {
                        // index from start    index from end
            "The",      // 0                   ^9
            "quick",    // 1                   ^8
            "brown",    // 2                   ^7
            "fox",      // 3                   ^6
            "jumped",   // 4                   ^5
            "over",     // 5                   ^4
            "the",      // 6                   ^3
            "lazy",     // 7                   ^2
            "dog"       // 8                   ^1
        };
        #endregion

        internal int IndexAndRangesBasicSamples()
        {
            // Static local funcion in action (:D) !!!
            static string ArrToString(string[] values) => string.Join(",", values);

            #region Index

            Index i0 = new Index(0);
            Index i1 = new Index(1);
            Index i8 = new Index(8);

            Console.WriteLine(words[i0]); // The
            Console.WriteLine(words[i1]); // quick
            Console.WriteLine(words[i8]); // dog

            var iLast1 = Index.FromEnd(1);
            var iLast2 = Index.FromEnd(2);

            Console.WriteLine(words[iLast1]); // dog
            Console.WriteLine(words[iLast2]); // lazy

            #endregion

            #region Ranges

            Range r1 = new Range(0, 8);
            Range r2 = new Range(^1, ^0);
            Range r3 = new Range(^3, ^0);

            Console.WriteLine($"r1: {ArrToString(words[r1])}"); // The,quick,brown,fox,jumped,over,the,lazy
            Console.WriteLine($"r2: {ArrToString(words[r2])}"); // dog
            Console.WriteLine($"r3: {ArrToString(words[r3])}"); // the,lazy,dog

            #endregion
            
            try
            {
                // -- Index --
                //var a = words[^0];
                var b = words[^1];
                var c = words[^2];
                // var faraway = words[^99];  // Error -> Index Outbound !!!

                // -- Ranges --
                var d = words[..];
                var e = words[0..4];
                var f = words[..2];
                var g = words[4..];

                var h = words[0..^1];
                var i = words[0..^0];
                var j = words[^2..^0];
                var k = words[^2..^1];
                Console.WriteLine($"k: {ArrToString(k)}");

                // var l = words[^0..^9];
                // var m = words[^1..^9];
                // var n = words[^1..^8];
                var o = words[0..^8];                
                Console.WriteLine($"o: {ArrToString(o)}");

                var emptyArr = words[0..^9]; // Empty array !!!!  -> [0,  to 9 (from end)]

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return 0;
        }

        internal int Syntax_PartialRange()
        {
            #region IndicesAndRanges_PartialRanges

            var allWords = words[..]; // contains "The" through "dog".
            var firstPhrase = words[..4]; // contains "The" through "fox"
            var lastPhrase = words[6..]; // contains "the, "lazy" and "dog"
            foreach (var word in allWords)
                Console.Write($"< {word} >");
            Console.WriteLine();
            foreach (var word in firstPhrase)
                Console.Write($"< {word} >");
            Console.WriteLine();
            foreach (var word in lastPhrase)
                Console.Write($"< {word} >");
            Console.WriteLine();

            #endregion
            return 0;
        }

        internal int Syntax_IndexRangeType()
        {
            #region IndicesAndRanges_RangeIndexTypes

            Index the = ^3;
            Console.WriteLine(words[the]);
            Range phrase = 1..4;
            var text = words[phrase];
            foreach (var word in text)
                Console.Write($"< {word} >");
            Console.WriteLine();

            #endregion
            return 0;
        }

        internal int Syntax_WhyChosenSemantics()
        {
            #region IndicesAndRanges_CreateRange

            var numbers = Enumerable.Range(0, 100).ToArray();
            int x = 12;
            int y = 25;
            int z = 36;

            #endregion

            #region IndicesAndRanges_MathWithLength

            Console.WriteLine("^0 is the same as Length.");
            Console.WriteLine($"{numbers[^x]} is the same as {numbers[numbers.Length - x]}");
            Console.WriteLine($"{numbers[x..y].Length} is the same as {y - x}");
            Console.WriteLine();
            #endregion

            #region IndicesAndRanges_Disjoint

            Console.WriteLine("Consecutive disjoint sequences. numbers[x..y] and numbers[y..z] are consecutive and disjoint:");
            Span<int> x_y = numbers[x..y];
            Span<int> y_z = numbers[y..z];
            Console.WriteLine($"\tnumbers[x..y] is {x_y[0]} through {x_y[^1]}, numbers[y..z] is {y_z[0]} through {y_z[^1]}");
            Console.WriteLine();

            #endregion

            #region IndicesAndRanges_RemoveFromEnds

            Console.WriteLine("Remove elements from both ends. numbers[x..^x] removes x elements at each end:");
            Span<int> x_x = numbers[x..^x];
            Console.WriteLine($"\tnumbers[x..^x] starts with {x_x[0]} and ends with {x_x[^1]}");
            Console.WriteLine();

            #endregion

            #region IndicesAndRanges_IncompleteRanges

            Console.WriteLine("Incomplete sequences imply 0, ^0. numbers[..x] means numbers[0..x] and numbers[x..] means numbers[x..^0]");
            Span<int> start_x = numbers[..x];
            Span<int> zero_x = numbers[0..x];
            Console.WriteLine($"\t{start_x[0]}..{start_x[^1]} is the same as {zero_x[0]}..{zero_x[^1]}");
            Span<int> z_end = numbers[z..];
            Span<int> z_zero = numbers[z..];
            Console.WriteLine($"\t{z_end[0]}..{z_end[^1]} is the same as {z_zero[0]}..{z_zero[^1]}");
            Console.WriteLine();

            #endregion

            return 0;
        }

        internal int ComputeMovingAverages()
        {
            #region IndicesAndRanges_MovingAverage

            int[] sequence = Sequence(1000);


            for (int start = 0; start < sequence.Length; start += 100)
            {
                Range r = start..(start + 10);
                var (min, max, average) = MovingAverage(sequence, r);
                Console.WriteLine($"From {r.Start} to {r.End}:    \tMin: {min},\tMax: {max},\tAverage: {average}");
            }

            for (int start = 0; start < sequence.Length; start += 100)
            {
                Range r = ^(start + 10)..^start;
                var (min, max, average) = MovingAverage(sequence, r);
                Console.WriteLine($"From {r.Start} to {r.End}:  \tMin: {min},\tMax: {max},\tAverage: {average}");
            }

            (int min, int max, double average) MovingAverage(int[] subSequence, Range range) =>
                (
                    subSequence[range].Min(),
                    subSequence[range].Max(),
                    subSequence[range].Average()
                );
            #endregion
            return 0;
        }

        private int[] Sequence(int count)
        {
            return Enumerable.Range(0, count).Select(x => (int)(Math.Sqrt(x) * 100)).ToArray();
        }
    }
}
