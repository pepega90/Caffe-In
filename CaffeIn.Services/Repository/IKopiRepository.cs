using CaffeIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaffeIn.Services
{
    public interface IKopiRepository
    {
        Kopi FindKopiById(int Id);

        IEnumerable<Kopi> GetAllKopi();

        Kopi AddKopi(Kopi kopi);

        Kopi EditKopi(Kopi kopi);

        void HapusKopi(int Id);

        IQueryable<Kopi> SearchKopi(string kopi);
    }
}
