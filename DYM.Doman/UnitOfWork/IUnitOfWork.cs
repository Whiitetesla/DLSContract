using DYM.Doman.UnitOfWork.Reposetory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DYM.Doman.UnitOfWork
{
    public interface IUnitOfWork
    {
        IReposetory Reposetory { get; }

        Task<int> SaveChanges(CancellationToken cancellationToken = default(CancellationToken));
    }
}
