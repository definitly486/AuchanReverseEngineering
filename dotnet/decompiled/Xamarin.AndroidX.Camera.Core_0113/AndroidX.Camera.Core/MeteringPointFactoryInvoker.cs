using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/MeteringPointFactory", DoNotGenerateAcw = true)]
internal class MeteringPointFactoryInvoker : MeteringPointFactory
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/MeteringPointFactory", typeof(MeteringPointFactoryInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public MeteringPointFactoryInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("convertPoint", "(FF)Landroid/graphics/PointF;", "GetConvertPoint_FFHandler")]
	protected unsafe override PointF ConvertPoint(float p0, float p1)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(p0);
		ptr[1] = new JniArgumentValue(p1);
		return Java.Lang.Object.GetObject<PointF>(_members.InstanceMethods.InvokeAbstractObjectMethod("convertPoint.(FF)Landroid/graphics/PointF;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
