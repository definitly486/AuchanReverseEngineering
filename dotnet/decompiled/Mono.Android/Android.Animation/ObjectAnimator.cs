using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace Android.Animation;

[Register("android/animation/ObjectAnimator", DoNotGenerateAcw = true)]
public sealed class ObjectAnimator : ValueAnimator
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/animation/ObjectAnimator", typeof(ObjectAnimator));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	internal ObjectAnimator(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("ofFloat", "(Ljava/lang/Object;Landroid/util/Property;[F)Landroid/animation/ObjectAnimator;", "")]
	[JavaTypeParameters(new string[] { "T" })]
	public unsafe static ObjectAnimator? OfFloat(Java.Lang.Object? target, Property? property, params float[]? values)
	{
		nint num = JNIEnv.ToLocalJniHandle(target);
		nint num2 = JNIEnv.NewArray(values);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(property?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(num2);
			return Java.Lang.Object.GetObject<ObjectAnimator>(_members.StaticMethods.InvokeObjectMethod("ofFloat.(Ljava/lang/Object;Landroid/util/Property;[F)Landroid/animation/ObjectAnimator;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			if (values != null)
			{
				JNIEnv.CopyArray(num2, values);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(target);
			GC.KeepAlive(property);
			GC.KeepAlive(values);
		}
	}
}
