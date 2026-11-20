using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Loader.Content;

[Register("androidx/loader/content/Loader", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "D" })]
public class Loader : Java.Lang.Object
{
	[Register("androidx/loader/content/Loader$OnLoadCanceledListener", "", "AndroidX.Loader.Content.Loader/IOnLoadCanceledListenerInvoker")]
	[JavaTypeParameters(new string[] { "D" })]
	public interface IOnLoadCanceledListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onLoadCanceled", "(Landroidx/loader/content/Loader;)V", "GetOnLoadCanceled_Landroidx_loader_content_Loader_Handler:AndroidX.Loader.Content.Loader/IOnLoadCanceledListenerInvoker, Xamarin.AndroidX.Loader")]
		void OnLoadCanceled(Loader loader);
	}

	[Register("androidx/loader/content/Loader$OnLoadCanceledListener", DoNotGenerateAcw = true)]
	internal class IOnLoadCanceledListenerInvoker : Java.Lang.Object, IOnLoadCanceledListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_loader_content_Loader_OnLoadCanceledListener = new XAPeerMembers("androidx/loader/content/Loader$OnLoadCanceledListener", typeof(IOnLoadCanceledListenerInvoker));

		private static Delegate? cb_onLoadCanceled_OnLoadCanceled_Landroidx_loader_content_Loader__V;

		private static nint java_class_ref => _members_androidx_loader_content_Loader_OnLoadCanceledListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_loader_content_Loader_OnLoadCanceledListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_loader_content_Loader_OnLoadCanceledListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_loader_content_Loader_OnLoadCanceledListener.ManagedPeerType;

		public IOnLoadCanceledListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnLoadCanceled_Landroidx_loader_content_Loader_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_OnLoadCanceled_Landroidx_loader_content_Loader_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnLoadCanceled_Landroidx_loader_content_Loader_(nint jnienv, nint native__this, nint native_loader)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnLoadCanceledListener? onLoadCanceledListener = Java.Lang.Object.GetObject<IOnLoadCanceledListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Loader loader = Java.Lang.Object.GetObject<Loader>(native_loader, JniHandleOwnership.DoNotTransfer);
				onLoadCanceledListener.OnLoadCanceled(loader);
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

		public unsafe void OnLoadCanceled(Loader loader)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(loader?.Handle ?? IntPtr.Zero);
				_members_androidx_loader_content_Loader_OnLoadCanceledListener.InstanceMethods.InvokeAbstractVoidMethod("onLoadCanceled.(Landroidx/loader/content/Loader;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(loader);
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

	[Register("androidx/loader/content/Loader$OnLoadCompleteListener", "", "AndroidX.Loader.Content.Loader/IOnLoadCompleteListenerInvoker")]
	[JavaTypeParameters(new string[] { "D" })]
	public interface IOnLoadCompleteListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onLoadComplete", "(Landroidx/loader/content/Loader;Ljava/lang/Object;)V", "GetOnLoadComplete_Landroidx_loader_content_Loader_Ljava_lang_Object_Handler:AndroidX.Loader.Content.Loader/IOnLoadCompleteListenerInvoker, Xamarin.AndroidX.Loader")]
		void OnLoadComplete(Loader loader, Java.Lang.Object? data);
	}

	[Register("androidx/loader/content/Loader$OnLoadCompleteListener", DoNotGenerateAcw = true)]
	internal class IOnLoadCompleteListenerInvoker : Java.Lang.Object, IOnLoadCompleteListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_loader_content_Loader_OnLoadCompleteListener = new XAPeerMembers("androidx/loader/content/Loader$OnLoadCompleteListener", typeof(IOnLoadCompleteListenerInvoker));

		private static Delegate? cb_onLoadComplete_OnLoadComplete_Landroidx_loader_content_Loader_Ljava_lang_Object__V;

		private static nint java_class_ref => _members_androidx_loader_content_Loader_OnLoadCompleteListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_loader_content_Loader_OnLoadCompleteListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_loader_content_Loader_OnLoadCompleteListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_loader_content_Loader_OnLoadCompleteListener.ManagedPeerType;

		public IOnLoadCompleteListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnLoadComplete_Landroidx_loader_content_Loader_Ljava_lang_Object_Handler()
		{
			return new global::_JniMarshal_PPLL_V(n_OnLoadComplete_Landroidx_loader_content_Loader_Ljava_lang_Object_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnLoadComplete_Landroidx_loader_content_Loader_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_loader, nint native_data)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnLoadCompleteListener? onLoadCompleteListener = Java.Lang.Object.GetObject<IOnLoadCompleteListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Loader loader = Java.Lang.Object.GetObject<Loader>(native_loader, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object data = Java.Lang.Object.GetObject<Java.Lang.Object>(native_data, JniHandleOwnership.DoNotTransfer);
				onLoadCompleteListener.OnLoadComplete(loader, data);
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

		public unsafe void OnLoadComplete(Loader loader, Java.Lang.Object? data)
		{
			nint num = JNIEnv.ToLocalJniHandle(data);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(loader?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				_members_androidx_loader_content_Loader_OnLoadCompleteListener.InstanceMethods.InvokeAbstractVoidMethod("onLoadComplete.(Landroidx/loader/content/Loader;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(loader);
				GC.KeepAlive(data);
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/loader/content/Loader", typeof(Loader));

	private static Delegate? cb_getContext_GetContext_Landroid_content_Context_;

	private static Delegate? cb_getId_GetId_I;

	private static Delegate? cb_isAbandoned_IsAbandoned_Z;

	private static Delegate? cb_isReset_IsReset_Z;

	private static Delegate? cb_isStarted_IsStarted_Z;

	private static Delegate? cb_abandon_Abandon_V;

	private static Delegate? cb_cancelLoad_CancelLoad_Z;

	private static Delegate? cb_commitContentChanged_CommitContentChanged_V;

	private static Delegate? cb_dataToString_DataToString_Ljava_lang_Object__Ljava_lang_String_;

	private static Delegate? cb_deliverCancellation_DeliverCancellation_V;

	private static Delegate? cb_deliverResult_DeliverResult_Ljava_lang_Object__V;

	private static Delegate? cb_dump_Dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String__V;

	private static Delegate? cb_forceLoad_ForceLoad_V;

	private static Delegate? cb_onAbandon_OnAbandon_V;

	private static Delegate? cb_onCancelLoad_OnCancelLoad_Z;

	private static Delegate? cb_onContentChanged_OnContentChanged_V;

	private static Delegate? cb_onForceLoad_OnForceLoad_V;

	private static Delegate? cb_onReset_OnReset_V;

	private static Delegate? cb_onStartLoading_OnStartLoading_V;

	private static Delegate? cb_onStopLoading_OnStopLoading_V;

	private static Delegate? cb_registerListener_RegisterListener_ILandroidx_loader_content_Loader_OnLoadCompleteListener__V;

	private static Delegate? cb_registerOnLoadCanceledListener_RegisterOnLoadCanceledListener_Landroidx_loader_content_Loader_OnLoadCanceledListener__V;

	private static Delegate? cb_reset_Reset_V;

	private static Delegate? cb_rollbackContentChanged_RollbackContentChanged_V;

	private static Delegate? cb_stopLoading_StopLoading_V;

	private static Delegate? cb_takeContentChanged_TakeContentChanged_Z;

	private static Delegate? cb_unregisterListener_UnregisterListener_Landroidx_loader_content_Loader_OnLoadCompleteListener__V;

	private static Delegate? cb_unregisterOnLoadCanceledListener_UnregisterOnLoadCanceledListener_Landroidx_loader_content_Loader_OnLoadCanceledListener__V;

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

	public unsafe virtual Context Context
	{
		[Register("getContext", "()Landroid/content/Context;", "GetGetContextHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeVirtualObjectMethod("getContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int Id
	{
		[Register("getId", "()I", "GetGetIdHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getId.()I", this, null);
		}
	}

	public unsafe virtual bool IsAbandoned
	{
		[Register("isAbandoned", "()Z", "GetIsAbandonedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isAbandoned.()Z", this, null);
		}
	}

	public unsafe virtual bool IsReset
	{
		[Register("isReset", "()Z", "GetIsResetHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isReset.()Z", this, null);
		}
	}

	public unsafe virtual bool IsStarted
	{
		[Register("isStarted", "()Z", "GetIsStartedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isStarted.()Z", this, null);
		}
	}

	protected Loader(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe Loader(Context context)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Context);
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
			return Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id;
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

	private static Delegate GetIsAbandonedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsAbandoned);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsAbandoned(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsAbandoned ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsResetHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsReset);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsReset(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsReset ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsStartedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsStarted);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsStarted(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsStarted ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetAbandonHandler()
	{
		return new global::_JniMarshal_PP_V(n_Abandon);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Abandon(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Abandon();
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

	[Register("abandon", "()V", "GetAbandonHandler")]
	public unsafe virtual void Abandon()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("abandon.()V", this, null);
	}

	private static Delegate GetCancelLoadHandler()
	{
		return new global::_JniMarshal_PP_B(n_CancelLoad);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_CancelLoad(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CancelLoad() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("cancelLoad", "()Z", "GetCancelLoadHandler")]
	public unsafe virtual bool CancelLoad()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("cancelLoad.()Z", this, null);
	}

	private static Delegate GetCommitContentChangedHandler()
	{
		return new global::_JniMarshal_PP_V(n_CommitContentChanged);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CommitContentChanged(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CommitContentChanged();
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

	[Register("commitContentChanged", "()V", "GetCommitContentChangedHandler")]
	public unsafe virtual void CommitContentChanged()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("commitContentChanged.()V", this, null);
	}

	private static Delegate GetDataToString_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_DataToString_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_DataToString_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_data)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Loader? loader = Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object data = Java.Lang.Object.GetObject<Java.Lang.Object>(native_data, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(loader.DataToString(data));
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

	[Register("dataToString", "(Ljava/lang/Object;)Ljava/lang/String;", "GetDataToString_Ljava_lang_Object_Handler")]
	public unsafe virtual string DataToString(Java.Lang.Object? data)
	{
		nint num = JNIEnv.ToLocalJniHandle(data);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("dataToString.(Ljava/lang/Object;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(data);
		}
	}

	private static Delegate GetDeliverCancellationHandler()
	{
		return new global::_JniMarshal_PP_V(n_DeliverCancellation);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DeliverCancellation(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DeliverCancellation();
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

	[Register("deliverCancellation", "()V", "GetDeliverCancellationHandler")]
	public unsafe virtual void DeliverCancellation()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("deliverCancellation.()V", this, null);
	}

	private static Delegate GetDeliverResult_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_DeliverResult_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DeliverResult_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_data)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Loader? loader = Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object data = Java.Lang.Object.GetObject<Java.Lang.Object>(native_data, JniHandleOwnership.DoNotTransfer);
			loader.DeliverResult(data);
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

	[Register("deliverResult", "(Ljava/lang/Object;)V", "GetDeliverResult_Ljava_lang_Object_Handler")]
	public unsafe virtual void DeliverResult(Java.Lang.Object? data)
	{
		nint num = JNIEnv.ToLocalJniHandle(data);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("deliverResult.(Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(data);
		}
	}

	[Obsolete]
	private static Delegate GetDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPLLLL_V(n_Dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_(nint jnienv, nint native__this, nint native_prefix, nint native_fd, nint native_writer, nint native_args)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Loader? loader = Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string prefix = JNIEnv.GetString(native_prefix, JniHandleOwnership.DoNotTransfer);
			FileDescriptor fd = Java.Lang.Object.GetObject<FileDescriptor>(native_fd, JniHandleOwnership.DoNotTransfer);
			PrintWriter writer = Java.Lang.Object.GetObject<PrintWriter>(native_writer, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_args, JniHandleOwnership.DoNotTransfer, typeof(string));
			loader.Dump(prefix, fd, writer, array);
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

	[Obsolete("deprecated")]
	[Register("dump", "(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V", "GetDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_Handler")]
	public unsafe virtual void Dump(string? prefix, FileDescriptor? fd, PrintWriter? writer, string[]? args)
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

	private static Delegate GetForceLoadHandler()
	{
		return new global::_JniMarshal_PP_V(n_ForceLoad);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ForceLoad(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ForceLoad();
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

	[Register("forceLoad", "()V", "GetForceLoadHandler")]
	public unsafe virtual void ForceLoad()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("forceLoad.()V", this, null);
	}

	private static Delegate GetOnAbandonHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnAbandon);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnAbandon(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnAbandon();
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

	[Register("onAbandon", "()V", "GetOnAbandonHandler")]
	protected unsafe virtual void OnAbandon()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onAbandon.()V", this, null);
	}

	private static Delegate GetOnCancelLoadHandler()
	{
		return new global::_JniMarshal_PP_B(n_OnCancelLoad);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnCancelLoad(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCancelLoad() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onCancelLoad", "()Z", "GetOnCancelLoadHandler")]
	protected unsafe virtual bool OnCancelLoad()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("onCancelLoad.()Z", this, null);
	}

	private static Delegate GetOnContentChangedHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnContentChanged);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnContentChanged(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnContentChanged();
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

	[Register("onContentChanged", "()V", "GetOnContentChangedHandler")]
	public unsafe virtual void OnContentChanged()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onContentChanged.()V", this, null);
	}

	private static Delegate GetOnForceLoadHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnForceLoad);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnForceLoad(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnForceLoad();
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

	[Register("onForceLoad", "()V", "GetOnForceLoadHandler")]
	protected unsafe virtual void OnForceLoad()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onForceLoad.()V", this, null);
	}

	private static Delegate GetOnResetHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnReset);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnReset(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnReset();
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

	[Register("onReset", "()V", "GetOnResetHandler")]
	protected unsafe virtual void OnReset()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onReset.()V", this, null);
	}

	private static Delegate GetOnStartLoadingHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnStartLoading);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnStartLoading(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStartLoading();
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

	[Register("onStartLoading", "()V", "GetOnStartLoadingHandler")]
	protected unsafe virtual void OnStartLoading()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onStartLoading.()V", this, null);
	}

	private static Delegate GetOnStopLoadingHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnStopLoading);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnStopLoading(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStopLoading();
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

	[Register("onStopLoading", "()V", "GetOnStopLoadingHandler")]
	protected unsafe virtual void OnStopLoading()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onStopLoading.()V", this, null);
	}

	private static Delegate GetRegisterListener_ILandroidx_loader_content_Loader_OnLoadCompleteListener_Handler()
	{
		return new global::_JniMarshal_PPIL_V(n_RegisterListener_ILandroidx_loader_content_Loader_OnLoadCompleteListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RegisterListener_ILandroidx_loader_content_Loader_OnLoadCompleteListener_(nint jnienv, nint native__this, int id, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Loader? loader = Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnLoadCompleteListener listener = Java.Lang.Object.GetObject<IOnLoadCompleteListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			loader.RegisterListener(id, listener);
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

	[Register("registerListener", "(ILandroidx/loader/content/Loader$OnLoadCompleteListener;)V", "GetRegisterListener_ILandroidx_loader_content_Loader_OnLoadCompleteListener_Handler")]
	public unsafe virtual void RegisterListener(int id, IOnLoadCompleteListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(id);
			ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("registerListener.(ILandroidx/loader/content/Loader$OnLoadCompleteListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetRegisterOnLoadCanceledListener_Landroidx_loader_content_Loader_OnLoadCanceledListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RegisterOnLoadCanceledListener_Landroidx_loader_content_Loader_OnLoadCanceledListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RegisterOnLoadCanceledListener_Landroidx_loader_content_Loader_OnLoadCanceledListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Loader? loader = Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnLoadCanceledListener listener = Java.Lang.Object.GetObject<IOnLoadCanceledListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			loader.RegisterOnLoadCanceledListener(listener);
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

	[Register("registerOnLoadCanceledListener", "(Landroidx/loader/content/Loader$OnLoadCanceledListener;)V", "GetRegisterOnLoadCanceledListener_Landroidx_loader_content_Loader_OnLoadCanceledListener_Handler")]
	public unsafe virtual void RegisterOnLoadCanceledListener(IOnLoadCanceledListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("registerOnLoadCanceledListener.(Landroidx/loader/content/Loader$OnLoadCanceledListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetResetHandler()
	{
		return new global::_JniMarshal_PP_V(n_Reset);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Reset(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reset();
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

	[Register("reset", "()V", "GetResetHandler")]
	public unsafe virtual void Reset()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("reset.()V", this, null);
	}

	private static Delegate GetRollbackContentChangedHandler()
	{
		return new global::_JniMarshal_PP_V(n_RollbackContentChanged);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RollbackContentChanged(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RollbackContentChanged();
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

	[Register("rollbackContentChanged", "()V", "GetRollbackContentChangedHandler")]
	public unsafe virtual void RollbackContentChanged()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("rollbackContentChanged.()V", this, null);
	}

	[Register("startLoading", "()V", "")]
	public unsafe void StartLoading()
	{
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("startLoading.()V", this, null);
	}

	private static Delegate GetStopLoadingHandler()
	{
		return new global::_JniMarshal_PP_V(n_StopLoading);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_StopLoading(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StopLoading();
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

	[Register("stopLoading", "()V", "GetStopLoadingHandler")]
	public unsafe virtual void StopLoading()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("stopLoading.()V", this, null);
	}

	private static Delegate GetTakeContentChangedHandler()
	{
		return new global::_JniMarshal_PP_B(n_TakeContentChanged);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_TakeContentChanged(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TakeContentChanged() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("takeContentChanged", "()Z", "GetTakeContentChangedHandler")]
	public unsafe virtual bool TakeContentChanged()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("takeContentChanged.()Z", this, null);
	}

	private static Delegate GetUnregisterListener_Landroidx_loader_content_Loader_OnLoadCompleteListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_UnregisterListener_Landroidx_loader_content_Loader_OnLoadCompleteListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UnregisterListener_Landroidx_loader_content_Loader_OnLoadCompleteListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Loader? loader = Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnLoadCompleteListener listener = Java.Lang.Object.GetObject<IOnLoadCompleteListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			loader.UnregisterListener(listener);
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

	[Register("unregisterListener", "(Landroidx/loader/content/Loader$OnLoadCompleteListener;)V", "GetUnregisterListener_Landroidx_loader_content_Loader_OnLoadCompleteListener_Handler")]
	public unsafe virtual void UnregisterListener(IOnLoadCompleteListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("unregisterListener.(Landroidx/loader/content/Loader$OnLoadCompleteListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetUnregisterOnLoadCanceledListener_Landroidx_loader_content_Loader_OnLoadCanceledListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_UnregisterOnLoadCanceledListener_Landroidx_loader_content_Loader_OnLoadCanceledListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UnregisterOnLoadCanceledListener_Landroidx_loader_content_Loader_OnLoadCanceledListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Loader? loader = Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnLoadCanceledListener listener = Java.Lang.Object.GetObject<IOnLoadCanceledListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			loader.UnregisterOnLoadCanceledListener(listener);
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

	[Register("unregisterOnLoadCanceledListener", "(Landroidx/loader/content/Loader$OnLoadCanceledListener;)V", "GetUnregisterOnLoadCanceledListener_Landroidx_loader_content_Loader_OnLoadCanceledListener_Handler")]
	public unsafe virtual void UnregisterOnLoadCanceledListener(IOnLoadCanceledListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("unregisterOnLoadCanceledListener.(Landroidx/loader/content/Loader$OnLoadCanceledListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}
}
