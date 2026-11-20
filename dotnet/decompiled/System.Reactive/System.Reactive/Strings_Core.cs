using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;

namespace System.Reactive;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class Strings_Core
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
			{
				resourceMan = new ResourceManager("System.Reactive.Strings_Core", typeof(Strings_Core).GetTypeInfo().Assembly);
			}
			return resourceMan;
		}
	}

	internal static string COMPLETED_NO_VALUE => ResourceManager.GetString("COMPLETED_NO_VALUE", resourceCulture);

	internal static string DISPOSABLE_ALREADY_ASSIGNED => ResourceManager.GetString("DISPOSABLE_ALREADY_ASSIGNED", resourceCulture);

	internal static string DISPOSABLES_CANT_CONTAIN_NULL => ResourceManager.GetString("DISPOSABLES_CANT_CONTAIN_NULL", resourceCulture);

	internal static string HEAP_EMPTY => ResourceManager.GetString("HEAP_EMPTY", resourceCulture);
}
