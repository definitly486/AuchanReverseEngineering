using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.Activity;
using AndroidX.Fragment.App.StrictMode;
using AndroidX.Lifecycle;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Fragment.App;

[Register("androidx/fragment/app/FragmentManager", DoNotGenerateAcw = true)]
public abstract class FragmentManager : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("androidx/fragment/app/FragmentManager$BackStackEntry", "", "AndroidX.Fragment.App.FragmentManager/IBackStackEntryInvoker")]
	public interface IBackStackEntry : IJavaObject, IDisposable, IJavaPeerable
	{
		ICharSequence? BreadCrumbShortTitleFormatted
		{
			[Register("getBreadCrumbShortTitle", "()Ljava/lang/CharSequence;", "GetGetBreadCrumbShortTitleHandler:AndroidX.Fragment.App.FragmentManager/IBackStackEntryInvoker, Xamarin.AndroidX.Fragment")]
			get;
		}

		int BreadCrumbShortTitleRes
		{
			[Register("getBreadCrumbShortTitleRes", "()I", "GetGetBreadCrumbShortTitleResHandler:AndroidX.Fragment.App.FragmentManager/IBackStackEntryInvoker, Xamarin.AndroidX.Fragment")]
			get;
		}

		ICharSequence? BreadCrumbTitleFormatted
		{
			[Register("getBreadCrumbTitle", "()Ljava/lang/CharSequence;", "GetGetBreadCrumbTitleHandler:AndroidX.Fragment.App.FragmentManager/IBackStackEntryInvoker, Xamarin.AndroidX.Fragment")]
			get;
		}

		int BreadCrumbTitleRes
		{
			[Register("getBreadCrumbTitleRes", "()I", "GetGetBreadCrumbTitleResHandler:AndroidX.Fragment.App.FragmentManager/IBackStackEntryInvoker, Xamarin.AndroidX.Fragment")]
			get;
		}

		int Id
		{
			[Register("getId", "()I", "GetGetIdHandler:AndroidX.Fragment.App.FragmentManager/IBackStackEntryInvoker, Xamarin.AndroidX.Fragment")]
			get;
		}

		string? Name
		{
			[Register("getName", "()Ljava/lang/String;", "GetGetNameHandler:AndroidX.Fragment.App.FragmentManager/IBackStackEntryInvoker, Xamarin.AndroidX.Fragment")]
			get;
		}
	}

	[Register("androidx/fragment/app/FragmentManager$BackStackEntry", DoNotGenerateAcw = true)]
	internal class IBackStackEntryInvoker : Java.Lang.Object, IBackStackEntry, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_fragment_app_FragmentManager_BackStackEntry = new XAPeerMembers("androidx/fragment/app/FragmentManager$BackStackEntry", typeof(IBackStackEntryInvoker));

		private static Delegate? cb_getBreadCrumbShortTitle_GetBreadCrumbShortTitle_Ljava_lang_CharSequence_;

		private static Delegate? cb_getBreadCrumbShortTitleRes_GetBreadCrumbShortTitleRes_I;

		private static Delegate? cb_getBreadCrumbTitle_GetBreadCrumbTitle_Ljava_lang_CharSequence_;

		private static Delegate? cb_getBreadCrumbTitleRes_GetBreadCrumbTitleRes_I;

		private static Delegate? cb_getId_GetId_I;

		private static Delegate? cb_getName_GetName_Ljava_lang_String_;

		private static nint java_class_ref => _members_androidx_fragment_app_FragmentManager_BackStackEntry.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_fragment_app_FragmentManager_BackStackEntry;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_fragment_app_FragmentManager_BackStackEntry.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_fragment_app_FragmentManager_BackStackEntry.ManagedPeerType;

		public unsafe ICharSequence? BreadCrumbShortTitleFormatted => Java.Lang.Object.GetObject<ICharSequence>(_members_androidx_fragment_app_FragmentManager_BackStackEntry.InstanceMethods.InvokeAbstractObjectMethod("getBreadCrumbShortTitle.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

		public unsafe int BreadCrumbShortTitleRes => _members_androidx_fragment_app_FragmentManager_BackStackEntry.InstanceMethods.InvokeAbstractInt32Method("getBreadCrumbShortTitleRes.()I", this, null);

		public unsafe ICharSequence? BreadCrumbTitleFormatted => Java.Lang.Object.GetObject<ICharSequence>(_members_androidx_fragment_app_FragmentManager_BackStackEntry.InstanceMethods.InvokeAbstractObjectMethod("getBreadCrumbTitle.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

		public unsafe int BreadCrumbTitleRes => _members_androidx_fragment_app_FragmentManager_BackStackEntry.InstanceMethods.InvokeAbstractInt32Method("getBreadCrumbTitleRes.()I", this, null);

		public unsafe int Id => _members_androidx_fragment_app_FragmentManager_BackStackEntry.InstanceMethods.InvokeAbstractInt32Method("getId.()I", this, null);

		public unsafe string? Name => JNIEnv.GetString(_members_androidx_fragment_app_FragmentManager_BackStackEntry.InstanceMethods.InvokeAbstractObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

		public IBackStackEntryInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Obsolete]
		private static Delegate GetGetBreadCrumbShortTitleHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetBreadCrumbShortTitle);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetBreadCrumbShortTitle(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<IBackStackEntry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BreadCrumbShortTitleFormatted);
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

		[Obsolete]
		private static Delegate GetGetBreadCrumbShortTitleResHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetBreadCrumbShortTitleRes);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetBreadCrumbShortTitleRes(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<IBackStackEntry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BreadCrumbShortTitleRes;
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

		[Obsolete]
		private static Delegate GetGetBreadCrumbTitleHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetBreadCrumbTitle);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetBreadCrumbTitle(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<IBackStackEntry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BreadCrumbTitleFormatted);
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

		[Obsolete]
		private static Delegate GetGetBreadCrumbTitleResHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetBreadCrumbTitleRes);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetBreadCrumbTitleRes(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<IBackStackEntry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BreadCrumbTitleRes;
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

		private static Delegate GetGetIdHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetId);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetId(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<IBackStackEntry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id;
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

		private static Delegate GetGetNameHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetName);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetName(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IBackStackEntry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Name);
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

	[Register("androidx/fragment/app/FragmentManager$FragmentLifecycleCallbacks", DoNotGenerateAcw = true)]
	public abstract class FragmentLifecycleCallbacks : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentManager$FragmentLifecycleCallbacks", typeof(FragmentLifecycleCallbacks));

		private static Delegate? cb_onFragmentActivityCreated_OnFragmentActivityCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle__V;

		private static Delegate? cb_onFragmentAttached_OnFragmentAttached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_content_Context__V;

		private static Delegate? cb_onFragmentCreated_OnFragmentCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle__V;

		private static Delegate? cb_onFragmentDestroyed_OnFragmentDestroyed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment__V;

		private static Delegate? cb_onFragmentDetached_OnFragmentDetached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment__V;

		private static Delegate? cb_onFragmentPaused_OnFragmentPaused_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment__V;

		private static Delegate? cb_onFragmentPreAttached_OnFragmentPreAttached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_content_Context__V;

		private static Delegate? cb_onFragmentPreCreated_OnFragmentPreCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle__V;

		private static Delegate? cb_onFragmentResumed_OnFragmentResumed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment__V;

		private static Delegate? cb_onFragmentSaveInstanceState_OnFragmentSaveInstanceState_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle__V;

		private static Delegate? cb_onFragmentStarted_OnFragmentStarted_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment__V;

		private static Delegate? cb_onFragmentStopped_OnFragmentStopped_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment__V;

		private static Delegate? cb_onFragmentViewCreated_OnFragmentViewCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_view_View_Landroid_os_Bundle__V;

		private static Delegate? cb_onFragmentViewDestroyed_OnFragmentViewDestroyed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment__V;

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

		protected FragmentLifecycleCallbacks(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe FragmentLifecycleCallbacks()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Obsolete]
		private static Delegate GetOnFragmentActivityCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_Handler()
		{
			return new global::_JniMarshal_PPLLL_V(n_OnFragmentActivityCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnFragmentActivityCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_fm, nint native_f, nint native_savedInstanceState)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				FragmentLifecycleCallbacks? fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
				Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
				Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
				fragmentLifecycleCallbacks.OnFragmentActivityCreated(fm, f, savedInstanceState);
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

		[Obsolete("deprecated")]
		[Register("onFragmentActivityCreated", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/os/Bundle;)V", "GetOnFragmentActivityCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_Handler")]
		public unsafe virtual void OnFragmentActivityCreated(FragmentManager fm, Fragment f, Bundle? savedInstanceState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentActivityCreated.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
				GC.KeepAlive(savedInstanceState);
			}
		}

		private static Delegate GetOnFragmentAttached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_content_Context_Handler()
		{
			return new global::_JniMarshal_PPLLL_V(n_OnFragmentAttached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_content_Context_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnFragmentAttached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_content_Context_(nint jnienv, nint native__this, nint native_fm, nint native_f, nint native_context)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				FragmentLifecycleCallbacks? fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
				Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
				Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
				fragmentLifecycleCallbacks.OnFragmentAttached(fm, f, context);
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

		[Register("onFragmentAttached", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/content/Context;)V", "GetOnFragmentAttached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_content_Context_Handler")]
		public unsafe virtual void OnFragmentAttached(FragmentManager fm, Fragment f, Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentAttached.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/content/Context;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetOnFragmentCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_Handler()
		{
			return new global::_JniMarshal_PPLLL_V(n_OnFragmentCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnFragmentCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_fm, nint native_f, nint native_savedInstanceState)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				FragmentLifecycleCallbacks? fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
				Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
				Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
				fragmentLifecycleCallbacks.OnFragmentCreated(fm, f, savedInstanceState);
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

		[Register("onFragmentCreated", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/os/Bundle;)V", "GetOnFragmentCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_Handler")]
		public unsafe virtual void OnFragmentCreated(FragmentManager fm, Fragment f, Bundle? savedInstanceState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentCreated.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
				GC.KeepAlive(savedInstanceState);
			}
		}

		private static Delegate GetOnFragmentDestroyed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler()
		{
			return new global::_JniMarshal_PPLL_V(n_OnFragmentDestroyed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnFragmentDestroyed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_(nint jnienv, nint native__this, nint native_fm, nint native_f)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				FragmentLifecycleCallbacks? fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
				Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
				fragmentLifecycleCallbacks.OnFragmentDestroyed(fm, f);
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

		[Register("onFragmentDestroyed", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", "GetOnFragmentDestroyed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler")]
		public unsafe virtual void OnFragmentDestroyed(FragmentManager fm, Fragment f)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentDestroyed.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
			}
		}

		private static Delegate GetOnFragmentDetached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler()
		{
			return new global::_JniMarshal_PPLL_V(n_OnFragmentDetached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnFragmentDetached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_(nint jnienv, nint native__this, nint native_fm, nint native_f)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				FragmentLifecycleCallbacks? fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
				Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
				fragmentLifecycleCallbacks.OnFragmentDetached(fm, f);
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

		[Register("onFragmentDetached", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", "GetOnFragmentDetached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler")]
		public unsafe virtual void OnFragmentDetached(FragmentManager fm, Fragment f)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentDetached.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
			}
		}

		private static Delegate GetOnFragmentPaused_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler()
		{
			return new global::_JniMarshal_PPLL_V(n_OnFragmentPaused_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnFragmentPaused_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_(nint jnienv, nint native__this, nint native_fm, nint native_f)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				FragmentLifecycleCallbacks? fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
				Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
				fragmentLifecycleCallbacks.OnFragmentPaused(fm, f);
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

		[Register("onFragmentPaused", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", "GetOnFragmentPaused_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler")]
		public unsafe virtual void OnFragmentPaused(FragmentManager fm, Fragment f)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentPaused.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
			}
		}

		private static Delegate GetOnFragmentPreAttached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_content_Context_Handler()
		{
			return new global::_JniMarshal_PPLLL_V(n_OnFragmentPreAttached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_content_Context_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnFragmentPreAttached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_content_Context_(nint jnienv, nint native__this, nint native_fm, nint native_f, nint native_context)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				FragmentLifecycleCallbacks? fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
				Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
				Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
				fragmentLifecycleCallbacks.OnFragmentPreAttached(fm, f, context);
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

		[Register("onFragmentPreAttached", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/content/Context;)V", "GetOnFragmentPreAttached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_content_Context_Handler")]
		public unsafe virtual void OnFragmentPreAttached(FragmentManager fm, Fragment f, Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentPreAttached.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/content/Context;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetOnFragmentPreCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_Handler()
		{
			return new global::_JniMarshal_PPLLL_V(n_OnFragmentPreCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnFragmentPreCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_fm, nint native_f, nint native_savedInstanceState)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				FragmentLifecycleCallbacks? fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
				Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
				Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
				fragmentLifecycleCallbacks.OnFragmentPreCreated(fm, f, savedInstanceState);
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

		[Register("onFragmentPreCreated", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/os/Bundle;)V", "GetOnFragmentPreCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_Handler")]
		public unsafe virtual void OnFragmentPreCreated(FragmentManager fm, Fragment f, Bundle? savedInstanceState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentPreCreated.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
				GC.KeepAlive(savedInstanceState);
			}
		}

		private static Delegate GetOnFragmentResumed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler()
		{
			return new global::_JniMarshal_PPLL_V(n_OnFragmentResumed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnFragmentResumed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_(nint jnienv, nint native__this, nint native_fm, nint native_f)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				FragmentLifecycleCallbacks? fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
				Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
				fragmentLifecycleCallbacks.OnFragmentResumed(fm, f);
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

		[Register("onFragmentResumed", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", "GetOnFragmentResumed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler")]
		public unsafe virtual void OnFragmentResumed(FragmentManager fm, Fragment f)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentResumed.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
			}
		}

		private static Delegate GetOnFragmentSaveInstanceState_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_Handler()
		{
			return new global::_JniMarshal_PPLLL_V(n_OnFragmentSaveInstanceState_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnFragmentSaveInstanceState_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_fm, nint native_f, nint native_outState)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				FragmentLifecycleCallbacks? fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
				Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
				Bundle outState = Java.Lang.Object.GetObject<Bundle>(native_outState, JniHandleOwnership.DoNotTransfer);
				fragmentLifecycleCallbacks.OnFragmentSaveInstanceState(fm, f, outState);
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

		[Register("onFragmentSaveInstanceState", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/os/Bundle;)V", "GetOnFragmentSaveInstanceState_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_Handler")]
		public unsafe virtual void OnFragmentSaveInstanceState(FragmentManager fm, Fragment f, Bundle outState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(outState?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentSaveInstanceState.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
				GC.KeepAlive(outState);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnFragmentStarted_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_(nint jnienv, nint native__this, nint native_fm, nint native_f)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				FragmentLifecycleCallbacks? fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
				Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
				fragmentLifecycleCallbacks.OnFragmentStarted(fm, f);
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

		[Register("onFragmentStarted", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", "GetOnFragmentStarted_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler")]
		public unsafe virtual void OnFragmentStarted(FragmentManager fm, Fragment f)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentStarted.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
			}
		}

		private static Delegate GetOnFragmentStopped_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler()
		{
			return new global::_JniMarshal_PPLL_V(n_OnFragmentStopped_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnFragmentStopped_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_(nint jnienv, nint native__this, nint native_fm, nint native_f)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				FragmentLifecycleCallbacks? fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
				Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
				fragmentLifecycleCallbacks.OnFragmentStopped(fm, f);
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

		[Register("onFragmentStopped", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", "GetOnFragmentStopped_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler")]
		public unsafe virtual void OnFragmentStopped(FragmentManager fm, Fragment f)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentStopped.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
			}
		}

		private static Delegate GetOnFragmentViewCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_view_View_Landroid_os_Bundle_Handler()
		{
			return new global::_JniMarshal_PPLLLL_V(n_OnFragmentViewCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_view_View_Landroid_os_Bundle_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnFragmentViewCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_view_View_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_fm, nint native_f, nint native_v, nint native_savedInstanceState)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				FragmentLifecycleCallbacks? fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
				Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
				View v = Java.Lang.Object.GetObject<View>(native_v, JniHandleOwnership.DoNotTransfer);
				Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
				fragmentLifecycleCallbacks.OnFragmentViewCreated(fm, f, v, savedInstanceState);
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

		[Register("onFragmentViewCreated", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/view/View;Landroid/os/Bundle;)V", "GetOnFragmentViewCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_view_View_Landroid_os_Bundle_Handler")]
		public unsafe virtual void OnFragmentViewCreated(FragmentManager fm, Fragment f, View v, Bundle? savedInstanceState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentViewCreated.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/view/View;Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
				GC.KeepAlive(v);
				GC.KeepAlive(savedInstanceState);
			}
		}

		private static Delegate GetOnFragmentViewDestroyed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler()
		{
			return new global::_JniMarshal_PPLL_V(n_OnFragmentViewDestroyed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnFragmentViewDestroyed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_(nint jnienv, nint native__this, nint native_fm, nint native_f)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				FragmentLifecycleCallbacks? fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
				Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
				fragmentLifecycleCallbacks.OnFragmentViewDestroyed(fm, f);
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

		[Register("onFragmentViewDestroyed", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", "GetOnFragmentViewDestroyed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler")]
		public unsafe virtual void OnFragmentViewDestroyed(FragmentManager fm, Fragment f)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentViewDestroyed.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnFragmentStarted_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment__mm_wrapper(nint jnienv, nint native__this, nint native_fm, nint native_f)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnFragmentStarted_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_(jnienv, native__this, native_fm, native_f);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	[Register("androidx/fragment/app/FragmentManager$FragmentLifecycleCallbacks", DoNotGenerateAcw = true)]
	internal class FragmentLifecycleCallbacksInvoker : FragmentLifecycleCallbacks
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentManager$FragmentLifecycleCallbacks", typeof(FragmentLifecycleCallbacksInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public FragmentLifecycleCallbacksInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}

	[Register("androidx/fragment/app/FragmentManager$OnBackStackChangedListener", "", "AndroidX.Fragment.App.FragmentManager/IOnBackStackChangedListenerInvoker")]
	public interface IOnBackStackChangedListener : IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentManager$OnBackStackChangedListener", typeof(IOnBackStackChangedListener), isInterface: true);

		private static Delegate? cb_onBackStackChangeCancelled_OnBackStackChangeCancelled_V;

		private static Delegate? cb_onBackStackChangeCommitted_OnBackStackChangeCommitted_Landroidx_fragment_app_Fragment_Z_V;

		private static Delegate? cb_onBackStackChangeProgressed_OnBackStackChangeProgressed_Landroidx_activity_BackEventCompat__V;

		private static Delegate? cb_onBackStackChangeStarted_OnBackStackChangeStarted_Landroidx_fragment_app_Fragment_Z_V;

		[Register("onBackStackChanged", "()V", "GetOnBackStackChangedHandler:AndroidX.Fragment.App.FragmentManager/IOnBackStackChangedListenerInvoker, Xamarin.AndroidX.Fragment")]
		void OnBackStackChanged();

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnBackStackChangeCancelled(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<IOnBackStackChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnBackStackChangeCancelled();
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

		[Register("onBackStackChangeCancelled", "()V", "GetOnBackStackChangeCancelledHandler:AndroidX.Fragment.App.FragmentManager/IOnBackStackChangedListener, Xamarin.AndroidX.Fragment")]
		unsafe void OnBackStackChangeCancelled()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onBackStackChangeCancelled.()V", this, null);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnBackStackChangeCommitted_Landroidx_fragment_app_Fragment_Z(nint jnienv, nint native__this, nint native_fragment, sbyte native_pop)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnBackStackChangedListener? onBackStackChangedListener = Java.Lang.Object.GetObject<IOnBackStackChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
				bool pop = native_pop != 0;
				onBackStackChangedListener.OnBackStackChangeCommitted(fragment, pop);
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

		[Register("onBackStackChangeCommitted", "(Landroidx/fragment/app/Fragment;Z)V", "GetOnBackStackChangeCommitted_Landroidx_fragment_app_Fragment_ZHandler:AndroidX.Fragment.App.FragmentManager/IOnBackStackChangedListener, Xamarin.AndroidX.Fragment")]
		unsafe void OnBackStackChangeCommitted(Fragment fragment, bool pop)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(pop ? ((sbyte)1) : ((sbyte)0));
				_members.InstanceMethods.InvokeVirtualVoidMethod("onBackStackChangeCommitted.(Landroidx/fragment/app/Fragment;Z)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnBackStackChangeProgressed_Landroidx_activity_BackEventCompat_(nint jnienv, nint native__this, nint native_backEventCompat)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnBackStackChangedListener? onBackStackChangedListener = Java.Lang.Object.GetObject<IOnBackStackChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				BackEventCompat backEventCompat = Java.Lang.Object.GetObject<BackEventCompat>(native_backEventCompat, JniHandleOwnership.DoNotTransfer);
				onBackStackChangedListener.OnBackStackChangeProgressed(backEventCompat);
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

		[Register("onBackStackChangeProgressed", "(Landroidx/activity/BackEventCompat;)V", "GetOnBackStackChangeProgressed_Landroidx_activity_BackEventCompat_Handler:AndroidX.Fragment.App.FragmentManager/IOnBackStackChangedListener, Xamarin.AndroidX.Fragment")]
		unsafe void OnBackStackChangeProgressed(BackEventCompat backEventCompat)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(backEventCompat?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onBackStackChangeProgressed.(Landroidx/activity/BackEventCompat;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(backEventCompat);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnBackStackChangeStarted_Landroidx_fragment_app_Fragment_Z(nint jnienv, nint native__this, nint native_fragment, sbyte native_pop)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnBackStackChangedListener? onBackStackChangedListener = Java.Lang.Object.GetObject<IOnBackStackChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
				bool pop = native_pop != 0;
				onBackStackChangedListener.OnBackStackChangeStarted(fragment, pop);
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

		[Register("onBackStackChangeStarted", "(Landroidx/fragment/app/Fragment;Z)V", "GetOnBackStackChangeStarted_Landroidx_fragment_app_Fragment_ZHandler:AndroidX.Fragment.App.FragmentManager/IOnBackStackChangedListener, Xamarin.AndroidX.Fragment")]
		unsafe void OnBackStackChangeStarted(Fragment fragment, bool pop)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(pop ? ((sbyte)1) : ((sbyte)0));
				_members.InstanceMethods.InvokeVirtualVoidMethod("onBackStackChangeStarted.(Landroidx/fragment/app/Fragment;Z)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnBackStackChangeCancelled_mm_wrapper(nint jnienv, nint native__this)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnBackStackChangeCancelled(jnienv, native__this);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnBackStackChangeCommitted_Landroidx_fragment_app_Fragment_Z_mm_wrapper(nint jnienv, nint native__this, nint native_fragment, sbyte native_pop)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnBackStackChangeCommitted_Landroidx_fragment_app_Fragment_Z(jnienv, native__this, native_fragment, native_pop);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnBackStackChangeProgressed_Landroidx_activity_BackEventCompat__mm_wrapper(nint jnienv, nint native__this, nint native_backEventCompat)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnBackStackChangeProgressed_Landroidx_activity_BackEventCompat_(jnienv, native__this, native_backEventCompat);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnBackStackChangeStarted_Landroidx_fragment_app_Fragment_Z_mm_wrapper(nint jnienv, nint native__this, nint native_fragment, sbyte native_pop)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnBackStackChangeStarted_Landroidx_fragment_app_Fragment_Z(jnienv, native__this, native_fragment, native_pop);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	[Register("androidx/fragment/app/FragmentManager$OnBackStackChangedListener", DoNotGenerateAcw = true)]
	internal class IOnBackStackChangedListenerInvoker : Java.Lang.Object, IOnBackStackChangedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_fragment_app_FragmentManager_OnBackStackChangedListener = new XAPeerMembers("androidx/fragment/app/FragmentManager$OnBackStackChangedListener", typeof(IOnBackStackChangedListenerInvoker));

		private static Delegate? cb_onBackStackChanged_OnBackStackChanged_V;

		private static nint java_class_ref => _members_androidx_fragment_app_FragmentManager_OnBackStackChangedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_fragment_app_FragmentManager_OnBackStackChangedListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_fragment_app_FragmentManager_OnBackStackChangedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_fragment_app_FragmentManager_OnBackStackChangedListener.ManagedPeerType;

		public IOnBackStackChangedListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnBackStackChanged(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<IOnBackStackChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnBackStackChanged();
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

		public unsafe void OnBackStackChanged()
		{
			_members_androidx_fragment_app_FragmentManager_OnBackStackChangedListener.InstanceMethods.InvokeAbstractVoidMethod("onBackStackChanged.()V", this, null);
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

		[UnmanagedCallersOnly]
		private static void n_OnBackStackChanged_mm_wrapper(nint jnienv, nint native__this)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnBackStackChanged(jnienv, native__this);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class BackStackChangeCommittedEventArgs : EventArgs
	{
		private Fragment fragment;

		private bool pop;

		public BackStackChangeCommittedEventArgs(Fragment fragment, bool pop)
		{
			this.fragment = fragment;
			this.pop = pop;
		}
	}

	public class BackStackChangeProgressedEventArgs : EventArgs
	{
		private BackEventCompat backEventCompat;

		public BackStackChangeProgressedEventArgs(BackEventCompat backEventCompat)
		{
			this.backEventCompat = backEventCompat;
		}
	}

	public class BackStackChangeStartedEventArgs : EventArgs
	{
		private Fragment fragment;

		private bool pop;

		public BackStackChangeStartedEventArgs(Fragment fragment, bool pop)
		{
			this.fragment = fragment;
			this.pop = pop;
		}
	}

	[Register("mono/androidx/fragment/app/FragmentManager_OnBackStackChangedListenerImplementor")]
	internal sealed class IOnBackStackChangedListenerImplementor : Java.Lang.Object, IOnBackStackChangedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler? OnBackStackChangeCancelledHandler;

		public EventHandler<BackStackChangeCommittedEventArgs>? OnBackStackChangeCommittedHandler;

		public EventHandler<BackStackChangeProgressedEventArgs>? OnBackStackChangeProgressedHandler;

		public EventHandler<BackStackChangeStartedEventArgs>? OnBackStackChangeStartedHandler;

		public EventHandler? OnBackStackChangedHandler;

		public unsafe IOnBackStackChangedListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnBackStackChangeCancelled()
		{
			OnBackStackChangeCancelledHandler?.Invoke(sender, new EventArgs());
		}

		public void OnBackStackChangeCommitted(Fragment fragment, bool pop)
		{
			OnBackStackChangeCommittedHandler?.Invoke(sender, new BackStackChangeCommittedEventArgs(fragment, pop));
		}

		public void OnBackStackChangeProgressed(BackEventCompat backEventCompat)
		{
			OnBackStackChangeProgressedHandler?.Invoke(sender, new BackStackChangeProgressedEventArgs(backEventCompat));
		}

		public void OnBackStackChangeStarted(Fragment fragment, bool pop)
		{
			OnBackStackChangeStartedHandler?.Invoke(sender, new BackStackChangeStartedEventArgs(fragment, pop));
		}

		public void OnBackStackChanged()
		{
			OnBackStackChangedHandler?.Invoke(sender, new EventArgs());
		}

		internal static bool __IsEmpty(IOnBackStackChangedListenerImplementor value)
		{
			if (value.OnBackStackChangeCancelledHandler == null && value.OnBackStackChangeCommittedHandler == null && value.OnBackStackChangeProgressedHandler == null && value.OnBackStackChangeStartedHandler == null)
			{
				return value.OnBackStackChangedHandler == null;
			}
			return false;
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentManager", typeof(FragmentManager));

	private static Delegate? cb_getBackStackEntryCount_GetBackStackEntryCount_I;

	private static Delegate? cb_getFragmentFactory_GetFragmentFactory_Landroidx_fragment_app_FragmentFactory_;

	private static Delegate? cb_setFragmentFactory_SetFragmentFactory_Landroidx_fragment_app_FragmentFactory__V;

	private static Delegate? cb_getFragments_GetFragments_Ljava_util_List_;

	private static Delegate? cb_getHost_GetHost_Landroidx_fragment_app_FragmentHostCallback_;

	private static Delegate? cb_isDestroyed_IsDestroyed_Z;

	private static Delegate? cb_isStateSaved_IsStateSaved_Z;

	private static Delegate? cb_getPrimaryNavigationFragment_GetPrimaryNavigationFragment_Landroidx_fragment_app_Fragment_;

	private static Delegate? cb_getStrictModePolicy_GetStrictModePolicy_Landroidx_fragment_app_strictmode_FragmentStrictMode_Policy_;

	private static Delegate? cb_setStrictModePolicy_SetStrictModePolicy_Landroidx_fragment_app_strictmode_FragmentStrictMode_Policy__V;

	private static Delegate? cb_addFragmentOnAttachListener_AddFragmentOnAttachListener_Landroidx_fragment_app_FragmentOnAttachListener__V;

	private static Delegate? cb_addOnBackStackChangedListener_AddOnBackStackChangedListener_Landroidx_fragment_app_FragmentManager_OnBackStackChangedListener__V;

	private static Delegate? cb_beginTransaction_BeginTransaction_Landroidx_fragment_app_FragmentTransaction_;

	private static Delegate? cb_clearBackStack_ClearBackStack_Ljava_lang_String__V;

	private static Delegate? cb_dump_Dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String__V;

	private static Delegate? cb_executePendingTransactions_ExecutePendingTransactions_Z;

	private static Delegate? cb_findFragmentById_FindFragmentById_I_Landroidx_fragment_app_Fragment_;

	private static Delegate? cb_findFragmentByTag_FindFragmentByTag_Ljava_lang_String__Landroidx_fragment_app_Fragment_;

	private static Delegate? cb_getBackStackEntryAt_GetBackStackEntryAt_I_Landroidx_fragment_app_FragmentManager_BackStackEntry_;

	private static Delegate? cb_getFragment_GetFragment_Landroid_os_Bundle_Ljava_lang_String__Landroidx_fragment_app_Fragment_;

	private static Delegate? cb_openTransaction_OpenTransaction_Landroidx_fragment_app_FragmentTransaction_;

	private static Delegate? cb_popBackStack_PopBackStack_V;

	private static Delegate? cb_popBackStack_PopBackStack_II_V;

	private static Delegate? cb_popBackStack_PopBackStack_Ljava_lang_String_I_V;

	private static Delegate? cb_popBackStackImmediate_PopBackStackImmediate_Z;

	private static Delegate? cb_popBackStackImmediate_PopBackStackImmediate_II_Z;

	private static Delegate? cb_popBackStackImmediate_PopBackStackImmediate_Ljava_lang_String_I_Z;

	private static Delegate? cb_putFragment_PutFragment_Landroid_os_Bundle_Ljava_lang_String_Landroidx_fragment_app_Fragment__V;

	private static Delegate? cb_registerFragmentLifecycleCallbacks_RegisterFragmentLifecycleCallbacks_Landroidx_fragment_app_FragmentManager_FragmentLifecycleCallbacks_Z_V;

	private static Delegate? cb_removeFragmentOnAttachListener_RemoveFragmentOnAttachListener_Landroidx_fragment_app_FragmentOnAttachListener__V;

	private static Delegate? cb_removeOnBackStackChangedListener_RemoveOnBackStackChangedListener_Landroidx_fragment_app_FragmentManager_OnBackStackChangedListener__V;

	private static Delegate? cb_restoreBackStack_RestoreBackStack_Ljava_lang_String__V;

	private static Delegate? cb_saveBackStack_SaveBackStack_Ljava_lang_String__V;

	private static Delegate? cb_saveFragmentInstanceState_SaveFragmentInstanceState_Landroidx_fragment_app_Fragment__Landroidx_fragment_app_Fragment_SavedState_;

	private static Delegate? cb_unregisterFragmentLifecycleCallbacks_UnregisterFragmentLifecycleCallbacks_Landroidx_fragment_app_FragmentManager_FragmentLifecycleCallbacks__V;

	private WeakReference? weak_implementor_AddFragmentOnAttachListener;

	private WeakReference? weak_implementor_AddOnBackStackChangedListener;

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

	public unsafe virtual int BackStackEntryCount
	{
		[Register("getBackStackEntryCount", "()I", "GetGetBackStackEntryCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getBackStackEntryCount.()I", this, null);
		}
	}

	public unsafe virtual FragmentFactory FragmentFactory
	{
		[Register("getFragmentFactory", "()Landroidx/fragment/app/FragmentFactory;", "GetGetFragmentFactoryHandler")]
		get
		{
			return Java.Lang.Object.GetObject<FragmentFactory>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFragmentFactory.()Landroidx/fragment/app/FragmentFactory;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setFragmentFactory", "(Landroidx/fragment/app/FragmentFactory;)V", "GetSetFragmentFactory_Landroidx_fragment_app_FragmentFactory_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setFragmentFactory.(Landroidx/fragment/app/FragmentFactory;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual IList<Fragment> Fragments
	{
		[Register("getFragments", "()Ljava/util/List;", "GetGetFragmentsHandler")]
		get
		{
			return JavaList<Fragment>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getFragments.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual FragmentHostCallback Host
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getHost", "()Landroidx/fragment/app/FragmentHostCallback;", "GetGetHostHandler")]
		get
		{
			return Java.Lang.Object.GetObject<FragmentHostCallback>(_members.InstanceMethods.InvokeVirtualObjectMethod("getHost.()Landroidx/fragment/app/FragmentHostCallback;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool IsDestroyed
	{
		[Register("isDestroyed", "()Z", "GetIsDestroyedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDestroyed.()Z", this, null);
		}
	}

	public unsafe virtual bool IsStateSaved
	{
		[Register("isStateSaved", "()Z", "GetIsStateSavedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isStateSaved.()Z", this, null);
		}
	}

	public unsafe virtual Fragment? PrimaryNavigationFragment
	{
		[Register("getPrimaryNavigationFragment", "()Landroidx/fragment/app/Fragment;", "GetGetPrimaryNavigationFragmentHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Fragment>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPrimaryNavigationFragment.()Landroidx/fragment/app/Fragment;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual FragmentStrictMode.Policy? StrictModePolicy
	{
		[Register("getStrictModePolicy", "()Landroidx/fragment/app/strictmode/FragmentStrictMode$Policy;", "GetGetStrictModePolicyHandler")]
		get
		{
			return Java.Lang.Object.GetObject<FragmentStrictMode.Policy>(_members.InstanceMethods.InvokeVirtualObjectMethod("getStrictModePolicy.()Landroidx/fragment/app/strictmode/FragmentStrictMode$Policy;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setStrictModePolicy", "(Landroidx/fragment/app/strictmode/FragmentStrictMode$Policy;)V", "GetSetStrictModePolicy_Landroidx_fragment_app_strictmode_FragmentStrictMode_Policy_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setStrictModePolicy.(Landroidx/fragment/app/strictmode/FragmentStrictMode$Policy;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public event EventHandler<FragmentOnAttachEventArgs> FragmentOnAttach
	{
		add
		{
			EventHelper.AddEventHandler<IFragmentOnAttachListener, IFragmentOnAttachListenerImplementor>(ref weak_implementor_AddFragmentOnAttachListener, __CreateIFragmentOnAttachListenerImplementor, AddFragmentOnAttachListener, delegate(IFragmentOnAttachListenerImplementor __h)
			{
				__h.Handler = (EventHandler<FragmentOnAttachEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddFragmentOnAttachListener, IFragmentOnAttachListenerImplementor.__IsEmpty, delegate(IFragmentOnAttachListener __v)
			{
				RemoveFragmentOnAttachListener(__v);
			}, delegate(IFragmentOnAttachListenerImplementor __h)
			{
				__h.Handler = (EventHandler<FragmentOnAttachEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	public event EventHandler BackStackChangeCancelled
	{
		add
		{
			EventHelper.AddEventHandler<IOnBackStackChangedListener, IOnBackStackChangedListenerImplementor>(ref weak_implementor_AddOnBackStackChangedListener, __CreateIOnBackStackChangedListenerImplementor, AddOnBackStackChangedListener, delegate(IOnBackStackChangedListenerImplementor __h)
			{
				__h.OnBackStackChangeCancelledHandler = (EventHandler)Delegate.Combine(__h.OnBackStackChangeCancelledHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnBackStackChangedListener, IOnBackStackChangedListenerImplementor.__IsEmpty, delegate(IOnBackStackChangedListener __v)
			{
				RemoveOnBackStackChangedListener(__v);
			}, delegate(IOnBackStackChangedListenerImplementor __h)
			{
				__h.OnBackStackChangeCancelledHandler = (EventHandler)Delegate.Remove(__h.OnBackStackChangeCancelledHandler, value);
			});
		}
	}

	public event EventHandler<BackStackChangeCommittedEventArgs> BackStackChangeCommitted
	{
		add
		{
			EventHelper.AddEventHandler<IOnBackStackChangedListener, IOnBackStackChangedListenerImplementor>(ref weak_implementor_AddOnBackStackChangedListener, __CreateIOnBackStackChangedListenerImplementor, AddOnBackStackChangedListener, delegate(IOnBackStackChangedListenerImplementor __h)
			{
				__h.OnBackStackChangeCommittedHandler = (EventHandler<BackStackChangeCommittedEventArgs>)Delegate.Combine(__h.OnBackStackChangeCommittedHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnBackStackChangedListener, IOnBackStackChangedListenerImplementor.__IsEmpty, delegate(IOnBackStackChangedListener __v)
			{
				RemoveOnBackStackChangedListener(__v);
			}, delegate(IOnBackStackChangedListenerImplementor __h)
			{
				__h.OnBackStackChangeCommittedHandler = (EventHandler<BackStackChangeCommittedEventArgs>)Delegate.Remove(__h.OnBackStackChangeCommittedHandler, value);
			});
		}
	}

	public event EventHandler<BackStackChangeProgressedEventArgs> BackStackChangeProgressed
	{
		add
		{
			EventHelper.AddEventHandler<IOnBackStackChangedListener, IOnBackStackChangedListenerImplementor>(ref weak_implementor_AddOnBackStackChangedListener, __CreateIOnBackStackChangedListenerImplementor, AddOnBackStackChangedListener, delegate(IOnBackStackChangedListenerImplementor __h)
			{
				__h.OnBackStackChangeProgressedHandler = (EventHandler<BackStackChangeProgressedEventArgs>)Delegate.Combine(__h.OnBackStackChangeProgressedHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnBackStackChangedListener, IOnBackStackChangedListenerImplementor.__IsEmpty, delegate(IOnBackStackChangedListener __v)
			{
				RemoveOnBackStackChangedListener(__v);
			}, delegate(IOnBackStackChangedListenerImplementor __h)
			{
				__h.OnBackStackChangeProgressedHandler = (EventHandler<BackStackChangeProgressedEventArgs>)Delegate.Remove(__h.OnBackStackChangeProgressedHandler, value);
			});
		}
	}

	public event EventHandler<BackStackChangeStartedEventArgs> BackStackChangeStarted
	{
		add
		{
			EventHelper.AddEventHandler<IOnBackStackChangedListener, IOnBackStackChangedListenerImplementor>(ref weak_implementor_AddOnBackStackChangedListener, __CreateIOnBackStackChangedListenerImplementor, AddOnBackStackChangedListener, delegate(IOnBackStackChangedListenerImplementor __h)
			{
				__h.OnBackStackChangeStartedHandler = (EventHandler<BackStackChangeStartedEventArgs>)Delegate.Combine(__h.OnBackStackChangeStartedHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnBackStackChangedListener, IOnBackStackChangedListenerImplementor.__IsEmpty, delegate(IOnBackStackChangedListener __v)
			{
				RemoveOnBackStackChangedListener(__v);
			}, delegate(IOnBackStackChangedListenerImplementor __h)
			{
				__h.OnBackStackChangeStartedHandler = (EventHandler<BackStackChangeStartedEventArgs>)Delegate.Remove(__h.OnBackStackChangeStartedHandler, value);
			});
		}
	}

	public event EventHandler BackStackChanged
	{
		add
		{
			EventHelper.AddEventHandler<IOnBackStackChangedListener, IOnBackStackChangedListenerImplementor>(ref weak_implementor_AddOnBackStackChangedListener, __CreateIOnBackStackChangedListenerImplementor, AddOnBackStackChangedListener, delegate(IOnBackStackChangedListenerImplementor __h)
			{
				__h.OnBackStackChangedHandler = (EventHandler)Delegate.Combine(__h.OnBackStackChangedHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnBackStackChangedListener, IOnBackStackChangedListenerImplementor.__IsEmpty, delegate(IOnBackStackChangedListener __v)
			{
				RemoveOnBackStackChangedListener(__v);
			}, delegate(IOnBackStackChangedListenerImplementor __h)
			{
				__h.OnBackStackChangedHandler = (EventHandler)Delegate.Remove(__h.OnBackStackChangedHandler, value);
			});
		}
	}

	protected FragmentManager(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe FragmentManager()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetBackStackEntryCountHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetBackStackEntryCount);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetBackStackEntryCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BackStackEntryCount;
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

	private static Delegate GetGetFragmentFactoryHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetFragmentFactory);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetFragmentFactory(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FragmentFactory);
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

	private static Delegate GetSetFragmentFactory_Landroidx_fragment_app_FragmentFactory_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetFragmentFactory_Landroidx_fragment_app_FragmentFactory_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFragmentFactory_Landroidx_fragment_app_FragmentFactory_(nint jnienv, nint native__this, nint native_fragmentFactory)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FragmentManager? fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FragmentFactory fragmentFactory = Java.Lang.Object.GetObject<FragmentFactory>(native_fragmentFactory, JniHandleOwnership.DoNotTransfer);
			fragmentManager.FragmentFactory = fragmentFactory;
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

	private static Delegate GetGetFragmentsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetFragments);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetFragments(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<Fragment>.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Fragments);
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

	private static Delegate GetGetHostHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetHost);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetHost(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Host);
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

	private static Delegate GetIsDestroyedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsDestroyed);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsDestroyed(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsDestroyed ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsStateSavedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsStateSaved);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsStateSaved(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsStateSaved ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetPrimaryNavigationFragmentHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetPrimaryNavigationFragment);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPrimaryNavigationFragment(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PrimaryNavigationFragment);
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

	private static Delegate GetGetStrictModePolicyHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetStrictModePolicy);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetStrictModePolicy(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StrictModePolicy);
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

	private static Delegate GetSetStrictModePolicy_Landroidx_fragment_app_strictmode_FragmentStrictMode_Policy_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetStrictModePolicy_Landroidx_fragment_app_strictmode_FragmentStrictMode_Policy_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStrictModePolicy_Landroidx_fragment_app_strictmode_FragmentStrictMode_Policy_(nint jnienv, nint native__this, nint native_policy)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FragmentManager? fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FragmentStrictMode.Policy strictModePolicy = Java.Lang.Object.GetObject<FragmentStrictMode.Policy>(native_policy, JniHandleOwnership.DoNotTransfer);
			fragmentManager.StrictModePolicy = strictModePolicy;
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

	private static Delegate GetAddFragmentOnAttachListener_Landroidx_fragment_app_FragmentOnAttachListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddFragmentOnAttachListener_Landroidx_fragment_app_FragmentOnAttachListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddFragmentOnAttachListener_Landroidx_fragment_app_FragmentOnAttachListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FragmentManager? fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IFragmentOnAttachListener listener = Java.Lang.Object.GetObject<IFragmentOnAttachListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			fragmentManager.AddFragmentOnAttachListener(listener);
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

	[Register("addFragmentOnAttachListener", "(Landroidx/fragment/app/FragmentOnAttachListener;)V", "GetAddFragmentOnAttachListener_Landroidx_fragment_app_FragmentOnAttachListener_Handler")]
	public unsafe virtual void AddFragmentOnAttachListener(IFragmentOnAttachListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addFragmentOnAttachListener.(Landroidx/fragment/app/FragmentOnAttachListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetAddOnBackStackChangedListener_Landroidx_fragment_app_FragmentManager_OnBackStackChangedListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddOnBackStackChangedListener_Landroidx_fragment_app_FragmentManager_OnBackStackChangedListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddOnBackStackChangedListener_Landroidx_fragment_app_FragmentManager_OnBackStackChangedListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FragmentManager? fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnBackStackChangedListener listener = Java.Lang.Object.GetObject<IOnBackStackChangedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			fragmentManager.AddOnBackStackChangedListener(listener);
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

	[Register("addOnBackStackChangedListener", "(Landroidx/fragment/app/FragmentManager$OnBackStackChangedListener;)V", "GetAddOnBackStackChangedListener_Landroidx_fragment_app_FragmentManager_OnBackStackChangedListener_Handler")]
	public unsafe virtual void AddOnBackStackChangedListener(IOnBackStackChangedListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnBackStackChangedListener.(Landroidx/fragment/app/FragmentManager$OnBackStackChangedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetBeginTransactionHandler()
	{
		return new global::_JniMarshal_PP_L(n_BeginTransaction);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_BeginTransaction(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BeginTransaction());
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

	[Register("beginTransaction", "()Landroidx/fragment/app/FragmentTransaction;", "GetBeginTransactionHandler")]
	public unsafe virtual FragmentTransaction BeginTransaction()
	{
		return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("beginTransaction.()Landroidx/fragment/app/FragmentTransaction;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetClearBackStack_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_ClearBackStack_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearBackStack_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FragmentManager? fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			fragmentManager.ClearBackStack(name);
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

	[Register("clearBackStack", "(Ljava/lang/String;)V", "GetClearBackStack_Ljava_lang_String_Handler")]
	public unsafe virtual void ClearBackStack(string name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("clearBackStack.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("clearFragmentResult", "(Ljava/lang/String;)V", "")]
	public unsafe void ClearFragmentResult(string requestKey)
	{
		nint num = JNIEnv.NewString(requestKey);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("clearFragmentResult.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("clearFragmentResultListener", "(Ljava/lang/String;)V", "")]
	public unsafe void ClearFragmentResultListener(string requestKey)
	{
		nint num = JNIEnv.NewString(requestKey);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("clearFragmentResultListener.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPLLLL_V(n_Dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_(nint jnienv, nint native__this, nint native_prefix, nint native_fd, nint native_writer, nint native_args)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FragmentManager? fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string prefix = JNIEnv.GetString(native_prefix, JniHandleOwnership.DoNotTransfer);
			FileDescriptor fd = Java.Lang.Object.GetObject<FileDescriptor>(native_fd, JniHandleOwnership.DoNotTransfer);
			PrintWriter writer = Java.Lang.Object.GetObject<PrintWriter>(native_writer, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_args, JniHandleOwnership.DoNotTransfer, typeof(string));
			fragmentManager.Dump(prefix, fd, writer, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_args);
			}
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

	[Register("dump", "(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V", "GetDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_Handler")]
	public unsafe virtual void Dump(string prefix, FileDescriptor? fd, PrintWriter writer, string[]? args)
	{
		nint num = JNIEnv.NewString(prefix);
		nint num2 = JNIEnv.NewArray(args);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(fd?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(writer?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeVirtualVoidMethod("dump.(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			if (args != null)
			{
				JNIEnv.CopyArray(num2, args);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(fd);
			GC.KeepAlive(writer);
			GC.KeepAlive(args);
		}
	}

	[Obsolete("deprecated")]
	[Register("enableDebugLogging", "(Z)V", "")]
	public unsafe static void EnableDebugLogging(bool enabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enabled ? ((sbyte)1) : ((sbyte)0));
		_members.StaticMethods.InvokeVoidMethod("enableDebugLogging.(Z)V", ptr);
	}

	[Register("enablePredictiveBack", "(Z)V", "")]
	public unsafe static void EnablePredictiveBack(bool enabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enabled ? ((sbyte)1) : ((sbyte)0));
		_members.StaticMethods.InvokeVoidMethod("enablePredictiveBack.(Z)V", ptr);
	}

	private static Delegate GetExecutePendingTransactionsHandler()
	{
		return new global::_JniMarshal_PP_B(n_ExecutePendingTransactions);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ExecutePendingTransactions(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExecutePendingTransactions() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("executePendingTransactions", "()Z", "GetExecutePendingTransactionsHandler")]
	public unsafe virtual bool ExecutePendingTransactions()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("executePendingTransactions.()Z", this, null);
	}

	[Register("findFragment", "(Landroid/view/View;)Landroidx/fragment/app/Fragment;", "")]
	[JavaTypeParameters(new string[] { "F extends androidx.fragment.app.Fragment" })]
	public unsafe static Java.Lang.Object FindFragment(View view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("findFragment.(Landroid/view/View;)Landroidx/fragment/app/Fragment;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetFindFragmentById_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_FindFragmentById_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FindFragmentById_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindFragmentById(id));
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

	[Register("findFragmentById", "(I)Landroidx/fragment/app/Fragment;", "GetFindFragmentById_IHandler")]
	public unsafe virtual Fragment? FindFragmentById(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return Java.Lang.Object.GetObject<Fragment>(_members.InstanceMethods.InvokeVirtualObjectMethod("findFragmentById.(I)Landroidx/fragment/app/Fragment;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetFindFragmentByTag_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_FindFragmentByTag_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FindFragmentByTag_Ljava_lang_String_(nint jnienv, nint native__this, nint native_tag)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FragmentManager? fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string tag = JNIEnv.GetString(native_tag, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fragmentManager.FindFragmentByTag(tag));
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

	[Register("findFragmentByTag", "(Ljava/lang/String;)Landroidx/fragment/app/Fragment;", "GetFindFragmentByTag_Ljava_lang_String_Handler")]
	public unsafe virtual Fragment? FindFragmentByTag(string? tag)
	{
		nint num = JNIEnv.NewString(tag);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Fragment>(_members.InstanceMethods.InvokeVirtualObjectMethod("findFragmentByTag.(Ljava/lang/String;)Landroidx/fragment/app/Fragment;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("findFragmentManager", "(Landroid/view/View;)Landroidx/fragment/app/FragmentManager;", "")]
	public unsafe static FragmentManager FindFragmentManager(View view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FragmentManager>(_members.StaticMethods.InvokeObjectMethod("findFragmentManager.(Landroid/view/View;)Landroidx/fragment/app/FragmentManager;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetGetBackStackEntryAt_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetBackStackEntryAt_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetBackStackEntryAt_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetBackStackEntryAt(index));
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

	[Register("getBackStackEntryAt", "(I)Landroidx/fragment/app/FragmentManager$BackStackEntry;", "GetGetBackStackEntryAt_IHandler")]
	public unsafe virtual IBackStackEntry GetBackStackEntryAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<IBackStackEntry>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBackStackEntryAt.(I)Landroidx/fragment/app/FragmentManager$BackStackEntry;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetFragment_Landroid_os_Bundle_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_GetFragment_Landroid_os_Bundle_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetFragment_Landroid_os_Bundle_Ljava_lang_String_(nint jnienv, nint native__this, nint native_bundle, nint native_key)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FragmentManager? fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle bundle = Java.Lang.Object.GetObject<Bundle>(native_bundle, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fragmentManager.GetFragment(bundle, key));
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

	[Register("getFragment", "(Landroid/os/Bundle;Ljava/lang/String;)Landroidx/fragment/app/Fragment;", "GetGetFragment_Landroid_os_Bundle_Ljava_lang_String_Handler")]
	public unsafe virtual Fragment? GetFragment(Bundle bundle, string key)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(bundle?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Fragment>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFragment.(Landroid/os/Bundle;Ljava/lang/String;)Landroidx/fragment/app/Fragment;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(bundle);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("isLoggingEnabled", "(I)Z", "")]
	public unsafe static bool IsLoggingEnabled(int level)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(level);
		return _members.StaticMethods.InvokeBooleanMethod("isLoggingEnabled.(I)Z", ptr);
	}

	[Register("onContainerAvailable", "(Landroidx/fragment/app/FragmentContainerView;)V", "")]
	public unsafe void OnContainerAvailable(FragmentContainerView container)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("onContainerAvailable.(Landroidx/fragment/app/FragmentContainerView;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
		}
	}

	[Obsolete]
	private static Delegate GetOpenTransactionHandler()
	{
		return new global::_JniMarshal_PP_L(n_OpenTransaction);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OpenTransaction(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OpenTransaction());
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

	[Obsolete("deprecated")]
	[Register("openTransaction", "()Landroidx/fragment/app/FragmentTransaction;", "GetOpenTransactionHandler")]
	public unsafe virtual FragmentTransaction OpenTransaction()
	{
		return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("openTransaction.()Landroidx/fragment/app/FragmentTransaction;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetPopBackStackHandler()
	{
		return new global::_JniMarshal_PP_V(n_PopBackStack);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_PopBackStack(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PopBackStack();
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

	[Register("popBackStack", "()V", "GetPopBackStackHandler")]
	public unsafe virtual void PopBackStack()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("popBackStack.()V", this, null);
	}

	private static Delegate GetPopBackStack_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_PopBackStack_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_PopBackStack_II(nint jnienv, nint native__this, int id, int flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PopBackStack(id, flags);
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

	[Register("popBackStack", "(II)V", "GetPopBackStack_IIHandler")]
	public unsafe virtual void PopBackStack(int id, int flags)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(id);
		ptr[1] = new JniArgumentValue(flags);
		_members.InstanceMethods.InvokeVirtualVoidMethod("popBackStack.(II)V", this, ptr);
	}

	private static Delegate GetPopBackStack_Ljava_lang_String_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_PopBackStack_Ljava_lang_String_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_PopBackStack_Ljava_lang_String_I(nint jnienv, nint native__this, nint native_name, int flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FragmentManager? fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			fragmentManager.PopBackStack(name, flags);
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

	[Register("popBackStack", "(Ljava/lang/String;I)V", "GetPopBackStack_Ljava_lang_String_IHandler")]
	public unsafe virtual void PopBackStack(string? name, int flags)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(flags);
			_members.InstanceMethods.InvokeVirtualVoidMethod("popBackStack.(Ljava/lang/String;I)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetPopBackStackImmediateHandler()
	{
		return new global::_JniMarshal_PP_B(n_PopBackStackImmediate);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_PopBackStackImmediate(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PopBackStackImmediate() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("popBackStackImmediate", "()Z", "GetPopBackStackImmediateHandler")]
	public unsafe virtual bool PopBackStackImmediate()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("popBackStackImmediate.()Z", this, null);
	}

	private static Delegate GetPopBackStackImmediate_IIHandler()
	{
		return new global::_JniMarshal_PPII_B(n_PopBackStackImmediate_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_PopBackStackImmediate_II(nint jnienv, nint native__this, int id, int flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PopBackStackImmediate(id, flags) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("popBackStackImmediate", "(II)Z", "GetPopBackStackImmediate_IIHandler")]
	public unsafe virtual bool PopBackStackImmediate(int id, int flags)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(id);
		ptr[1] = new JniArgumentValue(flags);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("popBackStackImmediate.(II)Z", this, ptr);
	}

	private static Delegate GetPopBackStackImmediate_Ljava_lang_String_IHandler()
	{
		return new global::_JniMarshal_PPLI_B(n_PopBackStackImmediate_Ljava_lang_String_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_PopBackStackImmediate_Ljava_lang_String_I(nint jnienv, nint native__this, nint native_name, int flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FragmentManager? fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return fragmentManager.PopBackStackImmediate(name, flags) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("popBackStackImmediate", "(Ljava/lang/String;I)Z", "GetPopBackStackImmediate_Ljava_lang_String_IHandler")]
	public unsafe virtual bool PopBackStackImmediate(string? name, int flags)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(flags);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("popBackStackImmediate.(Ljava/lang/String;I)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetPutFragment_Landroid_os_Bundle_Ljava_lang_String_Landroidx_fragment_app_Fragment_Handler()
	{
		return new global::_JniMarshal_PPLLL_V(n_PutFragment_Landroid_os_Bundle_Ljava_lang_String_Landroidx_fragment_app_Fragment_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_PutFragment_Landroid_os_Bundle_Ljava_lang_String_Landroidx_fragment_app_Fragment_(nint jnienv, nint native__this, nint native_bundle, nint native_key, nint native_fragment)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FragmentManager? fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle bundle = Java.Lang.Object.GetObject<Bundle>(native_bundle, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
			fragmentManager.PutFragment(bundle, key, fragment);
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

	[Register("putFragment", "(Landroid/os/Bundle;Ljava/lang/String;Landroidx/fragment/app/Fragment;)V", "GetPutFragment_Landroid_os_Bundle_Ljava_lang_String_Landroidx_fragment_app_Fragment_Handler")]
	public unsafe virtual void PutFragment(Bundle bundle, string key, Fragment fragment)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(bundle?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("putFragment.(Landroid/os/Bundle;Ljava/lang/String;Landroidx/fragment/app/Fragment;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(bundle);
			GC.KeepAlive(fragment);
		}
	}

	private static Delegate GetRegisterFragmentLifecycleCallbacks_Landroidx_fragment_app_FragmentManager_FragmentLifecycleCallbacks_ZHandler()
	{
		return new global::_JniMarshal_PPLB_V(n_RegisterFragmentLifecycleCallbacks_Landroidx_fragment_app_FragmentManager_FragmentLifecycleCallbacks_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RegisterFragmentLifecycleCallbacks_Landroidx_fragment_app_FragmentManager_FragmentLifecycleCallbacks_Z(nint jnienv, nint native__this, nint native_cb, sbyte native_recursive)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FragmentManager? fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FragmentLifecycleCallbacks cb = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(native_cb, JniHandleOwnership.DoNotTransfer);
			bool recursive = native_recursive != 0;
			fragmentManager.RegisterFragmentLifecycleCallbacks(cb, recursive);
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

	[Register("registerFragmentLifecycleCallbacks", "(Landroidx/fragment/app/FragmentManager$FragmentLifecycleCallbacks;Z)V", "GetRegisterFragmentLifecycleCallbacks_Landroidx_fragment_app_FragmentManager_FragmentLifecycleCallbacks_ZHandler")]
	public unsafe virtual void RegisterFragmentLifecycleCallbacks(FragmentLifecycleCallbacks cb, bool recursive)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(cb?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(recursive ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("registerFragmentLifecycleCallbacks.(Landroidx/fragment/app/FragmentManager$FragmentLifecycleCallbacks;Z)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(cb);
		}
	}

	private static Delegate GetRemoveFragmentOnAttachListener_Landroidx_fragment_app_FragmentOnAttachListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveFragmentOnAttachListener_Landroidx_fragment_app_FragmentOnAttachListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveFragmentOnAttachListener_Landroidx_fragment_app_FragmentOnAttachListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FragmentManager? fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IFragmentOnAttachListener listener = Java.Lang.Object.GetObject<IFragmentOnAttachListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			fragmentManager.RemoveFragmentOnAttachListener(listener);
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

	[Register("removeFragmentOnAttachListener", "(Landroidx/fragment/app/FragmentOnAttachListener;)V", "GetRemoveFragmentOnAttachListener_Landroidx_fragment_app_FragmentOnAttachListener_Handler")]
	public unsafe virtual void RemoveFragmentOnAttachListener(IFragmentOnAttachListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeFragmentOnAttachListener.(Landroidx/fragment/app/FragmentOnAttachListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetRemoveOnBackStackChangedListener_Landroidx_fragment_app_FragmentManager_OnBackStackChangedListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveOnBackStackChangedListener_Landroidx_fragment_app_FragmentManager_OnBackStackChangedListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveOnBackStackChangedListener_Landroidx_fragment_app_FragmentManager_OnBackStackChangedListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FragmentManager? fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnBackStackChangedListener listener = Java.Lang.Object.GetObject<IOnBackStackChangedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			fragmentManager.RemoveOnBackStackChangedListener(listener);
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

	[Register("removeOnBackStackChangedListener", "(Landroidx/fragment/app/FragmentManager$OnBackStackChangedListener;)V", "GetRemoveOnBackStackChangedListener_Landroidx_fragment_app_FragmentManager_OnBackStackChangedListener_Handler")]
	public unsafe virtual void RemoveOnBackStackChangedListener(IOnBackStackChangedListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnBackStackChangedListener.(Landroidx/fragment/app/FragmentManager$OnBackStackChangedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetRestoreBackStack_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RestoreBackStack_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RestoreBackStack_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FragmentManager? fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			fragmentManager.RestoreBackStack(name);
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

	[Register("restoreBackStack", "(Ljava/lang/String;)V", "GetRestoreBackStack_Ljava_lang_String_Handler")]
	public unsafe virtual void RestoreBackStack(string name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("restoreBackStack.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSaveBackStack_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SaveBackStack_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SaveBackStack_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FragmentManager? fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			fragmentManager.SaveBackStack(name);
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

	[Register("saveBackStack", "(Ljava/lang/String;)V", "GetSaveBackStack_Ljava_lang_String_Handler")]
	public unsafe virtual void SaveBackStack(string name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("saveBackStack.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSaveFragmentInstanceState_Landroidx_fragment_app_Fragment_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_SaveFragmentInstanceState_Landroidx_fragment_app_Fragment_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SaveFragmentInstanceState_Landroidx_fragment_app_Fragment_(nint jnienv, nint native__this, nint native_f)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FragmentManager? fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fragmentManager.SaveFragmentInstanceState(f));
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

	[Register("saveFragmentInstanceState", "(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/Fragment$SavedState;", "GetSaveFragmentInstanceState_Landroidx_fragment_app_Fragment_Handler")]
	public unsafe virtual Fragment.SavedState? SaveFragmentInstanceState(Fragment f)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Fragment.SavedState>(_members.InstanceMethods.InvokeVirtualObjectMethod("saveFragmentInstanceState.(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/Fragment$SavedState;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(f);
		}
	}

	[Register("setFragmentResult", "(Ljava/lang/String;Landroid/os/Bundle;)V", "")]
	public unsafe void SetFragmentResult(string requestKey, Bundle result)
	{
		nint num = JNIEnv.NewString(requestKey);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("setFragmentResult.(Ljava/lang/String;Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(result);
		}
	}

	[Register("setFragmentResultListener", "(Ljava/lang/String;Landroidx/lifecycle/LifecycleOwner;Landroidx/fragment/app/FragmentResultListener;)V", "")]
	public unsafe void SetFragmentResultListener(string requestKey, ILifecycleOwner lifecycleOwner, IFragmentResultListener listener)
	{
		nint num = JNIEnv.NewString(requestKey);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((lifecycleOwner == null) ? IntPtr.Zero : ((Java.Lang.Object)lifecycleOwner).Handle);
			ptr[2] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("setFragmentResultListener.(Ljava/lang/String;Landroidx/lifecycle/LifecycleOwner;Landroidx/fragment/app/FragmentResultListener;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(lifecycleOwner);
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetUnregisterFragmentLifecycleCallbacks_Landroidx_fragment_app_FragmentManager_FragmentLifecycleCallbacks_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_UnregisterFragmentLifecycleCallbacks_Landroidx_fragment_app_FragmentManager_FragmentLifecycleCallbacks_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UnregisterFragmentLifecycleCallbacks_Landroidx_fragment_app_FragmentManager_FragmentLifecycleCallbacks_(nint jnienv, nint native__this, nint native_cb)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FragmentManager? fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FragmentLifecycleCallbacks cb = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(native_cb, JniHandleOwnership.DoNotTransfer);
			fragmentManager.UnregisterFragmentLifecycleCallbacks(cb);
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

	[Register("unregisterFragmentLifecycleCallbacks", "(Landroidx/fragment/app/FragmentManager$FragmentLifecycleCallbacks;)V", "GetUnregisterFragmentLifecycleCallbacks_Landroidx_fragment_app_FragmentManager_FragmentLifecycleCallbacks_Handler")]
	public unsafe virtual void UnregisterFragmentLifecycleCallbacks(FragmentLifecycleCallbacks cb)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(cb?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("unregisterFragmentLifecycleCallbacks.(Landroidx/fragment/app/FragmentManager$FragmentLifecycleCallbacks;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(cb);
		}
	}

	private IFragmentOnAttachListenerImplementor __CreateIFragmentOnAttachListenerImplementor()
	{
		return new IFragmentOnAttachListenerImplementor(this);
	}

	private IOnBackStackChangedListenerImplementor __CreateIOnBackStackChangedListenerImplementor()
	{
		return new IOnBackStackChangedListenerImplementor(this);
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
