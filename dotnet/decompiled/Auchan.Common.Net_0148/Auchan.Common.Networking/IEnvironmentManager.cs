using System;

namespace Auchan.Common.Networking;

public interface IEnvironmentManager
{
	Environment CurrentEnvironment { get; set; }

	event Action<Environment> EnvironmentChangedWeak;
}
