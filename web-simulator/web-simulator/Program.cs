using System;
using System.Collections.Generic;
using web_simulator.Users;

namespace web_simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            UserContainer uc = new UserContainer();
            uc.GenerateUsers();
        }
    }
}
