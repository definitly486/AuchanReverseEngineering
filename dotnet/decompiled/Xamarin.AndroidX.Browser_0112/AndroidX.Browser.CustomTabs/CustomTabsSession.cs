using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

namespace AndroidX.Browser.CustomTabs;

[Register("androidx/browser/customtabs/CustomTabsSession", DoNotGenerateAcw = true)]
public sealed class CustomTabsSession : Java.Lang.Object
{
	[Obsolete("While this type is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("androidx/browser/customtabs/CustomTabsSession$PendingSession", DoNotGenerateAcw = true)]
	public class PendingSession : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/browser/customtabs/CustomTabsSession$PendingSession", typeof(PendingSession));

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

		protected PendingSession(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/browser/customtabs/CustomTabsSession", typeof(CustomTabsSession));

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

	internal CustomTabsSession(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("createMockSessionForTesting", "(Landroid/content/ComponentName;)Landroidx/browser/customtabs/CustomTabsSession;", "")]
	public unsafe static CustomTabsSession CreateMockSessionForTesting(ComponentName componentName)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(componentName?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<CustomTabsSession>(_members.StaticMethods.InvokeObjectMethod("createMockSessionForTesting.(Landroid/content/ComponentName;)Landroidx/browser/customtabs/CustomTabsSession;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(componentName);
		}
	}

	[Register("isEngagementSignalsApiAvailable", "(Landroid/os/Bundle;)Z", "")]
	public unsafe bool IsEngagementSignalsApiAvailable(Bundle extras)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isEngagementSignalsApiAvailable.(Landroid/os/Bundle;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(extras);
		}
	}

	[Register("mayLaunchUrl", "(Landroid/net/Uri;Landroid/os/Bundle;Ljava/util/List;)Z", "")]
	public unsafe bool MayLaunchUrl(Android.Net.Uri? url, Bundle? extras, IList<Bundle>? otherLikelyBundles)
	{
		nint num = JavaList<Bundle>.ToLocalJniHandle(otherLikelyBundles);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(url?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("mayLaunchUrl.(Landroid/net/Uri;Landroid/os/Bundle;Ljava/util/List;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(url);
			GC.KeepAlive(extras);
			GC.KeepAlive(otherLikelyBundles);
		}
	}

	[Register("postMessage", "(Ljava/lang/String;Landroid/os/Bundle;)I", "")]
	public unsafe int PostMessage(string message, Bundle? extras)
	{
		nint num = JNIEnv.NewString(message);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeAbstractInt32Method("postMessage.(Ljava/lang/String;Landroid/os/Bundle;)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(extras);
		}
	}

	[Register("receiveFile", "(Landroid/net/Uri;ILandroid/os/Bundle;)Z", "")]
	public unsafe bool ReceiveFile(Android.Net.Uri uri, int purpose, Bundle? extras)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(uri?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(purpose);
			ptr[2] = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("receiveFile.(Landroid/net/Uri;ILandroid/os/Bundle;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(uri);
			GC.KeepAlive(extras);
		}
	}

	[Register("requestPostMessageChannel", "(Landroid/net/Uri;)Z", "")]
	public unsafe bool RequestPostMessageChannel(Android.Net.Uri postMessageOrigin)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(postMessageOrigin?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("requestPostMessageChannel.(Landroid/net/Uri;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(postMessageOrigin);
		}
	}

	[Register("requestPostMessageChannel", "(Landroid/net/Uri;Landroid/net/Uri;Landroid/os/Bundle;)Z", "")]
	public unsafe bool RequestPostMessageChannel(Android.Net.Uri postMessageOrigin, Android.Net.Uri? postMessageTargetOrigin, Bundle extras)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(postMessageOrigin?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(postMessageTargetOrigin?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("requestPostMessageChannel.(Landroid/net/Uri;Landroid/net/Uri;Landroid/os/Bundle;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(postMessageOrigin);
			GC.KeepAlive(postMessageTargetOrigin);
			GC.KeepAlive(extras);
		}
	}

	[Register("setActionButton", "(Landroid/graphics/Bitmap;Ljava/lang/String;)Z", "")]
	public unsafe bool SetActionButton(Bitmap icon, string description)
	{
		nint num = JNIEnv.NewString(description);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("setActionButton.(Landroid/graphics/Bitmap;Ljava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(icon);
		}
	}

	[Register("setEngagementSignalsCallback", "(Landroidx/browser/customtabs/EngagementSignalsCallback;Landroid/os/Bundle;)Z", "")]
	public unsafe bool SetEngagementSignalsCallback(IEngagementSignalsCallback callback, Bundle extras)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			ptr[1] = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("setEngagementSignalsCallback.(Landroidx/browser/customtabs/EngagementSignalsCallback;Landroid/os/Bundle;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(callback);
			GC.KeepAlive(extras);
		}
	}

	[Register("setEngagementSignalsCallback", "(Ljava/util/concurrent/Executor;Landroidx/browser/customtabs/EngagementSignalsCallback;Landroid/os/Bundle;)Z", "")]
	public unsafe bool SetEngagementSignalsCallback(IExecutor executor, IEngagementSignalsCallback callback, Bundle extras)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			ptr[2] = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("setEngagementSignalsCallback.(Ljava/util/concurrent/Executor;Landroidx/browser/customtabs/EngagementSignalsCallback;Landroid/os/Bundle;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(executor);
			GC.KeepAlive(callback);
			GC.KeepAlive(extras);
		}
	}

	[Register("setSecondaryToolbarSwipeUpGesture", "(Landroid/app/PendingIntent;)Z", "")]
	public unsafe bool SetSecondaryToolbarSwipeUpGesture(PendingIntent? pendingIntent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(pendingIntent?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("setSecondaryToolbarSwipeUpGesture.(Landroid/app/PendingIntent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(pendingIntent);
		}
	}

	[Register("setSecondaryToolbarViews", "(Landroid/widget/RemoteViews;[ILandroid/app/PendingIntent;)Z", "")]
	public unsafe bool SetSecondaryToolbarViews(RemoteViews? remoteViews, int[]? clickableIDs, PendingIntent? pendingIntent)
	{
		nint num = JNIEnv.NewArray(clickableIDs);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(remoteViews?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(pendingIntent?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("setSecondaryToolbarViews.(Landroid/widget/RemoteViews;[ILandroid/app/PendingIntent;)Z", this, ptr);
		}
		finally
		{
			if (clickableIDs != null)
			{
				JNIEnv.CopyArray(num, clickableIDs);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(remoteViews);
			GC.KeepAlive(clickableIDs);
			GC.KeepAlive(pendingIntent);
		}
	}

	[Obsolete("deprecated")]
	[Register("setToolbarItem", "(ILandroid/graphics/Bitmap;Ljava/lang/String;)Z", "")]
	public unsafe bool SetToolbarItem(int id, Bitmap icon, string description)
	{
		nint num = JNIEnv.NewString(description);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(id);
			ptr[1] = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("setToolbarItem.(ILandroid/graphics/Bitmap;Ljava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(icon);
		}
	}

	[Register("validateRelationship", "(ILandroid/net/Uri;Landroid/os/Bundle;)Z", "")]
	public unsafe bool ValidateRelationship(int relation, Android.Net.Uri origin, Bundle? extras)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(relation);
			ptr[1] = new JniArgumentValue(origin?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("validateRelationship.(ILandroid/net/Uri;Landroid/os/Bundle;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(origin);
			GC.KeepAlive(extras);
		}
	}
}
