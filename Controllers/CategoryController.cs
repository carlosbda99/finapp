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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Category
        [HttpGet]
        public ActionResult<IList<Category>> GetCategories()
        {
            if (_categoryService.List == null)
                return NotFound();

            return Ok(_categoryService.List());
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            if (!_categoryService.Exists(id))
                return NotFound();

            Category? category = await _categoryService.Detail(id);

            if (category is null)
                return NotFound();

            return Ok(category);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public IActionResult PutCategory(int id, Category category)
        {
            if (!_categoryService.Exists(id))
                return NotFound();

            if (id != category.Id)
            {
                return BadRequest();
            }

            Category categoryUpdated = _categoryService.Update(category);

            return Ok(categoryUpdated);
        }

        // POST: api/Category
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            Category categoryCreated = await _categoryService.Create(category);

            return Ok(categoryCreated);
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            if (!_categoryService.Exists(id))
                return NotFound();

            _categoryService.Delete(id);

            return NoContent();
        }
    }
}
