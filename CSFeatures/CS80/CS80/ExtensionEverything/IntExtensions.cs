//
// https://blog.ndepend.com/c-8-0-features-glimpse-future/
//
using System;
using System.Xml.Linq;

namespace ExtensionEverything
{
	// 1) Static Class
	public static class IntExtensions
	{
		// 2) Static method and "this" as first parm
		public static bool IsEven(this int value)
		{
			return value % 2 == 0;
		}
	}

	// New type declaration called an “extension”
	//public extension Int2Extension extends int
    //{
    //    public bool IsEven => this % 2 == 0;
    //}

} 
