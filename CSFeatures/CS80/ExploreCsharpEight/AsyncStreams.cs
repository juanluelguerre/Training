//
// Ref: Some samples from: https://www.variablenotfound.com/2019/10/enumerables-asincronos-en-c-8.html#more
//
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExploreCsharpEight
{
    class AsyncStreams
    {
        internal void Do_Option1()
        {
            foreach (var i in GetNumbers())
            {
                Console.WriteLine(i);
            }

            static IEnumerable<int> GetNumbers()
            {
                for (var i = 0; i < 1000; i++)
                {
                    var a = i * 2;   // <-- Esto es una operación síncrona,
                    yield return a;  //     ¿cómo haríamos si en lugar de esta operación síncrona
                                     //     necesitásemos hacer una llamada asíncrona para obtenerlo?
                }
            }
        }

        internal async void Do_Option2()
        {
            foreach (var i in await GetNumbersAsync())
            {
                Console.WriteLine(i);
            }

            static async Task<IEnumerable<int>> GetNumbersAsync()
            {
                var list = new List<int>();
                for (var i = 0; i < 1000; i++)
                {
                    var a = await Task.FromResult(i * 2); // <-- Aquí generamos los valores usando asincronía,
                    list.Add(a);                          //     pero el consumidor seguirá esperando hasta
                                                          //     que los hayamos generado todos.
                }
                return list;                              // <-- Aquí retornamos la colección completa
            }
        }

        internal async void Do_Solution()
        {
            await foreach (var i in GetNumbers())
            {
                Console.WriteLine(i);
            }

            static async IAsyncEnumerable<int> GetNumbers()
            {
                for (var i = 0; i < 1000; i++)
                {
                    var a = await Task.FromResult(i * 2); // <-- Esto podría ser cualquier tipo
                    yield return a;                       //     de operación asíncrona
                }
            }            
        }

        #region AsyncStreams_Declare

        internal async IAsyncEnumerable<int> GenerateSequence()
        {
            for (int i = 0; i < 10; i++)
            {
                // every 3 elements, wait 2 seconds:
                if (i % 3 == 0)
                    await Task.Delay(2000);
                yield return i;
            }
        }
        #endregion

        internal async Task<int> ConsumeStream()
        {
            #region AsyncStreams_Consume

            await foreach (var number in GenerateSequence())
            {
                Console.WriteLine($"The time is {DateTime.Now:hh:mm:ss}. Retrieved {number}");
            }
            #endregion

            return 0;
        }

    }
}
