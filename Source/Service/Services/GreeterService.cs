using System;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace Service.Services
{
	public class GreeterService : Greeter.GreeterBase
	{
		#region Fields

		private readonly ILogger<GreeterService> _logger;

		#endregion

		#region Constructors

		public GreeterService(ILogger<GreeterService> logger)
		{
			this._logger = logger;
		}

		#endregion

		#region Methods

		public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
		{
			if(request == null)
				throw new ArgumentNullException(nameof(request));

			return Task.FromResult(new HelloReply
			{
				Message = "Hello " + request.Name
			});
		}

		#endregion
	}
}