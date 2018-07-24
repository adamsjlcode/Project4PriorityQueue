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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4
{
	
	/// <summary>
	/// Priority Linked List
	/// </summary>
	/// <typeparam name="P">Priority</typeparam>
	/// <typeparam name="T">Value</typeparam>
	/// <seealso cref="Project4.IPriorityQueue{P, T}" />
	public class PriorityLinkedList<P, T> : IPriorityQueue<P, T> where P : IComparable
	{
		/// <summary>
		/// The top node
		/// </summary>
		private NodeLink<P, T> TopNode;
		/// <summary>
		/// Counts this instance.
		/// </summary>
		/// <returns></returns>
		public int Count ( )
		{
			var count = 0;
			NodeLink<P, T> link = TopNode;
			while (link != null)
			{
				if (link.CurrentNode != null)
					count++;
				link = link.ChildNode;
			}//End while loop
			return count;
		}//End Count ( )
		 /// <summary>
		 /// Clears this instance.
		 /// </summary>
		public void Clear ( )
		{
			TopNode = null;
		}//End Clear ( )
		 /// <summary>
		 /// Determines whether this instance is empty.
		 /// </summary>
		 /// <returns>If Queue has a count</returns>
		public bool IsEmpty ( )
		{
			return Count ( ) == 0;
		}//End IsEmpty ( )
		 /// <summary>
		 /// Gets the enumerator.
		 /// </summary>
		 /// <returns>
		 /// Enumerator Item
		 /// </returns>
		public IEnumerator<Node<P, T>> GetEnumerator ( )
		{
				NodeLink<P, T> tempNode = TopNode;
				do
				{
					if (tempNode.CurrentNode != null)
						yield return tempNode.CurrentNode;
					tempNode = tempNode.ChildNode;
				}
				while (tempNode != null);
		}//End GetEnumerator ( )
		 /// <summary>
		 /// Enqueues the specified item.
		 /// </summary>
		 /// <param name="listItem">List Item</param>
		public void Enqueue (Node<P, T> listItem)
		     {
				if (Count ( ) == 0)
				{
					TopNode = new NodeLink<P, T> ( )
					{
						CurrentNode = listItem
					};
				}//End if statement
			else
			{
				if (TopNode.CurrentNode.Key.CompareTo(listItem.Key) < 0)
				{
					var curNode = TopNode;
					var prevNode = new NodeLink<P, T> ( )
					{
						CurrentNode = listItem
					};
					prevNode = null;
					while (curNode != null && curNode.CurrentNode.Key.CompareTo (listItem.Key) == -1)
					{
						prevNode = curNode;
						curNode = curNode.ChildNode;
					}
					var tempNode = new NodeLink<P, T> ( )
					{
						CurrentNode = listItem
					};
					if (prevNode != null)
					{
						if (prevNode.ChildNode == null)
						{
							prevNode.ChildNode = tempNode;
							prevNode.ChildNode.ParentNode = prevNode;
						}//End if statement
						else
						{
							tempNode.ChildNode = prevNode.ChildNode;
							prevNode.ChildNode = tempNode;
							prevNode.ChildNode.ParentNode = prevNode;
						}//End else statement
					}//End if statement
					else
					{
						TopNode = tempNode;
					}//End else statement
				}//End if statement				
				else
				{
					var tempNode = TopNode;
					TopNode = new NodeLink<P, T> ( ) { CurrentNode = listItem };
					TopNode.ChildNode = tempNode;
					tempNode.ParentNode = TopNode;
				}//End else statement
			}//End else statement 
		}//End Enqueue (Node<P, T>
		 /// <summary>
		 /// Peeks this instance.
		 /// </summary>
		 /// <returns>
		 /// Linked List Node
		 /// </returns>
		 /// <exception cref="InvalidOperationException">Empty Queue</exception>
		public Node<P, T> Peek ( )
		{
			if (!IsEmpty ( ))
			{
				return TopNode.CurrentNode;
			}//End if statement
			else
			{
				throw new InvalidOperationException ("Empty Queue");
			}//End else statement
		}//End Peek ( )
		 /// <summary>
		 /// Dequeues this instance.
		 /// </summary>
		 /// <exception cref="InvalidOperationException">Empty Queue</exception>
		public void Dequeue ( )
		{
			if (!IsEmpty ( ))
			{
				var tempNode = TopNode;
				TopNode = tempNode.ChildNode;
				tempNode = null;
			}//End if statement
			else
			{
				throw new InvalidOperationException ("Empty Queue");
			}//End else statement
		}//End Dequeue ( )
	}//End PriorityLinkedList<P, T>
}//End Project4
