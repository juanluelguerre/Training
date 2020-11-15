using System;
using static System.Console;

namespace FeaturesCS7
{
    public class ProjectCS7
    {
        public int Id { get; } = 1;
        public string Title { get; set; } = "Project 1";
        public string Description { get; set; } = "New Features C#6";
        public string GetDetail() =>
            $"This is a project with id {Id}, title {Title} and a description: {Description}";            

        #region CASE 1) Constructor: Expression-bodied constructor

        public ProjectCS7() { }

        public ProjectCS7(int id) => this.Id = id;

        #endregion

        #region CASE 2) Destructor: Expression-bodied finalizer

        ~ProjectCS7() => Console.Error.WriteLine("Finalized!");

        #endregion

        #region CASE 3)  Expression-bodied get / set accessors

        private string _description2;

        public string Description2
        {
            get  => _description2; 
            set => _description2 = value ?? "Default Description"; 
        }

        #endregion
    }

    public class CS7
    {
        static void Main(string[] args)
        {
            WriteLine("Expression Bodied Members II (C# 7.0):");

            var p = new ProjectCS7();
            WriteLine(p.GetDetail());

            WriteLine("Pulse INTRO para finalizar...");
            ReadLine();
        }
    }
}
