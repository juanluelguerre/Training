//
// Samples form:  https://github.com/dotnet/try-samples/tree/master/csharp8
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExploreCsharpEight
{
    internal class ResourceHog : IDisposable
    {
        private string name;
        private bool beenDisposed;

        public ResourceHog(string name) => this.name = name;

        public void Dispose()
        {
            beenDisposed = true;
            Console.WriteLine($"Disposing {name}");
        }

        internal void CopyFrom(ResourceHog src)
        {
            switch (beenDisposed, src.beenDisposed)
            {
                case (true, true): throw new ObjectDisposedException($"Resource {name} has already been disposed");
                case (true, false): throw new ObjectDisposedException($"Resource {name} has already been disposed");
                case (false, true): throw new ObjectDisposedException($"Resource {name} has already been disposed");
                default: Console.WriteLine($"Copying from {src.name} to {name}"); return;
            };

        }
    }
    /// <summary>
    /// INFO:
    /// A using declaration is a variable declaration preceded by the "using" keyword.
    /// It tells the compiler that the variable being declared should be disposed at the end of the enclosing scope.   
    /// The using block has always been recommended for local variables when the type implements IDisposable.
    /// The following example shows a hypothetical use of two objects that implement IDisposable.
    /// Run the code and you'll see the ResourceHog writes a message when it is being disposed:
    /// 
    /// In addition: 
    /// A struct declared with the ref modifier may not implement any interfaces and so cannot implement System.IDisposable.
    /// Therefore, to enable a ref struct to be disposed, it must have an accessible void Dispose() method.
    /// This also applies to readonly ref struct declarations. These types can now release resources in using declarations or using blocks.
    /// </summary>
    internal class Using_DeclarationsRefStruct
    {
        internal int OldStyle()
        {
            #region Using_Block
            
            using (var src = new ResourceHog("source"))
            {
                using (var dest = new ResourceHog("destination"))
                {
                    dest.CopyFrom(src);
                }
                Console.WriteLine("After closing destination block");
            }
            Console.WriteLine("After closing source block");

            #endregion
            return 0;
        }








        internal int NewStyle()
        {
            #region Using_Declaration

            using var src = new ResourceHog("source");
            using var dest = new ResourceHog("destination");
            dest.CopyFrom(src);
            
            Console.WriteLine("Exiting block");

            #endregion

            return 0;
        }
    }
}
