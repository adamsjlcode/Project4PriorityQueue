//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 4 - PriorityQueue
//	File Name:		Event.cs
//	Description:	Holds the arrival and departure event for simulation	
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Justin Adams, adamsjl3@etsu.edu, Undergrad CS, East Tennessee State University
//	Created:		Monday, November 06, 2017
//	Copyright:		Justin Adams, 2017
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;

namespace Project4
{
	/// <summary>
	/// Event class for simulation
	/// </summary>
	public enum EVENT
	{
		/// <summary>
		/// The enter type
		/// </summary>
		ENTER,
		/// <summary>
		/// The leave type
		/// </summary>
		LEAVE
	}//End EVENT
	/// <summary>
	/// Create Event for registers
	/// </summary>
	/// <seealso cref="System.IComparable" />
	public class Event : IComparable
	{
		#region Properties
		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		/// <value>
		/// The type.
		/// </value>
		public EVENT Type { get; set; }
		/// <summary>
		/// Gets or sets the time.
		/// </summary>
		/// <value>
		/// The time.
		/// </value>
		public DateTime Time { get; set; }
		/// <summary>
		/// Gets or sets the register.
		/// </summary>
		/// <value>
		/// The register.
		/// </value>
		public int Register { get; set; }
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Event"/> class.
		/// </summary>
		public Event ( )
		{
			Type = EVENT.ENTER;
			Time = DateTime.Now;
			Register = -1;
		}//End Event ( )

		/// <summary>
		/// Initializes a new instance of the <see cref="Event"/> class.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="time">The time.</param>
		/// <param name="registor">The register.</param>
		public Event (EVENT type, DateTime time, int register)
		{
			Type = type;
			Time = time;
			Register = register;
		}//End Event (EVENT, time, int)
		#endregion

		#region Override Methods
		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="obj">An object to compare with this instance.</param>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="obj" /> in the sort order. Zero This instance occurs in the same position in the sort order as <paramref name="obj" />. Greater than zero This instance follows <paramref name="obj" /> in the sort order.
		/// </returns>
		/// <exception cref="ArgumentException">The argument is not an Event Object</exception>
		public int CompareTo (Object obj)
		{
			if (!(obj is Event))
			{
				throw new ArgumentException ("The argument is not an Event Object");
			}//End if statement	
			Event evnt = (Event) obj;
			return (evnt.Time.CompareTo (Time));
		}//End CompareTo (Object)
		/// <summary>
		 /// Returns a <see cref="System.String" /> that represents this instance.
		 /// </summary>
		 /// <returns>
		 /// A <see cref="System.String" /> that represents this instance.
		 /// </returns>
		public override string ToString ( )
		{
			return Time + " " + Register;
		}//End ToString ( )
		#endregion

	}//End Event
}//End Project4
