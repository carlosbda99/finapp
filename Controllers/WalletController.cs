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
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        // GET: api/Wallet
        [HttpGet]
        public ActionResult<IList<Wallet>> GetWallets()
        {
            if (_walletService.List == null)
                return NotFound();

            return Ok(_walletService.List());
        }

        // GET: api/Wallet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wallet>> GetWallet(int id)
        {
            if (!_walletService.Exists(id))
                return NotFound();

            Wallet? wallet = await _walletService.Detail(id);

            if (wallet is null)
                return NotFound();

            return Ok(wallet);
        }

        // PUT: api/Wallet/5
        [HttpPut("{id}")]
        public IActionResult PutWallet(int id, Wallet wallet)
        {
            if (!_walletService.Exists(id))
                return NotFound();

            if (id != wallet.Id)
            {
                return BadRequest();
            }

            Wallet walletUpdated = _walletService.Update(wallet);

            return Ok(walletUpdated);
        }

        // POST: api/Wallet
        [HttpPost]
        public async Task<ActionResult<Wallet>> PostWallet(Wallet wallet)
        {
            Wallet walletCreated = await _walletService.Create(wallet);

            return Ok(walletCreated);
        }

        // DELETE: api/Wallet/5
        [HttpDelete("{id}")]
        public IActionResult DeleteWallet(int id)
        {
            if (!_walletService.Exists(id))
                return NotFound();

            _walletService.Delete(id);

            return NoContent();
        }
    }
}
