using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Security;

namespace Bumptech.Glide.Load;

[Register("com/bumptech/glide/load/Option", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "T" })]
public sealed class Option : Java.Lang.Object
{
	[Register("com/bumptech/glide/load/Option$CacheKeyUpdater", "", "Bumptech.Glide.Load.Option/ICacheKeyUpdaterInvoker")]
	[JavaTypeParameters(new string[] { "T" })]
	public interface ICacheKeyUpdater : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("update", "([BLjava/lang/Object;Ljava/security/MessageDigest;)V", "GetUpdate_arrayBLjava_lang_Object_Ljava_security_MessageDigest_Handler:Bumptech.Glide.Load.Option/ICacheKeyUpdaterInvoker, Xamarin.Android.Glide")]
		void Update(byte[] p0, Java.Lang.Object p1, MessageDigest p2);
	}

	[Register("com/bumptech/glide/load/Option$CacheKeyUpdater", DoNotGenerateAcw = true)]
	internal class ICacheKeyUpdaterInvoker : Java.Lang.Object, ICacheKeyUpdater, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_bumptech_glide_load_Option_CacheKeyUpdater = new XAPeerMembers("com/bumptech/glide/load/Option$CacheKeyUpdater", typeof(ICacheKeyUpdaterInvoker));

		private static Delegate? cb_update_Update_arrayBLjava_lang_Object_Ljava_security_MessageDigest__V;

		private static nint java_class_ref => _members_com_bumptech_glide_load_Option_CacheKeyUpdater.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_load_Option_CacheKeyUpdater;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_bumptech_glide_load_Option_CacheKeyUpdater.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_bumptech_glide_load_Option_CacheKeyUpdater.ManagedPeerType;

		public ICacheKeyUpdaterInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetUpdate_arrayBLjava_lang_Object_Ljava_security_MessageDigest_Handler()
		{
			return new global::_JniMarshal_PPLLL_V(n_Update_arrayBLjava_lang_Object_Ljava_security_MessageDigest_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Update_arrayBLjava_lang_Object_Ljava_security_MessageDigest_(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ICacheKeyUpdater? cacheKeyUpdater = Java.Lang.Object.GetObject<ICacheKeyUpdater>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				byte[] array = (byte[])JNIEnv.GetArray(native_p0, JniHandleOwnership.DoNotTransfer, typeof(byte));
				Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p1, JniHandleOwnership.DoNotTransfer);
				MessageDigest p2 = Java.Lang.Object.GetObject<MessageDigest>(native_p2, JniHandleOwnership.DoNotTransfer);
				cacheKeyUpdater.Update(array, p, p2);
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_p0);
				}
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

		public unsafe void Update(byte[] p0, Java.Lang.Object p1, MessageDigest p2)
		{
			nint num = JNIEnv.NewArray(p0);
			nint num2 = JNIEnv.ToLocalJniHandle(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(num2);
				ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
				_members_com_bumptech_glide_load_Option_CacheKeyUpdater.InstanceMethods.InvokeAbstractVoidMethod("update.([BLjava/lang/Object;Ljava/security/MessageDigest;)V", this, ptr);
			}
			finally
			{
				if (p0 != null)
				{
					JNIEnv.CopyArray(num, p0);
					JNIEnv.DeleteLocalRef(num);
				}
				JNIEnv.DeleteLocalRef(num2);
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
				GC.KeepAlive(p2);
			}
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/Option", typeof(Option));

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe Java.Lang.Object? DefaultValue
	{
		[Register("getDefaultValue", "()Ljava/lang/Object;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("getDefaultValue.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal Option(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("disk", "(Ljava/lang/String;Lcom/bumptech/glide/load/Option$CacheKeyUpdater;)Lcom/bumptech/glide/load/Option;", "")]
	[JavaTypeParameters(new string[] { "T" })]
	public unsafe static Option Disk(string key, ICacheKeyUpdater cacheKeyUpdater)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((cacheKeyUpdater == null) ? IntPtr.Zero : ((Java.Lang.Object)cacheKeyUpdater).Handle);
			return Java.Lang.Object.GetObject<Option>(_members.StaticMethods.InvokeObjectMethod("disk.(Ljava/lang/String;Lcom/bumptech/glide/load/Option$CacheKeyUpdater;)Lcom/bumptech/glide/load/Option;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(cacheKeyUpdater);
		}
	}

	[Register("disk", "(Ljava/lang/String;Ljava/lang/Object;Lcom/bumptech/glide/load/Option$CacheKeyUpdater;)Lcom/bumptech/glide/load/Option;", "")]
	[JavaTypeParameters(new string[] { "T" })]
	public unsafe static Option Disk(string key, Java.Lang.Object? defaultValue, ICacheKeyUpdater cacheKeyUpdater)
	{
		nint num = JNIEnv.NewString(key);
		nint num2 = JNIEnv.ToLocalJniHandle(defaultValue);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue((cacheKeyUpdater == null) ? IntPtr.Zero : ((Java.Lang.Object)cacheKeyUpdater).Handle);
			return Java.Lang.Object.GetObject<Option>(_members.StaticMethods.InvokeObjectMethod("disk.(Ljava/lang/String;Ljava/lang/Object;Lcom/bumptech/glide/load/Option$CacheKeyUpdater;)Lcom/bumptech/glide/load/Option;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(defaultValue);
			GC.KeepAlive(cacheKeyUpdater);
		}
	}

	[Register("memory", "(Ljava/lang/String;)Lcom/bumptech/glide/load/Option;", "")]
	[JavaTypeParameters(new string[] { "T" })]
	public unsafe static Option Memory(string key)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Option>(_members.StaticMethods.InvokeObjectMethod("memory.(Ljava/lang/String;)Lcom/bumptech/glide/load/Option;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("memory", "(Ljava/lang/String;Ljava/lang/Object;)Lcom/bumptech/glide/load/Option;", "")]
	[JavaTypeParameters(new string[] { "T" })]
	public unsafe static Option Memory(string key, Java.Lang.Object defaultValue)
	{
		nint num = JNIEnv.NewString(key);
		nint num2 = JNIEnv.ToLocalJniHandle(defaultValue);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return Java.Lang.Object.GetObject<Option>(_members.StaticMethods.InvokeObjectMethod("memory.(Ljava/lang/String;Ljava/lang/Object;)Lcom/bumptech/glide/load/Option;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(defaultValue);
		}
	}

	[Register("update", "(Ljava/lang/Object;Ljava/security/MessageDigest;)V", "")]
	public unsafe void Update(Java.Lang.Object value, MessageDigest messageDigest)
	{
		nint num = JNIEnv.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(messageDigest?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("update.(Ljava/lang/Object;Ljava/security/MessageDigest;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(value);
			GC.KeepAlive(messageDigest);
		}
	}
}
