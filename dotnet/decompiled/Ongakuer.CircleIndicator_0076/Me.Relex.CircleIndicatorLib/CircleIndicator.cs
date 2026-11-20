using System;
using Android.Animation;
using Android.Content;
using Android.Database;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using AndroidX.ViewPager.Widget;
using Java.Interop;
using Java.Lang;

namespace Me.Relex.CircleIndicatorLib;

[Register("me/relex/circleindicator/CircleIndicator", DoNotGenerateAcw = true)]
public class CircleIndicator : LinearLayout
{
	internal static readonly JniPeerMembers _members = new XAPeerMembers("me/relex/circleindicator/CircleIndicator", typeof(CircleIndicator));

	private static Delegate cb_getDataSetObserver;

	private static Delegate cb_animatePageSelected_I;

	private static Delegate cb_createIndicators_II;

	private static Delegate cb_initialize_Lme_relex_circleindicator_Config_;

	private static Delegate cb_setOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_;

	private static Delegate cb_setViewPager_Landroidx_viewpager_widget_ViewPager_;

	private static Delegate cb_addIndicator_I;

	private static Delegate cb_createAnimatorIn_Lme_relex_circleindicator_Config_;

	private static Delegate cb_createAnimatorOut_Lme_relex_circleindicator_Config_;

	internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual DataSetObserver DataSetObserver
	{
		[Register("getDataSetObserver", "()Landroid/database/DataSetObserver;", "GetGetDataSetObserverHandler")]
		get
		{
			return Java.Lang.Object.GetObject<DataSetObserver>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDataSetObserver.()Landroid/database/DataSetObserver;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected CircleIndicator(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe CircleIndicator(Context context)
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
	public unsafe CircleIndicator(Context context, IAttributeSet attrs)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
	public unsafe CircleIndicator(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyleAttr);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;II)V", "")]
	public unsafe CircleIndicator(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
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

	private static Delegate GetGetDataSetObserverHandler()
	{
		if ((object)cb_getDataSetObserver == null)
		{
			cb_getDataSetObserver = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetDataSetObserver));
		}
		return cb_getDataSetObserver;
	}

	private static IntPtr n_GetDataSetObserver(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CircleIndicator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DataSetObserver);
	}

