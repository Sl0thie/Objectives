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
    /// LocalDatabase class.
    /// </summary>
    public class LocalDatabase
    {
        private static SQLiteAsyncConnection database;
        private HubConnection dataHubConnection;
        private IHubProxy dataHubProxy;

        /// <summary>
        /// Singleton instance of the database.
        /// </summary>
        public static readonly AsyncLazy<LocalDatabase> Instance = new AsyncLazy<LocalDatabase>(async () =>
        {
            LocalDatabase instance = new LocalDatabase();

            try
            {
                //await Database.DropTableAsync<AndroidObjectives.Models.Objective>();
                //await Database.DropTableAsync<CommonObjectives.Serial.Objective>();
                //await Database.DropTableAsync<Client>();

                CreateTableResult result = await database.CreateTableAsync<CommonObjectives.Serial.Objective>();
                result = await database.CreateTableAsync<Client>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }

            return instance;
        });

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalDatabase"/> class.
        /// </summary>
        public LocalDatabase()
        {
            database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
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
        /// Drops ans creates the Clients table.
        /// </summary>
        public async void DropCreateClientsAsync()
        {
            _ = await database.DropTableAsync<Client>();
            CreateTableResult result = await database.CreateTableAsync<Client>();
        }

        /// <summary>
        /// Save client object to database.
        /// </summary>
        /// <param name="client">The client object to save to the database.</param>
        /// <returns>A value indicating the success.</returns>
        public Task<int> SaveClientAsync(Client client)
        {
            Debug.WriteLine("LocalDatabase.SaveClientAsync");

            Task<List<Client>> rv = database.QueryAsync<Client>("SELECT * FROM [Client] WHERE [EntryID] = '" + client.EntryID + "'");
            List<Client> clients = rv.Result;

            if (clients.Count == 1)
            {
                return database.UpdateAsync(client, typeof(Client));
            }
            else
            {
                return database.InsertAsync(client, typeof(Client));
            }
        }

        /// <summary>
        /// Calls the server for the client objects.
        /// </summary>
        public void CallForClients()
        {
            Debug.WriteLine("LocalDatabase.CallForClients");

            try
            {
                _ = dataHubProxy.Invoke("SendClients");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Gets the clients.
        /// </summary>
        /// <returns>A table of client objects.</returns>
        public Task<List<Client>> GetClientsAsync()
        {
            Debug.WriteLine("LocalDatabase.GetClientsAsync");

            try
            {
                return database.Table<Client>().ToListAsync();
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
        /// Calls the server for objectives.
        /// </summary>
        public void CallForObjectives()
        {
            Debug.WriteLine("LocalDatabase.CallForObjectives");

            try
            {
                _ = dataHubProxy.Invoke("SendObjectives");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Get objectives.
        /// </summary>
        /// <returns>A table of objectives.</returns>
        public Task<List<CommonObjectives.Serial.Objective>> GetObjectivesAsync()
        {
            Debug.WriteLine("LocalDatabase.GetObjectivesAsync");

            try
            {
                return database.Table<CommonObjectives.Serial.Objective>().OrderBy(x => x.Archived).ThenBy(x => x.ObjectiveName).ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Get items not done.
        /// </summary>
        /// <returns>Returns a table of objects not done.</returns>
        public Task<List<CommonObjectives.Serial.Objective>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<CommonObjectives.Serial.Objective>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        /// <summary>
        /// Get item.
        /// </summary>
        /// <param name="objectiveName">The objective name to get.</param>
        /// <returns>The objective item.</returns>
        public Task<CommonObjectives.Serial.Objective> GetItemAsync(string objectiveName)
        {
            return database.Table<CommonObjectives.Serial.Objective>().Where(i => i.ObjectiveName == objectiveName).FirstOrDefaultAsync();
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
                Task<List<CommonObjectives.Serial.Objective>> rv = database.QueryAsync<CommonObjectives.Serial.Objective>("SELECT * FROM [Objective] WHERE [ObjectiveName] = '" + objective.ObjectiveName + "'");
                List<CommonObjectives.Serial.Objective> objectives = rv.Result;

                if (objectives.Count == 1)
                {
                    return database.UpdateAsync(objective);
                }
                else
                {
                    return database.InsertAsync(objective);
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
            return database.DeleteAsync(item);
        }

        #endregion

    }
}
