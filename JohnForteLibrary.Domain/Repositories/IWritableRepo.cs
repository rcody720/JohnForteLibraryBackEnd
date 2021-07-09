using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JohnForteLibrary.Domain.Repositories
{
    public interface IWritableRepo<T> where T : Entity
    {
        public Task<T> Add(T entityToAdd);

        public Task<bool> Delete(T entityToDelete);

        public Task<bool> Update(T entityToUpdate);
        
    }
}
