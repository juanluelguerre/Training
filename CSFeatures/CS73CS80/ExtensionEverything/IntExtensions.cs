//
// https://blog.ndepend.com/c-8-0-features-glimpse-future/
//
using System;
using System.Xml.Linq;

namespace ExtensionEverything
{
    // Static Class
    public static class IntExtensions
    {
        // Static method and "this" as first parm
        public static bool IsEven(this int value)
        {
            return value % 2 == 0;
        }
    }

    // 1) New ini C# 8.0. New type declaration called an "extension", and "extends"    
    //public extension Int2Extension extends int
    //{
    //    public bool IsEven => this % 2 == 0;
    //}

} 
