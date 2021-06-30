namespace AndroidObjectives.Data
{
    
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SQLite;
    using AndroidObjectives.Models;
    using System.Diagnostics;
    using System;
    using Microsoft.AspNet.SignalR.Client;
    using Newtonsoft.Json;

    /// <summary>
    /// 
    /// </summary>
    public class LocalDatabase
    {
        static SQLiteAsyncConnection Database;
        private HubConnection dataHubConnection;
        private IHubProxy dataHubProxy;

        /// <summary>
        /// 
        /// </summary>
        public static readonly AsyncLazy<LocalDatabase> Instance = new AsyncLazy<LocalDatabase>(async () =>
        {
            var instance = new LocalDatabase();
            // await Database.DropTableAsync<Objective>();
            // await Database.DropTableAsync<Client>();
            CreateTableResult result = await Database.CreateTableAsync<Objective>();
            result = await Database.CreateTableAsync<Client>();

            return instance;
        });

        /// <summary>
        /// 
        /// </summary>
        public LocalDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            IinitializeSignalR();
        }

        #region SignalR

        private async void IinitializeSignalR()
        {
            Debug.WriteLine("LocalDatabase.IinitializeSignalR");

            try
            {
                dataHubConnection = new HubConnection("http://www.intacomputers.com/");
                dataHubProxy = dataHubConnection.CreateHubProxy("DataHub");
                dataHubProxy.On<string>("ClientRecord", (json) =>
                {
                    Debug.WriteLine("ClientRecord");
                    Client newClient = JsonConvert.DeserializeObject<Client>(json);
                    SaveClientAsync(newClient);
                });

                //chatHubProxy.On<string, string>("recieveMessage", (n, m) => {
                //    Messages.Add(string.Format("{0} says: {1}", n, m));
                //});

                await dataHubConnection.Start();
                CallForClients();
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }
        }

        #endregion

        #region Clients

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public Task<int> SaveClientAsync(Client client)
        {
            Debug.WriteLine("LocalDatabase.SaveClientAsync");

            Task<List<Client>> rv = Database.QueryAsync<Client>("SELECT * FROM [Client] WHERE [EntryID] = '" + client.EntryID + "'");
            List<Client> clients = rv.Result;

            if (clients.Count == 1)
            {
                return Database.UpdateAsync(client, typeof(Client));

            }
            else
            {
                return Database.InsertAsync(client, typeof(Client));

            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void CallForClients()
        {
            Debug.WriteLine("LocalDatabase.CallForClients");

            try
            {
                dataHubProxy.Invoke("SendClients");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<List<Client>> GetClientsAsync()
        {
            Debug.WriteLine("LocalDatabase.GetClientsAsync");

            try
            {
                return Database.Table<Client>().ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

        #endregion

        #region Objectives

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<List<Objective>> GetObjectivesAsync()
        {
            Debug.WriteLine("LocalDatabase.GetObjectivesAsync");

            try
            {
                return Database.Table<Objective>().ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<List<Objective>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<Objective>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectiveName"></param>
        /// <returns></returns>
        public Task<Objective> GetItemAsync(string objectiveName)
        {
            return Database.Table<Objective>().Where(i => i.ObjectiveName == objectiveName).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objective"></param>
        /// <returns></returns>
        public Task<int> SaveObjectiveAsync(Objective objective)
        {
            Task<List<Objective>> rv = Database.QueryAsync<Objective>("SELECT * FROM [Objective] WHERE [ObjectiveName] = '" + objective.ObjectiveName + "'");
            List<Objective> objectives = rv.Result;

            if(objectives.Count == 1)
            {
                return Database.UpdateAsync(objective);
            }
            else
            {
                return Database.InsertAsync(objective);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Task<int> DeleteObjectiveAsync(Objective item)
        {
            return Database.DeleteAsync(item);
        }

        #endregion

        
    }
}
