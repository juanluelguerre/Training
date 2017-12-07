using System;
using static System.Console;

namespace FeaturesCS7
{
    class CS7
    {
        public class ProjectCS7
        {
            public ProjectCS7() { }
            public int Id { get; } = 1;
            public string Title { get; set; } = "Project 1";
            public string Description { get; set; } = "New Features C#6";
            public string GetDetail() =>
                $"This is a project with id {Id}, title {Title} and a description: {Description}";

            public ProjectCS7(int id) => this.Id = id;

            //public ProjectCS7(int id)
            //{
            //    if (id == -1)
            //        throw new ArgumentException(nameof(id));

            //    this.Id = id;
            //}

            #region CASE 1

            //private int id;
            //public int Id { get => id; set => id = (value == -1) ? throw new ArgumentException(nameof(id)) : value; }

            #endregion

            #region CASE 2

            public readonly string Description2 = 
                LoadConfiguration() ?? throw new InvalidOperationException("Could not load config");

            private static string LoadConfiguration()
            {
                return "Something....";
            }

            #endregion
        }

        public static void Main(string[] args)
        {
            WriteLine("C# 7.0 - Throw Expressions");

            var p = new ProjectCS7();
            WriteLine(p.GetDetail());

            WriteLine("Pulse INTRO para finalizar...");
            ReadLine();
        }
    }
}
