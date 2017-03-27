﻿using System.Collections.Generic;
using System.Reflection;

namespace web_simulator
{
    /// <summary>
    /// An abstarct class to manage ALL users in this program.
    /// </summary>
    public abstract class User
    {
        public int InterArrivalTime;
        public string Name;

		/// <summary>
		/// Abstract method to be overridden by the extending class
		/// </summary>
        public abstract void Login();

		/// <summary>
		/// Abstract method to be overriden by the extending class
		/// </summary>
        public abstract void Logout();

        public override string ToString()
        {
            return $"Name: {Name}; Time: {InterArrivalTime}";
        }

        /// <summary>
        /// This method returns a List<string> of ALL methods available to any child class that extends THIS parent class.
		/// For this program, we need to remove some methods we do not need to call dynamically ToString, Login and Logout.
		/// Add/Remove as you wish.
        /// </summary>
        /// <param name="user">This method take a User object, which has to be any of the extending classes.</param>
        /// <returns></returns>
        public List<string> GetMethods(User user)
        {
            var methodList = new List<string>();
            var type = user.GetType();
			foreach (var method in type.GetMethods(Randomize.MethodFlags))
            {
                if (method.Name != "Login" && method.Name != "Logout" && method.Name != "ToString")
                    methodList.Add(method.Name);
            }
            return methodList;
            //return (from method in type.GetMethods(flags) where method.Name != "Login" && method.Name != "Logout" && method.Name != "ToString" select method.Name).ToList();
        }
    }
}
