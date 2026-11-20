using System.Diagnostics.CodeAnalysis;
using Akavache.Core;
using Akavache.Sqlite3;
using SQLitePCL;
using Splat;

namespace Akavache;

[Preserve(AllMembers = true)]
[RequiresUnreferencedCode("Registrations for Akavache")]
[RequiresDynamicCode("Registrations for Akavache")]
public class Registrations : IWantsToRegisterStuff
{
	public static void Start(string applicationName)
	{
		Akavache.Sqlite3.Registrations.Start(applicationName, Batteries_V2.Init);
	}

	public void Register(IMutableDependencyResolver resolver, IReadonlyDependencyResolver readonlyDependencyResolver)
	{
		Batteries_V2.Init();
	}
}
