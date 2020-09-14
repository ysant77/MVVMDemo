using MVVMDemo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DataAccess
{
    public class Database
    {
        private static Database _databaseInstance = null;
        private static List<User> _users;
        private Database()
        {
            SeedDatabase();
        }

        private void SeedDatabase()
        {
            _users = new List<User>
            {
                new User {Id = 1, Username = "Yatharth", Password = "Yatharth", DateOfBirth = DateTime.Now, IsLoggedIn = false}
            };
        }

        public static Database GetDatabase()
        {
            if (_databaseInstance == null)
                _databaseInstance = new Database();
            return _databaseInstance;
        }

        public User Login(string userName, string password)
        {
            var user = _users.FirstOrDefault(u => u.Username == userName && u.Password == password);
            if(user != null) user.IsLoggedIn = true;
            return user;
        }

        public List<User> GetUsers()
        {
            return _users;
        }
    }
}
