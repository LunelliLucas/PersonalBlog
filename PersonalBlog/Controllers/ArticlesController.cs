using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Context;
using PersonalBlog.DTOs;
using PersonalBlog.Models;
using PersonalBlog.Repositories;

namespace PersonalBlog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public ArticlesController(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ArticleDTO>> GetAll()
        {
            var articles = _uof.ArticleRepository.GetAll();

            if (articles is null)
                return BadRequest("No Articles can be found..");

            var articlesDTO = _mapper.Map<IEnumerable<ArticleDTO>>(articles);

            return Ok(articlesDTO);
        }

        [HttpGet("Ordained")]
        public ActionResult<IEnumerable<ArticleDTO>> GetAllOrdained()
        {
            var articles = _uof.ArticleRepository.GetOrdainedArticles();

            if (articles is null)
                return BadRequest("No Articles can be found..");

            var articlesDTO = _mapper.Map<IEnumerable<ArticleDTO>>(articles);

            return Ok(articlesDTO);
        }

        [HttpGet("{id:int}")]
        public ActionResult<ArticleDTO> Get([FromQuery] int id)
        {
            var article = _uof.ArticleRepository.Get(a => a.ArticleId == id);

            if (article is null)
                return NotFound("No article was found with the specified Id");

            var articleDTO = _mapper.Map<ArticleDTO>(article);

            return Ok(articleDTO);
        }

        [HttpPost]
        public ActionResult<ArticleDTO> Post(ArticleDTO articleDTO)
        {
            if (articleDTO is null)
                return BadRequest();

            var article = _mapper.Map<Article>(articleDTO);

            var newArticle = _uof.ArticleRepository.Create(article);
            _uof.Commit();

            var newArticleDTO = _mapper.Map<ArticleDTO>(newArticle);

            return Ok(newArticleDTO);
        }

        [HttpPut("{id:int}")]
        public ActionResult<ArticleDTO> Put(int id, ArticleDTO articleDTO)
        {
            if (id != articleDTO.ArticleId)
                return BadRequest("The specified Id does not match with the Article Id!");

            var article = _mapper.Map<Article>(articleDTO);

            var articleUpdated = _uof.ArticleRepository.Update(article);
            _uof.Commit();

            var articleUpdatedDTO = _mapper.Map<ArticleDTO>(articleUpdated);

            return Ok(articleUpdatedDTO);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<ArticleDTO> Delete(int id)
        {
            var article = _uof.ArticleRepository.Get(a => a.ArticleId == id);

            if (article is null)
                return NotFound("No article was found with the specified Id");

            var articleDeleted = _uof.ArticleRepository.Delete(article);
            _uof.Commit();

            var articleDeletedDTO = _mapper.Map<ArticleDTO>(articleDeleted);

            return Ok(articleDeletedDTO);
        }
    }
}
