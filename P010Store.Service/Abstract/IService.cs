using P010Store.Data.Abstract;
using P010Store.Entities;

namespace P010Store.Service.Abstract
{
    public interface IService<T> : IRepository<T> where T : class, IEntity, new()
    {
    }
}
