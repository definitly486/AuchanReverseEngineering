using System;
using Android.Runtime;
using InputMask.Model;
using Java.Interop;
using Java.Lang;

namespace InputMask.Helper;

[Register("com/redmadrobot/inputmask/helper/CaretStringIterator", DoNotGenerateAcw = true)]
public class CaretStringIterator : Java.Lang.Object
{
	internal static readonly JniPeerMembers _members = new XAPeerMembers("com/redmadrobot/inputmask/helper/CaretStringIterator", typeof(CaretStringIterator));

	private static Delegate cb_deletionAffectsCaret;

	private static Delegate cb_insertionAffectsCaret;

	private static Delegate cb_next;

	internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	protected unsafe CaretString CaretString
	{
		[Register("getCaretString", "()Lcom/redmadrobot/inputmask/model/CaretString;", "")]
		get
		{
			return Java.Lang.Object.GetObject<CaretString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCaretString.()Lcom/redmadrobot/inputmask/model/CaretString;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected unsafe int CurrentIndex
	{
		[Register("getCurrentIndex", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("getCurrentIndex.()I", this, null);
		}
		[Register("setCurrentIndex", "(I)V", "")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("setCurrentIndex.(I)V", this, ptr);
		}
	}

	protected CaretStringIterator(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Lcom/redmadrobot/inputmask/model/CaretString;I)V", "")]
	public unsafe CaretStringIterator(CaretString caretString, int currentIndex)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(caretString?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(currentIndex);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/redmadrobot/inputmask/model/CaretString;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/redmadrobot/inputmask/model/CaretString;I)V", this, ptr);
			GC.KeepAlive(caretString);
		}
	}

	private static Delegate GetDeletionAffectsCaretHandler()
	{
		if ((object)cb_deletionAffectsCaret == null)
		{
			cb_deletionAffectsCaret = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_DeletionAffectsCaret));
		}
		return cb_deletionAffectsCaret;
	}

	private static bool n_DeletionAffectsCaret(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<CaretStringIterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DeletionAffectsCaret();
	}

	[Register("deletionAffectsCaret", "()Z", "GetDeletionAffectsCaretHandler")]
	public unsafe virtual bool DeletionAffectsCaret()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("deletionAffectsCaret.()Z", this, null);
	}

	private static Delegate GetInsertionAffectsCaretHandler()
	{
		if ((object)cb_insertionAffectsCaret == null)
		{
			cb_insertionAffectsCaret = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_InsertionAffectsCaret));
		}
		return cb_insertionAffectsCaret;
	}

	private static bool n_InsertionAffectsCaret(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<CaretStringIterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InsertionAffectsCaret();
	}

	[Register("insertionAffectsCaret", "()Z", "GetInsertionAffectsCaretHandler")]
	public unsafe virtual bool InsertionAffectsCaret()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("insertionAffectsCaret.()Z", this, null);
	}

	private static Delegate GetNextHandler()
	{
		if ((object)cb_next == null)
		{
			cb_next = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_Next));
		}
		return cb_next;
	}

	private static IntPtr n_Next(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CaretStringIterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Next());
	}

	[Register("next", "()Ljava/lang/Character;", "GetNextHandler")]
	public unsafe virtual Character Next()
	{
		return Java.Lang.Object.GetObject<Character>(_members.InstanceMethods.InvokeVirtualObjectMethod("next.()Ljava/lang/Character;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
