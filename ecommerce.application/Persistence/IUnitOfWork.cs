using ecommerce.domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.Persistence
{
    public interface IUnitOfWork: IDisposable, IAsyncDisposable 
    {
        IRepository<E> GetRepository<E>() where E : class;
        Task SaveChangesAsync();
    }
}
