using System;
using System.IO;
using Games.Droid.Services;
using Games.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidDataBasePathProvider))]
namespace Games.Droid.Services
{
	public class AndroidDataBasePathProvider : IDataBasePathProvider
    {
        public AndroidDataBasePathProvider()
        {
        }

        public string GetDataBasePath(string databaseFileName)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), databaseFileName);
        }
    }
}
