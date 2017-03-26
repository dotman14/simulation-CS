using System;
using System.Collections.Generic;
using System.Threading;
using web_simulator.Users;

namespace web_simulator
{
	class UserContainer
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

		public void GenerateUsers()
		{
			var studentThread = new Thread(GenerateStudent);
			var facultyThread = new Thread(GenerateFaculty);
			var adminThread   = new Thread(GenerateAdmin);

			studentThread.Start();
			facultyThread.Start();
			adminThread.Start();
		}

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
                Logger.InsertUserGeneration(Student.STUDENT_PRODUCER_LOGFILE, student.GetType().Name + " ", student.Name+" ", DateTime.Now);
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
                Logger.InsertUserGeneration(Faculty.FACULTY_PRODUCER_LOGFILE, faculty.GetType().Name + " ", faculty.Name + " ", DateTime.Now);
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
                Logger.InsertUserGeneration(Admin.ADMIN_PRODUCER_LOGFILE, admin.GetType().Name + " ", admin.Name + " ", DateTime.Now);
            }
		}
	}
}