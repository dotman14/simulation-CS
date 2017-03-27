using System.Collections.Generic;
using System.Reflection;

namespace web_simulator
{
    /// <summary>
    ///
    /// </summary>
    public abstract class User
    {
        public int InterArrivalTime;
        public string Name;

        public abstract void Login();

        public abstract void Logout();

        public override string ToString()
        {
            return $"Name: {Name}; Time: {InterArrivalTime}";
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<string> GetMethods(User user)
        {
            var methodList = new List<string>();

            var type = user.GetType();
            const BindingFlags flags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public;
            foreach (var method in type.GetMethods(flags))
            {
                if (method.Name != "Login" && method.Name != "Logout" && method.Name != "ToString")
                    methodList.Add(method.Name);
            }
            return methodList;

            //return (from method in type.GetMethods(flags) where method.Name != "Login" && method.Name != "Logout" && method.Name != "ToString" select method.Name).ToList();
        }
    }
}
