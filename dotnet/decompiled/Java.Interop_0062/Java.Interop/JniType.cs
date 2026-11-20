using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace Java.Interop;

public sealed class JniType : IDisposable
{
	private bool registered;

	private JniObjectReference peerReference;

	private JniNativeMethodRegistration[]? methods;

	public JniObjectReference PeerReference => peerReference;

	public string Name
	{
		get
		{
			AssertValid();
			return JniEnvironment.Types.GetJniTypeNameFromClass(PeerReference);
		}
	}

	public static bool TryParse(string name, [NotNullWhen(true)] out JniType? type)
	{
		if (!JniEnvironment.Types.TryFindClass(name, out var instance))
		{
			type = null;
			return false;
		}
		type = new JniType(ref instance, JniObjectReferenceOptions.CopyAndDispose);
		return true;
	}

	public JniType(string classname)
	{
		JniObjectReference jniObjectReference = JniEnvironment.Types.FindClass(classname);
		Initialize(ref jniObjectReference, JniObjectReferenceOptions.CopyAndDispose);
	}

	public JniType(ref JniObjectReference peerReference, JniObjectReferenceOptions transfer)
	{
		Initialize(ref peerReference, transfer);
	}

	private void Initialize(ref JniObjectReference peerReference, JniObjectReferenceOptions transfer)
	{
		if (!peerReference.IsValid)
		{
			throw new ArgumentException("handle must be valid.", "peerReference");
		}
		try
		{
			this.peerReference = peerReference.NewGlobalRef();
		}
		finally
		{
			JniObjectReference.Dispose(ref peerReference, transfer);
		}
	}

	public override string ToString()
	{
		return $"JniType(Name='{Name}' PeerReference={PeerReference})";
	}

