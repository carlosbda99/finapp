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
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        // GET: api/Card
        [HttpGet]
        public ActionResult<IList<Card>> GetCards()
        {
            if (_cardService.List == null)
                return NotFound();

            return Ok(_cardService.List());
        }

        // GET: api/Card/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> GetCard(int id)
        {
            if (!_cardService.Exists(id))
                return NotFound();

            Card? card = await _cardService.Detail(id);

            if (card is null)
                return NotFound();

            return Ok(card);
        }

        // PUT: api/Card/5
        [HttpPut("{id}")]
        public IActionResult PutCard(int id, Card card)
        {
            if (!_cardService.Exists(id))
                return NotFound();

            if (id != card.Id)
            {
                return BadRequest();
            }

            Card cardUpdated = _cardService.Update(card);

            return Ok(cardUpdated);
        }

        // POST: api/Card
        [HttpPost]
        public async Task<ActionResult<Card>> PostCard(Card card)
        {
            Card cardCreated = await _cardService.Create(card);

            return Ok(cardCreated);
        }

        // DELETE: api/Card/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCard(int id)
        {
            if (!_cardService.Exists(id))
                return NotFound();

            _cardService.Delete(id);

            return NoContent();
        }
    }
}
