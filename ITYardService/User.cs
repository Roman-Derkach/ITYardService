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
                char ch = _password[i];
                if (Char.IsLower(ch)) //if symbol on password is lowercase then him replace next symbol in alphabet (z->a)
                {
                    if (ch == 'z')
                    {
                        ch = 'a';
                    }
                    else
                    {
                        ch = (char)((int)ch + 1);
                    }
                }
                else
                if (Char.IsNumber(ch)) //if symbol on password is digit then him replace next digit (9->0)
                {
                    if (ch == '9')
                    {
                        ch = '0';
                    }
                    else
                    {
                        ch = (char)((int)ch + 1);
                    }
                }
                else
                if (Char.IsUpper(ch)) //if symbol on password is uppercase then him replace next symbol in alphabet (Z->A)
                {
                    if (ch == 'Z')
                    {
                        ch = 'A';
                    }
                    else
                    {
                        ch = (char)((int)ch + 1);
                    }
                }
                mass[i] = ch;
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
            
            for (int i = 0; i < _password.Length; i++)
            {
                char ch = _password[i];
                if (Char.IsLower(ch))
                {
                    if (ch == 'a')
                    {
                        ch = 'z';
                    }
                    else
                    {
                        ch = (char)((int)ch - 1);
                    }
                }
                else
                 if (Char.IsNumber(ch))
                {
                    if (ch == '0')
                    {
                        ch = '9';
                    }
                    else
                    {
                        ch = (char)((int)ch - 1);
                    }
                }
                else
            if (Char.IsUpper(ch))
                {
                    if (ch == 'A')
                    {
                        ch = 'Z';
                    }
                    else
                    {
                        ch = (char)((int)ch - 1);
                    }
                }
                mass[i] = ch;
            }
            return new string(mass);
        }

    }
}
