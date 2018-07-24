//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 4 - PriorityQueue
//	File Name:		IPriorityQueue.cs
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
	/// Interface to create double linked list 
	/// </summary>
	/// <typeparam name="P">Priority</typeparam>
	/// <typeparam name="T">Value</typeparam>
	/// <seealso cref="PriorityQueue.IContainer{T}" />
	public interface IPriorityQueue<P, T> : IContainer<T> where P : IComparable
	{
		#region Interface Methods
		/// <summary>
		/// Enqueues the specified item.
		/// </summary>
		/// <param name="item">The item.</param>
		void Enqueue (Node<P, T> listItem);
		/// <summary>
		/// Dequeues this instance.
		/// </summary>
		void Dequeue ( );
		/// <summary>
		/// Peeks this instance.
		/// </summary>
		/// <returns>Linked List Node</returns>
		Node<P, T> Peek ( );
		/// <summary>
		/// Gets the enumerator.
		/// </summary>
		/// <returns>Enumerator Item</returns>
		IEnumerator<Node<P, T>> GetEnumerator ( );
		#endregion
	}//End interface IPriorityQueue<T>
}//End PriorityQueue
