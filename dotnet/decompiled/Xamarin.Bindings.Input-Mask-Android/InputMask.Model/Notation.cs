using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace InputMask.Model;

[Register("com/redmadrobot/inputmask/model/Notation", DoNotGenerateAcw = true)]
public sealed class Notation : Java.Lang.Object
{
	internal static readonly JniPeerMembers _members = new XAPeerMembers("com/redmadrobot/inputmask/model/Notation", typeof(Notation));

	internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe char Character
	{
		[Register("getCharacter", "()C", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualCharMethod("getCharacter.()C", this, null);
		}
	}

	public unsafe string CharacterSet
	{
		[Register("getCharacterSet", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCharacterSet.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe bool IsOptional
	{
		[Register("isOptional", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isOptional.()Z", this, null);
		}
	}

	internal Notation(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(CLjava/lang/String;Z)V", "")]
	public unsafe Notation(char character, string characterSet, bool isOptional)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		IntPtr intPtr = JNIEnv.NewString(characterSet);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(character);
			ptr[1] = new JniArgumentValue(intPtr);
			ptr[2] = new JniArgumentValue(isOptional);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(CLjava/lang/String;Z)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(CLjava/lang/String;Z)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}

	[Register("component1", "()C", "")]
	public unsafe char Component1()
	{
		return _members.InstanceMethods.InvokeNonvirtualCharMethod("component1.()C", this, null);
	}

	[Register("component2", "()Ljava/lang/String;", "")]
	public unsafe string Component2()
	{
		return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component2.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("component3", "()Z", "")]
	public unsafe bool Component3()
	{
		return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("component3.()Z", this, null);
	}

	[Register("copy", "(CLjava/lang/String;Z)Lcom/redmadrobot/inputmask/model/Notation;", "")]
	public unsafe Notation Copy(char character, string characterSet, bool isOptional)
	{
		IntPtr intPtr = JNIEnv.NewString(characterSet);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(character);
			ptr[1] = new JniArgumentValue(intPtr);
			ptr[2] = new JniArgumentValue(isOptional);
			return Java.Lang.Object.GetObject<Notation>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copy.(CLjava/lang/String;Z)Lcom/redmadrobot/inputmask/model/Notation;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}
}
