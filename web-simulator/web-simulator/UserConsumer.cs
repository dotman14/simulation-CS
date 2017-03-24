using System;
using System.Collections.Generic;
using web_simulator.Users;

namespace web_simulator
{
	public class UserConsumer
	{
		static Random random = new Random();
		const int minNoOfMethods = 0;

		public static void StudentConsumer(Queue<Student> student)
		{
			Student localStudent;
			lock(student)
			{
				var stu = student.Dequeue();
				localStudent = stu;
			}
			Randomize.RunClassMethods(localStudent, random.Next(minNoOfMethods, 4));
		}

		public static void FacultyConsumer(Queue<Faculty> faculty)
		{
			Faculty localFaculty;
			lock (faculty)
			{
				var fac = faculty.Dequeue();
				localFaculty = fac;
			}
			Randomize.RunClassMethods(localFaculty, random.Next(minNoOfMethods, 4));
		}

		public static void AdminConsumer(Queue<Admin> admin)
		{
			Admin localAdmin;
			lock (admin)
			{
				var adm = admin.Dequeue();
				localAdmin = adm;
			}
				Randomize.RunClassMethods(localAdmin, random.Next(minNoOfMethods, 4));
		}
	}
}
