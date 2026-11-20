using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.Slider;

[Register("com/google/android/material/slider/LabelFormatter", DoNotGenerateAcw = true)]
internal class ILabelFormatterInvoker : Java.Lang.Object, ILabelFormatter, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_google_android_material_slider_LabelFormatter = new XAPeerMembers("com/google/android/material/slider/LabelFormatter", typeof(ILabelFormatterInvoker));

	private static Delegate? cb_getFormattedValue_GetFormattedValue_F_Ljava_lang_String_;

	private static nint java_class_ref => _members_com_google_android_material_slider_LabelFormatter.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_google_android_material_slider_LabelFormatter;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_google_android_material_slider_LabelFormatter.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_google_android_material_slider_LabelFormatter.ManagedPeerType;

	public ILabelFormatterInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetFormattedValue_FHandler()
	{
		return new global::_JniMarshal_PPF_L(n_GetFormattedValue_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetFormattedValue_F(nint jnienv, nint native__this, float p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ILabelFormatter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetFormattedValue(p0));
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

	public unsafe string GetFormattedValue(float p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		return JNIEnv.GetString(_members_com_google_android_material_slider_LabelFormatter.InstanceMethods.InvokeAbstractObjectMethod("getFormattedValue.(F)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
