using System;
using System.IO;

namespace AndroidObjectives
{
    /// <summary>
    /// 
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// 
        /// </summary>
        public const string DatabaseFilename = "TodoSQLite.db3";

        /// <summary>
        /// 
        /// </summary>
        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        /// <summary>
        /// 
        /// </summary>
        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}