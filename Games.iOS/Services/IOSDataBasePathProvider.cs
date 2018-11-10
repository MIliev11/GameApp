using System;
using System.IO;
using Games.iOS.Services;
using Games.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(IOSDataBasePathProvider))]
namespace Games.iOS.Services
{
    public class IOSDataBasePathProvider : IDataBasePathProvider
    {

        public IOSDataBasePathProvider()
        { }

        #region -- IConnectionService implements --

        public string GetDataBasePath(string databaseFileName)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", databaseFileName);
        }

        #endregion

    }
}
