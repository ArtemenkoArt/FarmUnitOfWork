using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Dal.Models
{
    public class FarmStorageDal
    {
        private static int id = 1;
        private static readonly List<FarmDal> _farmStorage;

        static FarmStorageDal()
        {
            _farmStorage = new List<FarmDal>();
        }

        public FarmStorageDal() { }

    }
}
