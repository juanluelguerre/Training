////
//// Samples from: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7
////
//using System;
//using static System.Console;

//namespace FeatruesCS7
//{
//    public class CS6
//    {
//        static void Main(string[] args)
//        {
//            int[,] matrix = new int[3, 3]
//            {
//                { 1, 2, 3 },
//                { 1, 42, 3 },
//                { 1, 2, 3 }
//            };

//            var indices = MatrixFind(matrix, (val) => val == 42);
//            WriteLine(indices);

//            matrix[indices.Item1, indices.Item2] = 24;
//            MatrixFind(matrix, (val) => val == 42); // Chage value doesn't work properly
//            WriteLine(indices);

//            WriteLine("Pulse INTRO para finalizar...");
//            ReadLine();
//        }

//        // Uinng Clasis Tuple before C# 7.0
//        public static Tuple<int, int> MatrixFind(int[,] matrix, Func<int, bool> predicate)
//        {
//            for (int i = 0; i < matrix.GetLength(0); i++)
//                for (int j = 0; j < matrix.GetLength(1); j++)
//                    if (predicate(matrix[i, j]))
//                        return Tuple.Create(i, j);
//            return Tuple.Create(-1, -1); // Not found
//        }
//    }
//}
