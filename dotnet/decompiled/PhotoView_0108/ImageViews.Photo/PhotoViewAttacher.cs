using System;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using Java.Interop;
using Java.Lang;

namespace ImageViews.Photo;

[Register("com/github/chrisbanes/photoview/PhotoViewAttacher", DoNotGenerateAcw = true)]
public class PhotoViewAttacher : Java.Lang.Object, View.IOnLayoutChangeListener, IJavaObject, IDisposable, View.IOnTouchListener
{
	internal static readonly JniPeerMembers _members = new XAPeerMembers("com/github/chrisbanes/photoview/PhotoViewAttacher", typeof(PhotoViewAttacher));

	private static Delegate cb_getDisplayRect;

	private static Delegate cb_getImageMatrix;

	private static Delegate cb_isZoomEnabled;

	private static Delegate cb_getMaximumScale;

	private static Delegate cb_setMaximumScale_F;

	private static Delegate cb_getMediumScale;

	private static Delegate cb_setMediumScale_F;

	private static Delegate cb_getMinimumScale;

	private static Delegate cb_setMinimumScale_F;

	private static Delegate cb_getScale;

	private static Delegate cb_setScale_F;

	private static Delegate cb_getScaleType;

	private static Delegate cb_setScaleType_Landroid_widget_ImageView_ScaleType_;

	private static Delegate cb_isZoomable;

	private static Delegate cb_setZoomable_Z;

	private static Delegate cb_getDisplayMatrix_Landroid_graphics_Matrix_;

	private static Delegate cb_getSuppMatrix_Landroid_graphics_Matrix_;

	private static Delegate cb_onLayoutChange_Landroid_view_View_IIIIIIII;

	private static Delegate cb_onTouch_Landroid_view_View_Landroid_view_MotionEvent_;

	private static Delegate cb_setAllowParentInterceptOnEdge_Z;

	private static Delegate cb_setBaseRotation_F;

	private static Delegate cb_setDisplayMatrix_Landroid_graphics_Matrix_;

	private static Delegate cb_setOnClickListener_Landroid_view_View_OnClickListener_;

	private static Delegate cb_setOnDoubleTapListener_Landroid_view_GestureDetector_OnDoubleTapListener_;

	private static Delegate cb_setOnLongClickListener_Landroid_view_View_OnLongClickListener_;

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

	private static Delegate cb_setZoomInterpolator_Landroid_view_animation_Interpolator_;

	private static Delegate cb_setZoomTransitionDuration_I;

