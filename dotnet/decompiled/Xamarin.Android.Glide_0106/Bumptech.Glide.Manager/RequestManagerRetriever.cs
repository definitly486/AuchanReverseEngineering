using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.Fragment.App;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Manager;

[Register("com/bumptech/glide/manager/RequestManagerRetriever", DoNotGenerateAcw = true)]
public class RequestManagerRetriever : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("com/bumptech/glide/manager/RequestManagerRetriever$RequestManagerFactory", "", "Bumptech.Glide.Manager.RequestManagerRetriever/IRequestManagerFactoryInvoker")]
	public interface IRequestManagerFactory : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("build", "(Lcom/bumptech/glide/Glide;Lcom/bumptech/glide/manager/Lifecycle;Lcom/bumptech/glide/manager/RequestManagerTreeNode;Landroid/content/Context;)Lcom/bumptech/glide/RequestManager;", "GetBuild_Lcom_bumptech_glide_Glide_Lcom_bumptech_glide_manager_Lifecycle_Lcom_bumptech_glide_manager_RequestManagerTreeNode_Landroid_content_Context_Handler:Bumptech.Glide.Manager.RequestManagerRetriever/IRequestManagerFactoryInvoker, Xamarin.Android.Glide")]
		RequestManager Build(Glide p0, ILifecycle p1, IRequestManagerTreeNode p2, Context p3);
	}

	[Register("com/bumptech/glide/manager/RequestManagerRetriever$RequestManagerFactory", DoNotGenerateAcw = true)]
	internal class IRequestManagerFactoryInvoker : Java.Lang.Object, IRequestManagerFactory, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_bumptech_glide_manager_RequestManagerRetriever_RequestManagerFactory = new XAPeerMembers("com/bumptech/glide/manager/RequestManagerRetriever$RequestManagerFactory", typeof(IRequestManagerFactoryInvoker));

		private static Delegate? cb_build_Build_Lcom_bumptech_glide_Glide_Lcom_bumptech_glide_manager_Lifecycle_Lcom_bumptech_glide_manager_RequestManagerTreeNode_Landroid_content_Context__Lcom_bumptech_glide_RequestManager_;

		private static nint java_class_ref => _members_com_bumptech_glide_manager_RequestManagerRetriever_RequestManagerFactory.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_manager_RequestManagerRetriever_RequestManagerFactory;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_bumptech_glide_manager_RequestManagerRetriever_RequestManagerFactory.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_bumptech_glide_manager_RequestManagerRetriever_RequestManagerFactory.ManagedPeerType;

		public IRequestManagerFactoryInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetBuild_Lcom_bumptech_glide_Glide_Lcom_bumptech_glide_manager_Lifecycle_Lcom_bumptech_glide_manager_RequestManagerTreeNode_Landroid_content_Context_Handler()
		{
			return new global::_JniMarshal_PPLLLL_L(n_Build_Lcom_bumptech_glide_Glide_Lcom_bumptech_glide_manager_Lifecycle_Lcom_bumptech_glide_manager_RequestManagerTreeNode_Landroid_content_Context_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_Build_Lcom_bumptech_glide_Glide_Lcom_bumptech_glide_manager_Lifecycle_Lcom_bumptech_glide_manager_RequestManagerTreeNode_Landroid_content_Context_(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2, nint native_p3)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IRequestManagerFactory? requestManagerFactory = Java.Lang.Object.GetObject<IRequestManagerFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Glide p = Java.Lang.Object.GetObject<Glide>(native_p0, JniHandleOwnership.DoNotTransfer);
				ILifecycle p2 = Java.Lang.Object.GetObject<ILifecycle>(native_p1, JniHandleOwnership.DoNotTransfer);
				IRequestManagerTreeNode p3 = Java.Lang.Object.GetObject<IRequestManagerTreeNode>(native_p2, JniHandleOwnership.DoNotTransfer);
				Context p4 = Java.Lang.Object.GetObject<Context>(native_p3, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(requestManagerFactory.Build(p, p2, p3, p4));
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

		public unsafe RequestManager Build(Glide p0, ILifecycle p1, IRequestManagerTreeNode p2, Context p3)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
				ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
				ptr[3] = new JniArgumentValue(p3?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<RequestManager>(_members_com_bumptech_glide_manager_RequestManagerRetriever_RequestManagerFactory.InstanceMethods.InvokeAbstractObjectMethod("build.(Lcom/bumptech/glide/Glide;Lcom/bumptech/glide/manager/Lifecycle;Lcom/bumptech/glide/manager/RequestManagerTreeNode;Landroid/content/Context;)Lcom/bumptech/glide/RequestManager;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
				GC.KeepAlive(p2);
				GC.KeepAlive(p3);
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/manager/RequestManagerRetriever", typeof(RequestManagerRetriever));

	private static Delegate? cb_get_Get_Landroid_app_Activity__Lcom_bumptech_glide_RequestManager_;

	private static Delegate? cb_get_Get_Landroid_app_Fragment__Lcom_bumptech_glide_RequestManager_;

	private static Delegate? cb_get_Get_Landroid_content_Context__Lcom_bumptech_glide_RequestManager_;

	private static Delegate? cb_get_Get_Landroid_view_View__Lcom_bumptech_glide_RequestManager_;

	private static Delegate? cb_get_Get_Landroidx_fragment_app_Fragment__Lcom_bumptech_glide_RequestManager_;

	private static Delegate? cb_get_Get_Landroidx_fragment_app_FragmentActivity__Lcom_bumptech_glide_RequestManager_;

	private static Delegate? cb_handleMessage_HandleMessage_Landroid_os_Message__Z;

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

	protected RequestManagerRetriever(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Lcom/bumptech/glide/manager/RequestManagerRetriever$RequestManagerFactory;)V", "")]
	public unsafe RequestManagerRetriever(IRequestManagerFactory? factory)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((factory == null) ? IntPtr.Zero : ((Java.Lang.Object)factory).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/bumptech/glide/manager/RequestManagerRetriever$RequestManagerFactory;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/bumptech/glide/manager/RequestManagerRetriever$RequestManagerFactory;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(factory);
		}
	}

	[Obsolete]
	private static Delegate GetGet_Landroid_app_Activity_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Get_Landroid_app_Activity_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Get_Landroid_app_Activity_(nint jnienv, nint native__this, nint native_activity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestManagerRetriever? requestManagerRetriever = Java.Lang.Object.GetObject<RequestManagerRetriever>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestManagerRetriever.Get(activity));
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
	[Register("get", "(Landroid/app/Activity;)Lcom/bumptech/glide/RequestManager;", "GetGet_Landroid_app_Activity_Handler")]
	public unsafe virtual RequestManager Get(Activity activity)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestManager>(_members.InstanceMethods.InvokeVirtualObjectMethod("get.(Landroid/app/Activity;)Lcom/bumptech/glide/RequestManager;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(activity);
		}
	}

	[Obsolete]
	private static Delegate GetGet_Landroid_app_Fragment_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Get_Landroid_app_Fragment_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Get_Landroid_app_Fragment_(nint jnienv, nint native__this, nint native_fragment)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestManagerRetriever? requestManagerRetriever = Java.Lang.Object.GetObject<RequestManagerRetriever>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.App.Fragment fragment = Java.Lang.Object.GetObject<Android.App.Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestManagerRetriever.Get(fragment));
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
	[Register("get", "(Landroid/app/Fragment;)Lcom/bumptech/glide/RequestManager;", "GetGet_Landroid_app_Fragment_Handler")]
	public unsafe virtual RequestManager Get(Android.App.Fragment fragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestManager>(_members.InstanceMethods.InvokeVirtualObjectMethod("get.(Landroid/app/Fragment;)Lcom/bumptech/glide/RequestManager;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	private static Delegate GetGet_Landroid_content_Context_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Get_Landroid_content_Context_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Get_Landroid_content_Context_(nint jnienv, nint native__this, nint native_context)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestManagerRetriever? requestManagerRetriever = Java.Lang.Object.GetObject<RequestManagerRetriever>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestManagerRetriever.Get(context));
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

	[Register("get", "(Landroid/content/Context;)Lcom/bumptech/glide/RequestManager;", "GetGet_Landroid_content_Context_Handler")]
	public unsafe virtual RequestManager Get(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestManager>(_members.InstanceMethods.InvokeVirtualObjectMethod("get.(Landroid/content/Context;)Lcom/bumptech/glide/RequestManager;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetGet_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Get_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Get_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestManagerRetriever? requestManagerRetriever = Java.Lang.Object.GetObject<RequestManagerRetriever>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestManagerRetriever.Get(view));
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

	[Register("get", "(Landroid/view/View;)Lcom/bumptech/glide/RequestManager;", "GetGet_Landroid_view_View_Handler")]
	public unsafe virtual RequestManager Get(View view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestManager>(_members.InstanceMethods.InvokeVirtualObjectMethod("get.(Landroid/view/View;)Lcom/bumptech/glide/RequestManager;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetGet_Landroidx_fragment_app_Fragment_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Get_Landroidx_fragment_app_Fragment_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Get_Landroidx_fragment_app_Fragment_(nint jnienv, nint native__this, nint native_fragment)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestManagerRetriever? requestManagerRetriever = Java.Lang.Object.GetObject<RequestManagerRetriever>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AndroidX.Fragment.App.Fragment fragment = Java.Lang.Object.GetObject<AndroidX.Fragment.App.Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestManagerRetriever.Get(fragment));
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

	[Register("get", "(Landroidx/fragment/app/Fragment;)Lcom/bumptech/glide/RequestManager;", "GetGet_Landroidx_fragment_app_Fragment_Handler")]
	public unsafe virtual RequestManager Get(AndroidX.Fragment.App.Fragment fragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestManager>(_members.InstanceMethods.InvokeVirtualObjectMethod("get.(Landroidx/fragment/app/Fragment;)Lcom/bumptech/glide/RequestManager;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	private static Delegate GetGet_Landroidx_fragment_app_FragmentActivity_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Get_Landroidx_fragment_app_FragmentActivity_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Get_Landroidx_fragment_app_FragmentActivity_(nint jnienv, nint native__this, nint native_activity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestManagerRetriever? requestManagerRetriever = Java.Lang.Object.GetObject<RequestManagerRetriever>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FragmentActivity activity = Java.Lang.Object.GetObject<FragmentActivity>(native_activity, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestManagerRetriever.Get(activity));
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

	[Register("get", "(Landroidx/fragment/app/FragmentActivity;)Lcom/bumptech/glide/RequestManager;", "GetGet_Landroidx_fragment_app_FragmentActivity_Handler")]
	public unsafe virtual RequestManager Get(FragmentActivity activity)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(((Java.Lang.Object)(object)activity)?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestManager>(_members.InstanceMethods.InvokeVirtualObjectMethod("get.(Landroidx/fragment/app/FragmentActivity;)Lcom/bumptech/glide/RequestManager;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(activity);
		}
	}

	[Obsolete]
	private static Delegate GetHandleMessage_Landroid_os_Message_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_HandleMessage_Landroid_os_Message_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HandleMessage_Landroid_os_Message_(nint jnienv, nint native__this, nint native_message)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestManagerRetriever? requestManagerRetriever = Java.Lang.Object.GetObject<RequestManagerRetriever>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Message message = Java.Lang.Object.GetObject<Message>(native_message, JniHandleOwnership.DoNotTransfer);
			return requestManagerRetriever.HandleMessage(message) ? ((sbyte)1) : ((sbyte)0);
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
	[Register("handleMessage", "(Landroid/os/Message;)Z", "GetHandleMessage_Landroid_os_Message_Handler")]
	public unsafe virtual bool HandleMessage(Message? message)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(message?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("handleMessage.(Landroid/os/Message;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(message);
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
