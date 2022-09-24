namespace OutlookObjectives
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using CommonObjectives;
    using LogNET;
    using Newtonsoft.Json;

    /// <summary>
    /// Class to hold the static objects and helper functions.
    /// </summary>
    public static class InTouch
    {
        /// <summary>
        /// The height of the ribbon in pixels.
        /// </summary>
        public const int RibbonHeight = 162;

        /// <summary>
        /// Version number for the WorkItem.
        /// </summary>
        public const int WorkItemVersion = 5;

        private static readonly TaskManager TaskManagerValue = new TaskManager();
        private static Dictionary<int, WorkType> workTypes = new Dictionary<int, WorkType>();

        /// <summary>
        /// Gets the task manager.
        /// </summary>
        public static TaskManager TaskManager
        {
            get { return TaskManagerValue; }
        }

        /// <summary>
        /// Gets or sets the path to the Objectives root folder.
        /// </summary>
        public static string ObjectivesRootFolder { get; set; }

        /// <summary>
        /// Gets or sets the path to the Objectives archive folder.
        /// </summary>
        public static string ObjectivesArchiveFolder { get; set; }

        /// <summary>
        /// Gets or sets the path to the Objectives storage folder.
        /// </summary>
        public static string ObjectivesStorageFolder { get; set; }

        /// <summary>
        /// Value to multiply the DPI X scale.
        /// </summary>
        public static readonly double DpiX = 1;

        /// <summary>
        /// Value to multiply the DPI Y scale.
        /// </summary>
        public static readonly double DpiY = 1;

        /// <summary>
        /// Gets or sets the Dictionary of WorkTypes.
        /// </summary>
        /// <remarks>
        /// These are the default WorkTypes to use if the Objective does not contain a similar WorkType.
        /// </remarks>
        public static Dictionary<int, WorkType> WorkTypes
        {
            get { return workTypes; }
            set { workTypes = value; }
        }

        /// <summary>
        /// Get an Objective object from a path.
        /// </summary>
        /// <param name="path">The path to the objective.</param>
        /// <returns>An objective.</returns>
        public static Objective GetObjective(string path)
        {
            Objective item = new Objective();

            if (path == InTouch.ObjectivesRootFolder + "\\None")
            {
                item.ObjectiveName = "None";
                item.Created = DateTime.Parse("2000-01-01");
                return item;
            }

            if (File.Exists(path + @"\System\Objective.json"))
            {
                string json = File.ReadAllText(path + @"\System\Objective.json");
                item = JsonConvert.DeserializeObject<Objective>(json);
            }
            else
            {
                item.Path = path;
                item.ObjectiveName = item.Path.Substring(path.LastIndexOf(@"\") + 1);
                item.Archived = false;

                DirectoryInfo baseDir = new DirectoryInfo(item.Path);
                item.Created = baseDir.CreationTime;

                // Check for older source file as some projects will probably be backdated.
                foreach (string file in Directory.EnumerateFiles(path + @"\Documents", "*.*", SearchOption.AllDirectories))
                {
                    try
                    {
                        FileInfo info = new FileInfo(file);
                        if (info.CreationTime < item.Created)
                        {
                            item.Created = info.CreationTime;
                        }

                        if (info.LastWriteTime < item.Created)
                        {
                            item.Created = info.LastWriteTime;
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex);
                    }
                }

                foreach (string file in Directory.EnumerateFiles(path + @"\Projects", "*.*", SearchOption.AllDirectories))
                {
                    try
                    {
                        FileInfo info = new FileInfo(file);
                        if (info.CreationTime < item.Created)
                        {
                            item.Created = info.CreationTime;
                        }

                        if (info.LastWriteTime < item.Created)
                        {
                            item.Created = info.LastWriteTime;
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex);
                    }
                }

                string json = JsonConvert.SerializeObject(item, Formatting.Indented);
                File.WriteAllText(path + @"\System\Objective.json", json);
            }

            if (item.Created < DateTime.Parse("2000-01-01"))
            {
                item.Created = DateTime.Parse("2000-01-01");
            }

            return item;
        }

        /// <summary>
        /// Create a new Objective.
        /// </summary>
        /// <param name="objectiveName">The name of the new Objective.</param>
        public static void CreateObjective(string objectiveName)
        {
            string path = ObjectivesRootFolder + @"\" + objectiveName;

            if (Directory.Exists(path))
            {
                throw new Exception("Directory already exists.");
            }
            else
            {
                _ = Directory.CreateDirectory(path);
                _ = Directory.CreateDirectory(path + @"\Documents");
                _ = Directory.CreateDirectory(path + @"\Info");
                _ = Directory.CreateDirectory(path + @"\Media");
                _ = Directory.CreateDirectory(path + @"\Media\Images");
                _ = Directory.CreateDirectory(path + @"\Media\Videos");
                _ = Directory.CreateDirectory(path + @"\Projects");
                _ = Directory.CreateDirectory(path + @"\System");
            }
        }

        /// <summary>
        /// Saves and Objective object to file.
        /// </summary>
        /// <param name="objective">The objective to save.</param>
        public static void SaveObjective(Objective objective)
        {
            string json = JsonConvert.SerializeObject(objective, Formatting.Indented);
            File.WriteAllText(objective.Path + @"\System\Objective.json", json);
        }

        /// <summary>
        /// Gets a formatted time string from an int of minutes.
        /// </summary>
        /// <param name="minutes">The number of minutes.</param>
        /// <returns>A string of the time.</returns>
        public static string GetTimeStringFromMinutes(int minutes)
        {
            string rv;
            int minutesInHour = 60;
            int remainder = minutes % minutesInHour;
            if (minutes < minutesInHour)
            {
                rv = "0:";
            }
            else
            {
                rv = (minutes / minutesInHour).ToString() + ":";
            }

            if (remainder < 10)
            {
                rv += "0" + remainder;
            }
            else
            {
                rv += remainder;
            }

            return rv;
        }

        /// <summary>
        /// Creates a CSS file for use by the reports.
        /// </summary>
        public static void CreateCSS()
        {
            // TODO Remove 2 from path that is used to allow to updating.
            if (!File.Exists(System.IO.Path.GetTempPath() + "page2.css"))
            {
                string css = "html, body {" + "\n";
                css += "background-color: #242424;" + "\n";
                css += "color: #FFFFFF;" + "\n";
                css += "margin: 0px;" + "\n";
                css += "padding: 0px;" + "\n";
                css += "font-family: Verdana;" + "\n";
                css += "font-size: 14px;" + "\n";
                css += "color: #AAAAAA;" + "\n";
                css += "}" + "\n";

                css += ".divWholePage {" + "\n";
                css += "background-color: #383838;" + "\n";
                css += "min-width: 800px;" + "\n";
                css += "max-width: 800px;" + "\n";
                css += "width: 800px;" + "\n";
                css += "margin-top: 0;" + "\n";
                css += "margin-bottom: 0;" + "\n";
                css += "margin-left: auto;" + "\n";
                css += "margin-right: auto;" + "\n";
                css += "padding-top: 0;" + "\n";
                css += "padding-bottom: 0;" + "\n";
                css += "padding-left: 20px;" + "\n";
                css += "padding-right: 20px;" + "\n";
                css += "z-index: 1;" + "\n";
                css += "}" + "\n";
                css += string.Empty + "\n";

                css += "h1 {" + "\n";
                css += "font-family: Calibri;" + "\n";
                css += "font-size: 32px;" + "\n";
                css += "font-weight: normal;" + "\n";
                css += "color: #FFFFFF;" + "\n";
                css += "text-align:center;" + "\n";
                css += "}" + "\n";

                css += "h2 {" + "\n";
                css += "font-family: Calibri;" + "\n";
                css += "font-size: 24px;" + "\n";
                css += "font-weight: normal;" + "\n";
                css += "color: #FFFFFF;" + "\n";
                css += "text-align:left;" + "\n";
                css += "margin-bottom: 5px;" + "\n";
                css += "}" + "\n";

                css += "p {" + "\n";
                css += "font-family: 'Segoe UI';" + "\n";
                css += "font-size: 14px;" + "\n";
                css += "color: #AAAAAA;" + "\n";
                css += "}" + "\n";

                css += "td {" + "\n";
                css += "font-family: Calibri;" + "\n";
                css += "font-size: 14px;" + "\n";
                css += "color: #AAAAAA;" + "\n";
                css += "vertical-align: top;" + "\n";
                css += "}" + "\n";

                css += ".tdHeader {" + "\n";
                css += "font-family: Verdana;" + "\n";
                css += "font-size: 14px;" + "\n";
                css += "color: #FFFFFF;" + "\n";
                css += "}" + "\n";

                File.WriteAllText(System.IO.Path.GetTempPath() + "page.css", css);
            }
        }
    }
}