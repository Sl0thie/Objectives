namespace OutlookObjectives
{
    using CommonObjectives;
    using LogNET;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms.DataVisualization.Charting;
    using Outlook = Microsoft.Office.Interop.Outlook;

    /// <summary>
    /// 
    /// </summary>
    public class TaskWebSync
    {
        private readonly Action CallBack;

        ServiceReference1.ObjectivesSoapClient soap;

        /// <summary>
        /// 
        /// </summary>
        public TaskWebSync(Action callBack)
        {
            CallBack = callBack;
        }

        /// <summary>
        /// Creates a thread to run the Task.
        /// </summary>
        public void RunTask()
        {
            Thread BackgroundThread = new Thread(new ThreadStart(BackgroundProcess))
            {
                Name = "Objectives.TaskWebSync",
                IsBackground = true,
                Priority = ThreadPriority.Normal
            };
            BackgroundThread.SetApartmentState(ApartmentState.STA);
            BackgroundThread.Start();
        }

        /// <summary>
        /// The starting point for the new process.
        /// </summary>
        private void BackgroundProcess()
        {
            SyncClients();
            SyncObjectives();
            CallBack?.Invoke();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SyncClients()
        {
            ServiceReference1.SetClientListRequest request = new ServiceReference1.SetClientListRequest();
            ServiceReference1.SetClientListResponse response = new ServiceReference1.SetClientListResponse();

            soap = new ServiceReference1.ObjectivesSoapClient();
            ServiceReference1.ClientList clientList = new ServiceReference1.ClientList();

            ServiceReference1.Client client1 = new ServiceReference1.Client();
            client1.EntryId = "sdggfd0s987g0sdf0sdfguyds098fguds0ugds0u0sd98gud0fud08ud8fud08d8ud8fugds8gusd098usdgusd0vb80908jva09ja09jva09vjf09sd8vj";
            client1.FirstName = "Client";
            client1.LastName = "Name 1";
            client1.Title = "Mr";

            ServiceReference1.Client client2 = new ServiceReference1.Client();
            client2.EntryId = "sdggfd0s987g0sdf0sdfguyds098fguds0ugds0u0gud0fud08ud8fud08d8ud8fugds8gus456365356sdgusd0vb80908jva09ja09jva09vjf09sd8vk";
            client2.FirstName = "Client";
            client2.LastName = "Name 2";
            client2.Title = "Mrs";

            ServiceReference1.Client client3 = new ServiceReference1.Client();
            client3.EntryId = "sdggfd0s987g0sdf0sdfguyds098fguds0ugds0u0gud0fud08ud8fud08d8ud8fugds8gus456365356sdgusd0vb80908jva09ja09jva09vjf09sd8vl";
            client3.FirstName = "Client";
            client3.LastName = "Name 3";
            client3.Title = "Ms";

            ServiceReference1.Client[] clients = new ServiceReference1.Client[3];

            clients[0] = client1;
            clients[1] = client2;
            clients[2] = client3;

            clientList.Count = 3;
            clientList.Clients = clients;

            try
            {
                soap.SetClientList(clientList);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void SyncObjectives()
        {
            soap = new ServiceReference1.ObjectivesSoapClient();

            foreach (var path in Directory.EnumerateDirectories(InTouch.ObjectivesRootFolder, "*", SearchOption.TopDirectoryOnly))
            {
                Objective objective = InTouch.GetObjective(path);
                objective.Archived = false;
                ServiceReference1.Objective obj = new ServiceReference1.Objective();
                obj.Archived = objective.Archived;
                obj.Created = objective.Created;
                obj.ObjectiveName = objective.ObjectiveName;

                Log.Info("ObjectiveName: " + obj.ObjectiveName);
                Log.Info("DateTime: " + obj.Created);

                soap.SaveObjective(obj);
            }

            foreach (var path in Directory.EnumerateDirectories(InTouch.ObjectivesArchiveFolder, "*", SearchOption.TopDirectoryOnly))
            {
                Objective objective = InTouch.GetObjective(path);
                objective.Archived = true;
                ServiceReference1.Objective obj = new ServiceReference1.Objective();
                obj.Archived = objective.Archived;
                obj.Created = objective.Created;
                obj.ObjectiveName = objective.ObjectiveName;

                Log.Info("ObjectiveName: " + obj.ObjectiveName);
                Log.Info("DateTime: " + obj.Created);

                soap.SaveObjective(obj);
            }
        }

    }
}