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
	/// Holds Register information for program
	/// </summary>
	/// <seealso cref="System.IEquatable{Project4.Registrant}//End " />
	public class Registrant : IEquatable<Registrant>
	{
		#region Properties
		/// <summary>
		/// The events
		/// </summary>
		private List<Event> _events = new List<Event> ( );
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		public int Id { get; set; }//End Id
		/// <summary>
		/// Gets or sets the register time.
		/// </summary>
		/// <value>
		/// The register time.
		/// </value>
		public double RegisterTime { get; set; }//End RegisterTime 
		/// <summary>
		/// Gets or sets the arrival.
		/// </summary>
		/// <value>
		/// The arrival.
		/// </value>
		public DateTime Arrival { get; set; }//End Arrival
		/// <summary>
		/// Gets or sets the departure.
		/// </summary>
		/// <value>
		/// The departure.
		/// </value>
		public DateTime Departure { get; set; }//End Departure 
		/// <summary>
		/// Sets the event.
		/// </summary>
		/// <value>
		/// The event.
		/// </value>
		public Event Event
		{
			set
			{
				switch (value.Type)
				{
					case EVENT.ENTER:
						Arrival = new DateTime (value.Time.Year,
												value.Time.Month,
												value.Time.Day,
												value.Time.Hour,
												value.Time.Minute,
												value.Time.Second);
						break;
					case EVENT.LEAVE:
						Departure = new DateTime (value.Time.Year,
												value.Time.Month,
												value.Time.Day,
												value.Time.Hour,
												value.Time.Minute,
												value.Time.Second); ;
						break;
					default:
						break;
				}//End switch statement
				_events.Add (value);
			}//End set		
		}//End Event
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Registrant"/> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="registrant">The registrant.</param>
		public Registrant (int id, double registrant)
		{
			Id = id;
			RegisterTime = Math.Round (registrant,2);
			_events = new List<Event> ( );
		}//End  Registrant (int, double)
		 /// <summary>
		 /// Initializes a new instance of the <see cref="Registrant"/> class.
		 /// </summary>
		 /// <param name="id">The identifier.</param>
		public Registrant (int id)
		{
			this.Id = id;
		}//End Registrant (int) 
		 /// <summary>
		 /// Initializes a new instance of the <see cref="Registrant"/> class.
		 /// </summary>
		 /// <param name="copy">The copy.</param>
		public Registrant (Registrant copy)
		{
			RegisterTime = copy.RegisterTime;
			Arrival = copy.Arrival;
			Departure = copy.Departure;
		}//End Registrant (Registrant)
		#endregion

		#region Methods
		/// <summary>
		/// Gets the events.
		/// </summary>
		/// <returns></returns>
		public Event getEvents (EVENT type)
		{
			int position = -1;
			switch (type)
			{
				case EVENT.ENTER:
					position = 0;
					break;
				case EVENT.LEAVE:
					position = 1;
					break;
				default:
					break;
			}//End switch statement
			return _events[position];
		}//End getEvents (EVENT)
		#endregion

		#region operator
		/// <summary>
		/// Implements the operator ==.
		/// </summary>
		/// <param name="registrant1">The registrant1.</param>
		/// <param name="registrant2">The registrant2.</param>
		/// <returns>
		/// The result of the operator.
		/// </returns>
		public static bool operator == (Registrant registrant1, Registrant registrant2)
		{
			return EqualityComparer<Registrant>.Default.Equals (registrant1, registrant2);
		}//End operator ==
		 /// <summary>
		 /// Implements the operator !=.
		 /// </summary>
		 /// <param name="registrant1">The registrant1.</param>
		 /// <param name="registrant2">The registrant2.</param>
		 /// <returns>
		 /// The result of the operator.
		 /// </returns>
		public static bool operator != (Registrant registrant1, Registrant registrant2)
		{
			return !(registrant1 == registrant2);
		}//End operator !=
		#endregion

		#region Overridden Methods
		/// <summary>
		/// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
		/// <returns>
		///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		public override bool Equals (object obj)
		{
			return Equals (obj as Registrant);
		}//End Equals (object)
		 /// <summary>
		 /// Indicates whether the current object is equal to another object of the same type.
		 /// </summary>
		 /// <param name="other">An object to compare with this object.</param>
		 /// <returns>
		 ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
		 /// </returns>
		public bool Equals (Registrant other)
		{
			return other != null &&
				   Id == other.Id;
		}//End Equals (Registrant)
		 /// <summary>
		 /// Returns a hash code for this instance.
		 /// </summary>
		 /// <returns>
		 /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
		 /// </returns>
		public override int GetHashCode ( )
		{
			return Id;
		}//End GetHashCode ( )
		 /// <summary>
		 /// Returns a <see cref="System.String" /> that represents this instance.
		 /// </summary>
		 /// <returns>
		 /// A <see cref="System.String" /> that represents this instance.
		 /// </returns>
		public override string ToString ( )
		{
			return Id.ToString ( );
		}//End ToString ( )
		#endregion

	}//End Registrant 
}//End Project4 
