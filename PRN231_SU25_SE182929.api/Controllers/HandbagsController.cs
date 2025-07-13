using System.Threading.Tasks;
using HandbagManagementRepository.Models;
using HandbagManagementService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PRN231_SU25_SE182929.api.Controllers
{
    [Route("api/handbags")]
    [ApiController]
    public class HandbagsController : ODataController
    {
        private readonly IHandbagService _handbagService;

        public HandbagsController()
        {
            _handbagService = new HandbagService();
        }

        public class HandbagRq
        {
            public int? BrandId { get; set; }

            public string ModelName { get; set; } = null!;

            public string? Material { get; set; }

            public string? Color { get; set; }

            public decimal? Price { get; set; }

            public int? Stock { get; set; }

            public DateOnly? ReleaseDate { get; set; }
        }


        // GET: api/<HandbagsController>
        [Authorize]
        [HttpGet]
        public async Task<List<Handbag>> Get()
        {
            return await _handbagService.GetAllAsync();
        }

        // GET api/<HandbagsController>/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<Handbag> Get(int id)
        {
            return await _handbagService.GetByIdAsync(id);
        }

        // POST api/<HandbagsController>
        [Authorize(Roles = "1,2")]
        [HttpPost]
        public async Task<int> Post([FromBody] HandbagRq rq)
        {
            var handbag = new Handbag
            {
                HandbagId = await _handbagService.GetMaxIdAsync() + 1,
                BrandId = rq.BrandId,
                ModelName = rq.ModelName,
                Material = rq.Material,
                Color = rq.Color,
                Price = rq.Price,
                Stock = rq.Stock,
                ReleaseDate = rq.ReleaseDate,
            };
            return await _handbagService.CreateAsync(handbag);
        }

        // PUT api/<HandbagsController>/5
        [Authorize(Roles = "1,2")]
        [HttpPut("{id}")]
        public async Task<int> Put(int id, [FromBody] HandbagRq rq)
        {
            var exist = await _handbagService.GetByIdAsync(id);
            var handbag = new Handbag
            {
                HandbagId = id,
                BrandId = rq.BrandId ?? exist.BrandId,
                ModelName = rq.ModelName ?? exist.ModelName,
                Material = rq.Material ?? exist.Material,
                Color = rq.Color ?? exist.Color,
                Price = rq.Price ?? exist.Price,
                Stock = rq.Stock ?? exist.Stock,
                ReleaseDate = rq.ReleaseDate ?? exist.ReleaseDate,
            };
            return await _handbagService.UpdateAsync(handbag);
        }

        // DELETE api/<HandbagsController>/5
        [Authorize(Roles = "1,2")]
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _handbagService.RemoveAsync(id);
        }

        [Authorize]
        [EnableQuery]
        [HttpGet("search")]
        public async Task<IActionResult> GetOData()
        {
            var handbags = await _handbagService.GetAllAsync();
            return Ok(handbags.AsQueryable());
        }
    }
}
