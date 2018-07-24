//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 4 - PriorityQueue
//	File Name:		PriorityQueue.cs
//	Description:	Implementation of Priority Queue	
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Justin Adams, adamsjl3@etsu.edu, Undergrad CS, East Tennessee State University
//	Created:		Thursday, November 09, 2017
//	Copyright:		Justin Adams, 2017
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4
{
	
	/// <summary>
	/// Implementation of Priority Queue Interface
	/// </summary>
	/// <typeparam name="P">Priority</typeparam>
	/// <typeparam name="T">Value</typeparam>
	/// <seealso cref="System.Collections.Generic.IEnumerable{T}" />
	/// <seealso cref="System.Collections.IEnumerable" />
	public class PriorityQueue <P, T> : IEnumerable<T>, IEnumerable where P : IComparable 
	{
		#region Interface Implementation Properties
		/// <summary>
		/// The linked list
		/// </summary>
		private IPriorityQueue<P, T> linkedList = new PriorityLinkedList<P, T> ( );
		/// <summary>
		/// Gets the count.
		/// </summary>
		/// <value>
		/// The count.
		/// </value>
		public int Count
		{
			get
			{
				return linkedList.Count ( );
			}//End get
		}//End Count
		#endregion

		#region Interface Implementation Methods
		/// <summary>
		/// Clears this instance.
		/// </summary>
		public void Clear ( )
		{
			linkedList.Clear ( );
		}//End Clear ( ) 
		 /// <summary>
		 /// Dequeues this instance.
		 /// </summary>
		public void Dequeue ( )
		{
			linkedList.Dequeue ( );
		}//End Dequeue ( )
		 /// <summary>
		 /// Enqueues the specified priority.
		 /// </summary>
		 /// <param name="priority">The priority.</param>
		 /// <param name="value">The value.</param>
		public void Enqueue (P priority, T value)
		{
			linkedList.Enqueue (new Node<P, T> ( )
			{
				Key = priority,
				Value = value
			});
		}//End Enqueue (P, T)
		 /// <summary>
		 /// Peeks this instance.
		 /// </summary>
		 /// <returns>Value of top Queue</returns>
		public T Peek ( )
		{
			var tempItem = linkedList.Peek ( );
			return tempItem.Value;
		}//End Peek ( )
		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>
		/// An enumerator that can be used to iterate through the collection.
		/// </returns>
		public IEnumerator<T> GetEnumerator ( )
		{
			foreach (var item in linkedList)
			{
				yield return item.Value;
			}//End foreach statement
		}//End GetEnumerator ( )
		 /// <summary>
		 /// Returns an enumerator that iterates through a collection.
		 /// </summary>
		 /// <returns>
		 /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
		 /// </returns>
		IEnumerator IEnumerable.GetEnumerator ( )
		{
			foreach (var item in linkedList)
			{
				yield return item.Value;
			}//End foreach statement
		}//End IEnumerable.GetEnumerator ( )
		#endregion

	}//End PriorityQueue <P, T>					  
}//Project4
