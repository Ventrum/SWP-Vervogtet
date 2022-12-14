using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Onlineshop.Models;

namespace WebAPI_Server.Controllers
{
    /*  Hier werden die Routen definiert, unter denen
     *      die Daten abgerufen werden können
     */
    [Route("api/[controller]")]
    [ApiController]
    public class OnlineshopController : ControllerBase
    {
        private OnlineshopContext _context;
        /*  2. Teil DI
         *      der dI-Container erkennt am Parameter, die bei ihm registrierte Klasse (OnlineshopContext)
         *      er übergibt an diesen Parameter die von ihm erzeugte Instanz
         */
        public OnlineshopController(OnlineshopContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("articles")]
        public IActionResult AllArticles()
        {
            //  Die Artikelliste nach JSON konvertieren.
            return new JsonResult(this._context.Articles.ToList<Article>());

        }

        /*  URL: http://servername:port(api/shop/article2
         */
        [HttpGet]
        [Route("article/{id}")]
        public IActionResult GetArticleByID(int id)
        {
            return new JsonResult(_context.Articles.Where(a => a.ArticleId == id).First());
        }
        // weiter Methodenä
        // einen neuen Artikel hinzufügen (POST)
        [HttpPost]
        [Route("addarticle")]
        public async Task<IActionResult> AddArticle(Article a)
        {
            if (a == null)
            {
                return new JsonResult(false);
            }
            _context.Articles.Add(a);
            int result = await _context.SaveChangesAsync();
            return new JsonResult(result == 1);

        }
        // einen Artikel löschen (DELTE)
        [HttpDelete]
        [Route("deletearticle/{id}")]
        public IActionResult DeleteArticle(int id)
        {
            return new JsonResult(_context.Articles.Remove(_context.Articles.Where(a => a.ArticleId == id).First()));
        }
        // einen vorhandenen Artikel ändern (PUT)
        [HttpPut]
        [Route("putarticle/{id}")]
        public async Task<bool> PutArticle(Article article)
        {
            try
            {
                _context.Articles.Update(article);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException dbucex) { Console.WriteLine(dbucex.Message); return false; }
            catch (DbUpdateException dbuex) { Console.WriteLine(dbuex.Message); return false; }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
            return true;
        }
    }
}
