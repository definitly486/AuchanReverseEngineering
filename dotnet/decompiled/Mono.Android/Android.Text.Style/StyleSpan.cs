using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text.Style;

[Register("android/text/style/StyleSpan", DoNotGenerateAcw = true)]
public class StyleSpan : MetricAffectingSpan, IParcelable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/style/StyleSpan", typeof(StyleSpan));

	private static Delegate? cb_describeContents_DescribeContents_I;

	private static Delegate? cb_updateDrawState_UpdateDrawState_Landroid_text_TextPaint__V;

	private static Delegate? cb_updateMeasureState_UpdateMeasureState_Landroid_text_TextPaint__V;

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

	protected StyleSpan(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(I)V", "")]
	public unsafe StyleSpan(TypefaceStyle style)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((int)style);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
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
			return Java.Lang.Object.GetObject<StyleSpan>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescribeContents();
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
	public unsafe virtual int DescribeContents()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("describeContents.()I", this, null);
	}

	private static Delegate GetUpdateDrawState_Landroid_text_TextPaint_Handler()
	{
		return new _JniMarshal_PPL_V(n_UpdateDrawState_Landroid_text_TextPaint_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateDrawState_Landroid_text_TextPaint_(nint jnienv, nint native__this, nint native_ds)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			StyleSpan? styleSpan = Java.Lang.Object.GetObject<StyleSpan>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TextPaint tp = Java.Lang.Object.GetObject<TextPaint>(native_ds, JniHandleOwnership.DoNotTransfer);
			styleSpan.UpdateDrawState(tp);
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

	[Register("updateDrawState", "(Landroid/text/TextPaint;)V", "GetUpdateDrawState_Landroid_text_TextPaint_Handler")]
	public unsafe override void UpdateDrawState(TextPaint? ds)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(ds?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateDrawState.(Landroid/text/TextPaint;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(ds);
		}
	}

	private static Delegate GetUpdateMeasureState_Landroid_text_TextPaint_Handler()
	{
		return new _JniMarshal_PPL_V(n_UpdateMeasureState_Landroid_text_TextPaint_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateMeasureState_Landroid_text_TextPaint_(nint jnienv, nint native__this, nint native_paint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			StyleSpan? styleSpan = Java.Lang.Object.GetObject<StyleSpan>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TextPaint textPaint = Java.Lang.Object.GetObject<TextPaint>(native_paint, JniHandleOwnership.DoNotTransfer);
			styleSpan.UpdateMeasureState(textPaint);
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

	[Register("updateMeasureState", "(Landroid/text/TextPaint;)V", "GetUpdateMeasureState_Landroid_text_TextPaint_Handler")]
	public unsafe override void UpdateMeasureState(TextPaint? paint)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(paint?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateMeasureState.(Landroid/text/TextPaint;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(paint);
		}
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
			StyleSpan? styleSpan = Java.Lang.Object.GetObject<StyleSpan>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Parcel dest = Java.Lang.Object.GetObject<Parcel>(native_dest, JniHandleOwnership.DoNotTransfer);
			styleSpan.WriteToParcel(dest, (ParcelableWriteFlags)native_flags);
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
