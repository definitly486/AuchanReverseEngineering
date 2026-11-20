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

	int Count
	{
		[Register("getCount", "()I", "GetGetCountHandler:Android.Widget.IAdapterInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	bool HasStableIds
	{
		[Register("hasStableIds", "()Z", "GetHasStableIdsHandler:Android.Widget.IAdapterInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	bool IsEmpty
	{
		[Register("isEmpty", "()Z", "GetIsEmptyHandler:Android.Widget.IAdapterInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	int ViewTypeCount
	{
		[Register("getViewTypeCount", "()I", "GetGetViewTypeCountHandler:Android.Widget.IAdapterInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	[Register("getItem", "(I)Ljava/lang/Object;", "GetGetItem_IHandler:Android.Widget.IAdapterInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	Java.Lang.Object? GetItem(int position);

	[Register("getItemId", "(I)J", "GetGetItemId_IHandler:Android.Widget.IAdapterInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	long GetItemId(int position);

	[Register("getItemViewType", "(I)I", "GetGetItemViewType_IHandler:Android.Widget.IAdapterInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int GetItemViewType(int position);

	[Register("getView", "(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;", "GetGetView_ILandroid_view_View_Landroid_view_ViewGroup_Handler:Android.Widget.IAdapterInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	View? GetView(int position, View? convertView, ViewGroup? parent);

	[Register("registerDataSetObserver", "(Landroid/database/DataSetObserver;)V", "GetRegisterDataSetObserver_Landroid_database_DataSetObserver_Handler:Android.Widget.IAdapterInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void RegisterDataSetObserver(DataSetObserver? observer);

	[Register("unregisterDataSetObserver", "(Landroid/database/DataSetObserver;)V", "GetUnregisterDataSetObserver_Landroid_database_DataSetObserver_Handler:Android.Widget.IAdapterInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
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
	[Register("getAutofillOptions", "()[Ljava/lang/CharSequence;", "GetGetAutofillOptionsHandler:Android.Widget.IAdapter, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 26)]
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
