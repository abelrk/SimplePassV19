using System;
using System.Collections.Generic;
using System.Text;

namespace SimplePassV19
{
    public class Profile
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Account { get; set; }

        public Profile(string line)
        {
            var items = line.Split(',');

            Username = items[0];
            Password = items[1];
            Account = items[2];
        }
        public Profile(string account, string username, string password)
        {
            Username = username;
            Password = password;
            Account = account;
        }

        override
        public string ToString()
        {
            return $"{Username},{Password},{Account}";
        }
    }
}
