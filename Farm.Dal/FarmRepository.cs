using Farm.Dal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Farm.Dal
{
    public class FarmRepository : IRepository<FarmDal>
    {
        private FarmDataContext db;

        public FarmRepository(FarmDataContext context)
        {
            this.db = context;
        }

        //
        public FarmDal Get(int id)
        {
            return db.Farms.FirstOrDefault(x => x.Id == id);
        }

        //
        public IEnumerable<FarmDal> GetAll()
        {
            return db.Farms.ToList();
        }

        //
        public IEnumerable<FarmDal> Find(Func<FarmDal, bool> predicate)
        {
            return db.Farms.Where(predicate).ToList();
        }

        //
        public void Create(FarmDal item)
        {
            db.Farms.Add(item);
            db.SaveChanges();
        }

        //
        public void Update(FarmDal item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }

        //
        public void Delete(int id)
        {
            FarmDal farm = db.Farms.FirstOrDefault(p => p.Id == id);
            if (farm != null)
            {
                db.Farms.Remove(farm);
                db.SaveChanges();
            }
        }
    }
}
