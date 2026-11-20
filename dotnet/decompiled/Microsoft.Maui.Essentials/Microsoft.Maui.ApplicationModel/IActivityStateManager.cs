using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;

namespace Microsoft.Maui.ApplicationModel;

public interface IActivityStateManager
{
	event EventHandler<ActivityStateChangedEventArgs> ActivityStateChanged;

	void Init(Application application);

	Activity? GetCurrentActivity();

	Task<Activity> WaitForActivityAsync(CancellationToken cancelToken = default(CancellationToken));
}
