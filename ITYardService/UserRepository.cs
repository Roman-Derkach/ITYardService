using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITYardService
{
    public class UserRepository
    {
        public static Dictionary<Guid, User> _users = new Dictionary<Guid, User>();

        public User[] All()
        {
            return _users.Values.ToArray();
        }

        public void Insert(User user)
        {
            _users.Add(user._id, user);
        }

        public User GetById(Guid id)
        {
            return _users[id];
        }

        public bool Update(Guid id,string newPassword)
        {
            User user = null;
            if (_users.TryGetValue(id, out user))
            {
                _users[id].UpdatePassword(newPassword);
                return true;
            }
            return false;
        }

        public bool Delete(Guid id)
        {
            return _users.Remove(id);
        }

        public void DisplayUserInfo()
        {
            foreach (var user in _users)
            {
                Console.WriteLine($"Username - {user.Value._username}, decrypt password - {user.Value._hashingPassword}");
            }
        }

    }
}
