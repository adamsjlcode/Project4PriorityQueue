
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4
{
	/// <summary>
	/// Utility Class for Program
	/// </summary>
	public static class Utility
	{
		/// <summary>
		/// Adds the newline.
		/// </summary>
		/// <param name="number">The number.</param>
		/// <returns>the number of new lines needed</returns>
		public static string addNewline (int number)
		{
			string newLine = "";
			for (int i = 0 ; i < number ; i++)
			{
				newLine += "\n";	
			}//end for loop
			return newLine;
		}//End addNewline (int)
		 /// <summary>
		 /// Adds the tab.
		 /// </summary>
		 /// <param name="number">The number.</param>
		 /// <returns>the number of new tabs needed</returns>
		public static string addTab (int number)
		{
			string newTab = "";
			for (int i = 0 ; i < number ; i++)
			{
				newTab += "\t";
			}//end for loop
			return newTab;
		}//End addTab (int)
		 /// <summary>
		 /// Adds the line.
		 /// </summary>
		 /// <param name="number">The number.</param>
		 /// <returns>A Line to display</returns>
		public static string addLine (int number)
		{
			string newLine = "";
			for (int i = 0 ; i < number ; i++)
			{
				newLine += "_";
			}//end for loop
			return newLine;
		}//End addLine (int)
		 /// <summary>
		 /// Adds the Star.
		 /// </summary>
		 /// <param name="number">The number.</param>
		 /// <returns>the number of new * needed</returns>
		public static string addStar (int number)
		{
			string newStar = "";
			for (int i = 0 ; i < number ; i++)
			{
				newStar += "*";
			}//end for loop
			return newStar;
		}//End addLine (int)
	}//End Utility
}//End PriorityQueue
