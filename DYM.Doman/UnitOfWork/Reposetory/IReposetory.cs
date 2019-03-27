using DYM.Doman.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DYM.Doman.UnitOfWork.Reposetory
{
    public interface IReposetory
    {
        /// <summary>
        /// Gets all entitys in the system
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IReadOnlyCollection<string>> All(
            CancellationToken cancellationToken);
    }
}