	public void RegisterWithRuntime()
	{
		AssertValid();
		if (!registered)
		{
			JniEnvironment.Runtime.Track(this);
			registered = true;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void AssertValid()
	{
		if (!PeerReference.IsValid)
		{
			throw new ObjectDisposedException(GetType().FullName);
		}
	}

	public static JniType GetCachedJniType([NotNull] ref JniType? cachedType, string classname)
	{
		if (cachedType != null && cachedType.PeerReference.IsValid)
		{
			return cachedType;
		}
		JniType jniType = new JniType(classname);
		if (Interlocked.CompareExchange(ref cachedType, jniType, null) != null)
		{
			jniType.Dispose();
		}
		cachedType.RegisterWithRuntime();
		return cachedType;
	}

	public void Dispose()
	{
		if (PeerReference.IsValid)
		{
			if (registered)
			{
				JniEnvironment.Runtime.UnTrack(PeerReference.Handle);
			}
			if (methods != null)
			{
				UnregisterNativeMethods();
			}
			JniObjectReference.Dispose(ref peerReference);
		}
	}

	public void RegisterNativeMethods(params JniNativeMethodRegistration[] methods)
	{
		AssertValid();
		if (methods == null)
		{
			throw new ArgumentNullException("methods");
		}
		JniEnvironment.Types.RegisterNatives(PeerReference, methods, methods.Length);
		this.methods = methods;
		RegisterWithRuntime();
	}

	public void UnregisterNativeMethods()
	{
		AssertValid();
		JniEnvironment.Types.UnregisterNatives(PeerReference);
	}

	public JniMethodInfo GetConstructor(string signature)
	{
		AssertValid();
		return JniEnvironment.InstanceMethods.GetMethodID(PeerReference, "<init>", signature);
	}

	public JniMethodInfo GetCachedConstructor([NotNull] ref JniMethodInfo? cachedMethod, string signature)
	{
		AssertValid();
		return GetCachedInstanceMethod(ref cachedMethod, "<init>", signature);
	}

	public JniObjectReference AllocObject()
	{
		AssertValid();
		return JniEnvironment.Object.AllocObject(PeerReference);
	}

	public unsafe JniObjectReference NewObject(JniMethodInfo constructor, JniArgumentValue* parameters)
	{
		AssertValid();
		return JniEnvironment.Object.NewObject(PeerReference, constructor, parameters);
	}

	public JniFieldInfo GetInstanceField(string name, string signature)
	{
		AssertValid();
		return JniEnvironment.InstanceFields.GetFieldID(PeerReference, name, signature);
	}

	public JniFieldInfo GetStaticField(string name, string signature)
	{
		AssertValid();
		return JniEnvironment.StaticFields.GetStaticFieldID(PeerReference, name, signature);
	}

	public JniMethodInfo GetInstanceMethod(string name, string signature)
	{
		AssertValid();
		return JniEnvironment.InstanceMethods.GetMethodID(PeerReference, name, signature);
	}

	internal bool TryGetInstanceMethod(string name, string signature, [NotNullWhen(true)] out JniMethodInfo? method)
	{
		AssertValid();
		method = null;
		nint environmentPointer = JniEnvironment.EnvironmentPointer;
		nint thrown;
		nint num = RawGetMethodID(environmentPointer, name, signature, out thrown);
		if (thrown != IntPtr.Zero)
		{
			JniEnvironment.Exceptions.ExceptionClear();
			JniEnvironment.References.RawDeleteLocalRef(environmentPointer, thrown);
			return false;
		}
		if (num == IntPtr.Zero)
		{
			return false;
		}
		method = new JniMethodInfo(name, signature, num, isStatic: false);
		return true;
	}

	private nint RawGetMethodID(nint env, string name, string signature, out nint thrown)
	{
		nint num = Marshal.StringToCoTaskMemUTF8(name);
		nint num2 = Marshal.StringToCoTaskMemUTF8(signature);
		try
		{
			nint methodID = JniNativeMethods.GetMethodID(env, PeerReference.Handle, num, num2);
			thrown = JniNativeMethods.ExceptionOccurred(env);
			return methodID;
		}
		finally
		{
			Marshal.ZeroFreeCoTaskMemUTF8(num);
			Marshal.ZeroFreeCoTaskMemUTF8(num2);
		}
	}

	public JniMethodInfo GetCachedInstanceMethod([NotNull] ref JniMethodInfo? cachedMethod, string name, string signature)
	{
		AssertValid();
		if (cachedMethod != null && cachedMethod.IsValid)
		{
			return cachedMethod;
		}
		JniMethodInfo instanceMethod = GetInstanceMethod(name, signature);
		Interlocked.CompareExchange(ref cachedMethod, instanceMethod, null);
		return cachedMethod;
	}

	public JniMethodInfo GetStaticMethod(string name, string signature)
	{
		AssertValid();
		return JniEnvironment.StaticMethods.GetStaticMethodID(PeerReference, name, signature);
	}

	internal bool TryGetStaticMethod(string name, string signature, [NotNullWhen(true)] out JniMethodInfo? method)
	{
		AssertValid();
		method = null;
		nint environmentPointer = JniEnvironment.EnvironmentPointer;
		nint thrown;
		nint num = RawGetStaticMethodID(environmentPointer, name, signature, out thrown);
		if (thrown != IntPtr.Zero)
		{
			JniEnvironment.Exceptions.ExceptionClear();
			JniEnvironment.References.RawDeleteLocalRef(environmentPointer, thrown);
			return false;
		}
		if (num == IntPtr.Zero)
		{
			return false;
		}
		method = new JniMethodInfo(name, signature, num, isStatic: true);
		return true;
	}

	private nint RawGetStaticMethodID(nint env, string name, string signature, out nint thrown)
	{
		nint num = Marshal.StringToCoTaskMemUTF8(name);
		nint num2 = Marshal.StringToCoTaskMemUTF8(signature);
		try
		{
			nint staticMethodID = JniNativeMethods.GetStaticMethodID(env, PeerReference.Handle, num, num2);
			thrown = JniNativeMethods.ExceptionOccurred(env);
			return staticMethodID;
		}
		finally
		{
			Marshal.ZeroFreeCoTaskMemUTF8(num);
			Marshal.ZeroFreeCoTaskMemUTF8(num2);
		}
	}

	public JniMethodInfo GetCachedStaticMethod([NotNull] ref JniMethodInfo? cachedMethod, string name, string signature)
	{
		AssertValid();
		if (cachedMethod != null && cachedMethod.IsValid)
		{
			return cachedMethod;
		}
		JniMethodInfo staticMethod = GetStaticMethod(name, signature);
		Interlocked.CompareExchange(ref cachedMethod, staticMethod, null);
		return cachedMethod;
	}
}
