using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_intro.Data;
using Api_intro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_intro.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task< IActionResult> GetAll()
        {

            return Ok(await _context.Categories.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById( [FromRoute] int id)
        {

            var data = await _context.Categories.FindAsync((int)id);

            if (data is null) return NotFound();

            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id is null) return BadRequest();

            var data = await _context.Categories.FindAsync(id);

            if (data is null) return NotFound();

            _context.Remove(data);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _context.Categories.AddAsync(category);

            await _context.SaveChangesAsync();

            return CreatedAtAction("Creat", category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] Category category)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var data = await _context.Categories.FindAsync(id);

            if (data is null) return NotFound();

            data.Name = category.Name;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string searchText)
        {
            return Ok(searchText==null? await _context.Categories.ToListAsync(): await _context.Categories.Where(m => m.Name.Contains(searchText)).ToListAsync());
        }

    }
}

