using Article.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Article.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly ArticlesDBContext context;
        //Constructor Injetcion 
        public ArticlesController(ArticlesDBContext context)
        {
            this.context = context;
        }
        // GET: api/<WritersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Article>>> ArticleList()
        {
            List<Models.Article> articleList = await context.Articles.ToListAsync();
            return articleList;

        }
        // GET api/<ArticlesController>/5

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Article>> GetArticle(int id)
        {
            //select * from where Article Id= id
            var article = await context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            return article;
        }

        [HttpGet("{WriterId}")]
        public async Task<ActionResult<IEnumerable<Models.Article>>> GetArticlesByWriterId(int WriterId)
        {
            //select * from where Article Id= id
            List<Models.Article> articleList = await context.Articles.Where(i => i.WriterId == WriterId).ToListAsync();

            return articleList;
        }

        // POST api/<ArticlessController>
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Models.Article>>> AddArticle(Models.Article article)
        {   //insert into Article() values(article.Id, article.name)
            context.Articles.Add(article);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return CreatedAtAction("GetArticle", new { id = article.Id }, article);
        }

        // PUT api/<ArticlesController>/5
        [HttpPut]
        public async Task<ActionResult<IEnumerable<Models.Article>>> ArticleUpdate(Models.Article article)
        {
            //update Article set Id=article.Id,Name=article.Name
            context.Entry(article).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Message.ToString();
            }
            return CreatedAtAction("GetWriter", new { id = article.Id }, article);
        }

        // DELETE api/<ArticlesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Article>> ArticleDelete(int id)
        {
            //delete from Article where Id=id
            var article = await context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            context.Articles.Remove(article);
            await context.SaveChangesAsync();
            return article;
        }
    }
}
