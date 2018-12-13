using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITYardService
{
    class Program
    {
        static void Main(string[] args)
        {
            var user1 = new User();
            var user2 = new User("Roman", "Derkach");
            var user3 = new User("ajaja", " sjsjjs");
            var repo = new UserRepository();
            repo.Insert(user1);
            repo.Insert(user2);
            repo.Insert(user3);
            repo.DisplayUserInfo();
            var users = repo.All();
            foreach (var user in users)
            {
                user.DisplayInfo();
            }
            Console.ReadKey();
        }
    }




}
