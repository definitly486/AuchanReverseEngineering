using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;

namespace Android.Views.Animations;

[Register("android/view/animation/BaseInterpolator", DoNotGenerateAcw = true, ApiSince = 22)]
[SupportedOSPlatform("android22.0")]
internal class BaseInterpolatorInvoker : BaseInterpolator
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/animation/BaseInterpolator", typeof(BaseInterpolatorInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public BaseInterpolatorInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	public unsafe override float GetInterpolation(float input)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(input);
		return _members.InstanceMethods.InvokeAbstractSingleMethod("getInterpolation.(F)F", this, ptr);
	}
}
