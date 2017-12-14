//
// Samples from: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7
//
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;

namespace FeatruesCS7
{
    public static class CS7
    {
        static void Main(string[] args)
        {
            var alphabet = new List<char>()
                { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'ñ' } as IEnumerable<char>;

            var resultSet = alphabet.AlphabetSubset3('f', 'a');
            Console.WriteLine("iterator created");
            foreach (var thing in resultSet)
                Console.Write($"{thing}, ");

            WriteLine("Pulse INTRO para finalizar...");
            ReadLine();
        }

        #region CASE 1

        // Exception thrown when the result of this method used. Inside the Caller!

        public static IEnumerable<char> AlphabetSubset(this IEnumerable<char> _, char start, char end)
        {
            if (start < 'a' || start > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
            if (end < 'a' || end > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");

            if (end <= start)
                throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");
            for (var c = start; c < end; c++)
                yield return c;
        }

        #endregion

        #region CASE 2

        // 1) Exception thrown when method is called.        

        public static IEnumerable<char> AlphabetSubset2(this IEnumerable<char> _, char start, char end)
        {
            if (start < 'a' || start > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
            if (end < 'a' || end > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");

            if (end <= start)
                throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");
            return AlphabetSubsetImplementation(start, end);
        }

        // 2) A new Private member solve it, but the private member could be called outside this public method, withouth validation. 

        private static IEnumerable<char> AlphabetSubsetImplementation(char start, char end)
        {
            for (var c = start; c < end; c++)
                yield return c;
        }

        #endregion

        #region CASE 3

        // Solution to cases 1 and 2 -> Local Funciton !!!

        public static IEnumerable<char> AlphabetSubset3(this IEnumerable<char> _,char start, char end)
        {
            if (start < 'a' || start > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
            if (end < 'a' || end > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");

            if (end <= start)
                throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");

            return alphabetSubsetImplementation();

            // This is a local function 
            IEnumerable<char> alphabetSubsetImplementation()
            {
                for (var c = start; c < end; c++)
                    yield return c;
            }
        }

        #endregion

        #region CASE 4

        // Solution to similar cases with async !!!

        public static Task<string> PerformLongRunningWork(string address, int index, string name)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException(message: "An address is required", paramName: nameof(address));
            if (index < 0)
                throw new ArgumentOutOfRangeException(paramName: nameof(index), message: "The index must be non-negative");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(message: "You must supply a name", paramName: nameof(name));

            return LongRunningWorkImplementation();

            async Task<string> LongRunningWorkImplementation()
            {
                var result1 = await DoSomething1(address);
                var result2 = await DoSomething2(index, name);
                return $"The results are {result1} and {result2}. Enjoy.";
            }
        }

        private static async Task<string> DoSomething1(string address)
        {
            return await Task.Run(() => address);
        }

        private static async Task<string> DoSomething2(int index, string name)
        {
            return await Task.Run(() => name.Substring(index));
        }

        #endregion
    }
}
