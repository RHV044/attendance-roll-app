using AttendanceRollApp.SharedUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AttendanceRollApp.SharedUI.Models.Person;

namespace AttendanceRollApp.SharedUI.Services.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person?> GetById(string nationalId);
        Task<Person?> GetByNfcSerial(string NfcSerialNumber);
        Task<IEnumerable<Person>?> GetMany(Filters? filters = null);
        Task AddOrUpdate(Person person);

        public class Filters
        {
            public IEnumerable<EGender>? Genders { get; set; }
            public IEnumerable<string>? NfcSerialNumbers { get; set; }
            public DateOnly? BirthDateStart { get; set; }
            public DateOnly? BirthDateEnd { get; set; }
        }
    }
}
