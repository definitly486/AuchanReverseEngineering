using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Content;

[Register("android/content/ClipData", DoNotGenerateAcw = true)]
public class ClipData : Java.Lang.Object, IParcelable, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("android/content/ClipData$Item", DoNotGenerateAcw = true)]
	public class Item : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/content/ClipData$Item", typeof(Item));

		private static Delegate? cb_getUri_GetUri_Landroid_net_Uri_;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual Android.Net.Uri? Uri
		{
			[Register("getUri", "()Landroid/net/Uri;", "GetGetUriHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceMethods.InvokeVirtualObjectMethod("getUri.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected Item(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetUriHandler()
		{
			return new _JniMarshal_PP_L(n_GetUri);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetUri(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Item>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Uri);
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
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/content/ClipData", typeof(ClipData));

	private static Delegate? cb_getItemCount_GetItemCount_I;

	private static Delegate? cb_describeContents_DescribeContents_I;

	private static Delegate? cb_getItemAt_GetItemAt_I_Landroid_content_ClipData_Item_;

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

	public unsafe virtual int ItemCount => _members.InstanceMethods.InvokeVirtualInt32Method("getItemCount.()I", this, null);

	protected ClipData(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetItemCountHandler()
	{
		return new _JniMarshal_PP_I(n_GetItemCount);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetItemCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ClipData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemCount;
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
			return Java.Lang.Object.GetObject<ClipData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescribeContents();
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

	public unsafe virtual int DescribeContents()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("describeContents.()I", this, null);
	}

	private static Delegate GetGetItemAt_IHandler()
	{
		return new _JniMarshal_PPI_L(n_GetItemAt_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetItemAt_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ClipData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItemAt(index));
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

	public unsafe virtual Item? GetItemAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<Item>(_members.InstanceMethods.InvokeVirtualObjectMethod("getItemAt.(I)Landroid/content/ClipData$Item;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	public unsafe static ClipData? NewPlainText(ICharSequence? label, ICharSequence? text)
	{
		nint num = CharSequence.ToLocalJniHandle(label);
		nint num2 = CharSequence.ToLocalJniHandle(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return Java.Lang.Object.GetObject<ClipData>(_members.StaticMethods.InvokeObjectMethod("newPlainText.(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Landroid/content/ClipData;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(label);
			GC.KeepAlive(text);
		}
	}

	public static ClipData? NewPlainText(string? label, string? text)
	{
		Java.Lang.String obj = ((label == null) ? null : new Java.Lang.String(label));
		Java.Lang.String obj2 = ((text == null) ? null : new Java.Lang.String(text));
		ClipData result = NewPlainText(obj, obj2);
		obj?.Dispose();
		obj2?.Dispose();
		return result;
	}

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
			ClipData? clipData = Java.Lang.Object.GetObject<ClipData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Parcel dest = Java.Lang.Object.GetObject<Parcel>(native_dest, JniHandleOwnership.DoNotTransfer);
			clipData.WriteToParcel(dest, (ParcelableWriteFlags)native_flags);
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

	public unsafe virtual void WriteToParcel(Parcel? dest, ParcelableWriteFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(dest?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)flags);
			_members.InstanceMethods.InvokeVirtualVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(dest);
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
