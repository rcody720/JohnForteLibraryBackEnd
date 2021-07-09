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
    public class PatronRepository : IReadableRepo<Patron>, IWritableRepo<Patron>
    {
        private JohnForteLibraryDbContext _dbContext;

        public PatronRepository(JohnForteLibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Patron> Add(Patron entityToAdd)
        {
            await _dbContext.AddAsync(entityToAdd);
            await _dbContext.SaveChangesAsync();

            return entityToAdd;
        }

        public async Task<bool> Delete(Patron entityToDelete)
        {
            _dbContext.Patrons.Remove(entityToDelete);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<Patron>> FindAll()
        {
            return _dbContext.Patrons.ToList();
        }

        public async Task<Patron> FindById(int id)
        {
            return _dbContext.Patrons.FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<Patron>> FindBySpecification(ISpecification<Patron> query)
        {
            if (query == null) return await FindAll();

            return _dbContext.Patrons.Where(query.ToExpression()).ToList();
        }

        public Task<bool> Update(Patron entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
