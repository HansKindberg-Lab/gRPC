using System;
using System.Threading.Tasks;
using Client.Models.Clients;
using Client.Models.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Client.Controllers
{
	public class HomeController : Controller
	{
		#region Constructors

		public HomeController(IListDictionaryClient listDictionaryClient, ILoggerFactory loggerFactory)
		{
			this.ListDictionaryClient = listDictionaryClient ?? throw new ArgumentNullException(nameof(listDictionaryClient));
			this.Logger = (loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory))).CreateLogger(this.GetType());
		}

		#endregion

		#region Properties

		protected internal virtual IListDictionaryClient ListDictionaryClient { get; }
		protected internal virtual ILogger Logger { get; }

		#endregion

		#region Methods

		public virtual async Task<IActionResult> Index()
		{
			var dictionary = await this.ListDictionaryClient.GetAsync();
			var model = new HomeViewModel();

			foreach(var (key, value) in dictionary)
			{
				model.Dictionary.Add(key, value);
			}

			return await Task.FromResult(this.View(model));
		}

		#endregion
	}
}