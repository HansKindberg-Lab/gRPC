using System;
using System.Collections.Generic;

namespace Client.Models.ViewModels
{
	public class HomeViewModel
	{
		#region Properties

		public virtual IDictionary<string, IEnumerable<string>> Dictionary { get; } = new Dictionary<string, IEnumerable<string>>(StringComparer.OrdinalIgnoreCase);

		#endregion
	}
}