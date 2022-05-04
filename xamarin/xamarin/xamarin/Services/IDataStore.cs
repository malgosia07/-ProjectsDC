using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace xamarin.Services
{
    public interface IDataStore<Item>
    {
        Task<bool> AddItemAsync(Item item);
        Task<bool> UpdateItemAsync(Item item);
        Task<bool> DeleteItemAsync(string id);
        Task<Item> GetItemAsync(string id);
        Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false);
    }
}
