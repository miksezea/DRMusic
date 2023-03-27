using DRMusic.Models;
using DRMusic.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DRMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicRecordsController : ControllerBase
    {
        private MusicRecordsRepository _repository;
        public MusicRecordsController(MusicRecordsRepository repo)
        {
            _repository = repo;
        }
        // GET: api/<MusicRecordsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<MusicRecord>> Get([FromQuery] string? title, [FromQuery] string? artist)
        {
            List<MusicRecord> result = _repository.GetAll(title, artist);
            if(result.Count < 1)
            {
                return NoContent();
            }
            return Ok(result);
        }

        // GET api/<MusicRecordsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MusicRecordsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<MusicRecord> Post([FromBody] MusicRecord value)
        {
            try
            {
                MusicRecord createdRecord = _repository.Add(value);
                return Created($"api/Musicrecords/{createdRecord.Id}", createdRecord);
                //return Created($"/{createdPokemen.Id}", createdPokemen);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<MusicRecordsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MusicRecordsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
