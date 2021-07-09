using JohnForteLibrary.Domain;
using JohnForteLibrary.Domain.Repositories;
using JohnForteLibrary.Domain.Specifications;
using JohnForteLibrary.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnForteLibrary.Repositories
{
    public class AuthorRepository : IReadableRepo<Author>
    {
        private JohnForteLibraryDbContext _dbContext;

        public AuthorRepository(JohnForteLibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Author>> FindAll()
        {
            return _dbContext.Authors.ToList();
        }

        public async Task<Author> FindById(int id)
        {
            return await _dbContext.FindAsync<Author>(id);
        }

        public async Task<List<Author>> FindBySpecification(ISpecification<Author> query)
        {
            if (query == null)
                return await FindAll();

            return _dbContext.Authors.Where(query.ToExpression()).ToList();
        }
    }
}
