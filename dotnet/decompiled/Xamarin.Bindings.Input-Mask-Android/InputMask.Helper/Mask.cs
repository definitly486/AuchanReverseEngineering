using System;
using System.Collections.Generic;
using Android.Runtime;
using InputMask.Model;
using Java.Interop;
using Java.Lang;

namespace InputMask.Helper;

[Register("com/redmadrobot/inputmask/helper/Mask", DoNotGenerateAcw = true)]
public class Mask : Java.Lang.Object
{
	[Register("com/redmadrobot/inputmask/helper/Mask$Result", DoNotGenerateAcw = true)]
	public sealed class Result : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/redmadrobot/inputmask/helper/Mask$Result", typeof(Result));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int Affinity
		{
			[Register("getAffinity", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getAffinity.()I", this, null);
			}
		}

		public unsafe bool Complete
		{
			[Register("getComplete", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getComplete.()Z", this, null);
			}
		}

		public unsafe string ExtractedValue
		{
			[Register("getExtractedValue", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getExtractedValue.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe CaretString FormattedText
		{
			[Register("getFormattedText", "()Lcom/redmadrobot/inputmask/model/CaretString;", "")]
			get
			{
				return Java.Lang.Object.GetObject<CaretString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getFormattedText.()Lcom/redmadrobot/inputmask/model/CaretString;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal Result(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/redmadrobot/inputmask/model/CaretString;Ljava/lang/String;IZ)V", "")]
		public unsafe Result(CaretString formattedText, string extractedValue, int affinity, bool complete)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(extractedValue);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(formattedText?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(affinity);
				ptr[3] = new JniArgumentValue(complete);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/redmadrobot/inputmask/model/CaretString;Ljava/lang/String;IZ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/redmadrobot/inputmask/model/CaretString;Ljava/lang/String;IZ)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(formattedText);
			}
		}

		[Register("component1", "()Lcom/redmadrobot/inputmask/model/CaretString;", "")]
		public unsafe CaretString Component1()
		{
			return Java.Lang.Object.GetObject<CaretString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component1.()Lcom/redmadrobot/inputmask/model/CaretString;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component2", "()Ljava/lang/String;", "")]
		public unsafe string Component2()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component2.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component3", "()I", "")]
		public unsafe int Component3()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("component3.()I", this, null);
		}

		[Register("component4", "()Z", "")]
		public unsafe bool Component4()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("component4.()Z", this, null);
		}

		[Register("copy", "(Lcom/redmadrobot/inputmask/model/CaretString;Ljava/lang/String;IZ)Lcom/redmadrobot/inputmask/helper/Mask$Result;", "")]
		public unsafe Result Copy(CaretString formattedText, string extractedValue, int affinity, bool complete)
		{
			IntPtr intPtr = JNIEnv.NewString(extractedValue);
			Result result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(formattedText?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(affinity);
				ptr[3] = new JniArgumentValue(complete);
				result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copy.(Lcom/redmadrobot/inputmask/model/CaretString;Ljava/lang/String;IZ)Lcom/redmadrobot/inputmask/helper/Mask$Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(formattedText);
			return result;
		}

		[Register("reversed", "()Lcom/redmadrobot/inputmask/helper/Mask$Result;", "")]
		public unsafe Result Reversed()
		{
			return Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("reversed.()Lcom/redmadrobot/inputmask/helper/Mask$Result;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal static readonly JniPeerMembers _members = new XAPeerMembers("com/redmadrobot/inputmask/helper/Mask", typeof(Mask));

	private static Delegate cb_apply_Lcom_redmadrobot_inputmask_model_CaretString_;

	private static Delegate cb_makeIterator_Lcom_redmadrobot_inputmask_model_CaretString_;

	internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	protected unsafe IList<Notation> CustomNotations
	{
		[Register("getCustomNotations", "()Ljava/util/List;", "")]
		get
		{
			return JavaList<Notation>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCustomNotations.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected Mask(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Ljava/lang/String;)V", "")]
	public unsafe Mask(string format)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		IntPtr intPtr = JNIEnv.NewString(format);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intPtr);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;Ljava/util/List;)V", "")]
	public unsafe Mask(string format, IList<Notation> customNotations)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		IntPtr intPtr = JNIEnv.NewString(format);
		IntPtr intPtr2 = JavaList<Notation>.ToLocalJniHandle(customNotations);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue(intPtr2);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/util/List;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
			GC.KeepAlive(customNotations);
		}
	}

	[Register("acceptableTextLength", "()I", "")]
	public unsafe int AcceptableTextLength()
	{
		return _members.InstanceMethods.InvokeNonvirtualInt32Method("acceptableTextLength.()I", this, null);
	}

	[Register("acceptableValueLength", "()I", "")]
	public unsafe int AcceptableValueLength()
	{
		return _members.InstanceMethods.InvokeNonvirtualInt32Method("acceptableValueLength.()I", this, null);
	}

	private static Delegate GetApply_Lcom_redmadrobot_inputmask_model_CaretString_Handler()
	{
		if ((object)cb_apply_Lcom_redmadrobot_inputmask_model_CaretString_ == null)
		{
			cb_apply_Lcom_redmadrobot_inputmask_model_CaretString_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr>(n_Apply_Lcom_redmadrobot_inputmask_model_CaretString_));
		}
		return cb_apply_Lcom_redmadrobot_inputmask_model_CaretString_;
	}

	private static IntPtr n_Apply_Lcom_redmadrobot_inputmask_model_CaretString_(IntPtr jnienv, IntPtr native__this, IntPtr native_text)
	{
		Mask? mask = Java.Lang.Object.GetObject<Mask>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		CaretString text = Java.Lang.Object.GetObject<CaretString>(native_text, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(mask.Apply(text));
	}

	[Register("apply", "(Lcom/redmadrobot/inputmask/model/CaretString;)Lcom/redmadrobot/inputmask/helper/Mask$Result;", "GetApply_Lcom_redmadrobot_inputmask_model_CaretString_Handler")]
	public unsafe virtual Result Apply(CaretString text)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(text?.Handle ?? IntPtr.Zero);
		Result? result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeVirtualObjectMethod("apply.(Lcom/redmadrobot/inputmask/model/CaretString;)Lcom/redmadrobot/inputmask/helper/Mask$Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		GC.KeepAlive(text);
		return result;
	}

	private static Delegate GetMakeIterator_Lcom_redmadrobot_inputmask_model_CaretString_Handler()
	{
		if ((object)cb_makeIterator_Lcom_redmadrobot_inputmask_model_CaretString_ == null)
		{
			cb_makeIterator_Lcom_redmadrobot_inputmask_model_CaretString_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr>(n_MakeIterator_Lcom_redmadrobot_inputmask_model_CaretString_));
		}
		return cb_makeIterator_Lcom_redmadrobot_inputmask_model_CaretString_;
	}

	private static IntPtr n_MakeIterator_Lcom_redmadrobot_inputmask_model_CaretString_(IntPtr jnienv, IntPtr native__this, IntPtr native_text)
	{
		Mask? mask = Java.Lang.Object.GetObject<Mask>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		CaretString text = Java.Lang.Object.GetObject<CaretString>(native_text, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(mask.MakeIterator(text));
	}

	[Register("makeIterator", "(Lcom/redmadrobot/inputmask/model/CaretString;)Lcom/redmadrobot/inputmask/helper/CaretStringIterator;", "GetMakeIterator_Lcom_redmadrobot_inputmask_model_CaretString_Handler")]
	public unsafe virtual CaretStringIterator MakeIterator(CaretString text)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(text?.Handle ?? IntPtr.Zero);
		CaretStringIterator? result = Java.Lang.Object.GetObject<CaretStringIterator>(_members.InstanceMethods.InvokeVirtualObjectMethod("makeIterator.(Lcom/redmadrobot/inputmask/model/CaretString;)Lcom/redmadrobot/inputmask/helper/CaretStringIterator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		GC.KeepAlive(text);
		return result;
	}

	[Register("placeholder", "()Ljava/lang/String;", "")]
	public unsafe string Placeholder()
	{
		return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("placeholder.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("totalTextLength", "()I", "")]
	public unsafe int TotalTextLength()
	{
		return _members.InstanceMethods.InvokeNonvirtualInt32Method("totalTextLength.()I", this, null);
	}

	[Register("totalValueLength", "()I", "")]
	public unsafe int TotalValueLength()
	{
		return _members.InstanceMethods.InvokeNonvirtualInt32Method("totalValueLength.()I", this, null);
	}
}
