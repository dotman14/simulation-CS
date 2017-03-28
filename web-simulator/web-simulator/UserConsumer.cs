using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using web_simulator.Users;

namespace web_simulator
{
	/// <summary>
	/// Class to manage how objects are dequeued from the queue.
	/// </summary>
	public static class UserConsumer
	{
		/// <summary>
		/// This method is used to put each method that generates it's respective objects into threads.
		/// First we create new Thread() with the method we want to run, then we start the thread.
		/// </summary>
		public static void Consumer()
		{
			var student = new Thread(() =>
			{
				while (true)
				{
					if (UserContainer.StudentQueue.Count != 0)
					{
						StudentConsumer(UserContainer.StudentQueue);
					}
				}
			});

			var faculty = new Thread(() =>
			{
				while (true)
				{
					if (UserContainer.FacultyQueue.Count != 0)
					{
						FacultyConsumer(UserContainer.FacultyQueue);
					}
				}
			});

			var admin = new Thread(() =>
			{
				while (true)
				{
					if (UserContainer.AdminQueue.Count != 0)
					{
						AdminConsumer(UserContainer.AdminQueue);
					}
				}
			});

			student.Start();
			faculty.Start();
			admin.Start();
		}

		/// <summary>
		/// This method is used to Dequeue elements at the top of the queue. We make sure to lock the queue to make sure, we are not enqueuing and dequeuing to the same queue at the same time.
		/// This method records the time of dequeuing and also time after which all random methods has been executed on the dequeued object.
		/// 
		/// Same as FacultyConsumer() and FacultyAdmin()
		/// </summary>
		/// <param name="studentQueue">student queue</param>
		private static void StudentConsumer(Queue<Student> studentQueue)
		{
			var student = new Student();
			lock (studentQueue)
			{
				if (studentQueue.Count != 0)
				{
					student = studentQueue.Dequeue();
					Logger.LogUserCreation(Student.STUDENT_CONSUMER_LOGFILE, student.GetType().Name + " | ", student.Name + " | ", DateTime.Now);
				}
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Randomize.RunClassMethods(student, Randomize.RandomNumber(1, 4));
			stopwatch.Stop();
			Logger.LogUserActivity(Student.STUDENT_METHODTIME_LOGFILE, student.GetType().Name + " | ", student.Name + " | ", stopwatch.Elapsed + " | ", DateTime.Now);
		}

		private static void FacultyConsumer(Queue<Faculty> facultyQueue)
		{
			var faculty = new Faculty();
			lock (facultyQueue)
			{
				if (facultyQueue.Count != 0)
				{
					faculty = facultyQueue.Dequeue();
					Logger.LogUserCreation(Faculty.FACULTY_CONSUMER_LOGFILE, faculty.GetType().Name + " | ", faculty.Name + " | ", DateTime.Now);
				}
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Randomize.RunClassMethods(faculty, Randomize.RandomNumber(1, 4));
			stopwatch.Stop();
			Logger.LogUserActivity(Faculty.FACULTY_METHODTIME_LOGFILE, faculty.GetType().Name + " | ", faculty.Name + " | ", stopwatch.Elapsed + " | ", DateTime.Now);
		}

		private static void AdminConsumer(Queue<Admin> adminQueue)
		{
			var admin = new Admin();
			lock (adminQueue)
			{
				if (adminQueue.Count != 0)
				{
					admin = adminQueue.Dequeue();
					Logger.LogUserCreation(Admin.ADMIN_CONSUMER_LOGFILE, admin.GetType().Name + " | ", admin.Name + " | ", DateTime.Now);
				}
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Randomize.RunClassMethods(admin, Randomize.RandomNumber(1, 4));
			stopwatch.Stop();
			Logger.LogUserActivity(Admin.ADMIN_METHODTIME_LOGFILE, admin.GetType().Name + " | ", admin.Name + " | ", stopwatch.Elapsed + " | ", DateTime.Now);
		}
	}
}