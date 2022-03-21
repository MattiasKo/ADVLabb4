using ADVLabb4.Models;
using IntresseKlubbenAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntresseKlubbenAPI.Services
{
    public class LinksRepository : IIntresseKlubben<Links>
    {
        private AppDbContext _appContext;
        public LinksRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<Links> Add(Links newEntity)
        {
           var result = await _appContext.Linkss.AddAsync(newEntity);
           await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Links> Delete(int id)
        {
           var result = await _appContext.Linkss.FirstOrDefaultAsync(p => p.ID == id);
            if(result != null)
            {
                _appContext.Linkss.Remove(result);
               await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Links>> GetAll()
        {

            return await _appContext.Linkss.ToListAsync();
        }

        public async Task<Links> GetSingel(int id)
        {
            return await _appContext.Linkss.
                FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task<Links> Update(Links Entity)
        {
           var result = await _appContext.Linkss.FirstOrDefaultAsync(p=>p.ID == Entity.ID);
            if(result != null)
            {
                result.strLink = Entity.strLink;
                result.PersID = Entity.PersID;

                await _appContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
