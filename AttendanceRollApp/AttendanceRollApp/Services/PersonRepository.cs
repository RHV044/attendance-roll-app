using AttendanceRollApp.LocalDBContext;
using AttendanceRollApp.SharedUI.Models;
using AttendanceRollApp.SharedUI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AttendanceRollApp.Services
{
    public class PersonRepository(AttrollDBContext dbContext) : IPersonRepository
    {
        IQueryable<Person> dbPerson = dbContext.Person.Where(x => !x.IsDeleted);
        public async Task AddOrUpdate(Person person)
        {
            dbContext.Person.Update(person);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Person person)
        {
            dbContext.Remove(person);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Person?> GetById(string nationalId) =>
            await dbPerson.SingleOrDefaultAsync(x => x.NationalID == nationalId);

        public async Task<Person?> GetByNfcSerial(string NfcSerialNumber) =>
            await dbPerson
            .SingleOrDefaultAsync(x => x.NfcSerialNumbers.Contains(NfcSerialNumber));

        public async Task<IEnumerable<Person>?> GetMany(IPersonRepository.Filters? filters)
        {
            if (filters?.Genders != null)
                dbPerson = dbPerson
                      .Where(x => filters.Genders.Contains(x.Gender));

            if (filters?.NfcSerialNumbers != null && filters?.NfcSerialNumbers.Count() > 0)
                dbPerson = dbPerson
                    .Where(x => x.NfcSerialNumbers.Intersect(filters.NfcSerialNumbers).Any());

            if (filters?.BirthDateStart != null)
                dbPerson = dbPerson
                    .Where(x => x.BirthDate >= filters.BirthDateStart);

            if (filters?.BirthDateEnd != null)
                dbPerson = dbPerson
                    .Where(x => x.BirthDate <= filters.BirthDateEnd);

            return await dbPerson.ToListAsync();
        }
    }
}
