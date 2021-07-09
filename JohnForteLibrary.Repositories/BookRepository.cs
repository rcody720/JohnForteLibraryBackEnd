using JohnForteLibrary.Domain;
using JohnForteLibrary.Domain.Repositories;
using JohnForteLibrary.Domain.Specifications;
using JohnForteLibrary.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnForteLibrary.Repositories
{
    public class BookRepository : IReadableRepo<Book>, IWritableRepo<Book>
    {
        private JohnForteLibraryDbContext _dbContext;

        public BookRepository(JohnForteLibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Book> Add(Book entityToAdd)
        {
            await _dbContext.AddAsync(entityToAdd);
            await _dbContext.SaveChangesAsync();            

            return entityToAdd;
        }

        public async Task<bool> Delete(Book entityToDelete)
        {
            _dbContext.Books.Remove(entityToDelete);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<Book>> FindAll()
        {
            return  _dbContext.Books.Include(b => b.Authors).ToList();
        }

        public async Task<Book> FindById(int id)
        {
            return _dbContext.Books.Include(x => x.Authors).Include(x=> x.Patron).FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<Book>> FindBySpecification(ISpecification<Book> query)
        {
            if (query == null) return await FindAll();

            return _dbContext.Books.Include(x => x.Authors).Where(query.ToExpression()).ToList();
        }


        public async Task<bool> Update(Book bookToUpdate)
        {
            _dbContext.Books.Attach(bookToUpdate);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
