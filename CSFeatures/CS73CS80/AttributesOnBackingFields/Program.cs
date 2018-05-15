using System;
using System.IO;
using System.Xml.Serialization;

namespace AttributesOnBackingFields
{
    [Serializable]
    public class Foo1
    {
        [NonSerialized]
        private string MySecret_backingField;

        public string MySecret
        {
            get { return MySecret_backingField; }
            set { MySecret_backingField = value; }
        }
    }

    //
    // 1)
    //
    [Serializable]
    public class Foo2
    {
        [field: NonSerialized]
        public string MySecret { get; set; }

        // [field: NonSerializedAttribute()]
        // public event ChangedEventHandler Changed;
    }

    static class Program
    {
        public static T Deserialize<T>(this string toDeserialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StringReader textReader = new StringReader(toDeserialize);
            return (T)xmlSerializer.Deserialize(textReader);
        }

        public static string Serialize<T>(this T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StringWriter textWriter = new StringWriter();
            xmlSerializer.Serialize(textWriter, toSerialize);
            return textWriter.ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Attributes On Backing Fields");

            var strFoo1 = Serialize(new Foo1() { MySecret = "Juanlu" });
            Console.WriteLine($"{nameof(Foo1)}: {strFoo1}");


            var strFoo2 = Serialize(new Foo2() { MySecret = "Juanlu" });
            Console.WriteLine($"{nameof(Foo2)}: {strFoo2}");

            var objFoo1 = Deserialize<Foo1>(strFoo1);

            var objFoo2 = Deserialize<Foo2>(strFoo2);


            Console.WriteLine("Press ENTER to finish...");
            Console.ReadLine();
        }

    }
}
