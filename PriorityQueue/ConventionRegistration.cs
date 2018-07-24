//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 4 - PriorityQueue
//	File Name:		ConventionRegistration.cs
//	Description:	Simulation Waiting Line	
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
using System.Threading;
using System.Threading.Tasks;

namespace Project4
{
	/// <summary>
	/// Handles the Simulation of the Waiting Lines
	/// </summary>
	public class ConventionRegistration
	{
		#region Properties
		List<Window> Windows;
		PriorityQueue<int, Event> Events;
		Random random = new Random ( );
		TimeSpan runevent;
        Exponential Creation = new Exponential();
		List<Registrant> list;
		/// <summary>
		/// Gets or sets the time now.
		/// </summary>
		/// <value>
		/// The time now.
		/// </value>
		public DateTime TimeNow { get; set; }//End TimeNow
		/// <summary>
		/// Gets or sets the time new.
		/// </summary>
		/// <value>
		/// The time new.
		/// </value>
		public DateTime TimeNew { get; set; }//End TimeNew
		/// <summary>
		/// Gets or sets the time depart.
		/// </summary>
		/// <value>
		/// The time depart.
		/// </value>
		public DateTime TimeDepart { get; set; }//End TimeDepart
		/// <summary>
		/// Gets or sets the counter.
		/// </summary>
		/// <value>
		/// The counter.
		/// </value>
		public int Counter { get; set; }//End Counter
		/// <summary>
		/// Gets or sets the arrivals.
		/// </summary>
		/// <value>
		/// The arrivals.
		/// </value>
		public int Arrivals { get; set; }//End Arrivals
		/// <summary>
		/// Gets or sets the departures.
		/// </summary>
		/// <value>
		/// The departures.
		/// </value>
		public int Departures { get; set; }//End Departures
		/// <summary>
		/// Gets or sets the minimum.
		/// </summary>
		/// <value>
		/// The minimum.
		/// </value>
		public int Min { get; set; }//End Min 
		/// <summary>
		/// Gets or sets the maximum.
		/// </summary>
		/// <value>
		/// The maximum.
		/// </value>
		public int Max { get; set; }//End Max
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ConventionRegistration"/> class.
		/// </summary>
		public ConventionRegistration ( )
		{

		}//End ConventionRegistration
		 /// <summary>
		 /// Initializes a new instance of the <see cref="ConventionRegistration"/> class.
		 /// </summary>
		 /// <param name="windows">The windows.</param>
		 /// <param name="distribution">The distribution.</param>
		public ConventionRegistration (List<Window> windows, double distribution, double average)
		{
			TimeNow = new DateTime (DateTime.Today.Year,
									DateTime.Today.Month,
									DateTime.Today.Day,
									8, 0, 0);
			list = new List<Registrant> ( );
			Events = new PriorityQueue<int, Event> ( );
			Windows = windows;
            int Poisson = Creation.Next(distribution);
			//Creates all enter events
			for (int i = 0 ; i < distribution ; i++)
			{
				Registrant temp = new Registrant (random.Next (1, 9999), (1.5 +  Creation.NegExp(average - 1.5)));
				int nextInt = random.Next (10 * 60);
				TimeSpan time = new TimeSpan (0, nextInt, 0);
				DateTime priority = TimeNow.Add (time);
				temp.Event = new Event (EVENT.ENTER, priority, temp.Id);
				list.Add (temp);
				Events.Enqueue (nextInt, temp.getEvents(EVENT.ENTER));
			}//end for loop
			//Display Console Screen
			Console.WriteLine (ToStringConsole (windows));
			Thread.Sleep (500);

			//Set Max to zero
			Min = 0;
			Max = 1;
			//Runs until no event are present
			do
			{
				//Sets the new time
				runevent = new TimeSpan (0, Counter, 0);
				TimeNew = TimeNow.Add (runevent);
				//Check for Min, Max, and Departure times
				for (int i = 0 ; i < Windows.Count ; i++)
				{

					if (Windows [i].SizeOfLine ( ) != 0)
					{
                        
						if (Windows [i].HeadLine ( ).Departure.Year == 0001)
						{
							int counter = (int) Windows [i].HeadLine ( ).RegisterTime * 60;
							runevent = new TimeSpan (0, 0, counter);
							TimeDepart = TimeNew.Add (runevent);
							Registrant tempRegistrant = Windows [i].HeadLine ( );
							int position = list.IndexOf (tempRegistrant);
							tempRegistrant = list [position];
							tempRegistrant.Event = new Event (EVENT.LEAVE, TimeDepart, tempRegistrant.Id);
							Events.Enqueue (counter / 60 + Counter, tempRegistrant.getEvents (EVENT.LEAVE));
						}//End if statement
                        
                    }//End if statement
				}//End for loop
				 //Check for event to the time
				while (Events.Peek ( ).Time <= TimeNew)
				{
					//Grab Registrant
					Event TempEvent = Events.Peek ( );
					Registrant tempRegistrant = new Registrant (TempEvent.Register);
					int position = list.IndexOf (tempRegistrant);
					tempRegistrant = list [position];
					LineCounts (windows);
					//Check if the event was to enter or leave
					if (TempEvent.Type == EVENT.ENTER)
					{
						Arrivals++;
						Events.Dequeue ( );
						Windows [Min].AddLine (tempRegistrant);
					}//End if statement
					else if (TempEvent.Type == EVENT.LEAVE)
					{
						for (int i = 0 ; i < Windows.Count ; i++)
						{
							if (Windows [i].SizeOfLine ( ) != 0)
								{
								if (tempRegistrant == Windows [i].HeadLine ( ))
								{
									windows [i].RemoveLine ( );
									Events.Dequeue ( );
                                    
									Departures++;
								}//End if statement 
							}//End if statement
						}
					}//End if statement
				}//End while statement
				
				//Increase Time
				Counter++;
				Console.WriteLine (ToStringConsole (windows));
				Thread.Sleep (210);
               
			} while (Arrivals - Departures != 0 && Arrivals > 0);//End do-while loop
		}//End ConventionRegistration (List<Window>, double)
		#endregion

