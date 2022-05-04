using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace xamarin.Models
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int IdPerson { get; set; }
        public string NamePerson { get; set; }
        public string AddressPerson { get; set; }
        public string ImagePerson { get; set; }


    }
}
