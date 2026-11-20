using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace InputMask.Model;

[Register("com/redmadrobot/inputmask/model/CaretString", DoNotGenerateAcw = true)]
public sealed class CaretString : Java.Lang.Object
{
	[Register("com/redmadrobot/inputmask/model/CaretString$CaretGravity", DoNotGenerateAcw = true)]
	public abstract class CaretGravity : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/redmadrobot/inputmask/model/CaretString$CaretGravity", typeof(CaretGravity));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe bool Autocomplete
		{
			[Register("getAutocomplete", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getAutocomplete.()Z", this, null);
			}
		}

		public unsafe bool Autoskip
		{
			[Register("getAutoskip", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getAutoskip.()Z", this, null);
			}
		}

		protected CaretGravity(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	[Register("com/redmadrobot/inputmask/model/CaretString$CaretGravity", DoNotGenerateAcw = true)]
	internal class CaretGravityInvoker : CaretGravity
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/redmadrobot/inputmask/model/CaretString$CaretGravity", typeof(CaretGravityInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public CaretGravityInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}

	internal static readonly JniPeerMembers _members = new XAPeerMembers("com/redmadrobot/inputmask/model/CaretString", typeof(CaretString));

	internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe int CaretPosition
	{
		[Register("getCaretPosition", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("getCaretPosition.()I", this, null);
		}
	}

	public unsafe string String
	{
		[Register("getString", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal CaretString(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Ljava/lang/String;ILcom/redmadrobot/inputmask/model/CaretString$CaretGravity;)V", "")]
	public unsafe CaretString(string @string, int caretPosition, CaretGravity caretGravity)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		IntPtr intPtr = JNIEnv.NewString(@string);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue(caretPosition);
			ptr[2] = new JniArgumentValue(caretGravity?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;ILcom/redmadrobot/inputmask/model/CaretString$CaretGravity;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;ILcom/redmadrobot/inputmask/model/CaretString$CaretGravity;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(caretGravity);
		}
	}

	[Register("component1", "()Ljava/lang/String;", "")]
	public unsafe string Component1()
	{
		return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component1.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("component2", "()I", "")]
	public unsafe int Component2()
	{
		return _members.InstanceMethods.InvokeNonvirtualInt32Method("component2.()I", this, null);
	}

	[Register("component3", "()Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity;", "")]
	public unsafe CaretGravity Component3()
	{
		return Java.Lang.Object.GetObject<CaretGravity>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component3.()Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("copy", "(Ljava/lang/String;ILcom/redmadrobot/inputmask/model/CaretString$CaretGravity;)Lcom/redmadrobot/inputmask/model/CaretString;", "")]
	public unsafe CaretString Copy(string @string, int caretPosition, CaretGravity caretGravity)
	{
		IntPtr intPtr = JNIEnv.NewString(@string);
		CaretString result;
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue(caretPosition);
			ptr[2] = new JniArgumentValue(caretGravity?.Handle ?? IntPtr.Zero);
			result = Java.Lang.Object.GetObject<CaretString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copy.(Ljava/lang/String;ILcom/redmadrobot/inputmask/model/CaretString$CaretGravity;)Lcom/redmadrobot/inputmask/model/CaretString;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
		}
		GC.KeepAlive(caretGravity);
		return result;
	}

	[Register("getCaretGravity", "()Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity;", "")]
	public unsafe CaretGravity GetCaretGravity()
	{
		return Java.Lang.Object.GetObject<CaretGravity>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCaretGravity.()Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("reversed", "()Lcom/redmadrobot/inputmask/model/CaretString;", "")]
	public unsafe CaretString Reversed()
	{
		return Java.Lang.Object.GetObject<CaretString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("reversed.()Lcom/redmadrobot/inputmask/model/CaretString;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
