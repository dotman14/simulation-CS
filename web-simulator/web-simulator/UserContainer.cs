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
		private static int studentCounter;
		private static int facultyCounter;
		private static int adminCounter;

		public static void GenerateUsers()
		{
			new Thread(GenerateStudent).Start();
			new Thread(GenerateFaculty).Start();
			new Thread(GenerateAdmin).Start();
		}

		private static void GenerateStudent()
		{

			var timeIncreament = 0;
			while (true)
			{
				if(studentCounter >= Convert.ToInt32(AppConfig.AppSettings["noOfStudent"])) break;

				var interArrivalTime = Randomize.RandomNumber(3, 7);
				timeIncreament += interArrivalTime;
				Thread.Sleep(interArrivalTime * 1000);
				var student = new Student
				{
					InterArrivalTime = timeIncreament,
					Name = "student-" + timeIncreament
				};
				StudentQueue.Enqueue(student);
				Console.WriteLine("Enqueue student {0}", student.Name);
				studentCounter++;
				//TextFile.LogUserEnqueue(Student.STUDENT_PRODUCER_LOGFILE, student.GetType().Name + " | ", student.Name + " | ", DateTime.Parse(DateTime.Now.ToString("MM/dd/yy HH:mm:ss.ffffff")));
				Sql.LogUserEnqueue("UserProduce", student.GetType().Name, student.Name, DateTime.Parse(DateTime.Now.ToString("MM/dd/yy HH:mm:ss.ffffff")));
			}
		}

		private static void GenerateFaculty()
		{
			var timeIncreament = 0;
			while (true)
			{
				if(facultyCounter >= Convert.ToInt32(AppConfig.AppSettings["noOfFaculty"])) break;
				var interArrivalTime = Randomize.RandomNumber(7, 15);
				timeIncreament += interArrivalTime;
				Thread.Sleep(interArrivalTime * 1000);
				var faculty = new Faculty
				{
					InterArrivalTime = timeIncreament,
					Name = "faculty-" + timeIncreament
				};
				FacultyQueue.Enqueue(faculty);
				Console.WriteLine("Enqueue student {0}", faculty.Name);
				facultyCounter++;
				//TextFile.LogUserEnqueue(Faculty.FACULTY_PRODUCER_LOGFILE, faculty.GetType().Name + " | ", faculty.Name + " | ", DateTime.Parse(DateTime.Now.ToString("MM/dd/yy HH:mm:ss.ffffff")));
				Sql.LogUserEnqueue("UserProduce", faculty.GetType().Name, faculty.Name, DateTime.Parse(DateTime.Now.ToString("MM/dd/yy HH:mm:ss.ffffff")));
			}
		}

		private static void GenerateAdmin()
		{
			var timeIncreament = 0;
			while (true)
			{
				if(adminCounter >= Convert.ToInt32(AppConfig.AppSettings["noOfAdmin"])) break;
				var interArrivalTime = Randomize.RandomNumber(13, 13);
				timeIncreament += interArrivalTime;
				Thread.Sleep(interArrivalTime * 1000);
				var admin = new Admin
				{
					InterArrivalTime = timeIncreament,
					Name = "admin-" + timeIncreament
				};
				AdminQueue.Enqueue(admin);
				Console.WriteLine("Enqueue student {0}", admin.Name);
				adminCounter++;
				//TextFile.LogUserEnqueue(Admin.ADMIN_PRODUCER_LOGFILE, admin.GetType().Name + " | ", admin.Name + " | ", DateTime.Parse(DateTime.Now.ToString("MM/dd/yy HH:mm:ss.ffffff")));
				Sql.LogUserEnqueue("UserProduce", admin.GetType().Name, admin.Name, DateTime.Parse(DateTime.Now.ToString("MM/dd/yy HH:mm:ss.ffffff")));
			}
		}
	}
}