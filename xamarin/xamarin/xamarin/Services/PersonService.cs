using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xamarin.Models;

namespace xamarin.Services
{
    public class PersonService : IPersonRepository
    {
        public SQLite.SQLiteAsyncConnection _db;

        public PersonService(string datebasePath)
        {
            _db = new SQLite.SQLiteAsyncConnection(datebasePath);
            _db.CreateTableAsync<Person>().Wait();
        }

        public async Task<bool> AddPersonAsync(Person person)
        {
            if(person.IdPerson > 0)
            {
                await _db.UpdateAsync(person);
            }
            else
            {
                await _db.InsertAsync(person);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeletePersonAsync(int id)
        {
            await _db.DeleteAsync<Person>(id);
            return await Task.FromResult(true);
        }


        public async Task<Person> GetPersonAsync(int id)
        {
            return await _db.Table<Person>().Where(p => p.IdPerson == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Person>> GetPersonAsync()
        {
            return await Task.FromResult(await _db.Table<Person>().ToListAsync());
        }

        public Task<bool> UpdatePersonAsync(Person person)
        {
            throw new NotImplementedException();
        }

       
    }
}
