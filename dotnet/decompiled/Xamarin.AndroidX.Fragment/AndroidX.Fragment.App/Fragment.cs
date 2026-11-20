using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Animation;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Views.Animations;
using AndroidX.Activity.Result;
using AndroidX.Activity.Result.Contract;
using AndroidX.Core.App;
using AndroidX.Lifecycle;
using AndroidX.Lifecycle.ViewModels;
using AndroidX.Loader.App;
using AndroidX.SavedState;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

namespace AndroidX.Fragment.App;

[Register("androidx/fragment/app/Fragment", DoNotGenerateAcw = true)]
public class Fragment : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable, ILifecycleOwner, IViewModelStoreOwner
{
	[Register("androidx/fragment/app/Fragment$SavedState", DoNotGenerateAcw = true)]
	public class SavedState : Java.Lang.Object, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/Fragment$SavedState", typeof(SavedState));

		private static Delegate? cb_describeContents_DescribeContents_I;

		private static Delegate? cb_writeToParcel_WriteToParcel_Landroid_os_Parcel_I_V;

		[Register("CREATOR")]
		public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

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

		protected SavedState(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetDescribeContentsHandler()
		{
			return new global::_JniMarshal_PP_I(n_DescribeContents);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_DescribeContents(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<SavedState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescribeContents();
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

		[Register("describeContents", "()I", "GetDescribeContentsHandler")]
		public unsafe virtual int DescribeContents()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("describeContents.()I", this, null);
		}

		private static Delegate GetWriteToParcel_Landroid_os_Parcel_IHandler()
		{
			return new global::_JniMarshal_PPLI_V(n_WriteToParcel_Landroid_os_Parcel_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_WriteToParcel_Landroid_os_Parcel_I(nint jnienv, nint native__this, nint native_dest, int native_flags)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				SavedState? savedState = Java.Lang.Object.GetObject<SavedState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Parcel dest = Java.Lang.Object.GetObject<Parcel>(native_dest, JniHandleOwnership.DoNotTransfer);
				savedState.WriteToParcel(dest, (ParcelableWriteFlags)native_flags);
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

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "GetWriteToParcel_Landroid_os_Parcel_IHandler")]
		public unsafe virtual void WriteToParcel(Parcel dest, ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(dest?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeVirtualVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(dest);
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/Fragment", typeof(Fragment));

	private static Delegate? cb_getAllowEnterTransitionOverlap_GetAllowEnterTransitionOverlap_Z;

	private static Delegate? cb_setAllowEnterTransitionOverlap_SetAllowEnterTransitionOverlap_Z_V;

	private static Delegate? cb_getAllowReturnTransitionOverlap_GetAllowReturnTransitionOverlap_Z;

	private static Delegate? cb_setAllowReturnTransitionOverlap_SetAllowReturnTransitionOverlap_Z_V;

	private static Delegate? cb_getContext_GetContext_Landroid_content_Context_;

	private static Delegate? cb_getDefaultViewModelCreationExtras_GetDefaultViewModelCreationExtras_Landroidx_lifecycle_viewmodel_CreationExtras_;

	private static Delegate? cb_getDefaultViewModelProviderFactory_GetDefaultViewModelProviderFactory_Landroidx_lifecycle_ViewModelProvider_Factory_;

	private static Delegate? cb_getEnterTransition_GetEnterTransition_Ljava_lang_Object_;

	private static Delegate? cb_setEnterTransition_SetEnterTransition_Ljava_lang_Object__V;

	private static Delegate? cb_getExitTransition_GetExitTransition_Ljava_lang_Object_;

	private static Delegate? cb_setExitTransition_SetExitTransition_Ljava_lang_Object__V;

	private static Delegate? cb_getLifecycle_GetLifecycle_Landroidx_lifecycle_Lifecycle_;

	private static Delegate? cb_getLoaderManager_GetLoaderManager_Landroidx_loader_app_LoaderManager_;

	private static Delegate? cb_getReenterTransition_GetReenterTransition_Ljava_lang_Object_;

	private static Delegate? cb_setReenterTransition_SetReenterTransition_Ljava_lang_Object__V;

	private static Delegate? cb_getReturnTransition_GetReturnTransition_Ljava_lang_Object_;

	private static Delegate? cb_setReturnTransition_SetReturnTransition_Ljava_lang_Object__V;

	private static Delegate? cb_getSharedElementEnterTransition_GetSharedElementEnterTransition_Ljava_lang_Object_;

	private static Delegate? cb_setSharedElementEnterTransition_SetSharedElementEnterTransition_Ljava_lang_Object__V;

	private static Delegate? cb_getSharedElementReturnTransition_GetSharedElementReturnTransition_Ljava_lang_Object_;

	private static Delegate? cb_setSharedElementReturnTransition_SetSharedElementReturnTransition_Ljava_lang_Object__V;

	private static Delegate? cb_getUserVisibleHint_GetUserVisibleHint_Z;

	private static Delegate? cb_setUserVisibleHint_SetUserVisibleHint_Z_V;

	private static Delegate? cb_getView_GetView_Landroid_view_View_;

	private static Delegate? cb_getViewLifecycleOwner_GetViewLifecycleOwner_Landroidx_lifecycle_LifecycleOwner_;

	private static Delegate? cb_getViewLifecycleOwnerLiveData_GetViewLifecycleOwnerLiveData_Landroidx_lifecycle_LiveData_;

	private static Delegate? cb_getViewModelStore_GetViewModelStore_Landroidx_lifecycle_ViewModelStore_;

	private static Delegate? cb_dump_Dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String__V;

	private static Delegate? cb_getLayoutInflater_GetLayoutInflater_Landroid_os_Bundle__Landroid_view_LayoutInflater_;

	private static Delegate? cb_onActivityCreated_OnActivityCreated_Landroid_os_Bundle__V;

	private static Delegate? cb_onActivityResult_OnActivityResult_IILandroid_content_Intent__V;

	private static Delegate? cb_onAttach_OnAttach_Landroid_app_Activity__V;

	private static Delegate? cb_onAttach_OnAttach_Landroid_content_Context__V;

	private static Delegate? cb_onAttachFragment_OnAttachFragment_Landroidx_fragment_app_Fragment__V;

	private static Delegate? cb_onConfigurationChanged_OnConfigurationChanged_Landroid_content_res_Configuration__V;

	private static Delegate? cb_onContextItemSelected_OnContextItemSelected_Landroid_view_MenuItem__Z;

	private static Delegate? cb_onCreate_OnCreate_Landroid_os_Bundle__V;

	private static Delegate? cb_onCreateAnimation_OnCreateAnimation_IZI_Landroid_view_animation_Animation_;

	private static Delegate? cb_onCreateAnimator_OnCreateAnimator_IZI_Landroid_animation_Animator_;

	private static Delegate? cb_onCreateContextMenu_OnCreateContextMenu_Landroid_view_ContextMenu_Landroid_view_View_Landroid_view_ContextMenu_ContextMenuInfo__V;

	private static Delegate? cb_onCreateOptionsMenu_OnCreateOptionsMenu_Landroid_view_Menu_Landroid_view_MenuInflater__V;

	private static Delegate? cb_onCreateView_OnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle__Landroid_view_View_;

	private static Delegate? cb_onDestroy_OnDestroy_V;

	private static Delegate? cb_onDestroyOptionsMenu_OnDestroyOptionsMenu_V;

	private static Delegate? cb_onDestroyView_OnDestroyView_V;

	private static Delegate? cb_onDetach_OnDetach_V;

	private static Delegate? cb_onGetLayoutInflater_OnGetLayoutInflater_Landroid_os_Bundle__Landroid_view_LayoutInflater_;

	private static Delegate? cb_onHiddenChanged_OnHiddenChanged_Z_V;

	private static Delegate? cb_onInflate_OnInflate_Landroid_app_Activity_Landroid_util_AttributeSet_Landroid_os_Bundle__V;

	private static Delegate? cb_onInflate_OnInflate_Landroid_content_Context_Landroid_util_AttributeSet_Landroid_os_Bundle__V;

	private static Delegate? cb_onLowMemory_OnLowMemory_V;

	private static Delegate? cb_onMultiWindowModeChanged_OnMultiWindowModeChanged_Z_V;

	private static Delegate? cb_onOptionsItemSelected_OnOptionsItemSelected_Landroid_view_MenuItem__Z;

	private static Delegate? cb_onOptionsMenuClosed_OnOptionsMenuClosed_Landroid_view_Menu__V;

	private static Delegate? cb_onPause_OnPause_V;

	private static Delegate? cb_onPictureInPictureModeChanged_OnPictureInPictureModeChanged_Z_V;

	private static Delegate? cb_onPrepareOptionsMenu_OnPrepareOptionsMenu_Landroid_view_Menu__V;

	private static Delegate? cb_onPrimaryNavigationFragmentChanged_OnPrimaryNavigationFragmentChanged_Z_V;

	private static Delegate? cb_onRequestPermissionsResult_OnRequestPermissionsResult_IarrayLjava_lang_String_arrayI_V;

	private static Delegate? cb_onResume_OnResume_V;

	private static Delegate? cb_onSaveInstanceState_OnSaveInstanceState_Landroid_os_Bundle__V;

	private static Delegate? cb_onStart_OnStart_V;

	private static Delegate? cb_onStop_OnStop_V;

	private static Delegate? cb_onViewCreated_OnViewCreated_Landroid_view_View_Landroid_os_Bundle__V;

	private static Delegate? cb_onViewStateRestored_OnViewStateRestored_Landroid_os_Bundle__V;

	private static Delegate? cb_postponeEnterTransition_PostponeEnterTransition_V;

	private static Delegate? cb_registerForContextMenu_RegisterForContextMenu_Landroid_view_View__V;

	private static Delegate? cb_setEnterSharedElementCallback_SetEnterSharedElementCallback_Landroidx_core_app_SharedElementCallback__V;

	private static Delegate? cb_setExitSharedElementCallback_SetExitSharedElementCallback_Landroidx_core_app_SharedElementCallback__V;

	private static Delegate? cb_setInitialSavedState_SetInitialSavedState_Landroidx_fragment_app_Fragment_SavedState__V;

	private static Delegate? cb_setMenuVisibility_SetMenuVisibility_Z_V;

	private static Delegate? cb_setTargetFragment_SetTargetFragment_Landroidx_fragment_app_Fragment_I_V;

	private static Delegate? cb_shouldShowRequestPermissionRationale_ShouldShowRequestPermissionRationale_Ljava_lang_String__Z;

	private static Delegate? cb_startActivity_StartActivity_Landroid_content_Intent__V;

	private static Delegate? cb_startActivity_StartActivity_Landroid_content_Intent_Landroid_os_Bundle__V;

	private static Delegate? cb_startActivityForResult_StartActivityForResult_Landroid_content_Intent_I_V;

	private static Delegate? cb_startActivityForResult_StartActivityForResult_Landroid_content_Intent_ILandroid_os_Bundle__V;

	private static Delegate? cb_startIntentSenderForResult_StartIntentSenderForResult_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle__V;

	private static Delegate? cb_startPostponedEnterTransition_StartPostponedEnterTransition_V;

	private static Delegate? cb_unregisterForContextMenu_UnregisterForContextMenu_Landroid_view_View__V;

	[Register("mPreviousWho")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	public string? MPreviousWho
	{
		get
		{
			return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("mPreviousWho.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				_members.InstanceFields.SetValue("mPreviousWho.Ljava/lang/String;", this, new JniObjectReference(num));
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

	public unsafe FragmentActivity? Activity
	{
		[Register("getActivity", "()Landroidx/fragment/app/FragmentActivity;", "")]
		get
		{
			return Java.Lang.Object.GetObject<FragmentActivity>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getActivity.()Landroidx/fragment/app/FragmentActivity;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool AllowEnterTransitionOverlap
	{
		[Register("getAllowEnterTransitionOverlap", "()Z", "GetGetAllowEnterTransitionOverlapHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getAllowEnterTransitionOverlap.()Z", this, null);
		}
		[Register("setAllowEnterTransitionOverlap", "(Z)V", "GetSetAllowEnterTransitionOverlap_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAllowEnterTransitionOverlap.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool AllowReturnTransitionOverlap
	{
		[Register("getAllowReturnTransitionOverlap", "()Z", "GetGetAllowReturnTransitionOverlapHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getAllowReturnTransitionOverlap.()Z", this, null);
		}
		[Register("setAllowReturnTransitionOverlap", "(Z)V", "GetSetAllowReturnTransitionOverlap_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAllowReturnTransitionOverlap.(Z)V", this, ptr);
		}
	}

	public unsafe Bundle? Arguments
	{
		[Register("getArguments", "()Landroid/os/Bundle;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Bundle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getArguments.()Landroid/os/Bundle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setArguments", "(Landroid/os/Bundle;)V", "GetSetArguments_Landroid_os_Bundle_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setArguments.(Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe FragmentManager ChildFragmentManager
	{
		[Register("getChildFragmentManager", "()Landroidx/fragment/app/FragmentManager;", "")]
		get
		{
			return Java.Lang.Object.GetObject<FragmentManager>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getChildFragmentManager.()Landroidx/fragment/app/FragmentManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Context? Context
	{
		[Register("getContext", "()Landroid/content/Context;", "GetGetContextHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeVirtualObjectMethod("getContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual CreationExtras DefaultViewModelCreationExtras
	{
		[Register("getDefaultViewModelCreationExtras", "()Landroidx/lifecycle/viewmodel/CreationExtras;", "GetGetDefaultViewModelCreationExtrasHandler")]
		get
		{
			return Java.Lang.Object.GetObject<CreationExtras>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDefaultViewModelCreationExtras.()Landroidx/lifecycle/viewmodel/CreationExtras;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ViewModelProvider.IFactory DefaultViewModelProviderFactory
	{
		[Register("getDefaultViewModelProviderFactory", "()Landroidx/lifecycle/ViewModelProvider$Factory;", "GetGetDefaultViewModelProviderFactoryHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ViewModelProvider.IFactory>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDefaultViewModelProviderFactory.()Landroidx/lifecycle/ViewModelProvider$Factory;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Java.Lang.Object? EnterTransition
	{
		[Register("getEnterTransition", "()Ljava/lang/Object;", "GetGetEnterTransitionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getEnterTransition.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setEnterTransition", "(Ljava/lang/Object;)V", "GetSetEnterTransition_Ljava_lang_Object_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setEnterTransition.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual Java.Lang.Object? ExitTransition
	{
		[Register("getExitTransition", "()Ljava/lang/Object;", "GetGetExitTransitionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getExitTransition.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setExitTransition", "(Ljava/lang/Object;)V", "GetSetExitTransition_Ljava_lang_Object_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setExitTransition.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	[Obsolete("deprecated")]
	public unsafe FragmentManager? FragmentManager
	{
		[Register("getFragmentManager", "()Landroidx/fragment/app/FragmentManager;", "")]
		get
		{
			return Java.Lang.Object.GetObject<FragmentManager>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getFragmentManager.()Landroidx/fragment/app/FragmentManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe bool HasOptionsMenu
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("hasOptionsMenu", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("hasOptionsMenu.()Z", this, null);
		}
		[Obsolete("deprecated")]
		[Register("setHasOptionsMenu", "(Z)V", "GetSetHasOptionsMenu_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHasOptionsMenu.(Z)V", this, ptr);
		}
	}

	public unsafe Java.Lang.Object? Host
	{
		[Register("getHost", "()Ljava/lang/Object;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getHost.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int Id
	{
		[Register("getId", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("getId.()I", this, null);
		}
	}

	public unsafe bool IsAdded
	{
		[Register("isAdded", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isAdded.()Z", this, null);
		}
	}

	public unsafe bool IsDetached
	{
		[Register("isDetached", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isDetached.()Z", this, null);
		}
	}

	public unsafe bool IsHidden
	{
		[Register("isHidden", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isHidden.()Z", this, null);
		}
	}

	public unsafe bool IsInLayout
	{
		[Register("isInLayout", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isInLayout.()Z", this, null);
		}
	}

	public unsafe bool IsMenuVisible
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("isMenuVisible", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isMenuVisible.()Z", this, null);
		}
	}

	public unsafe bool IsRemoving
	{
		[Register("isRemoving", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isRemoving.()Z", this, null);
		}
	}

	public unsafe bool IsResumed
	{
		[Register("isResumed", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isResumed.()Z", this, null);
		}
	}

	public unsafe bool IsStateSaved
	{
		[Register("isStateSaved", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isStateSaved.()Z", this, null);
		}
	}

	public unsafe bool IsVisible
	{
		[Register("isVisible", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isVisible.()Z", this, null);
		}
	}

	public unsafe LayoutInflater LayoutInflater
	{
		[Register("getLayoutInflater", "()Landroid/view/LayoutInflater;", "")]
		get
		{
			return Java.Lang.Object.GetObject<LayoutInflater>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLayoutInflater.()Landroid/view/LayoutInflater;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual AndroidX.Lifecycle.Lifecycle Lifecycle
	{
		[Register("getLifecycle", "()Landroidx/lifecycle/Lifecycle;", "GetGetLifecycleHandler")]
		get
		{
			return Java.Lang.Object.GetObject<AndroidX.Lifecycle.Lifecycle>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLifecycle.()Landroidx/lifecycle/Lifecycle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual LoaderManager LoaderManager
	{
		[Register("getLoaderManager", "()Landroidx/loader/app/LoaderManager;", "GetGetLoaderManagerHandler")]
		get
		{
			return Java.Lang.Object.GetObject<LoaderManager>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLoaderManager.()Landroidx/loader/app/LoaderManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe Fragment? ParentFragment
	{
		[Register("getParentFragment", "()Landroidx/fragment/app/Fragment;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Fragment>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getParentFragment.()Landroidx/fragment/app/Fragment;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe FragmentManager ParentFragmentManager
	{
		[Register("getParentFragmentManager", "()Landroidx/fragment/app/FragmentManager;", "")]
		get
		{
			return Java.Lang.Object.GetObject<FragmentManager>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getParentFragmentManager.()Landroidx/fragment/app/FragmentManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Java.Lang.Object? ReenterTransition
	{
		[Register("getReenterTransition", "()Ljava/lang/Object;", "GetGetReenterTransitionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getReenterTransition.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setReenterTransition", "(Ljava/lang/Object;)V", "GetSetReenterTransition_Ljava_lang_Object_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setReenterTransition.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe Resources Resources
	{
		[Register("getResources", "()Landroid/content/res/Resources;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Resources>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getResources.()Landroid/content/res/Resources;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[Obsolete("deprecated")]
	public unsafe bool RetainInstance
	{
		[Register("getRetainInstance", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getRetainInstance.()Z", this, null);
		}
		[Register("setRetainInstance", "(Z)V", "GetSetRetainInstance_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRetainInstance.(Z)V", this, ptr);
		}
	}

	public unsafe virtual Java.Lang.Object? ReturnTransition
	{
		[Register("getReturnTransition", "()Ljava/lang/Object;", "GetGetReturnTransitionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getReturnTransition.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setReturnTransition", "(Ljava/lang/Object;)V", "GetSetReturnTransition_Ljava_lang_Object_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setReturnTransition.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe SavedStateRegistry SavedStateRegistry
	{
		[Register("getSavedStateRegistry", "()Landroidx/savedstate/SavedStateRegistry;", "")]
		get
		{
			return Java.Lang.Object.GetObject<SavedStateRegistry>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getSavedStateRegistry.()Landroidx/savedstate/SavedStateRegistry;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Java.Lang.Object? SharedElementEnterTransition
	{
		[Register("getSharedElementEnterTransition", "()Ljava/lang/Object;", "GetGetSharedElementEnterTransitionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSharedElementEnterTransition.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setSharedElementEnterTransition", "(Ljava/lang/Object;)V", "GetSetSharedElementEnterTransition_Ljava_lang_Object_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSharedElementEnterTransition.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual Java.Lang.Object? SharedElementReturnTransition
	{
		[Register("getSharedElementReturnTransition", "()Ljava/lang/Object;", "GetGetSharedElementReturnTransitionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSharedElementReturnTransition.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setSharedElementReturnTransition", "(Ljava/lang/Object;)V", "GetSetSharedElementReturnTransition_Ljava_lang_Object_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSharedElementReturnTransition.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe string? Tag
	{
		[Register("getTag", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTag.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[Obsolete("deprecated")]
	public unsafe Fragment? TargetFragment
	{
		[Register("getTargetFragment", "()Landroidx/fragment/app/Fragment;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Fragment>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTargetFragment.()Landroidx/fragment/app/Fragment;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[Obsolete("deprecated")]
	public unsafe int TargetRequestCode
	{
		[Register("getTargetRequestCode", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("getTargetRequestCode.()I", this, null);
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual bool UserVisibleHint
	{
		[Register("getUserVisibleHint", "()Z", "GetGetUserVisibleHintHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getUserVisibleHint.()Z", this, null);
		}
		[Register("setUserVisibleHint", "(Z)V", "GetSetUserVisibleHint_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setUserVisibleHint.(Z)V", this, ptr);
		}
	}

	public unsafe virtual View? View
	{
		[Register("getView", "()Landroid/view/View;", "GetGetViewHandler")]
		get
		{
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("getView.()Landroid/view/View;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ILifecycleOwner ViewLifecycleOwner
	{
		[Register("getViewLifecycleOwner", "()Landroidx/lifecycle/LifecycleOwner;", "GetGetViewLifecycleOwnerHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ILifecycleOwner>(_members.InstanceMethods.InvokeVirtualObjectMethod("getViewLifecycleOwner.()Landroidx/lifecycle/LifecycleOwner;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual LiveData ViewLifecycleOwnerLiveData
	{
		[Register("getViewLifecycleOwnerLiveData", "()Landroidx/lifecycle/LiveData;", "GetGetViewLifecycleOwnerLiveDataHandler")]
		get
		{
			return Java.Lang.Object.GetObject<LiveData>(_members.InstanceMethods.InvokeVirtualObjectMethod("getViewLifecycleOwnerLiveData.()Landroidx/lifecycle/LiveData;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ViewModelStore ViewModelStore
	{
		[Register("getViewModelStore", "()Landroidx/lifecycle/ViewModelStore;", "GetGetViewModelStoreHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ViewModelStore>(_members.InstanceMethods.InvokeVirtualObjectMethod("getViewModelStore.()Landroidx/lifecycle/ViewModelStore;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected Fragment(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Fragment()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(I)V", "")]
	public unsafe Fragment(int contentLayoutId)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(contentLayoutId);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
		}
	}

	private static Delegate GetGetAllowEnterTransitionOverlapHandler()
	{
		return new global::_JniMarshal_PP_B(n_GetAllowEnterTransitionOverlap);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetAllowEnterTransitionOverlap(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AllowEnterTransitionOverlap ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetAllowEnterTransitionOverlap_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetAllowEnterTransitionOverlap_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAllowEnterTransitionOverlap_Z(nint jnienv, nint native__this, sbyte native_allow)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool allowEnterTransitionOverlap = native_allow != 0;
			fragment.AllowEnterTransitionOverlap = allowEnterTransitionOverlap;
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

	private static Delegate GetGetAllowReturnTransitionOverlapHandler()
	{
		return new global::_JniMarshal_PP_B(n_GetAllowReturnTransitionOverlap);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetAllowReturnTransitionOverlap(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AllowReturnTransitionOverlap ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetAllowReturnTransitionOverlap_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetAllowReturnTransitionOverlap_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAllowReturnTransitionOverlap_Z(nint jnienv, nint native__this, sbyte native_allow)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool allowReturnTransitionOverlap = native_allow != 0;
			fragment.AllowReturnTransitionOverlap = allowReturnTransitionOverlap;
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

	private static Delegate GetGetContextHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetContext);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetContext(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Context);
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

	private static Delegate GetGetDefaultViewModelCreationExtrasHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetDefaultViewModelCreationExtras);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDefaultViewModelCreationExtras(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefaultViewModelCreationExtras);
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

	private static Delegate GetGetDefaultViewModelProviderFactoryHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetDefaultViewModelProviderFactory);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDefaultViewModelProviderFactory(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefaultViewModelProviderFactory);
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

	private static Delegate GetGetEnterTransitionHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetEnterTransition);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetEnterTransition(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnterTransition);
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

	private static Delegate GetSetEnterTransition_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetEnterTransition_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEnterTransition_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_transition)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object enterTransition = Java.Lang.Object.GetObject<Java.Lang.Object>(native_transition, JniHandleOwnership.DoNotTransfer);
			fragment.EnterTransition = enterTransition;
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

	private static Delegate GetGetExitTransitionHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetExitTransition);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetExitTransition(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExitTransition);
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

	private static Delegate GetSetExitTransition_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetExitTransition_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetExitTransition_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_transition)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object exitTransition = Java.Lang.Object.GetObject<Java.Lang.Object>(native_transition, JniHandleOwnership.DoNotTransfer);
			fragment.ExitTransition = exitTransition;
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

	private static Delegate GetGetLifecycleHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetLifecycle);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetLifecycle(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Lifecycle);
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
	private static Delegate GetGetLoaderManagerHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetLoaderManager);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetLoaderManager(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LoaderManager);
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

	private static Delegate GetGetReenterTransitionHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetReenterTransition);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetReenterTransition(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReenterTransition);
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

	private static Delegate GetSetReenterTransition_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetReenterTransition_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetReenterTransition_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_transition)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object reenterTransition = Java.Lang.Object.GetObject<Java.Lang.Object>(native_transition, JniHandleOwnership.DoNotTransfer);
			fragment.ReenterTransition = reenterTransition;
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

	private static Delegate GetGetReturnTransitionHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetReturnTransition);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetReturnTransition(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReturnTransition);
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

	private static Delegate GetSetReturnTransition_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetReturnTransition_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetReturnTransition_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_transition)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object returnTransition = Java.Lang.Object.GetObject<Java.Lang.Object>(native_transition, JniHandleOwnership.DoNotTransfer);
			fragment.ReturnTransition = returnTransition;
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

	private static Delegate GetGetSharedElementEnterTransitionHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSharedElementEnterTransition);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSharedElementEnterTransition(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SharedElementEnterTransition);
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

	private static Delegate GetSetSharedElementEnterTransition_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetSharedElementEnterTransition_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSharedElementEnterTransition_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_transition)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object sharedElementEnterTransition = Java.Lang.Object.GetObject<Java.Lang.Object>(native_transition, JniHandleOwnership.DoNotTransfer);
			fragment.SharedElementEnterTransition = sharedElementEnterTransition;
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

	private static Delegate GetGetSharedElementReturnTransitionHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSharedElementReturnTransition);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSharedElementReturnTransition(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SharedElementReturnTransition);
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

	private static Delegate GetSetSharedElementReturnTransition_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetSharedElementReturnTransition_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSharedElementReturnTransition_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_transition)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object sharedElementReturnTransition = Java.Lang.Object.GetObject<Java.Lang.Object>(native_transition, JniHandleOwnership.DoNotTransfer);
			fragment.SharedElementReturnTransition = sharedElementReturnTransition;
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

	[Obsolete]
	private static Delegate GetGetUserVisibleHintHandler()
	{
		return new global::_JniMarshal_PP_B(n_GetUserVisibleHint);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetUserVisibleHint(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UserVisibleHint ? ((sbyte)1) : ((sbyte)0);
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
	private static Delegate GetSetUserVisibleHint_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetUserVisibleHint_Z);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetUserVisibleHint_Z(nint jnienv, nint native__this, sbyte native_isVisibleToUser)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool userVisibleHint = native_isVisibleToUser != 0;
			fragment.UserVisibleHint = userVisibleHint;
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

	private static Delegate GetGetViewHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetView);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).View);
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

	private static Delegate GetGetViewLifecycleOwnerHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetViewLifecycleOwner);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetViewLifecycleOwner(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ViewLifecycleOwner);
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

	private static Delegate GetGetViewLifecycleOwnerLiveDataHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetViewLifecycleOwnerLiveData);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetViewLifecycleOwnerLiveData(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ViewLifecycleOwnerLiveData);
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

	private static Delegate GetGetViewModelStoreHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetViewModelStore);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetViewModelStore(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ViewModelStore);
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
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string prefix = JNIEnv.GetString(native_prefix, JniHandleOwnership.DoNotTransfer);
			FileDescriptor fd = Java.Lang.Object.GetObject<FileDescriptor>(native_fd, JniHandleOwnership.DoNotTransfer);
			PrintWriter writer = Java.Lang.Object.GetObject<PrintWriter>(native_writer, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_args, JniHandleOwnership.DoNotTransfer, typeof(string));
			fragment.Dump(prefix, fd, writer, array);
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

	[Register("equals", "(Ljava/lang/Object;)Z", "")]
	public unsafe sealed override bool Equals(Java.Lang.Object? o)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(o?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("equals.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(o);
		}
	}

	[Obsolete]
	private static Delegate GetGetLayoutInflater_Landroid_os_Bundle_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetLayoutInflater_Landroid_os_Bundle_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetLayoutInflater_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_savedFragmentState)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle savedFragmentState = Java.Lang.Object.GetObject<Bundle>(native_savedFragmentState, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fragment.GetLayoutInflater(savedFragmentState));
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
	[Register("getLayoutInflater", "(Landroid/os/Bundle;)Landroid/view/LayoutInflater;", "GetGetLayoutInflater_Landroid_os_Bundle_Handler")]
	public unsafe virtual LayoutInflater GetLayoutInflater(Bundle? savedFragmentState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(savedFragmentState?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<LayoutInflater>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLayoutInflater.(Landroid/os/Bundle;)Landroid/view/LayoutInflater;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(savedFragmentState);
		}
	}

	[Register("getString", "(I)Ljava/lang/String;", "")]
	public unsafe string GetString(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getString.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("getString", "(I[Ljava/lang/Object;)Ljava/lang/String;", "")]
	public unsafe string GetString(int resId, params Java.Lang.Object[]? formatArgs)
	{
		nint num = JNIEnv.NewArray(formatArgs);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(resId);
			ptr[1] = new JniArgumentValue(num);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getString.(I[Ljava/lang/Object;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (formatArgs != null)
			{
				JNIEnv.CopyArray(num, formatArgs);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(formatArgs);
		}
	}

	[Register("getText", "(I)Ljava/lang/CharSequence;", "")]
	public unsafe ICharSequence GetTextFormatted(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getText.(I)Ljava/lang/CharSequence;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	public string GetText(int resId)
	{
		return GetTextFormatted(resId)?.ToString();
	}

	[Register("hashCode", "()I", "")]
	public unsafe sealed override int GetHashCode()
	{
		return _members.InstanceMethods.InvokeNonvirtualInt32Method("hashCode.()I", this, null);
	}

	[Obsolete("deprecated")]
	[Register("instantiate", "(Landroid/content/Context;Ljava/lang/String;)Landroidx/fragment/app/Fragment;", "")]
	public unsafe static Fragment Instantiate(Context context, string fname)
	{
		nint num = JNIEnv.NewString(fname);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Fragment>(_members.StaticMethods.InvokeObjectMethod("instantiate.(Landroid/content/Context;Ljava/lang/String;)Landroidx/fragment/app/Fragment;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(context);
		}
	}

	[Obsolete("deprecated")]
	[Register("instantiate", "(Landroid/content/Context;Ljava/lang/String;Landroid/os/Bundle;)Landroidx/fragment/app/Fragment;", "")]
	public unsafe static Fragment Instantiate(Context context, string fname, Bundle? args)
	{
		nint num = JNIEnv.NewString(fname);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(args?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Fragment>(_members.StaticMethods.InvokeObjectMethod("instantiate.(Landroid/content/Context;Ljava/lang/String;Landroid/os/Bundle;)Landroidx/fragment/app/Fragment;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(context);
			GC.KeepAlive(args);
		}
	}

	[Obsolete]
	private static Delegate GetOnActivityCreated_Landroid_os_Bundle_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnActivityCreated_Landroid_os_Bundle_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnActivityCreated_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_savedInstanceState)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
			fragment.OnActivityCreated(savedInstanceState);
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
	[Register("onActivityCreated", "(Landroid/os/Bundle;)V", "GetOnActivityCreated_Landroid_os_Bundle_Handler")]
	public unsafe virtual void OnActivityCreated(Bundle? savedInstanceState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onActivityCreated.(Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(savedInstanceState);
		}
	}

	[Obsolete]
	private static Delegate GetOnActivityResult_IILandroid_content_Intent_Handler()
	{
		return new global::_JniMarshal_PPIIL_V(n_OnActivityResult_IILandroid_content_Intent_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnActivityResult_IILandroid_content_Intent_(nint jnienv, nint native__this, int requestCode, int resultCode, nint native_data)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent data = Java.Lang.Object.GetObject<Intent>(native_data, JniHandleOwnership.DoNotTransfer);
			fragment.OnActivityResult(requestCode, resultCode, data);
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
	[Register("onActivityResult", "(IILandroid/content/Intent;)V", "GetOnActivityResult_IILandroid_content_Intent_Handler")]
	public unsafe virtual void OnActivityResult(int requestCode, int resultCode, Intent? data)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(requestCode);
			ptr[1] = new JniArgumentValue(resultCode);
			ptr[2] = new JniArgumentValue(data?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onActivityResult.(IILandroid/content/Intent;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(data);
		}
	}

	[Obsolete]
	private static Delegate GetOnAttach_Landroid_app_Activity_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnAttach_Landroid_app_Activity_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnAttach_Landroid_app_Activity_(nint jnienv, nint native__this, nint native_activity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.App.Activity activity = Java.Lang.Object.GetObject<Android.App.Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
			fragment.OnAttach(activity);
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
	[Register("onAttach", "(Landroid/app/Activity;)V", "GetOnAttach_Landroid_app_Activity_Handler")]
	public unsafe virtual void OnAttach(Android.App.Activity activity)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onAttach.(Landroid/app/Activity;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(activity);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnAttach_Landroid_content_Context_(nint jnienv, nint native__this, nint native_context)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			fragment.OnAttach(context);
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

	[Register("onAttach", "(Landroid/content/Context;)V", "GetOnAttach_Landroid_content_Context_Handler")]
	public unsafe virtual void OnAttach(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onAttach.(Landroid/content/Context;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Obsolete]
	private static Delegate GetOnAttachFragment_Landroidx_fragment_app_Fragment_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnAttachFragment_Landroidx_fragment_app_Fragment_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnAttachFragment_Landroidx_fragment_app_Fragment_(nint jnienv, nint native__this, nint native_childFragment)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Fragment childFragment = Java.Lang.Object.GetObject<Fragment>(native_childFragment, JniHandleOwnership.DoNotTransfer);
			fragment.OnAttachFragment(childFragment);
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
	[Register("onAttachFragment", "(Landroidx/fragment/app/Fragment;)V", "GetOnAttachFragment_Landroidx_fragment_app_Fragment_Handler")]
	public unsafe virtual void OnAttachFragment(Fragment childFragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(childFragment?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onAttachFragment.(Landroidx/fragment/app/Fragment;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(childFragment);
		}
	}

	private static Delegate GetOnConfigurationChanged_Landroid_content_res_Configuration_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnConfigurationChanged_Landroid_content_res_Configuration_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnConfigurationChanged_Landroid_content_res_Configuration_(nint jnienv, nint native__this, nint native_newConfig)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Configuration newConfig = Java.Lang.Object.GetObject<Configuration>(native_newConfig, JniHandleOwnership.DoNotTransfer);
			fragment.OnConfigurationChanged(newConfig);
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

	[Register("onConfigurationChanged", "(Landroid/content/res/Configuration;)V", "GetOnConfigurationChanged_Landroid_content_res_Configuration_Handler")]
	public unsafe virtual void OnConfigurationChanged(Configuration newConfig)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(newConfig?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onConfigurationChanged.(Landroid/content/res/Configuration;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(newConfig);
		}
	}

	private static Delegate GetOnContextItemSelected_Landroid_view_MenuItem_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_OnContextItemSelected_Landroid_view_MenuItem_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnContextItemSelected_Landroid_view_MenuItem_(nint jnienv, nint native__this, nint native_item)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuItem item = Java.Lang.Object.GetObject<IMenuItem>(native_item, JniHandleOwnership.DoNotTransfer);
			return fragment.OnContextItemSelected(item) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onContextItemSelected", "(Landroid/view/MenuItem;)Z", "GetOnContextItemSelected_Landroid_view_MenuItem_Handler")]
	public unsafe virtual bool OnContextItemSelected(IMenuItem item)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((item == null) ? IntPtr.Zero : ((Java.Lang.Object)item).Handle);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onContextItemSelected.(Landroid/view/MenuItem;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(item);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnCreate_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_savedInstanceState)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
			fragment.OnCreate(savedInstanceState);
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

	[Register("onCreate", "(Landroid/os/Bundle;)V", "GetOnCreate_Landroid_os_Bundle_Handler")]
	public unsafe virtual void OnCreate(Bundle? savedInstanceState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onCreate.(Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(savedInstanceState);
		}
	}

	private static Delegate GetOnCreateAnimation_IZIHandler()
	{
		return new _JniMarshal_PPIBI_L(n_OnCreateAnimation_IZI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnCreateAnimation_IZI(nint jnienv, nint native__this, int transit, sbyte native_enter, int nextAnim)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool enter = native_enter != 0;
			return JNIEnv.ToLocalJniHandle(fragment.OnCreateAnimation(transit, enter, nextAnim));
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

	[Register("onCreateAnimation", "(IZI)Landroid/view/animation/Animation;", "GetOnCreateAnimation_IZIHandler")]
	public unsafe virtual Animation? OnCreateAnimation(int transit, bool enter, int nextAnim)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(transit);
		ptr[1] = new JniArgumentValue(enter ? ((sbyte)1) : ((sbyte)0));
		ptr[2] = new JniArgumentValue(nextAnim);
		return Java.Lang.Object.GetObject<Animation>(_members.InstanceMethods.InvokeVirtualObjectMethod("onCreateAnimation.(IZI)Landroid/view/animation/Animation;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetOnCreateAnimator_IZIHandler()
	{
		return new _JniMarshal_PPIBI_L(n_OnCreateAnimator_IZI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnCreateAnimator_IZI(nint jnienv, nint native__this, int transit, sbyte native_enter, int nextAnim)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool enter = native_enter != 0;
			return JNIEnv.ToLocalJniHandle(fragment.OnCreateAnimator(transit, enter, nextAnim));
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

	[Register("onCreateAnimator", "(IZI)Landroid/animation/Animator;", "GetOnCreateAnimator_IZIHandler")]
	public unsafe virtual Animator? OnCreateAnimator(int transit, bool enter, int nextAnim)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(transit);
		ptr[1] = new JniArgumentValue(enter ? ((sbyte)1) : ((sbyte)0));
		ptr[2] = new JniArgumentValue(nextAnim);
		return Java.Lang.Object.GetObject<Animator>(_members.InstanceMethods.InvokeVirtualObjectMethod("onCreateAnimator.(IZI)Landroid/animation/Animator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetOnCreateContextMenu_Landroid_view_ContextMenu_Landroid_view_View_Landroid_view_ContextMenu_ContextMenuInfo_Handler()
	{
		return new global::_JniMarshal_PPLLL_V(n_OnCreateContextMenu_Landroid_view_ContextMenu_Landroid_view_View_Landroid_view_ContextMenu_ContextMenuInfo_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnCreateContextMenu_Landroid_view_ContextMenu_Landroid_view_View_Landroid_view_ContextMenu_ContextMenuInfo_(nint jnienv, nint native__this, nint native_menu, nint native_v, nint native_menuInfo)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IContextMenu menu = Java.Lang.Object.GetObject<IContextMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
			View v = Java.Lang.Object.GetObject<View>(native_v, JniHandleOwnership.DoNotTransfer);
			IContextMenuContextMenuInfo menuInfo = Java.Lang.Object.GetObject<IContextMenuContextMenuInfo>(native_menuInfo, JniHandleOwnership.DoNotTransfer);
			fragment.OnCreateContextMenu(menu, v, menuInfo);
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

	[Register("onCreateContextMenu", "(Landroid/view/ContextMenu;Landroid/view/View;Landroid/view/ContextMenu$ContextMenuInfo;)V", "GetOnCreateContextMenu_Landroid_view_ContextMenu_Landroid_view_View_Landroid_view_ContextMenu_ContextMenuInfo_Handler")]
	public unsafe virtual void OnCreateContextMenu(IContextMenu menu, View v, IContextMenuContextMenuInfo? menuInfo)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue((menu == null) ? IntPtr.Zero : ((Java.Lang.Object)menu).Handle);
			ptr[1] = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((menuInfo == null) ? IntPtr.Zero : ((Java.Lang.Object)menuInfo).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onCreateContextMenu.(Landroid/view/ContextMenu;Landroid/view/View;Landroid/view/ContextMenu$ContextMenuInfo;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(menu);
			GC.KeepAlive(v);
			GC.KeepAlive(menuInfo);
		}
	}

	[Obsolete]
	private static Delegate GetOnCreateOptionsMenu_Landroid_view_Menu_Landroid_view_MenuInflater_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_OnCreateOptionsMenu_Landroid_view_Menu_Landroid_view_MenuInflater_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnCreateOptionsMenu_Landroid_view_Menu_Landroid_view_MenuInflater_(nint jnienv, nint native__this, nint native_menu, nint native_inflater)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenu menu = Java.Lang.Object.GetObject<IMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
			MenuInflater inflater = Java.Lang.Object.GetObject<MenuInflater>(native_inflater, JniHandleOwnership.DoNotTransfer);
			fragment.OnCreateOptionsMenu(menu, inflater);
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
	[Register("onCreateOptionsMenu", "(Landroid/view/Menu;Landroid/view/MenuInflater;)V", "GetOnCreateOptionsMenu_Landroid_view_Menu_Landroid_view_MenuInflater_Handler")]
	public unsafe virtual void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((menu == null) ? IntPtr.Zero : ((Java.Lang.Object)menu).Handle);
			ptr[1] = new JniArgumentValue(inflater?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onCreateOptionsMenu.(Landroid/view/Menu;Landroid/view/MenuInflater;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(menu);
			GC.KeepAlive(inflater);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_inflater, nint native_container, nint native_savedInstanceState)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LayoutInflater inflater = Java.Lang.Object.GetObject<LayoutInflater>(native_inflater, JniHandleOwnership.DoNotTransfer);
			ViewGroup container = Java.Lang.Object.GetObject<ViewGroup>(native_container, JniHandleOwnership.DoNotTransfer);
			Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fragment.OnCreateView(inflater, container, savedInstanceState));
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

	[Register("onCreateView", "(Landroid/view/LayoutInflater;Landroid/view/ViewGroup;Landroid/os/Bundle;)Landroid/view/View;", "GetOnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_Handler")]
	public unsafe virtual View? OnCreateView(LayoutInflater inflater, ViewGroup? container, Bundle? savedInstanceState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(inflater?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("onCreateView.(Landroid/view/LayoutInflater;Landroid/view/ViewGroup;Landroid/os/Bundle;)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(inflater);
			GC.KeepAlive(container);
			GC.KeepAlive(savedInstanceState);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnDestroy(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDestroy();
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

	[Register("onDestroy", "()V", "GetOnDestroyHandler")]
	public unsafe virtual void OnDestroy()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onDestroy.()V", this, null);
	}

	[Obsolete]
	private static Delegate GetOnDestroyOptionsMenuHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnDestroyOptionsMenu);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnDestroyOptionsMenu(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDestroyOptionsMenu();
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
	[Register("onDestroyOptionsMenu", "()V", "GetOnDestroyOptionsMenuHandler")]
	public unsafe virtual void OnDestroyOptionsMenu()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onDestroyOptionsMenu.()V", this, null);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnDestroyView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDestroyView();
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

	[Register("onDestroyView", "()V", "GetOnDestroyViewHandler")]
	public unsafe virtual void OnDestroyView()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onDestroyView.()V", this, null);
	}

	private static Delegate GetOnDetachHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnDetach);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnDetach(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDetach();
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

	[Register("onDetach", "()V", "GetOnDetachHandler")]
	public unsafe virtual void OnDetach()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onDetach.()V", this, null);
	}

	private static Delegate GetOnGetLayoutInflater_Landroid_os_Bundle_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_OnGetLayoutInflater_Landroid_os_Bundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnGetLayoutInflater_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_savedInstanceState)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fragment.OnGetLayoutInflater(savedInstanceState));
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

	[Register("onGetLayoutInflater", "(Landroid/os/Bundle;)Landroid/view/LayoutInflater;", "GetOnGetLayoutInflater_Landroid_os_Bundle_Handler")]
	public unsafe virtual LayoutInflater OnGetLayoutInflater(Bundle? savedInstanceState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<LayoutInflater>(_members.InstanceMethods.InvokeVirtualObjectMethod("onGetLayoutInflater.(Landroid/os/Bundle;)Landroid/view/LayoutInflater;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(savedInstanceState);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnHiddenChanged_Z(nint jnienv, nint native__this, sbyte native_hidden)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool hidden = native_hidden != 0;
			fragment.OnHiddenChanged(hidden);
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

	[Register("onHiddenChanged", "(Z)V", "GetOnHiddenChanged_ZHandler")]
	public unsafe virtual void OnHiddenChanged(bool hidden)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(hidden ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("onHiddenChanged.(Z)V", this, ptr);
	}

	[Obsolete]
	private static Delegate GetOnInflate_Landroid_app_Activity_Landroid_util_AttributeSet_Landroid_os_Bundle_Handler()
	{
		return new global::_JniMarshal_PPLLL_V(n_OnInflate_Landroid_app_Activity_Landroid_util_AttributeSet_Landroid_os_Bundle_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnInflate_Landroid_app_Activity_Landroid_util_AttributeSet_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_activity, nint native_attrs, nint native_savedInstanceState)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.App.Activity activity = Java.Lang.Object.GetObject<Android.App.Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
			IAttributeSet attrs = Java.Lang.Object.GetObject<IAttributeSet>(native_attrs, JniHandleOwnership.DoNotTransfer);
			Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
			fragment.OnInflate(activity, attrs, savedInstanceState);
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
	[Register("onInflate", "(Landroid/app/Activity;Landroid/util/AttributeSet;Landroid/os/Bundle;)V", "GetOnInflate_Landroid_app_Activity_Landroid_util_AttributeSet_Landroid_os_Bundle_Handler")]
	public unsafe virtual void OnInflate(Android.App.Activity activity, IAttributeSet attrs, Bundle? savedInstanceState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onInflate.(Landroid/app/Activity;Landroid/util/AttributeSet;Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(activity);
			GC.KeepAlive(attrs);
			GC.KeepAlive(savedInstanceState);
		}
	}

	private static Delegate GetOnInflate_Landroid_content_Context_Landroid_util_AttributeSet_Landroid_os_Bundle_Handler()
	{
		return new global::_JniMarshal_PPLLL_V(n_OnInflate_Landroid_content_Context_Landroid_util_AttributeSet_Landroid_os_Bundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnInflate_Landroid_content_Context_Landroid_util_AttributeSet_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_context, nint native_attrs, nint native_savedInstanceState)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			IAttributeSet attrs = Java.Lang.Object.GetObject<IAttributeSet>(native_attrs, JniHandleOwnership.DoNotTransfer);
			Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
			fragment.OnInflate(context, attrs, savedInstanceState);
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

	[Register("onInflate", "(Landroid/content/Context;Landroid/util/AttributeSet;Landroid/os/Bundle;)V", "GetOnInflate_Landroid_content_Context_Landroid_util_AttributeSet_Landroid_os_Bundle_Handler")]
	public unsafe virtual void OnInflate(Context context, IAttributeSet attrs, Bundle? savedInstanceState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onInflate.(Landroid/content/Context;Landroid/util/AttributeSet;Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
			GC.KeepAlive(savedInstanceState);
		}
	}

	private static Delegate GetOnLowMemoryHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnLowMemory);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnLowMemory(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnLowMemory();
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

	[Register("onLowMemory", "()V", "GetOnLowMemoryHandler")]
	public unsafe virtual void OnLowMemory()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onLowMemory.()V", this, null);
	}

	private static Delegate GetOnMultiWindowModeChanged_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_OnMultiWindowModeChanged_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnMultiWindowModeChanged_Z(nint jnienv, nint native__this, sbyte native_isInMultiWindowMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool isInMultiWindowMode = native_isInMultiWindowMode != 0;
			fragment.OnMultiWindowModeChanged(isInMultiWindowMode);
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

	[Register("onMultiWindowModeChanged", "(Z)V", "GetOnMultiWindowModeChanged_ZHandler")]
	public unsafe virtual void OnMultiWindowModeChanged(bool isInMultiWindowMode)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(isInMultiWindowMode ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("onMultiWindowModeChanged.(Z)V", this, ptr);
	}

	[Obsolete]
	private static Delegate GetOnOptionsItemSelected_Landroid_view_MenuItem_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_OnOptionsItemSelected_Landroid_view_MenuItem_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnOptionsItemSelected_Landroid_view_MenuItem_(nint jnienv, nint native__this, nint native_item)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuItem item = Java.Lang.Object.GetObject<IMenuItem>(native_item, JniHandleOwnership.DoNotTransfer);
			return fragment.OnOptionsItemSelected(item) ? ((sbyte)1) : ((sbyte)0);
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
	[Register("onOptionsItemSelected", "(Landroid/view/MenuItem;)Z", "GetOnOptionsItemSelected_Landroid_view_MenuItem_Handler")]
	public unsafe virtual bool OnOptionsItemSelected(IMenuItem item)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((item == null) ? IntPtr.Zero : ((Java.Lang.Object)item).Handle);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onOptionsItemSelected.(Landroid/view/MenuItem;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(item);
		}
	}

	[Obsolete]
	private static Delegate GetOnOptionsMenuClosed_Landroid_view_Menu_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnOptionsMenuClosed_Landroid_view_Menu_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnOptionsMenuClosed_Landroid_view_Menu_(nint jnienv, nint native__this, nint native_menu)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenu menu = Java.Lang.Object.GetObject<IMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
			fragment.OnOptionsMenuClosed(menu);
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
	[Register("onOptionsMenuClosed", "(Landroid/view/Menu;)V", "GetOnOptionsMenuClosed_Landroid_view_Menu_Handler")]
	public unsafe virtual void OnOptionsMenuClosed(IMenu menu)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((menu == null) ? IntPtr.Zero : ((Java.Lang.Object)menu).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onOptionsMenuClosed.(Landroid/view/Menu;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(menu);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnPause(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnPause();
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

	[Register("onPause", "()V", "GetOnPauseHandler")]
	public unsafe virtual void OnPause()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onPause.()V", this, null);
	}

	private static Delegate GetOnPictureInPictureModeChanged_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_OnPictureInPictureModeChanged_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnPictureInPictureModeChanged_Z(nint jnienv, nint native__this, sbyte native_isInPictureInPictureMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool isInPictureInPictureMode = native_isInPictureInPictureMode != 0;
			fragment.OnPictureInPictureModeChanged(isInPictureInPictureMode);
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

	[Register("onPictureInPictureModeChanged", "(Z)V", "GetOnPictureInPictureModeChanged_ZHandler")]
	public unsafe virtual void OnPictureInPictureModeChanged(bool isInPictureInPictureMode)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(isInPictureInPictureMode ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("onPictureInPictureModeChanged.(Z)V", this, ptr);
	}

	[Obsolete]
	private static Delegate GetOnPrepareOptionsMenu_Landroid_view_Menu_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnPrepareOptionsMenu_Landroid_view_Menu_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnPrepareOptionsMenu_Landroid_view_Menu_(nint jnienv, nint native__this, nint native_menu)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenu menu = Java.Lang.Object.GetObject<IMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
			fragment.OnPrepareOptionsMenu(menu);
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
	[Register("onPrepareOptionsMenu", "(Landroid/view/Menu;)V", "GetOnPrepareOptionsMenu_Landroid_view_Menu_Handler")]
	public unsafe virtual void OnPrepareOptionsMenu(IMenu menu)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((menu == null) ? IntPtr.Zero : ((Java.Lang.Object)menu).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onPrepareOptionsMenu.(Landroid/view/Menu;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(menu);
		}
	}

	private static Delegate GetOnPrimaryNavigationFragmentChanged_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_OnPrimaryNavigationFragmentChanged_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnPrimaryNavigationFragmentChanged_Z(nint jnienv, nint native__this, sbyte native_isPrimaryNavigationFragment)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool isPrimaryNavigationFragment = native_isPrimaryNavigationFragment != 0;
			fragment.OnPrimaryNavigationFragmentChanged(isPrimaryNavigationFragment);
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

	[Register("onPrimaryNavigationFragmentChanged", "(Z)V", "GetOnPrimaryNavigationFragmentChanged_ZHandler")]
	public unsafe virtual void OnPrimaryNavigationFragmentChanged(bool isPrimaryNavigationFragment)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(isPrimaryNavigationFragment ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("onPrimaryNavigationFragmentChanged.(Z)V", this, ptr);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnRequestPermissionsResult_IarrayLjava_lang_String_arrayI(nint jnienv, nint native__this, int requestCode, nint native_permissions, nint native_grantResults)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_permissions, JniHandleOwnership.DoNotTransfer, typeof(string));
			Permission[] array2 = (Permission[])JNIEnv.GetArray(native_grantResults, JniHandleOwnership.DoNotTransfer, typeof(Permission));
			fragment.OnRequestPermissionsResult(requestCode, array, array2);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_permissions);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_grantResults);
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

	[Obsolete("deprecated")]
	[Register("onRequestPermissionsResult", "(I[Ljava/lang/String;[I)V", "GetOnRequestPermissionsResult_IarrayLjava_lang_String_arrayIHandler")]
	public unsafe virtual void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
	{
		nint num = JNIEnv.NewArray(permissions);
		nint num2 = JNIEnv.NewArray(grantResults);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(requestCode);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onRequestPermissionsResult.(I[Ljava/lang/String;[I)V", this, ptr);
		}
		finally
		{
			if (permissions != null)
			{
				JNIEnv.CopyArray(num, permissions);
				JNIEnv.DeleteLocalRef(num);
			}
			if (grantResults != null)
			{
				JNIEnv.CopyArray(num2, grantResults);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(permissions);
			GC.KeepAlive(grantResults);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnResume(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnResume();
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

	[Register("onResume", "()V", "GetOnResumeHandler")]
	public unsafe virtual void OnResume()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onResume.()V", this, null);
	}

	private static Delegate GetOnSaveInstanceState_Landroid_os_Bundle_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnSaveInstanceState_Landroid_os_Bundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnSaveInstanceState_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_outState)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle outState = Java.Lang.Object.GetObject<Bundle>(native_outState, JniHandleOwnership.DoNotTransfer);
			fragment.OnSaveInstanceState(outState);
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

	[Register("onSaveInstanceState", "(Landroid/os/Bundle;)V", "GetOnSaveInstanceState_Landroid_os_Bundle_Handler")]
	public unsafe virtual void OnSaveInstanceState(Bundle outState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(outState?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onSaveInstanceState.(Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(outState);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnStart(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStart();
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

	[Register("onStart", "()V", "GetOnStartHandler")]
	public unsafe virtual void OnStart()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onStart.()V", this, null);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnStop(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStop();
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

	[Register("onStop", "()V", "GetOnStopHandler")]
	public unsafe virtual void OnStop()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onStop.()V", this, null);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnViewCreated_Landroid_view_View_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_view, nint native_savedInstanceState)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
			fragment.OnViewCreated(view, savedInstanceState);
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

	[Register("onViewCreated", "(Landroid/view/View;Landroid/os/Bundle;)V", "GetOnViewCreated_Landroid_view_View_Landroid_os_Bundle_Handler")]
	public unsafe virtual void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onViewCreated.(Landroid/view/View;Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(savedInstanceState);
		}
	}

	private static Delegate GetOnViewStateRestored_Landroid_os_Bundle_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnViewStateRestored_Landroid_os_Bundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnViewStateRestored_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_savedInstanceState)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
			fragment.OnViewStateRestored(savedInstanceState);
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

	[Register("onViewStateRestored", "(Landroid/os/Bundle;)V", "GetOnViewStateRestored_Landroid_os_Bundle_Handler")]
	public unsafe virtual void OnViewStateRestored(Bundle? savedInstanceState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onViewStateRestored.(Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(savedInstanceState);
		}
	}

	private static Delegate GetPostponeEnterTransitionHandler()
	{
		return new global::_JniMarshal_PP_V(n_PostponeEnterTransition);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_PostponeEnterTransition(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PostponeEnterTransition();
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

	[Register("postponeEnterTransition", "()V", "GetPostponeEnterTransitionHandler")]
	public unsafe virtual void PostponeEnterTransition()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("postponeEnterTransition.()V", this, null);
	}

	[Register("postponeEnterTransition", "(JLjava/util/concurrent/TimeUnit;)V", "")]
	public unsafe void PostponeEnterTransition(long duration, TimeUnit timeUnit)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(duration);
			ptr[1] = new JniArgumentValue(timeUnit?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("postponeEnterTransition.(JLjava/util/concurrent/TimeUnit;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(timeUnit);
		}
	}

	[Register("registerForActivityResult", "(Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;", "")]
	[JavaTypeParameters(new string[] { "I", "O" })]
	public unsafe ActivityResultLauncher RegisterForActivityResult(ActivityResultContract contract, IActivityResultCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(contract?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<ActivityResultLauncher>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("registerForActivityResult.(Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(contract);
			GC.KeepAlive(callback);
		}
	}

	[Register("registerForActivityResult", "(Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultRegistry;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;", "")]
	[JavaTypeParameters(new string[] { "I", "O" })]
	public unsafe ActivityResultLauncher RegisterForActivityResult(ActivityResultContract contract, ActivityResultRegistry registry, IActivityResultCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(contract?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(registry?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<ActivityResultLauncher>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("registerForActivityResult.(Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultRegistry;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(contract);
			GC.KeepAlive(registry);
			GC.KeepAlive(callback);
		}
	}

	private static Delegate GetRegisterForContextMenu_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RegisterForContextMenu_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RegisterForContextMenu_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			fragment.RegisterForContextMenu(view);
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

	[Register("registerForContextMenu", "(Landroid/view/View;)V", "GetRegisterForContextMenu_Landroid_view_View_Handler")]
	public unsafe virtual void RegisterForContextMenu(View view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("registerForContextMenu.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("requestPermissions", "([Ljava/lang/String;I)V", "")]
	public unsafe void RequestPermissions(string[] permissions, int requestCode)
	{
		nint num = JNIEnv.NewArray(permissions);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(requestCode);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("requestPermissions.([Ljava/lang/String;I)V", this, ptr);
		}
		finally
		{
			if (permissions != null)
			{
				JNIEnv.CopyArray(num, permissions);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(permissions);
		}
	}

	[Register("requireActivity", "()Landroidx/fragment/app/FragmentActivity;", "")]
	public unsafe FragmentActivity RequireActivity()
	{
		return Java.Lang.Object.GetObject<FragmentActivity>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("requireActivity.()Landroidx/fragment/app/FragmentActivity;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("requireArguments", "()Landroid/os/Bundle;", "")]
	public unsafe Bundle RequireArguments()
	{
		return Java.Lang.Object.GetObject<Bundle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("requireArguments.()Landroid/os/Bundle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("requireContext", "()Landroid/content/Context;", "")]
	public unsafe Context RequireContext()
	{
		return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("requireContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Obsolete("deprecated")]
	[Register("requireFragmentManager", "()Landroidx/fragment/app/FragmentManager;", "")]
	public unsafe FragmentManager RequireFragmentManager()
	{
		return Java.Lang.Object.GetObject<FragmentManager>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("requireFragmentManager.()Landroidx/fragment/app/FragmentManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("requireHost", "()Ljava/lang/Object;", "")]
	public unsafe Java.Lang.Object RequireHost()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("requireHost.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("requireParentFragment", "()Landroidx/fragment/app/Fragment;", "")]
	public unsafe Fragment RequireParentFragment()
	{
		return Java.Lang.Object.GetObject<Fragment>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("requireParentFragment.()Landroidx/fragment/app/Fragment;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("requireView", "()Landroid/view/View;", "")]
	public unsafe View RequireView()
	{
		return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("requireView.()Landroid/view/View;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetEnterSharedElementCallback_Landroidx_core_app_SharedElementCallback_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetEnterSharedElementCallback_Landroidx_core_app_SharedElementCallback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEnterSharedElementCallback_Landroidx_core_app_SharedElementCallback_(nint jnienv, nint native__this, nint native__callback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SharedElementCallback enterSharedElementCallback = Java.Lang.Object.GetObject<SharedElementCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			fragment.SetEnterSharedElementCallback(enterSharedElementCallback);
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

	[Register("setEnterSharedElementCallback", "(Landroidx/core/app/SharedElementCallback;)V", "GetSetEnterSharedElementCallback_Landroidx_core_app_SharedElementCallback_Handler")]
	public unsafe virtual void SetEnterSharedElementCallback(SharedElementCallback? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setEnterSharedElementCallback.(Landroidx/core/app/SharedElementCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	private static Delegate GetSetExitSharedElementCallback_Landroidx_core_app_SharedElementCallback_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetExitSharedElementCallback_Landroidx_core_app_SharedElementCallback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetExitSharedElementCallback_Landroidx_core_app_SharedElementCallback_(nint jnienv, nint native__this, nint native__callback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SharedElementCallback exitSharedElementCallback = Java.Lang.Object.GetObject<SharedElementCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			fragment.SetExitSharedElementCallback(exitSharedElementCallback);
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

	[Register("setExitSharedElementCallback", "(Landroidx/core/app/SharedElementCallback;)V", "GetSetExitSharedElementCallback_Landroidx_core_app_SharedElementCallback_Handler")]
	public unsafe virtual void SetExitSharedElementCallback(SharedElementCallback? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setExitSharedElementCallback.(Landroidx/core/app/SharedElementCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	private static Delegate GetSetInitialSavedState_Landroidx_fragment_app_Fragment_SavedState_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetInitialSavedState_Landroidx_fragment_app_Fragment_SavedState_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetInitialSavedState_Landroidx_fragment_app_Fragment_SavedState_(nint jnienv, nint native__this, nint native_state)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SavedState initialSavedState = Java.Lang.Object.GetObject<SavedState>(native_state, JniHandleOwnership.DoNotTransfer);
			fragment.SetInitialSavedState(initialSavedState);
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

	[Register("setInitialSavedState", "(Landroidx/fragment/app/Fragment$SavedState;)V", "GetSetInitialSavedState_Landroidx_fragment_app_Fragment_SavedState_Handler")]
	public unsafe virtual void SetInitialSavedState(SavedState? state)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setInitialSavedState.(Landroidx/fragment/app/Fragment$SavedState;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(state);
		}
	}

	private static Delegate GetSetMenuVisibility_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetMenuVisibility_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMenuVisibility_Z(nint jnienv, nint native__this, sbyte native_menuVisible)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool menuVisibility = native_menuVisible != 0;
			fragment.SetMenuVisibility(menuVisibility);
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

	[Register("setMenuVisibility", "(Z)V", "GetSetMenuVisibility_ZHandler")]
	public unsafe virtual void SetMenuVisibility(bool menuVisible)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(menuVisible ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setMenuVisibility.(Z)V", this, ptr);
	}

	[Obsolete]
	private static Delegate GetSetTargetFragment_Landroidx_fragment_app_Fragment_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_SetTargetFragment_Landroidx_fragment_app_Fragment_I);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTargetFragment_Landroidx_fragment_app_Fragment_I(nint jnienv, nint native__this, nint native_fragment, int requestCode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Fragment fragment2 = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
			fragment.SetTargetFragment(fragment2, requestCode);
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
	[Register("setTargetFragment", "(Landroidx/fragment/app/Fragment;I)V", "GetSetTargetFragment_Landroidx_fragment_app_Fragment_IHandler")]
	public unsafe virtual void SetTargetFragment(Fragment? fragment, int requestCode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(requestCode);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTargetFragment.(Landroidx/fragment/app/Fragment;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	private static Delegate GetShouldShowRequestPermissionRationale_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_ShouldShowRequestPermissionRationale_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ShouldShowRequestPermissionRationale_Ljava_lang_String_(nint jnienv, nint native__this, nint native_permission)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string permission = JNIEnv.GetString(native_permission, JniHandleOwnership.DoNotTransfer);
			return fragment.ShouldShowRequestPermissionRationale(permission) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("shouldShowRequestPermissionRationale", "(Ljava/lang/String;)Z", "GetShouldShowRequestPermissionRationale_Ljava_lang_String_Handler")]
	public unsafe virtual bool ShouldShowRequestPermissionRationale(string permission)
	{
		nint num = JNIEnv.NewString(permission);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("shouldShowRequestPermissionRationale.(Ljava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetStartActivity_Landroid_content_Intent_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_StartActivity_Landroid_content_Intent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_StartActivity_Landroid_content_Intent_(nint jnienv, nint native__this, nint native_intent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			fragment.StartActivity(intent);
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

	[Register("startActivity", "(Landroid/content/Intent;)V", "GetStartActivity_Landroid_content_Intent_Handler")]
	public unsafe virtual void StartActivity(Intent intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("startActivity.(Landroid/content/Intent;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	private static Delegate GetStartActivity_Landroid_content_Intent_Landroid_os_Bundle_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_StartActivity_Landroid_content_Intent_Landroid_os_Bundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_StartActivity_Landroid_content_Intent_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_intent, nint native_options)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			Bundle options = Java.Lang.Object.GetObject<Bundle>(native_options, JniHandleOwnership.DoNotTransfer);
			fragment.StartActivity(intent, options);
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

	[Register("startActivity", "(Landroid/content/Intent;Landroid/os/Bundle;)V", "GetStartActivity_Landroid_content_Intent_Landroid_os_Bundle_Handler")]
	public unsafe virtual void StartActivity(Intent intent, Bundle? options)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("startActivity.(Landroid/content/Intent;Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
			GC.KeepAlive(options);
		}
	}

	[Obsolete]
	private static Delegate GetStartActivityForResult_Landroid_content_Intent_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_StartActivityForResult_Landroid_content_Intent_I);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_StartActivityForResult_Landroid_content_Intent_I(nint jnienv, nint native__this, nint native_intent, int requestCode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			fragment.StartActivityForResult(intent, requestCode);
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
	[Register("startActivityForResult", "(Landroid/content/Intent;I)V", "GetStartActivityForResult_Landroid_content_Intent_IHandler")]
	public unsafe virtual void StartActivityForResult(Intent intent, int requestCode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(requestCode);
			_members.InstanceMethods.InvokeVirtualVoidMethod("startActivityForResult.(Landroid/content/Intent;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Obsolete]
	private static Delegate GetStartActivityForResult_Landroid_content_Intent_ILandroid_os_Bundle_Handler()
	{
		return new global::_JniMarshal_PPLIL_V(n_StartActivityForResult_Landroid_content_Intent_ILandroid_os_Bundle_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_StartActivityForResult_Landroid_content_Intent_ILandroid_os_Bundle_(nint jnienv, nint native__this, nint native_intent, int requestCode, nint native_options)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			Bundle options = Java.Lang.Object.GetObject<Bundle>(native_options, JniHandleOwnership.DoNotTransfer);
			fragment.StartActivityForResult(intent, requestCode, options);
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
	[Register("startActivityForResult", "(Landroid/content/Intent;ILandroid/os/Bundle;)V", "GetStartActivityForResult_Landroid_content_Intent_ILandroid_os_Bundle_Handler")]
	public unsafe virtual void StartActivityForResult(Intent intent, int requestCode, Bundle? options)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(requestCode);
			ptr[2] = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("startActivityForResult.(Landroid/content/Intent;ILandroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
			GC.KeepAlive(options);
		}
	}

	[Obsolete]
	private static Delegate GetStartIntentSenderForResult_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_Handler()
	{
		return new _JniMarshal_PPLILIIIL_V(n_StartIntentSenderForResult_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_StartIntentSenderForResult_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_(nint jnienv, nint native__this, nint native_intent, int requestCode, nint native_fillInIntent, int flagsMask, int flagsValues, int extraFlags, nint native_options)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IntentSender intent = Java.Lang.Object.GetObject<IntentSender>(native_intent, JniHandleOwnership.DoNotTransfer);
			Intent fillInIntent = Java.Lang.Object.GetObject<Intent>(native_fillInIntent, JniHandleOwnership.DoNotTransfer);
			Bundle options = Java.Lang.Object.GetObject<Bundle>(native_options, JniHandleOwnership.DoNotTransfer);
			fragment.StartIntentSenderForResult(intent, requestCode, fillInIntent, flagsMask, flagsValues, extraFlags, options);
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
	[Register("startIntentSenderForResult", "(Landroid/content/IntentSender;ILandroid/content/Intent;IIILandroid/os/Bundle;)V", "GetStartIntentSenderForResult_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_Handler")]
	public unsafe virtual void StartIntentSenderForResult(IntentSender intent, int requestCode, Intent? fillInIntent, int flagsMask, int flagsValues, int extraFlags, Bundle? options)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(requestCode);
			ptr[2] = new JniArgumentValue(fillInIntent?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(flagsMask);
			ptr[4] = new JniArgumentValue(flagsValues);
			ptr[5] = new JniArgumentValue(extraFlags);
			ptr[6] = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("startIntentSenderForResult.(Landroid/content/IntentSender;ILandroid/content/Intent;IIILandroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
			GC.KeepAlive(fillInIntent);
			GC.KeepAlive(options);
		}
	}

	private static Delegate GetStartPostponedEnterTransitionHandler()
	{
		return new global::_JniMarshal_PP_V(n_StartPostponedEnterTransition);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_StartPostponedEnterTransition(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartPostponedEnterTransition();
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

	[Register("startPostponedEnterTransition", "()V", "GetStartPostponedEnterTransitionHandler")]
	public unsafe virtual void StartPostponedEnterTransition()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("startPostponedEnterTransition.()V", this, null);
	}

	private static Delegate GetUnregisterForContextMenu_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_UnregisterForContextMenu_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UnregisterForContextMenu_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Fragment? fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			fragment.UnregisterForContextMenu(view);
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

	[Register("unregisterForContextMenu", "(Landroid/view/View;)V", "GetUnregisterForContextMenu_Landroid_view_View_Handler")]
	public unsafe virtual void UnregisterForContextMenu(View view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("unregisterForContextMenu.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
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

	[UnmanagedCallersOnly]
	private static void n_OnViewCreated_Landroid_view_View_Landroid_os_Bundle__mm_wrapper(nint jnienv, nint native__this, nint native_view, nint native_savedInstanceState)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnViewCreated_Landroid_view_View_Landroid_os_Bundle_(jnienv, native__this, native_view, native_savedInstanceState);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnCreate_Landroid_os_Bundle__mm_wrapper(nint jnienv, nint native__this, nint native_savedInstanceState)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnCreate_Landroid_os_Bundle_(jnienv, native__this, native_savedInstanceState);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnDestroy_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnDestroy(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnDestroyView_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnDestroyView(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnResume_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnResume(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnPause_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnPause(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnAttach_Landroid_content_Context__mm_wrapper(nint jnienv, nint native__this, nint native_context)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnAttach_Landroid_content_Context_(jnienv, native__this, native_context);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnStart_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnStart(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnStop_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnStop(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnHiddenChanged_Z_mm_wrapper(nint jnienv, nint native__this, sbyte native_hidden)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnHiddenChanged_Z(jnienv, native__this, native_hidden);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnRequestPermissionsResult_IarrayLjava_lang_String_arrayI_mm_wrapper(nint jnienv, nint native__this, int requestCode, nint native_permissions, nint native_grantResults)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnRequestPermissionsResult_IarrayLjava_lang_String_arrayI(jnienv, native__this, requestCode, native_permissions, native_grantResults);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_OnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle__mm_wrapper(nint jnienv, nint native__this, nint native_inflater, nint native_container, nint native_savedInstanceState)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_OnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_(jnienv, native__this, native_inflater, native_container, native_savedInstanceState);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}
}
