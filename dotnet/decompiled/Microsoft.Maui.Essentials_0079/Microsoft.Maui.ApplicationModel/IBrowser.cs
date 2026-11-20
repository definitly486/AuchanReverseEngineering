using System;
using System.Threading.Tasks;

namespace Microsoft.Maui.ApplicationModel;

public interface IBrowser
{
	Task<bool> OpenAsync(Uri uri, BrowserLaunchOptions options);
}
