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
        private FarmStorageDal _farmStorageDal;
    }
}
