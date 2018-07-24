//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 4 - PriorityQueue
//	File Name:		NodeLink.cs
//	Description:	Holder of node links	
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
	/// Holds double link for Current Node 
	/// </summary>
	/// <typeparam name="P">Priority</typeparam>
	/// <typeparam name="T">Value</typeparam>
	public class NodeLink<P, T> where P : IComparable
	{

		#region Properties
		/// <summary>
		/// Gets or sets the current node.
		/// </summary>
		/// <value>
		/// The current node.
		/// </value>
		public Node<P, T> CurrentNode { get; set; }
		/// <summary>
		/// Gets or sets the parent node.
		/// </summary>
		/// <value>
		/// The parent node.
		/// </value>
		public NodeLink<P, T> ParentNode { get; set; }
		/// <summary>
		/// Gets or sets the child node.
		/// </summary>
		/// <value>
		/// The child node.
		/// </value>
		public NodeLink<P, T> ChildNode { get; set; }
		#endregion

	}//End NodeLink<P, T>
}//End PriorityQueue
