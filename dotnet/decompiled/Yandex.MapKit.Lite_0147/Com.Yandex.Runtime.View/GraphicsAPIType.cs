using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Runtime.View;

[Register("com/yandex/runtime/view/GraphicsAPIType", DoNotGenerateAcw = true)]
public sealed class GraphicsAPIType : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/runtime/view/GraphicsAPIType", typeof(GraphicsAPIType));

	[Register("OPEN_GL")]
	public static GraphicsAPIType? OpenGl => Java.Lang.Object.GetObject<GraphicsAPIType>(_members.StaticFields.GetObjectValue("OPEN_GL.Lcom/yandex/runtime/view/GraphicsAPIType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("VULKAN")]
	public static GraphicsAPIType? Vulkan => Java.Lang.Object.GetObject<GraphicsAPIType>(_members.StaticFields.GetObjectValue("VULKAN.Lcom/yandex/runtime/view/GraphicsAPIType;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal GraphicsAPIType(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/yandex/runtime/view/GraphicsAPIType;", "")]
	public unsafe static GraphicsAPIType? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<GraphicsAPIType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/yandex/runtime/view/GraphicsAPIType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/yandex/runtime/view/GraphicsAPIType;", "")]
	public unsafe static GraphicsAPIType[]? Values()
	{
		return (GraphicsAPIType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/yandex/runtime/view/GraphicsAPIType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(GraphicsAPIType));
	}
}
