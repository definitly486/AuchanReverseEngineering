using System;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Interop;
using Java.Lang;

namespace ImageViews.Photo;

[Register("com/github/chrisbanes/photoview/PhotoView", DoNotGenerateAcw = true)]
public class PhotoView : ImageView
{
	internal static readonly JniPeerMembers _members = new XAPeerMembers("com/github/chrisbanes/photoview/PhotoView", typeof(PhotoView));

	private static Delegate cb_getAttacher;

	private static Delegate cb_getDisplayRect;

	private static Delegate cb_isZoomEnabled;

	private static Delegate cb_getMaximumScale;

	private static Delegate cb_setMaximumScale_F;

	private static Delegate cb_getMediumScale;

	private static Delegate cb_setMediumScale_F;

	private static Delegate cb_getMinimumScale;

	private static Delegate cb_setMinimumScale_F;

	private static Delegate cb_getScale;

	private static Delegate cb_setScale_F;

	private static Delegate cb_isZoomable;

	private static Delegate cb_setZoomable_Z;

	private static Delegate cb_getDisplayMatrix_Landroid_graphics_Matrix_;

	private static Delegate cb_getSuppMatrix_Landroid_graphics_Matrix_;

	private static Delegate cb_setAllowParentInterceptOnEdge_Z;

	private static Delegate cb_setDisplayMatrix_Landroid_graphics_Matrix_;

	private static Delegate cb_setOnDoubleTapListener_Landroid_view_GestureDetector_OnDoubleTapListener_;

	private static Delegate cb_setOnMatrixChangeListener_Lcom_github_chrisbanes_photoview_OnMatrixChangedListener_;

	private static Delegate cb_setOnOutsidePhotoTapListener_Lcom_github_chrisbanes_photoview_OnOutsidePhotoTapListener_;

	private static Delegate cb_setOnPhotoTapListener_Lcom_github_chrisbanes_photoview_OnPhotoTapListener_;

	private static Delegate cb_setOnScaleChangeListener_Lcom_github_chrisbanes_photoview_OnScaleChangedListener_;

	private static Delegate cb_setOnSingleFlingListener_Lcom_github_chrisbanes_photoview_OnSingleFlingListener_;

	private static Delegate cb_setOnViewDragListener_Lcom_github_chrisbanes_photoview_OnViewDragListener_;

	private static Delegate cb_setOnViewTapListener_Lcom_github_chrisbanes_photoview_OnViewTapListener_;

	private static Delegate cb_setRotationBy_F;

	private static Delegate cb_setRotationTo_F;

	private static Delegate cb_setScale_FZ;

	private static Delegate cb_setScale_FFFZ;

	private static Delegate cb_setScaleLevels_FFF;

	private static Delegate cb_setSuppMatrix_Landroid_graphics_Matrix_;

	private static Delegate cb_setZoomTransitionDuration_I;

	private WeakReference weak_implementor_SetOnMatrixChangeListener;

	private WeakReference weak_implementor_SetOnOutsidePhotoTapListener;

	private WeakReference weak_implementor_SetOnPhotoTapListener;

	private WeakReference weak_implementor_SetOnScaleChangeListener;

	private WeakReference weak_implementor_SetOnSingleFlingListener;

	private WeakReference weak_implementor_SetOnViewDragListener;

	private WeakReference weak_implementor_SetOnViewTapListener;

	public Matrix DisplayMatrix
	{
		get
		{
			Matrix matrix = new Matrix();
			GetDisplayMatrix(matrix);
			return matrix;
		}
		set
		{
			SetDisplayMatrix(value);
		}
	}

	public Matrix SuppMatrix
	{
		get
		{
			Matrix matrix = new Matrix();
			GetSuppMatrix(matrix);
			return matrix;
		}
		set
		{
			SetSuppMatrix(value);
		}
	}

	internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual PhotoViewAttacher Attacher
	{
		[Register("getAttacher", "()Lcom/github/chrisbanes/photoview/PhotoViewAttacher;", "GetGetAttacherHandler")]
		get
		{
			return Java.Lang.Object.GetObject<PhotoViewAttacher>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAttacher.()Lcom/github/chrisbanes/photoview/PhotoViewAttacher;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual RectF DisplayRect
	{
		[Register("getDisplayRect", "()Landroid/graphics/RectF;", "GetGetDisplayRectHandler")]
		get
		{
			return Java.Lang.Object.GetObject<RectF>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDisplayRect.()Landroid/graphics/RectF;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual bool IsZoomEnabled
	{
		[Register("isZoomEnabled", "()Z", "GetIsZoomEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isZoomEnabled.()Z", this, null);
		}
	}

	public unsafe virtual float MaximumScale
	{
		[Register("getMaximumScale", "()F", "GetGetMaximumScaleHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getMaximumScale.()F", this, null);
		}
		[Register("setMaximumScale", "(F)V", "GetSetMaximumScale_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMaximumScale.(F)V", this, ptr);
		}
	}

	public unsafe virtual float MediumScale
	{
		[Register("getMediumScale", "()F", "GetGetMediumScaleHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getMediumScale.()F", this, null);
		}
		[Register("setMediumScale", "(F)V", "GetSetMediumScale_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMediumScale.(F)V", this, ptr);
		}
	}

	public unsafe virtual float MinimumScale
	{
		[Register("getMinimumScale", "()F", "GetGetMinimumScaleHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getMinimumScale.()F", this, null);
		}
		[Register("setMinimumScale", "(F)V", "GetSetMinimumScale_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMinimumScale.(F)V", this, ptr);
		}
	}

	public unsafe virtual float Scale
	{
		[Register("getScale", "()F", "GetGetScaleHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getScale.()F", this, null);
		}
		[Register("setScale", "(F)V", "GetSetScale_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setScale.(F)V", this, ptr);
		}
	}

	public unsafe virtual bool Zoomable
	{
		[Register("isZoomable", "()Z", "GetIsZoomableHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isZoomable.()Z", this, null);
		}
		[Register("setZoomable", "(Z)V", "GetSetZoomable_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setZoomable.(Z)V", this, ptr);
		}
	}

	public event EventHandler<MatrixChangedEventArgs> MatrixChange
	{
		add
		{
			EventHelper.AddEventHandler<IOnMatrixChangedListener, IOnMatrixChangedListenerImplementor>(ref weak_implementor_SetOnMatrixChangeListener, __CreateIOnMatrixChangedListenerImplementor, SetOnMatrixChangeListener, delegate(IOnMatrixChangedListenerImplementor __h)
			{
				__h.Handler = (EventHandler<MatrixChangedEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnMatrixChangedListener, IOnMatrixChangedListenerImplementor>(ref weak_implementor_SetOnMatrixChangeListener, IOnMatrixChangedListenerImplementor.__IsEmpty, delegate
			{
				SetOnMatrixChangeListener(null);
			}, delegate(IOnMatrixChangedListenerImplementor __h)
			{
				__h.Handler = (EventHandler<MatrixChangedEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	public event EventHandler<OutsidePhotoTapEventArgs> OutsidePhotoTap
	{
		add
		{
			EventHelper.AddEventHandler<IOnOutsidePhotoTapListener, IOnOutsidePhotoTapListenerImplementor>(ref weak_implementor_SetOnOutsidePhotoTapListener, __CreateIOnOutsidePhotoTapListenerImplementor, SetOnOutsidePhotoTapListener, delegate(IOnOutsidePhotoTapListenerImplementor __h)
			{
				__h.Handler = (EventHandler<OutsidePhotoTapEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnOutsidePhotoTapListener, IOnOutsidePhotoTapListenerImplementor>(ref weak_implementor_SetOnOutsidePhotoTapListener, IOnOutsidePhotoTapListenerImplementor.__IsEmpty, delegate
			{
				SetOnOutsidePhotoTapListener(null);
			}, delegate(IOnOutsidePhotoTapListenerImplementor __h)
			{
				__h.Handler = (EventHandler<OutsidePhotoTapEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	public event EventHandler<PhotoTapEventArgs> PhotoTap
	{
		add
		{
			EventHelper.AddEventHandler<IOnPhotoTapListener, IOnPhotoTapListenerImplementor>(ref weak_implementor_SetOnPhotoTapListener, __CreateIOnPhotoTapListenerImplementor, SetOnPhotoTapListener, delegate(IOnPhotoTapListenerImplementor __h)
			{
				__h.Handler = (EventHandler<PhotoTapEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnPhotoTapListener, IOnPhotoTapListenerImplementor>(ref weak_implementor_SetOnPhotoTapListener, IOnPhotoTapListenerImplementor.__IsEmpty, delegate
			{
				SetOnPhotoTapListener(null);
			}, delegate(IOnPhotoTapListenerImplementor __h)
			{
				__h.Handler = (EventHandler<PhotoTapEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	public event EventHandler<ScaleChangedEventArgs> ScaleChange
	{
		add
		{
			EventHelper.AddEventHandler<IOnScaleChangedListener, IOnScaleChangedListenerImplementor>(ref weak_implementor_SetOnScaleChangeListener, __CreateIOnScaleChangedListenerImplementor, SetOnScaleChangeListener, delegate(IOnScaleChangedListenerImplementor __h)
			{
				__h.Handler = (EventHandler<ScaleChangedEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnScaleChangedListener, IOnScaleChangedListenerImplementor>(ref weak_implementor_SetOnScaleChangeListener, IOnScaleChangedListenerImplementor.__IsEmpty, delegate
			{
				SetOnScaleChangeListener(null);
			}, delegate(IOnScaleChangedListenerImplementor __h)
			{
				__h.Handler = (EventHandler<ScaleChangedEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	public event EventHandler<SingleFlingEventArgs> SingleFling
	{
		add
		{
			EventHelper.AddEventHandler<IOnSingleFlingListener, IOnSingleFlingListenerImplementor>(ref weak_implementor_SetOnSingleFlingListener, __CreateIOnSingleFlingListenerImplementor, SetOnSingleFlingListener, delegate(IOnSingleFlingListenerImplementor __h)
			{
				__h.Handler = (EventHandler<SingleFlingEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnSingleFlingListener, IOnSingleFlingListenerImplementor>(ref weak_implementor_SetOnSingleFlingListener, IOnSingleFlingListenerImplementor.__IsEmpty, delegate
			{
				SetOnSingleFlingListener(null);
			}, delegate(IOnSingleFlingListenerImplementor __h)
			{
				__h.Handler = (EventHandler<SingleFlingEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	public event EventHandler<ViewDragEventArgs> ViewDrag
	{
		add
		{
			EventHelper.AddEventHandler<IOnViewDragListener, IOnViewDragListenerImplementor>(ref weak_implementor_SetOnViewDragListener, __CreateIOnViewDragListenerImplementor, SetOnViewDragListener, delegate(IOnViewDragListenerImplementor __h)
			{
				__h.Handler = (EventHandler<ViewDragEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnViewDragListener, IOnViewDragListenerImplementor>(ref weak_implementor_SetOnViewDragListener, IOnViewDragListenerImplementor.__IsEmpty, delegate
			{
				SetOnViewDragListener(null);
			}, delegate(IOnViewDragListenerImplementor __h)
			{
				__h.Handler = (EventHandler<ViewDragEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	public event EventHandler<ViewTapEventArgs> ViewTap
	{
		add
		{
			EventHelper.AddEventHandler<IOnViewTapListener, IOnViewTapListenerImplementor>(ref weak_implementor_SetOnViewTapListener, __CreateIOnViewTapListenerImplementor, SetOnViewTapListener, delegate(IOnViewTapListenerImplementor __h)
			{
				__h.Handler = (EventHandler<ViewTapEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnViewTapListener, IOnViewTapListenerImplementor>(ref weak_implementor_SetOnViewTapListener, IOnViewTapListenerImplementor.__IsEmpty, delegate
			{
				SetOnViewTapListener(null);
			}, delegate(IOnViewTapListenerImplementor __h)
			{
				__h.Handler = (EventHandler<ViewTapEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	protected PhotoView(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe PhotoView(Context context)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
			GC.KeepAlive(context);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
	public unsafe PhotoView(Context context, IAttributeSet attr)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attr == null) ? IntPtr.Zero : ((Java.Lang.Object)attr).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
			GC.KeepAlive(context);
			GC.KeepAlive(attr);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
	public unsafe PhotoView(Context context, IAttributeSet attr, int defStyle)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attr == null) ? IntPtr.Zero : ((Java.Lang.Object)attr).Handle);
			ptr[2] = new JniArgumentValue(defStyle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
			GC.KeepAlive(context);
			GC.KeepAlive(attr);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;II)V", "")]
	public unsafe PhotoView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyleAttr);
			ptr[3] = new JniArgumentValue(defStyleRes);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;II)V", this, ptr);
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	private static Delegate GetGetAttacherHandler()
	{
		if ((object)cb_getAttacher == null)
		{
			cb_getAttacher = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetAttacher));
		}
		return cb_getAttacher;
	}

	private static IntPtr n_GetAttacher(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Attacher);
	}

	private static Delegate GetGetDisplayRectHandler()
	{
		if ((object)cb_getDisplayRect == null)
		{
			cb_getDisplayRect = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetDisplayRect));
		}
		return cb_getDisplayRect;
	}

	private static IntPtr n_GetDisplayRect(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DisplayRect);
	}

	private static Delegate GetIsZoomEnabledHandler()
	{
		if ((object)cb_isZoomEnabled == null)
		{
			cb_isZoomEnabled = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsZoomEnabled));
		}
		return cb_isZoomEnabled;
	}

	private static bool n_IsZoomEnabled(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsZoomEnabled;
	}

	private static Delegate GetGetMaximumScaleHandler()
	{
		if ((object)cb_getMaximumScale == null)
		{
			cb_getMaximumScale = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, float>(n_GetMaximumScale));
		}
		return cb_getMaximumScale;
	}

	private static float n_GetMaximumScale(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaximumScale;
	}

	private static Delegate GetSetMaximumScale_FHandler()
	{
		if ((object)cb_setMaximumScale_F == null)
		{
			cb_setMaximumScale_F = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, float>(n_SetMaximumScale_F));
		}
		return cb_setMaximumScale_F;
	}

	private static void n_SetMaximumScale_F(IntPtr jnienv, IntPtr native__this, float maximumScale)
	{
		Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaximumScale = maximumScale;
	}

	private static Delegate GetGetMediumScaleHandler()
	{
		if ((object)cb_getMediumScale == null)
		{
			cb_getMediumScale = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, float>(n_GetMediumScale));
		}
		return cb_getMediumScale;
	}

	private static float n_GetMediumScale(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MediumScale;
	}

	private static Delegate GetSetMediumScale_FHandler()
	{
		if ((object)cb_setMediumScale_F == null)
		{
			cb_setMediumScale_F = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, float>(n_SetMediumScale_F));
		}
		return cb_setMediumScale_F;
	}

	private static void n_SetMediumScale_F(IntPtr jnienv, IntPtr native__this, float mediumScale)
	{
		Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MediumScale = mediumScale;
	}

	private static Delegate GetGetMinimumScaleHandler()
	{
		if ((object)cb_getMinimumScale == null)
		{
			cb_getMinimumScale = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, float>(n_GetMinimumScale));
		}
		return cb_getMinimumScale;
	}

	private static float n_GetMinimumScale(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinimumScale;
	}

	private static Delegate GetSetMinimumScale_FHandler()
	{
		if ((object)cb_setMinimumScale_F == null)
		{
			cb_setMinimumScale_F = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, float>(n_SetMinimumScale_F));
		}
		return cb_setMinimumScale_F;
	}

	private static void n_SetMinimumScale_F(IntPtr jnienv, IntPtr native__this, float minimumScale)
	{
		Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinimumScale = minimumScale;
	}

	private static Delegate GetGetScaleHandler()
	{
		if ((object)cb_getScale == null)
		{
			cb_getScale = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, float>(n_GetScale));
		}
		return cb_getScale;
	}

	private static float n_GetScale(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Scale;
	}

	private static Delegate GetSetScale_FHandler()
	{
		if ((object)cb_setScale_F == null)
		{
			cb_setScale_F = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, float>(n_SetScale_F));
		}
		return cb_setScale_F;
	}

	private static void n_SetScale_F(IntPtr jnienv, IntPtr native__this, float scale)
	{
		Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Scale = scale;
	}

	private static Delegate GetIsZoomableHandler()
	{
		if ((object)cb_isZoomable == null)
		{
			cb_isZoomable = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsZoomable));
		}
		return cb_isZoomable;
	}

	private static bool n_IsZoomable(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Zoomable;
	}

	private static Delegate GetSetZoomable_ZHandler()
	{
		if ((object)cb_setZoomable_Z == null)
		{
			cb_setZoomable_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_SetZoomable_Z));
		}
		return cb_setZoomable_Z;
	}

	private static void n_SetZoomable_Z(IntPtr jnienv, IntPtr native__this, bool zoomable)
	{
		Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Zoomable = zoomable;
	}

	private static Delegate GetGetDisplayMatrix_Landroid_graphics_Matrix_Handler()
	{
		if ((object)cb_getDisplayMatrix_Landroid_graphics_Matrix_ == null)
		{
			cb_getDisplayMatrix_Landroid_graphics_Matrix_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_GetDisplayMatrix_Landroid_graphics_Matrix_));
		}
		return cb_getDisplayMatrix_Landroid_graphics_Matrix_;
	}

	private static void n_GetDisplayMatrix_Landroid_graphics_Matrix_(IntPtr jnienv, IntPtr native__this, IntPtr native_matrix)
	{
		PhotoView? photoView = Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Matrix matrix = Java.Lang.Object.GetObject<Matrix>(native_matrix, JniHandleOwnership.DoNotTransfer);
		photoView.GetDisplayMatrix(matrix);
	}

	[Register("getDisplayMatrix", "(Landroid/graphics/Matrix;)V", "GetGetDisplayMatrix_Landroid_graphics_Matrix_Handler")]
	public unsafe virtual void GetDisplayMatrix(Matrix matrix)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(matrix?.Handle ?? IntPtr.Zero);
		_members.InstanceMethods.InvokeVirtualVoidMethod("getDisplayMatrix.(Landroid/graphics/Matrix;)V", this, ptr);
		GC.KeepAlive(matrix);
	}

	private static Delegate GetGetSuppMatrix_Landroid_graphics_Matrix_Handler()
	{
		if ((object)cb_getSuppMatrix_Landroid_graphics_Matrix_ == null)
		{
			cb_getSuppMatrix_Landroid_graphics_Matrix_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_GetSuppMatrix_Landroid_graphics_Matrix_));
		}
		return cb_getSuppMatrix_Landroid_graphics_Matrix_;
	}

	private static void n_GetSuppMatrix_Landroid_graphics_Matrix_(IntPtr jnienv, IntPtr native__this, IntPtr native_matrix)
	{
		PhotoView? photoView = Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Matrix matrix = Java.Lang.Object.GetObject<Matrix>(native_matrix, JniHandleOwnership.DoNotTransfer);
		photoView.GetSuppMatrix(matrix);
	}

	[Register("getSuppMatrix", "(Landroid/graphics/Matrix;)V", "GetGetSuppMatrix_Landroid_graphics_Matrix_Handler")]
	public unsafe virtual void GetSuppMatrix(Matrix matrix)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(matrix?.Handle ?? IntPtr.Zero);
		_members.InstanceMethods.InvokeVirtualVoidMethod("getSuppMatrix.(Landroid/graphics/Matrix;)V", this, ptr);
		GC.KeepAlive(matrix);
	}

	private static Delegate GetSetAllowParentInterceptOnEdge_ZHandler()
	{
		if ((object)cb_setAllowParentInterceptOnEdge_Z == null)
		{
			cb_setAllowParentInterceptOnEdge_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_SetAllowParentInterceptOnEdge_Z));
		}
		return cb_setAllowParentInterceptOnEdge_Z;
	}

	private static void n_SetAllowParentInterceptOnEdge_Z(IntPtr jnienv, IntPtr native__this, bool allow)
	{
		Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetAllowParentInterceptOnEdge(allow);
	}

	[Register("setAllowParentInterceptOnEdge", "(Z)V", "GetSetAllowParentInterceptOnEdge_ZHandler")]
	public unsafe virtual void SetAllowParentInterceptOnEdge(bool allow)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(allow);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setAllowParentInterceptOnEdge.(Z)V", this, ptr);
	}

	private static Delegate GetSetDisplayMatrix_Landroid_graphics_Matrix_Handler()
	{
		if ((object)cb_setDisplayMatrix_Landroid_graphics_Matrix_ == null)
		{
			cb_setDisplayMatrix_Landroid_graphics_Matrix_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, bool>(n_SetDisplayMatrix_Landroid_graphics_Matrix_));
		}
		return cb_setDisplayMatrix_Landroid_graphics_Matrix_;
	}

	private static bool n_SetDisplayMatrix_Landroid_graphics_Matrix_(IntPtr jnienv, IntPtr native__this, IntPtr native_finalRectangle)
	{
		PhotoView? photoView = Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Matrix displayMatrix = Java.Lang.Object.GetObject<Matrix>(native_finalRectangle, JniHandleOwnership.DoNotTransfer);
		return photoView.SetDisplayMatrix(displayMatrix);
	}

	[Register("setDisplayMatrix", "(Landroid/graphics/Matrix;)Z", "GetSetDisplayMatrix_Landroid_graphics_Matrix_Handler")]
	public unsafe virtual bool SetDisplayMatrix(Matrix finalRectangle)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(finalRectangle?.Handle ?? IntPtr.Zero);
		bool result = _members.InstanceMethods.InvokeVirtualBooleanMethod("setDisplayMatrix.(Landroid/graphics/Matrix;)Z", this, ptr);
		GC.KeepAlive(finalRectangle);
		return result;
	}

	private static Delegate GetSetOnDoubleTapListener_Landroid_view_GestureDetector_OnDoubleTapListener_Handler()
	{
		if ((object)cb_setOnDoubleTapListener_Landroid_view_GestureDetector_OnDoubleTapListener_ == null)
		{
			cb_setOnDoubleTapListener_Landroid_view_GestureDetector_OnDoubleTapListener_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetOnDoubleTapListener_Landroid_view_GestureDetector_OnDoubleTapListener_));
		}
		return cb_setOnDoubleTapListener_Landroid_view_GestureDetector_OnDoubleTapListener_;
	}

	private static void n_SetOnDoubleTapListener_Landroid_view_GestureDetector_OnDoubleTapListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_onDoubleTapListener)
	{
		PhotoView? photoView = Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		GestureDetector.IOnDoubleTapListener onDoubleTapListener = Java.Lang.Object.GetObject<GestureDetector.IOnDoubleTapListener>(native_onDoubleTapListener, JniHandleOwnership.DoNotTransfer);
		photoView.SetOnDoubleTapListener(onDoubleTapListener);
	}

	[Register("setOnDoubleTapListener", "(Landroid/view/GestureDetector$OnDoubleTapListener;)V", "GetSetOnDoubleTapListener_Landroid_view_GestureDetector_OnDoubleTapListener_Handler")]
	public unsafe virtual void SetOnDoubleTapListener(GestureDetector.IOnDoubleTapListener onDoubleTapListener)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((onDoubleTapListener == null) ? IntPtr.Zero : ((Java.Lang.Object)onDoubleTapListener).Handle);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setOnDoubleTapListener.(Landroid/view/GestureDetector$OnDoubleTapListener;)V", this, ptr);
		GC.KeepAlive(onDoubleTapListener);
	}

	private static Delegate GetSetOnMatrixChangeListener_Lcom_github_chrisbanes_photoview_OnMatrixChangedListener_Handler()
	{
		if ((object)cb_setOnMatrixChangeListener_Lcom_github_chrisbanes_photoview_OnMatrixChangedListener_ == null)
		{
			cb_setOnMatrixChangeListener_Lcom_github_chrisbanes_photoview_OnMatrixChangedListener_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetOnMatrixChangeListener_Lcom_github_chrisbanes_photoview_OnMatrixChangedListener_));
		}
		return cb_setOnMatrixChangeListener_Lcom_github_chrisbanes_photoview_OnMatrixChangedListener_;
	}

	private static void n_SetOnMatrixChangeListener_Lcom_github_chrisbanes_photoview_OnMatrixChangedListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
	{
		PhotoView? photoView = Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnMatrixChangedListener onMatrixChangeListener = Java.Lang.Object.GetObject<IOnMatrixChangedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		photoView.SetOnMatrixChangeListener(onMatrixChangeListener);
	}

	[Register("setOnMatrixChangeListener", "(Lcom/github/chrisbanes/photoview/OnMatrixChangedListener;)V", "GetSetOnMatrixChangeListener_Lcom_github_chrisbanes_photoview_OnMatrixChangedListener_Handler")]
	public unsafe virtual void SetOnMatrixChangeListener(IOnMatrixChangedListener listener)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setOnMatrixChangeListener.(Lcom/github/chrisbanes/photoview/OnMatrixChangedListener;)V", this, ptr);
		GC.KeepAlive(listener);
	}

	private static Delegate GetSetOnOutsidePhotoTapListener_Lcom_github_chrisbanes_photoview_OnOutsidePhotoTapListener_Handler()
	{
		if ((object)cb_setOnOutsidePhotoTapListener_Lcom_github_chrisbanes_photoview_OnOutsidePhotoTapListener_ == null)
		{
			cb_setOnOutsidePhotoTapListener_Lcom_github_chrisbanes_photoview_OnOutsidePhotoTapListener_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetOnOutsidePhotoTapListener_Lcom_github_chrisbanes_photoview_OnOutsidePhotoTapListener_));
		}
		return cb_setOnOutsidePhotoTapListener_Lcom_github_chrisbanes_photoview_OnOutsidePhotoTapListener_;
	}

	private static void n_SetOnOutsidePhotoTapListener_Lcom_github_chrisbanes_photoview_OnOutsidePhotoTapListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
	{
		PhotoView? photoView = Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnOutsidePhotoTapListener onOutsidePhotoTapListener = Java.Lang.Object.GetObject<IOnOutsidePhotoTapListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		photoView.SetOnOutsidePhotoTapListener(onOutsidePhotoTapListener);
	}

	[Register("setOnOutsidePhotoTapListener", "(Lcom/github/chrisbanes/photoview/OnOutsidePhotoTapListener;)V", "GetSetOnOutsidePhotoTapListener_Lcom_github_chrisbanes_photoview_OnOutsidePhotoTapListener_Handler")]
	public unsafe virtual void SetOnOutsidePhotoTapListener(IOnOutsidePhotoTapListener listener)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setOnOutsidePhotoTapListener.(Lcom/github/chrisbanes/photoview/OnOutsidePhotoTapListener;)V", this, ptr);
		GC.KeepAlive(listener);
	}

	private static Delegate GetSetOnPhotoTapListener_Lcom_github_chrisbanes_photoview_OnPhotoTapListener_Handler()
	{
		if ((object)cb_setOnPhotoTapListener_Lcom_github_chrisbanes_photoview_OnPhotoTapListener_ == null)
		{
			cb_setOnPhotoTapListener_Lcom_github_chrisbanes_photoview_OnPhotoTapListener_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetOnPhotoTapListener_Lcom_github_chrisbanes_photoview_OnPhotoTapListener_));
		}
		return cb_setOnPhotoTapListener_Lcom_github_chrisbanes_photoview_OnPhotoTapListener_;
	}

	private static void n_SetOnPhotoTapListener_Lcom_github_chrisbanes_photoview_OnPhotoTapListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
	{
		PhotoView? photoView = Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnPhotoTapListener onPhotoTapListener = Java.Lang.Object.GetObject<IOnPhotoTapListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		photoView.SetOnPhotoTapListener(onPhotoTapListener);
	}

	[Register("setOnPhotoTapListener", "(Lcom/github/chrisbanes/photoview/OnPhotoTapListener;)V", "GetSetOnPhotoTapListener_Lcom_github_chrisbanes_photoview_OnPhotoTapListener_Handler")]
	public unsafe virtual void SetOnPhotoTapListener(IOnPhotoTapListener listener)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setOnPhotoTapListener.(Lcom/github/chrisbanes/photoview/OnPhotoTapListener;)V", this, ptr);
		GC.KeepAlive(listener);
	}

	private static Delegate GetSetOnScaleChangeListener_Lcom_github_chrisbanes_photoview_OnScaleChangedListener_Handler()
	{
		if ((object)cb_setOnScaleChangeListener_Lcom_github_chrisbanes_photoview_OnScaleChangedListener_ == null)
		{
			cb_setOnScaleChangeListener_Lcom_github_chrisbanes_photoview_OnScaleChangedListener_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetOnScaleChangeListener_Lcom_github_chrisbanes_photoview_OnScaleChangedListener_));
		}
		return cb_setOnScaleChangeListener_Lcom_github_chrisbanes_photoview_OnScaleChangedListener_;
	}

	private static void n_SetOnScaleChangeListener_Lcom_github_chrisbanes_photoview_OnScaleChangedListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_onScaleChangedListener)
	{
		PhotoView? photoView = Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnScaleChangedListener onScaleChangeListener = Java.Lang.Object.GetObject<IOnScaleChangedListener>(native_onScaleChangedListener, JniHandleOwnership.DoNotTransfer);
		photoView.SetOnScaleChangeListener(onScaleChangeListener);
	}

	[Register("setOnScaleChangeListener", "(Lcom/github/chrisbanes/photoview/OnScaleChangedListener;)V", "GetSetOnScaleChangeListener_Lcom_github_chrisbanes_photoview_OnScaleChangedListener_Handler")]
	public unsafe virtual void SetOnScaleChangeListener(IOnScaleChangedListener onScaleChangedListener)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((onScaleChangedListener == null) ? IntPtr.Zero : ((Java.Lang.Object)onScaleChangedListener).Handle);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setOnScaleChangeListener.(Lcom/github/chrisbanes/photoview/OnScaleChangedListener;)V", this, ptr);
		GC.KeepAlive(onScaleChangedListener);
	}

	private static Delegate GetSetOnSingleFlingListener_Lcom_github_chrisbanes_photoview_OnSingleFlingListener_Handler()
	{
		if ((object)cb_setOnSingleFlingListener_Lcom_github_chrisbanes_photoview_OnSingleFlingListener_ == null)
		{
			cb_setOnSingleFlingListener_Lcom_github_chrisbanes_photoview_OnSingleFlingListener_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetOnSingleFlingListener_Lcom_github_chrisbanes_photoview_OnSingleFlingListener_));
		}
		return cb_setOnSingleFlingListener_Lcom_github_chrisbanes_photoview_OnSingleFlingListener_;
	}

	private static void n_SetOnSingleFlingListener_Lcom_github_chrisbanes_photoview_OnSingleFlingListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_onSingleFlingListener)
	{
		PhotoView? photoView = Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnSingleFlingListener onSingleFlingListener = Java.Lang.Object.GetObject<IOnSingleFlingListener>(native_onSingleFlingListener, JniHandleOwnership.DoNotTransfer);
		photoView.SetOnSingleFlingListener(onSingleFlingListener);
	}

	[Register("setOnSingleFlingListener", "(Lcom/github/chrisbanes/photoview/OnSingleFlingListener;)V", "GetSetOnSingleFlingListener_Lcom_github_chrisbanes_photoview_OnSingleFlingListener_Handler")]
	public unsafe virtual void SetOnSingleFlingListener(IOnSingleFlingListener onSingleFlingListener)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((onSingleFlingListener == null) ? IntPtr.Zero : ((Java.Lang.Object)onSingleFlingListener).Handle);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setOnSingleFlingListener.(Lcom/github/chrisbanes/photoview/OnSingleFlingListener;)V", this, ptr);
		GC.KeepAlive(onSingleFlingListener);
	}

	private static Delegate GetSetOnViewDragListener_Lcom_github_chrisbanes_photoview_OnViewDragListener_Handler()
	{
		if ((object)cb_setOnViewDragListener_Lcom_github_chrisbanes_photoview_OnViewDragListener_ == null)
		{
			cb_setOnViewDragListener_Lcom_github_chrisbanes_photoview_OnViewDragListener_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetOnViewDragListener_Lcom_github_chrisbanes_photoview_OnViewDragListener_));
		}
		return cb_setOnViewDragListener_Lcom_github_chrisbanes_photoview_OnViewDragListener_;
	}

	private static void n_SetOnViewDragListener_Lcom_github_chrisbanes_photoview_OnViewDragListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
	{
		PhotoView? photoView = Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnViewDragListener onViewDragListener = Java.Lang.Object.GetObject<IOnViewDragListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		photoView.SetOnViewDragListener(onViewDragListener);
	}

	[Register("setOnViewDragListener", "(Lcom/github/chrisbanes/photoview/OnViewDragListener;)V", "GetSetOnViewDragListener_Lcom_github_chrisbanes_photoview_OnViewDragListener_Handler")]
	public unsafe virtual void SetOnViewDragListener(IOnViewDragListener listener)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setOnViewDragListener.(Lcom/github/chrisbanes/photoview/OnViewDragListener;)V", this, ptr);
		GC.KeepAlive(listener);
	}

	private static Delegate GetSetOnViewTapListener_Lcom_github_chrisbanes_photoview_OnViewTapListener_Handler()
	{
		if ((object)cb_setOnViewTapListener_Lcom_github_chrisbanes_photoview_OnViewTapListener_ == null)
		{
			cb_setOnViewTapListener_Lcom_github_chrisbanes_photoview_OnViewTapListener_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetOnViewTapListener_Lcom_github_chrisbanes_photoview_OnViewTapListener_));
		}
		return cb_setOnViewTapListener_Lcom_github_chrisbanes_photoview_OnViewTapListener_;
	}

	private static void n_SetOnViewTapListener_Lcom_github_chrisbanes_photoview_OnViewTapListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
	{
		PhotoView? photoView = Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnViewTapListener onViewTapListener = Java.Lang.Object.GetObject<IOnViewTapListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		photoView.SetOnViewTapListener(onViewTapListener);
	}

	[Register("setOnViewTapListener", "(Lcom/github/chrisbanes/photoview/OnViewTapListener;)V", "GetSetOnViewTapListener_Lcom_github_chrisbanes_photoview_OnViewTapListener_Handler")]
	public unsafe virtual void SetOnViewTapListener(IOnViewTapListener listener)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setOnViewTapListener.(Lcom/github/chrisbanes/photoview/OnViewTapListener;)V", this, ptr);
		GC.KeepAlive(listener);
	}

	private static Delegate GetSetRotationBy_FHandler()
	{
		if ((object)cb_setRotationBy_F == null)
		{
			cb_setRotationBy_F = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, float>(n_SetRotationBy_F));
		}
		return cb_setRotationBy_F;
	}

	private static void n_SetRotationBy_F(IntPtr jnienv, IntPtr native__this, float rotationDegree)
	{
		Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetRotationBy(rotationDegree);
	}

	[Register("setRotationBy", "(F)V", "GetSetRotationBy_FHandler")]
	public unsafe virtual void SetRotationBy(float rotationDegree)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(rotationDegree);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setRotationBy.(F)V", this, ptr);
	}

	private static Delegate GetSetRotationTo_FHandler()
	{
		if ((object)cb_setRotationTo_F == null)
		{
			cb_setRotationTo_F = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, float>(n_SetRotationTo_F));
		}
		return cb_setRotationTo_F;
	}

	private static void n_SetRotationTo_F(IntPtr jnienv, IntPtr native__this, float rotationDegree)
	{
		Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetRotationTo(rotationDegree);
	}

	[Register("setRotationTo", "(F)V", "GetSetRotationTo_FHandler")]
	public unsafe virtual void SetRotationTo(float rotationDegree)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(rotationDegree);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setRotationTo.(F)V", this, ptr);
	}

	private static Delegate GetSetScale_FZHandler()
	{
		if ((object)cb_setScale_FZ == null)
		{
			cb_setScale_FZ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, float, bool>(n_SetScale_FZ));
		}
		return cb_setScale_FZ;
	}

	private static void n_SetScale_FZ(IntPtr jnienv, IntPtr native__this, float scale, bool animate)
	{
		Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetScale(scale, animate);
	}

	[Register("setScale", "(FZ)V", "GetSetScale_FZHandler")]
	public unsafe virtual void SetScale(float scale, bool animate)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(scale);
		ptr[1] = new JniArgumentValue(animate);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setScale.(FZ)V", this, ptr);
	}

	private static Delegate GetSetScale_FFFZHandler()
	{
		if ((object)cb_setScale_FFFZ == null)
		{
			cb_setScale_FFFZ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, float, float, float, bool>(n_SetScale_FFFZ));
		}
		return cb_setScale_FFFZ;
	}

	private static void n_SetScale_FFFZ(IntPtr jnienv, IntPtr native__this, float scale, float focalX, float focalY, bool animate)
	{
		Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetScale(scale, focalX, focalY, animate);
	}

	[Register("setScale", "(FFFZ)V", "GetSetScale_FFFZHandler")]
	public unsafe virtual void SetScale(float scale, float focalX, float focalY, bool animate)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(scale);
		ptr[1] = new JniArgumentValue(focalX);
		ptr[2] = new JniArgumentValue(focalY);
		ptr[3] = new JniArgumentValue(animate);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setScale.(FFFZ)V", this, ptr);
	}

	private static Delegate GetSetScaleLevels_FFFHandler()
	{
		if ((object)cb_setScaleLevels_FFF == null)
		{
			cb_setScaleLevels_FFF = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, float, float, float>(n_SetScaleLevels_FFF));
		}
		return cb_setScaleLevels_FFF;
	}

	private static void n_SetScaleLevels_FFF(IntPtr jnienv, IntPtr native__this, float minimumScale, float mediumScale, float maximumScale)
	{
		Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetScaleLevels(minimumScale, mediumScale, maximumScale);
	}

	[Register("setScaleLevels", "(FFF)V", "GetSetScaleLevels_FFFHandler")]
	public unsafe virtual void SetScaleLevels(float minimumScale, float mediumScale, float maximumScale)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(minimumScale);
		ptr[1] = new JniArgumentValue(mediumScale);
		ptr[2] = new JniArgumentValue(maximumScale);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setScaleLevels.(FFF)V", this, ptr);
	}

	private static Delegate GetSetSuppMatrix_Landroid_graphics_Matrix_Handler()
	{
		if ((object)cb_setSuppMatrix_Landroid_graphics_Matrix_ == null)
		{
			cb_setSuppMatrix_Landroid_graphics_Matrix_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, bool>(n_SetSuppMatrix_Landroid_graphics_Matrix_));
		}
		return cb_setSuppMatrix_Landroid_graphics_Matrix_;
	}

	private static bool n_SetSuppMatrix_Landroid_graphics_Matrix_(IntPtr jnienv, IntPtr native__this, IntPtr native_matrix)
	{
		PhotoView? photoView = Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Matrix suppMatrix = Java.Lang.Object.GetObject<Matrix>(native_matrix, JniHandleOwnership.DoNotTransfer);
		return photoView.SetSuppMatrix(suppMatrix);
	}

	[Register("setSuppMatrix", "(Landroid/graphics/Matrix;)Z", "GetSetSuppMatrix_Landroid_graphics_Matrix_Handler")]
	public unsafe virtual bool SetSuppMatrix(Matrix matrix)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(matrix?.Handle ?? IntPtr.Zero);
		bool result = _members.InstanceMethods.InvokeVirtualBooleanMethod("setSuppMatrix.(Landroid/graphics/Matrix;)Z", this, ptr);
		GC.KeepAlive(matrix);
		return result;
	}

	private static Delegate GetSetZoomTransitionDuration_IHandler()
	{
		if ((object)cb_setZoomTransitionDuration_I == null)
		{
			cb_setZoomTransitionDuration_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetZoomTransitionDuration_I));
		}
		return cb_setZoomTransitionDuration_I;
	}

	private static void n_SetZoomTransitionDuration_I(IntPtr jnienv, IntPtr native__this, int milliseconds)
	{
		Java.Lang.Object.GetObject<PhotoView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetZoomTransitionDuration(milliseconds);
	}

	[Register("setZoomTransitionDuration", "(I)V", "GetSetZoomTransitionDuration_IHandler")]
	public unsafe virtual void SetZoomTransitionDuration(int milliseconds)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(milliseconds);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setZoomTransitionDuration.(I)V", this, ptr);
	}

	private IOnMatrixChangedListenerImplementor __CreateIOnMatrixChangedListenerImplementor()
	{
		return new IOnMatrixChangedListenerImplementor(this);
	}

	private IOnOutsidePhotoTapListenerImplementor __CreateIOnOutsidePhotoTapListenerImplementor()
	{
		return new IOnOutsidePhotoTapListenerImplementor(this);
	}

	private IOnPhotoTapListenerImplementor __CreateIOnPhotoTapListenerImplementor()
	{
		return new IOnPhotoTapListenerImplementor(this);
	}

	private IOnScaleChangedListenerImplementor __CreateIOnScaleChangedListenerImplementor()
	{
		return new IOnScaleChangedListenerImplementor(this);
	}

	private IOnSingleFlingListenerImplementor __CreateIOnSingleFlingListenerImplementor()
	{
		return new IOnSingleFlingListenerImplementor(this);
	}

	private IOnViewDragListenerImplementor __CreateIOnViewDragListenerImplementor()
	{
		return new IOnViewDragListenerImplementor(this);
	}

	private IOnViewTapListenerImplementor __CreateIOnViewTapListenerImplementor()
	{
		return new IOnViewTapListenerImplementor(this);
	}
}
