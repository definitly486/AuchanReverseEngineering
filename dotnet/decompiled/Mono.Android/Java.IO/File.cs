using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.IO;

[Register("java/io/File", DoNotGenerateAcw = true)]
public class File : Java.Lang.Object, ISerializable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/io/File", typeof(File));

	private static Delegate? cb_getAbsolutePath_GetAbsolutePath_Ljava_lang_String_;

	private static Delegate? cb_getCanonicalPath_GetCanonicalPath_Ljava_lang_String_;

	private static Delegate? cb_getPath_GetPath_Ljava_lang_String_;

	private static Delegate? cb_deleteOnExit_DeleteOnExit_V;

	private static Delegate? cb_mkdirs_Mkdirs_Z;

	[Register("separator")]
	public static string? Separator => JNIEnv.GetString(_members.StaticFields.GetObjectValue("separator.Ljava/lang/String;").Handle, JniHandleOwnership.TransferLocalRef);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual string AbsolutePath
	{
		[Register("getAbsolutePath", "()Ljava/lang/String;", "GetGetAbsolutePathHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getAbsolutePath.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string CanonicalPath
	{
		[Register("getCanonicalPath", "()Ljava/lang/String;", "GetGetCanonicalPathHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getCanonicalPath.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string Path
	{
		[Register("getPath", "()Ljava/lang/String;", "GetGetPathHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getPath.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected File(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Ljava/io/File;Ljava/lang/String;)V", "")]
	public unsafe File(File? parent, string child)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(child);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/io/File;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/io/File;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(parent);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;)V", "")]
	public unsafe File(string pathname)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(pathname);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetAbsolutePathHandler()
	{
		return new _JniMarshal_PP_L(n_GetAbsolutePath);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAbsolutePath(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<File>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AbsolutePath);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetCanonicalPathHandler()
	{
		return new _JniMarshal_PP_L(n_GetCanonicalPath);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCanonicalPath(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<File>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CanonicalPath);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetPathHandler()
	{
		return new _JniMarshal_PP_L(n_GetPath);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPath(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<File>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Path);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetDeleteOnExitHandler()
	{
		return new _JniMarshal_PP_V(n_DeleteOnExit);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DeleteOnExit(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<File>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DeleteOnExit();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("deleteOnExit", "()V", "GetDeleteOnExitHandler")]
	public unsafe virtual void DeleteOnExit()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("deleteOnExit.()V", this, null);
	}

	private static Delegate GetMkdirsHandler()
	{
		return new _JniMarshal_PP_B(n_Mkdirs);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Mkdirs(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<File>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Mkdirs() ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("mkdirs", "()Z", "GetMkdirsHandler")]
	public unsafe virtual bool Mkdirs()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("mkdirs.()Z", this, null);
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
