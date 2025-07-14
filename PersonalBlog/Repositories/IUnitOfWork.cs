using System.Transactions;

namespace PersonalBlog.Repositories
{
    public interface IUnitOfWork
    {
        IArticleRepository ArticleRepository { get; }
        void Commit();
    }
}
