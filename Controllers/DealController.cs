using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Finapp.Models;
using Finapp.Services.Interfaces;

namespace Finapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealController : ControllerBase
    {
        private readonly IDealService _dealService;

        public DealController(IDealService dealService)
        {
            _dealService = dealService;
        }

        // GET: api/Deal
        [HttpGet]
        public ActionResult<IList<Deal>> GetDeals()
        {
            if (_dealService.List == null)
                return NotFound();

            return Ok(_dealService.List());
        }

        // GET: api/Deal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deal>> GetDeal(int id)
        {
            if (!_dealService.Exists(id))
                return NotFound();

            Deal? deal = await _dealService.Detail(id);

            if (deal is null)
                return NotFound();

            return Ok(deal);
        }

        // PUT: api/Deal/5
        [HttpPut("{id}")]
        public IActionResult PutDeal(int id, Deal deal)
        {
            if (!_dealService.Exists(id))
                return NotFound();

            if (id != deal.Id)
            {
                return BadRequest();
            }

            Deal dealUpdated = _dealService.Update(deal);

            return Ok(dealUpdated);
        }

        // POST: api/Deal
        [HttpPost]
        public async Task<ActionResult<Deal>> PostDeal(Deal deal)
        {
            Deal dealCreated = await _dealService.Create(deal);

            return Ok(dealCreated);
        }

        // DELETE: api/Deal/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDeal(int id)
        {
            if (!_dealService.Exists(id))
                return NotFound();

            _dealService.Delete(id);

            return NoContent();
        }
    }
}
