using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Models.Clients
{
	public interface IListDictionaryClient
	{
		#region Methods

		Task<IDictionary<string, IEnumerable<string>>> GetAsync();

		#endregion
	}
}