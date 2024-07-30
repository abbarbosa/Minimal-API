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


        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            try
            {
                var order = await _order.Find(FilterDefinition<Order>.Empty).ToListAsync();
                return Ok(order);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Order>>> GetById(string id)
        {
            try
            {
                var order = await _order.Find(x => x.Id == id).FirstOrDefaultAsync();
                return Ok(order);
            }
            catch (Exception)
            {

                return NotFound();
            }
        }


        [HttpPost]
        public async Task<ActionResult<Order>> Create(Order order)
        {
            try
            {
                await _order.InsertOneAsync(order);
                return StatusCode(201, order);

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(string id, Order order)
        {
            try
            {
                await _order.ReplaceOneAsync(z => z.Id == id, order);

                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(string id)
        {
            try
            {
                var filter = Builders<Order>.Filter.Eq(x => x.Id, id);
                await _order.DeleteOneAsync(filter);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
