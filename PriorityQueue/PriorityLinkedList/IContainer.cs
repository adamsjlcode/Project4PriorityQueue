//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 4 - PriorityQueue
//	File Name:		IContainer.cs
//	Description:	Holds the count and container is empty	
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
	/// Interface of a container
	/// </summary>
	/// <typeparam name="T">Value</typeparam>
	public interface IContainer<T>
	{
		
		#region Interface Methods
		/// <summary>
		/// Clears this instance.
		/// </summary>
		void Clear ( );
		/// <summary>
		/// Determines whether this instance is empty.
		/// </summary>
		bool IsEmpty ( );
		/// <summary>
		/// Counts this instance.
		/// </summary>
		/// <returns></returns>
		int Count ( );
		#endregion

	}//End IContainer<T>
}//End PriorityQueue
