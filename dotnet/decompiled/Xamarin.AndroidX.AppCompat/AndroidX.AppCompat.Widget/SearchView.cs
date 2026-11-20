using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.CursorAdapter.Widget;
using Java.Interop;
using Java.Lang;

namespace AndroidX.AppCompat.Widget;

[Register("androidx/appcompat/widget/SearchView", DoNotGenerateAcw = true)]
public class SearchView : LinearLayoutCompat, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("androidx/appcompat/widget/SearchView$OnCloseListener", "", "AndroidX.AppCompat.Widget.SearchView/IOnCloseListenerInvoker")]
	public interface IOnCloseListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onClose", "()Z", "GetOnCloseHandler:AndroidX.AppCompat.Widget.SearchView/IOnCloseListenerInvoker, Xamarin.AndroidX.AppCompat")]
		bool OnClose();
	}

	[Register("androidx/appcompat/widget/SearchView$OnCloseListener", DoNotGenerateAcw = true)]
	internal class IOnCloseListenerInvoker : Java.Lang.Object, IOnCloseListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_appcompat_widget_SearchView_OnCloseListener = new XAPeerMembers("androidx/appcompat/widget/SearchView$OnCloseListener", typeof(IOnCloseListenerInvoker));

		private static Delegate? cb_onClose_OnClose_Z;

		private static nint java_class_ref => _members_androidx_appcompat_widget_SearchView_OnCloseListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_appcompat_widget_SearchView_OnCloseListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_appcompat_widget_SearchView_OnCloseListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_appcompat_widget_SearchView_OnCloseListener.ManagedPeerType;

		public IOnCloseListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnClose(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<IOnCloseListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnClose() ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool OnClose()
		{
			return _members_androidx_appcompat_widget_SearchView_OnCloseListener.InstanceMethods.InvokeAbstractBooleanMethod("onClose.()Z", this, null);
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
		private static sbyte n_OnClose_mm_wrapper(nint jnienv, nint native__this)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnClose(jnienv, native__this);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}
	}

	public class CloseEventArgs : EventArgs
	{
		private bool handled;

		public bool Handled => handled;

		public CloseEventArgs(bool handled)
		{
			this.handled = handled;
		}
	}

	[Register("mono/androidx/appcompat/widget/SearchView_OnCloseListenerImplementor")]
	internal sealed class IOnCloseListenerImplementor : Java.Lang.Object, IOnCloseListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<CloseEventArgs>? Handler;

		public unsafe IOnCloseListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public bool OnClose()
		{
			EventHandler<CloseEventArgs> handler = Handler;
			if (handler == null)
			{
				return false;
			}
			CloseEventArgs e = new CloseEventArgs(handled: true);
			handler(sender, e);
			return e.Handled;
		}

		internal static bool __IsEmpty(IOnCloseListenerImplementor value)
		{
			return value.Handler == null;
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

	[Register("androidx/appcompat/widget/SearchView$OnQueryTextListener", "", "AndroidX.AppCompat.Widget.SearchView/IOnQueryTextListenerInvoker")]
	public interface IOnQueryTextListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onQueryTextChange", "(Ljava/lang/String;)Z", "GetOnQueryTextChange_Ljava_lang_String_Handler:AndroidX.AppCompat.Widget.SearchView/IOnQueryTextListenerInvoker, Xamarin.AndroidX.AppCompat")]
		bool OnQueryTextChange(string? newText);

		[Register("onQueryTextSubmit", "(Ljava/lang/String;)Z", "GetOnQueryTextSubmit_Ljava_lang_String_Handler:AndroidX.AppCompat.Widget.SearchView/IOnQueryTextListenerInvoker, Xamarin.AndroidX.AppCompat")]
		bool OnQueryTextSubmit(string? newText);
	}

	[Register("androidx/appcompat/widget/SearchView$OnQueryTextListener", DoNotGenerateAcw = true)]
	internal class IOnQueryTextListenerInvoker : Java.Lang.Object, IOnQueryTextListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_appcompat_widget_SearchView_OnQueryTextListener = new XAPeerMembers("androidx/appcompat/widget/SearchView$OnQueryTextListener", typeof(IOnQueryTextListenerInvoker));

		private static Delegate? cb_onQueryTextChange_OnQueryTextChange_Ljava_lang_String__Z;

		private static Delegate? cb_onQueryTextSubmit_OnQueryTextSubmit_Ljava_lang_String__Z;

		private static nint java_class_ref => _members_androidx_appcompat_widget_SearchView_OnQueryTextListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_appcompat_widget_SearchView_OnQueryTextListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_appcompat_widget_SearchView_OnQueryTextListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_appcompat_widget_SearchView_OnQueryTextListener.ManagedPeerType;

		public IOnQueryTextListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnQueryTextChange_Ljava_lang_String_(nint jnienv, nint native__this, nint native_newText)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IOnQueryTextListener? onQueryTextListener = Java.Lang.Object.GetObject<IOnQueryTextListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string newText = JNIEnv.GetString(native_newText, JniHandleOwnership.DoNotTransfer);
				return onQueryTextListener.OnQueryTextChange(newText) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool OnQueryTextChange(string? newText)
		{
			nint num = JNIEnv.NewString(newText);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return _members_androidx_appcompat_widget_SearchView_OnQueryTextListener.InstanceMethods.InvokeAbstractBooleanMethod("onQueryTextChange.(Ljava/lang/String;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnQueryTextSubmit_Ljava_lang_String_(nint jnienv, nint native__this, nint native_newText)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IOnQueryTextListener? onQueryTextListener = Java.Lang.Object.GetObject<IOnQueryTextListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string newText = JNIEnv.GetString(native_newText, JniHandleOwnership.DoNotTransfer);
				return onQueryTextListener.OnQueryTextSubmit(newText) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool OnQueryTextSubmit(string? newText)
		{
			nint num = JNIEnv.NewString(newText);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return _members_androidx_appcompat_widget_SearchView_OnQueryTextListener.InstanceMethods.InvokeAbstractBooleanMethod("onQueryTextSubmit.(Ljava/lang/String;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
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
		private static sbyte n_OnQueryTextChange_Ljava_lang_String__mm_wrapper(nint jnienv, nint native__this, nint native_newText)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnQueryTextChange_Ljava_lang_String_(jnienv, native__this, native_newText);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static sbyte n_OnQueryTextSubmit_Ljava_lang_String__mm_wrapper(nint jnienv, nint native__this, nint native_newText)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnQueryTextSubmit_Ljava_lang_String_(jnienv, native__this, native_newText);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}
	}

	public class QueryTextChangeEventArgs : EventArgs
	{
		private bool handled;

		private string? newText;

		public bool Handled => handled;

		public string? NewText => newText;

		public QueryTextChangeEventArgs(bool handled, string? newText)
		{
			this.handled = handled;
			this.newText = newText;
		}
	}

	public class QueryTextSubmitEventArgs : EventArgs
	{
		private bool handled;

		private string? newText;

		public bool Handled
		{
			get
			{
				return handled;
			}
			set
			{
				handled = value;
			}
		}

		public QueryTextSubmitEventArgs(bool handled, string? newText)
		{
			this.handled = handled;
			this.newText = newText;
		}
	}

	[Register("mono/androidx/appcompat/widget/SearchView_OnQueryTextListenerImplementor")]
	internal sealed class IOnQueryTextListenerImplementor : Java.Lang.Object, IOnQueryTextListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<QueryTextChangeEventArgs>? OnQueryTextChangeHandler;

		public EventHandler<QueryTextSubmitEventArgs>? OnQueryTextSubmitHandler;

		public unsafe IOnQueryTextListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public bool OnQueryTextChange(string? newText)
		{
			EventHandler<QueryTextChangeEventArgs> onQueryTextChangeHandler = OnQueryTextChangeHandler;
			if (onQueryTextChangeHandler == null)
			{
				return false;
			}
			QueryTextChangeEventArgs e = new QueryTextChangeEventArgs(handled: true, newText);
			onQueryTextChangeHandler(sender, e);
			return e.Handled;
		}

		public bool OnQueryTextSubmit(string? newText)
		{
			EventHandler<QueryTextSubmitEventArgs> onQueryTextSubmitHandler = OnQueryTextSubmitHandler;
			if (onQueryTextSubmitHandler == null)
			{
				return false;
			}
			QueryTextSubmitEventArgs e = new QueryTextSubmitEventArgs(handled: true, newText);
			onQueryTextSubmitHandler(sender, e);
			return e.Handled;
		}

		internal static bool __IsEmpty(IOnQueryTextListenerImplementor value)
		{
			if (value.OnQueryTextChangeHandler == null)
			{
				return value.OnQueryTextSubmitHandler == null;
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

	[Register("androidx/appcompat/widget/SearchView$OnSuggestionListener", "", "AndroidX.AppCompat.Widget.SearchView/IOnSuggestionListenerInvoker")]
	public interface IOnSuggestionListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onSuggestionClick", "(I)Z", "GetOnSuggestionClick_IHandler:AndroidX.AppCompat.Widget.SearchView/IOnSuggestionListenerInvoker, Xamarin.AndroidX.AppCompat")]
		bool OnSuggestionClick(int position);

		[Register("onSuggestionSelect", "(I)Z", "GetOnSuggestionSelect_IHandler:AndroidX.AppCompat.Widget.SearchView/IOnSuggestionListenerInvoker, Xamarin.AndroidX.AppCompat")]
		bool OnSuggestionSelect(int position);
	}

	[Register("androidx/appcompat/widget/SearchView$OnSuggestionListener", DoNotGenerateAcw = true)]
	internal class IOnSuggestionListenerInvoker : Java.Lang.Object, IOnSuggestionListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_appcompat_widget_SearchView_OnSuggestionListener = new XAPeerMembers("androidx/appcompat/widget/SearchView$OnSuggestionListener", typeof(IOnSuggestionListenerInvoker));

		private static Delegate? cb_onSuggestionClick_OnSuggestionClick_I_Z;

		private static Delegate? cb_onSuggestionSelect_OnSuggestionSelect_I_Z;

		private static nint java_class_ref => _members_androidx_appcompat_widget_SearchView_OnSuggestionListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_appcompat_widget_SearchView_OnSuggestionListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_appcompat_widget_SearchView_OnSuggestionListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_appcompat_widget_SearchView_OnSuggestionListener.ManagedPeerType;

		public IOnSuggestionListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnSuggestionClick_I(nint jnienv, nint native__this, int position)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<IOnSuggestionListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnSuggestionClick(position) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool OnSuggestionClick(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			return _members_androidx_appcompat_widget_SearchView_OnSuggestionListener.InstanceMethods.InvokeAbstractBooleanMethod("onSuggestionClick.(I)Z", this, ptr);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnSuggestionSelect_I(nint jnienv, nint native__this, int position)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<IOnSuggestionListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnSuggestionSelect(position) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool OnSuggestionSelect(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			return _members_androidx_appcompat_widget_SearchView_OnSuggestionListener.InstanceMethods.InvokeAbstractBooleanMethod("onSuggestionSelect.(I)Z", this, ptr);
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
		private static sbyte n_OnSuggestionClick_I_mm_wrapper(nint jnienv, nint native__this, int position)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnSuggestionClick_I(jnienv, native__this, position);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static sbyte n_OnSuggestionSelect_I_mm_wrapper(nint jnienv, nint native__this, int position)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnSuggestionSelect_I(jnienv, native__this, position);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}
	}

	public class SuggestionClickEventArgs : EventArgs
	{
		private bool handled;

		private int position;

		public bool Handled => handled;

		public SuggestionClickEventArgs(bool handled, int position)
		{
			this.handled = handled;
			this.position = position;
		}
	}

	public class SuggestionSelectEventArgs : EventArgs
	{
		private bool handled;

		private int position;

		public bool Handled => handled;

		public SuggestionSelectEventArgs(bool handled, int position)
		{
			this.handled = handled;
			this.position = position;
		}
	}

	[Register("mono/androidx/appcompat/widget/SearchView_OnSuggestionListenerImplementor")]
	internal sealed class IOnSuggestionListenerImplementor : Java.Lang.Object, IOnSuggestionListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<SuggestionClickEventArgs>? OnSuggestionClickHandler;

		public EventHandler<SuggestionSelectEventArgs>? OnSuggestionSelectHandler;

		public unsafe IOnSuggestionListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public bool OnSuggestionClick(int position)
		{
			EventHandler<SuggestionClickEventArgs> onSuggestionClickHandler = OnSuggestionClickHandler;
			if (onSuggestionClickHandler == null)
			{
				return false;
			}
			SuggestionClickEventArgs e = new SuggestionClickEventArgs(handled: true, position);
			onSuggestionClickHandler(sender, e);
			return e.Handled;
		}

		public bool OnSuggestionSelect(int position)
		{
			EventHandler<SuggestionSelectEventArgs> onSuggestionSelectHandler = OnSuggestionSelectHandler;
			if (onSuggestionSelectHandler == null)
			{
				return false;
			}
			SuggestionSelectEventArgs e = new SuggestionSelectEventArgs(handled: true, position);
			onSuggestionSelectHandler(sender, e);
			return e.Handled;
		}

		internal static bool __IsEmpty(IOnSuggestionListenerImplementor value)
		{
			if (value.OnSuggestionClickHandler == null)
			{
				return value.OnSuggestionSelectHandler == null;
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/appcompat/widget/SearchView", typeof(SearchView));

	private static Delegate? cb_isIconified_IsIconified_Z;

	private static Delegate? cb_setIconified_SetIconified_Z_V;

	private static Delegate? cb_getImeOptions_GetImeOptions_I;

	private static Delegate? cb_setImeOptions_SetImeOptions_I_V;

	private static Delegate? cb_getInputType_GetInputType_I;

	private static Delegate? cb_setInputType_SetInputType_I_V;

	private static Delegate? cb_isIconfiedByDefault_IsIconfiedByDefault_Z;

	private static Delegate? cb_getMaxWidth_GetMaxWidth_I;

	private static Delegate? cb_setMaxWidth_SetMaxWidth_I_V;

	private static Delegate? cb_getQuery_GetQuery_Ljava_lang_CharSequence_;

	private static Delegate? cb_getQueryHint_GetQueryHint_Ljava_lang_CharSequence_;

	private static Delegate? cb_setQueryHint_SetQueryHint_Ljava_lang_CharSequence__V;

	private static Delegate? cb_isQueryRefinementEnabled_IsQueryRefinementEnabled_Z;

	private static Delegate? cb_setQueryRefinementEnabled_SetQueryRefinementEnabled_Z_V;

	private static Delegate? cb_isSubmitButtonEnabled_IsSubmitButtonEnabled_Z;

	private static Delegate? cb_setSubmitButtonEnabled_SetSubmitButtonEnabled_Z_V;

	private static Delegate? cb_getSuggestionsAdapter_GetSuggestionsAdapter_Landroidx_cursoradapter_widget_CursorAdapter_;

	private static Delegate? cb_setSuggestionsAdapter_SetSuggestionsAdapter_Landroidx_cursoradapter_widget_CursorAdapter__V;

	private static Delegate? cb_onActionViewCollapsed_OnActionViewCollapsed_V;

	private static Delegate? cb_onActionViewExpanded_OnActionViewExpanded_V;

	private static Delegate? cb_onQueryRefine_OnQueryRefine_Ljava_lang_CharSequence__V;

	private static Delegate? cb_setAppSearchData_SetAppSearchData_Landroid_os_Bundle__V;

	private static Delegate? cb_setIconifiedByDefault_SetIconifiedByDefault_Z_V;

	private static Delegate? cb_setOnCloseListener_SetOnCloseListener_Landroidx_appcompat_widget_SearchView_OnCloseListener__V;

	private static Delegate? cb_setOnQueryTextFocusChangeListener_SetOnQueryTextFocusChangeListener_Landroid_view_View_OnFocusChangeListener__V;

	private static Delegate? cb_setOnQueryTextListener_SetOnQueryTextListener_Landroidx_appcompat_widget_SearchView_OnQueryTextListener__V;

	private static Delegate? cb_setOnSearchClickListener_SetOnSearchClickListener_Landroid_view_View_OnClickListener__V;

	private static Delegate? cb_setOnSuggestionListener_SetOnSuggestionListener_Landroidx_appcompat_widget_SearchView_OnSuggestionListener__V;

	private static Delegate? cb_setQuery_SetQuery_Ljava_lang_CharSequence_Z_V;

	private static Delegate? cb_setSearchableInfo_SetSearchableInfo_Landroid_app_SearchableInfo__V;

	private WeakReference? weak_implementor_SetOnCloseListener;

	private WeakReference? weak_implementor_SetOnQueryTextListener;

	private WeakReference? weak_implementor_SetOnSuggestionListener;

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

	public unsafe virtual bool Iconified
	{
		[Register("isIconified", "()Z", "GetIsIconifiedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isIconified.()Z", this, null);
		}
		[Register("setIconified", "(Z)V", "GetSetIconified_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setIconified.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int ImeOptions
	{
		[Register("getImeOptions", "()I", "GetGetImeOptionsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getImeOptions.()I", this, null);
		}
		[Register("setImeOptions", "(I)V", "GetSetImeOptions_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setImeOptions.(I)V", this, ptr);
		}
	}

	public unsafe virtual int InputType
	{
		[Register("getInputType", "()I", "GetGetInputTypeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getInputType.()I", this, null);
		}
		[Register("setInputType", "(I)V", "GetSetInputType_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setInputType.(I)V", this, ptr);
		}
	}

	public unsafe virtual bool IsIconfiedByDefault
	{
		[Register("isIconfiedByDefault", "()Z", "GetIsIconfiedByDefaultHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isIconfiedByDefault.()Z", this, null);
		}
	}

	public unsafe virtual int MaxWidth
	{
		[Register("getMaxWidth", "()I", "GetGetMaxWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMaxWidth.()I", this, null);
		}
		[Register("setMaxWidth", "(I)V", "GetSetMaxWidth_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMaxWidth.(I)V", this, ptr);
		}
	}

	public unsafe virtual ICharSequence? QueryFormatted
	{
		[Register("getQuery", "()Ljava/lang/CharSequence;", "GetGetQueryHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getQuery.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public string? Query
	{
		get
		{
			if (QueryFormatted != null)
			{
				return QueryFormatted.ToString();
			}
			return null;
		}
	}

	public unsafe virtual ICharSequence? QueryHintFormatted
	{
		[Register("getQueryHint", "()Ljava/lang/CharSequence;", "GetGetQueryHintHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getQueryHint.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setQueryHint", "(Ljava/lang/CharSequence;)V", "GetSetQueryHint_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setQueryHint.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? QueryHint
	{
		get
		{
			if (QueryHintFormatted != null)
			{
				return QueryHintFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(QueryHintFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual bool QueryRefinementEnabled
	{
		[Register("isQueryRefinementEnabled", "()Z", "GetIsQueryRefinementEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isQueryRefinementEnabled.()Z", this, null);
		}
		[Register("setQueryRefinementEnabled", "(Z)V", "GetSetQueryRefinementEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setQueryRefinementEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool SubmitButtonEnabled
	{
		[Register("isSubmitButtonEnabled", "()Z", "GetIsSubmitButtonEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSubmitButtonEnabled.()Z", this, null);
		}
		[Register("setSubmitButtonEnabled", "(Z)V", "GetSetSubmitButtonEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSubmitButtonEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe virtual AndroidX.CursorAdapter.Widget.CursorAdapter? SuggestionsAdapter
	{
		[Register("getSuggestionsAdapter", "()Landroidx/cursoradapter/widget/CursorAdapter;", "GetGetSuggestionsAdapterHandler")]
		get
		{
			return Java.Lang.Object.GetObject<AndroidX.CursorAdapter.Widget.CursorAdapter>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSuggestionsAdapter.()Landroidx/cursoradapter/widget/CursorAdapter;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setSuggestionsAdapter", "(Landroidx/cursoradapter/widget/CursorAdapter;)V", "GetSetSuggestionsAdapter_Landroidx_cursoradapter_widget_CursorAdapter_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSuggestionsAdapter.(Landroidx/cursoradapter/widget/CursorAdapter;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public event EventHandler<CloseEventArgs> Close
	{
		add
		{
			EventHelper.AddEventHandler<IOnCloseListener, IOnCloseListenerImplementor>(ref weak_implementor_SetOnCloseListener, __CreateIOnCloseListenerImplementor, SetOnCloseListener, delegate(IOnCloseListenerImplementor __h)
			{
				__h.Handler = (EventHandler<CloseEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnCloseListener, IOnCloseListenerImplementor>(ref weak_implementor_SetOnCloseListener, IOnCloseListenerImplementor.__IsEmpty, delegate
			{
				SetOnCloseListener(null);
			}, delegate(IOnCloseListenerImplementor __h)
			{
				__h.Handler = (EventHandler<CloseEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	public event EventHandler<QueryTextChangeEventArgs> QueryTextChange
	{
		add
		{
			EventHelper.AddEventHandler<IOnQueryTextListener, IOnQueryTextListenerImplementor>(ref weak_implementor_SetOnQueryTextListener, __CreateIOnQueryTextListenerImplementor, SetOnQueryTextListener, delegate(IOnQueryTextListenerImplementor __h)
			{
				__h.OnQueryTextChangeHandler = (EventHandler<QueryTextChangeEventArgs>)Delegate.Combine(__h.OnQueryTextChangeHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnQueryTextListener, IOnQueryTextListenerImplementor>(ref weak_implementor_SetOnQueryTextListener, IOnQueryTextListenerImplementor.__IsEmpty, delegate
			{
				SetOnQueryTextListener(null);
			}, delegate(IOnQueryTextListenerImplementor __h)
			{
				__h.OnQueryTextChangeHandler = (EventHandler<QueryTextChangeEventArgs>)Delegate.Remove(__h.OnQueryTextChangeHandler, value);
			});
		}
	}

	public event EventHandler<QueryTextSubmitEventArgs> QueryTextSubmit
	{
		add
		{
			EventHelper.AddEventHandler<IOnQueryTextListener, IOnQueryTextListenerImplementor>(ref weak_implementor_SetOnQueryTextListener, __CreateIOnQueryTextListenerImplementor, SetOnQueryTextListener, delegate(IOnQueryTextListenerImplementor __h)
			{
				__h.OnQueryTextSubmitHandler = (EventHandler<QueryTextSubmitEventArgs>)Delegate.Combine(__h.OnQueryTextSubmitHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnQueryTextListener, IOnQueryTextListenerImplementor>(ref weak_implementor_SetOnQueryTextListener, IOnQueryTextListenerImplementor.__IsEmpty, delegate
			{
				SetOnQueryTextListener(null);
			}, delegate(IOnQueryTextListenerImplementor __h)
			{
				__h.OnQueryTextSubmitHandler = (EventHandler<QueryTextSubmitEventArgs>)Delegate.Remove(__h.OnQueryTextSubmitHandler, value);
			});
		}
	}

	public event EventHandler<SuggestionClickEventArgs> SuggestionClick
	{
		add
		{
			EventHelper.AddEventHandler<IOnSuggestionListener, IOnSuggestionListenerImplementor>(ref weak_implementor_SetOnSuggestionListener, __CreateIOnSuggestionListenerImplementor, SetOnSuggestionListener, delegate(IOnSuggestionListenerImplementor __h)
			{
				__h.OnSuggestionClickHandler = (EventHandler<SuggestionClickEventArgs>)Delegate.Combine(__h.OnSuggestionClickHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnSuggestionListener, IOnSuggestionListenerImplementor>(ref weak_implementor_SetOnSuggestionListener, IOnSuggestionListenerImplementor.__IsEmpty, delegate
			{
				SetOnSuggestionListener(null);
			}, delegate(IOnSuggestionListenerImplementor __h)
			{
				__h.OnSuggestionClickHandler = (EventHandler<SuggestionClickEventArgs>)Delegate.Remove(__h.OnSuggestionClickHandler, value);
			});
		}
	}

	public event EventHandler<SuggestionSelectEventArgs> SuggestionSelect
	{
		add
		{
			EventHelper.AddEventHandler<IOnSuggestionListener, IOnSuggestionListenerImplementor>(ref weak_implementor_SetOnSuggestionListener, __CreateIOnSuggestionListenerImplementor, SetOnSuggestionListener, delegate(IOnSuggestionListenerImplementor __h)
			{
				__h.OnSuggestionSelectHandler = (EventHandler<SuggestionSelectEventArgs>)Delegate.Combine(__h.OnSuggestionSelectHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnSuggestionListener, IOnSuggestionListenerImplementor>(ref weak_implementor_SetOnSuggestionListener, IOnSuggestionListenerImplementor.__IsEmpty, delegate
			{
				SetOnSuggestionListener(null);
			}, delegate(IOnSuggestionListenerImplementor __h)
			{
				__h.OnSuggestionSelectHandler = (EventHandler<SuggestionSelectEventArgs>)Delegate.Remove(__h.OnSuggestionSelectHandler, value);
			});
		}
	}

	protected SearchView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe SearchView(Context context)
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

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
	public unsafe SearchView(Context context, IAttributeSet? attrs)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
	public unsafe SearchView(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyleAttr);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	private static Delegate GetIsIconifiedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsIconified);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsIconified(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Iconified ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetIconified_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetIconified_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetIconified_Z(nint jnienv, nint native__this, sbyte native_iconify)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SearchView? searchView = Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool iconified = native_iconify != 0;
			searchView.Iconified = iconified;
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

	private static Delegate GetGetImeOptionsHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetImeOptions);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetImeOptions(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImeOptions;
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

	private static Delegate GetSetImeOptions_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetImeOptions_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetImeOptions_I(nint jnienv, nint native__this, int imeOptions)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImeOptions = imeOptions;
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

	private static Delegate GetGetInputTypeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetInputType);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetInputType(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InputType;
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

	private static Delegate GetSetInputType_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetInputType_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetInputType_I(nint jnienv, nint native__this, int inputType)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InputType = inputType;
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

	private static Delegate GetIsIconfiedByDefaultHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsIconfiedByDefault);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsIconfiedByDefault(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsIconfiedByDefault ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetMaxWidthHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetMaxWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMaxWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxWidth;
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

	private static Delegate GetSetMaxWidth_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetMaxWidth_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMaxWidth_I(nint jnienv, nint native__this, int maxpixels)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxWidth = maxpixels;
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

	private static Delegate GetGetQueryHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetQuery);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetQuery(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).QueryFormatted);
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

	private static Delegate GetGetQueryHintHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetQueryHint);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetQueryHint(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).QueryHintFormatted);
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

	private static Delegate GetSetQueryHint_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetQueryHint_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetQueryHint_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_hint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SearchView? searchView = Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence queryHintFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_hint, JniHandleOwnership.DoNotTransfer);
			searchView.QueryHintFormatted = queryHintFormatted;
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

	private static Delegate GetIsQueryRefinementEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsQueryRefinementEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsQueryRefinementEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).QueryRefinementEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetQueryRefinementEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetQueryRefinementEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetQueryRefinementEnabled_Z(nint jnienv, nint native__this, sbyte native_enable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SearchView? searchView = Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool queryRefinementEnabled = native_enable != 0;
			searchView.QueryRefinementEnabled = queryRefinementEnabled;
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

	private static Delegate GetIsSubmitButtonEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsSubmitButtonEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsSubmitButtonEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SubmitButtonEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetSubmitButtonEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetSubmitButtonEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSubmitButtonEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SearchView? searchView = Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool submitButtonEnabled = native_enabled != 0;
			searchView.SubmitButtonEnabled = submitButtonEnabled;
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

	private static Delegate GetGetSuggestionsAdapterHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSuggestionsAdapter);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSuggestionsAdapter(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SuggestionsAdapter);
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

	private static Delegate GetSetSuggestionsAdapter_Landroidx_cursoradapter_widget_CursorAdapter_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetSuggestionsAdapter_Landroidx_cursoradapter_widget_CursorAdapter_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSuggestionsAdapter_Landroidx_cursoradapter_widget_CursorAdapter_(nint jnienv, nint native__this, nint native_adapter)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SearchView? searchView = Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AndroidX.CursorAdapter.Widget.CursorAdapter suggestionsAdapter = Java.Lang.Object.GetObject<AndroidX.CursorAdapter.Widget.CursorAdapter>(native_adapter, JniHandleOwnership.DoNotTransfer);
			searchView.SuggestionsAdapter = suggestionsAdapter;
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

	private static Delegate GetOnActionViewCollapsedHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnActionViewCollapsed);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnActionViewCollapsed(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnActionViewCollapsed();
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

	[Register("onActionViewCollapsed", "()V", "GetOnActionViewCollapsedHandler")]
	public unsafe virtual void OnActionViewCollapsed()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onActionViewCollapsed.()V", this, null);
	}

	private static Delegate GetOnActionViewExpandedHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnActionViewExpanded);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnActionViewExpanded(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnActionViewExpanded();
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

	[Register("onActionViewExpanded", "()V", "GetOnActionViewExpandedHandler")]
	public unsafe virtual void OnActionViewExpanded()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onActionViewExpanded.()V", this, null);
	}

	private static Delegate GetOnQueryRefine_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnQueryRefine_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnQueryRefine_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_queryText)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SearchView? searchView = Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence queryText = Java.Lang.Object.GetObject<ICharSequence>(native_queryText, JniHandleOwnership.DoNotTransfer);
			searchView.OnQueryRefine(queryText);
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

	[Register("onQueryRefine", "(Ljava/lang/CharSequence;)V", "GetOnQueryRefine_Ljava_lang_CharSequence_Handler")]
	protected unsafe virtual void OnQueryRefine(ICharSequence? queryText)
	{
		nint num = CharSequence.ToLocalJniHandle(queryText);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onQueryRefine.(Ljava/lang/CharSequence;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(queryText);
		}
	}

	protected void OnQueryRefine(string? queryText)
	{
		Java.Lang.String obj = ((queryText == null) ? null : new Java.Lang.String(queryText));
		OnQueryRefine(obj);
		obj?.Dispose();
	}

	private static Delegate GetSetAppSearchData_Landroid_os_Bundle_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetAppSearchData_Landroid_os_Bundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAppSearchData_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_appSearchData)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SearchView? searchView = Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle appSearchData = Java.Lang.Object.GetObject<Bundle>(native_appSearchData, JniHandleOwnership.DoNotTransfer);
			searchView.SetAppSearchData(appSearchData);
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

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("setAppSearchData", "(Landroid/os/Bundle;)V", "GetSetAppSearchData_Landroid_os_Bundle_Handler")]
	public unsafe virtual void SetAppSearchData(Bundle? appSearchData)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(appSearchData?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAppSearchData.(Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(appSearchData);
		}
	}

	private static Delegate GetSetIconifiedByDefault_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetIconifiedByDefault_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetIconifiedByDefault_Z(nint jnienv, nint native__this, sbyte native_iconified)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SearchView? searchView = Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool iconifiedByDefault = native_iconified != 0;
			searchView.SetIconifiedByDefault(iconifiedByDefault);
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

	[Register("setIconifiedByDefault", "(Z)V", "GetSetIconifiedByDefault_ZHandler")]
	public unsafe virtual void SetIconifiedByDefault(bool iconified)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(iconified ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setIconifiedByDefault.(Z)V", this, ptr);
	}

	private static Delegate GetSetOnCloseListener_Landroidx_appcompat_widget_SearchView_OnCloseListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetOnCloseListener_Landroidx_appcompat_widget_SearchView_OnCloseListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnCloseListener_Landroidx_appcompat_widget_SearchView_OnCloseListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SearchView? searchView = Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnCloseListener onCloseListener = Java.Lang.Object.GetObject<IOnCloseListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			searchView.SetOnCloseListener(onCloseListener);
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

	[Register("setOnCloseListener", "(Landroidx/appcompat/widget/SearchView$OnCloseListener;)V", "GetSetOnCloseListener_Landroidx_appcompat_widget_SearchView_OnCloseListener_Handler")]
	public unsafe virtual void SetOnCloseListener(IOnCloseListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnCloseListener.(Landroidx/appcompat/widget/SearchView$OnCloseListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetOnQueryTextFocusChangeListener_Landroid_view_View_OnFocusChangeListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetOnQueryTextFocusChangeListener_Landroid_view_View_OnFocusChangeListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnQueryTextFocusChangeListener_Landroid_view_View_OnFocusChangeListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SearchView? searchView = Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnFocusChangeListener onQueryTextFocusChangeListener = Java.Lang.Object.GetObject<IOnFocusChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			searchView.SetOnQueryTextFocusChangeListener(onQueryTextFocusChangeListener);
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

	[Register("setOnQueryTextFocusChangeListener", "(Landroid/view/View$OnFocusChangeListener;)V", "GetSetOnQueryTextFocusChangeListener_Landroid_view_View_OnFocusChangeListener_Handler")]
	public unsafe virtual void SetOnQueryTextFocusChangeListener(IOnFocusChangeListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnQueryTextFocusChangeListener.(Landroid/view/View$OnFocusChangeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetOnQueryTextListener_Landroidx_appcompat_widget_SearchView_OnQueryTextListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetOnQueryTextListener_Landroidx_appcompat_widget_SearchView_OnQueryTextListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnQueryTextListener_Landroidx_appcompat_widget_SearchView_OnQueryTextListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SearchView? searchView = Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnQueryTextListener onQueryTextListener = Java.Lang.Object.GetObject<IOnQueryTextListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			searchView.SetOnQueryTextListener(onQueryTextListener);
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

	[Register("setOnQueryTextListener", "(Landroidx/appcompat/widget/SearchView$OnQueryTextListener;)V", "GetSetOnQueryTextListener_Landroidx_appcompat_widget_SearchView_OnQueryTextListener_Handler")]
	public unsafe virtual void SetOnQueryTextListener(IOnQueryTextListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnQueryTextListener.(Landroidx/appcompat/widget/SearchView$OnQueryTextListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetOnSearchClickListener_Landroid_view_View_OnClickListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetOnSearchClickListener_Landroid_view_View_OnClickListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnSearchClickListener_Landroid_view_View_OnClickListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SearchView? searchView = Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnClickListener onSearchClickListener = Java.Lang.Object.GetObject<IOnClickListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			searchView.SetOnSearchClickListener(onSearchClickListener);
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

	[Register("setOnSearchClickListener", "(Landroid/view/View$OnClickListener;)V", "GetSetOnSearchClickListener_Landroid_view_View_OnClickListener_Handler")]
	public unsafe virtual void SetOnSearchClickListener(IOnClickListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnSearchClickListener.(Landroid/view/View$OnClickListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetOnSuggestionListener_Landroidx_appcompat_widget_SearchView_OnSuggestionListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetOnSuggestionListener_Landroidx_appcompat_widget_SearchView_OnSuggestionListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnSuggestionListener_Landroidx_appcompat_widget_SearchView_OnSuggestionListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SearchView? searchView = Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnSuggestionListener onSuggestionListener = Java.Lang.Object.GetObject<IOnSuggestionListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			searchView.SetOnSuggestionListener(onSuggestionListener);
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

	[Register("setOnSuggestionListener", "(Landroidx/appcompat/widget/SearchView$OnSuggestionListener;)V", "GetSetOnSuggestionListener_Landroidx_appcompat_widget_SearchView_OnSuggestionListener_Handler")]
	public unsafe virtual void SetOnSuggestionListener(IOnSuggestionListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnSuggestionListener.(Landroidx/appcompat/widget/SearchView$OnSuggestionListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetQuery_Ljava_lang_CharSequence_ZHandler()
	{
		return new global::_JniMarshal_PPLB_V(n_SetQuery_Ljava_lang_CharSequence_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetQuery_Ljava_lang_CharSequence_Z(nint jnienv, nint native__this, nint native_query, sbyte native_submit)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SearchView? searchView = Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence query = Java.Lang.Object.GetObject<ICharSequence>(native_query, JniHandleOwnership.DoNotTransfer);
			bool submit = native_submit != 0;
			searchView.SetQuery(query, submit);
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

	[Register("setQuery", "(Ljava/lang/CharSequence;Z)V", "GetSetQuery_Ljava_lang_CharSequence_ZHandler")]
	public unsafe virtual void SetQuery(ICharSequence? query, bool submit)
	{
		nint num = CharSequence.ToLocalJniHandle(query);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(submit ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setQuery.(Ljava/lang/CharSequence;Z)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(query);
		}
	}

	public void SetQuery(string? query, bool submit)
	{
		Java.Lang.String obj = ((query == null) ? null : new Java.Lang.String(query));
		SetQuery(obj, submit);
		obj?.Dispose();
	}

	private static Delegate GetSetSearchableInfo_Landroid_app_SearchableInfo_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetSearchableInfo_Landroid_app_SearchableInfo_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSearchableInfo_Landroid_app_SearchableInfo_(nint jnienv, nint native__this, nint native_searchable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SearchView? searchView = Java.Lang.Object.GetObject<SearchView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SearchableInfo searchableInfo = Java.Lang.Object.GetObject<SearchableInfo>(native_searchable, JniHandleOwnership.DoNotTransfer);
			searchView.SetSearchableInfo(searchableInfo);
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

	[Register("setSearchableInfo", "(Landroid/app/SearchableInfo;)V", "GetSetSearchableInfo_Landroid_app_SearchableInfo_Handler")]
	public unsafe virtual void SetSearchableInfo(SearchableInfo? searchable)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(searchable?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSearchableInfo.(Landroid/app/SearchableInfo;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(searchable);
		}
	}

	private IOnCloseListenerImplementor __CreateIOnCloseListenerImplementor()
	{
		return new IOnCloseListenerImplementor(this);
	}

	private IOnQueryTextListenerImplementor __CreateIOnQueryTextListenerImplementor()
	{
		return new IOnQueryTextListenerImplementor(this);
	}

	private IOnSuggestionListenerImplementor __CreateIOnSuggestionListenerImplementor()
	{
		return new IOnSuggestionListenerImplementor(this);
	}
}
