using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ViewPager.Widget;

[Register("androidx/viewpager/widget/PagerAdapter", DoNotGenerateAcw = true)]
internal class PagerAdapterInvoker : PagerAdapter
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/viewpager/widget/PagerAdapter", typeof(PagerAdapterInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override int Count
	{
		[Register("getCount", "()I", "GetGetCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getCount.()I", this, null);
		}
	}

	public PagerAdapterInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("isViewFromObject", "(Landroid/view/View;Ljava/lang/Object;)Z", "GetIsViewFromObject_Landroid_view_View_Ljava_lang_Object_Handler")]
	public unsafe override bool IsViewFromObject(View view, Java.Lang.Object @object)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(@object?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isViewFromObject.(Landroid/view/View;Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(@object);
		}
	}
}
