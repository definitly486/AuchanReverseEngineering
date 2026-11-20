using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using AndroidX.CardView.Widget;
using Google.Android.Material.Shape;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.Card;

[Register("com/google/android/material/card/MaterialCardView", DoNotGenerateAcw = true)]
public class MaterialCardView : CardView, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("com/google/android/material/card/MaterialCardView$OnCheckedChangeListener", "", "Google.Android.Material.Card.MaterialCardView/IOnCheckedChangeListenerInvoker")]
	public interface IOnCheckedChangeListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onCheckedChanged", "(Lcom/google/android/material/card/MaterialCardView;Z)V", "GetOnCheckedChanged_Lcom_google_android_material_card_MaterialCardView_ZHandler:Google.Android.Material.Card.MaterialCardView/IOnCheckedChangeListenerInvoker, Xamarin.Google.Android.Material")]
		void OnCheckedChanged(MaterialCardView? p0, bool p1);
	}

	[Register("com/google/android/material/card/MaterialCardView$OnCheckedChangeListener", DoNotGenerateAcw = true)]
	internal class IOnCheckedChangeListenerInvoker : Java.Lang.Object, IOnCheckedChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_google_android_material_card_MaterialCardView_OnCheckedChangeListener = new XAPeerMembers("com/google/android/material/card/MaterialCardView$OnCheckedChangeListener", typeof(IOnCheckedChangeListenerInvoker));

		private static Delegate? cb_onCheckedChanged_OnCheckedChanged_Lcom_google_android_material_card_MaterialCardView_Z_V;

		private static nint java_class_ref => _members_com_google_android_material_card_MaterialCardView_OnCheckedChangeListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_google_android_material_card_MaterialCardView_OnCheckedChangeListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_google_android_material_card_MaterialCardView_OnCheckedChangeListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_google_android_material_card_MaterialCardView_OnCheckedChangeListener.ManagedPeerType;

		public IOnCheckedChangeListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnCheckedChanged_Lcom_google_android_material_card_MaterialCardView_Z(nint jnienv, nint native__this, nint native_p0, sbyte native_p1)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnCheckedChangeListener? onCheckedChangeListener = Java.Lang.Object.GetObject<IOnCheckedChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MaterialCardView p = Java.Lang.Object.GetObject<MaterialCardView>(native_p0, JniHandleOwnership.DoNotTransfer);
				bool p2 = native_p1 != 0;
				onCheckedChangeListener.OnCheckedChanged(p, p2);
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

		public unsafe void OnCheckedChanged(MaterialCardView? p0, bool p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1 ? ((sbyte)1) : ((sbyte)0));
				_members_com_google_android_material_card_MaterialCardView_OnCheckedChangeListener.InstanceMethods.InvokeAbstractVoidMethod("onCheckedChanged.(Lcom/google/android/material/card/MaterialCardView;Z)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
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
		private static void n_OnCheckedChanged_Lcom_google_android_material_card_MaterialCardView_Z_mm_wrapper(nint jnienv, nint native__this, nint native_p0, sbyte native_p1)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnCheckedChanged_Lcom_google_android_material_card_MaterialCardView_Z(jnienv, native__this, native_p0, native_p1);
			}
			catch (System.Exception e)
			{
				global::Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class CheckedChangeEventArgs : EventArgs
	{
		private MaterialCardView? p0;

		private bool p1;

		public CheckedChangeEventArgs(MaterialCardView? p0, bool p1)
		{
			this.p0 = p0;
			this.p1 = p1;
		}
	}

	[Register("mono/com/google/android/material/card/MaterialCardView_OnCheckedChangeListenerImplementor")]
	internal sealed class IOnCheckedChangeListenerImplementor : Java.Lang.Object, IOnCheckedChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<CheckedChangeEventArgs>? Handler;

		public unsafe IOnCheckedChangeListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnCheckedChanged(MaterialCardView? p0, bool p1)
		{
			Handler?.Invoke(sender, new CheckedChangeEventArgs(p0, p1));
		}

		internal static bool __IsEmpty(IOnCheckedChangeListenerImplementor value)
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/card/MaterialCardView", typeof(MaterialCardView));

	private static Delegate? cb_getCardForegroundColor_GetCardForegroundColor_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setCardForegroundColor_SetCardForegroundColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_isCheckable_IsCheckable_Z;

	private static Delegate? cb_setCheckable_SetCheckable_Z_V;

	private static Delegate? cb_isChecked_IsChecked_Z;

	private static Delegate? cb_setChecked_SetChecked_Z_V;

	private static Delegate? cb_getCheckedIcon_GetCheckedIcon_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_setCheckedIcon_SetCheckedIcon_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_getCheckedIconGravity_GetCheckedIconGravity_I;

	private static Delegate? cb_setCheckedIconGravity_SetCheckedIconGravity_I_V;

	private static Delegate? cb_getCheckedIconMargin_GetCheckedIconMargin_I;

	private static Delegate? cb_setCheckedIconMargin_SetCheckedIconMargin_I_V;

	private static Delegate? cb_getCheckedIconSize_GetCheckedIconSize_I;

	private static Delegate? cb_setCheckedIconSize_SetCheckedIconSize_I_V;

	private static Delegate? cb_getCheckedIconTint_GetCheckedIconTint_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setCheckedIconTint_SetCheckedIconTint_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_isDragged_IsDragged_Z;

	private static Delegate? cb_setDragged_SetDragged_Z_V;

	private static Delegate? cb_getProgress_GetProgress_F;

	private static Delegate? cb_setProgress_SetProgress_F_V;

	private static Delegate? cb_getRippleColor_GetRippleColor_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setRippleColor_SetRippleColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getShapeAppearanceModel_GetShapeAppearanceModel_Lcom_google_android_material_shape_ShapeAppearanceModel_;

	private static Delegate? cb_setShapeAppearanceModel_SetShapeAppearanceModel_Lcom_google_android_material_shape_ShapeAppearanceModel__V;

	private static Delegate? cb_getStrokeColor_GetStrokeColor_I;

	private static Delegate? cb_setStrokeColor_SetStrokeColor_I_V;

	private static Delegate? cb_getStrokeColorStateList_GetStrokeColorStateList_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_getStrokeWidth_GetStrokeWidth_I;

	private static Delegate? cb_setStrokeWidth_SetStrokeWidth_I_V;

	private static Delegate? cb_setCheckedIconMarginResource_SetCheckedIconMarginResource_I_V;

	private static Delegate? cb_setCheckedIconResource_SetCheckedIconResource_I_V;

	private static Delegate? cb_setCheckedIconSizeResource_SetCheckedIconSizeResource_I_V;

	private static Delegate? cb_setOnCheckedChangeListener_SetOnCheckedChangeListener_Lcom_google_android_material_card_MaterialCardView_OnCheckedChangeListener__V;

	private static Delegate? cb_setRippleColorResource_SetRippleColorResource_I_V;

	private static Delegate? cb_setStrokeColor_SetStrokeColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_toggle_Toggle_V;

	private WeakReference? weak_implementor_SetOnCheckedChangeListener;

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

	public unsafe virtual ColorStateList CardForegroundColor
	{
		[Register("getCardForegroundColor", "()Landroid/content/res/ColorStateList;", "GetGetCardForegroundColorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCardForegroundColor.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setCardForegroundColor", "(Landroid/content/res/ColorStateList;)V", "GetSetCardForegroundColor_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setCardForegroundColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual bool Checkable
	{
		[Register("isCheckable", "()Z", "GetIsCheckableHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isCheckable.()Z", this, null);
		}
		[Register("setCheckable", "(Z)V", "GetSetCheckable_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCheckable.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool Checked
	{
		[Register("isChecked", "()Z", "GetIsCheckedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isChecked.()Z", this, null);
		}
		[Register("setChecked", "(Z)V", "GetSetChecked_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setChecked.(Z)V", this, ptr);
		}
	}

	public unsafe virtual Drawable? CheckedIcon
	{
		[Register("getCheckedIcon", "()Landroid/graphics/drawable/Drawable;", "GetGetCheckedIconHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCheckedIcon.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setCheckedIcon", "(Landroid/graphics/drawable/Drawable;)V", "GetSetCheckedIcon_Landroid_graphics_drawable_Drawable_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setCheckedIcon.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int CheckedIconGravity
	{
		[Register("getCheckedIconGravity", "()I", "GetGetCheckedIconGravityHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getCheckedIconGravity.()I", this, null);
		}
		[Register("setCheckedIconGravity", "(I)V", "GetSetCheckedIconGravity_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCheckedIconGravity.(I)V", this, ptr);
		}
	}

	public unsafe virtual int CheckedIconMargin
	{
		[Register("getCheckedIconMargin", "()I", "GetGetCheckedIconMarginHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getCheckedIconMargin.()I", this, null);
		}
		[Register("setCheckedIconMargin", "(I)V", "GetSetCheckedIconMargin_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCheckedIconMargin.(I)V", this, ptr);
		}
	}

	public unsafe virtual int CheckedIconSize
	{
		[Register("getCheckedIconSize", "()I", "GetGetCheckedIconSizeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getCheckedIconSize.()I", this, null);
		}
		[Register("setCheckedIconSize", "(I)V", "GetSetCheckedIconSize_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCheckedIconSize.(I)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList? CheckedIconTint
	{
		[Register("getCheckedIconTint", "()Landroid/content/res/ColorStateList;", "GetGetCheckedIconTintHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCheckedIconTint.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setCheckedIconTint", "(Landroid/content/res/ColorStateList;)V", "GetSetCheckedIconTint_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setCheckedIconTint.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual bool Dragged
	{
		[Register("isDragged", "()Z", "GetIsDraggedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDragged.()Z", this, null);
		}
		[Register("setDragged", "(Z)V", "GetSetDragged_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDragged.(Z)V", this, ptr);
		}
	}

	public unsafe virtual float Progress
	{
		[Register("getProgress", "()F", "GetGetProgressHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getProgress.()F", this, null);
		}
		[Register("setProgress", "(F)V", "GetSetProgress_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setProgress.(F)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList? RippleColor
	{
		[Register("getRippleColor", "()Landroid/content/res/ColorStateList;", "GetGetRippleColorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRippleColor.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setRippleColor", "(Landroid/content/res/ColorStateList;)V", "GetSetRippleColor_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setRippleColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual ShapeAppearanceModel ShapeAppearanceModel
	{
		[Register("getShapeAppearanceModel", "()Lcom/google/android/material/shape/ShapeAppearanceModel;", "GetGetShapeAppearanceModelHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ShapeAppearanceModel>(_members.InstanceMethods.InvokeVirtualObjectMethod("getShapeAppearanceModel.()Lcom/google/android/material/shape/ShapeAppearanceModel;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setShapeAppearanceModel", "(Lcom/google/android/material/shape/ShapeAppearanceModel;)V", "GetSetShapeAppearanceModel_Lcom_google_android_material_shape_ShapeAppearanceModel_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setShapeAppearanceModel.(Lcom/google/android/material/shape/ShapeAppearanceModel;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int StrokeColor
	{
		[Obsolete("deprecated")]
		[Register("getStrokeColor", "()I", "GetGetStrokeColorHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getStrokeColor.()I", this, null);
		}
		[Register("setStrokeColor", "(I)V", "GetSetStrokeColor_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStrokeColor.(I)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList? StrokeColorStateList
	{
		[Register("getStrokeColorStateList", "()Landroid/content/res/ColorStateList;", "GetGetStrokeColorStateListHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getStrokeColorStateList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int StrokeWidth
	{
		[Register("getStrokeWidth", "()I", "GetGetStrokeWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getStrokeWidth.()I", this, null);
		}
		[Register("setStrokeWidth", "(I)V", "GetSetStrokeWidth_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStrokeWidth.(I)V", this, ptr);
		}
	}

	public event EventHandler<CheckedChangeEventArgs> CheckedChange
	{
		add
		{
			EventHelper.AddEventHandler<IOnCheckedChangeListener, IOnCheckedChangeListenerImplementor>(ref weak_implementor_SetOnCheckedChangeListener, __CreateIOnCheckedChangeListenerImplementor, SetOnCheckedChangeListener, delegate(IOnCheckedChangeListenerImplementor __h)
			{
				__h.Handler = (EventHandler<CheckedChangeEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnCheckedChangeListener, IOnCheckedChangeListenerImplementor>(ref weak_implementor_SetOnCheckedChangeListener, IOnCheckedChangeListenerImplementor.__IsEmpty, delegate
			{
				SetOnCheckedChangeListener(null);
			}, delegate(IOnCheckedChangeListenerImplementor __h)
			{
				__h.Handler = (EventHandler<CheckedChangeEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	protected MaterialCardView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe MaterialCardView(Context? context)
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
	public unsafe MaterialCardView(Context? context, IAttributeSet? attrs)
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
	public unsafe MaterialCardView(Context? context, IAttributeSet? attrs, int defStyleAttr)
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

	private static Delegate GetGetCardForegroundColorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCardForegroundColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCardForegroundColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CardForegroundColor);
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

	private static Delegate GetSetCardForegroundColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetCardForegroundColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCardForegroundColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_foregroundColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialCardView? materialCardView = Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList cardForegroundColor = Java.Lang.Object.GetObject<ColorStateList>(native_foregroundColor, JniHandleOwnership.DoNotTransfer);
			materialCardView.CardForegroundColor = cardForegroundColor;
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

	private static Delegate GetIsCheckableHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsCheckable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsCheckable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Checkable ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetCheckable_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetCheckable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCheckable_Z(nint jnienv, nint native__this, sbyte native_checkable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialCardView? materialCardView = Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool checkable = native_checkable != 0;
			materialCardView.Checkable = checkable;
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

	private static Delegate GetIsCheckedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsChecked);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsChecked(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Checked ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetChecked_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetChecked_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetChecked_Z(nint jnienv, nint native__this, sbyte native__checked)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialCardView? materialCardView = Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool flag = native__checked != 0;
			materialCardView.Checked = flag;
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

	private static Delegate GetGetCheckedIconHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCheckedIcon);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCheckedIcon(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CheckedIcon);
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

	private static Delegate GetSetCheckedIcon_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetCheckedIcon_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCheckedIcon_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_checkedIcon)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialCardView? materialCardView = Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable checkedIcon = Java.Lang.Object.GetObject<Drawable>(native_checkedIcon, JniHandleOwnership.DoNotTransfer);
			materialCardView.CheckedIcon = checkedIcon;
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

	private static Delegate GetGetCheckedIconGravityHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetCheckedIconGravity);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetCheckedIconGravity(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CheckedIconGravity;
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

	private static Delegate GetSetCheckedIconGravity_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetCheckedIconGravity_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCheckedIconGravity_I(nint jnienv, nint native__this, int checkedIconGravity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CheckedIconGravity = checkedIconGravity;
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

	private static Delegate GetGetCheckedIconMarginHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetCheckedIconMargin);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetCheckedIconMargin(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CheckedIconMargin;
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

	private static Delegate GetSetCheckedIconMargin_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetCheckedIconMargin_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCheckedIconMargin_I(nint jnienv, nint native__this, int checkedIconMargin)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CheckedIconMargin = checkedIconMargin;
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

	private static Delegate GetGetCheckedIconSizeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetCheckedIconSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetCheckedIconSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CheckedIconSize;
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

	private static Delegate GetSetCheckedIconSize_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetCheckedIconSize_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCheckedIconSize_I(nint jnienv, nint native__this, int checkedIconSize)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CheckedIconSize = checkedIconSize;
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

	private static Delegate GetGetCheckedIconTintHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCheckedIconTint);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCheckedIconTint(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CheckedIconTint);
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

	private static Delegate GetSetCheckedIconTint_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetCheckedIconTint_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCheckedIconTint_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_checkedIconTint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialCardView? materialCardView = Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList checkedIconTint = Java.Lang.Object.GetObject<ColorStateList>(native_checkedIconTint, JniHandleOwnership.DoNotTransfer);
			materialCardView.CheckedIconTint = checkedIconTint;
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

	private static Delegate GetIsDraggedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsDragged);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsDragged(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Dragged ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetDragged_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetDragged_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDragged_Z(nint jnienv, nint native__this, sbyte native_dragged)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialCardView? materialCardView = Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool dragged = native_dragged != 0;
			materialCardView.Dragged = dragged;
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

	private static Delegate GetGetProgressHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetProgress);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetProgress(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Progress;
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

	private static Delegate GetSetProgress_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetProgress_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetProgress_F(nint jnienv, nint native__this, float progress)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Progress = progress;
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

	private static Delegate GetGetRippleColorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetRippleColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetRippleColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RippleColor);
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

	private static Delegate GetSetRippleColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetRippleColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRippleColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_rippleColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialCardView? materialCardView = Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList rippleColor = Java.Lang.Object.GetObject<ColorStateList>(native_rippleColor, JniHandleOwnership.DoNotTransfer);
			materialCardView.RippleColor = rippleColor;
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

	private static Delegate GetGetShapeAppearanceModelHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetShapeAppearanceModel);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetShapeAppearanceModel(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShapeAppearanceModel);
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

	private static Delegate GetSetShapeAppearanceModel_Lcom_google_android_material_shape_ShapeAppearanceModel_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetShapeAppearanceModel_Lcom_google_android_material_shape_ShapeAppearanceModel_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetShapeAppearanceModel_Lcom_google_android_material_shape_ShapeAppearanceModel_(nint jnienv, nint native__this, nint native_shapeAppearanceModel)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialCardView? materialCardView = Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ShapeAppearanceModel shapeAppearanceModel = Java.Lang.Object.GetObject<ShapeAppearanceModel>(native_shapeAppearanceModel, JniHandleOwnership.DoNotTransfer);
			materialCardView.ShapeAppearanceModel = shapeAppearanceModel;
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
	private static Delegate GetGetStrokeColorHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetStrokeColor);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetStrokeColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StrokeColor;
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

	private static Delegate GetSetStrokeColor_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetStrokeColor_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStrokeColor_I(nint jnienv, nint native__this, int strokeColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StrokeColor = strokeColor;
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

	private static Delegate GetGetStrokeColorStateListHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetStrokeColorStateList);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetStrokeColorStateList(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StrokeColorStateList);
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

	private static Delegate GetGetStrokeWidthHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetStrokeWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetStrokeWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StrokeWidth;
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

	private static Delegate GetSetStrokeWidth_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetStrokeWidth_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStrokeWidth_I(nint jnienv, nint native__this, int strokeWidth)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StrokeWidth = strokeWidth;
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

	private static Delegate GetSetCheckedIconMarginResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetCheckedIconMarginResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCheckedIconMarginResource_I(nint jnienv, nint native__this, int checkedIconMarginResId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCheckedIconMarginResource(checkedIconMarginResId);
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

	[Register("setCheckedIconMarginResource", "(I)V", "GetSetCheckedIconMarginResource_IHandler")]
	public unsafe virtual void SetCheckedIconMarginResource(int checkedIconMarginResId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(checkedIconMarginResId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setCheckedIconMarginResource.(I)V", this, ptr);
	}

	private static Delegate GetSetCheckedIconResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetCheckedIconResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCheckedIconResource_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCheckedIconResource(id);
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

	[Register("setCheckedIconResource", "(I)V", "GetSetCheckedIconResource_IHandler")]
	public unsafe virtual void SetCheckedIconResource(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setCheckedIconResource.(I)V", this, ptr);
	}

	private static Delegate GetSetCheckedIconSizeResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetCheckedIconSizeResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCheckedIconSizeResource_I(nint jnienv, nint native__this, int checkedIconSizeResId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCheckedIconSizeResource(checkedIconSizeResId);
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

	[Register("setCheckedIconSizeResource", "(I)V", "GetSetCheckedIconSizeResource_IHandler")]
	public unsafe virtual void SetCheckedIconSizeResource(int checkedIconSizeResId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(checkedIconSizeResId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setCheckedIconSizeResource.(I)V", this, ptr);
	}

	private static Delegate GetSetOnCheckedChangeListener_Lcom_google_android_material_card_MaterialCardView_OnCheckedChangeListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetOnCheckedChangeListener_Lcom_google_android_material_card_MaterialCardView_OnCheckedChangeListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnCheckedChangeListener_Lcom_google_android_material_card_MaterialCardView_OnCheckedChangeListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialCardView? materialCardView = Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnCheckedChangeListener onCheckedChangeListener = Java.Lang.Object.GetObject<IOnCheckedChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			materialCardView.SetOnCheckedChangeListener(onCheckedChangeListener);
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

	[Register("setOnCheckedChangeListener", "(Lcom/google/android/material/card/MaterialCardView$OnCheckedChangeListener;)V", "GetSetOnCheckedChangeListener_Lcom_google_android_material_card_MaterialCardView_OnCheckedChangeListener_Handler")]
	public unsafe virtual void SetOnCheckedChangeListener(IOnCheckedChangeListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnCheckedChangeListener.(Lcom/google/android/material/card/MaterialCardView$OnCheckedChangeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetRippleColorResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetRippleColorResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRippleColorResource_I(nint jnienv, nint native__this, int rippleColorResourceId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetRippleColorResource(rippleColorResourceId);
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

	[Register("setRippleColorResource", "(I)V", "GetSetRippleColorResource_IHandler")]
	public unsafe virtual void SetRippleColorResource(int rippleColorResourceId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(rippleColorResourceId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setRippleColorResource.(I)V", this, ptr);
	}

	private static Delegate GetSetStrokeColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetStrokeColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStrokeColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_strokeColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialCardView? materialCardView = Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList strokeColor = Java.Lang.Object.GetObject<ColorStateList>(native_strokeColor, JniHandleOwnership.DoNotTransfer);
			materialCardView.SetStrokeColor(strokeColor);
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

	[Register("setStrokeColor", "(Landroid/content/res/ColorStateList;)V", "GetSetStrokeColor_Landroid_content_res_ColorStateList_Handler")]
	public unsafe virtual void SetStrokeColor(ColorStateList? strokeColor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(strokeColor?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStrokeColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(strokeColor);
		}
	}

	private static Delegate GetToggleHandler()
	{
		return new global::_JniMarshal_PP_V(n_Toggle);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Toggle(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialCardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Toggle();
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

	[Register("toggle", "()V", "GetToggleHandler")]
	public unsafe virtual void Toggle()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("toggle.()V", this, null);
	}

	private IOnCheckedChangeListenerImplementor __CreateIOnCheckedChangeListenerImplementor()
	{
		return new IOnCheckedChangeListenerImplementor(this);
	}
}
