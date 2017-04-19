using System;
using MixMash.Shared.DL.Clients;
using System.IO;
using SQLite;

namespace MixMash.Droid.Data
{
    public class SqlLiteConnectionFactory : ISqlLiteConnectionFactory
    {
        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(GetPath());
        }

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            return new SQLiteAsyncConnection(GetPath());
        }

        private string GetPath()
        {
            var sqliteFilename = "MixMash.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(documentsPath, sqliteFilename);
        }
    }
}