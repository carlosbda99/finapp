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
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;

        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        // GET: api/Bill
        [HttpGet]
        public ActionResult<IList<Bill>> GetBills()
        {
            if (_billService.List == null)
                return NotFound();

            return Ok(_billService.List());
        }

        // GET: api/Bill/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bill>> GetBill(int id)
        {
            if (!_billService.Exists(id))
                return NotFound();

            Bill? bill = await _billService.Detail(id);

            if (bill is null)
                return NotFound();

            return Ok(bill);
        }

        // PUT: api/Bill/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutBill(int id, Bill bill)
        {
            if (!_billService.Exists(id))
                return NotFound();

            if (id != bill.Id)
            {
                return BadRequest();
            }

            Bill billUpdated = _billService.Update(bill);

            return Ok(billUpdated);
        }

        // POST: api/Bill
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bill>> PostBill(Bill bill)
        {
            Bill billCreated = await _billService.Create(bill);

            return Ok(billCreated);
        }

        // DELETE: api/Bill/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBill(int id)
        {
            if (!_billService.Exists(id))
                return NotFound();

            _billService.Delete(id);

            return NoContent();
        }
    }
}
