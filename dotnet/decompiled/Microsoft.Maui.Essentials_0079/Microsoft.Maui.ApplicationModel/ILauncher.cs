using System;
using System.Threading.Tasks;

namespace Microsoft.Maui.ApplicationModel;

public interface ILauncher
{
	Task<bool> OpenAsync(Uri uri);

	Task<bool> TryOpenAsync(Uri uri);
}
