using System;
using System.Collections.Generic;
using System.Text;

namespace DYM.Doman.Interfaces {
	public interface IDYMApi {
		List<string> DidYouMean(string query, int size);
	}
}
