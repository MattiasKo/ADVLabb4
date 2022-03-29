using ADVLabb4.Models;
using IntresseKlubbenAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntresseKlubbenAPI.Services
{
    public class PersonRepository : IIntresseKlubben<Personer>
    {
        private AppDbContext _appContext;
        public PersonRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<Personer> Add(Personer newEntity)
        {
           var result = await _appContext.Personers.AddAsync(newEntity);
           await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Personer> Delete(int id)
        {
           var result = await _appContext.Personers.FirstOrDefaultAsync(p => p.Id == id);
            if(result != null)
            {
                _appContext.Personers.Remove(result);
               await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Personer>> GetAll()
        {

            return await _appContext.Personers.ToListAsync();
        }

        public Task<IEnumerable<Personer>> GetAllMisc(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Personer> GetSingel(int id)
        {
            return await _appContext.Personers.
                FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Personer> Update(Personer Entity)
        {
           var result = await _appContext.Personers.FirstOrDefaultAsync(p=>p.Id == Entity.Id);
            if(result != null)
            {
                result.Name = Entity.Name;
                result.Phone = Entity.Phone;
                result.Email = Entity.Email;
                await _appContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
      

    }
}
