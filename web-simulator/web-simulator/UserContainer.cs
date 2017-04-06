using System;
using System.Collections.Generic;
using System.Threading;
using web_simulator.Users;
using AppConfig = System.Configuration.ConfigurationManager;

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
		public static int StudentCounter;
		public static int FacultyCounter;
		public static int AdminCounter;

		/// <summary>
		/// This method is used to put each method that generates it's respective objects into threads.
		/// </summary>
		public static void GenerateUsers()
		{
			new Thread(GenerateStudent).Start();
			new Thread(GenerateFaculty).Start();
			new Thread(GenerateAdmin).Start();
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
				if(StudentCounter >= Convert.ToInt32(AppConfig.AppSettings["noOfStudent"])) break;

				var interArrivalTime = Randomize.RandomNumber(3, 7);
				timeIncreament += interArrivalTime;
				Thread.Sleep(interArrivalTime * 1000);
				var student = new Student
				{
					InterArrivalTime = timeIncreament,
					Name = "student-" + timeIncreament
				};
				StudentQueue.Enqueue(student);
				StudentCounter++;
				Console.WriteLine(student);
				///TextFile.LogUserCreation(Student.STUDENT_PRODUCER_LOGFILE, student.GetType().Name + " | ", student.Name + " | ", DateTime.Now.ToString("MM/dd/yy HH:mm:ss.ffffff"));
				Sql.LogUserCreation("UserProduce", student.GetType().Name, student.Name, DateTime.Parse(DateTime.Now.ToString("MM/dd/yy HH:mm:ss.ffffff")));
			}
		}

		private static void GenerateFaculty()
		{
			var timeIncreament = 0;
			while (true)
			{
				if(FacultyCounter >= Convert.ToInt32(AppConfig.AppSettings["noOfFaculty"])) break;
				var interArrivalTime = Randomize.RandomNumber(7, 15);
				timeIncreament += interArrivalTime;
				Thread.Sleep(interArrivalTime * 1000);
				var faculty = new Faculty
				{
					InterArrivalTime = timeIncreament,
					Name = "faculty-" + timeIncreament
				};
				FacultyQueue.Enqueue(faculty);
				FacultyCounter++;
				Console.WriteLine(faculty);
				//TextFile.LogUserCreation(Faculty.FACULTY_PRODUCER_LOGFILE, faculty.GetType().Name + " | ", faculty.Name + " | ", DateTime.Now.ToString("MM/dd/yy HH:mm:ss.ffffff"));
				Sql.LogUserCreation("UserProduce", faculty.GetType().Name, faculty.Name, DateTime.Parse(DateTime.Now.ToString("MM/dd/yy HH:mm:ss.ffffff")));
			}
		}

		private static void GenerateAdmin()
		{
			var timeIncreament = 0;
			while (true)
			{
				if(AdminCounter >= Convert.ToInt32(AppConfig.AppSettings["noOfAdmin"])) break;
				var interArrivalTime = Randomize.RandomNumber(13, 13);
				timeIncreament += interArrivalTime;
				Thread.Sleep(interArrivalTime * 1000);
				var admin = new Admin
				{
					InterArrivalTime = timeIncreament,
					Name = "admin-" + timeIncreament
				};
				AdminQueue.Enqueue(admin);
				AdminCounter++;
				Console.WriteLine(admin);
				//TextFile.LogUserCreation(Admin.ADMIN_PRODUCER_LOGFILE, admin.GetType().Name + " | ", admin.Name + " | ", DateTime.Now.ToString("MM/dd/yy HH:mm:ss.ffffff"));
				Sql.LogUserCreation("UserProduce", admin.GetType().Name, admin.Name, DateTime.Parse(DateTime.Now.ToString("MM/dd/yy HH:mm:ss.ffffff")));
			}
		}
	}
}