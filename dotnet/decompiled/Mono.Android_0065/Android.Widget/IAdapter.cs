using System;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Database;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Android.Widget;

[Register("android/widget/Adapter", "", "Android.Widget.IAdapterInvoker")]
public interface IAdapter : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/widget/Adapter", typeof(IAdapter), isInterface: true);

	private static Delegate? cb_getAutofillOptions_GetAutofillOptions_arrayLjava_lang_CharSequence_;

	int Count { get; }

	bool HasStableIds { get; }

	bool IsEmpty { get; }

	int ViewTypeCount { get; }

	Java.Lang.Object? GetItem(int position);

	long GetItemId(int position);

	int GetItemViewType(int position);

	View? GetView(int position, View? convertView, ViewGroup? parent);

	void RegisterDataSetObserver(DataSetObserver? observer);

	void UnregisterDataSetObserver(DataSetObserver? observer);

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
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<IAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAutofillOptionsFormatted());
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
	unsafe ICharSequence[]? GetAutofillOptionsFormatted()
	{
		return (ICharSequence[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getAutofillOptions.()[Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ICharSequence));
	}

	[SupportedOSPlatform("android26.0")]
	string[]? GetAutofillOptions()
	{
		return CharSequence.ArrayToStringArray(GetAutofillOptionsFormatted());
	}
}
