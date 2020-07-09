using System;
//
// Samples form:  https://github.com/dotnet/try-samples/tree/master/csharp8
//

using System.Collections.Generic;
using System.Text;

namespace ExploreCsharpEight
{
    #region Nullable_PersonDefinition
    
    #nullable enable
    
    internal class Person
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }

        public Person(string first, string last) =>
            (FirstName, LastName) = (first, last);

        public Person(string first, string middle, string last) =>
            (FirstName, MiddleName, LastName) = (first, middle, last);

        public override string ToString() => $"{FirstName} {MiddleName} {LastName}";
    }

#nullable restore

    #endregion

    /// <summary>
    /// INFO:
    /// In a nullable enabled context, the compiler uses static analysis to enforce these rules:
    ///   - A non-nullable reference must be initialized to a non-null value.
    ///   - A non-nullable reference cannot be assigned to a variable that may be null.
    ///   - A nullable reference may only be dereferenced safely when static analysis determines its value cannot be null.
    /// There may be situations where you know a variable is not null, even though static analysis cannot prove it.
    /// For those situations, you can use the null forgiveness operator, !, to declare that the variable is not null.
    /// </summary>
    class NullableReferences
    {

        #region Nullable_GetLengthMethod

        #nullable enable

        private static int GetLengthOfMiddleName(Person p)
        {
            //
            // string middleName = p.MiddleName!;
            //
            string middleName = p.MiddleName;
            return middleName.Length;
        }
        
        #nullable restore

        #endregion

        internal int NullableTestBed()
        {
            #region Nullable_Usage

            #nullable enable

            Person juanlu = new Person("Juan", "Guerrero");
            var length = GetLengthOfMiddleName(juanlu);
            Console.WriteLine(length);
            
            #nullable restore
            //Was this tested on a person who doesn't have a middle name?

            #endregion
            return 0;
        }
    }
}
