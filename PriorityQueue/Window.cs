//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 4 - PriorityQueue
//	File Name:		PriorityLinkedList.cs
//	Description:	Im	
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Justin Adams, adamsjl3@etsu.edu, Undergrad CS, East Tennessee State University
//	Created:		Thursday, November 09, 2017
//	Copyright:		Justin Adams, 2017
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;

namespace Project4
{
	/// <summary>
	/// Queue of Registrant for waiting line simulation 
	/// </summary>
	public class Window : IEquatable<Window>
	{
		#region Properties
		/// <summary>
		/// The line
		/// </summary>
		Queue<Registrant> Line;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Window"/> class.
		/// </summary>
		public Window ( )
		{
			Line = new Queue<Registrant> ( );
		}//End Window ( )
		#endregion

		#region Methods

		 /// <summary>
		 /// Adds the line.
		 /// </summary>
		 /// <param name="register">The register.</param>
		public void AddLine (Registrant register)
		{
			Line.Enqueue (register);
		}//End AddLine (Registrant
		 /// <summary>
		 /// Sizes the of line.
		 /// </summary>
		 /// <returns>Size of Line</returns>
		public int SizeOfLine ( )
		{
			return Line.Count;
		}//End SizeOfLine ( )
		 /// <summary>
		 /// Removes the line.
		 /// </summary>
		 /// <returns>Remove head node</returns>
		public Registrant RemoveLine ( )
		{
			return Line.Dequeue ( );
		}//End RemoveLine ( )

		/// <summary>
		/// Check Heads the line.
		/// </summary>
		public Registrant HeadLine ( )
		{
			return Line.Peek ( );
		}//End HeadLine ( )
		#endregion

		#region Overridden Methods
		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
		/// </returns>
		public bool Equals (Window other)
		{
			if (other == null) return false;
			return (this.Line.Peek().Equals (other.Line.Peek ( )));
		}//End Equals (Window)
		 /// <summary>
		 /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
		 /// </summary>
		 /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
		 /// <returns>
		 ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
		 /// </returns>
		public override bool Equals (object obj)
		{
			if (obj == null) return false;
			Window objAsPart = obj as Window;
			if (objAsPart == null) return false;
			else return Equals (objAsPart);
		}//End Equals (object) 
		 /// <summary>
		 /// Returns a hash code for this instance.
		 /// </summary>
		 /// <returns>
		 /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
		 /// </returns>
		public override int GetHashCode ( )
		{
			return base.GetHashCode ( );
		}//End GetHashCode ( )
		 /// <summary>
		 /// To the string line.
		 /// </summary>
		 /// <returns>Array of Registers ToStrings</returns>
		public override string ToString ( )
		{
			Registrant[] waitingline = Line.ToArray();
			string inLine = "";
			for (int i = 0 ; i < waitingline.Length ; i++)
			{
				inLine += waitingline[i].ToString ( ) + "|";		
			}//end for loop
			return inLine;
		}//End ToStringLine ( )
		#endregion
 
	}//End 
}//End 
