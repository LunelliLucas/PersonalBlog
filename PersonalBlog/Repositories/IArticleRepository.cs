using PersonalBlog.Models;

namespace PersonalBlog.Repositories
{
    public interface IArticleRepository : IRepository<Article>
    {
        IEnumerable<Article> GetOrdainedArticles();
    }
}
