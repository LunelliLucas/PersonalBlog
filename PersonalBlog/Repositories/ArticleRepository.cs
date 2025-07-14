using MapsterMapper;
using PersonalBlog.Context;
using PersonalBlog.Models;

namespace PersonalBlog.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(AppDbContext context) : base(context)
        {}

        public IEnumerable<Article> GetOrdainedArticles()
        {
            var articles = GetAll();
            var orderedArticles = articles.OrderByDescending(p => p.PublishDate);
            return orderedArticles;
        }
    }
}
