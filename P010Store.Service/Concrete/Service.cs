using P010Store.Data;
using P010Store.Data.Concrete;
using P010Store.Entities;

namespace P010Store.Service.Concrete
{
    public class Service<T> : Repository<T> where T : class, IEntity, new()
    {
        public Service(DatabaseContext _context) : base(_context)
        {
        }
    }
}
