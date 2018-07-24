//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 4 - PriorityQueue
//	File Name:		Node.cs
//	Description:	Holds data and priority for linked list	
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Justin Adams, adamsjl3@etsu.edu, Undergrad CS, East Tennessee State University
//	Created:		Thursday, November 09, 2017
//	Copyright:		Justin Adams, 2017
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4
{
	/// <summary>
	/// Holds Linked List Node 
	/// </summary>
	/// <typeparam name="P">Priority</typeparam>
	/// <typeparam name="T">Value</typeparam>
	public class Node<P, T> where P : IComparable
	{
		/// <summary>
		/// Gets or sets the key.
		/// </summary>
		/// <value>
		/// The key.
		/// </value>
		public P Key { get; set; }
		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>
		/// The value.
		/// </value>
		public T Value { get; set; }

		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString ( )
		{
			return Key.ToString ( ) + " " + Value.ToString ( );
		}//End ToString ( )
	}//End Node<P, T>
}//End PriorityQueue 
