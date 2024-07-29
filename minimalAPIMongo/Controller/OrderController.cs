using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minimalAPIMongo.Domains;
using minimalAPIMongo.Services;
using MongoDB.Driver;

namespace minimalAPIMongo.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {

        private readonly IMongoCollection<Order> _order;

        public OrderController(MongoDbService mongoDbService)
        {

            _order = mongoDbService.GetDatabase.GetCollection<Order>("order");
        }

        [HttpPost]
        public async Task<ActionResult> Create(Order order)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
