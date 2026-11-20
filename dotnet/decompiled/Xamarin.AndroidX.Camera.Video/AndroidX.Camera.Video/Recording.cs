using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Video;

[Register("androidx/camera/video/Recording", DoNotGenerateAcw = true)]
public sealed class Recording : Java.Lang.Object, IAutoCloseable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/video/Recording", typeof(Recording));

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

	public unsafe bool IsClosed
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("isClosed", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isClosed.()Z", this, null);
		}
	}

	public unsafe bool IsPersistent
	{
		[Register("isPersistent", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isPersistent.()Z", this, null);
		}
	}

	internal Recording(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("close", "()V", "")]
	public unsafe void Close()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("close.()V", this, null);
	}

	[Register("mute", "(Z)V", "")]
	public unsafe void Mute(bool muted)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(muted);
		_members.InstanceMethods.InvokeAbstractVoidMethod("mute.(Z)V", this, ptr);
	}

	[Register("pause", "()V", "")]
	public unsafe void Pause()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("pause.()V", this, null);
	}

	[Register("resume", "()V", "")]
	public unsafe void Resume()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("resume.()V", this, null);
	}

	[Register("stop", "()V", "")]
	public unsafe void Stop()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("stop.()V", this, null);
	}
}
