using System;

namespace Auchan.Common.Home;

public interface IHomeScreenTracker
{
	bool Shown { get; set; }

	event EventHandler<EventArgs> OnShown;
}
