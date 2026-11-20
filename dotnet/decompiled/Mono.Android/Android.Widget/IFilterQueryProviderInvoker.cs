using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Database;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Widget;

[Register("android/widget/FilterQueryProvider", DoNotGenerateAcw = true)]
internal class IFilterQueryProviderInvoker : Java.Lang.Object, IFilterQueryProvider, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_widget_FilterQueryProvider = new XAPeerMembers("android/widget/FilterQueryProvider", typeof(IFilterQueryProviderInvoker));

	private static Delegate? cb_runQuery_RunQuery_Ljava_lang_CharSequence__Landroid_database_Cursor_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_widget_FilterQueryProvider;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_widget_FilterQueryProvider.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_widget_FilterQueryProvider.ManagedPeerType;

	public IFilterQueryProviderInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetRunQuery_Ljava_lang_CharSequence_Handler()
	{
		return new _JniMarshal_PPL_L(n_RunQuery_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_RunQuery_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_constraint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IFilterQueryProvider? filterQueryProvider = Java.Lang.Object.GetObject<IFilterQueryProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence constraint = Java.Lang.Object.GetObject<ICharSequence>(native_constraint, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(filterQueryProvider.RunQuery(constraint));
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

	public unsafe ICursor? RunQuery(ICharSequence? constraint)
	{
		nint num = CharSequence.ToLocalJniHandle(constraint);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ICursor>(_members_android_widget_FilterQueryProvider.InstanceMethods.InvokeAbstractObjectMethod("runQuery.(Ljava/lang/CharSequence;)Landroid/database/Cursor;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(constraint);
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
