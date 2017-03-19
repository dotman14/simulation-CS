using System;
using System.Collections.Generic;
using System.Reflection;

namespace web_simulator
{
    public abstract class User
    {
        public abstract void Login();

        public abstract void Logout();

        public List<string> GetMethods(Type type)
        {
            List<string> meths = new List<string>();
            var flags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public;
            foreach (var method in type.GetMethods(flags))
            {
                meths.Add(method.Name);
            }
            return meths;
        }
    }
}
