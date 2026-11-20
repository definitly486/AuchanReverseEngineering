using System;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.PersonalCabinet;

namespace Auchan.Common.Home;

internal class HomeScreenTracker : IHomeScreenTracker
{
	private bool _shown;

	private readonly WeakEventManager<EventArgs> _weakEventManager = new WeakEventManager<EventArgs>();

	public bool Shown
	{
		get
		{
			return _shown;
		}
		set
		{
			_shown = value;
			if (value)
			{
				_weakEventManager.RaiseEvent((object?)this, EventArgs.Empty, "OnShown");
			}
		}
	}

	public event EventHandler<EventArgs> OnShown
	{
		add
		{
			_weakEventManager.AddEventHandler(value, "OnShown");
		}
		remove
		{
			_weakEventManager.RemoveEventHandler(value, "OnShown");
		}
	}

	public HomeScreenTracker(IUserContext context)
	{
		context.AfterLoggedOut += AfterLoggedOut;
	}

	private Task AfterLoggedOut()
	{
		Shown = false;
		return Task.CompletedTask;
	}
}
