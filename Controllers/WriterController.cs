using IndyBooks.Models;
using Microsoft.AspNetCore.Mvc;
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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WriterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WriterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
