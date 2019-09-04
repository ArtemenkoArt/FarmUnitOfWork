using Farm.Dal;
using Farm.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Farm.Api.Controllers
{
    public class FarmController : ApiController
    {
        private IRepository<FarmDal> _farmRepository;

        public FarmController()
        {
            var unitOfWork = new FarmUnitOfWork(new FarmDataContext());
            _farmRepository = unitOfWork.Farms;
        }
    }
}
