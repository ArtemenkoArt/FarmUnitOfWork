using Farm.Dal;
using Farm.Dal.Models;
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

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_farmRepository.GetAll());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var farm = _farmRepository.Get(id);
            if (farm == null)
            {
                return NotFound();
            }
            return Ok(farm);
        }

        [HttpPost]
        public HttpResponseMessage Create([FromBody]FarmDal farm)
        //public HttpResponseMessage Create(FarmDal farm)
        {
            var errorMassage = new HttpResponseMessage(HttpStatusCode.BadRequest);

            if (farm == null)
            {
                errorMassage.Content = new StringContent("Farm can't be empty!");
                return errorMassage;
            }

            if (!ModelState.IsValid)
            {   
                errorMassage.Content = new StringContent("Name can't be empty!");
                return errorMassage;
            }
            _farmRepository.Create(farm);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] FarmDal farm)
        {
            _farmRepository.Update(farm);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _farmRepository.Delete(id);
            return Ok();
        }

        [HttpGet]
        [Route("search/param")]
        public IHttpActionResult Search(string name)
        {
            var farm = _farmRepository.Find(x => x.Name.ToUpper().Contains(name.ToUpper()));
            return Ok(farm);
        }
    }
}
