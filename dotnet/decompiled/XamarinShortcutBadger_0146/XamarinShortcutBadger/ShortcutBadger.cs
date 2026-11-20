using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.App;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace XamarinShortcutBadger;

[Register("me/leolin/shortcutbadger/ShortcutBadger", DoNotGenerateAcw = true)]
public sealed class ShortcutBadger : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("me/leolin/shortcutbadger/ShortcutBadger", typeof(ShortcutBadger));

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

	internal ShortcutBadger(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("applyCount", "(Landroid/content/Context;I)Z", "")]
	public unsafe static bool ApplyCount(Context context, int badgeCount)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(badgeCount);
			return _members.StaticMethods.InvokeBooleanMethod("applyCount.(Landroid/content/Context;I)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("applyCountOrThrow", "(Landroid/content/Context;I)V", "")]
	public unsafe static void ApplyCountOrThrow(Context context, int badgeCount)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(badgeCount);
			_members.StaticMethods.InvokeVoidMethod("applyCountOrThrow.(Landroid/content/Context;I)V", ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("applyNotification", "(Landroid/content/Context;Landroid/app/Notification;I)V", "")]
	public unsafe static void ApplyNotification(Context context, Notification notification, int badgeCount)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(notification?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(badgeCount);
			_members.StaticMethods.InvokeVoidMethod("applyNotification.(Landroid/content/Context;Landroid/app/Notification;I)V", ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(notification);
		}
	}

	[Register("isBadgeCounterSupported", "(Landroid/content/Context;)Z", "")]
	public unsafe static bool IsBadgeCounterSupported(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("isBadgeCounterSupported.(Landroid/content/Context;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("removeCount", "(Landroid/content/Context;)Z", "")]
	public unsafe static bool RemoveCount(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("removeCount.(Landroid/content/Context;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("removeCountOrThrow", "(Landroid/content/Context;)V", "")]
	public unsafe static void RemoveCountOrThrow(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("removeCountOrThrow.(Landroid/content/Context;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}
}
