using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xamarin.Models;

namespace xamarin.Services
{
    interface IPersonRepository
    {
        Task<bool> AddPersonAsync(Person person);
        Task<bool> UpdatePersonAsync(Person person);
        Task<bool> DeletePersonAsync(int id);
        Task<Person> GetPersonAsync(int id);
        Task<IEnumerable<Person>> GetPersonAsync();


    }
}
