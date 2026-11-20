using System;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.Common;

public interface IBrowserActivator
{
	Task LaunchBrowserAsync(Uri uri, BrowserLaunchMode browserLaunchMode);
}
