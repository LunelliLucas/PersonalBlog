
using PersonalBlog.Context;
using PersonalBlog.Models;

namespace PersonalBlog.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public AppDbContext _context;
        public IArticleRepository _articleRepo;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IArticleRepository ArticleRepository
        {
            get
            {
                return _articleRepo = _articleRepo ?? new ArticleRepository(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
