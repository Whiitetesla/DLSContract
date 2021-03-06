﻿using DYM.Doman.Entities;
using DYM.Doman.UnitOfWork.Reposetory;
using DYM.Infrastructure.FakeDB;
using DYM.Infrastructure.RealData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DYM.Infrastructure.UnitOfWork.Reposetorys
{
    public class Reposetory : IReposetory
    {
        public Task<IReadOnlyCollection<string>> All(CancellationToken cancellationToken)
        {
            IReadOnlyCollection<string> temp = new DataReader().GetData().AsReadOnly();
            return Task.FromResult(temp);
        }
    }
}
