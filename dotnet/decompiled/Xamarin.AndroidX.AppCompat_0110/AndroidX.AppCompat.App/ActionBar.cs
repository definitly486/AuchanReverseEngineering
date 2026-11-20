using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.View;
using AndroidX.Fragment.App;
using Java.Interop;
using Java.Lang;

namespace AndroidX.AppCompat.App;

[Register("androidx/appcompat/app/ActionBar", DoNotGenerateAcw = true)]
public abstract class ActionBar : Java.Lang.Object
{
	[Register("androidx/appcompat/app/ActionBar$LayoutParams", DoNotGenerateAcw = true)]
	public class LayoutParams : ViewGroup.MarginLayoutParams
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/appcompat/app/ActionBar$LayoutParams", typeof(LayoutParams));

		[Register("gravity")]
		public int Gravity
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("gravity.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("gravity.I", this, value);
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

		protected LayoutParams(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe LayoutParams(Context c, IAttributeSet? attrs)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(c);
				GC.KeepAlive(attrs);
			}
		}

		[Register(".ctor", "(Landroid/view/ViewGroup$LayoutParams;)V", "")]
		public unsafe LayoutParams(ViewGroup.LayoutParams? source)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/ViewGroup$LayoutParams;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/view/ViewGroup$LayoutParams;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}

		[Register(".ctor", "(Landroidx/appcompat/app/ActionBar$LayoutParams;)V", "")]
		public unsafe LayoutParams(LayoutParams? source)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/appcompat/app/ActionBar$LayoutParams;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/appcompat/app/ActionBar$LayoutParams;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}

		[Register(".ctor", "(I)V", "")]
		public unsafe LayoutParams(int gravity)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(gravity);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
			}
		}

		[Register(".ctor", "(II)V", "")]
		public unsafe LayoutParams(int width, int height)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(width);
				ptr[1] = new JniArgumentValue(height);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(II)V", this, ptr);
			}
		}

		[Register(".ctor", "(III)V", "")]
		public unsafe LayoutParams(int width, int height, int gravity)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(width);
				ptr[1] = new JniArgumentValue(height);
				ptr[2] = new JniArgumentValue(gravity);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(III)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(III)V", this, ptr);
			}
		}
	}

	[Register("androidx/appcompat/app/ActionBar$OnMenuVisibilityListener", "", "AndroidX.AppCompat.App.ActionBar/IOnMenuVisibilityListenerInvoker")]
	public interface IOnMenuVisibilityListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onMenuVisibilityChanged", "(Z)V", "GetOnMenuVisibilityChanged_ZHandler:AndroidX.AppCompat.App.ActionBar/IOnMenuVisibilityListenerInvoker, Xamarin.AndroidX.AppCompat")]
		void OnMenuVisibilityChanged(bool isVisible);
	}

	[Register("androidx/appcompat/app/ActionBar$OnMenuVisibilityListener", DoNotGenerateAcw = true)]
	internal class IOnMenuVisibilityListenerInvoker : Java.Lang.Object, IOnMenuVisibilityListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_appcompat_app_ActionBar_OnMenuVisibilityListener = new XAPeerMembers("androidx/appcompat/app/ActionBar$OnMenuVisibilityListener", typeof(IOnMenuVisibilityListenerInvoker));

		private static Delegate? cb_onMenuVisibilityChanged_OnMenuVisibilityChanged_Z_V;

		private static nint java_class_ref => _members_androidx_appcompat_app_ActionBar_OnMenuVisibilityListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_appcompat_app_ActionBar_OnMenuVisibilityListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_appcompat_app_ActionBar_OnMenuVisibilityListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_appcompat_app_ActionBar_OnMenuVisibilityListener.ManagedPeerType;

		public IOnMenuVisibilityListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnMenuVisibilityChanged_Z(nint jnienv, nint native__this, sbyte native_isVisible)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnMenuVisibilityListener? onMenuVisibilityListener = Java.Lang.Object.GetObject<IOnMenuVisibilityListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				bool isVisible = native_isVisible != 0;
				onMenuVisibilityListener.OnMenuVisibilityChanged(isVisible);
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

		public unsafe void OnMenuVisibilityChanged(bool isVisible)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(isVisible ? ((sbyte)1) : ((sbyte)0));
			_members_androidx_appcompat_app_ActionBar_OnMenuVisibilityListener.InstanceMethods.InvokeAbstractVoidMethod("onMenuVisibilityChanged.(Z)V", this, ptr);
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
		private static void n_OnMenuVisibilityChanged_Z_mm_wrapper(nint jnienv, nint native__this, sbyte native_isVisible)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnMenuVisibilityChanged_Z(jnienv, native__this, native_isVisible);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class MenuVisibilityEventArgs : EventArgs
	{
		private bool isVisible;

		public MenuVisibilityEventArgs(bool isVisible)
		{
			this.isVisible = isVisible;
		}
	}

	[Register("mono/androidx/appcompat/app/ActionBar_OnMenuVisibilityListenerImplementor")]
	internal sealed class IOnMenuVisibilityListenerImplementor : Java.Lang.Object, IOnMenuVisibilityListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<MenuVisibilityEventArgs>? Handler;

		public unsafe IOnMenuVisibilityListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnMenuVisibilityChanged(bool isVisible)
		{
			Handler?.Invoke(sender, new MenuVisibilityEventArgs(isVisible));
		}

		internal static bool __IsEmpty(IOnMenuVisibilityListenerImplementor value)
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

	[Obsolete("This class is obsoleted in this android platform")]
	[Register("androidx/appcompat/app/ActionBar$OnNavigationListener", "", "AndroidX.AppCompat.App.ActionBar/IOnNavigationListenerInvoker")]
	public interface IOnNavigationListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onNavigationItemSelected", "(IJ)Z", "GetOnNavigationItemSelected_IJHandler:AndroidX.AppCompat.App.ActionBar/IOnNavigationListenerInvoker, Xamarin.AndroidX.AppCompat")]
		bool OnNavigationItemSelected(int itemPosition, long itemId);
	}

	[Register("androidx/appcompat/app/ActionBar$OnNavigationListener", DoNotGenerateAcw = true)]
	[Obsolete("This class is obsoleted in this android platform")]
	internal class IOnNavigationListenerInvoker : Java.Lang.Object, IOnNavigationListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_appcompat_app_ActionBar_OnNavigationListener = new XAPeerMembers("androidx/appcompat/app/ActionBar$OnNavigationListener", typeof(IOnNavigationListenerInvoker));

		private static Delegate? cb_onNavigationItemSelected_OnNavigationItemSelected_IJ_Z;

		private static nint java_class_ref => _members_androidx_appcompat_app_ActionBar_OnNavigationListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_appcompat_app_ActionBar_OnNavigationListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_appcompat_app_ActionBar_OnNavigationListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_appcompat_app_ActionBar_OnNavigationListener.ManagedPeerType;

		public IOnNavigationListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnNavigationItemSelected_IJHandler()
		{
			return new _JniMarshal_PPIJ_B(n_OnNavigationItemSelected_IJ);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnNavigationItemSelected_IJ(nint jnienv, nint native__this, int itemPosition, long itemId)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<IOnNavigationListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnNavigationItemSelected(itemPosition, itemId) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool OnNavigationItemSelected(int itemPosition, long itemId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(itemPosition);
			ptr[1] = new JniArgumentValue(itemId);
			return _members_androidx_appcompat_app_ActionBar_OnNavigationListener.InstanceMethods.InvokeAbstractBooleanMethod("onNavigationItemSelected.(IJ)Z", this, ptr);
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

	[Obsolete("This class is obsoleted in this android platform")]
	[Register("androidx/appcompat/app/ActionBar$Tab", DoNotGenerateAcw = true)]
	public abstract class Tab : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/appcompat/app/ActionBar$Tab", typeof(Tab));

		private static Delegate? cb_getContentDescription_GetContentDescription_Ljava_lang_CharSequence_;

		private static Delegate? cb_getCustomView_GetCustomView_Landroid_view_View_;

		private static Delegate? cb_getIcon_GetIcon_Landroid_graphics_drawable_Drawable_;

		private static Delegate? cb_getPosition_GetPosition_I;

		private static Delegate? cb_getTag_GetTag_Ljava_lang_Object_;

		private static Delegate? cb_getText_GetText_Ljava_lang_CharSequence_;

		private static Delegate? cb_select_Select_V;

		private static Delegate? cb_setContentDescription_SetContentDescription_I_Landroidx_appcompat_app_ActionBar_Tab_;

		private static Delegate? cb_setContentDescription_SetContentDescription_Ljava_lang_CharSequence__Landroidx_appcompat_app_ActionBar_Tab_;

		private static Delegate? cb_setCustomView_SetCustomView_Landroid_view_View__Landroidx_appcompat_app_ActionBar_Tab_;

		private static Delegate? cb_setCustomView_SetCustomView_I_Landroidx_appcompat_app_ActionBar_Tab_;

		private static Delegate? cb_setIcon_SetIcon_Landroid_graphics_drawable_Drawable__Landroidx_appcompat_app_ActionBar_Tab_;

		private static Delegate? cb_setIcon_SetIcon_I_Landroidx_appcompat_app_ActionBar_Tab_;

		private static Delegate? cb_setTabListener_SetTabListener_Landroidx_appcompat_app_ActionBar_TabListener__Landroidx_appcompat_app_ActionBar_Tab_;

		private static Delegate? cb_setTag_SetTag_Ljava_lang_Object__Landroidx_appcompat_app_ActionBar_Tab_;

		private static Delegate? cb_setText_SetText_I_Landroidx_appcompat_app_ActionBar_Tab_;

		private static Delegate? cb_setText_SetText_Ljava_lang_CharSequence__Landroidx_appcompat_app_ActionBar_Tab_;

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

		public abstract ICharSequence? ContentDescriptionFormatted
		{
			[Register("getContentDescription", "()Ljava/lang/CharSequence;", "GetGetContentDescriptionHandler")]
			get;
		}

		public string? ContentDescription
		{
			get
			{
				if (ContentDescriptionFormatted != null)
				{
					return ContentDescriptionFormatted.ToString();
				}
				return null;
			}
		}

		public abstract Android.Views.View? CustomView
		{
			[Register("getCustomView", "()Landroid/view/View;", "GetGetCustomViewHandler")]
			get;
		}

		public abstract Drawable? Icon
		{
			[Register("getIcon", "()Landroid/graphics/drawable/Drawable;", "GetGetIconHandler")]
			get;
		}

		public abstract int Position
		{
			[Register("getPosition", "()I", "GetGetPositionHandler")]
			get;
		}

		public abstract Java.Lang.Object? Tag
		{
			[Register("getTag", "()Ljava/lang/Object;", "GetGetTagHandler")]
			get;
		}

		public abstract ICharSequence? TextFormatted
		{
			[Register("getText", "()Ljava/lang/CharSequence;", "GetGetTextHandler")]
			get;
		}

		public string? Text
		{
			get
			{
				if (TextFormatted != null)
				{
					return TextFormatted.ToString();
				}
				return null;
			}
		}

		protected Tab(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Tab()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetContentDescriptionHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetContentDescription);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetContentDescription(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentDescriptionFormatted);
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

		private static Delegate GetGetCustomViewHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetCustomView);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetCustomView(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CustomView);
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

		private static Delegate GetGetIconHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetIcon);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetIcon(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Icon);
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

		private static Delegate GetGetPositionHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetPosition);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetPosition(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Position;
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

		private static Delegate GetGetTagHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetTag);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetTag(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Tag);
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

		private static Delegate GetGetTextHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetText);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetText(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TextFormatted);
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

		private static Delegate GetSelectHandler()
		{
			return new global::_JniMarshal_PP_V(n_Select);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Select(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Select();
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

		[Register("select", "()V", "GetSelectHandler")]
		public abstract void Select();

		private static Delegate GetSetContentDescription_IHandler()
		{
			return new global::_JniMarshal_PPI_L(n_SetContentDescription_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetContentDescription_I(nint jnienv, nint native__this, int resId)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetContentDescription(resId));
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

		[Register("setContentDescription", "(I)Landroidx/appcompat/app/ActionBar$Tab;", "GetSetContentDescription_IHandler")]
		public abstract Tab? SetContentDescription(int resId);

		private static Delegate GetSetContentDescription_Ljava_lang_CharSequence_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_SetContentDescription_Ljava_lang_CharSequence_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetContentDescription_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_contentDesc)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Tab? tab = Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ICharSequence contentDescription = Java.Lang.Object.GetObject<ICharSequence>(native_contentDesc, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(tab.SetContentDescription(contentDescription));
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

		[Register("setContentDescription", "(Ljava/lang/CharSequence;)Landroidx/appcompat/app/ActionBar$Tab;", "GetSetContentDescription_Ljava_lang_CharSequence_Handler")]
		public abstract Tab? SetContentDescription(ICharSequence? contentDesc);

		public Tab? SetContentDescription(string? contentDesc)
		{
			Java.Lang.String obj = ((contentDesc == null) ? null : new Java.Lang.String(contentDesc));
			Tab? result = SetContentDescription(obj);
			obj?.Dispose();
			return result;
		}

		private static Delegate GetSetCustomView_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_SetCustomView_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetCustomView_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Tab? tab = Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Android.Views.View customView = Java.Lang.Object.GetObject<Android.Views.View>(native_view, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(tab.SetCustomView(customView));
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

		[Register("setCustomView", "(Landroid/view/View;)Landroidx/appcompat/app/ActionBar$Tab;", "GetSetCustomView_Landroid_view_View_Handler")]
		public abstract Tab? SetCustomView(Android.Views.View? view);

		private static Delegate GetSetCustomView_IHandler()
		{
			return new global::_JniMarshal_PPI_L(n_SetCustomView_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetCustomView_I(nint jnienv, nint native__this, int layoutResId)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCustomView(layoutResId));
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

		[Register("setCustomView", "(I)Landroidx/appcompat/app/ActionBar$Tab;", "GetSetCustomView_IHandler")]
		public abstract Tab? SetCustomView(int layoutResId);

		private static Delegate GetSetIcon_Landroid_graphics_drawable_Drawable_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_SetIcon_Landroid_graphics_drawable_Drawable_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetIcon_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_icon)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Tab? tab = Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Drawable icon = Java.Lang.Object.GetObject<Drawable>(native_icon, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(tab.SetIcon(icon));
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

		[Register("setIcon", "(Landroid/graphics/drawable/Drawable;)Landroidx/appcompat/app/ActionBar$Tab;", "GetSetIcon_Landroid_graphics_drawable_Drawable_Handler")]
		public abstract Tab? SetIcon(Drawable? icon);

		private static Delegate GetSetIcon_IHandler()
		{
			return new global::_JniMarshal_PPI_L(n_SetIcon_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetIcon_I(nint jnienv, nint native__this, int resId)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetIcon(resId));
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

		[Register("setIcon", "(I)Landroidx/appcompat/app/ActionBar$Tab;", "GetSetIcon_IHandler")]
		public abstract Tab? SetIcon(int resId);

		private static Delegate GetSetTabListener_Landroidx_appcompat_app_ActionBar_TabListener_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_SetTabListener_Landroidx_appcompat_app_ActionBar_TabListener_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetTabListener_Landroidx_appcompat_app_ActionBar_TabListener_(nint jnienv, nint native__this, nint native_listener)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Tab? tab = Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ITabListener tabListener = Java.Lang.Object.GetObject<ITabListener>(native_listener, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(tab.SetTabListener(tabListener));
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

		[Register("setTabListener", "(Landroidx/appcompat/app/ActionBar$TabListener;)Landroidx/appcompat/app/ActionBar$Tab;", "GetSetTabListener_Landroidx_appcompat_app_ActionBar_TabListener_Handler")]
		public abstract Tab? SetTabListener(ITabListener? listener);

		private static Delegate GetSetTag_Ljava_lang_Object_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_SetTag_Ljava_lang_Object_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetTag_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_obj)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Tab? tab = Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object tag = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(tab.SetTag(tag));
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

		[Register("setTag", "(Ljava/lang/Object;)Landroidx/appcompat/app/ActionBar$Tab;", "GetSetTag_Ljava_lang_Object_Handler")]
		public abstract Tab? SetTag(Java.Lang.Object? obj);

		private static Delegate GetSetText_IHandler()
		{
			return new global::_JniMarshal_PPI_L(n_SetText_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetText_I(nint jnienv, nint native__this, int resId)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetText(resId));
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

		[Register("setText", "(I)Landroidx/appcompat/app/ActionBar$Tab;", "GetSetText_IHandler")]
		public abstract Tab? SetText(int resId);

		private static Delegate GetSetText_Ljava_lang_CharSequence_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_SetText_Ljava_lang_CharSequence_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetText_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_text)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Tab? tab = Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ICharSequence text = Java.Lang.Object.GetObject<ICharSequence>(native_text, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(tab.SetText(text));
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

		[Register("setText", "(Ljava/lang/CharSequence;)Landroidx/appcompat/app/ActionBar$Tab;", "GetSetText_Ljava_lang_CharSequence_Handler")]
		public abstract Tab? SetText(ICharSequence? text);

		public Tab? SetText(string? text)
		{
			Java.Lang.String obj = ((text == null) ? null : new Java.Lang.String(text));
			Tab? result = SetText(obj);
			obj?.Dispose();
			return result;
		}
	}

	[Register("androidx/appcompat/app/ActionBar$Tab", DoNotGenerateAcw = true)]
	internal class TabInvoker : Tab
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/appcompat/app/ActionBar$Tab", typeof(TabInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override ICharSequence? ContentDescriptionFormatted
		{
			[Register("getContentDescription", "()Ljava/lang/CharSequence;", "GetGetContentDescriptionHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeAbstractObjectMethod("getContentDescription.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override Android.Views.View? CustomView
		{
			[Register("getCustomView", "()Landroid/view/View;", "GetGetCustomViewHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Android.Views.View>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCustomView.()Landroid/view/View;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override Drawable? Icon
		{
			[Register("getIcon", "()Landroid/graphics/drawable/Drawable;", "GetGetIconHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeAbstractObjectMethod("getIcon.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override int Position
		{
			[Register("getPosition", "()I", "GetGetPositionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getPosition.()I", this, null);
			}
		}

		public unsafe override Java.Lang.Object? Tag
		{
			[Register("getTag", "()Ljava/lang/Object;", "GetGetTagHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTag.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override ICharSequence? TextFormatted
		{
			[Register("getText", "()Ljava/lang/CharSequence;", "GetGetTextHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeAbstractObjectMethod("getText.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public TabInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("select", "()V", "GetSelectHandler")]
		public unsafe override void Select()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("select.()V", this, null);
		}

		[Register("setContentDescription", "(I)Landroidx/appcompat/app/ActionBar$Tab;", "GetSetContentDescription_IHandler")]
		public unsafe override Tab? SetContentDescription(int resId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resId);
			return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeAbstractObjectMethod("setContentDescription.(I)Landroidx/appcompat/app/ActionBar$Tab;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setContentDescription", "(Ljava/lang/CharSequence;)Landroidx/appcompat/app/ActionBar$Tab;", "GetSetContentDescription_Ljava_lang_CharSequence_Handler")]
		public unsafe override Tab? SetContentDescription(ICharSequence? contentDesc)
		{
			nint num = CharSequence.ToLocalJniHandle(contentDesc);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeAbstractObjectMethod("setContentDescription.(Ljava/lang/CharSequence;)Landroidx/appcompat/app/ActionBar$Tab;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(contentDesc);
			}
		}

		[Register("setCustomView", "(Landroid/view/View;)Landroidx/appcompat/app/ActionBar$Tab;", "GetSetCustomView_Landroid_view_View_Handler")]
		public unsafe override Tab? SetCustomView(Android.Views.View? view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeAbstractObjectMethod("setCustomView.(Landroid/view/View;)Landroidx/appcompat/app/ActionBar$Tab;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		[Register("setCustomView", "(I)Landroidx/appcompat/app/ActionBar$Tab;", "GetSetCustomView_IHandler")]
		public unsafe override Tab? SetCustomView(int layoutResId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(layoutResId);
			return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeAbstractObjectMethod("setCustomView.(I)Landroidx/appcompat/app/ActionBar$Tab;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setIcon", "(Landroid/graphics/drawable/Drawable;)Landroidx/appcompat/app/ActionBar$Tab;", "GetSetIcon_Landroid_graphics_drawable_Drawable_Handler")]
		public unsafe override Tab? SetIcon(Drawable? icon)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeAbstractObjectMethod("setIcon.(Landroid/graphics/drawable/Drawable;)Landroidx/appcompat/app/ActionBar$Tab;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(icon);
			}
		}

		[Register("setIcon", "(I)Landroidx/appcompat/app/ActionBar$Tab;", "GetSetIcon_IHandler")]
		public unsafe override Tab? SetIcon(int resId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resId);
			return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeAbstractObjectMethod("setIcon.(I)Landroidx/appcompat/app/ActionBar$Tab;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setTabListener", "(Landroidx/appcompat/app/ActionBar$TabListener;)Landroidx/appcompat/app/ActionBar$Tab;", "GetSetTabListener_Landroidx_appcompat_app_ActionBar_TabListener_Handler")]
		public unsafe override Tab? SetTabListener(ITabListener? listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeAbstractObjectMethod("setTabListener.(Landroidx/appcompat/app/ActionBar$TabListener;)Landroidx/appcompat/app/ActionBar$Tab;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		[Register("setTag", "(Ljava/lang/Object;)Landroidx/appcompat/app/ActionBar$Tab;", "GetSetTag_Ljava_lang_Object_Handler")]
		public unsafe override Tab? SetTag(Java.Lang.Object? obj)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeAbstractObjectMethod("setTag.(Ljava/lang/Object;)Landroidx/appcompat/app/ActionBar$Tab;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
			}
		}

		[Register("setText", "(I)Landroidx/appcompat/app/ActionBar$Tab;", "GetSetText_IHandler")]
		public unsafe override Tab? SetText(int resId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resId);
			return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeAbstractObjectMethod("setText.(I)Landroidx/appcompat/app/ActionBar$Tab;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setText", "(Ljava/lang/CharSequence;)Landroidx/appcompat/app/ActionBar$Tab;", "GetSetText_Ljava_lang_CharSequence_Handler")]
		public unsafe override Tab? SetText(ICharSequence? text)
		{
			nint num = CharSequence.ToLocalJniHandle(text);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeAbstractObjectMethod("setText.(Ljava/lang/CharSequence;)Landroidx/appcompat/app/ActionBar$Tab;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(text);
			}
		}
	}

	[Obsolete("This class is obsoleted in this android platform")]
	[Register("androidx/appcompat/app/ActionBar$TabListener", "", "AndroidX.AppCompat.App.ActionBar/ITabListenerInvoker")]
	public interface ITabListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onTabReselected", "(Landroidx/appcompat/app/ActionBar$Tab;Landroidx/fragment/app/FragmentTransaction;)V", "GetOnTabReselected_Landroidx_appcompat_app_ActionBar_Tab_Landroidx_fragment_app_FragmentTransaction_Handler:AndroidX.AppCompat.App.ActionBar/ITabListenerInvoker, Xamarin.AndroidX.AppCompat")]
		void OnTabReselected(Tab? tab, FragmentTransaction? ft);

		[Register("onTabSelected", "(Landroidx/appcompat/app/ActionBar$Tab;Landroidx/fragment/app/FragmentTransaction;)V", "GetOnTabSelected_Landroidx_appcompat_app_ActionBar_Tab_Landroidx_fragment_app_FragmentTransaction_Handler:AndroidX.AppCompat.App.ActionBar/ITabListenerInvoker, Xamarin.AndroidX.AppCompat")]
		void OnTabSelected(Tab? tab, FragmentTransaction? ft);

		[Register("onTabUnselected", "(Landroidx/appcompat/app/ActionBar$Tab;Landroidx/fragment/app/FragmentTransaction;)V", "GetOnTabUnselected_Landroidx_appcompat_app_ActionBar_Tab_Landroidx_fragment_app_FragmentTransaction_Handler:AndroidX.AppCompat.App.ActionBar/ITabListenerInvoker, Xamarin.AndroidX.AppCompat")]
		void OnTabUnselected(Tab? tab, FragmentTransaction? ft);
	}

	[Register("androidx/appcompat/app/ActionBar$TabListener", DoNotGenerateAcw = true)]
	[Obsolete("This class is obsoleted in this android platform")]
	internal class ITabListenerInvoker : Java.Lang.Object, ITabListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_appcompat_app_ActionBar_TabListener = new XAPeerMembers("androidx/appcompat/app/ActionBar$TabListener", typeof(ITabListenerInvoker));

		private static Delegate? cb_onTabReselected_OnTabReselected_Landroidx_appcompat_app_ActionBar_Tab_Landroidx_fragment_app_FragmentTransaction__V;

		private static Delegate? cb_onTabSelected_OnTabSelected_Landroidx_appcompat_app_ActionBar_Tab_Landroidx_fragment_app_FragmentTransaction__V;

		private static Delegate? cb_onTabUnselected_OnTabUnselected_Landroidx_appcompat_app_ActionBar_Tab_Landroidx_fragment_app_FragmentTransaction__V;

		private static nint java_class_ref => _members_androidx_appcompat_app_ActionBar_TabListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_appcompat_app_ActionBar_TabListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_appcompat_app_ActionBar_TabListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_appcompat_app_ActionBar_TabListener.ManagedPeerType;

		public ITabListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnTabReselected_Landroidx_appcompat_app_ActionBar_Tab_Landroidx_fragment_app_FragmentTransaction_Handler()
		{
			return new global::_JniMarshal_PPLL_V(n_OnTabReselected_Landroidx_appcompat_app_ActionBar_Tab_Landroidx_fragment_app_FragmentTransaction_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnTabReselected_Landroidx_appcompat_app_ActionBar_Tab_Landroidx_fragment_app_FragmentTransaction_(nint jnienv, nint native__this, nint native_tab, nint native_ft)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ITabListener? tabListener = Java.Lang.Object.GetObject<ITabListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Tab tab = Java.Lang.Object.GetObject<Tab>(native_tab, JniHandleOwnership.DoNotTransfer);
				FragmentTransaction ft = Java.Lang.Object.GetObject<FragmentTransaction>(native_ft, JniHandleOwnership.DoNotTransfer);
				tabListener.OnTabReselected(tab, ft);
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

		public unsafe void OnTabReselected(Tab? tab, FragmentTransaction? ft)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(tab?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(ft?.Handle ?? IntPtr.Zero);
				_members_androidx_appcompat_app_ActionBar_TabListener.InstanceMethods.InvokeAbstractVoidMethod("onTabReselected.(Landroidx/appcompat/app/ActionBar$Tab;Landroidx/fragment/app/FragmentTransaction;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(tab);
				GC.KeepAlive(ft);
			}
		}

		private static Delegate GetOnTabSelected_Landroidx_appcompat_app_ActionBar_Tab_Landroidx_fragment_app_FragmentTransaction_Handler()
		{
			return new global::_JniMarshal_PPLL_V(n_OnTabSelected_Landroidx_appcompat_app_ActionBar_Tab_Landroidx_fragment_app_FragmentTransaction_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnTabSelected_Landroidx_appcompat_app_ActionBar_Tab_Landroidx_fragment_app_FragmentTransaction_(nint jnienv, nint native__this, nint native_tab, nint native_ft)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ITabListener? tabListener = Java.Lang.Object.GetObject<ITabListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Tab tab = Java.Lang.Object.GetObject<Tab>(native_tab, JniHandleOwnership.DoNotTransfer);
				FragmentTransaction ft = Java.Lang.Object.GetObject<FragmentTransaction>(native_ft, JniHandleOwnership.DoNotTransfer);
				tabListener.OnTabSelected(tab, ft);
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

		public unsafe void OnTabSelected(Tab? tab, FragmentTransaction? ft)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(tab?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(ft?.Handle ?? IntPtr.Zero);
				_members_androidx_appcompat_app_ActionBar_TabListener.InstanceMethods.InvokeAbstractVoidMethod("onTabSelected.(Landroidx/appcompat/app/ActionBar$Tab;Landroidx/fragment/app/FragmentTransaction;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(tab);
				GC.KeepAlive(ft);
			}
		}

		private static Delegate GetOnTabUnselected_Landroidx_appcompat_app_ActionBar_Tab_Landroidx_fragment_app_FragmentTransaction_Handler()
		{
			return new global::_JniMarshal_PPLL_V(n_OnTabUnselected_Landroidx_appcompat_app_ActionBar_Tab_Landroidx_fragment_app_FragmentTransaction_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnTabUnselected_Landroidx_appcompat_app_ActionBar_Tab_Landroidx_fragment_app_FragmentTransaction_(nint jnienv, nint native__this, nint native_tab, nint native_ft)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ITabListener? tabListener = Java.Lang.Object.GetObject<ITabListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Tab tab = Java.Lang.Object.GetObject<Tab>(native_tab, JniHandleOwnership.DoNotTransfer);
				FragmentTransaction ft = Java.Lang.Object.GetObject<FragmentTransaction>(native_ft, JniHandleOwnership.DoNotTransfer);
				tabListener.OnTabUnselected(tab, ft);
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

		public unsafe void OnTabUnselected(Tab? tab, FragmentTransaction? ft)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(tab?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(ft?.Handle ?? IntPtr.Zero);
				_members_androidx_appcompat_app_ActionBar_TabListener.InstanceMethods.InvokeAbstractVoidMethod("onTabUnselected.(Landroidx/appcompat/app/ActionBar$Tab;Landroidx/fragment/app/FragmentTransaction;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(tab);
				GC.KeepAlive(ft);
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/appcompat/app/ActionBar", typeof(ActionBar));

	private static Delegate? cb_getCustomView_GetCustomView_Landroid_view_View_;

	private static Delegate? cb_setCustomView_SetCustomView_Landroid_view_View__V;

	private static Delegate? cb_getDisplayOptions_GetDisplayOptions_I;

	private static Delegate? cb_setDisplayOptions_SetDisplayOptions_I_V;

	private static Delegate? cb_getElevation_GetElevation_F;

	private static Delegate? cb_setElevation_SetElevation_F_V;

	private static Delegate? cb_getHeight_GetHeight_I;

	private static Delegate? cb_getHideOffset_GetHideOffset_I;

	private static Delegate? cb_setHideOffset_SetHideOffset_I_V;

	private static Delegate? cb_isHideOnContentScrollEnabled_IsHideOnContentScrollEnabled_Z;

	private static Delegate? cb_setHideOnContentScrollEnabled_SetHideOnContentScrollEnabled_Z_V;

	private static Delegate? cb_isShowing_IsShowing_Z;

	private static Delegate? cb_isTitleTruncated_IsTitleTruncated_Z;

	private static Delegate? cb_getNavigationItemCount_GetNavigationItemCount_I;

	private static Delegate? cb_getNavigationMode_GetNavigationMode_I;

	private static Delegate? cb_setNavigationMode_SetNavigationMode_I_V;

	private static Delegate? cb_getSelectedNavigationIndex_GetSelectedNavigationIndex_I;

	private static Delegate? cb_getSelectedTab_GetSelectedTab_Landroidx_appcompat_app_ActionBar_Tab_;

	private static Delegate? cb_getSubtitle_GetSubtitle_Ljava_lang_CharSequence_;

	private static Delegate? cb_setSubtitle_SetSubtitle_Ljava_lang_CharSequence__V;

	private static Delegate? cb_getTabCount_GetTabCount_I;

	private static Delegate? cb_getThemedContext_GetThemedContext_Landroid_content_Context_;

	private static Delegate? cb_getTitle_GetTitle_Ljava_lang_CharSequence_;

	private static Delegate? cb_setTitle_SetTitle_Ljava_lang_CharSequence__V;

	private static Delegate? cb_addOnMenuVisibilityListener_AddOnMenuVisibilityListener_Landroidx_appcompat_app_ActionBar_OnMenuVisibilityListener__V;

	private static Delegate? cb_addTab_AddTab_Landroidx_appcompat_app_ActionBar_Tab__V;

	private static Delegate? cb_addTab_AddTab_Landroidx_appcompat_app_ActionBar_Tab_Z_V;

	private static Delegate? cb_addTab_AddTab_Landroidx_appcompat_app_ActionBar_Tab_I_V;

	private static Delegate? cb_addTab_AddTab_Landroidx_appcompat_app_ActionBar_Tab_IZ_V;

	private static Delegate? cb_closeOptionsMenu_CloseOptionsMenu_Z;

	private static Delegate? cb_collapseActionView_CollapseActionView_Z;

	private static Delegate? cb_dispatchMenuVisibilityChanged_DispatchMenuVisibilityChanged_Z_V;

	private static Delegate? cb_getTabAt_GetTabAt_I_Landroidx_appcompat_app_ActionBar_Tab_;

	private static Delegate? cb_hide_Hide_V;

	private static Delegate? cb_invalidateOptionsMenu_InvalidateOptionsMenu_Z;

	private static Delegate? cb_newTab_NewTab_Landroidx_appcompat_app_ActionBar_Tab_;

	private static Delegate? cb_onConfigurationChanged_OnConfigurationChanged_Landroid_content_res_Configuration__V;

	private static Delegate? cb_onKeyShortcut_OnKeyShortcut_ILandroid_view_KeyEvent__Z;

	private static Delegate? cb_onMenuKeyEvent_OnMenuKeyEvent_Landroid_view_KeyEvent__Z;

	private static Delegate? cb_openOptionsMenu_OpenOptionsMenu_Z;

	private static Delegate? cb_removeAllTabs_RemoveAllTabs_V;

	private static Delegate? cb_removeOnMenuVisibilityListener_RemoveOnMenuVisibilityListener_Landroidx_appcompat_app_ActionBar_OnMenuVisibilityListener__V;

	private static Delegate? cb_removeTab_RemoveTab_Landroidx_appcompat_app_ActionBar_Tab__V;

	private static Delegate? cb_removeTabAt_RemoveTabAt_I_V;

	private static Delegate? cb_selectTab_SelectTab_Landroidx_appcompat_app_ActionBar_Tab__V;

	private static Delegate? cb_setBackgroundDrawable_SetBackgroundDrawable_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_setCustomView_SetCustomView_Landroid_view_View_Landroidx_appcompat_app_ActionBar_LayoutParams__V;

	private static Delegate? cb_setCustomView_SetCustomView_I_V;

	private static Delegate? cb_setDefaultDisplayHomeAsUpEnabled_SetDefaultDisplayHomeAsUpEnabled_Z_V;

	private static Delegate? cb_setDisplayHomeAsUpEnabled_SetDisplayHomeAsUpEnabled_Z_V;

	private static Delegate? cb_setDisplayOptions_SetDisplayOptions_II_V;

	private static Delegate? cb_setDisplayShowCustomEnabled_SetDisplayShowCustomEnabled_Z_V;

	private static Delegate? cb_setDisplayShowHomeEnabled_SetDisplayShowHomeEnabled_Z_V;

	private static Delegate? cb_setDisplayShowTitleEnabled_SetDisplayShowTitleEnabled_Z_V;

	private static Delegate? cb_setDisplayUseLogoEnabled_SetDisplayUseLogoEnabled_Z_V;

	private static Delegate? cb_setHomeActionContentDescription_SetHomeActionContentDescription_I_V;

	private static Delegate? cb_setHomeActionContentDescription_SetHomeActionContentDescription_Ljava_lang_CharSequence__V;

	private static Delegate? cb_setHomeAsUpIndicator_SetHomeAsUpIndicator_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_setHomeAsUpIndicator_SetHomeAsUpIndicator_I_V;

	private static Delegate? cb_setHomeButtonEnabled_SetHomeButtonEnabled_Z_V;

	private static Delegate? cb_setIcon_SetIcon_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_setIcon_SetIcon_I_V;

	private static Delegate? cb_setListNavigationCallbacks_SetListNavigationCallbacks_Landroid_widget_SpinnerAdapter_Landroidx_appcompat_app_ActionBar_OnNavigationListener__V;

	private static Delegate? cb_setLogo_SetLogo_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_setLogo_SetLogo_I_V;

	private static Delegate? cb_setSelectedNavigationItem_SetSelectedNavigationItem_I_V;

	private static Delegate? cb_setShowHideAnimationEnabled_SetShowHideAnimationEnabled_Z_V;

	private static Delegate? cb_setSplitBackgroundDrawable_SetSplitBackgroundDrawable_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_setStackedBackgroundDrawable_SetStackedBackgroundDrawable_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_setSubtitle_SetSubtitle_I_V;

	private static Delegate? cb_setTitle_SetTitle_I_V;

	private static Delegate? cb_setWindowTitle_SetWindowTitle_Ljava_lang_CharSequence__V;

	private static Delegate? cb_show_Show_V;

	private static Delegate? cb_startActionMode_StartActionMode_Landroidx_appcompat_view_ActionMode_Callback__Landroidx_appcompat_view_ActionMode_;

	private WeakReference? weak_implementor_AddOnMenuVisibilityListener;

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

	public abstract Android.Views.View? CustomView
	{
		[Register("getCustomView", "()Landroid/view/View;", "GetGetCustomViewHandler")]
		get;
		[Register("setCustomView", "(Landroid/view/View;)V", "GetSetCustomView_Landroid_view_View_Handler")]
		set;
	}

	public abstract int DisplayOptions
	{
		[Register("getDisplayOptions", "()I", "GetGetDisplayOptionsHandler")]
		get;
		[Register("setDisplayOptions", "(I)V", "GetSetDisplayOptions_IHandler")]
		set;
	}

	public unsafe virtual float Elevation
	{
		[Register("getElevation", "()F", "GetGetElevationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getElevation.()F", this, null);
		}
		[Register("setElevation", "(F)V", "GetSetElevation_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setElevation.(F)V", this, ptr);
		}
	}

	public abstract int Height
	{
		[Register("getHeight", "()I", "GetGetHeightHandler")]
		get;
	}

	public unsafe virtual int HideOffset
	{
		[Register("getHideOffset", "()I", "GetGetHideOffsetHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getHideOffset.()I", this, null);
		}
		[Register("setHideOffset", "(I)V", "GetSetHideOffset_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHideOffset.(I)V", this, ptr);
		}
	}

	public unsafe virtual bool HideOnContentScrollEnabled
	{
		[Register("isHideOnContentScrollEnabled", "()Z", "GetIsHideOnContentScrollEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isHideOnContentScrollEnabled.()Z", this, null);
		}
		[Register("setHideOnContentScrollEnabled", "(Z)V", "GetSetHideOnContentScrollEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHideOnContentScrollEnabled.(Z)V", this, ptr);
		}
	}

	public abstract bool IsShowing
	{
		[Register("isShowing", "()Z", "GetIsShowingHandler")]
		get;
	}

	public unsafe virtual bool IsTitleTruncated
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("isTitleTruncated", "()Z", "GetIsTitleTruncatedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isTitleTruncated.()Z", this, null);
		}
	}

	public abstract int NavigationItemCount
	{
		[Register("getNavigationItemCount", "()I", "GetGetNavigationItemCountHandler")]
		get;
	}

	public abstract int NavigationMode
	{
		[Register("getNavigationMode", "()I", "GetGetNavigationModeHandler")]
		get;
		[Register("setNavigationMode", "(I)V", "GetSetNavigationMode_IHandler")]
		set;
	}

	public abstract int SelectedNavigationIndex
	{
		[Register("getSelectedNavigationIndex", "()I", "GetGetSelectedNavigationIndexHandler")]
		get;
	}

	public abstract Tab? SelectedTab
	{
		[Register("getSelectedTab", "()Landroidx/appcompat/app/ActionBar$Tab;", "GetGetSelectedTabHandler")]
		get;
	}

	public abstract ICharSequence? SubtitleFormatted
	{
		[Register("getSubtitle", "()Ljava/lang/CharSequence;", "GetGetSubtitleHandler")]
		get;
		[Register("setSubtitle", "(Ljava/lang/CharSequence;)V", "GetSetSubtitle_Ljava_lang_CharSequence_Handler")]
		set;
	}

	public unsafe string? Subtitle
	{
		get
		{
			if (SubtitleFormatted != null)
			{
				return SubtitleFormatted.ToString();
			}
			return null;
		}
		set
		{
			JniObjectReference reference = JniEnvironment.Strings.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(reference);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setSubtitle.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JniObjectReference.Dispose(ref reference);
			}
		}
	}

	public abstract int TabCount
	{
		[Register("getTabCount", "()I", "GetGetTabCountHandler")]
		get;
	}

	public unsafe virtual Context? ThemedContext
	{
		[Register("getThemedContext", "()Landroid/content/Context;", "GetGetThemedContextHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeVirtualObjectMethod("getThemedContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public abstract ICharSequence? TitleFormatted
	{
		[Register("getTitle", "()Ljava/lang/CharSequence;", "GetGetTitleHandler")]
		get;
		[Register("setTitle", "(Ljava/lang/CharSequence;)V", "GetSetTitle_Ljava_lang_CharSequence_Handler")]
		set;
	}

	public unsafe string? Title
	{
		get
		{
			if (TitleFormatted != null)
			{
				return TitleFormatted.ToString();
			}
			return null;
		}
		set
		{
			JniObjectReference reference = JniEnvironment.Strings.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(reference);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setTitle.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JniObjectReference.Dispose(ref reference);
			}
		}
	}

	public event EventHandler<MenuVisibilityEventArgs> MenuVisibility
	{
		add
		{
			EventHelper.AddEventHandler<IOnMenuVisibilityListener, IOnMenuVisibilityListenerImplementor>(ref weak_implementor_AddOnMenuVisibilityListener, __CreateIOnMenuVisibilityListenerImplementor, AddOnMenuVisibilityListener, delegate(IOnMenuVisibilityListenerImplementor __h)
			{
				__h.Handler = (EventHandler<MenuVisibilityEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnMenuVisibilityListener, IOnMenuVisibilityListenerImplementor.__IsEmpty, delegate(IOnMenuVisibilityListener __v)
			{
				RemoveOnMenuVisibilityListener(__v);
			}, delegate(IOnMenuVisibilityListenerImplementor __h)
			{
				__h.Handler = (EventHandler<MenuVisibilityEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	protected ActionBar(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ActionBar()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetCustomViewHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCustomView);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCustomView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CustomView);
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

	private static Delegate GetSetCustomView_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetCustomView_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCustomView_Landroid_view_View_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View customView = Java.Lang.Object.GetObject<Android.Views.View>(native_p0, JniHandleOwnership.DoNotTransfer);
			actionBar.CustomView = customView;
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

	private static Delegate GetGetDisplayOptionsHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetDisplayOptions);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetDisplayOptions(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DisplayOptions;
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

	private static Delegate GetSetDisplayOptions_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetDisplayOptions_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDisplayOptions_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DisplayOptions = p0;
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

	private static Delegate GetGetElevationHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetElevation);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetElevation(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Elevation;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetElevation_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetElevation_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetElevation_F(nint jnienv, nint native__this, float elevation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Elevation = elevation;
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

	private static Delegate GetGetHeightHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetHeight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetHeight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Height;
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

	private static Delegate GetGetHideOffsetHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetHideOffset);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetHideOffset(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HideOffset;
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

	private static Delegate GetSetHideOffset_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetHideOffset_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHideOffset_I(nint jnienv, nint native__this, int offset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HideOffset = offset;
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

	private static Delegate GetIsHideOnContentScrollEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsHideOnContentScrollEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsHideOnContentScrollEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HideOnContentScrollEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetHideOnContentScrollEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetHideOnContentScrollEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHideOnContentScrollEnabled_Z(nint jnienv, nint native__this, sbyte native_hideOnContentScroll)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool hideOnContentScrollEnabled = native_hideOnContentScroll != 0;
			actionBar.HideOnContentScrollEnabled = hideOnContentScrollEnabled;
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

	private static Delegate GetIsShowingHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsShowing);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsShowing(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsShowing ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsTitleTruncatedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsTitleTruncated);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsTitleTruncated(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsTitleTruncated ? ((sbyte)1) : ((sbyte)0);
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
	private static Delegate GetGetNavigationItemCountHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetNavigationItemCount);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetNavigationItemCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NavigationItemCount;
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
	private static Delegate GetGetNavigationModeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetNavigationMode);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetNavigationMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NavigationMode;
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
	private static Delegate GetSetNavigationMode_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetNavigationMode_I);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetNavigationMode_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NavigationMode = p0;
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
	private static Delegate GetGetSelectedNavigationIndexHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetSelectedNavigationIndex);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSelectedNavigationIndex(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SelectedNavigationIndex;
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
	private static Delegate GetGetSelectedTabHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSelectedTab);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSelectedTab(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SelectedTab);
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

	private static Delegate GetGetSubtitleHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSubtitle);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSubtitle(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SubtitleFormatted);
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

	private static Delegate GetSetSubtitle_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetSubtitle_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSubtitle_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence subtitleFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_p0, JniHandleOwnership.DoNotTransfer);
			actionBar.SubtitleFormatted = subtitleFormatted;
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
	private static Delegate GetGetTabCountHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetTabCount);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTabCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TabCount;
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

	private static Delegate GetGetThemedContextHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetThemedContext);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetThemedContext(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ThemedContext);
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

	private static Delegate GetGetTitleHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTitle);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTitle(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TitleFormatted);
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

	private static Delegate GetSetTitle_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTitle_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTitle_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence titleFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_p0, JniHandleOwnership.DoNotTransfer);
			actionBar.TitleFormatted = titleFormatted;
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

	private static Delegate GetAddOnMenuVisibilityListener_Landroidx_appcompat_app_ActionBar_OnMenuVisibilityListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddOnMenuVisibilityListener_Landroidx_appcompat_app_ActionBar_OnMenuVisibilityListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddOnMenuVisibilityListener_Landroidx_appcompat_app_ActionBar_OnMenuVisibilityListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnMenuVisibilityListener listener = Java.Lang.Object.GetObject<IOnMenuVisibilityListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			actionBar.AddOnMenuVisibilityListener(listener);
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

	[Register("addOnMenuVisibilityListener", "(Landroidx/appcompat/app/ActionBar$OnMenuVisibilityListener;)V", "GetAddOnMenuVisibilityListener_Landroidx_appcompat_app_ActionBar_OnMenuVisibilityListener_Handler")]
	public abstract void AddOnMenuVisibilityListener(IOnMenuVisibilityListener? listener);

	[Obsolete]
	private static Delegate GetAddTab_Landroidx_appcompat_app_ActionBar_Tab_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddTab_Landroidx_appcompat_app_ActionBar_Tab_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddTab_Landroidx_appcompat_app_ActionBar_Tab_(nint jnienv, nint native__this, nint native_tab)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Tab tab = Java.Lang.Object.GetObject<Tab>(native_tab, JniHandleOwnership.DoNotTransfer);
			actionBar.AddTab(tab);
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
	[Register("addTab", "(Landroidx/appcompat/app/ActionBar$Tab;)V", "GetAddTab_Landroidx_appcompat_app_ActionBar_Tab_Handler")]
	public abstract void AddTab(Tab? tab);

	[Obsolete]
	private static Delegate GetAddTab_Landroidx_appcompat_app_ActionBar_Tab_ZHandler()
	{
		return new global::_JniMarshal_PPLB_V(n_AddTab_Landroidx_appcompat_app_ActionBar_Tab_Z);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddTab_Landroidx_appcompat_app_ActionBar_Tab_Z(nint jnienv, nint native__this, nint native_tab, sbyte native_setSelected)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Tab tab = Java.Lang.Object.GetObject<Tab>(native_tab, JniHandleOwnership.DoNotTransfer);
			bool setSelected = native_setSelected != 0;
			actionBar.AddTab(tab, setSelected);
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
	[Register("addTab", "(Landroidx/appcompat/app/ActionBar$Tab;Z)V", "GetAddTab_Landroidx_appcompat_app_ActionBar_Tab_ZHandler")]
	public abstract void AddTab(Tab? tab, bool setSelected);

	[Obsolete]
	private static Delegate GetAddTab_Landroidx_appcompat_app_ActionBar_Tab_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_AddTab_Landroidx_appcompat_app_ActionBar_Tab_I);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddTab_Landroidx_appcompat_app_ActionBar_Tab_I(nint jnienv, nint native__this, nint native_tab, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Tab tab = Java.Lang.Object.GetObject<Tab>(native_tab, JniHandleOwnership.DoNotTransfer);
			actionBar.AddTab(tab, position);
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
	[Register("addTab", "(Landroidx/appcompat/app/ActionBar$Tab;I)V", "GetAddTab_Landroidx_appcompat_app_ActionBar_Tab_IHandler")]
	public abstract void AddTab(Tab? tab, int position);

	[Obsolete]
	private static Delegate GetAddTab_Landroidx_appcompat_app_ActionBar_Tab_IZHandler()
	{
		return new global::_JniMarshal_PPLIB_V(n_AddTab_Landroidx_appcompat_app_ActionBar_Tab_IZ);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddTab_Landroidx_appcompat_app_ActionBar_Tab_IZ(nint jnienv, nint native__this, nint native_tab, int position, sbyte native_setSelected)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Tab tab = Java.Lang.Object.GetObject<Tab>(native_tab, JniHandleOwnership.DoNotTransfer);
			bool setSelected = native_setSelected != 0;
			actionBar.AddTab(tab, position, setSelected);
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
	[Register("addTab", "(Landroidx/appcompat/app/ActionBar$Tab;IZ)V", "GetAddTab_Landroidx_appcompat_app_ActionBar_Tab_IZHandler")]
	public abstract void AddTab(Tab? tab, int position, bool setSelected);

	private static Delegate GetCloseOptionsMenuHandler()
	{
		return new global::_JniMarshal_PP_B(n_CloseOptionsMenu);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_CloseOptionsMenu(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CloseOptionsMenu() ? ((sbyte)1) : ((sbyte)0);
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

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("closeOptionsMenu", "()Z", "GetCloseOptionsMenuHandler")]
	public unsafe virtual bool CloseOptionsMenu()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("closeOptionsMenu.()Z", this, null);
	}

	private static Delegate GetCollapseActionViewHandler()
	{
		return new global::_JniMarshal_PP_B(n_CollapseActionView);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_CollapseActionView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CollapseActionView() ? ((sbyte)1) : ((sbyte)0);
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

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("collapseActionView", "()Z", "GetCollapseActionViewHandler")]
	public unsafe virtual bool CollapseActionView()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("collapseActionView.()Z", this, null);
	}

	private static Delegate GetDispatchMenuVisibilityChanged_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_DispatchMenuVisibilityChanged_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DispatchMenuVisibilityChanged_Z(nint jnienv, nint native__this, sbyte native_visible)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool visible = native_visible != 0;
			actionBar.DispatchMenuVisibilityChanged(visible);
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
	[Register("dispatchMenuVisibilityChanged", "(Z)V", "GetDispatchMenuVisibilityChanged_ZHandler")]
	public unsafe virtual void DispatchMenuVisibilityChanged(bool visible)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(visible ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("dispatchMenuVisibilityChanged.(Z)V", this, ptr);
	}

	[Obsolete]
	private static Delegate GetGetTabAt_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetTabAt_I);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTabAt_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetTabAt(index));
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
	[Register("getTabAt", "(I)Landroidx/appcompat/app/ActionBar$Tab;", "GetGetTabAt_IHandler")]
	public abstract Tab? GetTabAt(int index);

	private static Delegate GetHideHandler()
	{
		return new global::_JniMarshal_PP_V(n_Hide);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Hide(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Hide();
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

	[Register("hide", "()V", "GetHideHandler")]
	public abstract void Hide();

	private static Delegate GetInvalidateOptionsMenuHandler()
	{
		return new global::_JniMarshal_PP_B(n_InvalidateOptionsMenu);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_InvalidateOptionsMenu(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InvalidateOptionsMenu() ? ((sbyte)1) : ((sbyte)0);
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

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("invalidateOptionsMenu", "()Z", "GetInvalidateOptionsMenuHandler")]
	public unsafe virtual bool InvalidateOptionsMenu()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("invalidateOptionsMenu.()Z", this, null);
	}

	[Obsolete]
	private static Delegate GetNewTabHandler()
	{
		return new global::_JniMarshal_PP_L(n_NewTab);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_NewTab(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NewTab());
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
	[Register("newTab", "()Landroidx/appcompat/app/ActionBar$Tab;", "GetNewTabHandler")]
	public abstract Tab? NewTab();

	private static Delegate GetOnConfigurationChanged_Landroid_content_res_Configuration_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnConfigurationChanged_Landroid_content_res_Configuration_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnConfigurationChanged_Landroid_content_res_Configuration_(nint jnienv, nint native__this, nint native_config)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Configuration config = Java.Lang.Object.GetObject<Configuration>(native_config, JniHandleOwnership.DoNotTransfer);
			actionBar.OnConfigurationChanged(config);
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
	[Register("onConfigurationChanged", "(Landroid/content/res/Configuration;)V", "GetOnConfigurationChanged_Landroid_content_res_Configuration_Handler")]
	public unsafe virtual void OnConfigurationChanged(Configuration? config)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(config?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onConfigurationChanged.(Landroid/content/res/Configuration;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(config);
		}
	}

	private static Delegate GetOnKeyShortcut_ILandroid_view_KeyEvent_Handler()
	{
		return new global::_JniMarshal_PPIL_B(n_OnKeyShortcut_ILandroid_view_KeyEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnKeyShortcut_ILandroid_view_KeyEvent_(nint jnienv, nint native__this, int keyCode, nint native_ev)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			KeyEvent ev = Java.Lang.Object.GetObject<KeyEvent>(native_ev, JniHandleOwnership.DoNotTransfer);
			return actionBar.OnKeyShortcut(keyCode, ev) ? ((sbyte)1) : ((sbyte)0);
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

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("onKeyShortcut", "(ILandroid/view/KeyEvent;)Z", "GetOnKeyShortcut_ILandroid_view_KeyEvent_Handler")]
	public unsafe virtual bool OnKeyShortcut(int keyCode, KeyEvent? ev)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(keyCode);
			ptr[1] = new JniArgumentValue(ev?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onKeyShortcut.(ILandroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(ev);
		}
	}

	private static Delegate GetOnMenuKeyEvent_Landroid_view_KeyEvent_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_OnMenuKeyEvent_Landroid_view_KeyEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnMenuKeyEvent_Landroid_view_KeyEvent_(nint jnienv, nint native__this, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return actionBar.OnMenuKeyEvent(e) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("onMenuKeyEvent", "(Landroid/view/KeyEvent;)Z", "GetOnMenuKeyEvent_Landroid_view_KeyEvent_Handler")]
	public unsafe virtual bool OnMenuKeyEvent(KeyEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onMenuKeyEvent.(Landroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetOpenOptionsMenuHandler()
	{
		return new global::_JniMarshal_PP_B(n_OpenOptionsMenu);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OpenOptionsMenu(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OpenOptionsMenu() ? ((sbyte)1) : ((sbyte)0);
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

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("openOptionsMenu", "()Z", "GetOpenOptionsMenuHandler")]
	public unsafe virtual bool OpenOptionsMenu()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("openOptionsMenu.()Z", this, null);
	}

	[Obsolete]
	private static Delegate GetRemoveAllTabsHandler()
	{
		return new global::_JniMarshal_PP_V(n_RemoveAllTabs);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveAllTabs(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveAllTabs();
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
	[Register("removeAllTabs", "()V", "GetRemoveAllTabsHandler")]
	public abstract void RemoveAllTabs();

	private static Delegate GetRemoveOnMenuVisibilityListener_Landroidx_appcompat_app_ActionBar_OnMenuVisibilityListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveOnMenuVisibilityListener_Landroidx_appcompat_app_ActionBar_OnMenuVisibilityListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveOnMenuVisibilityListener_Landroidx_appcompat_app_ActionBar_OnMenuVisibilityListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnMenuVisibilityListener listener = Java.Lang.Object.GetObject<IOnMenuVisibilityListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			actionBar.RemoveOnMenuVisibilityListener(listener);
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

	[Register("removeOnMenuVisibilityListener", "(Landroidx/appcompat/app/ActionBar$OnMenuVisibilityListener;)V", "GetRemoveOnMenuVisibilityListener_Landroidx_appcompat_app_ActionBar_OnMenuVisibilityListener_Handler")]
	public abstract void RemoveOnMenuVisibilityListener(IOnMenuVisibilityListener? listener);

	[Obsolete]
	private static Delegate GetRemoveTab_Landroidx_appcompat_app_ActionBar_Tab_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveTab_Landroidx_appcompat_app_ActionBar_Tab_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveTab_Landroidx_appcompat_app_ActionBar_Tab_(nint jnienv, nint native__this, nint native_tab)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Tab tab = Java.Lang.Object.GetObject<Tab>(native_tab, JniHandleOwnership.DoNotTransfer);
			actionBar.RemoveTab(tab);
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
	[Register("removeTab", "(Landroidx/appcompat/app/ActionBar$Tab;)V", "GetRemoveTab_Landroidx_appcompat_app_ActionBar_Tab_Handler")]
	public abstract void RemoveTab(Tab? tab);

	[Obsolete]
	private static Delegate GetRemoveTabAt_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_RemoveTabAt_I);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveTabAt_I(nint jnienv, nint native__this, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveTabAt(position);
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
	[Register("removeTabAt", "(I)V", "GetRemoveTabAt_IHandler")]
	public abstract void RemoveTabAt(int position);

	[Obsolete]
	private static Delegate GetSelectTab_Landroidx_appcompat_app_ActionBar_Tab_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SelectTab_Landroidx_appcompat_app_ActionBar_Tab_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SelectTab_Landroidx_appcompat_app_ActionBar_Tab_(nint jnienv, nint native__this, nint native_tab)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Tab tab = Java.Lang.Object.GetObject<Tab>(native_tab, JniHandleOwnership.DoNotTransfer);
			actionBar.SelectTab(tab);
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
	[Register("selectTab", "(Landroidx/appcompat/app/ActionBar$Tab;)V", "GetSelectTab_Landroidx_appcompat_app_ActionBar_Tab_Handler")]
	public abstract void SelectTab(Tab? tab);

	private static Delegate GetSetBackgroundDrawable_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetBackgroundDrawable_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBackgroundDrawable_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_d)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable backgroundDrawable = Java.Lang.Object.GetObject<Drawable>(native_d, JniHandleOwnership.DoNotTransfer);
			actionBar.SetBackgroundDrawable(backgroundDrawable);
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

	[Register("setBackgroundDrawable", "(Landroid/graphics/drawable/Drawable;)V", "GetSetBackgroundDrawable_Landroid_graphics_drawable_Drawable_Handler")]
	public abstract void SetBackgroundDrawable(Drawable? d);

	private static Delegate GetSetCustomView_Landroid_view_View_Landroidx_appcompat_app_ActionBar_LayoutParams_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_SetCustomView_Landroid_view_View_Landroidx_appcompat_app_ActionBar_LayoutParams_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCustomView_Landroid_view_View_Landroidx_appcompat_app_ActionBar_LayoutParams_(nint jnienv, nint native__this, nint native_view, nint native_layoutParams)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View view = Java.Lang.Object.GetObject<Android.Views.View>(native_view, JniHandleOwnership.DoNotTransfer);
			LayoutParams layoutParams = Java.Lang.Object.GetObject<LayoutParams>(native_layoutParams, JniHandleOwnership.DoNotTransfer);
			actionBar.SetCustomView(view, layoutParams);
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

	[Register("setCustomView", "(Landroid/view/View;Landroidx/appcompat/app/ActionBar$LayoutParams;)V", "GetSetCustomView_Landroid_view_View_Landroidx_appcompat_app_ActionBar_LayoutParams_Handler")]
	public abstract void SetCustomView(Android.Views.View? view, LayoutParams? layoutParams);

	private static Delegate GetSetCustomView_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetCustomView_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCustomView_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCustomView(resId);
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

	[Register("setCustomView", "(I)V", "GetSetCustomView_IHandler")]
	public abstract void SetCustomView(int resId);

	private static Delegate GetSetDefaultDisplayHomeAsUpEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetDefaultDisplayHomeAsUpEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDefaultDisplayHomeAsUpEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool defaultDisplayHomeAsUpEnabled = native_enabled != 0;
			actionBar.SetDefaultDisplayHomeAsUpEnabled(defaultDisplayHomeAsUpEnabled);
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
	[Register("setDefaultDisplayHomeAsUpEnabled", "(Z)V", "GetSetDefaultDisplayHomeAsUpEnabled_ZHandler")]
	public unsafe virtual void SetDefaultDisplayHomeAsUpEnabled(bool enabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enabled ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setDefaultDisplayHomeAsUpEnabled.(Z)V", this, ptr);
	}

	private static Delegate GetSetDisplayHomeAsUpEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetDisplayHomeAsUpEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDisplayHomeAsUpEnabled_Z(nint jnienv, nint native__this, sbyte native_showHomeAsUp)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool displayHomeAsUpEnabled = native_showHomeAsUp != 0;
			actionBar.SetDisplayHomeAsUpEnabled(displayHomeAsUpEnabled);
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

	[Register("setDisplayHomeAsUpEnabled", "(Z)V", "GetSetDisplayHomeAsUpEnabled_ZHandler")]
	public abstract void SetDisplayHomeAsUpEnabled(bool showHomeAsUp);

	private static Delegate GetSetDisplayOptions_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetDisplayOptions_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDisplayOptions_II(nint jnienv, nint native__this, int options, int mask)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDisplayOptions(options, mask);
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

	[Register("setDisplayOptions", "(II)V", "GetSetDisplayOptions_IIHandler")]
	public abstract void SetDisplayOptions(int options, int mask);

	private static Delegate GetSetDisplayShowCustomEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetDisplayShowCustomEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDisplayShowCustomEnabled_Z(nint jnienv, nint native__this, sbyte native_showCustom)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool displayShowCustomEnabled = native_showCustom != 0;
			actionBar.SetDisplayShowCustomEnabled(displayShowCustomEnabled);
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

	[Register("setDisplayShowCustomEnabled", "(Z)V", "GetSetDisplayShowCustomEnabled_ZHandler")]
	public abstract void SetDisplayShowCustomEnabled(bool showCustom);

	private static Delegate GetSetDisplayShowHomeEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetDisplayShowHomeEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDisplayShowHomeEnabled_Z(nint jnienv, nint native__this, sbyte native_showHome)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool displayShowHomeEnabled = native_showHome != 0;
			actionBar.SetDisplayShowHomeEnabled(displayShowHomeEnabled);
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

	[Register("setDisplayShowHomeEnabled", "(Z)V", "GetSetDisplayShowHomeEnabled_ZHandler")]
	public abstract void SetDisplayShowHomeEnabled(bool showHome);

	private static Delegate GetSetDisplayShowTitleEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetDisplayShowTitleEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDisplayShowTitleEnabled_Z(nint jnienv, nint native__this, sbyte native_showTitle)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool displayShowTitleEnabled = native_showTitle != 0;
			actionBar.SetDisplayShowTitleEnabled(displayShowTitleEnabled);
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

	[Register("setDisplayShowTitleEnabled", "(Z)V", "GetSetDisplayShowTitleEnabled_ZHandler")]
	public abstract void SetDisplayShowTitleEnabled(bool showTitle);

	private static Delegate GetSetDisplayUseLogoEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetDisplayUseLogoEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDisplayUseLogoEnabled_Z(nint jnienv, nint native__this, sbyte native_useLogo)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool displayUseLogoEnabled = native_useLogo != 0;
			actionBar.SetDisplayUseLogoEnabled(displayUseLogoEnabled);
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

	[Register("setDisplayUseLogoEnabled", "(Z)V", "GetSetDisplayUseLogoEnabled_ZHandler")]
	public abstract void SetDisplayUseLogoEnabled(bool useLogo);

	private static Delegate GetSetHomeActionContentDescription_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetHomeActionContentDescription_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHomeActionContentDescription_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHomeActionContentDescription(resId);
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

	[Register("setHomeActionContentDescription", "(I)V", "GetSetHomeActionContentDescription_IHandler")]
	public unsafe virtual void SetHomeActionContentDescription(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setHomeActionContentDescription.(I)V", this, ptr);
	}

	private static Delegate GetSetHomeActionContentDescription_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetHomeActionContentDescription_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHomeActionContentDescription_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_description)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence homeActionContentDescription = Java.Lang.Object.GetObject<ICharSequence>(native_description, JniHandleOwnership.DoNotTransfer);
			actionBar.SetHomeActionContentDescription(homeActionContentDescription);
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

	[Register("setHomeActionContentDescription", "(Ljava/lang/CharSequence;)V", "GetSetHomeActionContentDescription_Ljava_lang_CharSequence_Handler")]
	public unsafe virtual void SetHomeActionContentDescription(ICharSequence? description)
	{
		nint num = CharSequence.ToLocalJniHandle(description);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHomeActionContentDescription.(Ljava/lang/CharSequence;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(description);
		}
	}

	public void SetHomeActionContentDescription(string? description)
	{
		Java.Lang.String obj = ((description == null) ? null : new Java.Lang.String(description));
		SetHomeActionContentDescription(obj);
		obj?.Dispose();
	}

	private static Delegate GetSetHomeAsUpIndicator_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetHomeAsUpIndicator_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHomeAsUpIndicator_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_indicator)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable homeAsUpIndicator = Java.Lang.Object.GetObject<Drawable>(native_indicator, JniHandleOwnership.DoNotTransfer);
			actionBar.SetHomeAsUpIndicator(homeAsUpIndicator);
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

	[Register("setHomeAsUpIndicator", "(Landroid/graphics/drawable/Drawable;)V", "GetSetHomeAsUpIndicator_Landroid_graphics_drawable_Drawable_Handler")]
	public unsafe virtual void SetHomeAsUpIndicator(Drawable? indicator)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(indicator?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHomeAsUpIndicator.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(indicator);
		}
	}

	private static Delegate GetSetHomeAsUpIndicator_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetHomeAsUpIndicator_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHomeAsUpIndicator_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHomeAsUpIndicator(resId);
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

	[Register("setHomeAsUpIndicator", "(I)V", "GetSetHomeAsUpIndicator_IHandler")]
	public unsafe virtual void SetHomeAsUpIndicator(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setHomeAsUpIndicator.(I)V", this, ptr);
	}

	private static Delegate GetSetHomeButtonEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetHomeButtonEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHomeButtonEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool homeButtonEnabled = native_enabled != 0;
			actionBar.SetHomeButtonEnabled(homeButtonEnabled);
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

	[Register("setHomeButtonEnabled", "(Z)V", "GetSetHomeButtonEnabled_ZHandler")]
	public unsafe virtual void SetHomeButtonEnabled(bool enabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enabled ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setHomeButtonEnabled.(Z)V", this, ptr);
	}

	private static Delegate GetSetIcon_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetIcon_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetIcon_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_icon)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable icon = Java.Lang.Object.GetObject<Drawable>(native_icon, JniHandleOwnership.DoNotTransfer);
			actionBar.SetIcon(icon);
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

	[Register("setIcon", "(Landroid/graphics/drawable/Drawable;)V", "GetSetIcon_Landroid_graphics_drawable_Drawable_Handler")]
	public abstract void SetIcon(Drawable? icon);

	private static Delegate GetSetIcon_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetIcon_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetIcon_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetIcon(resId);
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

	[Register("setIcon", "(I)V", "GetSetIcon_IHandler")]
	public abstract void SetIcon(int resId);

	[Obsolete]
	private static Delegate GetSetListNavigationCallbacks_Landroid_widget_SpinnerAdapter_Landroidx_appcompat_app_ActionBar_OnNavigationListener_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_SetListNavigationCallbacks_Landroid_widget_SpinnerAdapter_Landroidx_appcompat_app_ActionBar_OnNavigationListener_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetListNavigationCallbacks_Landroid_widget_SpinnerAdapter_Landroidx_appcompat_app_ActionBar_OnNavigationListener_(nint jnienv, nint native__this, nint native_adapter, nint native_callback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ISpinnerAdapter adapter = Java.Lang.Object.GetObject<ISpinnerAdapter>(native_adapter, JniHandleOwnership.DoNotTransfer);
			IOnNavigationListener callback_ = Java.Lang.Object.GetObject<IOnNavigationListener>(native_callback, JniHandleOwnership.DoNotTransfer);
			actionBar.SetListNavigationCallbacks(adapter, callback_);
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
	[Register("setListNavigationCallbacks", "(Landroid/widget/SpinnerAdapter;Landroidx/appcompat/app/ActionBar$OnNavigationListener;)V", "GetSetListNavigationCallbacks_Landroid_widget_SpinnerAdapter_Landroidx_appcompat_app_ActionBar_OnNavigationListener_Handler")]
	public abstract void SetListNavigationCallbacks(ISpinnerAdapter? adapter, IOnNavigationListener? callback_);

	private static Delegate GetSetLogo_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetLogo_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLogo_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_logo)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable logo = Java.Lang.Object.GetObject<Drawable>(native_logo, JniHandleOwnership.DoNotTransfer);
			actionBar.SetLogo(logo);
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

	[Register("setLogo", "(Landroid/graphics/drawable/Drawable;)V", "GetSetLogo_Landroid_graphics_drawable_Drawable_Handler")]
	public abstract void SetLogo(Drawable? logo);

	private static Delegate GetSetLogo_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetLogo_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLogo_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetLogo(resId);
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

	[Register("setLogo", "(I)V", "GetSetLogo_IHandler")]
	public abstract void SetLogo(int resId);

	[Obsolete]
	private static Delegate GetSetSelectedNavigationItem_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetSelectedNavigationItem_I);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSelectedNavigationItem_I(nint jnienv, nint native__this, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSelectedNavigationItem(position);
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
	[Register("setSelectedNavigationItem", "(I)V", "GetSetSelectedNavigationItem_IHandler")]
	public abstract void SetSelectedNavigationItem(int position);

	private static Delegate GetSetShowHideAnimationEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetShowHideAnimationEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetShowHideAnimationEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool showHideAnimationEnabled = native_enabled != 0;
			actionBar.SetShowHideAnimationEnabled(showHideAnimationEnabled);
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
	[Register("setShowHideAnimationEnabled", "(Z)V", "GetSetShowHideAnimationEnabled_ZHandler")]
	public unsafe virtual void SetShowHideAnimationEnabled(bool enabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enabled ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setShowHideAnimationEnabled.(Z)V", this, ptr);
	}

	private static Delegate GetSetSplitBackgroundDrawable_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetSplitBackgroundDrawable_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSplitBackgroundDrawable_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_d)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable splitBackgroundDrawable = Java.Lang.Object.GetObject<Drawable>(native_d, JniHandleOwnership.DoNotTransfer);
			actionBar.SetSplitBackgroundDrawable(splitBackgroundDrawable);
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

	[Register("setSplitBackgroundDrawable", "(Landroid/graphics/drawable/Drawable;)V", "GetSetSplitBackgroundDrawable_Landroid_graphics_drawable_Drawable_Handler")]
	public unsafe virtual void SetSplitBackgroundDrawable(Drawable? d)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(d?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSplitBackgroundDrawable.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(d);
		}
	}

	private static Delegate GetSetStackedBackgroundDrawable_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetStackedBackgroundDrawable_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStackedBackgroundDrawable_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_d)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable stackedBackgroundDrawable = Java.Lang.Object.GetObject<Drawable>(native_d, JniHandleOwnership.DoNotTransfer);
			actionBar.SetStackedBackgroundDrawable(stackedBackgroundDrawable);
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

	[Register("setStackedBackgroundDrawable", "(Landroid/graphics/drawable/Drawable;)V", "GetSetStackedBackgroundDrawable_Landroid_graphics_drawable_Drawable_Handler")]
	public unsafe virtual void SetStackedBackgroundDrawable(Drawable? d)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(d?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStackedBackgroundDrawable.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(d);
		}
	}

	private static Delegate GetSetSubtitle_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetSubtitle_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSubtitle_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSubtitle(resId);
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

	[Register("setSubtitle", "(I)V", "GetSetSubtitle_IHandler")]
	public abstract void SetSubtitle(int resId);

	private static Delegate GetSetTitle_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetTitle_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTitle_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTitle(resId);
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

	[Register("setTitle", "(I)V", "GetSetTitle_IHandler")]
	public abstract void SetTitle(int resId);

	private static Delegate GetSetWindowTitle_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetWindowTitle_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetWindowTitle_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_title)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence windowTitle = Java.Lang.Object.GetObject<ICharSequence>(native_title, JniHandleOwnership.DoNotTransfer);
			actionBar.SetWindowTitle(windowTitle);
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
	[Register("setWindowTitle", "(Ljava/lang/CharSequence;)V", "GetSetWindowTitle_Ljava_lang_CharSequence_Handler")]
	public unsafe virtual void SetWindowTitle(ICharSequence? title)
	{
		nint num = CharSequence.ToLocalJniHandle(title);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setWindowTitle.(Ljava/lang/CharSequence;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(title);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	public void SetWindowTitle(string? title)
	{
		Java.Lang.String obj = ((title == null) ? null : new Java.Lang.String(title));
		SetWindowTitle(obj);
		obj?.Dispose();
	}

	private static Delegate GetShowHandler()
	{
		return new global::_JniMarshal_PP_V(n_Show);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Show(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Show();
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

	[Register("show", "()V", "GetShowHandler")]
	public abstract void Show();

	private static Delegate GetStartActionMode_Landroidx_appcompat_view_ActionMode_Callback_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_StartActionMode_Landroidx_appcompat_view_ActionMode_Callback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_StartActionMode_Landroidx_appcompat_view_ActionMode_Callback_(nint jnienv, nint native__this, nint native__callback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ActionBar? actionBar = Java.Lang.Object.GetObject<ActionBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AndroidX.AppCompat.View.ActionMode.ICallback callback = Java.Lang.Object.GetObject<AndroidX.AppCompat.View.ActionMode.ICallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(actionBar.StartActionMode(callback));
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

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("startActionMode", "(Landroidx/appcompat/view/ActionMode$Callback;)Landroidx/appcompat/view/ActionMode;", "GetStartActionMode_Landroidx_appcompat_view_ActionMode_Callback_Handler")]
	public unsafe virtual AndroidX.AppCompat.View.ActionMode? StartActionMode(AndroidX.AppCompat.View.ActionMode.ICallback? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<AndroidX.AppCompat.View.ActionMode>(_members.InstanceMethods.InvokeVirtualObjectMethod("startActionMode.(Landroidx/appcompat/view/ActionMode$Callback;)Landroidx/appcompat/view/ActionMode;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	private IOnMenuVisibilityListenerImplementor __CreateIOnMenuVisibilityListenerImplementor()
	{
		return new IOnMenuVisibilityListenerImplementor(this);
	}
}
