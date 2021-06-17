namespace OutlookObjectives
{
    using CommonObjectives;
    using LogNET;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Class to hold the static objects and helper functions.
    /// </summary>
    public static class InTouch
    {

        private static readonly TaskManager taskManager = new TaskManager();

        public static TaskManager TaskManager
        {
            get { return taskManager; }
        }

        public static int RibbonHeight { get; } = 162;
        public static string ObjectivesRootFolder { get; set; }
        public static string ObjectivesArchiveFolder { get; set; }
        public static string ObjectivesStorageFolder { get; set; }

        public static readonly double DpiX = 1;
        public static readonly double DpiY = 1;


        private static Dictionary<int, WorkType> workTypes = new Dictionary<int, WorkType>();
        public static Dictionary<int, WorkType> WorkTypes
        {
            get { return workTypes; }
            set { workTypes = value; }
        }


        public static int WorkItemVersion = 5;



        /// <summary>
        /// Get an Objective object from a path.
        /// </summary>
        /// <param name="path">The path to the objective.</param>
        /// <returns></returns>
        public static Objective GetObjective(string path)
        {
            Objective item = new Objective();

            if (path == InTouch.ObjectivesRootFolder + "\\None")
            {
                item.ObjectiveName = "None";
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
                foreach (var file in Directory.EnumerateFiles(path + @"\Documents", "*.*", SearchOption.AllDirectories))
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

                foreach (var file in Directory.EnumerateFiles(path + @"\Projects", "*.*", SearchOption.AllDirectories))
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
                Directory.CreateDirectory(path);
                Directory.CreateDirectory(path + @"\Documents");
                Directory.CreateDirectory(path + @"\Info");
                Directory.CreateDirectory(path + @"\Media");
                Directory.CreateDirectory(path + @"\Media\Images");
                Directory.CreateDirectory(path + @"\Media\Videos");
                Directory.CreateDirectory(path + @"\Projects");
                Directory.CreateDirectory(path + @"\System");
            }
        }

        /// <summary>
        /// Saves and Objective object to file.
        /// </summary>
        /// <param name="objective"></param>
        public static void SaveObjective(Objective objective)
        {
            string json = JsonConvert.SerializeObject(objective, Formatting.Indented);
            File.WriteAllText(objective.Path + @"\System\Objective.json", json);
        }

        /// <summary>
        /// Gets a formatted time string from an int of minutes.
        /// </summary>
        /// <param name="minutes">The number of minutes.</param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        public static void CreateCSS()
        {
            //TODO Remove 2 from path that is used to allow to updating.
            if (!File.Exists(System.IO.Path.GetTempPath() + "page2.css"))
            {
                string CSS = "html, body {" + "\n";
                //CSS += "height: 100%;" + "\n";
                CSS += "background-color: #242424;" + "\n";
                CSS += "color: #FFFFFF;" + "\n";
                CSS += "margin: 0px;" + "\n";
                CSS += "padding: 0px;" + "\n";
                CSS += "font-family: Verdana;" + "\n";
                CSS += "font-size: 14px;" + "\n";
                CSS += "color: #AAAAAA;" + "\n";
                CSS += "}" + "\n";

                CSS += ".divWholePage {" + "\n";
                //CSS += "height: 100%;" + "\n";
                CSS += "background-color: #383838;" + "\n";
                CSS += "min-width: 800px;" + "\n";
                CSS += "max-width: 800px;" + "\n";
                CSS += "width: 800px;" + "\n";
                CSS += "margin-top: 0;" + "\n";
                CSS += "margin-bottom: 0;" + "\n";
                CSS += "margin-left: auto;" + "\n";
                CSS += "margin-right: auto;" + "\n";
                CSS += "padding-top: 0;" + "\n";
                CSS += "padding-bottom: 0;" + "\n";
                CSS += "padding-left: 20px;" + "\n";
                CSS += "padding-right: 20px;" + "\n";
                CSS += "z-index: 1;" + "\n";
                CSS += "}" + "\n";
                CSS += "" + "\n";

                CSS += "h1 {" + "\n";
                CSS += "font-family: Calibri;" + "\n";
                CSS += "font-size: 32px;" + "\n";
                CSS += "font-weight: normal;" + "\n";
                CSS += "color: #FFFFFF;" + "\n";
                CSS += "text-align:center;" + "\n";
                CSS += "}" + "\n";

                CSS += "h2 {" + "\n";
                CSS += "font-family: Calibri;" + "\n";
                CSS += "font-size: 24px;" + "\n";
                CSS += "font-weight: normal;" + "\n";
                CSS += "color: #FFFFFF;" + "\n";
                CSS += "text-align:left;" + "\n";
                CSS += "margin-bottom: 5px;" + "\n";
                CSS += "}" + "\n";

                CSS += "p {" + "\n";
                CSS += "font-family: 'Segoe UI';" + "\n";
                CSS += "font-size: 14px;" + "\n";
                CSS += "color: #AAAAAA;" + "\n";
                CSS += "}" + "\n";

                File.WriteAllText(System.IO.Path.GetTempPath() + "page.css", CSS);
            }
        }
    }
}