using System;
using System.Collections.Generic;
using System.Text;

namespace DYM.Doman.Interfaces {
	interface IDYMApi {
		List<string> DidYouMean(string query, int size);
	}
}
