using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Threading;
using Android.App;
using Java.Interop;
using Java.Interop.Tools.TypeNameMappings;

namespace Android.Runtime;

internal static class JNIEnvInit
{
	internal struct JnienvInitializeArgs
	{
		public nint javaVm;

		public nint env;

		public nint grefLoader;

		public nint Loader_loadClass;

		public nint grefClass;

		public uint logCategories;

		public int version;

		public int grefGcThreshold;

		public nint grefIGCUserPeer;

		public byte brokenExceptionTransitions;

		public int packageNamingPolicy;

		public byte ioExceptionType;

		public int jniAddNativeMethodRegistrationAttributePresent;

		public bool jniRemappingInUse;

		public bool marshalMethodsEnabled;

		public nint grefGCUserPeerable;

		public bool managedMarshalMethodsLookupEnabled;

		public nint propagateUncaughtExceptionFn;
	}

	internal static bool jniRemappingInUse;

	internal static bool MarshalMethodsEnabled;

	internal static bool PropagateExceptions;

	internal static BoundExceptionType BoundExceptionType;

	internal static int gref_gc_threshold;

	internal static nint grefIGCUserPeer_class;

	internal static nint grefGCUserPeerable_class;

	internal static nint java_class_loader;

	internal static JniRuntime? androidRuntime;

	[UnmanagedCallersOnly]
	private static void PropagateUncaughtException(nint env, nint javaThread, nint javaException)
	{
		JNIEnv.PropagateUncaughtException(env, javaThread, javaException);
	}

	[UnmanagedCallersOnly]
	private unsafe static void RegisterJniNatives(nint typeName_ptr, int typeName_len, nint jniClass, nint methods_ptr, int methods_len)
	{
		string text = new string((char*)typeName_ptr, 0, typeName_len);
		Type type = TypeGetType(text);
		if (type == null)
		{
			RuntimeNativeMethods.monodroid_log(LogLevel.Error, LogCategories.Default, $"Could not load type '{text}'. Skipping JNI registration of type '{Java.Interop.TypeManager.GetClassName(jniClass)}'.");
		}
		else
		{
			string className = Java.Interop.TypeManager.GetClassName(jniClass);
			Java.Interop.TypeManager.RegisterType(className, type);
			JniType cachedType = null;
			JniType.GetCachedJniType(ref cachedType, className);
			ReadOnlySpan<char> methods = new ReadOnlySpan<char>((void*)methods_ptr, methods_len);
			androidRuntime.TypeManager.RegisterNativeMembers(cachedType, type, methods);
		}
		[UnconditionalSuppressMessage("Trimming", "IL2057", Justification = "Type should be preserved by the MarkJavaObjects trimmer step.")]
		[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.NonPublicNestedTypes)]
		static Type TypeGetType(string typeName)
		{
			return Type.GetType(typeName, throwOnError: false);
		}
	}

	[UnmanagedCallersOnly]
	internal unsafe static void Initialize(JnienvInitializeArgs* args)
	{
		_ = 1;
		if (false)
		{
		}
		_ = IntPtr.Zero;
		_ = IntPtr.Zero;
		Logger.SetLogCategories((LogCategories)args->logCategories);
		gref_gc_threshold = args->grefGcThreshold;
		jniRemappingInUse = args->jniRemappingInUse;
		MarshalMethodsEnabled = args->marshalMethodsEnabled;
		java_class_loader = args->grefLoader;
		BoundExceptionType = (BoundExceptionType)args->ioExceptionType;
		if (false)
		{
		}
		JniRuntime.JniTypeManager typeManager = new AndroidTypeManager(args->jniAddNativeMethodRegistrationAttributePresent != 0);
		_ = 1;
		JniRuntime.JniValueManager valueManager = new AndroidValueManager();
		androidRuntime = new AndroidRuntime(args->env, args->javaVm, args->grefLoader, typeManager, valueManager, args->jniAddNativeMethodRegistrationAttributePresent != 0);
		grefIGCUserPeer_class = args->grefIGCUserPeer;
		grefGCUserPeerable_class = args->grefGCUserPeerable;
		PropagateExceptions = args->brokenExceptionTransitions == 0;
		JavaNativeTypeManager.PackageNamingPolicy = (PackageNamingPolicy)args->packageNamingPolicy;
		if (args->managedMarshalMethodsLookupEnabled)
		{
			delegate* unmanaged<int, int, int, nint*, void> get_function_pointer = (delegate* unmanaged<int, int, int, nint*, void>)(delegate*<int, int, int, nint*, void>)(&ManagedMarshalMethodsLookupTable.GetFunctionPointer);
			xamarin_app_init(args->env, get_function_pointer);
		}
		args->propagateUncaughtExceptionFn = (nint)(delegate*<nint, nint, nint, void>)(&PropagateUncaughtException);
		RunStartupHooksIfNeeded();
		SetSynchronizationContext();
	}

	[DllImport("xa-internal-api", CallingConvention = CallingConvention.Cdecl)]
	private unsafe static extern void xamarin_app_init(nint env, delegate* unmanaged<int, int, int, nint*, void> get_function_pointer);

	private static void RunStartupHooksIfNeeded()
	{
		_ = 0;
	}

	private static void SetSynchronizationContext()
	{
		SynchronizationContext.SetSynchronizationContext(Application.SynchronizationContext);
	}
}
