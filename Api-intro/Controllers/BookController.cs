using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_intro.Data;
using Api_intro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_intro.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly AppDbContext _context;

        public BookController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Books.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            var book = await _context.Books.FindAsync((int)id);

            if (book is null) return NotFound();

            return Ok(book);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id is null) return BadRequest();

            var book = await _context.Books.FindAsync(id);

            if (book is null) return NotFound();

            _context.Remove(book);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Book book)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _context.Books.AddAsync(book);

            await _context.SaveChangesAsync();

            return CreatedAtAction("Create", book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] Book book)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var data = await _context.Books.FindAsync(id);

            if (data is null) return NotFound();

            data.Name = book.Name;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string search)
        {
            return Ok(search == null ? await _context.Books.ToListAsync() : await _context.Books.Where(m => m.Name.Contains(search)).ToListAsync());
        }
    }
}

