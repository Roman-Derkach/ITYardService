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
            var user1 = new User("Roman Derkach", "goodpassword");
            var user2 = new User("test1", "qkskrosc_1A");
            var repo = new UserRepository();
            repo.Insert(user1);
            repo.Insert(user2);
            var users = repo.All();

            repo.DisplayUserInfo(user1._id);
            repo.DisplayUserInfo(user2._id);

            Console.WriteLine();
            foreach (var user in users)
            {
                user.DisplayInfo();
            }
            
            
            Console.ReadKey();
        }
    }




}
