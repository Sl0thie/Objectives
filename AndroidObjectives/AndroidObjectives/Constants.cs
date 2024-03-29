﻿namespace AndroidObjectives
{
    using System;
    using System.IO;

    /// <summary>
    /// Constants class manages global constants.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Database file name.
        /// </summary>
        public const string DatabaseFilename = "TodoSQLite.db3";

        /// <summary>
        /// SQLite flags.
        /// </summary>
        public const SQLite.SQLiteOpenFlags Flags =

            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |

            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |

            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        /// <summary>
        /// Gets the database path.
        /// </summary>
        public static string DatabasePath
        {
            get
            {
                string basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}