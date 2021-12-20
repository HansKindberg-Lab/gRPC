using System;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace Service
{
	public class ListDictionaryService : ListDictionary.ListDictionaryBase
	{
		#region Constructors

		public ListDictionaryService(ILoggerFactory loggerFactory)
		{
			this.Logger = (loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory))).CreateLogger(this.GetType());
		}

		#endregion

		#region Properties

		protected internal virtual ILogger Logger { get; }

		#endregion

		#region Methods

		public override async Task<Response> Get(Request request, ServerCallContext context)
		{
			var response = new Response();

			response.ListDictionary.Add("First", new Response.Types.StringCollection { Items = { "A", "B", "C" } });
			response.ListDictionary.Add("Second", new Response.Types.StringCollection { Items = { "D", "E", "F" } });
			response.ListDictionary.Add("Third", new Response.Types.StringCollection { Items = { "G", "H", "I" } });

			return await Task.FromResult(response);
		}

		#endregion
	}
}