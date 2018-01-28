//
// Samples from: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7
//
using System;
using static System.Console;

namespace FeatruesCS7
{
    public class CS7
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[3, 3]
            {
                { 1, 2, 3 },
                { 1, 42, 3 },
                { 1, 2, 3 }
            };

            WriteLine("--- Matrix 1 ---");
            var indices = MatrixFind(matrix, (val) => val == 42);
            WriteLine($"{indices} = { matrix[indices.i, indices.j]}");

            //Changing value
            matrix[indices.i, indices.j] = 35;
            indices = MatrixFind(matrix, (val) => val == 42); // Change value doesn't work properly. Not found !
            if (indices.i != -1 && indices.j != -1)
                WriteLine($"{indices} = { matrix[indices.i, indices.j]}");
            else
                WriteLine("Not found!");


            WriteLine("--- Matrix 2 ---");
            var valItem2 = MatrixFindValue(matrix, (val) => val == 35);
            WriteLine($"Value: {valItem2}");
            valItem2 = 24;
            WriteLine($"Matrix Value: {matrix[1, 1]}");


            WriteLine("--- Matrix 3 ---");
            ref var valItem3 = ref MatrixFindValue(matrix, (val) => val == 35);
            WriteLine($"Value: {valItem3}");
            valItem3 = 24; // Reference value change directly without index.
            WriteLine($"Matrix Value: {matrix[1, 1]}");



            WriteLine("Pulse INTRO para finalizar...");
            ReadLine();
        }

        // Usin modern tuples (System.ValueTuple) for C# 7.0 and upper
        public static (int i, int j) MatrixFind(int[,] matrix, Func<int, bool> predicate)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (predicate(matrix[i, j]))
                        return (i, j);
            return (-1, -1); // Not found
        }


        // Note that this won't compile. 
        // Method declaration indicates ref return,
        // but return statement specifies a value return.
        public static ref int MatrixFindValue(int[,] matrix, Func<int, bool> predicate)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (predicate(matrix[i, j]))
                        return ref matrix[i, j];
            throw new InvalidOperationException("Not found");
        }
    }
}
