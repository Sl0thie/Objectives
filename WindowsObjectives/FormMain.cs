namespace WindowsObjectives
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;
    using CommonObjectives;
    using Microsoft.Win32;
    using Newtonsoft.Json;

    /// <summary>
    /// FormMain Form.
    /// </summary>
    public partial class FormMain : Form
    {
        private readonly SystemSleep systemSleep = new SystemSleep();
        private readonly SystemIdle systemIdle = new SystemIdle();
        private readonly SystemUptime systemUptime = new SystemUptime();

        [DllImport("user32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [StructLayout(LayoutKind.Sequential)]
        private struct LASTINPUTINFO
        {
            public static readonly int SizeOf = Marshal.SizeOf(typeof(LASTINPUTINFO));
            [MarshalAs(UnmanagedType.U4)]
            public int CbSize;
            [MarshalAs(UnmanagedType.U4)]
            public uint DwTime;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        /// <summary>
        /// GetWindowThreadProcessId method.
        /// </summary>
        /// <param name="hWnd">The window handle.</param>
        /// <param name="lpdwProcessId">The process Id.</param>
        /// <returns>A uint of the process Id.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        private readonly int idleMin = 300;
        private int lastValue;
        private bool armed = false;
        private bool isIdle = false;
        private bool isAsleep = false;
        private string storageFolder;

        private static int GetLastInputTime()
        {
            int idleTime = 0;
            LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.CbSize = Marshal.SizeOf(lastInputInfo);
            lastInputInfo.DwTime = 0;
            int envTicks = Environment.TickCount;
            if (GetLastInputInfo(ref lastInputInfo))
            {
                int lastInputTick = (int)lastInputInfo.DwTime;

                idleTime = envTicks - lastInputTick;
            }

            return (idleTime > 0) ? (idleTime / 1000) : idleTime;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormMain"/> class.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Visible = false;
            SystemEvents.PowerModeChanged += OnPowerChange;

            storageFolder = (string)Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\InTouch\\Objectives", "StorageFolder", string.Empty);

            systemSleep.ComputerName = Environment.MachineName.ToString();
            systemSleep.UserName = Environment.UserName.ToString();

            systemIdle.ComputerName = Environment.MachineName.ToString();
            systemIdle.UserName = Environment.UserName.ToString();

            systemUptime.ComputerName = Environment.MachineName.ToString();
            systemUptime.UserName = Environment.UserName.ToString();
            systemUptime.Start = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));
        }

        private void OnPowerChange(object s, PowerModeChangedEventArgs e)
        {
            switch (e.Mode)
            {
                case PowerModes.Resume:
                    isAsleep = false;
                    ProcessSleep();

                    break;
                case PowerModes.Suspend:
                    isAsleep = true;
                    systemSleep.Start = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));
                    break;
            }
        }

        private void ProcessSleep()
        {
            systemSleep.Finish = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));

            if (systemSleep.Start != systemSleep.Finish)
            {
                string json = JsonConvert.SerializeObject(systemSleep, Formatting.Indented);
                File.WriteAllText(storageFolder + @"\" + (int)SystemType.Sleep + "-" + Guid.NewGuid().ToString() + ".json", json);
            }

            if (isAsleep)
            {
                systemSleep.Start = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));
            }
        }

        private void ProcessIdle()
        {
            Debug.WriteLine("Process Idle " + storageFolder);

            systemIdle.Finish = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));

            if (systemIdle.Start != systemIdle.Finish)
            {
                string json = JsonConvert.SerializeObject(systemIdle, Formatting.Indented);
                File.WriteAllText(storageFolder + @"\" + (int)SystemType.Idle + "-" + Guid.NewGuid().ToString() + ".json", json);
            }

            if (isIdle)
            {
                systemIdle.Start = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));
            }
        }

        private void ProcessUptime()
        {
            systemUptime.Finish = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));

            if (systemUptime.Start != systemUptime.Finish)
            {
                string json = JsonConvert.SerializeObject(systemUptime, Formatting.Indented);
                File.WriteAllText(storageFolder + @"\" + (int)SystemType.Uptime + "-" + Guid.NewGuid().ToString() + ".json", json);
            }

            systemUptime.ActiveApplications.Clear();
            systemUptime.Start = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isAsleep)
            {
                ProcessSleep();
            }

            if (isIdle)
            {
                ProcessIdle();
            }

            ProcessUptime();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TimerMain_Tick(object sender, EventArgs e)
        {
            int nextValue = GetLastInputTime();
            if (armed)
            {
                if (nextValue < idleMin)
                {
                    armed = false;
                    isIdle = false;
                    ProcessIdle();
                }
                else
                {
                }
            }
            else
            {
                if (nextValue > idleMin)
                {
                    armed = true;
                    isIdle = true;
                    systemIdle.Start = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));
                }
            }

            lastValue = nextValue;

            Debug.WriteLine(nextValue + " " + lastValue);
            Debug.WriteLine("Idle : " + isIdle + " Sleep : " + isAsleep);

            if ((DateTime.Now.Minute == 0) || (DateTime.Now.Minute == 30))
            {
                if (isAsleep)
                {
                    ProcessSleep();
                }

                if (isIdle)
                {
                    ProcessIdle();
                }

                ProcessUptime();
            }

            ActiveApplication app = new ActiveApplication
            {
                Time = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm")),
            };

            try
            {
                IntPtr handle = GetForegroundWindow();
                int intLength = GetWindowTextLength(handle) + 1;
                StringBuilder stringBuilder = new StringBuilder(intLength);
                if (GetWindowText(handle, stringBuilder, intLength) > 0)
                {
                    app.Title = stringBuilder.ToString();
                }

                _ = GetWindowThreadProcessId(handle, out uint procId);
                Process proc = Process.GetProcessById((int)procId);
                app.Application = proc.MainModule.ToString();
            }
            catch (Exception ex)
            {
                app.Application = "Unknown: ";
                app.Title = "Unknown" + ex.Message;
            }

            systemUptime.ActiveApplications.Add(app);
        }

        private string GetCaptionOfActiveWindow()
        {
            string strTitle = string.Empty;
            IntPtr handle = GetForegroundWindow();

            // Obtain the length of the text
            int intLength = GetWindowTextLength(handle) + 1;
            StringBuilder stringBuilder = new StringBuilder(intLength);
            if (GetWindowText(handle, stringBuilder, intLength) > 0)
            {
                strTitle = stringBuilder.ToString();
            }

            return strTitle;
        }
    }
}