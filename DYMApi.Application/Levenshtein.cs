using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DYMApi.Application {
	public class Levenshtein {
		private static int CalculateDistanceBetween(string a, string b) {
			if (String.IsNullOrEmpty(a) && String.IsNullOrEmpty(b)) {
				return 0;
			}
			if (String.IsNullOrEmpty(a)) {
				return b.Length;
			}
			if (String.IsNullOrEmpty(b)) {
				return a.Length;
			}
			int lengthA = a.Length;
			int lengthB = b.Length;
			var distances = new int[lengthA + 1, lengthB + 1];
			for (int i = 0; i <= lengthA; distances[i, 0] = i++) ;
			for (int j = 0; j <= lengthB; distances[0, j] = j++) ;

			for (int i = 1; i <= lengthA; i++)
				for (int j = 1; j <= lengthB; j++) {
					int cost = b[j - 1] == a[i - 1] ? 0 : 1;
					distances[i, j] = Math.Min
						(
						Math.Min(distances[i - 1, j] + 1, distances[i, j - 1] + 1),
						distances[i - 1, j - 1] + cost
						);
				}
			return distances[lengthA, lengthB];
		}

		public static IDictionary<string, int> CalculateDistances(string input, IReadOnlyCollection<string> dictionary) {
			var result = new ConcurrentDictionary<string, int>();

			Parallel.ForEach(dictionary, (word) => {
				var distance = CalculateDistanceBetween(word, input);
				result.TryAdd(word, distance);
			});

			return result;
		}
	}
}
