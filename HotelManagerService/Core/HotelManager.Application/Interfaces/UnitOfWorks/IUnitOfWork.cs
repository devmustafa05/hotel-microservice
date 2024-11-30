using HotelManager.Application.Interfaces.Repositories;
using HotelManager.Domain.Common;

namespace HotelManager.Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReadRepository<T> GetReadRepostory<T>() where T : class, IEntityBase, new();
        IWriteRepository<T> GetWriteRepostory<T>() where T : class, IEntityBase, new();
        Task<int> SaveAsync();
        int Save();
    }
}