	private static Delegate GetAnimatePageSelected_IHandler()
	{
		if ((object)cb_animatePageSelected_I == null)
		{
			cb_animatePageSelected_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_AnimatePageSelected_I));
		}
		return cb_animatePageSelected_I;
	}

	private static void n_AnimatePageSelected_I(IntPtr jnienv, IntPtr native__this, int position)
	{
		Java.Lang.Object.GetObject<CircleIndicator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnimatePageSelected(position);
	}

	[Register("animatePageSelected", "(I)V", "GetAnimatePageSelected_IHandler")]
	public unsafe virtual void AnimatePageSelected(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		_members.InstanceMethods.InvokeVirtualVoidMethod("animatePageSelected.(I)V", this, ptr);
	}

	private static Delegate GetCreateIndicators_IIHandler()
	{
		if ((object)cb_createIndicators_II == null)
		{
			cb_createIndicators_II = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int, int>(n_CreateIndicators_II));
		}
		return cb_createIndicators_II;
	}

	private static void n_CreateIndicators_II(IntPtr jnienv, IntPtr native__this, int count, int currentPosition)
	{
		Java.Lang.Object.GetObject<CircleIndicator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateIndicators(count, currentPosition);
	}

	[Register("createIndicators", "(II)V", "GetCreateIndicators_IIHandler")]
	public unsafe virtual void CreateIndicators(int count, int currentPosition)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(count);
		ptr[1] = new JniArgumentValue(currentPosition);
		_members.InstanceMethods.InvokeVirtualVoidMethod("createIndicators.(II)V", this, ptr);
	}

	private static Delegate GetInitialize_Lme_relex_circleindicator_Config_Handler()
	{
		if ((object)cb_initialize_Lme_relex_circleindicator_Config_ == null)
		{
			cb_initialize_Lme_relex_circleindicator_Config_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_Initialize_Lme_relex_circleindicator_Config_));
		}
		return cb_initialize_Lme_relex_circleindicator_Config_;
	}

	private static void n_Initialize_Lme_relex_circleindicator_Config_(IntPtr jnienv, IntPtr native__this, IntPtr native_config)
	{
		CircleIndicator? circleIndicator = Java.Lang.Object.GetObject<CircleIndicator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Config config = Java.Lang.Object.GetObject<Config>(native_config, JniHandleOwnership.DoNotTransfer);
		circleIndicator.Initialize(config);
	}

	[Register("initialize", "(Lme/relex/circleindicator/Config;)V", "GetInitialize_Lme_relex_circleindicator_Config_Handler")]
	public unsafe virtual void Initialize(Config config)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(config?.Handle ?? IntPtr.Zero);
		_members.InstanceMethods.InvokeVirtualVoidMethod("initialize.(Lme/relex/circleindicator/Config;)V", this, ptr);
		GC.KeepAlive(config);
	}

	[Obsolete]
	private static Delegate GetSetOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_Handler()
	{
		if ((object)cb_setOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_ == null)
		{
			cb_setOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_));
		}
		return cb_setOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_;
	}

	[Obsolete]
	private static void n_SetOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_onPageChangeListener)
	{
		CircleIndicator? circleIndicator = Java.Lang.Object.GetObject<CircleIndicator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ViewPager.IOnPageChangeListener onPageChangeListener = Java.Lang.Object.GetObject<ViewPager.IOnPageChangeListener>(native_onPageChangeListener, JniHandleOwnership.DoNotTransfer);
		circleIndicator.SetOnPageChangeListener(onPageChangeListener);
	}

	[Obsolete("deprecated")]
	[Register("setOnPageChangeListener", "(Landroidx/viewpager/widget/ViewPager$OnPageChangeListener;)V", "GetSetOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_Handler")]
	public unsafe virtual void SetOnPageChangeListener(ViewPager.IOnPageChangeListener onPageChangeListener)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((onPageChangeListener == null) ? IntPtr.Zero : ((Java.Lang.Object)onPageChangeListener).Handle);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setOnPageChangeListener.(Landroidx/viewpager/widget/ViewPager$OnPageChangeListener;)V", this, ptr);
		GC.KeepAlive(onPageChangeListener);
	}

	private static Delegate GetSetViewPager_Landroidx_viewpager_widget_ViewPager_Handler()
	{
		if ((object)cb_setViewPager_Landroidx_viewpager_widget_ViewPager_ == null)
		{
			cb_setViewPager_Landroidx_viewpager_widget_ViewPager_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetViewPager_Landroidx_viewpager_widget_ViewPager_));
		}
		return cb_setViewPager_Landroidx_viewpager_widget_ViewPager_;
	}

	private static void n_SetViewPager_Landroidx_viewpager_widget_ViewPager_(IntPtr jnienv, IntPtr native__this, IntPtr native_viewPager)
	{
		CircleIndicator? circleIndicator = Java.Lang.Object.GetObject<CircleIndicator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ViewPager viewPager = Java.Lang.Object.GetObject<ViewPager>(native_viewPager, JniHandleOwnership.DoNotTransfer);
		circleIndicator.SetViewPager(viewPager);
	}

	[Register("setViewPager", "(Landroidx/viewpager/widget/ViewPager;)V", "GetSetViewPager_Landroidx_viewpager_widget_ViewPager_Handler")]
	public unsafe virtual void SetViewPager(ViewPager viewPager)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(viewPager?.Handle ?? IntPtr.Zero);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setViewPager.(Landroidx/viewpager/widget/ViewPager;)V", this, ptr);
		GC.KeepAlive(viewPager);
	}

	private static Delegate GetAddIndicator_IHandler()
	{
		if ((object)cb_addIndicator_I == null)
		{
			cb_addIndicator_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_AddIndicator_I));
		}
		return cb_addIndicator_I;
	}

	private static void n_AddIndicator_I(IntPtr jnienv, IntPtr native__this, int orientation)
	{
		Java.Lang.Object.GetObject<CircleIndicator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AddIndicator(orientation);
	}

	[Register("addIndicator", "(I)V", "GetAddIndicator_IHandler")]
	protected unsafe virtual void AddIndicator(int orientation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(orientation);
		_members.InstanceMethods.InvokeVirtualVoidMethod("addIndicator.(I)V", this, ptr);
	}

	private static Delegate GetCreateAnimatorIn_Lme_relex_circleindicator_Config_Handler()
	{
		if ((object)cb_createAnimatorIn_Lme_relex_circleindicator_Config_ == null)
		{
			cb_createAnimatorIn_Lme_relex_circleindicator_Config_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr>(n_CreateAnimatorIn_Lme_relex_circleindicator_Config_));
		}
		return cb_createAnimatorIn_Lme_relex_circleindicator_Config_;
	}

	private static IntPtr n_CreateAnimatorIn_Lme_relex_circleindicator_Config_(IntPtr jnienv, IntPtr native__this, IntPtr native_config)
	{
		CircleIndicator? circleIndicator = Java.Lang.Object.GetObject<CircleIndicator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Config config = Java.Lang.Object.GetObject<Config>(native_config, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(circleIndicator.CreateAnimatorIn(config));
	}

	[Register("createAnimatorIn", "(Lme/relex/circleindicator/Config;)Landroid/animation/Animator;", "GetCreateAnimatorIn_Lme_relex_circleindicator_Config_Handler")]
	protected unsafe virtual Animator CreateAnimatorIn(Config config)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(config?.Handle ?? IntPtr.Zero);
		Animator? result = Java.Lang.Object.GetObject<Animator>(_members.InstanceMethods.InvokeVirtualObjectMethod("createAnimatorIn.(Lme/relex/circleindicator/Config;)Landroid/animation/Animator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		GC.KeepAlive(config);
		return result;
	}

	private static Delegate GetCreateAnimatorOut_Lme_relex_circleindicator_Config_Handler()
	{
		if ((object)cb_createAnimatorOut_Lme_relex_circleindicator_Config_ == null)
		{
			cb_createAnimatorOut_Lme_relex_circleindicator_Config_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr>(n_CreateAnimatorOut_Lme_relex_circleindicator_Config_));
		}
		return cb_createAnimatorOut_Lme_relex_circleindicator_Config_;
	}

	private static IntPtr n_CreateAnimatorOut_Lme_relex_circleindicator_Config_(IntPtr jnienv, IntPtr native__this, IntPtr native_config)
	{
		CircleIndicator? circleIndicator = Java.Lang.Object.GetObject<CircleIndicator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Config config = Java.Lang.Object.GetObject<Config>(native_config, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(circleIndicator.CreateAnimatorOut(config));
	}

	[Register("createAnimatorOut", "(Lme/relex/circleindicator/Config;)Landroid/animation/Animator;", "GetCreateAnimatorOut_Lme_relex_circleindicator_Config_Handler")]
	protected unsafe virtual Animator CreateAnimatorOut(Config config)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(config?.Handle ?? IntPtr.Zero);
		Animator? result = Java.Lang.Object.GetObject<Animator>(_members.InstanceMethods.InvokeVirtualObjectMethod("createAnimatorOut.(Lme/relex/circleindicator/Config;)Landroid/animation/Animator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		GC.KeepAlive(config);
		return result;
	}
}
