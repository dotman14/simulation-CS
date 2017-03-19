using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using web_simulator.Users;

namespace web_simulator
{
    class Program
    {
        static List<string> ShowMethods(Type type)
        {
            List<string> meths = new List<string>();
            var flags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public;
            foreach (var method in type.GetMethods(flags))
            {
                meths.Add(method.Name);
            }
            return meths;
        }

        static void Main(string[] args)
        {
            Student stu = new Student();
            Console.WriteLine("Student");
            foreach (var me in ShowMethods(typeof (Student)))
            {
                Console.WriteLine(me);
            }
            //Console.WriteLine();
            //Console.WriteLine("Admin");
            //foreach (var me in ShowMethods(typeof(Admin)))
            //{
            //    Console.WriteLine(me);
            //}

            //Console.WriteLine();
            //Console.WriteLine("Faculty");
            //foreach (var me in ShowMethods(typeof(Faculty)))
            //{
            //    Console.WriteLine(me);
            //}
        }
    }
}
