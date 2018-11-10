using System;
using System.Collections;
using System.Collections.Generic;
using Games.Model;
using Games.Model.Data;
using Games.Services;
using Xamarin.Forms;

namespace Games.Model
{
    public class UserManager
    {

        private const string FILE_NAME = "users.db";

        private string _path;

        public UserManager()
        {
            _path = DependencyService.Get<IDataBasePathProvider>().GetDataBasePath(FILE_NAME);
        }

        public bool Exist(User userToCheck)
        {
            bool result = false;

            using (var db = new ApplicationContext(_path))
            {
                db.Database.EnsureCreated();
                foreach (User userThatExist in db.Users)
                    if (userToCheck.Equals(userThatExist))
                        result = true;
            }

            return result;
        }

        public void AddUser(User user)
        {
            using (var db = new ApplicationContext(_path))
            {
                db.Database.EnsureCreated();
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public string GetDefaultUsername()
        {
            string result = "Player";
            int counter = 0;

            using (var db = new ApplicationContext(_path))
            {
                db.Database.EnsureCreated();
                foreach (User userThatExist in db.Users)
                    if (userThatExist.Username.Contains(result))
                        counter++;
            }

            return result + " " + counter;
        }


    }
}
