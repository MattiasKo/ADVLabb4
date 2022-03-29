using ADVLabb4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntresseKlubbenAPI.Services
{
    public interface IPerLinksInterest : IIntresseKlubben<Links>
    {
        public Task<Links> UpdateLinksForSpesificPerson(int id, int Intrsid, Links LinkId);
    }
}
