using System;
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
using Java.Util;

namespace AndroidX.Browser.CustomTabs;

[Register("androidx/browser/customtabs/CustomTabsIntent", DoNotGenerateAcw = true)]
public sealed class CustomTabsIntent : Java.Lang.Object
{
	[Register("androidx/browser/customtabs/CustomTabsIntent$Builder", DoNotGenerateAcw = true)]
	public sealed class Builder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/browser/customtabs/CustomTabsIntent$Builder", typeof(Builder));

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

		internal Builder(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Builder()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Landroidx/browser/customtabs/CustomTabsSession;)V", "")]
		public unsafe Builder(CustomTabsSession? session)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(session?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/browser/customtabs/CustomTabsSession;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/browser/customtabs/CustomTabsSession;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(session);
			}
		}

		[Obsolete("deprecated")]
		[Register("addDefaultShareMenuItem", "()Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder AddDefaultShareMenuItem()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addDefaultShareMenuItem.()Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("addMenuItem", "(Ljava/lang/String;Landroid/app/PendingIntent;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder AddMenuItem(string label, PendingIntent pendingIntent)
		{
			nint num = JNIEnv.NewString(label);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(pendingIntent?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addMenuItem.(Ljava/lang/String;Landroid/app/PendingIntent;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(pendingIntent);
			}
		}

		[Obsolete("deprecated")]
		[Register("addToolbarItem", "(ILandroid/graphics/Bitmap;Ljava/lang/String;Landroid/app/PendingIntent;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder AddToolbarItem(int id, Bitmap icon, string description, PendingIntent pendingIntent)
		{
			nint num = JNIEnv.NewString(description);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(id);
				ptr[1] = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(num);
				ptr[3] = new JniArgumentValue(pendingIntent?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addToolbarItem.(ILandroid/graphics/Bitmap;Ljava/lang/String;Landroid/app/PendingIntent;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(icon);
				GC.KeepAlive(pendingIntent);
			}
		}

		[Register("build", "()Landroidx/browser/customtabs/CustomTabsIntent;", "")]
		public unsafe CustomTabsIntent Build()
		{
			return Java.Lang.Object.GetObject<CustomTabsIntent>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Landroidx/browser/customtabs/CustomTabsIntent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Obsolete("deprecated")]
		[Register("enableUrlBarHiding", "()Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder EnableUrlBarHiding()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("enableUrlBarHiding.()Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setActionButton", "(Landroid/graphics/Bitmap;Ljava/lang/String;Landroid/app/PendingIntent;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetActionButton(Bitmap icon, string description, PendingIntent pendingIntent)
		{
			nint num = JNIEnv.NewString(description);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(pendingIntent?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setActionButton.(Landroid/graphics/Bitmap;Ljava/lang/String;Landroid/app/PendingIntent;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(icon);
				GC.KeepAlive(pendingIntent);
			}
		}

		[Register("setActionButton", "(Landroid/graphics/Bitmap;Ljava/lang/String;Landroid/app/PendingIntent;Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetActionButton(Bitmap icon, string description, PendingIntent pendingIntent, bool shouldTint)
		{
			nint num = JNIEnv.NewString(description);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(pendingIntent?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(shouldTint);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setActionButton.(Landroid/graphics/Bitmap;Ljava/lang/String;Landroid/app/PendingIntent;Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(icon);
				GC.KeepAlive(pendingIntent);
			}
		}

		[Register("setActivitySideSheetBreakpointDp", "(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetActivitySideSheetBreakpointDp(int breakpointDp)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(breakpointDp);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setActivitySideSheetBreakpointDp.(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setActivitySideSheetDecorationType", "(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetActivitySideSheetDecorationType(int decorationType)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(decorationType);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setActivitySideSheetDecorationType.(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setActivitySideSheetMaximizationEnabled", "(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetActivitySideSheetMaximizationEnabled(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setActivitySideSheetMaximizationEnabled.(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setActivitySideSheetPosition", "(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetActivitySideSheetPosition(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setActivitySideSheetPosition.(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setActivitySideSheetRoundedCornersPosition", "(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetActivitySideSheetRoundedCornersPosition(int roundedCornersPosition)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(roundedCornersPosition);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setActivitySideSheetRoundedCornersPosition.(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setBackgroundInteractionEnabled", "(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetBackgroundInteractionEnabled(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setBackgroundInteractionEnabled.(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setBookmarksButtonEnabled", "(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetBookmarksButtonEnabled(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setBookmarksButtonEnabled.(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setCloseButtonIcon", "(Landroid/graphics/Bitmap;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetCloseButtonIcon(Bitmap icon)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setCloseButtonIcon.(Landroid/graphics/Bitmap;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(icon);
			}
		}

		[Register("setCloseButtonPosition", "(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetCloseButtonPosition(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setCloseButtonPosition.(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setColorScheme", "(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetColorScheme(int colorScheme)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(colorScheme);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setColorScheme.(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setColorSchemeParams", "(ILandroidx/browser/customtabs/CustomTabColorSchemeParams;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetColorSchemeParams(int colorScheme, CustomTabColorSchemeParams @params)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(colorScheme);
				ptr[1] = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setColorSchemeParams.(ILandroidx/browser/customtabs/CustomTabColorSchemeParams;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(@params);
			}
		}

		[Register("setDefaultColorSchemeParams", "(Landroidx/browser/customtabs/CustomTabColorSchemeParams;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetDefaultColorSchemeParams(CustomTabColorSchemeParams @params)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setDefaultColorSchemeParams.(Landroidx/browser/customtabs/CustomTabColorSchemeParams;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(@params);
			}
		}

		[Obsolete("deprecated")]
		[Register("setDefaultShareMenuItemEnabled", "(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetDefaultShareMenuItemEnabled(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setDefaultShareMenuItemEnabled.(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setDownloadButtonEnabled", "(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetDownloadButtonEnabled(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setDownloadButtonEnabled.(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setExitAnimations", "(Landroid/content/Context;II)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetExitAnimations(Context context, int enterResId, int exitResId)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(enterResId);
				ptr[2] = new JniArgumentValue(exitResId);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setExitAnimations.(Landroid/content/Context;II)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		[Register("setInitialActivityHeightPx", "(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetInitialActivityHeightPx(int initialHeightPx)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(initialHeightPx);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setInitialActivityHeightPx.(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setInitialActivityHeightPx", "(II)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetInitialActivityHeightPx(int initialHeightPx, int activityHeightResizeBehavior)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(initialHeightPx);
			ptr[1] = new JniArgumentValue(activityHeightResizeBehavior);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setInitialActivityHeightPx.(II)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setInitialActivityWidthPx", "(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetInitialActivityWidthPx(int initialWidthPx)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(initialWidthPx);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setInitialActivityWidthPx.(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setInstantAppsEnabled", "(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetInstantAppsEnabled(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setInstantAppsEnabled.(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Obsolete("deprecated")]
		[Register("setNavigationBarColor", "(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetNavigationBarColor(int color)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(color);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setNavigationBarColor.(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Obsolete("deprecated")]
		[Register("setNavigationBarDividerColor", "(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetNavigationBarDividerColor(int color)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(color);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setNavigationBarDividerColor.(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("setPendingSession", "(Landroidx/browser/customtabs/CustomTabsSession$PendingSession;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetPendingSession(CustomTabsSession.PendingSession session)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(session?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setPendingSession.(Landroidx/browser/customtabs/CustomTabsSession$PendingSession;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(session);
			}
		}

		[Obsolete("deprecated")]
		[Register("setSecondaryToolbarColor", "(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetSecondaryToolbarColor(int color)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(color);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setSecondaryToolbarColor.(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setSecondaryToolbarSwipeUpGesture", "(Landroid/app/PendingIntent;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetSecondaryToolbarSwipeUpGesture(PendingIntent? pendingIntent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(pendingIntent?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setSecondaryToolbarSwipeUpGesture.(Landroid/app/PendingIntent;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(pendingIntent);
			}
		}

		[Register("setSecondaryToolbarViews", "(Landroid/widget/RemoteViews;[ILandroid/app/PendingIntent;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetSecondaryToolbarViews(RemoteViews remoteViews, int[]? clickableIDs, PendingIntent? pendingIntent)
		{
			nint num = JNIEnv.NewArray(clickableIDs);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(remoteViews?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(pendingIntent?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setSecondaryToolbarViews.(Landroid/widget/RemoteViews;[ILandroid/app/PendingIntent;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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

		[Register("setSendToExternalDefaultHandlerEnabled", "(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetSendToExternalDefaultHandlerEnabled(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setSendToExternalDefaultHandlerEnabled.(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setSession", "(Landroidx/browser/customtabs/CustomTabsSession;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetSession(CustomTabsSession session)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(session?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setSession.(Landroidx/browser/customtabs/CustomTabsSession;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(session);
			}
		}

		[Register("setShareIdentityEnabled", "(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetShareIdentityEnabled(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setShareIdentityEnabled.(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setShareState", "(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetShareState(int shareState)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(shareState);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setShareState.(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setShowTitle", "(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetShowTitle(bool showTitle)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(showTitle);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setShowTitle.(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setStartAnimations", "(Landroid/content/Context;II)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetStartAnimations(Context context, int enterResId, int exitResId)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(enterResId);
				ptr[2] = new JniArgumentValue(exitResId);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setStartAnimations.(Landroid/content/Context;II)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		[Obsolete("deprecated")]
		[Register("setToolbarColor", "(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetToolbarColor(int color)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(color);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setToolbarColor.(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setToolbarCornerRadiusDp", "(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetToolbarCornerRadiusDp(int cornerRadiusDp)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(cornerRadiusDp);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setToolbarCornerRadiusDp.(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setTranslateLocale", "(Ljava/util/Locale;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetTranslateLocale(Locale locale)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(locale?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setTranslateLocale.(Ljava/util/Locale;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(locale);
			}
		}

		[Register("setUrlBarHidingEnabled", "(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
		public unsafe Builder SetUrlBarHidingEnabled(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setUrlBarHidingEnabled.(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/browser/customtabs/CustomTabsIntent", typeof(CustomTabsIntent));

	[Register("intent")]
	public Intent Intent
	{
		get
		{
			return Java.Lang.Object.GetObject<Intent>(_members.InstanceFields.GetObjectValue("intent.Landroid/content/Intent;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("intent.Landroid/content/Intent;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("startAnimationBundle")]
	public Bundle? StartAnimationBundle
	{
		get
		{
			return Java.Lang.Object.GetObject<Bundle>(_members.InstanceFields.GetObjectValue("startAnimationBundle.Landroid/os/Bundle;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("startAnimationBundle.Landroid/os/Bundle;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

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

	public unsafe static int MaxToolbarItems
	{
		[Register("getMaxToolbarItems", "()I", "")]
		get
		{
			return _members.StaticMethods.InvokeInt32Method("getMaxToolbarItems.()I", null);
		}
	}

	internal CustomTabsIntent(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("getActivityResizeBehavior", "(Landroid/content/Intent;)I", "")]
	public unsafe static int GetActivityResizeBehavior(Intent intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getActivityResizeBehavior.(Landroid/content/Intent;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("getActivitySideSheetBreakpointDp", "(Landroid/content/Intent;)I", "")]
	public unsafe static int GetActivitySideSheetBreakpointDp(Intent intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getActivitySideSheetBreakpointDp.(Landroid/content/Intent;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("getActivitySideSheetDecorationType", "(Landroid/content/Intent;)I", "")]
	public unsafe static int GetActivitySideSheetDecorationType(Intent intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getActivitySideSheetDecorationType.(Landroid/content/Intent;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("getActivitySideSheetPosition", "(Landroid/content/Intent;)I", "")]
	public unsafe static int GetActivitySideSheetPosition(Intent intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getActivitySideSheetPosition.(Landroid/content/Intent;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("getActivitySideSheetRoundedCornersPosition", "(Landroid/content/Intent;)I", "")]
	public unsafe static int GetActivitySideSheetRoundedCornersPosition(Intent intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getActivitySideSheetRoundedCornersPosition.(Landroid/content/Intent;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("getCloseButtonPosition", "(Landroid/content/Intent;)I", "")]
	public unsafe static int GetCloseButtonPosition(Intent intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getCloseButtonPosition.(Landroid/content/Intent;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("getColorSchemeParams", "(Landroid/content/Intent;I)Landroidx/browser/customtabs/CustomTabColorSchemeParams;", "")]
	public unsafe static CustomTabColorSchemeParams GetColorSchemeParams(Intent intent, int colorScheme)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(colorScheme);
			return Java.Lang.Object.GetObject<CustomTabColorSchemeParams>(_members.StaticMethods.InvokeObjectMethod("getColorSchemeParams.(Landroid/content/Intent;I)Landroidx/browser/customtabs/CustomTabColorSchemeParams;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("getInitialActivityHeightPx", "(Landroid/content/Intent;)I", "")]
	public unsafe static int GetInitialActivityHeightPx(Intent intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getInitialActivityHeightPx.(Landroid/content/Intent;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("getInitialActivityWidthPx", "(Landroid/content/Intent;)I", "")]
	public unsafe static int GetInitialActivityWidthPx(Intent intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getInitialActivityWidthPx.(Landroid/content/Intent;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("getSecondaryToolbarSwipeUpGesture", "(Landroid/content/Intent;)Landroid/app/PendingIntent;", "")]
	public unsafe static PendingIntent? GetSecondaryToolbarSwipeUpGesture(Intent intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<PendingIntent>(_members.StaticMethods.InvokeObjectMethod("getSecondaryToolbarSwipeUpGesture.(Landroid/content/Intent;)Landroid/app/PendingIntent;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("getToolbarCornerRadiusDp", "(Landroid/content/Intent;)I", "")]
	public unsafe static int GetToolbarCornerRadiusDp(Intent intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getToolbarCornerRadiusDp.(Landroid/content/Intent;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("getTranslateLocale", "(Landroid/content/Intent;)Ljava/util/Locale;", "")]
	public unsafe static Locale? GetTranslateLocale(Intent intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Locale>(_members.StaticMethods.InvokeObjectMethod("getTranslateLocale.(Landroid/content/Intent;)Ljava/util/Locale;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("isActivitySideSheetMaximizationEnabled", "(Landroid/content/Intent;)Z", "")]
	public unsafe static bool IsActivitySideSheetMaximizationEnabled(Intent intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("isActivitySideSheetMaximizationEnabled.(Landroid/content/Intent;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("isBackgroundInteractionEnabled", "(Landroid/content/Intent;)Z", "")]
	public unsafe static bool IsBackgroundInteractionEnabled(Intent intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("isBackgroundInteractionEnabled.(Landroid/content/Intent;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("isBookmarksButtonEnabled", "(Landroid/content/Intent;)Z", "")]
	public unsafe static bool IsBookmarksButtonEnabled(Intent intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("isBookmarksButtonEnabled.(Landroid/content/Intent;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("isDownloadButtonEnabled", "(Landroid/content/Intent;)Z", "")]
	public unsafe static bool IsDownloadButtonEnabled(Intent intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("isDownloadButtonEnabled.(Landroid/content/Intent;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("isSendToExternalDefaultHandlerEnabled", "(Landroid/content/Intent;)Z", "")]
	public unsafe static bool IsSendToExternalDefaultHandlerEnabled(Intent intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("isSendToExternalDefaultHandlerEnabled.(Landroid/content/Intent;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("launchUrl", "(Landroid/content/Context;Landroid/net/Uri;)V", "")]
	public unsafe void LaunchUrl(Context context, Android.Net.Uri url)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(url?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("launchUrl.(Landroid/content/Context;Landroid/net/Uri;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(url);
		}
	}

	[Register("setAlwaysUseBrowserUI", "(Landroid/content/Intent;)Landroid/content/Intent;", "")]
	public unsafe static Intent SetAlwaysUseBrowserUI(Intent? intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Intent>(_members.StaticMethods.InvokeObjectMethod("setAlwaysUseBrowserUI.(Landroid/content/Intent;)Landroid/content/Intent;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("shouldAlwaysUseBrowserUI", "(Landroid/content/Intent;)Z", "")]
	public unsafe static bool ShouldAlwaysUseBrowserUI(Intent intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("shouldAlwaysUseBrowserUI.(Landroid/content/Intent;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}
}
