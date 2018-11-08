using System;
namespace Games.Model.Data
{
    public class User
    {

        public int? ID { get; set; }
        public string Username { get; set; }

        public User()
        {
        }


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
