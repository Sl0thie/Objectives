namespace AndroidObjectives.Data
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using AndroidObjectives.Models;
    using CommonObjectives;
    using Microsoft.AspNet.SignalR.Client;
    using Newtonsoft.Json;
    using SQLite;

    /// <summary>
    ///
    /// </summary>
    public class LocalDatabase
    {
        private static SQLiteAsyncConnection Database;
        private HubConnection dataHubConnection;
        private IHubProxy dataHubProxy;

        /// <summary>
        ///
        /// </summary>
        public static readonly AsyncLazy<LocalDatabase> Instance = new AsyncLazy<LocalDatabase>(async () =>
        {
            var instance = new LocalDatabase();

            try
            {
                //await Database.DropTableAsync<AndroidObjectives.Models.Objective>();
                //await Database.DropTableAsync<CommonObjectives.Serial.Objective>();
                //await Database.DropTableAsync<Client>();

                CreateTableResult result = await Database.CreateTableAsync<CommonObjectives.Serial.Objective>();
                result = await Database.CreateTableAsync<Client>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }

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

                dataHubProxy.On<string>("SaveClient", (json) =>
                {
                    Client newClient = JsonConvert.DeserializeObject<Client>(json);
                    SaveClientAsync(newClient);
                });

                dataHubProxy.On("DropCreateClient", () =>
                {
                    DropCreateClientsAsync();
                });

                dataHubProxy.On<string>("SaveObjective", (json) =>
                {
                    CommonObjectives.Serial.Objective newObjective = JsonConvert.DeserializeObject<CommonObjectives.Serial.Objective>(json);
                    SaveObjectiveAsync(newObjective);
                });

                dataHubProxy.On<string>("ReceiveMessage", (message) =>
                {
                    ReceiveMessage(message);
                });

                await dataHubConnection.Start();

                CallForObjectives();
                CallForClients();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }

            Debug.WriteLine("LocalDatabase.IinitializeSignalR Finished");
        }

        #endregion

        private void ReceiveMessage(string message)
        {
            Debug.WriteLine("ReceiveMessage: " + message);
        }

        #region Clients

        /// <summary>
        ///
        /// </summary>
        public async void DropCreateClientsAsync()
        {
            await Database.DropTableAsync<Client>();
            CreateTableResult result = await Database.CreateTableAsync<Client>();
        }

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
        public void CallForObjectives()
        {
            Debug.WriteLine("LocalDatabase.CallForObjectives");

            try
            {
                dataHubProxy.Invoke("SendObjectives");
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
        public Task<List<CommonObjectives.Serial.Objective>> GetObjectivesAsync()
        {
            Debug.WriteLine("LocalDatabase.GetObjectivesAsync");

            try
            {
                return Database.Table<CommonObjectives.Serial.Objective>().OrderBy(x => x.Archived).ThenBy(x => x.ObjectiveName).ToListAsync();
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
        public Task<List<CommonObjectives.Serial.Objective>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<CommonObjectives.Serial.Objective>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objectiveName"></param>
        /// <returns></returns>
        public Task<CommonObjectives.Serial.Objective> GetItemAsync(string objectiveName)
        {
            return Database.Table<CommonObjectives.Serial.Objective>().Where(i => i.ObjectiveName == objectiveName).FirstOrDefaultAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objective"></param>
        /// <returns></returns>
        public Task<int> SaveObjectiveAsync(CommonObjectives.Serial.Objective objective)
        {
            Debug.WriteLine("LocalDatabase.SaveObjectiveAsync");

            try
            {
                Task<List<CommonObjectives.Serial.Objective>> rv = Database.QueryAsync<CommonObjectives.Serial.Objective>("SELECT * FROM [Objective] WHERE [ObjectiveName] = '" + objective.ObjectiveName + "'");
                List<CommonObjectives.Serial.Objective> objectives = rv.Result;

                if (objectives.Count == 1)
                {
                    return Database.UpdateAsync(objective);
                }
                else
                {
                    return Database.InsertAsync(objective);
                }
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
        /// <param name="item"></param>
        /// <returns></returns>
        public Task<int> DeleteObjectiveAsync(CommonObjectives.Serial.Objective item)
        {
            return Database.DeleteAsync(item);
        }

        #endregion

    }
}
