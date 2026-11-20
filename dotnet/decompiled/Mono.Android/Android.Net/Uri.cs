using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.OS;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace Android.Net;

[Register("android/net/Uri", DoNotGenerateAcw = true)]
public abstract class Uri : Java.Lang.Object, IParcelable, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("android/net/Uri$Builder", DoNotGenerateAcw = true)]
	public sealed class Builder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/net/Uri$Builder", typeof(Builder));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Builder(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("appendQueryParameter", "(Ljava/lang/String;Ljava/lang/String;)Landroid/net/Uri$Builder;", "")]
		public unsafe Builder? AppendQueryParameter(string? key, string? value)
		{
			nint num = JNIEnv.NewString(key);
			nint num2 = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(num2);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("appendQueryParameter.(Ljava/lang/String;Ljava/lang/String;)Landroid/net/Uri$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				JNIEnv.DeleteLocalRef(num2);
			}
		}

		[Register("build", "()Landroid/net/Uri;", "")]
		public unsafe Uri? Build()
		{
			return Java.Lang.Object.GetObject<Uri>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/net/Uri", typeof(Uri));

	private static Delegate? cb_getAuthority_GetAuthority_Ljava_lang_String_;

	private static Delegate? cb_getPath_GetPath_Ljava_lang_String_;

	private static Delegate? cb_getScheme_GetScheme_Ljava_lang_String_;

	private static Delegate? cb_buildUpon_BuildUpon_Landroid_net_Uri_Builder_;

	private static Delegate? cb_toString_ToString_Ljava_lang_String_;

	private static Delegate? cb_describeContents_DescribeContents_I;

	private static Delegate? cb_writeToParcel_WriteToParcel_Landroid_os_Parcel_I_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public abstract string? Authority
	{
		[Register("getAuthority", "()Ljava/lang/String;", "GetGetAuthorityHandler")]
		get;
	}

	public abstract string? Path
	{
		[Register("getPath", "()Ljava/lang/String;", "GetGetPathHandler")]
		get;
	}

	public abstract string? Scheme
	{
		[Register("getScheme", "()Ljava/lang/String;", "GetGetSchemeHandler")]
		get;
	}

	protected Uri(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetAuthorityHandler()
	{
		return new _JniMarshal_PP_L(n_GetAuthority);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAuthority(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<Uri>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Authority);
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<Uri>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Path);
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

	private static Delegate GetGetSchemeHandler()
	{
		return new _JniMarshal_PP_L(n_GetScheme);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetScheme(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<Uri>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Scheme);
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

	private static Delegate GetBuildUponHandler()
	{
		return new _JniMarshal_PP_L(n_BuildUpon);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_BuildUpon(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Uri>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BuildUpon());
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

	[Register("buildUpon", "()Landroid/net/Uri$Builder;", "GetBuildUponHandler")]
	public abstract Builder? BuildUpon();

	[Register("fromFile", "(Ljava/io/File;)Landroid/net/Uri;", "")]
	public unsafe static Uri? FromFile(File? file)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(file?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Uri>(_members.StaticMethods.InvokeObjectMethod("fromFile.(Ljava/io/File;)Landroid/net/Uri;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(file);
		}
	}

	[Register("parse", "(Ljava/lang/String;)Landroid/net/Uri;", "")]
	public unsafe static Uri? Parse(string? uriString)
	{
		nint num = JNIEnv.NewString(uriString);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Uri>(_members.StaticMethods.InvokeObjectMethod("parse.(Ljava/lang/String;)Landroid/net/Uri;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetToStringHandler()
	{
		return new _JniMarshal_PP_L(n_ToString);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ToString(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<Uri>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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

	[Register("toString", "()Ljava/lang/String;", "GetToStringHandler")]
	public new abstract string? ToString();

	private static Delegate GetDescribeContentsHandler()
	{
		return new _JniMarshal_PP_I(n_DescribeContents);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_DescribeContents(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Uri>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescribeContents();
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

	[Register("describeContents", "()I", "GetDescribeContentsHandler")]
	public abstract int DescribeContents();

	private static Delegate GetWriteToParcel_Landroid_os_Parcel_IHandler()
	{
		return new _JniMarshal_PPLI_V(n_WriteToParcel_Landroid_os_Parcel_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_WriteToParcel_Landroid_os_Parcel_I(nint jnienv, nint native__this, nint native_dest, int native_flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Uri? uri = Java.Lang.Object.GetObject<Uri>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Parcel dest = Java.Lang.Object.GetObject<Parcel>(native_dest, JniHandleOwnership.DoNotTransfer);
			uri.WriteToParcel(dest, (ParcelableWriteFlags)native_flags);
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

	[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "GetWriteToParcel_Landroid_os_Parcel_IHandler")]
	public abstract void WriteToParcel(Parcel dest, ParcelableWriteFlags flags);

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
