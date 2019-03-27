using DYMApi.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DYMApi.Controllers {
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ValuesController : ControllerBase {
		private readonly IMediator mediator;

		public ValuesController(IMediator mediator) {
			this.mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> DidYouMean(string query, int size) {
			if (String.IsNullOrEmpty(query)) return Ok(new List<string>());
			if (size == 0) return Ok(new List<string>());

			try {
				var result = await mediator.Send(new CalculateDistanceCommand(query));

				IEnumerable<KeyValuePair<string, int>> Wanted;
				if (query.Length > 4) {
					Wanted = result.Where(x => x.Value == 2);
				} else
					Wanted = result.Where(x => x.Value == 1);

				var final = new List<string>();
				for (int i = 0; i < size; i++) {
					final.Add(Wanted.ElementAt(i).Key);
				}

				return Ok(final);
			} catch (Exception) {
				return StatusCode(500);
			}
		}

	}
}
