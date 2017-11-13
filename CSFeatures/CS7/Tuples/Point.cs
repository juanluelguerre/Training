using System;
using System.Collections.Generic;
using System.Text;
//
// Samples from: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7
//
namespace FeatruesCS7
{
    public class Point
    {
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; }
        public double Y { get; }

        public void Deconstruct(out double x, out double y)
        {
            x = this.X;
            y = this.Y;
        }
    }
}
