using DYM.Doman.Entities;
using DYM.Doman.UnitOfWork.Reposetory;
using DYM.Infrastructure.FakeDB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DYM.Infrastructure.UnitOfWork.Reposetorys
{
    public class Reposetory : IReposetory
    {
        public Task<IReadOnlyCollection<string>> Al(CancellationToken cancellationToken)
        {
            IReadOnlyCollection<string> temp = new FakeDb().Words.AsReadOnly();
            return Task.FromResult(temp);
        }
    }
}
