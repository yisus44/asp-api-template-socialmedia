using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Persistance
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Post> PostRepository { get; }
        public IGenericRepository<Comment> CommentRepository { get; }

        public void Save();
    }
}
