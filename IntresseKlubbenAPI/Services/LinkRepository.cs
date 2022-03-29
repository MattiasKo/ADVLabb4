using ADVLabb4.Models;
using IntresseKlubbenAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntresseKlubbenAPI.Services
{
    public class LinksRepository : IPerLinksInterest
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
        public async Task<IEnumerable<Links>> GetAllMisc(int id)
        {
            var result = await _appContext.Personers.FirstOrDefaultAsync(p => p.Id == id);
            if (result != null)
            {
                var result2 = await _appContext.Personers.Join(_appContext.Linkss,
                Per => Per.Id,
                Lin => Lin.PersID,
                (Per, Lin) => new { Per, Lin }).Where(p => p.Lin.PersID== id).Select(i => i.Lin).ToListAsync();

                return result2;
            }
            return null;
        }
        public async Task<Links> UpdateLinksForSpesificPerson(int id,  int idIntre, Links Lid)
        {
            var result = await _appContext.Personers.FirstOrDefaultAsync(p => p.Id == id);
            var result2 = await _appContext.Interests.FirstOrDefaultAsync(i => i.ID == idIntre);
            if (result != null && result2 != null)
            {
                var newLink = await _appContext.Linkss.AddAsync(new Links 
                {PersID = id, 
                InterestID = idIntre,
                strLink = Lid.strLink });

                await _appContext.SaveChangesAsync();
                return newLink.Entity;
            }
            return null;
        }

    }
}