		#region Methods
		/// <summary>
		/// Lines the counts.
		/// </summary>
		/// <param name="windows">The windows.</param>
		private void LineCounts (List<Window> windows)//End LineCount (List<Window>)
		{
            int temp = 0;

			for (int i = 0 ; i < windows.Count ; i++)
			{
                if(i==0)
                {
                    temp = windows[i].SizeOfLine();
                    Min = 0;
                    continue;
                }
                if(temp > Windows [i].SizeOfLine ( ))
                {
                    Min = i;
                }
				
				else if (Windows[i].SizeOfLine() > Max)
				{
					Max = windows [i].SizeOfLine ( );
				}//End if statement 
			}//end for loop
		}

		/// <summary>
		/// To the string console.
		/// </summary>
		/// <param name="windows">The windows.</param>
		/// <returns>Formatted Console Screen</returns>
		private string ToStringConsole (List<Window> windows)
		{
			Console.Clear ( );
			string screen = "";
			string title = Utility.addNewline (1) +
							Utility.addStar (Console.WindowWidth / 4) +
							Utility.addStar (Console.WindowWidth / 8) +
							"Waiting-Line-Simulation-Project 4" +
							Utility.addStar (Console.WindowWidth / 4) +
							Utility.addStar ((Console.WindowWidth / 8) - 3) +
							Utility.addNewline (2);
			string [ ] window = new string [windows.Count];
			string [ ] line = new string [0];
			screen += title;
			screen += Utility.addNewline (1);
			screen += "Time: " + TimeNew;
			screen += Utility.addNewline (2);
			screen += Utility.addLine (Console.WindowWidth);
			screen += Utility.addNewline (1);
			for (int x = 0 ; x < windows.Count ; x++)
			{
				screen += "W" + x + " [] ";
				line = windows [x].ToString ( ).Split ('|');
				for (int y = 0 ; y < line.Length ; y++)
				{
					if (y == 0)
					{
						line [y] += Utility.addTab (1) + "|";
						screen += line [y];
						continue;
					}//End if statement 
					screen += line [y] + Utility.addTab (1);
				}//End for loop
				screen += Utility.addNewline (1);
				screen += Utility.addLine (Console.WindowWidth);
				screen += Utility.addNewline (1);
			}//End for loop 
			screen += Utility.addNewline (3);
			screen += "Events: " + (Arrivals + Departures) +
						Utility.addTab (1) +
						"Arrivals: " + Arrivals +
						Utility.addTab (1) +
						"Departures: " + Departures +
                        Utility.addTab (1) +
                        "Max Length: " + Max;
			return screen;
		}//End ToStringConsole (List<Window>) 


        
		#endregion

	}//End ConventionRegistration
}//End Project4
