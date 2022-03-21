using ADVLabb4.Models;
using IntresseKlubbenAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntresseKlubbenAPI.Services
{
    public class InterestsRepository : IIntresseKlubben<Interest>
    {
        private AppDbContext _appContext;
        public InterestsRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<Interest> Add(Interest newEntity)
        {
           var result = await _appContext.Interests.AddAsync(newEntity);
           await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Interest> Delete(int id)
        {
           var result = await _appContext.Interests.FirstOrDefaultAsync(p => p.ID == id);
            if(result != null)
            {
                _appContext.Interests.Remove(result);
               await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Interest>> GetAll()
        {

            return await _appContext.Interests.ToListAsync();
        }

        public async Task<Interest> GetSingel(int id)
        {
            return await _appContext.Interests.
                FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task<Interest> Update(Interest Entity)
        {
           var result = await _appContext.Interests.FirstOrDefaultAsync(p=>p.ID == Entity.ID);
            if(result != null)
            {
                result.ID = Entity.ID;
                result.Title = Entity.Title;
                result.Description = Entity.Description;
                result.PersId = Entity.PersId;
                await _appContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
