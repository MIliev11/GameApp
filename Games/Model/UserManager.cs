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

        private string _fileName = "database.db";

        public UserManager()
        {
        }

        public bool Exist(User userToCheck)
        {
            bool result = false;

            using(var db = new ApplicationContext(DependencyService.Get<IDataBasePathProvider>().GetDataBasePath(_fileName)))
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
            using (var db = new ApplicationContext(DependencyService.Get<IDataBasePathProvider>().GetDataBasePath(_fileName)))
            {
                db.Database.EnsureCreated();
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public string GetDefaultUsername() {
            return "Player";
        }


    }
}
