using IndyBooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IndyBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        private IndyBooksDataContext _db;
        public WriterController(IndyBooksDataContext db)
        {
            _db = db; 
        }
        // GET: api/<WriterController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Writers);
        }

        // GET api/<WriterController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            return Ok(_db.Writers.FirstOrDefault(w=>w.Id==id));
        }

        // POST api/<WriterController>
        [HttpPost]
        public IActionResult Post(Writer writer)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            _db.Add(writer);
            _db.SaveChanges();
            return Accepted();
        }

        // PUT api/<WriterController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, Writer writer)
        {
            writer.Id = id;
            _db.Update(writer);
            _db.SaveChanges();
            return Accepted();
        }

        // DELETE api/<WriterController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Writer writer =_db.Writers.Include(w=>w.Books).FirstOrDefault(w=>w.Id == id);
            if (writer == null) { return BadRequest(); }
            _db.Writers.Remove(writer);
            _db.SaveChanges();
            return Accepted();

        }
        [HttpGet("{id}/bookcount")]
        public IActionResult GetCount(int id)
        {
            Writer writer = _db.Writers.Include(w => w.Books).FirstOrDefault(w => w.Id == id);
            return Ok(new { count = writer.Books.Count() });
        }
    }
}
