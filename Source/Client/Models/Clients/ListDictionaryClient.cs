using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Service;

namespace Client.Models.Clients
{
	public class ListDictionaryClient : IListDictionaryClient
	{
		#region Constructors

		public ListDictionaryClient(IConfiguration configuration)
		{
			this.Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
		}

		#endregion

		#region Properties

		protected internal virtual IConfiguration Configuration { get; }
		protected internal virtual string ConnectionStringName => "ListDictionaryService";

		#endregion

		#region Methods

		public virtual async Task<IDictionary<string, IEnumerable<string>>> GetAsync()
		{
			using(var channel = GrpcChannel.ForAddress(this.Configuration.GetConnectionString(this.ConnectionStringName)))
			{
				var client = new ListDictionary.ListDictionaryClient(channel);
				var dictionary = new Dictionary<string, IEnumerable<string>>(StringComparer.OrdinalIgnoreCase);
				var response = await client.GetAsync(new Request());

				foreach(var (key, value) in response.ListDictionary)
				{
					dictionary.Add(key, value.Items.ToArray());
				}

				return dictionary;
			}
		}

		#endregion
	}
}