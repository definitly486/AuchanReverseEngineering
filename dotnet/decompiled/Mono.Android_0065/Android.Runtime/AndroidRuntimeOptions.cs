using Java.Interop;

namespace Android.Runtime;

internal class AndroidRuntimeOptions : JniRuntime.CreationOptions
{
	public AndroidRuntimeOptions(nint jnienv, nint vm, nint classLoader, JniRuntime.JniTypeManager typeManager, JniRuntime.JniValueManager valueManager, bool jniAddNativeMethodRegistrationAttributePresent)
	{
		base.EnvironmentPointer = jnienv;
		base.ClassLoader = new JniObjectReference(classLoader, JniObjectReferenceType.Global);
		base.InvocationPointer = vm;
		base.ObjectReferenceManager = new AndroidObjectReferenceManager();
		base.TypeManager = typeManager;
		base.ValueManager = valueManager;
		base.UseMarshalMemberBuilder = false;
		base.JniAddNativeMethodRegistrationAttributePresent = jniAddNativeMethodRegistrationAttributePresent;
	}
}
