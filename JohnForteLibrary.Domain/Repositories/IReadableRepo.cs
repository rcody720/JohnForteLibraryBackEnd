using JohnForteLibrary.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JohnForteLibrary.Domain.Repositories
{
    public interface IReadableRepo<T> where T : Entity
    {
        public Task<List<T>> FindAll();

        public Task<T> FindById(int id);

        public Task<List<T>> FindBySpecification(ISpecification<T> specification);
    }
}
