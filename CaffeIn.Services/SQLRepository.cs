using CaffeIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaffeIn.Services
{
    public class SQLRepository : IKopiRepository
    {
        private readonly AppDbContext context;

        public SQLRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Kopi AddKopi(Kopi kopi)
        {
            context.Kopis.Add(kopi);
            context.SaveChanges();
            return kopi;
        }

        public Kopi EditKopi(Kopi kopi)
        {
            context.Update(kopi);
            context.SaveChanges();
            return kopi;
        }

        public Kopi FindKopiById(int Id)
        {
            return context.Kopis.Find(Id);
        }

        public IEnumerable<Kopi> GetAllKopi()
        {
            return context.Kopis;
        }

        public void HapusKopi(int Id)
        {
            Kopi deletedKopi = context.Kopis.Find(Id);

            if(deletedKopi != null)
            {
                context.Kopis.Remove(deletedKopi);
                context.SaveChanges();
            }
        }

        public IQueryable<Kopi> SearchKopi(string kopi)
        {
            if(string.IsNullOrEmpty(kopi))
            {
                return context.Kopis;
            }

            return context.Kopis.Where(e => e.NamaKopi.Contains(kopi) ||
            e.Deskripsi.Contains(kopi));
        }
    }
}
