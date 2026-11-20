using System;
using Android.Runtime;
using InputMask.Model;
using Java.Interop;
using Java.Lang;

namespace InputMask.Helper;

[Register("com/redmadrobot/inputmask/helper/AffinityCalculationStrategy", DoNotGenerateAcw = true)]
public sealed class AffinityCalculationStrategy : Java.Lang.Enum
{
	internal static readonly JniPeerMembers _members = new XAPeerMembers("com/redmadrobot/inputmask/helper/AffinityCalculationStrategy", typeof(AffinityCalculationStrategy));

	[Register("CAPACITY")]
	public static AffinityCalculationStrategy Capacity => Java.Lang.Object.GetObject<AffinityCalculationStrategy>(_members.StaticFields.GetObjectValue("CAPACITY.Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("EXTRACTED_VALUE_CAPACITY")]
	public static AffinityCalculationStrategy ExtractedValueCapacity => Java.Lang.Object.GetObject<AffinityCalculationStrategy>(_members.StaticFields.GetObjectValue("EXTRACTED_VALUE_CAPACITY.Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("PREFIX")]
	public static AffinityCalculationStrategy Prefix => Java.Lang.Object.GetObject<AffinityCalculationStrategy>(_members.StaticFields.GetObjectValue("PREFIX.Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("WHOLE_STRING")]
	public static AffinityCalculationStrategy WholeString => Java.Lang.Object.GetObject<AffinityCalculationStrategy>(_members.StaticFields.GetObjectValue("WHOLE_STRING.Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;").Handle, JniHandleOwnership.TransferLocalRef);

	internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	internal AffinityCalculationStrategy(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("calculateAffinityOfMask", "(Lcom/redmadrobot/inputmask/helper/Mask;Lcom/redmadrobot/inputmask/model/CaretString;)I", "")]
	public unsafe int CalculateAffinityOfMask(Mask mask, CaretString text)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(mask?.Handle ?? IntPtr.Zero);
		ptr[1] = new JniArgumentValue(text?.Handle ?? IntPtr.Zero);
		int result = _members.InstanceMethods.InvokeNonvirtualInt32Method("calculateAffinityOfMask.(Lcom/redmadrobot/inputmask/helper/Mask;Lcom/redmadrobot/inputmask/model/CaretString;)I", this, ptr);
		GC.KeepAlive(mask);
		GC.KeepAlive(text);
		return result;
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;", "")]
	public unsafe static AffinityCalculationStrategy ValueOf(string p0)
	{
		IntPtr intPtr = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intPtr);
			return Java.Lang.Object.GetObject<AffinityCalculationStrategy>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}

	[Register("values", "()[Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;", "")]
	public unsafe static AffinityCalculationStrategy[] Values()
	{
		return (AffinityCalculationStrategy[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(AffinityCalculationStrategy));
	}
}
