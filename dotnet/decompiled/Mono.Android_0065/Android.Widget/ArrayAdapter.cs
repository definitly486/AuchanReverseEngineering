using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Versioning;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Android.Widget;

[Register("android/widget/ArrayAdapter", DoNotGenerateAcw = true)]
public class ArrayAdapter<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T> : ArrayAdapter
{
	private static nint id_ctor_Landroid_content_Context_IarrayLjava_lang_Object_;

	public ArrayAdapter(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	public ArrayAdapter(Context context, int textViewResourceId, T[] objects)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewObjectArray(objects);
		if (GetType() == typeof(ArrayAdapter<T>))
		{
			if (id_ctor_Landroid_content_Context_IarrayLjava_lang_Object_ == IntPtr.Zero)
			{
				id_ctor_Landroid_content_Context_IarrayLjava_lang_Object_ = JNIEnv.GetMethodID(ArrayAdapter.class_ref, "<init>", "(Landroid/content/Context;I[Ljava/lang/Object;)V");
			}
			SetHandle(JNIEnv.StartCreateInstance(ArrayAdapter.class_ref, id_ctor_Landroid_content_Context_IarrayLjava_lang_Object_, new JValue(context), new JValue(textViewResourceId), new JValue(num)), JniHandleOwnership.TransferLocalRef);
			JNIEnv.FinishCreateInstance(base.Handle, ArrayAdapter.class_ref, id_ctor_Landroid_content_Context_IarrayLjava_lang_Object_, new JValue(context), new JValue(textViewResourceId), new JValue(num));
		}
		else
		{
			SetHandle(JNIEnv.StartCreateInstance(GetType(), "(Landroid/content/Context;I[Ljava/lang/Object;)V", new JValue(context), new JValue(textViewResourceId), new JValue(num)), JniHandleOwnership.TransferLocalRef);
			JNIEnv.FinishCreateInstance(base.Handle, "(Landroid/content/Context;I[Ljava/lang/Object;)V", new JValue(context), new JValue(textViewResourceId), new JValue(num));
		}
		JNIEnv.DeleteLocalRef(num);
	}
}
[Register("android/widget/ArrayAdapter", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "T" })]
public class ArrayAdapter : BaseAdapter, IJavaObject, IDisposable, IJavaPeerable, ISpinnerAdapter, IAdapter
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/widget/ArrayAdapter", typeof(ArrayAdapter));

	private static Delegate? cb_getCount_GetCount_I;

	private static Delegate? cb_getAutofillOptions_GetAutofillOptions_arrayLjava_lang_CharSequence_;

	private static Delegate? cb_getItem_GetItem_I_Ljava_lang_Object_;

	private static Delegate? cb_getItemId_GetItemId_I_J;

	private static Delegate? cb_getView_GetView_ILandroid_view_View_Landroid_view_ViewGroup__Landroid_view_View_;

	internal new static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override int Count => _members.InstanceMethods.InvokeVirtualInt32Method("getCount.()I", this, null);

	protected ArrayAdapter(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetCountHandler()
	{
		return new _JniMarshal_PP_I(n_GetCount);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ArrayAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Count;
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

	[SupportedOSPlatform("android26.0")]
	private static Delegate GetGetAutofillOptionsHandler()
	{
		return new _JniMarshal_PP_L(n_GetAutofillOptions);
	}

	[SupportedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAutofillOptions(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<ArrayAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAutofillOptionsFormatted());
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

	[SupportedOSPlatform("android26.0")]
	public new unsafe virtual ICharSequence[]? GetAutofillOptionsFormatted()
	{
		return (ICharSequence[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getAutofillOptions.()[Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ICharSequence));
	}

	[SupportedOSPlatform("android26.0")]
	public new string[]? GetAutofillOptions()
	{
		return CharSequence.ArrayToStringArray(GetAutofillOptionsFormatted());
	}

	private static Delegate GetGetItem_IHandler()
	{
		return new _JniMarshal_PPI_L(n_GetItem_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetItem_I(nint jnienv, nint native__this, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ArrayAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItem(position));
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

	public unsafe override Java.Lang.Object? GetItem(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getItem.(I)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetItemId_IHandler()
	{
		return new _JniMarshal_PPI_J(n_GetItemId_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_GetItemId_I(nint jnienv, nint native__this, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Java.Lang.Object.GetObject<ArrayAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItemId(position);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0L;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe override long GetItemId(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		return _members.InstanceMethods.InvokeVirtualInt64Method("getItemId.(I)J", this, ptr);
	}

	private static Delegate GetGetView_ILandroid_view_View_Landroid_view_ViewGroup_Handler()
	{
		return new _JniMarshal_PPILL_L(n_GetView_ILandroid_view_View_Landroid_view_ViewGroup_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetView_ILandroid_view_View_Landroid_view_ViewGroup_(nint jnienv, nint native__this, int position, nint native_convertView, nint native_parent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ArrayAdapter? arrayAdapter = Java.Lang.Object.GetObject<ArrayAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View convertView = Java.Lang.Object.GetObject<View>(native_convertView, JniHandleOwnership.DoNotTransfer);
			ViewGroup parent = Java.Lang.Object.GetObject<ViewGroup>(native_parent, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(arrayAdapter.GetView(position, convertView, parent));
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

	public unsafe override View GetView(int position, View? convertView, ViewGroup parent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(position);
			ptr[1] = new JniArgumentValue(convertView?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("getView.(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(convertView);
			GC.KeepAlive(parent);
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
