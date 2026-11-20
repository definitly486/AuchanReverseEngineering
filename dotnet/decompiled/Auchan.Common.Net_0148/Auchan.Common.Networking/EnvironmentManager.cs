using System;
using AsyncAwaitBestPractices;
using Auchan.Common.Extensions;

namespace Auchan.Common.Networking;

public class EnvironmentManager : IEnvironmentManager
{
	private const Environment DEFAULT_ENVIRONMENT = Environment.Production;

	private readonly WeakEventManager<Environment> _environmentChangedWeakEventManager = new WeakEventManager<Environment>();

	private Environment _currentEnvironment = PreferencesEx.GetEnum("CurrentEnvironment", Environment.Production);

	public Environment CurrentEnvironment
	{
		get
		{
			return _currentEnvironment;
		}
		set
		{
			if (_currentEnvironment != value)
			{
				_currentEnvironment = PreferencesEx.SetEnum("CurrentEnvironment", value);
				_environmentChangedWeakEventManager.RaiseEvent(value, "EnvironmentChangedWeak");
			}
		}
	}

	public event Action<Environment> EnvironmentChangedWeak
	{
		add
		{
			_environmentChangedWeakEventManager.AddEventHandler(value, "EnvironmentChangedWeak");
		}
		remove
		{
			_environmentChangedWeakEventManager.RemoveEventHandler(value, "EnvironmentChangedWeak");
		}
	}
}
