using Farm.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Dal
{
    public class FarmUnitOfWork : IDisposable
    {
        private FarmDataContext db;
        private bool disposed;
        private IRepository<FarmDal> _farmRepository;
        //private Dictionary<string, object> _repositories;

        public FarmUnitOfWork(FarmDataContext context)
        {
            this.db = context;
        }

        public FarmUnitOfWork()
        {
            this.db = new FarmDataContext();
        }

        public IRepository<FarmDal> Farms
        {
            get
            {
                if (_farmRepository == null)
                {
                    _farmRepository = new FarmRepository(db);
                }
                return _farmRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            disposed = true;
        }
    }
}
