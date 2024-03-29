﻿namespace OutlookObjectives
{
    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using Serilog;

    /// <summary>
    /// TaskManager manages the background tasks.
    /// </summary>
    /// <remarks>The TaskManager is used to manage the background tasks that perform
    /// operations such as moving emails from the Inbox. It provides a queue to store tasks
    /// and executes them one at a time.</remarks>
    public class TaskManager
    {
        private readonly ConcurrentQueue<Action> backgroundTasks = new ConcurrentQueue<Action>(); // Queue for the tasks.
        private readonly TaskImportData taskImportData;
        private readonly TaskDayReport taskDayReport;
        private readonly TaskWeekReport taskWeekReport;
        private readonly TaskMonthReport taskMonthReport;
        private readonly TaskConvertVersion taskConvertVersion;
        private readonly TaskWebSync taskWebSync;
        private bool taskRunning = false; // Is a task currently running.
        private Action currentAction;

        /// <summary>
        /// Gets a queue of Task to be performed.
        /// </summary>
        public ConcurrentQueue<Action> BackgroundTasks
        {
            get
            {
                return backgroundTasks;
            }
        }

        /// <summary>
        /// Gets or sets the current action to be called when finished.
        /// </summary>
        public Action CurrentAction
        {
            get
            {
                return currentAction;
            }

            set
            {
                currentAction = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskManager"/> class.
        /// </summary>
        public TaskManager()
        {
            // Create task objects.
            taskImportData = new TaskImportData(TaskFinished);
            taskDayReport = new TaskDayReport(TaskFinished);
            taskWeekReport = new TaskWeekReport(TaskFinished);
            taskMonthReport = new TaskMonthReport(TaskFinished);
            taskConvertVersion = new TaskConvertVersion(TaskFinished);
            taskWebSync = new TaskWebSync(TaskFinished);

            // Configure and start a background thread.
            Thread backgroundThread = new Thread(new ThreadStart(BackgroundProcess))
            {
                Name = "Objectives.TaskManager",
                IsBackground = true,
                Priority = ThreadPriority.Normal,
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
            bool doLoop = true; // Keeps the main loop running.
            while (doLoop)
            {
                Thread.Sleep(5000);
                try
                {
                    if ((!taskRunning) && (!BackgroundTasks.IsEmpty))
                    {
                        taskRunning = true;
                        _ = BackgroundTasks.TryDequeue(out currentAction);
                        Log.Information("TaskManager Starting " + currentAction.Target + "." + currentAction.Method.Name.ToString());
                        currentAction.Invoke();
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message, ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Enqueues a Import Data Task.
        /// </summary>
        public void EnqueueImportDataTask()
        {
            backgroundTasks.Enqueue(taskImportData.RunTask);
        }

        /// <summary>
        /// Enqueues a Day Report Task.
        /// </summary>
        public void EnqueueDayReportTask()
        {
            backgroundTasks.Enqueue(taskDayReport.RunTask);
        }

        /// <summary>
        /// Enqueues a Week Report Task.
        /// </summary>
        public void EnqueueWeekReportTask()
        {
            backgroundTasks.Enqueue(taskWeekReport.RunTask);
        }

        /// <summary>
        /// Enqueues a Month Report Task.
        /// </summary>
        public void EnqueueMonthReportTask()
        {
            backgroundTasks.Enqueue(taskMonthReport.RunTask);
        }

        /// <summary>
        /// Enqueues a Conversion Task.
        /// </summary>
        public void EnqueueConvertVersionTask()
        {
            backgroundTasks.Enqueue(taskConvertVersion.RunTask);
        }

        /// <summary>
        /// Enqueues a Month Report Task.
        /// </summary>
        public void EnqueueWebSyncTask()
        {
            backgroundTasks.Enqueue(taskWebSync.RunTask);
        }
    }
}