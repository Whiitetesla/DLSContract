using DYM.Doman.UnitOfWork.Reposetory;
using System;
using System.Collections.Generic;
using System.Text;

namespace DYM.Doman.UnitOfWork
{
    public interface IUnitOfWork
    {
        IReposetory Reposetory { get; }
    }
}
