using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.Core.Content;
using AndroidX.Core.View;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.App;

[Register("androidx/core/app/ActivityCompat", DoNotGenerateAcw = true)]
public class ActivityCompat : ContextCompat
{
	[Register("androidx/core/app/ActivityCompat$PermissionCompatDelegate", "", "AndroidX.Core.App.ActivityCompat/IPermissionCompatDelegateInvoker")]
	public interface IPermissionCompatDelegate : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onActivityResult", "(Landroid/app/Activity;IILandroid/content/Intent;)Z", "GetOnActivityResult_Landroid_app_Activity_IILandroid_content_Intent_Handler:AndroidX.Core.App.ActivityCompat/IPermissionCompatDelegateInvoker, Xamarin.AndroidX.Core")]
		bool OnActivityResult(Activity? activity, int requestCode, int resultCode, Intent? data);

		[Register("requestPermissions", "(Landroid/app/Activity;[Ljava/lang/String;I)Z", "GetRequestPermissions_Landroid_app_Activity_arrayLjava_lang_String_IHandler:AndroidX.Core.App.ActivityCompat/IPermissionCompatDelegateInvoker, Xamarin.AndroidX.Core")]
		bool RequestPermissions(Activity? activity, string[]? permissions, int requestCode);
	}

	[Register("androidx/core/app/ActivityCompat$PermissionCompatDelegate", DoNotGenerateAcw = true)]
	internal class IPermissionCompatDelegateInvoker : Java.Lang.Object, IPermissionCompatDelegate, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_core_app_ActivityCompat_PermissionCompatDelegate = new XAPeerMembers("androidx/core/app/ActivityCompat$PermissionCompatDelegate", typeof(IPermissionCompatDelegateInvoker));

		private static Delegate? cb_onActivityResult_OnActivityResult_Landroid_app_Activity_IILandroid_content_Intent__Z;

		private static Delegate? cb_requestPermissions_RequestPermissions_Landroid_app_Activity_arrayLjava_lang_String_I_Z;

		private static nint java_class_ref => _members_androidx_core_app_ActivityCompat_PermissionCompatDelegate.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_core_app_ActivityCompat_PermissionCompatDelegate;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_core_app_ActivityCompat_PermissionCompatDelegate.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_core_app_ActivityCompat_PermissionCompatDelegate.ManagedPeerType;

		public IPermissionCompatDelegateInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnActivityResult_Landroid_app_Activity_IILandroid_content_Intent_Handler()
		{
			return new _JniMarshal_PPLIIL_B(n_OnActivityResult_Landroid_app_Activity_IILandroid_content_Intent_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnActivityResult_Landroid_app_Activity_IILandroid_content_Intent_(nint jnienv, nint native__this, nint native_activity, int requestCode, int resultCode, nint native_data)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IPermissionCompatDelegate? permissionCompatDelegate = Java.Lang.Object.GetObject<IPermissionCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
				Intent data = Java.Lang.Object.GetObject<Intent>(native_data, JniHandleOwnership.DoNotTransfer);
				return permissionCompatDelegate.OnActivityResult(activity, requestCode, resultCode, data) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool OnActivityResult(Activity? activity, int requestCode, int resultCode, Intent? data)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(requestCode);
				ptr[2] = new JniArgumentValue(resultCode);
				ptr[3] = new JniArgumentValue(data?.Handle ?? IntPtr.Zero);
				return _members_androidx_core_app_ActivityCompat_PermissionCompatDelegate.InstanceMethods.InvokeAbstractBooleanMethod("onActivityResult.(Landroid/app/Activity;IILandroid/content/Intent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
				GC.KeepAlive(data);
			}
		}

		private static Delegate GetRequestPermissions_Landroid_app_Activity_arrayLjava_lang_String_IHandler()
		{
			return new global::_JniMarshal_PPLLI_B(n_RequestPermissions_Landroid_app_Activity_arrayLjava_lang_String_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_RequestPermissions_Landroid_app_Activity_arrayLjava_lang_String_I(nint jnienv, nint native__this, nint native_activity, nint native_permissions, int requestCode)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IPermissionCompatDelegate? permissionCompatDelegate = Java.Lang.Object.GetObject<IPermissionCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
				string[] array = (string[])JNIEnv.GetArray(native_permissions, JniHandleOwnership.DoNotTransfer, typeof(string));
				sbyte result = (permissionCompatDelegate.RequestPermissions(activity, array, requestCode) ? ((sbyte)1) : ((sbyte)0));
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_permissions);
				}
				return result;
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

		public unsafe bool RequestPermissions(Activity? activity, string[]? permissions, int requestCode)
		{
			nint num = JNIEnv.NewArray(permissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(requestCode);
				return _members_androidx_core_app_ActivityCompat_PermissionCompatDelegate.InstanceMethods.InvokeAbstractBooleanMethod("requestPermissions.(Landroid/app/Activity;[Ljava/lang/String;I)Z", this, ptr);
			}
			finally
			{
				if (permissions != null)
				{
					JNIEnv.CopyArray(num, permissions);
					JNIEnv.DeleteLocalRef(num);
				}
				GC.KeepAlive(activity);
				GC.KeepAlive(permissions);
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/app/ActivityCompat", typeof(ActivityCompat));

	internal new static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe static IPermissionCompatDelegate? PermissionCompatDelegate
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getPermissionCompatDelegate", "()Landroidx/core/app/ActivityCompat$PermissionCompatDelegate;", "")]
		get
		{
			return Java.Lang.Object.GetObject<IPermissionCompatDelegate>(_members.StaticMethods.InvokeObjectMethod("getPermissionCompatDelegate.()Landroidx/core/app/ActivityCompat$PermissionCompatDelegate;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setPermissionCompatDelegate", "(Landroidx/core/app/ActivityCompat$PermissionCompatDelegate;)V", "")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members.StaticMethods.InvokeVoidMethod("setPermissionCompatDelegate.(Landroidx/core/app/ActivityCompat$PermissionCompatDelegate;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	protected ActivityCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	protected unsafe ActivityCompat()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register("finishAffinity", "(Landroid/app/Activity;)V", "")]
	public unsafe static void FinishAffinity(Activity? activity)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("finishAffinity.(Landroid/app/Activity;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(activity);
		}
	}

	[Register("finishAfterTransition", "(Landroid/app/Activity;)V", "")]
	public unsafe static void FinishAfterTransition(Activity? activity)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("finishAfterTransition.(Landroid/app/Activity;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(activity);
		}
	}

	[Register("getReferrer", "(Landroid/app/Activity;)Landroid/net/Uri;", "")]
	public unsafe static Uri? GetReferrer(Activity? activity)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Uri>(_members.StaticMethods.InvokeObjectMethod("getReferrer.(Landroid/app/Activity;)Landroid/net/Uri;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(activity);
		}
	}

	[Obsolete("deprecated")]
	[Register("invalidateOptionsMenu", "(Landroid/app/Activity;)Z", "")]
	public unsafe static bool InvalidateOptionsMenu(Activity? activity)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("invalidateOptionsMenu.(Landroid/app/Activity;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(activity);
		}
	}

	[Register("isLaunchedFromBubble", "(Landroid/app/Activity;)Z", "")]
	public unsafe static bool IsLaunchedFromBubble(Activity? activity)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("isLaunchedFromBubble.(Landroid/app/Activity;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(activity);
		}
	}

	[Register("postponeEnterTransition", "(Landroid/app/Activity;)V", "")]
	public unsafe static void PostponeEnterTransition(Activity? activity)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("postponeEnterTransition.(Landroid/app/Activity;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(activity);
		}
	}

	[Register("recreate", "(Landroid/app/Activity;)V", "")]
	public unsafe static void Recreate(Activity? activity)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("recreate.(Landroid/app/Activity;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(activity);
		}
	}

	[Register("requestDragAndDropPermissions", "(Landroid/app/Activity;Landroid/view/DragEvent;)Landroidx/core/view/DragAndDropPermissionsCompat;", "")]
	public unsafe static DragAndDropPermissionsCompat? RequestDragAndDropPermissions(Activity? activity, DragEvent? dragEvent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(dragEvent?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<DragAndDropPermissionsCompat>(_members.StaticMethods.InvokeObjectMethod("requestDragAndDropPermissions.(Landroid/app/Activity;Landroid/view/DragEvent;)Landroidx/core/view/DragAndDropPermissionsCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(activity);
			GC.KeepAlive(dragEvent);
		}
	}

	[Register("requestPermissions", "(Landroid/app/Activity;[Ljava/lang/String;I)V", "")]
	public unsafe static void RequestPermissions(Activity? activity, string[]? permissions, int requestCode)
	{
		nint num = JNIEnv.NewArray(permissions);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(requestCode);
			_members.StaticMethods.InvokeVoidMethod("requestPermissions.(Landroid/app/Activity;[Ljava/lang/String;I)V", ptr);
		}
		finally
		{
			if (permissions != null)
			{
				JNIEnv.CopyArray(num, permissions);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(activity);
			GC.KeepAlive(permissions);
		}
	}

	[Register("requireViewById", "(Landroid/app/Activity;I)Landroid/view/View;", "")]
	[JavaTypeParameters(new string[] { "T extends android.view.View" })]
	public unsafe static Java.Lang.Object? RequireViewById(Activity? activity, int id)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(id);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("requireViewById.(Landroid/app/Activity;I)Landroid/view/View;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(activity);
		}
	}

	[Register("setEnterSharedElementCallback", "(Landroid/app/Activity;Landroidx/core/app/SharedElementCallback;)V", "")]
	public unsafe static void SetEnterSharedElementCallback(Activity? activity, SharedElementCallback? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("setEnterSharedElementCallback.(Landroid/app/Activity;Landroidx/core/app/SharedElementCallback;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(activity);
			GC.KeepAlive(callback);
		}
	}

	[Register("setExitSharedElementCallback", "(Landroid/app/Activity;Landroidx/core/app/SharedElementCallback;)V", "")]
	public unsafe static void SetExitSharedElementCallback(Activity? activity, SharedElementCallback? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("setExitSharedElementCallback.(Landroid/app/Activity;Landroidx/core/app/SharedElementCallback;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(activity);
			GC.KeepAlive(callback);
		}
	}

	[Register("setLocusContext", "(Landroid/app/Activity;Landroidx/core/content/LocusIdCompat;Landroid/os/Bundle;)V", "")]
	public unsafe static void SetLocusContext(Activity? activity, LocusIdCompat? locusId, Bundle? bundle)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(locusId?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(bundle?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("setLocusContext.(Landroid/app/Activity;Landroidx/core/content/LocusIdCompat;Landroid/os/Bundle;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(activity);
			GC.KeepAlive(locusId);
			GC.KeepAlive(bundle);
		}
	}

	[Register("shouldShowRequestPermissionRationale", "(Landroid/app/Activity;Ljava/lang/String;)Z", "")]
	public unsafe static bool ShouldShowRequestPermissionRationale(Activity? activity, string? permission)
	{
		nint num = JNIEnv.NewString(permission);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return _members.StaticMethods.InvokeBooleanMethod("shouldShowRequestPermissionRationale.(Landroid/app/Activity;Ljava/lang/String;)Z", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(activity);
		}
	}

	[Register("startActivityForResult", "(Landroid/app/Activity;Landroid/content/Intent;ILandroid/os/Bundle;)V", "")]
	public unsafe static void StartActivityForResult(Activity? activity, Intent? intent, int requestCode, Bundle? options)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(requestCode);
			ptr[3] = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("startActivityForResult.(Landroid/app/Activity;Landroid/content/Intent;ILandroid/os/Bundle;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(activity);
			GC.KeepAlive(intent);
			GC.KeepAlive(options);
		}
	}

	[Register("startIntentSenderForResult", "(Landroid/app/Activity;Landroid/content/IntentSender;ILandroid/content/Intent;IIILandroid/os/Bundle;)V", "")]
	public unsafe static void StartIntentSenderForResult(Activity? activity, IntentSender? intent, int requestCode, Intent? fillInIntent, int flagsMask, int flagsValues, int extraFlags, Bundle? options)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(requestCode);
			ptr[3] = new JniArgumentValue(fillInIntent?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(flagsMask);
			ptr[5] = new JniArgumentValue(flagsValues);
			ptr[6] = new JniArgumentValue(extraFlags);
			ptr[7] = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("startIntentSenderForResult.(Landroid/app/Activity;Landroid/content/IntentSender;ILandroid/content/Intent;IIILandroid/os/Bundle;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(activity);
			GC.KeepAlive(intent);
			GC.KeepAlive(fillInIntent);
			GC.KeepAlive(options);
		}
	}

	[Register("startPostponedEnterTransition", "(Landroid/app/Activity;)V", "")]
	public unsafe static void StartPostponedEnterTransition(Activity? activity)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("startPostponedEnterTransition.(Landroid/app/Activity;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(activity);
		}
	}
}
