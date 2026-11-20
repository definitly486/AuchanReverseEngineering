using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Lifecycle;

[Register("androidx/lifecycle/ViewModelStore", DoNotGenerateAcw = true)]
public class ViewModelStore : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/ViewModelStore", typeof(ViewModelStore));

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

	protected ViewModelStore(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ViewModelStore()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register("clear", "()V", "")]
	public unsafe void Clear()
	{
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("clear.()V", this, null);
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("get", "(Ljava/lang/String;)Landroidx/lifecycle/ViewModel;", "")]
	public unsafe ViewModel? Get(string key)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ViewModel>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("get.(Ljava/lang/String;)Landroidx/lifecycle/ViewModel;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("keys", "()Ljava/util/Set;", "")]
	public unsafe ICollection<string> Keys()
	{
		return JavaSet<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("keys.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("put", "(Ljava/lang/String;Landroidx/lifecycle/ViewModel;)V", "")]
	public unsafe void Put(string key, ViewModel viewModel)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(viewModel?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("put.(Ljava/lang/String;Landroidx/lifecycle/ViewModel;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(viewModel);
		}
	}
}
