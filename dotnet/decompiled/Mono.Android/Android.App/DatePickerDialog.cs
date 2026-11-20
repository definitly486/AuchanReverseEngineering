using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Content;
using Android.Runtime;
using Android.Widget;
using Java.Interop;
using Java.Lang;

namespace Android.App;

[Register("android/app/DatePickerDialog", DoNotGenerateAcw = true)]
public class DatePickerDialog : AlertDialog, IDialogInterfaceOnClickListener, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("android/app/DatePickerDialog$OnDateSetListener", "", "Android.App.DatePickerDialog/IOnDateSetListenerInvoker")]
	public interface IOnDateSetListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onDateSet", "(Landroid/widget/DatePicker;III)V", "GetOnDateSet_Landroid_widget_DatePicker_IIIHandler:Android.App.DatePickerDialog/IOnDateSetListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnDateSet(DatePicker? view, int year, int month, int dayOfMonth);
	}

	[Register("android/app/DatePickerDialog$OnDateSetListener", DoNotGenerateAcw = true)]
	internal class IOnDateSetListenerInvoker : Java.Lang.Object, IOnDateSetListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_app_DatePickerDialog_OnDateSetListener = new XAPeerMembers("android/app/DatePickerDialog$OnDateSetListener", typeof(IOnDateSetListenerInvoker));

		private static Delegate? cb_onDateSet_OnDateSet_Landroid_widget_DatePicker_III_V;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_app_DatePickerDialog_OnDateSetListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_app_DatePickerDialog_OnDateSetListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_app_DatePickerDialog_OnDateSetListener.ManagedPeerType;

		public IOnDateSetListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnDateSet_Landroid_widget_DatePicker_III(nint jnienv, nint native__this, nint native_view, int year, int month, int dayOfMonth)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnDateSetListener? onDateSetListener = Java.Lang.Object.GetObject<IOnDateSetListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				DatePicker view = Java.Lang.Object.GetObject<DatePicker>(native_view, JniHandleOwnership.DoNotTransfer);
				onDateSetListener.OnDateSet(view, year, month, dayOfMonth);
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

		public unsafe void OnDateSet(DatePicker? view, int year, int month, int dayOfMonth)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(year);
				ptr[2] = new JniArgumentValue(month);
				ptr[3] = new JniArgumentValue(dayOfMonth);
				_members_android_app_DatePickerDialog_OnDateSetListener.InstanceMethods.InvokeAbstractVoidMethod("onDateSet.(Landroid/widget/DatePicker;III)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
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

		[UnmanagedCallersOnly]
		private static void n_OnDateSet_Landroid_widget_DatePicker_III_mm_wrapper(nint jnienv, nint native__this, nint native_view, int year, int month, int dayOfMonth)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnDateSet_Landroid_widget_DatePicker_III(jnienv, native__this, native_view, year, month, dayOfMonth);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/app/DatePickerDialog", typeof(DatePickerDialog));

	private static Delegate? cb_getDatePicker_GetDatePicker_Landroid_widget_DatePicker_;

	private static Delegate? cb_onClick_OnClick_Landroid_content_DialogInterface_I_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual DatePicker DatePicker
	{
		[Register("getDatePicker", "()Landroid/widget/DatePicker;", "GetGetDatePickerHandler")]
		get
		{
			return Java.Lang.Object.GetObject<DatePicker>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDatePicker.()Landroid/widget/DatePicker;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected DatePickerDialog(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/app/DatePickerDialog$OnDateSetListener;III)V", "")]
	public unsafe DatePickerDialog(Context context, IOnDateSetListener? listener, int year, int month, int dayOfMonth)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			ptr[2] = new JniArgumentValue(year);
			ptr[3] = new JniArgumentValue(month);
			ptr[4] = new JniArgumentValue(dayOfMonth);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/app/DatePickerDialog$OnDateSetListener;III)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/app/DatePickerDialog$OnDateSetListener;III)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetGetDatePickerHandler()
	{
		return new _JniMarshal_PP_L(n_GetDatePicker);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDatePicker(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<DatePickerDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DatePicker);
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

	private static Delegate GetOnClick_Landroid_content_DialogInterface_IHandler()
	{
		return new _JniMarshal_PPLI_V(n_OnClick_Landroid_content_DialogInterface_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnClick_Landroid_content_DialogInterface_I(nint jnienv, nint native__this, nint native_dialog, int which)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DatePickerDialog? datePickerDialog = Java.Lang.Object.GetObject<DatePickerDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDialogInterface dialog = Java.Lang.Object.GetObject<IDialogInterface>(native_dialog, JniHandleOwnership.DoNotTransfer);
			datePickerDialog.OnClick(dialog, which);
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

	[Register("onClick", "(Landroid/content/DialogInterface;I)V", "GetOnClick_Landroid_content_DialogInterface_IHandler")]
	public unsafe virtual void OnClick(IDialogInterface dialog, int which)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((dialog == null) ? IntPtr.Zero : ((Java.Lang.Object)dialog).Handle);
			ptr[1] = new JniArgumentValue(which);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onClick.(Landroid/content/DialogInterface;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(dialog);
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
