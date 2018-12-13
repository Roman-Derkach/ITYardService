using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITYardService
{
    public class User
    {
        public Guid _id;
        public string _username;
        public string _password { get; set; }
        public string _hashingPassword;
        public User()
        {
            this._id = Guid.NewGuid();
        }

        public User(string username, string password) : this()
        {
            _username = username;
            _password = password;
            EncryptPassword();
        }

        public void EncryptPassword()
        {
            char[] mass = new char[_password.Length];
            _hashingPassword = "";
            for(int i = 0; i < _password.Length; i++)
            {
                mass[i] =(char)((int)_password[i] + (int)_username[i % _username.Length]);
            }
            _hashingPassword = new string(mass);
        }

        public void UpdatePassword(string password)
        {
            _password = password;
            EncryptPassword();
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Username - {_username} and password - {_password}");
        }

        public string DecryptPassword()
        {
            char[] mass = new char[_password.Length];
            for(int i = 0; i < _password.Length; i++)
            {
                mass[i] = (char)((int)_hashingPassword[i] - (int)_username[i % _username.Length]);
            }

            return new string(mass);
        }

    }
}
