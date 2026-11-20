using System;
using System.Threading.Tasks;

namespace Auchan.Common.PersonalCabinet;

public interface IVkAuthLauncher
{
	Task LaunchAsync(Uri uri);
}
