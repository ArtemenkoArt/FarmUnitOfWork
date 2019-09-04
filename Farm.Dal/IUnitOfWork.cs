using Farm.Dal.Models;

namespace Farm.Dal
{
    public interface IUnitOfWork
    {
        IRepository<FarmDal> Farms { get; }

        void Save();
    }
}