namespace OutlookObjectives
{
    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using LogNET;

    /// <summary>
    /// TaskManager manages the background tasks.
    /// </summary>
    /// <remarks>The TaskManager is used to manage the background tasks that perform 
    /// operations such as moving emails from the Inbox. It provides a queue to store tasks
    /// and executes them one at a time.</remarks>
    public class TaskManager
    {
        private bool taskRunning = false; //Is a task currently running.
        private readonly ConcurrentQueue<Action> backgroundTasks = new ConcurrentQueue<Action>(); //Queue for the tasks.
        public ConcurrentQueue<Action> BackgroundTasks { get => backgroundTasks; }
        private Action currentAction;
        public Action CurrentAction { get => currentAction; set => currentAction = value; }

        private readonly TaskImportData taskImportData;
        private readonly TaskDayReport taskDayReport;
        private readonly TaskWeekReport taskWeekReport;
        private readonly TaskMonthReport taskMonthReport;

        public TaskManager()
        {
            //Create task objects.
            taskImportData = new TaskImportData(TaskFinished);
            taskDayReport = new TaskDayReport(TaskFinished);
            taskWeekReport = new TaskWeekReport(TaskFinished);
            taskMonthReport = new TaskMonthReport(TaskFinished);

            //Configure and start a background thread.
            Thread backgroundThread = new Thread(new ThreadStart(BackgroundProcess))
            {
                Name = "Objectives.TaskManager",
                IsBackground = true,
                Priority = ThreadPriority.Normal
            };
            backgroundThread.SetApartmentState(ApartmentState.STA);
            backgroundThread.Start();
        }

        /// <summary>
        /// Callback for when the current task is finished.
        /// </summary>
        public void TaskFinished()
        {
            taskRunning = false;
        }

        /// <summary>
        /// Main loop for managing tasks.
        /// </summary>
        private void BackgroundProcess()
        {
            bool DoLoop = true; //Keeps the main loop running.
            while (DoLoop)
            {
                Thread.Sleep(5000);
                //Thread.Sleep(60000);
                try
                {
                    if ((!taskRunning) && (!BackgroundTasks.IsEmpty))
                    {
                        taskRunning = true;
                        BackgroundTasks.TryDequeue(out currentAction);
                        Log.Info("TaskManager Starting " + currentAction.Target + "." + currentAction.Method.Name.ToString());
                        currentAction.Invoke();
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                    throw;
                }
            }
        }

        public void EnqueueImportDataTask()
        {
            backgroundTasks.Enqueue(taskImportData.RunTask);
        }

        public void EnqueueDayReportTask()
        {
            backgroundTasks.Enqueue(taskDayReport.RunTask);
        }

        public void EnqueueWeekReportTask()
        {
            backgroundTasks.Enqueue(taskWeekReport.RunTask);
        }

        public void EnqueueMonthReportTask()
        {
            backgroundTasks.Enqueue(taskMonthReport.RunTask);
        }
    }
}