using System;
using System.Collections.Generic;
using System.Threading;
using web_simulator.Users;

namespace web_simulator
{
	static class UserContainer
	{
		static UserContainer()
		{
			StudentQueue = new Queue<Student>();
			FacultyQueue = new Queue<Faculty>();
			AdminQueue = new Queue<Admin>();
		}

		public static readonly Queue<Student> StudentQueue;
		public static readonly Queue<Faculty> FacultyQueue;
		public static readonly Queue<Admin> AdminQueue;

		/// <summary>
		/// This method is used to put each method that generates it's respective objects into threds.
		/// First we create new Thread() with the method we want to run, then we start the thread.
		/// </summary>
		public static void GenerateUsers()
		{
			var student = new Thread(GenerateStudent);
			var faculty = new Thread(GenerateFaculty);
			var admin = new Thread(GenerateAdmin);

			student.Start();
			faculty.Start();
			admin.Start();
		}

		/// <summary>
		/// This method generates a new Student object and adds it to the end of a queue. Same apply for GenerateFaculty() and GenerateAdmin().
		/// We control the rate at which the objects are inserted using a random number selector, then Sleep the function for that number of seconds.
		/// Then we log this information into the respective Student text file.
		/// </summary>
		private static void GenerateStudent()
		{
			var timeIncreament = 0;
			while (true)
			{
				//var average = Enumerable.Range(3, 5).ToList().Average();
				int interArrivalTime = Randomize.RandomNumber(3, 7);
				timeIncreament += interArrivalTime;
				Thread.Sleep(interArrivalTime * 1000);
				var student = new Student
				{
					InterArrivalTime = timeIncreament,
					Name = "student-" + timeIncreament
				};
				StudentQueue.Enqueue(student);
				Console.WriteLine(student);
				Logger.LogUserCreation(Student.STUDENT_PRODUCER_LOGFILE, student.GetType().Name + " | ", student.Name + " | ", DateTime.Now);
			}
		}

		private static void GenerateFaculty()
		{
			var timeIncreament = 0;
			while (true)
			{
				//var average = Enumerable.Range(7, 9).ToList().Average();
				int interArrivalTime = Randomize.RandomNumber(7, 15);
				timeIncreament += interArrivalTime;
				Thread.Sleep(interArrivalTime * 1000);
				var faculty = new Faculty
				{
					InterArrivalTime = timeIncreament,
					Name = "faculty-" + timeIncreament
				};
				FacultyQueue.Enqueue(faculty);
				Console.WriteLine(faculty);
				Logger.LogUserCreation(Faculty.FACULTY_PRODUCER_LOGFILE, faculty.GetType().Name + " | ", faculty.Name + " | ", DateTime.Now);
			}
		}

		private static void GenerateAdmin()
		{
			var timeIncreament = 0;
			while (true)
			{
				//var average = Enumerable.Range(13, 13).ToList().Average();
				int interArrivalTime = Randomize.RandomNumber(13, 13);
				timeIncreament += interArrivalTime;
				Thread.Sleep(interArrivalTime * 1000);
				var admin = new Admin
				{
					InterArrivalTime = timeIncreament,
					Name = "admin-" + timeIncreament
				};
				AdminQueue.Enqueue(admin);
				Console.WriteLine(admin);
				Logger.LogUserCreation(Admin.ADMIN_PRODUCER_LOGFILE, admin.GetType().Name + " | ", admin.Name + " | ", DateTime.Now);
			}
		}
	}
}