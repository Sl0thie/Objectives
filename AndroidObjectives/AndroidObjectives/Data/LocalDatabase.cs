namespace AndroidObjectives.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SQLite;
    using AndroidObjectives.Models;

    /// <summary>
    /// 
    /// </summary>
    public class LocalDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<LocalDatabase> Instance = new AsyncLazy<LocalDatabase>(async () =>
        {
            var instance = new LocalDatabase();
            CreateTableResult result = await Database.CreateTableAsync<Objective>();
            return instance;
        });

        /// <summary>
        /// 
        /// </summary>
        public LocalDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<List<Objective>> GetItemsAsync()
        {
            return Database.Table<Objective>().ToListAsync();
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
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Objective> GetItemAsync(string id)
        {
            return Database.Table<Objective>().Where(i => i.ObjectiveName == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Task<int> SaveItemAsync(Objective item)
        {
            if (item.ObjectiveName != "")
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Task<int> DeleteItemAsync(Objective item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
