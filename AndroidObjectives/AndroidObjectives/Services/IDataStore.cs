using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndroidObjectives.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataStore<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<bool> AddItemAsync(T item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<bool> UpdateItemAsync(T item);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteItemAsync(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetItemAsync(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="forceRefresh"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
