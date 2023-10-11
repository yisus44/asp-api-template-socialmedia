using Core.Entities;
using Core.Interfaces.Persistance;
using Infra.Data;

namespace Infra.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Post>? _postRepository;
        public IGenericRepository<Comment>? _commentRepository;

        private readonly DatabaseContext _databaseContext;

        public UnitOfWork (DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public IGenericRepository<Comment> CommentRepository
        {
            get
            {
                if (_commentRepository == null)
                {
                    _commentRepository = new GenericRepository<Comment>(_databaseContext);
                }
                return _commentRepository;
            }
        }
        
        public IGenericRepository<Post> PostRepository
        {
            get
            {
                if (_postRepository == null)
                {
                    _postRepository = new GenericRepository<Post>(_databaseContext);
                }
                return _postRepository;
            }
        }

        public void Save()
        {
            _databaseContext.SaveChanges();
        }

    }
}
