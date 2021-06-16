namespace WindowsObjectives
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using Microsoft.Win32;
    using System.Threading;
    using CommonObjectives;
    using Newtonsoft.Json;
    using System.IO;
    using System.Text;

    public partial class FormMain : Form
    {
        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [StructLayout(LayoutKind.Sequential)]
        struct LASTINPUTINFO
        {
            public static readonly int SizeOf = Marshal.SizeOf(typeof(LASTINPUTINFO));
            [MarshalAs(UnmanagedType.U4)]
            public int cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dwTime;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        private int IdleMin = 300;
        private int lastValue;
        private bool armed = false;
        private bool IsIdle = false;
        private bool IsAsleep = false;
        private SystemSleep systemSleep = new SystemSleep();
        private SystemIdle systemIdle = new SystemIdle();
        private SystemUptime systemUptime = new SystemUptime();
        private string StorageFolder;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            SystemEvents.PowerModeChanged += OnPowerChange;

            StorageFolder = (string)Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\InTouch\\Objectives", "StorageFolder", "");

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
                    IsAsleep = false;
                    ProcessSleep();

                    break;
                case PowerModes.Suspend:
                    IsAsleep = true;
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
                File.WriteAllText(StorageFolder + @"\" + (int)SystemType.Sleep + "-" + Guid.NewGuid().ToString() + ".json", json);
            }

            if (IsAsleep)
            {
                systemSleep.Start = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));
            }
        }

        private void ProcessIdle()
        {
            Debug.WriteLine("Process Idle " + StorageFolder);

            systemIdle.Finish = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));

            if (systemIdle.Start != systemIdle.Finish)
            {

                string json = JsonConvert.SerializeObject(systemIdle, Formatting.Indented);
                File.WriteAllText(StorageFolder + @"\" + (int)SystemType.Idle + "-" + Guid.NewGuid().ToString() + ".json", json);
            }

            if (IsIdle)
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
                File.WriteAllText(StorageFolder + @"\" + (int)SystemType.Uptime + "-" + Guid.NewGuid().ToString() + ".json", json);
            }

            systemUptime.ActiveApplications.Clear();
            systemUptime.Start = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsAsleep)
            {
                ProcessSleep();
            }

            if (IsIdle)
            {
                ProcessIdle();
            }

            ProcessUptime();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            int nextValue = GetLastInputTime();
            if (armed)
            {
                if (nextValue < IdleMin)
                {
                    armed = false;
                    IsIdle = false;
                    ProcessIdle();
                }
                else
                {

                }
            }
            else
            {
                if (nextValue > IdleMin)
                {
                    armed = true;
                    IsIdle = true;
                    systemIdle.Start = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));
                }
            }
            lastValue = nextValue;

            Debug.WriteLine(nextValue + " " + lastValue);
            Debug.WriteLine("Idle : " + IsIdle + " Sleep : " + IsAsleep);

            if ((DateTime.Now.Minute == 0) || (DateTime.Now.Minute == 30))
            {
                if (IsAsleep)
                {
                    ProcessSleep();
                }

                if (IsIdle)
                {
                    ProcessIdle();
                }

                ProcessUptime();
            }

            ActiveApplication app = new ActiveApplication();
            app.Time = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));

            try
            {
                IntPtr handle = GetForegroundWindow();
                var intLength = GetWindowTextLength(handle) + 1;
                var stringBuilder = new StringBuilder(intLength);
                if (GetWindowText(handle, stringBuilder, intLength) > 0)
                {
                    app.Title = stringBuilder.ToString();
                }

                uint procId = 0;
                GetWindowThreadProcessId(handle, out procId);
                var proc = Process.GetProcessById((int)procId);
                app.Application = proc.MainModule.ToString();
            }
            catch
            {
                app.Application = "Unknown";
                app.Title = "Unknown";
            }

            systemUptime.ActiveApplications.Add(app);
        }

        static int GetLastInputTime()
        {
            int idleTime = 0;
            LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = Marshal.SizeOf(lastInputInfo);
            lastInputInfo.dwTime = 0;
            int envTicks = Environment.TickCount;
            if (GetLastInputInfo(ref lastInputInfo))
            {
                int lastInputTick = (int)lastInputInfo.dwTime;

                idleTime = envTicks - lastInputTick;
            }
            return ((idleTime > 0) ? (idleTime / 1000) : idleTime);
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private string GetCaptionOfActiveWindow()
        {
            var strTitle = string.Empty;
            var handle = GetForegroundWindow();
            // Obtain the length of the text   
            var intLength = GetWindowTextLength(handle) + 1;
            var stringBuilder = new StringBuilder(intLength);
            if (GetWindowText(handle, stringBuilder, intLength) > 0)
            {
                strTitle = stringBuilder.ToString();
            }
            return strTitle;
        }

    }
}