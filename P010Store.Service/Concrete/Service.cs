using P010Store.Data;
using P010Store.Data.Concrete;
using P010Store.Entities;
using P010Store.Service.Abstract;

namespace P010Store.Service.Concrete
{
    public class Service<T> : Repository<T>, IService<T> where T : class, IEntity, new()
    {
        public Service(DatabaseContext _context) : base(_context)
        {
        }
    }
}
