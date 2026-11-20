using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Maui.ApplicationModel;

public interface IAppActions
{
	bool IsSupported { get; }

	event EventHandler<AppActionEventArgs>? AppActionActivated;

	Task SetAsync(IEnumerable<AppAction> actions);
}
