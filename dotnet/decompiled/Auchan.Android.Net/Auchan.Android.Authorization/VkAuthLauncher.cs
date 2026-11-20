using System;
using System.Threading.Tasks;
using Auchan.Common.PersonalCabinet;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.Authorization;

internal sealed class VkAuthLauncher : IVkAuthLauncher
{
	public Task LaunchAsync(Uri uri)
	{
		return Launcher.TryOpenAsync(uri);
	}
}
