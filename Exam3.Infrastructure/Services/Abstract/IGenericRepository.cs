using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam3.Core.Entities;

namespace Exam3.Infrastructure.Repositories.Abstract
{
    public interface IGenericRepository<T>
    {
        public void Update(T entity);

        public Task SaveChangesAsync();

        public Task AddAsync(T entity);

        public Task<int> CountAsync();
    }
}
