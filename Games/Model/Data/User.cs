using System;
namespace Games.Model.Data
{
    public class User
    {

        public User()
        { }

        #region -- Private helpers --

        public int? ID { get; set; }

        public string Username { get; set; }

        #endregion

        public User(string Username)
        {
            this.Username = Username;
        }

        public override bool Equals(object obj)
        {
            return Username == (obj as User).Username;
        }

    }
}
