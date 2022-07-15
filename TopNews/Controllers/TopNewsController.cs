using Microsoft.AspNetCore.Mvc;

namespace TopNews.Controllers
{
    [Route("[controller]")]
    public class TopNewsController : Controller
    {
        private readonly ILogger<TopNewsController> _logger;
        private readonly TopNewsDbContext _dbContext;

        public TopNewsController(ILogger<TopNewsController> logger,
        TopNewsDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet("list")]
        public IActionResult Index()
        {
            return Ok(_dbContext.TopNewsItem.Take(5).ToList());
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTopNewsItem([FromBody]TopNewsItem item)
        {
            _dbContext.TopNewsItem.Add(item);
            var rowCount = await _dbContext.SaveChangesAsync();
            if (rowCount > 0)
            {
                return Ok(new {Id=item.Id});
            }
            return BadRequest();
        }
    
        [HttpGet("get")]
        public async Task<IActionResult> GetTopNewsItem(int id)
        {
            var topNewsitem = await _dbContext.TopNewsItem.FindAsync(id);
            if (topNewsitem != null)
            {
                return Ok(topNewsitem);
            }
            return NotFound();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteTopNewsItem(int id)
        {
            var itemToDelete = await _dbContext.TopNewsItem.FindAsync(id);
            if (itemToDelete == null)
            {
                return NotFound();
            }

            _dbContext.TopNewsItem.Remove(itemToDelete);
            int rowsModified = await _dbContext.SaveChangesAsync();
            if (rowsModified > 0)
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}