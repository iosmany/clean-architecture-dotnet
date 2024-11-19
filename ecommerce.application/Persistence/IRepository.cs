using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.Persistence
{
    public interface IRepository<E> where E: class
    {
        ValueTask<E?> GetByIdAsync(long id);
        IAsyncEnumerable<E> GetAllAsync();
    }
}
