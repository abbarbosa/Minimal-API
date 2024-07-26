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
    
    
    public class ProductController : ControllerBase
    {
        /// <summary>
        /// armazena os dados de acesso da collection
        /// </summary>
        private readonly IMongoCollection <Product>_product;

        /// <summary>
        /// construtor que recebe como dependência o obj da classe MongoDbService
        /// </summary>
        /// <param name="mongoDbService">obj da classe MongoDbService</param>
        public ProductController(MongoDbService mongoDbService)
        {
            //obtem a collection "product"
            _product = mongoDbService.GetDatabase.GetCollection<Product>("product");
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            try
            {
                // Busca todos os produtos da coleção _product.
                var products = await _product.Find(FilterDefinition<Product>.Empty).ToListAsync();
                return Ok(products);
            }
            catch (Exception e)
            {
                //caso dê erro retorna uma mensagem
                return BadRequest(e.Message);
                
            }
        }

        [HttpPost] 
        public async Task<ActionResult> Create(Product product )
        {
            try
            {
                await _product.InsertOneAsync(product);
                return StatusCode(201, product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task <ActionResult> Remove (int id)
        {
            try
            {
              
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        
    }
}
