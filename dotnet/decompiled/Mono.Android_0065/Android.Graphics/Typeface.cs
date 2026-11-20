using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Graphics;

[Register("android/graphics/Typeface", DoNotGenerateAcw = true)]
public class Typeface : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/Typeface", typeof(Typeface));

	[Register("DEFAULT")]
	public static Typeface? Default => Java.Lang.Object.GetObject<Typeface>(_members.StaticFields.GetObjectValue("DEFAULT.Landroid/graphics/Typeface;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("DEFAULT_BOLD")]
	public static Typeface? DefaultBold => Java.Lang.Object.GetObject<Typeface>(_members.StaticFields.GetObjectValue("DEFAULT_BOLD.Landroid/graphics/Typeface;").Handle, JniHandleOwnership.TransferLocalRef);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected Typeface(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe static Typeface? Create(string? familyName, TypefaceStyle style)
	{
		nint num = JNIEnv.NewString(familyName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((int)style);
			return Java.Lang.Object.GetObject<Typeface>(_members.StaticMethods.InvokeObjectMethod("create.(Ljava/lang/String;I)Landroid/graphics/Typeface;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}
}
