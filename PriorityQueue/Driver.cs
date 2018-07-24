/*
 * Project:			Project 4 - Registration Demo
 * File Name:	    Driver.cs
 * Description:		Driver for the project
 * Course:			CSCI 2210-001 - Data Structures
 * Author:			Chase Hileman, hilemanc@etsu.edu
 * Created:			Thursday, November 9, 2017
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project4
{

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	public class Driver
	{
		private static int NumRegs;         //holds the number of expected registrants
		private static float Hours;         //holds the number of hours
		private static List<Window> Windows = new List<Window>();      //holds the number of windows that will be open
		private static float AvgTime;       //holds the average time to register
		
		/// <summary>
		/// The random
		/// </summary>
		static Random random = new Random ( );
		/// <summary>
		/// Mains the specified arguments.
		/// </summary>
		/// <param name="args">The arguments.</param>
		public static void Main (string [ ] args)
		{
			//TestMethods ( );
			//TestMethodPriority ( );
            /*
			Random random = new Random ( );
			Console.WriteLine ("How many windows");
			int numWindows = Int32.Parse (Console.ReadLine ( ));
			Windows = new List<Window> (numWidows);
			for (int i = 0 ; i < Windows.Capacity ; i++)
			{
				Window window = new Window ( );
				Windows.Add (window);
			}//end for loop
			//tempLines ( );
			//Console.WriteLine (ToStringConsole (Windows));
			//ConventionRegistration conventionRegistration = new ConventionRegistration (Windows, -1000 * Math.Log (random.NextDouble ( ), Math.E));
            */
			Menu ( );
		}//End Main (string [ ])

		/// <summary>
		/// Menus this instance.
		/// </summary>
		/// <exception cref="InvalidCastException">
		/// </exception>
		public static void Menu ( )
		{
			String Line;                                    //gets the user's input
			int Choice = 0;                                 //holds the user's choice
			bool Option = true;                             //checks if the user entered a valid option
			bool Option2 = true;                            //checks to see if the numbers entered are valid


			while (Choice != 5)
			{
				Console.WriteLine ("\n\nRegistration Demo Menu\n");       //displays the menu
				Console.WriteLine ("1. Set the number of Registrants \n" +
									"2. Set the number of hours open \n" +
									"3. Set the number of windows available \n" +
									"4. Set the average duration to register \n" +
									"5. Start Simulation \n" +
									"6. Exit\n");

				Console.WriteLine ("\n\nType the number of your choice");

				Line = Console.ReadLine ( );                    //gets the users choice
				Option = Int32.TryParse (Line, out Choice);    //try to parse the input
				if (Option == true)                           //checks if the value is valid
				{
					if (Choice >= 1 && Choice <= 6)
					{
						switch (Choice)
						{
							case (1):
								Console.WriteLine ("\nPlease enter the amount of registrants expected: ");
								Line = Console.ReadLine ( );
								Option2 = Int32.TryParse (Line, out NumRegs);
								if (Option2 == false)
								{
									Console.WriteLine ("Invalid number input");
									throw new InvalidCastException ( );
									//if the value input is not a valid integer, throws an exception to return to the menu
								}
								break;
							case (2):
								Console.WriteLine ("\nPlease enter the number of hours the windows will be open: ");
								Line = Console.ReadLine ( );
								Option2 = float.TryParse (Line, out Hours);
								if (Option2 == false)
								{
									Console.WriteLine ("Invalid number input");
									throw new InvalidCastException ( );
									//if the value input is not a valid integer, throws an exception to return to the menu
								}
                                
								break;

							case (3):
								Console.WriteLine ("\nPlease enter the number of Windows that will be open: ");
								Line = Console.ReadLine ( );
                                
								Option2 = Int32.TryParse (Line, out int NumWindows);
								if (Option2 == false)
								{
									Console.WriteLine ("Invalid number input");
									throw new InvalidCastException ( );
									//if the value input is not a valid integer, throws an exception to return to the menu
								}
                                Windows = new List<Window>(NumWindows);
                                for (int i = 0; i < Windows.Capacity; i++)
                                {
                                    Window window = new Window();
                                    Windows.Add(window);
                                }//end for loop
                                break;
							case (4):
								Console.WriteLine ("\nPlease enter the average time it takes to register: ");
								Line = Console.ReadLine ( );
								Option2 = float.TryParse (Line, out AvgTime);
								if (Option2 == false)
								{
									Console.WriteLine ("Invalid number input");
									throw new InvalidCastException ( );
									//if the value input is not a valid integer, throws an exception to return to the menu
								}
								break;
							case (5):
                                //ConventionRegistration conventionRegistration = new ConventionRegistration(Windows, NumRegs, AvgTime);
                                Windows = new List<Window>(8);
                                for (int i = 0; i < Windows.Capacity; i++)
                                {
                                    Window window = new Window();
                                    Windows.Add(window); 
                                }
                                ConventionRegistration conventionRegistration = new ConventionRegistration(Windows, 1000, 4.5);
                                break;
                            case (6):
                                Environment.Exit(0);
                                break;
                            default:
                                throw new InvalidCastException();
                            
                        }
					}
				}

			}
		}
		private static void tempLines ( )
		{
			for (int x = 0 ; x < 4 ; x++)
			{
				for (int y = 0 ; y < 4 ; y++)
				{
					Registrant temp = new Registrant (random.Next (1, 9999),
													(Math.Log (1 - random.NextDouble ( )) * (-4.5) + 1.5));
					Windows [y].AddLine (temp);
				}//end for loop
			}//end for loop
		}//End tempLines ( )
		/// <summary>
		 /// Tests the methods.
		 /// </summary>
		private static void TestMethods ( )
		{
			PriorityQueue<int, Event> test = new PriorityQueue<int, Event> ( );
			Random random = new Random ( );
			PriorityQueue<int, Event> Events = new PriorityQueue<int, Event> ( );
			DateTime TimeNow = new DateTime (DateTime.Today.Year,
									DateTime.Today.Month,
									DateTime.Today.Day,
									8, 0, 0);
			DateTime TimeStop = new DateTime (DateTime.Today.Year,
									DateTime.Today.Month,
									DateTime.Today.Day,
									18, 0, 0);
			List<Registrant> list = new List<Registrant> ( );
			TimeSpan time;
			Event evntTemp;
			double amount =  -1000 * Math.Log (random.NextDouble ( ), Math.E);
			for (int i = 0 ; i < (int) amount ; i++)
			{
				Registrant temp = new Registrant (random.Next (1, 9999), (Math.Log (1 - random.NextDouble ( )) * (-4.5) + 1.5));
				Console.WriteLine ("Id: " + temp.Id);
				Console.WriteLine ("Time: " + temp.RegisterTime);
				int nextInt = random.Next (10 * 60);
				time = new TimeSpan (0, nextInt, 0);
				DateTime priority = TimeNow.Add (time);
				Console.WriteLine ("Priority: " + nextInt);
				evntTemp = new Event (EVENT.ENTER, priority, temp.Id);
				Console.WriteLine ("Event: " + evntTemp.Time);
				Events.Enqueue (nextInt, evntTemp);
				temp.Event = evntTemp;
				list.Add (temp);
			}//end for loop
			foreach (var item in Events)
			{
				Console.WriteLine (Events.Peek ( ));
				Events.Dequeue ( );
			}//End foreach statement
		}//End TestPriority ( ) 
		/// <summary>
		/// Tests the methods.
		/// </summary>
		public static void TestMethodPriority ( )
		{
			PriorityQueue<int, Event> test = new PriorityQueue<int, Event> ( );
			Random random = new Random ( );
			PriorityQueue<int, Event> Events = new PriorityQueue<int, Event> ( );
			DateTime TimeNow = new DateTime (DateTime.Today.Year,
									DateTime.Today.Month,
									DateTime.Today.Day,
									8, 0, 0);
			DateTime TimeStop = new DateTime (DateTime.Today.Year,
									DateTime.Today.Month,
									DateTime.Today.Day,
									18, 0, 0);
			List<Registrant> list = new List<Registrant> ( );
			TimeSpan time;
			Event evntTemp;
			Exponential exp = new Exponential (4.5);
			for (int i = 0 ; i < 100 ; i++)
			{
				Registrant temp = new Registrant (random.Next (1, 9999), (Math.Log (1 - random.NextDouble ( )) * (-4.5) + 1.5));
				Console.WriteLine ("Id: " + temp.Id);
				Console.WriteLine ("Time: " + temp.RegisterTime);
				int nextInt = random.Next (10 * 60);
				time = new TimeSpan (0, nextInt, 0);
				DateTime priority = TimeNow.Add (time);
				Console.WriteLine ("Priority: " + nextInt);
				evntTemp = new Event (EVENT.ENTER, priority, temp.Id);
				Console.WriteLine ("Event: " + evntTemp.Time);
				Events.Enqueue (nextInt, evntTemp);
				temp.Event = evntTemp;
				list.Add (temp);
			}//end for loop
			foreach (var item in Events)
			{
				Console.WriteLine (Events.Peek ( ));
				Events.Dequeue ( );
			}//End foreach statement
		}//End TestMethodPriority ( )
		/// <summary>
		/// To the string console.
		/// </summary>
		/// <param name="windows">The windows.</param>
		/// <returns>Formatted Console Screen</returns>
		private static string ToStringConsole (List<Window> windows)
		{
			Console.Clear ( );
			string screen = "";
			string title = Utility.addNewline (1)+
							Utility.addStar(Console.WindowWidth/4) +
							Utility.addStar (Console.WindowWidth / 8) +
							"Waiting-Line-Simulation-Project 4" + 
							Utility.addStar (Console.WindowWidth / 4) +
							Utility.addStar ((Console.WindowWidth / 8)-3) +
							Utility.addNewline(2);
			string [ ] window = new string [windows.Count];
			string [ ] line = new string [0];
			screen += title;
			screen += Utility.addNewline (1);
			screen += "Time: " + "";
			screen += Utility.addNewline (2);
			screen += Utility.addLine (Console.WindowWidth);
			screen += Utility.addNewline (1);
			for (int x = 0 ; x < windows.Count ; x++)
			{
				screen += "W" + x + " [] ";
				line = windows[x].ToString ( ).Split ('|');
				for (int y = 0 ; y < line.Length ; y++)
				{
					if (y == 0)
					{
						line [y] += Utility.addTab(1) + "|";
						screen += line [y];
						continue;
					}//End if statement 
					screen += line [y] + Utility.addTab (1);
				}//End for loop
				screen += Utility.addNewline(1);
				screen += Utility.addLine (Console.WindowWidth);
				screen += Utility.addNewline (1);
			}//End for loop 
			screen += Utility.addNewline (3);
			screen += "Events: " + "" + 
						Utility.addTab (1) + 
						"Arrivals: " + "" + 
						Utility.addTab (1) +
						"Departures: " + "";
			return screen;
		}//End ToStringConsole (List<Window>)
	}//End 
}//End 
