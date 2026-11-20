using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.Core.Util;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.App;

[Register("androidx/core/app/ActivityOptionsCompat", DoNotGenerateAcw = true)]
public class ActivityOptionsCompat : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/app/ActivityOptionsCompat", typeof(ActivityOptionsCompat));

	private static Delegate? cb_getLaunchBounds_GetLaunchBounds_Landroid_graphics_Rect_;

	private static Delegate? cb_getLaunchDisplayId_GetLaunchDisplayId_I;

	private static Delegate? cb_requestUsageTimeReport_RequestUsageTimeReport_Landroid_app_PendingIntent__V;

	private static Delegate? cb_setLaunchBounds_SetLaunchBounds_Landroid_graphics_Rect__Landroidx_core_app_ActivityOptionsCompat_;

	private static Delegate? cb_setLaunchDisplayId_SetLaunchDisplayId_I_Landroidx_core_app_ActivityOptionsCompat_;

	private static Delegate? cb_setPendingIntentBackgroundActivityStartMode_SetPendingIntentBackgroundActivityStartMode_I_Landroidx_core_app_ActivityOptionsCompat_;

	private static Delegate? cb_setShareIdentityEnabled_SetShareIdentityEnabled_Z_Landroidx_core_app_ActivityOptionsCompat_;

	private static Delegate? cb_toBundle_ToBundle_Landroid_os_Bundle_;

	private static Delegate? cb_update_Update_Landroidx_core_app_ActivityOptionsCompat__V;

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

	public unsafe virtual Rect? LaunchBounds
	{
		[Register("getLaunchBounds", "()Landroid/graphics/Rect;", "GetGetLaunchBoundsHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Rect>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLaunchBounds.()Landroid/graphics/Rect;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int LaunchDisplayId
	{
		[Register("getLaunchDisplayId", "()I", "GetGetLaunchDisplayIdHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getLaunchDisplayId.()I", this, null);
		}
	}

	protected ActivityOptionsCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	protected unsafe ActivityOptionsCompat()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetLaunchBoundsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetLaunchBounds);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetLaunchBounds(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ActivityOptionsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LaunchBounds);
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

	private static Delegate GetGetLaunchDisplayIdHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetLaunchDisplayId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetLaunchDisplayId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ActivityOptionsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LaunchDisplayId;
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

	[Register("makeBasic", "()Landroidx/core/app/ActivityOptionsCompat;", "")]
	public unsafe static ActivityOptionsCompat? MakeBasic()
	{
		return Java.Lang.Object.GetObject<ActivityOptionsCompat>(_members.StaticMethods.InvokeObjectMethod("makeBasic.()Landroidx/core/app/ActivityOptionsCompat;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("makeClipRevealAnimation", "(Landroid/view/View;IIII)Landroidx/core/app/ActivityOptionsCompat;", "")]
	public unsafe static ActivityOptionsCompat? MakeClipRevealAnimation(Android.Views.View? source, int startX, int startY, int width, int height)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(startX);
			ptr[2] = new JniArgumentValue(startY);
			ptr[3] = new JniArgumentValue(width);
			ptr[4] = new JniArgumentValue(height);
			return Java.Lang.Object.GetObject<ActivityOptionsCompat>(_members.StaticMethods.InvokeObjectMethod("makeClipRevealAnimation.(Landroid/view/View;IIII)Landroidx/core/app/ActivityOptionsCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(source);
		}
	}

	[Register("makeCustomAnimation", "(Landroid/content/Context;II)Landroidx/core/app/ActivityOptionsCompat;", "")]
	public unsafe static ActivityOptionsCompat? MakeCustomAnimation(Context? context, int enterResId, int exitResId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(enterResId);
			ptr[2] = new JniArgumentValue(exitResId);
			return Java.Lang.Object.GetObject<ActivityOptionsCompat>(_members.StaticMethods.InvokeObjectMethod("makeCustomAnimation.(Landroid/content/Context;II)Landroidx/core/app/ActivityOptionsCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("makeScaleUpAnimation", "(Landroid/view/View;IIII)Landroidx/core/app/ActivityOptionsCompat;", "")]
	public unsafe static ActivityOptionsCompat? MakeScaleUpAnimation(Android.Views.View? source, int startX, int startY, int startWidth, int startHeight)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(startX);
			ptr[2] = new JniArgumentValue(startY);
			ptr[3] = new JniArgumentValue(startWidth);
			ptr[4] = new JniArgumentValue(startHeight);
			return Java.Lang.Object.GetObject<ActivityOptionsCompat>(_members.StaticMethods.InvokeObjectMethod("makeScaleUpAnimation.(Landroid/view/View;IIII)Landroidx/core/app/ActivityOptionsCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(source);
		}
	}

	[Register("makeSceneTransitionAnimation", "(Landroid/app/Activity;Landroid/view/View;Ljava/lang/String;)Landroidx/core/app/ActivityOptionsCompat;", "")]
	public unsafe static ActivityOptionsCompat? MakeSceneTransitionAnimation(Activity? activity, Android.Views.View? sharedElement, string? sharedElementName)
	{
		nint num = JNIEnv.NewString(sharedElementName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(sharedElement?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ActivityOptionsCompat>(_members.StaticMethods.InvokeObjectMethod("makeSceneTransitionAnimation.(Landroid/app/Activity;Landroid/view/View;Ljava/lang/String;)Landroidx/core/app/ActivityOptionsCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(activity);
			GC.KeepAlive(sharedElement);
		}
	}

	[Register("makeSceneTransitionAnimation", "(Landroid/app/Activity;[Landroidx/core/util/Pair;)Landroidx/core/app/ActivityOptionsCompat;", "")]
	public unsafe static ActivityOptionsCompat? MakeSceneTransitionAnimation(Activity? activity, params Pair[]? sharedElements)
	{
		nint num = JNIEnv.NewArray(sharedElements);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ActivityOptionsCompat>(_members.StaticMethods.InvokeObjectMethod("makeSceneTransitionAnimation.(Landroid/app/Activity;[Landroidx/core/util/Pair;)Landroidx/core/app/ActivityOptionsCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (sharedElements != null)
			{
				JNIEnv.CopyArray(num, sharedElements);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(activity);
			GC.KeepAlive(sharedElements);
		}
	}

	[Register("makeTaskLaunchBehind", "()Landroidx/core/app/ActivityOptionsCompat;", "")]
	public unsafe static ActivityOptionsCompat? MakeTaskLaunchBehind()
	{
		return Java.Lang.Object.GetObject<ActivityOptionsCompat>(_members.StaticMethods.InvokeObjectMethod("makeTaskLaunchBehind.()Landroidx/core/app/ActivityOptionsCompat;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("makeThumbnailScaleUpAnimation", "(Landroid/view/View;Landroid/graphics/Bitmap;II)Landroidx/core/app/ActivityOptionsCompat;", "")]
	public unsafe static ActivityOptionsCompat? MakeThumbnailScaleUpAnimation(Android.Views.View? source, Bitmap? thumbnail, int startX, int startY)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(thumbnail?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(startX);
			ptr[3] = new JniArgumentValue(startY);
			return Java.Lang.Object.GetObject<ActivityOptionsCompat>(_members.StaticMethods.InvokeObjectMethod("makeThumbnailScaleUpAnimation.(Landroid/view/View;Landroid/graphics/Bitmap;II)Landroidx/core/app/ActivityOptionsCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(source);
			GC.KeepAlive(thumbnail);
		}
	}

	private static Delegate GetRequestUsageTimeReport_Landroid_app_PendingIntent_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RequestUsageTimeReport_Landroid_app_PendingIntent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RequestUsageTimeReport_Landroid_app_PendingIntent_(nint jnienv, nint native__this, nint native_receiver)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActivityOptionsCompat? activityOptionsCompat = Java.Lang.Object.GetObject<ActivityOptionsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PendingIntent receiver = Java.Lang.Object.GetObject<PendingIntent>(native_receiver, JniHandleOwnership.DoNotTransfer);
			activityOptionsCompat.RequestUsageTimeReport(receiver);
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

	[Register("requestUsageTimeReport", "(Landroid/app/PendingIntent;)V", "GetRequestUsageTimeReport_Landroid_app_PendingIntent_Handler")]
	public unsafe virtual void RequestUsageTimeReport(PendingIntent? receiver)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(receiver?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("requestUsageTimeReport.(Landroid/app/PendingIntent;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(receiver);
		}
	}

	private static Delegate GetSetLaunchBounds_Landroid_graphics_Rect_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_SetLaunchBounds_Landroid_graphics_Rect_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetLaunchBounds_Landroid_graphics_Rect_(nint jnienv, nint native__this, nint native_screenSpacePixelRect)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ActivityOptionsCompat? activityOptionsCompat = Java.Lang.Object.GetObject<ActivityOptionsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Rect launchBounds = Java.Lang.Object.GetObject<Rect>(native_screenSpacePixelRect, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(activityOptionsCompat.SetLaunchBounds(launchBounds));
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

	[Register("setLaunchBounds", "(Landroid/graphics/Rect;)Landroidx/core/app/ActivityOptionsCompat;", "GetSetLaunchBounds_Landroid_graphics_Rect_Handler")]
	public unsafe virtual ActivityOptionsCompat? SetLaunchBounds(Rect? screenSpacePixelRect)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(screenSpacePixelRect?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ActivityOptionsCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("setLaunchBounds.(Landroid/graphics/Rect;)Landroidx/core/app/ActivityOptionsCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(screenSpacePixelRect);
		}
	}

	private static Delegate GetSetLaunchDisplayId_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetLaunchDisplayId_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetLaunchDisplayId_I(nint jnienv, nint native__this, int launchDisplayId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ActivityOptionsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetLaunchDisplayId(launchDisplayId));
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

	[Register("setLaunchDisplayId", "(I)Landroidx/core/app/ActivityOptionsCompat;", "GetSetLaunchDisplayId_IHandler")]
	public unsafe virtual ActivityOptionsCompat? SetLaunchDisplayId(int launchDisplayId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(launchDisplayId);
		return Java.Lang.Object.GetObject<ActivityOptionsCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("setLaunchDisplayId.(I)Landroidx/core/app/ActivityOptionsCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetPendingIntentBackgroundActivityStartMode_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetPendingIntentBackgroundActivityStartMode_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetPendingIntentBackgroundActivityStartMode_I(nint jnienv, nint native__this, int state)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ActivityOptionsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPendingIntentBackgroundActivityStartMode(state));
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

	[Register("setPendingIntentBackgroundActivityStartMode", "(I)Landroidx/core/app/ActivityOptionsCompat;", "GetSetPendingIntentBackgroundActivityStartMode_IHandler")]
	public unsafe virtual ActivityOptionsCompat? SetPendingIntentBackgroundActivityStartMode(int state)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(state);
		return Java.Lang.Object.GetObject<ActivityOptionsCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("setPendingIntentBackgroundActivityStartMode.(I)Landroidx/core/app/ActivityOptionsCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetShareIdentityEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_L(n_SetShareIdentityEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetShareIdentityEnabled_Z(nint jnienv, nint native__this, sbyte native_shareIdentity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ActivityOptionsCompat? activityOptionsCompat = Java.Lang.Object.GetObject<ActivityOptionsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool shareIdentityEnabled = native_shareIdentity != 0;
			return JNIEnv.ToLocalJniHandle(activityOptionsCompat.SetShareIdentityEnabled(shareIdentityEnabled));
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

	[Register("setShareIdentityEnabled", "(Z)Landroidx/core/app/ActivityOptionsCompat;", "GetSetShareIdentityEnabled_ZHandler")]
	public unsafe virtual ActivityOptionsCompat? SetShareIdentityEnabled(bool shareIdentity)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(shareIdentity ? ((sbyte)1) : ((sbyte)0));
		return Java.Lang.Object.GetObject<ActivityOptionsCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("setShareIdentityEnabled.(Z)Landroidx/core/app/ActivityOptionsCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetToBundleHandler()
	{
		return new global::_JniMarshal_PP_L(n_ToBundle);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ToBundle(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ActivityOptionsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToBundle());
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

	[Register("toBundle", "()Landroid/os/Bundle;", "GetToBundleHandler")]
	public unsafe virtual Bundle? ToBundle()
	{
		return Java.Lang.Object.GetObject<Bundle>(_members.InstanceMethods.InvokeVirtualObjectMethod("toBundle.()Landroid/os/Bundle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetUpdate_Landroidx_core_app_ActivityOptionsCompat_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Update_Landroidx_core_app_ActivityOptionsCompat_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Update_Landroidx_core_app_ActivityOptionsCompat_(nint jnienv, nint native__this, nint native_otherOptions)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActivityOptionsCompat? activityOptionsCompat = Java.Lang.Object.GetObject<ActivityOptionsCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ActivityOptionsCompat otherOptions = Java.Lang.Object.GetObject<ActivityOptionsCompat>(native_otherOptions, JniHandleOwnership.DoNotTransfer);
			activityOptionsCompat.Update(otherOptions);
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

	[Register("update", "(Landroidx/core/app/ActivityOptionsCompat;)V", "GetUpdate_Landroidx_core_app_ActivityOptionsCompat_Handler")]
	public unsafe virtual void Update(ActivityOptionsCompat? otherOptions)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(otherOptions?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("update.(Landroidx/core/app/ActivityOptionsCompat;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(otherOptions);
		}
	}
}
