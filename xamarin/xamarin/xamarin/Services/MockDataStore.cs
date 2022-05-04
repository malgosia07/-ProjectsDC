using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xamarin.Models;

namespace xamarin.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Romance Dawn", Chapters="Chapter: 1-7", Volumes = "Volumes: 1", Episodes = "Episodes 1-3" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Orange Town", Chapters="Chapter: 8-21", Volumes = "Volumes: 1-3", Episodes = "Episodes 4-8" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Syrup Village", Chapters="Chapter: 22-41", Volumes = "Volumes: 3-5", Episodes = "Episodes 9-18" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Baratie", Chapters="Chapter: 42-68", Volumes = "Volumes: 5-8", Episodes = "Episodes 19-30" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Arlong Park", Chapters="Chapter: 69-95", Volumes = "Volumes: 8-11", Episodes = "Episodes 31-44" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Loguetown", Chapters="Chapter: 96-100", Volumes = "Volumes: 11-12", Episodes = "Episodes 45, 48-53" },
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}