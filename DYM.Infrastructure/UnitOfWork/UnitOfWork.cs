using DYM.Doman.UnitOfWork;
using DYM.Doman.UnitOfWork.Reposetory;
using DYM.Infrastructure.UnitOfWork.Reposetorys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DYM.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IReposetory Reposetory { get; }

        public UnitOfWork()
        {
            this.Reposetory = new Reposetory();
        }

    }
}
