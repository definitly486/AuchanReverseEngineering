using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Reflection.Emit;
using Mono.CodeGeneration;

namespace Java.Interop;

[RequiresDynamicCode("Mono.Android.Export uses dynamic features.")]
[RequiresUnreferencedCode("Mono.Android.Export uses dynamic features.")]
internal static class DynamicCallbackFactory
{
	public static ModuleBuilder Module { get; private set; }

	public static CodeClass CodeClass { get; private set; }

	static DynamicCallbackFactory()
	{
		Module = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("__callback_factory__"), AssemblyBuilderAccess.Run).DefineDynamicModule("__callback_factory__");
		CodeClass = new CodeClass(Module, "__callback_factory__class__");
	}
}
