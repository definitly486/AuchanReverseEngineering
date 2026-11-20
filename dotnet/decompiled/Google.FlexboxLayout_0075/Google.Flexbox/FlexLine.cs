using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Google.Flexbox;

[Register("com/google/android/flexbox/FlexLine", DoNotGenerateAcw = true)]
public class FlexLine : Java.Lang.Object
{
	internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/flexbox/FlexLine", typeof(FlexLine));

	private static Delegate cb_getCrossSize;

	private static Delegate cb_getFirstIndex;

	private static Delegate cb_getItemCount;

	private static Delegate cb_getItemCountNotGone;

	private static Delegate cb_getMainSize;

	private static Delegate cb_getTotalFlexGrow;

	private static Delegate cb_getTotalFlexShrink;

	internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual int CrossSize
	{
		[Register("getCrossSize", "()I", "GetGetCrossSizeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getCrossSize.()I", this, null);
		}
	}

	public unsafe virtual int FirstIndex
	{
		[Register("getFirstIndex", "()I", "GetGetFirstIndexHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getFirstIndex.()I", this, null);
		}
	}

	public unsafe virtual int ItemCount
	{
		[Register("getItemCount", "()I", "GetGetItemCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getItemCount.()I", this, null);
		}
	}

	public unsafe virtual int ItemCountNotGone
	{
		[Register("getItemCountNotGone", "()I", "GetGetItemCountNotGoneHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getItemCountNotGone.()I", this, null);
		}
	}

	public unsafe virtual int MainSize
	{
		[Register("getMainSize", "()I", "GetGetMainSizeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMainSize.()I", this, null);
		}
	}

	public unsafe virtual float TotalFlexGrow
	{
		[Register("getTotalFlexGrow", "()F", "GetGetTotalFlexGrowHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getTotalFlexGrow.()F", this, null);
		}
	}

	public unsafe virtual float TotalFlexShrink
	{
		[Register("getTotalFlexShrink", "()F", "GetGetTotalFlexShrinkHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getTotalFlexShrink.()F", this, null);
		}
	}

	protected FlexLine(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetCrossSizeHandler()
	{
		if ((object)cb_getCrossSize == null)
		{
			cb_getCrossSize = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetCrossSize));
		}
		return cb_getCrossSize;
	}

	private static int n_GetCrossSize(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FlexLine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CrossSize;
	}

	private static Delegate GetGetFirstIndexHandler()
	{
		if ((object)cb_getFirstIndex == null)
		{
			cb_getFirstIndex = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetFirstIndex));
		}
		return cb_getFirstIndex;
	}

	private static int n_GetFirstIndex(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FlexLine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FirstIndex;
	}

	private static Delegate GetGetItemCountHandler()
	{
		if ((object)cb_getItemCount == null)
		{
			cb_getItemCount = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetItemCount));
		}
		return cb_getItemCount;
	}

	private static int n_GetItemCount(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FlexLine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemCount;
	}

	private static Delegate GetGetItemCountNotGoneHandler()
	{
		if ((object)cb_getItemCountNotGone == null)
		{
			cb_getItemCountNotGone = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetItemCountNotGone));
		}
		return cb_getItemCountNotGone;
	}

	private static int n_GetItemCountNotGone(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FlexLine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemCountNotGone;
	}

	private static Delegate GetGetMainSizeHandler()
	{
		if ((object)cb_getMainSize == null)
		{
			cb_getMainSize = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetMainSize));
		}
		return cb_getMainSize;
	}

	private static int n_GetMainSize(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FlexLine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MainSize;
	}

	private static Delegate GetGetTotalFlexGrowHandler()
	{
		if ((object)cb_getTotalFlexGrow == null)
		{
			cb_getTotalFlexGrow = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, float>(n_GetTotalFlexGrow));
		}
		return cb_getTotalFlexGrow;
	}

	private static float n_GetTotalFlexGrow(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FlexLine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TotalFlexGrow;
	}

	private static Delegate GetGetTotalFlexShrinkHandler()
	{
		if ((object)cb_getTotalFlexShrink == null)
		{
			cb_getTotalFlexShrink = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, float>(n_GetTotalFlexShrink));
		}
		return cb_getTotalFlexShrink;
	}

	private static float n_GetTotalFlexShrink(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FlexLine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TotalFlexShrink;
	}
}
