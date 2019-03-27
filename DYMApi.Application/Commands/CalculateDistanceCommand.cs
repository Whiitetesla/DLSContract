using DYM.Doman.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DYMApi.Application.Commands {
	public class CalculateDistanceCommand : IRequest<IDictionary<string, int>> {
		public string Input { get; }

		public CalculateDistanceCommand(string input) {
			this.Input = input;
		}


	}

	public class CalculateDistanceHandler : IRequestHandler<CalculateDistanceCommand, IDictionary<string, int>> {
		private readonly IUnitOfWork uow;

		public CalculateDistanceHandler(IUnitOfWork uow) {
			if (uow == null) throw new ArgumentNullException(nameof(uow));

			this.uow = uow;
		}

		public async Task<IDictionary<string, int>> Handle(CalculateDistanceCommand request, CancellationToken cancellationToken) {
			if (request == null) throw new ArgumentNullException(nameof(request));
			if (cancellationToken == null) throw new ArgumentNullException(nameof(cancellationToken));
			if (request.Input == null) throw new ArgumentNullException(nameof(request.Input));

			var dictionary = await uow.Reposetory.All(cancellationToken);

			return Levenshtein.CalculateDistances(request.Input, dictionary);
		}
	}
}