	private static Delegate cb_update;

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
	}

	internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual RectF DisplayRect
	{
		[Register("getDisplayRect", "()Landroid/graphics/RectF;", "GetGetDisplayRectHandler")]
		get
		{
			return Java.Lang.Object.GetObject<RectF>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDisplayRect.()Landroid/graphics/RectF;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Matrix ImageMatrix
	{
		[Register("getImageMatrix", "()Landroid/graphics/Matrix;", "GetGetImageMatrixHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Matrix>(_members.InstanceMethods.InvokeVirtualObjectMethod("getImageMatrix.()Landroid/graphics/Matrix;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

	public unsafe virtual ImageView.ScaleType ScaleType
	{
		[Register("getScaleType", "()Landroid/widget/ImageView$ScaleType;", "GetGetScaleTypeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ImageView.ScaleType>(_members.InstanceMethods.InvokeVirtualObjectMethod("getScaleType.()Landroid/widget/ImageView$ScaleType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setScaleType", "(Landroid/widget/ImageView$ScaleType;)V", "GetSetScaleType_Landroid_widget_ImageView_ScaleType_Handler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setScaleType.(Landroid/widget/ImageView$ScaleType;)V", this, ptr);
			GC.KeepAlive(value);
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

	protected PhotoViewAttacher(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/widget/ImageView;)V", "")]
	public unsafe PhotoViewAttacher(ImageView imageView)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(imageView?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/widget/ImageView;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/widget/ImageView;)V", this, ptr);
			GC.KeepAlive(imageView);
		}
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
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DisplayRect);
	}

	private static Delegate GetGetImageMatrixHandler()
	{
		if ((object)cb_getImageMatrix == null)
		{
			cb_getImageMatrix = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetImageMatrix));
		}
		return cb_getImageMatrix;
	}

	private static IntPtr n_GetImageMatrix(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageMatrix);
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
		return Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsZoomEnabled;
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
		return Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaximumScale;
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
		Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaximumScale = maximumScale;
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
		return Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MediumScale;
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
		Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MediumScale = mediumScale;
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
		return Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinimumScale;
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
		Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinimumScale = minimumScale;
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
		return Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Scale;
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
		Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Scale = scale;
	}

	private static Delegate GetGetScaleTypeHandler()
	{
		if ((object)cb_getScaleType == null)
		{
			cb_getScaleType = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetScaleType));
		}
		return cb_getScaleType;
	}

	private static IntPtr n_GetScaleType(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ScaleType);
	}

	private static Delegate GetSetScaleType_Landroid_widget_ImageView_ScaleType_Handler()
	{
		if ((object)cb_setScaleType_Landroid_widget_ImageView_ScaleType_ == null)
		{
			cb_setScaleType_Landroid_widget_ImageView_ScaleType_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetScaleType_Landroid_widget_ImageView_ScaleType_));
		}
		return cb_setScaleType_Landroid_widget_ImageView_ScaleType_;
	}

	private static void n_SetScaleType_Landroid_widget_ImageView_ScaleType_(IntPtr jnienv, IntPtr native__this, IntPtr native_scaleType)
	{
		PhotoViewAttacher? photoViewAttacher = Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ImageView.ScaleType scaleType = Java.Lang.Object.GetObject<ImageView.ScaleType>(native_scaleType, JniHandleOwnership.DoNotTransfer);
		photoViewAttacher.ScaleType = scaleType;
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
		return Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Zoomable;
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
		Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Zoomable = zoomable;
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
		PhotoViewAttacher? photoViewAttacher = Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Matrix matrix = Java.Lang.Object.GetObject<Matrix>(native_matrix, JniHandleOwnership.DoNotTransfer);
		photoViewAttacher.GetDisplayMatrix(matrix);
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
		PhotoViewAttacher? photoViewAttacher = Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Matrix matrix = Java.Lang.Object.GetObject<Matrix>(native_matrix, JniHandleOwnership.DoNotTransfer);
		photoViewAttacher.GetSuppMatrix(matrix);
	}

	[Register("getSuppMatrix", "(Landroid/graphics/Matrix;)V", "GetGetSuppMatrix_Landroid_graphics_Matrix_Handler")]
	public unsafe virtual void GetSuppMatrix(Matrix matrix)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(matrix?.Handle ?? IntPtr.Zero);
		_members.InstanceMethods.InvokeVirtualVoidMethod("getSuppMatrix.(Landroid/graphics/Matrix;)V", this, ptr);
		GC.KeepAlive(matrix);
	}

	private static Delegate GetOnLayoutChange_Landroid_view_View_IIIIIIIIHandler()
	{
		if ((object)cb_onLayoutChange_Landroid_view_View_IIIIIIII == null)
		{
			cb_onLayoutChange_Landroid_view_View_IIIIIIII = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, int, int, int, int, int, int, int, int>(n_OnLayoutChange_Landroid_view_View_IIIIIIII));
		}
		return cb_onLayoutChange_Landroid_view_View_IIIIIIII;
	}

	private static void n_OnLayoutChange_Landroid_view_View_IIIIIIII(IntPtr jnienv, IntPtr native__this, IntPtr native_v, int left, int top, int right, int bottom, int oldLeft, int oldTop, int oldRight, int oldBottom)
	{
		PhotoViewAttacher? photoViewAttacher = Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View v = Java.Lang.Object.GetObject<View>(native_v, JniHandleOwnership.DoNotTransfer);
		photoViewAttacher.OnLayoutChange(v, left, top, right, bottom, oldLeft, oldTop, oldRight, oldBottom);
	}

	[Register("onLayoutChange", "(Landroid/view/View;IIIIIIII)V", "GetOnLayoutChange_Landroid_view_View_IIIIIIIIHandler")]
	public unsafe virtual void OnLayoutChange(View v, int left, int top, int right, int bottom, int oldLeft, int oldTop, int oldRight, int oldBottom)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[9];
		*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
		ptr[1] = new JniArgumentValue(left);
		ptr[2] = new JniArgumentValue(top);
		ptr[3] = new JniArgumentValue(right);
		ptr[4] = new JniArgumentValue(bottom);
		ptr[5] = new JniArgumentValue(oldLeft);
		ptr[6] = new JniArgumentValue(oldTop);
		ptr[7] = new JniArgumentValue(oldRight);
		ptr[8] = new JniArgumentValue(oldBottom);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onLayoutChange.(Landroid/view/View;IIIIIIII)V", this, ptr);
		GC.KeepAlive(v);
	}

	private static Delegate GetOnTouch_Landroid_view_View_Landroid_view_MotionEvent_Handler()
	{
		if ((object)cb_onTouch_Landroid_view_View_Landroid_view_MotionEvent_ == null)
		{
			cb_onTouch_Landroid_view_View_Landroid_view_MotionEvent_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr, bool>(n_OnTouch_Landroid_view_View_Landroid_view_MotionEvent_));
		}
		return cb_onTouch_Landroid_view_View_Landroid_view_MotionEvent_;
	}

	private static bool n_OnTouch_Landroid_view_View_Landroid_view_MotionEvent_(IntPtr jnienv, IntPtr native__this, IntPtr native_v, IntPtr native_ev)
	{
		PhotoViewAttacher? photoViewAttacher = Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View v = Java.Lang.Object.GetObject<View>(native_v, JniHandleOwnership.DoNotTransfer);
		MotionEvent ev = Java.Lang.Object.GetObject<MotionEvent>(native_ev, JniHandleOwnership.DoNotTransfer);
		return photoViewAttacher.OnTouch(v, ev);
	}

	[Register("onTouch", "(Landroid/view/View;Landroid/view/MotionEvent;)Z", "GetOnTouch_Landroid_view_View_Landroid_view_MotionEvent_Handler")]
	public unsafe virtual bool OnTouch(View v, MotionEvent ev)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
		ptr[1] = new JniArgumentValue(ev?.Handle ?? IntPtr.Zero);
		bool result = _members.InstanceMethods.InvokeVirtualBooleanMethod("onTouch.(Landroid/view/View;Landroid/view/MotionEvent;)Z", this, ptr);
		GC.KeepAlive(v);
		GC.KeepAlive(ev);
		return result;
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
		Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetAllowParentInterceptOnEdge(allow);
	}

	[Register("setAllowParentInterceptOnEdge", "(Z)V", "GetSetAllowParentInterceptOnEdge_ZHandler")]
	public unsafe virtual void SetAllowParentInterceptOnEdge(bool allow)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(allow);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setAllowParentInterceptOnEdge.(Z)V", this, ptr);
	}

	private static Delegate GetSetBaseRotation_FHandler()
	{
		if ((object)cb_setBaseRotation_F == null)
		{
			cb_setBaseRotation_F = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, float>(n_SetBaseRotation_F));
		}
		return cb_setBaseRotation_F;
	}

	private static void n_SetBaseRotation_F(IntPtr jnienv, IntPtr native__this, float degrees)
	{
		Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetBaseRotation(degrees);
	}

	[Register("setBaseRotation", "(F)V", "GetSetBaseRotation_FHandler")]
	public unsafe virtual void SetBaseRotation(float degrees)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(degrees);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setBaseRotation.(F)V", this, ptr);
	}

	private static Delegate GetSetDisplayMatrix_Landroid_graphics_Matrix_Handler()
	{
		if ((object)cb_setDisplayMatrix_Landroid_graphics_Matrix_ == null)
		{
			cb_setDisplayMatrix_Landroid_graphics_Matrix_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, bool>(n_SetDisplayMatrix_Landroid_graphics_Matrix_));
		}
		return cb_setDisplayMatrix_Landroid_graphics_Matrix_;
	}

	private static bool n_SetDisplayMatrix_Landroid_graphics_Matrix_(IntPtr jnienv, IntPtr native__this, IntPtr native_finalMatrix)
	{
		PhotoViewAttacher? photoViewAttacher = Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Matrix displayMatrix = Java.Lang.Object.GetObject<Matrix>(native_finalMatrix, JniHandleOwnership.DoNotTransfer);
		return photoViewAttacher.SetDisplayMatrix(displayMatrix);
	}

	[Register("setDisplayMatrix", "(Landroid/graphics/Matrix;)Z", "GetSetDisplayMatrix_Landroid_graphics_Matrix_Handler")]
	public unsafe virtual bool SetDisplayMatrix(Matrix finalMatrix)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(finalMatrix?.Handle ?? IntPtr.Zero);
		bool result = _members.InstanceMethods.InvokeVirtualBooleanMethod("setDisplayMatrix.(Landroid/graphics/Matrix;)Z", this, ptr);
		GC.KeepAlive(finalMatrix);
		return result;
	}

	private static Delegate GetSetOnClickListener_Landroid_view_View_OnClickListener_Handler()
	{
		if ((object)cb_setOnClickListener_Landroid_view_View_OnClickListener_ == null)
		{
			cb_setOnClickListener_Landroid_view_View_OnClickListener_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetOnClickListener_Landroid_view_View_OnClickListener_));
		}
		return cb_setOnClickListener_Landroid_view_View_OnClickListener_;
	}

	private static void n_SetOnClickListener_Landroid_view_View_OnClickListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
	{
		PhotoViewAttacher? photoViewAttacher = Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View.IOnClickListener onClickListener = Java.Lang.Object.GetObject<View.IOnClickListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		photoViewAttacher.SetOnClickListener(onClickListener);
	}

	[Register("setOnClickListener", "(Landroid/view/View$OnClickListener;)V", "GetSetOnClickListener_Landroid_view_View_OnClickListener_Handler")]
	public unsafe virtual void SetOnClickListener(View.IOnClickListener listener)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setOnClickListener.(Landroid/view/View$OnClickListener;)V", this, ptr);
		GC.KeepAlive(listener);
	}

	private static Delegate GetSetOnDoubleTapListener_Landroid_view_GestureDetector_OnDoubleTapListener_Handler()
	{
		if ((object)cb_setOnDoubleTapListener_Landroid_view_GestureDetector_OnDoubleTapListener_ == null)
		{
			cb_setOnDoubleTapListener_Landroid_view_GestureDetector_OnDoubleTapListener_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetOnDoubleTapListener_Landroid_view_GestureDetector_OnDoubleTapListener_));
		}
		return cb_setOnDoubleTapListener_Landroid_view_GestureDetector_OnDoubleTapListener_;
	}

	private static void n_SetOnDoubleTapListener_Landroid_view_GestureDetector_OnDoubleTapListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_newOnDoubleTapListener)
	{
		PhotoViewAttacher? photoViewAttacher = Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		GestureDetector.IOnDoubleTapListener onDoubleTapListener = Java.Lang.Object.GetObject<GestureDetector.IOnDoubleTapListener>(native_newOnDoubleTapListener, JniHandleOwnership.DoNotTransfer);
		photoViewAttacher.SetOnDoubleTapListener(onDoubleTapListener);
	}

	[Register("setOnDoubleTapListener", "(Landroid/view/GestureDetector$OnDoubleTapListener;)V", "GetSetOnDoubleTapListener_Landroid_view_GestureDetector_OnDoubleTapListener_Handler")]
	public unsafe virtual void SetOnDoubleTapListener(GestureDetector.IOnDoubleTapListener newOnDoubleTapListener)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((newOnDoubleTapListener == null) ? IntPtr.Zero : ((Java.Lang.Object)newOnDoubleTapListener).Handle);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setOnDoubleTapListener.(Landroid/view/GestureDetector$OnDoubleTapListener;)V", this, ptr);
		GC.KeepAlive(newOnDoubleTapListener);
	}

	private static Delegate GetSetOnLongClickListener_Landroid_view_View_OnLongClickListener_Handler()
	{
		if ((object)cb_setOnLongClickListener_Landroid_view_View_OnLongClickListener_ == null)
		{
			cb_setOnLongClickListener_Landroid_view_View_OnLongClickListener_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetOnLongClickListener_Landroid_view_View_OnLongClickListener_));
		}
		return cb_setOnLongClickListener_Landroid_view_View_OnLongClickListener_;
	}

	private static void n_SetOnLongClickListener_Landroid_view_View_OnLongClickListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
	{
		PhotoViewAttacher? photoViewAttacher = Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View.IOnLongClickListener onLongClickListener = Java.Lang.Object.GetObject<View.IOnLongClickListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		photoViewAttacher.SetOnLongClickListener(onLongClickListener);
	}

	[Register("setOnLongClickListener", "(Landroid/view/View$OnLongClickListener;)V", "GetSetOnLongClickListener_Landroid_view_View_OnLongClickListener_Handler")]
	public unsafe virtual void SetOnLongClickListener(View.IOnLongClickListener listener)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setOnLongClickListener.(Landroid/view/View$OnLongClickListener;)V", this, ptr);
		GC.KeepAlive(listener);
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
		PhotoViewAttacher? photoViewAttacher = Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnMatrixChangedListener onMatrixChangeListener = Java.Lang.Object.GetObject<IOnMatrixChangedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		photoViewAttacher.SetOnMatrixChangeListener(onMatrixChangeListener);
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

	private static void n_SetOnOutsidePhotoTapListener_Lcom_github_chrisbanes_photoview_OnOutsidePhotoTapListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_mOutsidePhotoTapListener)
	{
		PhotoViewAttacher? photoViewAttacher = Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnOutsidePhotoTapListener onOutsidePhotoTapListener = Java.Lang.Object.GetObject<IOnOutsidePhotoTapListener>(native_mOutsidePhotoTapListener, JniHandleOwnership.DoNotTransfer);
		photoViewAttacher.SetOnOutsidePhotoTapListener(onOutsidePhotoTapListener);
	}

	[Register("setOnOutsidePhotoTapListener", "(Lcom/github/chrisbanes/photoview/OnOutsidePhotoTapListener;)V", "GetSetOnOutsidePhotoTapListener_Lcom_github_chrisbanes_photoview_OnOutsidePhotoTapListener_Handler")]
	public unsafe virtual void SetOnOutsidePhotoTapListener(IOnOutsidePhotoTapListener mOutsidePhotoTapListener)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((mOutsidePhotoTapListener == null) ? IntPtr.Zero : ((Java.Lang.Object)mOutsidePhotoTapListener).Handle);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setOnOutsidePhotoTapListener.(Lcom/github/chrisbanes/photoview/OnOutsidePhotoTapListener;)V", this, ptr);
		GC.KeepAlive(mOutsidePhotoTapListener);
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
		PhotoViewAttacher? photoViewAttacher = Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnPhotoTapListener onPhotoTapListener = Java.Lang.Object.GetObject<IOnPhotoTapListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		photoViewAttacher.SetOnPhotoTapListener(onPhotoTapListener);
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

	private static void n_SetOnScaleChangeListener_Lcom_github_chrisbanes_photoview_OnScaleChangedListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_onScaleChangeListener)
	{
		PhotoViewAttacher? photoViewAttacher = Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnScaleChangedListener onScaleChangeListener = Java.Lang.Object.GetObject<IOnScaleChangedListener>(native_onScaleChangeListener, JniHandleOwnership.DoNotTransfer);
		photoViewAttacher.SetOnScaleChangeListener(onScaleChangeListener);
	}

	[Register("setOnScaleChangeListener", "(Lcom/github/chrisbanes/photoview/OnScaleChangedListener;)V", "GetSetOnScaleChangeListener_Lcom_github_chrisbanes_photoview_OnScaleChangedListener_Handler")]
	public unsafe virtual void SetOnScaleChangeListener(IOnScaleChangedListener onScaleChangeListener)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((onScaleChangeListener == null) ? IntPtr.Zero : ((Java.Lang.Object)onScaleChangeListener).Handle);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setOnScaleChangeListener.(Lcom/github/chrisbanes/photoview/OnScaleChangedListener;)V", this, ptr);
		GC.KeepAlive(onScaleChangeListener);
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
		PhotoViewAttacher? photoViewAttacher = Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnSingleFlingListener onSingleFlingListener = Java.Lang.Object.GetObject<IOnSingleFlingListener>(native_onSingleFlingListener, JniHandleOwnership.DoNotTransfer);
		photoViewAttacher.SetOnSingleFlingListener(onSingleFlingListener);
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
		PhotoViewAttacher? photoViewAttacher = Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnViewDragListener onViewDragListener = Java.Lang.Object.GetObject<IOnViewDragListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		photoViewAttacher.SetOnViewDragListener(onViewDragListener);
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
		PhotoViewAttacher? photoViewAttacher = Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnViewTapListener onViewTapListener = Java.Lang.Object.GetObject<IOnViewTapListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		photoViewAttacher.SetOnViewTapListener(onViewTapListener);
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

	private static void n_SetRotationBy_F(IntPtr jnienv, IntPtr native__this, float degrees)
	{
		Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetRotationBy(degrees);
	}

	[Register("setRotationBy", "(F)V", "GetSetRotationBy_FHandler")]
	public unsafe virtual void SetRotationBy(float degrees)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(degrees);
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

	private static void n_SetRotationTo_F(IntPtr jnienv, IntPtr native__this, float degrees)
	{
		Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetRotationTo(degrees);
	}

	[Register("setRotationTo", "(F)V", "GetSetRotationTo_FHandler")]
	public unsafe virtual void SetRotationTo(float degrees)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(degrees);
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
		Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetScale(scale, animate);
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
		Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetScale(scale, focalX, focalY, animate);
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
		Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetScaleLevels(minimumScale, mediumScale, maximumScale);
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

	private static Delegate GetSetZoomInterpolator_Landroid_view_animation_Interpolator_Handler()
	{
		if ((object)cb_setZoomInterpolator_Landroid_view_animation_Interpolator_ == null)
		{
			cb_setZoomInterpolator_Landroid_view_animation_Interpolator_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetZoomInterpolator_Landroid_view_animation_Interpolator_));
		}
		return cb_setZoomInterpolator_Landroid_view_animation_Interpolator_;
	}

	private static void n_SetZoomInterpolator_Landroid_view_animation_Interpolator_(IntPtr jnienv, IntPtr native__this, IntPtr native_interpolator)
	{
		PhotoViewAttacher? photoViewAttacher = Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IInterpolator zoomInterpolator = Java.Lang.Object.GetObject<IInterpolator>(native_interpolator, JniHandleOwnership.DoNotTransfer);
		photoViewAttacher.SetZoomInterpolator(zoomInterpolator);
	}

	[Register("setZoomInterpolator", "(Landroid/view/animation/Interpolator;)V", "GetSetZoomInterpolator_Landroid_view_animation_Interpolator_Handler")]
	public unsafe virtual void SetZoomInterpolator(IInterpolator interpolator)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((interpolator == null) ? IntPtr.Zero : ((Java.Lang.Object)interpolator).Handle);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setZoomInterpolator.(Landroid/view/animation/Interpolator;)V", this, ptr);
		GC.KeepAlive(interpolator);
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
		Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetZoomTransitionDuration(milliseconds);
	}

	[Register("setZoomTransitionDuration", "(I)V", "GetSetZoomTransitionDuration_IHandler")]
	public unsafe virtual void SetZoomTransitionDuration(int milliseconds)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(milliseconds);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setZoomTransitionDuration.(I)V", this, ptr);
	}

	private static Delegate GetUpdateHandler()
	{
		if ((object)cb_update == null)
		{
			cb_update = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_Update));
		}
		return cb_update;
	}

	private static void n_Update(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<PhotoViewAttacher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Update();
	}

	[Register("update", "()V", "GetUpdateHandler")]
	public unsafe virtual void Update()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("update.()V", this, null);
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
