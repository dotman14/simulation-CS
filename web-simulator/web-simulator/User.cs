using System.Collections.Generic;
using System.Reflection;

namespace web_simulator
{
    public abstract class User
    {
        public abstract void Login();

        public abstract void Logout();

        public List<string> GetMethods(User user)
        {
            var meths = new List<string>();

            var type = user.GetType();
            const BindingFlags flags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public;
            foreach (var method in type.GetMethods(flags))
            {
                if(method.Name != "Login" && method.Name != "Logout" && method.Name != "ToString")
                meths.Add(method.Name);
            }
            return meths;

            //LINQ: return (from method in type.GetMethods(flags) where method.Name != "Login" && method.Name != "Logout" && method.Name != "ToString" select method.Name).ToList();
        }
    }
}
