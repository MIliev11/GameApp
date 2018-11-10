using System;
namespace Games.Model.Data
{
    public class User
    {

        public User()
        { }

        public User(string username)
        {
            Username = username;
        }

        #region -- Public propeties --

        public int? ID { get; set; }

        public string Username { get; set; }

        #endregion

        #region -- Overrides --

        public override bool Equals(object obj)
        {
            return Username == (obj as User).Username;
        }

        #endregion

    }
}
