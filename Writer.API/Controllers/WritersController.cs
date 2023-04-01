using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Writer.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Writer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WritersController : ControllerBase
    {
        private readonly WritersDBContext context;
        //Construcot Injection
        public WritersController(WritersDBContext context)
        {
            this.context = context;
        }


        // GET api/<WritersController>/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Writer>>> WriterList()
        {
            List<Models.Writer> writers = await context.Writers.ToListAsync();
            return writers;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Writer>> GetWriter(int id)
        {
            var writer = await context.Writers.FindAsync(id);//select * from where Writer Id=id
            if (writer == null)
            {
                return NotFound();
            }
            return writer;
        }

        // POST api/<WritersController>
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Models.Writer>>> AddWriter(Models.Writer writer)
        {// instert into Writer() values(writer.Id,writer.name)

            context.Writers.Add(writer);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                ex.Message.ToString();
            }
            return CreatedAtAction("Get Writer", new { id = writer.Id, }, writer);
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<Models.Writer>>> WriterUpdate(Models.Writer writer)
        {
            context.Entry(writer).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Message.ToString();
            }
            return CreatedAtAction("GetWriter", new { id = writer.Id, }, writer);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Writer>> WriterDelete(int id)
        {
            var writer = await context.Writers.FindAsync(id);
            if (writer == null) { return NotFound();}
            context.Writers.Remove(writer);
            await context.SaveChangesAsync();
            return writer;
        }
    }
}
