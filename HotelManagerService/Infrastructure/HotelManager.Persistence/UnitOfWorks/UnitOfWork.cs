using HotelManager.Application.Interfaces.Repositories;
using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Persistence.Context;
using HotelManager.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();

        public int Save() => dbContext.SaveChanges();

        public Task<int> SaveAsync() => dbContext.SaveChangesAsync();

        IReadRepository<T> IUnitOfWork.GetReadRepostory<T>() => new ReadRespostory<T>(dbContext);

        IWriteRepository<T> IUnitOfWork.GetWriteRepostory<T>() => new WriteRepository<T>(dbContext);
    }
}
