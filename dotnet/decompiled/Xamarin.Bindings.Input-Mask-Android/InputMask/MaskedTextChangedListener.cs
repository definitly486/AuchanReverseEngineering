using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using InputMask.Helper;
using InputMask.Model;
using Java.Interop;
using Java.Lang;

namespace InputMask;

[Register("com/redmadrobot/inputmask/MaskedTextChangedListener", DoNotGenerateAcw = true)]
public class MaskedTextChangedListener : Java.Lang.Object, ITextWatcher, INoCopySpan, IJavaObject, IDisposable, IJavaPeerable, View.IOnFocusChangeListener
{
	[Register("com/redmadrobot/inputmask/MaskedTextChangedListener$Companion", DoNotGenerateAcw = true)]
	public sealed class CompanionObject : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/redmadrobot/inputmask/MaskedTextChangedListener$Companion", typeof(CompanionObject));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal CompanionObject(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("installOn", "(Landroid/widget/EditText;Ljava/lang/String;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)Lcom/redmadrobot/inputmask/MaskedTextChangedListener;", "")]
		public unsafe MaskedTextChangedListener InstallOn(EditText editText, string primaryFormat, IValueListener valueListener)
		{
			IntPtr intPtr = JNIEnv.NewString(primaryFormat);
			MaskedTextChangedListener result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(editText?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue((valueListener == null) ? IntPtr.Zero : ((Java.Lang.Object)valueListener).Handle);
				result = Java.Lang.Object.GetObject<MaskedTextChangedListener>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("installOn.(Landroid/widget/EditText;Ljava/lang/String;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)Lcom/redmadrobot/inputmask/MaskedTextChangedListener;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(editText);
			GC.KeepAlive(valueListener);
			return result;
		}

		[Register("installOn", "(Landroid/widget/EditText;Ljava/lang/String;Ljava/util/List;Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)Lcom/redmadrobot/inputmask/MaskedTextChangedListener;", "")]
		public unsafe MaskedTextChangedListener InstallOn(EditText editText, string primaryFormat, IList<string> affineFormats, AffinityCalculationStrategy affinityCalculationStrategy, IValueListener valueListener)
		{
			IntPtr intPtr = JNIEnv.NewString(primaryFormat);
			IntPtr intPtr2 = JavaList<string>.ToLocalJniHandle(affineFormats);
			MaskedTextChangedListener result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(editText?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				ptr[3] = new JniArgumentValue(affinityCalculationStrategy?.Handle ?? IntPtr.Zero);
				ptr[4] = new JniArgumentValue((valueListener == null) ? IntPtr.Zero : ((Java.Lang.Object)valueListener).Handle);
				result = Java.Lang.Object.GetObject<MaskedTextChangedListener>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("installOn.(Landroid/widget/EditText;Ljava/lang/String;Ljava/util/List;Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)Lcom/redmadrobot/inputmask/MaskedTextChangedListener;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
			GC.KeepAlive(editText);
			GC.KeepAlive(affineFormats);
			GC.KeepAlive(affinityCalculationStrategy);
			GC.KeepAlive(valueListener);
			return result;
		}

		[Register("installOn", "(Landroid/widget/EditText;Ljava/lang/String;Ljava/util/List;Ljava/util/List;Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;ZZLandroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)Lcom/redmadrobot/inputmask/MaskedTextChangedListener;", "")]
		public unsafe MaskedTextChangedListener InstallOn(EditText editText, string primaryFormat, IList<string> affineFormats, IList<Notation> customNotations, AffinityCalculationStrategy affinityCalculationStrategy, bool autocomplete, bool autoskip, ITextWatcher listener, IValueListener valueListener)
		{
			IntPtr intPtr = JNIEnv.NewString(primaryFormat);
			IntPtr intPtr2 = JavaList<string>.ToLocalJniHandle(affineFormats);
			IntPtr intPtr3 = JavaList<Notation>.ToLocalJniHandle(customNotations);
			MaskedTextChangedListener result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[9];
				*ptr = new JniArgumentValue(editText?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				ptr[3] = new JniArgumentValue(intPtr3);
				ptr[4] = new JniArgumentValue(affinityCalculationStrategy?.Handle ?? IntPtr.Zero);
				ptr[5] = new JniArgumentValue(autocomplete);
				ptr[6] = new JniArgumentValue(autoskip);
				ptr[7] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				ptr[8] = new JniArgumentValue((valueListener == null) ? IntPtr.Zero : ((Java.Lang.Object)valueListener).Handle);
				result = Java.Lang.Object.GetObject<MaskedTextChangedListener>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("installOn.(Landroid/widget/EditText;Ljava/lang/String;Ljava/util/List;Ljava/util/List;Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;ZZLandroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)Lcom/redmadrobot/inputmask/MaskedTextChangedListener;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				JNIEnv.DeleteLocalRef(intPtr3);
			}
			GC.KeepAlive(editText);
			GC.KeepAlive(affineFormats);
			GC.KeepAlive(customNotations);
			GC.KeepAlive(affinityCalculationStrategy);
			GC.KeepAlive(listener);
			GC.KeepAlive(valueListener);
			return result;
		}
	}

	[Register("com/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener", "", "InputMask.MaskedTextChangedListener/IValueListenerInvoker")]
	public interface IValueListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onTextChanged", "(ZLjava/lang/String;Ljava/lang/String;)V", "GetOnTextChanged_ZLjava_lang_String_Ljava_lang_String_Handler:InputMask.MaskedTextChangedListener/IValueListenerInvoker, Xamarin.Bindings.Input-Mask-Android")]
		void OnTextChanged(bool maskFilled, string extractedValue, string formattedValue);
	}

	[Register("com/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener", DoNotGenerateAcw = true)]
	internal class IValueListenerInvoker : Java.Lang.Object, IValueListener, IJavaObject, IDisposable, IJavaPeerable
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener", typeof(IValueListenerInvoker));

		private IntPtr class_ref;

		private IntPtr id_onTextChanged_ZLjava_lang_String_Ljava_lang_String_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IValueListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IValueListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.redmadrobot.inputmask.MaskedTextChangedListener.ValueListener"));
			}
			return handle;
		}

		protected override void Dispose(bool disposing)
		{
			if (class_ref != IntPtr.Zero)
			{
				JNIEnv.DeleteGlobalRef(class_ref);
			}
			class_ref = IntPtr.Zero;
			base.Dispose(disposing);
		}

		public IValueListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static void n_OnTextChanged_ZLjava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, bool maskFilled, IntPtr native_extractedValue, IntPtr native_formattedValue)
		{
			IValueListener? valueListener = Java.Lang.Object.GetObject<IValueListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string extractedValue = JNIEnv.GetString(native_extractedValue, JniHandleOwnership.DoNotTransfer);
			string formattedValue = JNIEnv.GetString(native_formattedValue, JniHandleOwnership.DoNotTransfer);
			valueListener.OnTextChanged(maskFilled, extractedValue, formattedValue);
		}

		public unsafe void OnTextChanged(bool maskFilled, string extractedValue, string formattedValue)
		{
			if (id_onTextChanged_ZLjava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_onTextChanged_ZLjava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "onTextChanged", "(ZLjava/lang/String;Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(extractedValue);
			IntPtr intPtr2 = JNIEnv.NewString(formattedValue);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(maskFilled);
			ptr[1] = new JValue(intPtr);
			ptr[2] = new JValue(intPtr2);
			JNIEnv.CallVoidMethod(base.Handle, id_onTextChanged_ZLjava_lang_String_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
		}

		[UnmanagedCallersOnly]
		private static void n_OnTextChanged_ZLjava_lang_String_Ljava_lang_String__mm_wrapper(IntPtr jnienv, IntPtr native__this, byte maskFilled, IntPtr native_extractedValue, IntPtr native_formattedValue)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnTextChanged_ZLjava_lang_String_Ljava_lang_String_(jnienv, native__this, maskFilled != 0, native_extractedValue, native_formattedValue);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class ValueEventArgs : EventArgs
	{
		private bool maskFilled;

		private string extractedValue;

		private string formattedValue;

		public ValueEventArgs(bool maskFilled, string extractedValue, string formattedValue)
		{
			this.maskFilled = maskFilled;
			this.extractedValue = extractedValue;
			this.formattedValue = formattedValue;
		}
	}

	[Register("mono/com/redmadrobot/inputmask/MaskedTextChangedListener_ValueListenerImplementor")]
	internal sealed class IValueListenerImplementor : Java.Lang.Object, IValueListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public EventHandler<ValueEventArgs> Handler;

		public IValueListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/com/redmadrobot/inputmask/MaskedTextChangedListener_ValueListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnTextChanged(bool maskFilled, string extractedValue, string formattedValue)
		{
			Handler?.Invoke(sender, new ValueEventArgs(maskFilled, extractedValue, formattedValue));
		}

		internal static bool __IsEmpty(IValueListenerImplementor value)
		{
			return value.Handler == null;
		}
	}

	internal static readonly JniPeerMembers _members = new XAPeerMembers("com/redmadrobot/inputmask/MaskedTextChangedListener", typeof(MaskedTextChangedListener));

	private static Delegate cb_afterTextChanged_Landroid_text_Editable_;

	private static Delegate cb_beforeTextChanged_Ljava_lang_CharSequence_III;

	private static Delegate cb_onFocusChange_Landroid_view_View_Z;

	private static Delegate cb_onTextChanged_Ljava_lang_CharSequence_III;

	private static Delegate cb_setText_Ljava_lang_String_Landroid_widget_EditText_Ljava_lang_Boolean_;

	private static Delegate cb_setText_Ljava_lang_String_Ljava_lang_Boolean_;

	private WeakReference weak_implementor___SetValueListener;

	[Register("Companion")]
	public static CompanionObject Companion => Java.Lang.Object.GetObject<CompanionObject>(_members.StaticFields.GetObjectValue("Companion.Lcom/redmadrobot/inputmask/MaskedTextChangedListener$Companion;").Handle, JniHandleOwnership.TransferLocalRef);

	internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe IList<string> AffineFormats
	{
		[Register("getAffineFormats", "()Ljava/util/List;", "")]
		get
		{
			return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getAffineFormats.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setAffineFormats", "(Ljava/util/List;)V", "")]
		set
		{
			IntPtr intPtr = JavaList<string>.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setAffineFormats.(Ljava/util/List;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe AffinityCalculationStrategy AffinityCalculationStrategy
	{
		[Register("getAffinityCalculationStrategy", "()Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;", "")]
		get
		{
			return Java.Lang.Object.GetObject<AffinityCalculationStrategy>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getAffinityCalculationStrategy.()Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setAffinityCalculationStrategy", "(Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;)V", "")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("setAffinityCalculationStrategy.(Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;)V", this, ptr);
			GC.KeepAlive(value);
		}
	}

	public unsafe bool Autocomplete
	{
		[Register("getAutocomplete", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getAutocomplete.()Z", this, null);
		}
		[Register("setAutocomplete", "(Z)V", "")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("setAutocomplete.(Z)V", this, ptr);
		}
	}

	public unsafe bool Autoskip
	{
		[Register("getAutoskip", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getAutoskip.()Z", this, null);
		}
		[Register("setAutoskip", "(Z)V", "")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("setAutoskip.(Z)V", this, ptr);
		}
	}

	public unsafe IList<Notation> CustomNotations
	{
		[Register("getCustomNotations", "()Ljava/util/List;", "")]
		get
		{
			return JavaList<Notation>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCustomNotations.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setCustomNotations", "(Ljava/util/List;)V", "")]
		set
		{
			IntPtr intPtr = JavaList<Notation>.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setCustomNotations.(Ljava/util/List;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe ITextWatcher Listener
	{
		[Register("getListener", "()Landroid/text/TextWatcher;", "")]
		get
		{
			return Java.Lang.Object.GetObject<ITextWatcher>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getListener.()Landroid/text/TextWatcher;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setListener", "(Landroid/text/TextWatcher;)V", "")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("setListener.(Landroid/text/TextWatcher;)V", this, ptr);
			GC.KeepAlive(value);
		}
	}

	public unsafe string PrimaryFormat
	{
		[Register("getPrimaryFormat", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getPrimaryFormat.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setPrimaryFormat", "(Ljava/lang/String;)V", "")]
		set
		{
			IntPtr intPtr = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setPrimaryFormat.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}

	public unsafe bool RightToLeft
	{
		[Register("getRightToLeft", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getRightToLeft.()Z", this, null);
		}
		[Register("setRightToLeft", "(Z)V", "")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("setRightToLeft.(Z)V", this, ptr);
		}
	}

	public unsafe IValueListener ValueListener
	{
		[Register("getValueListener", "()Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;", "")]
		get
		{
			return Java.Lang.Object.GetObject<IValueListener>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getValueListener.()Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setValueListener", "(Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V", "")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("setValueListener.(Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V", this, ptr);
			GC.KeepAlive(value);
		}
	}

	public event EventHandler<ValueEventArgs> Value
	{
		add
		{
			EventHelper.AddEventHandler(ref weak_implementor___SetValueListener, __CreateIValueListenerImplementor, delegate(IValueListener __v)
			{
				ValueListener = __v;
			}, delegate(IValueListenerImplementor __h)
			{
				__h.Handler = (EventHandler<ValueEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IValueListener, IValueListenerImplementor>(ref weak_implementor___SetValueListener, IValueListenerImplementor.__IsEmpty, delegate
			{
				ValueListener = null;
			}, delegate(IValueListenerImplementor __h)
			{
				__h.Handler = (EventHandler<ValueEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	protected MaskedTextChangedListener(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Ljava/lang/String;Landroid/widget/EditText;)V", "")]
	public unsafe MaskedTextChangedListener(string format, EditText field)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		IntPtr intPtr = JNIEnv.NewString(format);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue(field?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Landroid/widget/EditText;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Landroid/widget/EditText;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(field);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;Landroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V", "")]
	public unsafe MaskedTextChangedListener(string format, EditText field, ITextWatcher listener, IValueListener valueListener)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		IntPtr intPtr = JNIEnv.NewString(format);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue(field?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			ptr[3] = new JniArgumentValue((valueListener == null) ? IntPtr.Zero : ((Java.Lang.Object)valueListener).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Landroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Landroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(field);
			GC.KeepAlive(listener);
			GC.KeepAlive(valueListener);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;Landroid/widget/EditText;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V", "")]
	public unsafe MaskedTextChangedListener(string format, EditText field, IValueListener valueListener)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		IntPtr intPtr = JNIEnv.NewString(format);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue(field?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((valueListener == null) ? IntPtr.Zero : ((Java.Lang.Object)valueListener).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Landroid/widget/EditText;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Landroid/widget/EditText;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(field);
			GC.KeepAlive(valueListener);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;ZLandroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V", "")]
	public unsafe MaskedTextChangedListener(string format, bool autocomplete, EditText field, ITextWatcher listener, IValueListener valueListener)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		IntPtr intPtr = JNIEnv.NewString(format);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue(autocomplete);
			ptr[2] = new JniArgumentValue(field?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			ptr[4] = new JniArgumentValue((valueListener == null) ? IntPtr.Zero : ((Java.Lang.Object)valueListener).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;ZLandroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;ZLandroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(field);
			GC.KeepAlive(listener);
			GC.KeepAlive(valueListener);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;Ljava/util/List;Landroid/widget/EditText;)V", "")]
	public unsafe MaskedTextChangedListener(string primaryFormat, IList<string> affineFormats, EditText field)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		IntPtr intPtr = JNIEnv.NewString(primaryFormat);
		IntPtr intPtr2 = JavaList<string>.ToLocalJniHandle(affineFormats);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue(intPtr2);
			ptr[2] = new JniArgumentValue(field?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/util/List;Landroid/widget/EditText;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/util/List;Landroid/widget/EditText;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
			GC.KeepAlive(affineFormats);
			GC.KeepAlive(field);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;Ljava/util/List;Landroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V", "")]
	public unsafe MaskedTextChangedListener(string primaryFormat, IList<string> affineFormats, EditText field, ITextWatcher listener, IValueListener valueListener)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		IntPtr intPtr = JNIEnv.NewString(primaryFormat);
		IntPtr intPtr2 = JavaList<string>.ToLocalJniHandle(affineFormats);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue(intPtr2);
			ptr[2] = new JniArgumentValue(field?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			ptr[4] = new JniArgumentValue((valueListener == null) ? IntPtr.Zero : ((Java.Lang.Object)valueListener).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/util/List;Landroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/util/List;Landroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
			GC.KeepAlive(affineFormats);
			GC.KeepAlive(field);
			GC.KeepAlive(listener);
			GC.KeepAlive(valueListener);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;Ljava/util/List;Landroid/widget/EditText;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V", "")]
	public unsafe MaskedTextChangedListener(string primaryFormat, IList<string> affineFormats, EditText field, IValueListener valueListener)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		IntPtr intPtr = JNIEnv.NewString(primaryFormat);
		IntPtr intPtr2 = JavaList<string>.ToLocalJniHandle(affineFormats);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue(intPtr2);
			ptr[2] = new JniArgumentValue(field?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue((valueListener == null) ? IntPtr.Zero : ((Java.Lang.Object)valueListener).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/util/List;Landroid/widget/EditText;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/util/List;Landroid/widget/EditText;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
			GC.KeepAlive(affineFormats);
			GC.KeepAlive(field);
			GC.KeepAlive(valueListener);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;Ljava/util/List;ZLandroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V", "")]
	public unsafe MaskedTextChangedListener(string primaryFormat, IList<string> affineFormats, bool autocomplete, EditText field, ITextWatcher listener, IValueListener valueListener)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		IntPtr intPtr = JNIEnv.NewString(primaryFormat);
		IntPtr intPtr2 = JavaList<string>.ToLocalJniHandle(affineFormats);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue(intPtr2);
			ptr[2] = new JniArgumentValue(autocomplete);
			ptr[3] = new JniArgumentValue(field?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			ptr[5] = new JniArgumentValue((valueListener == null) ? IntPtr.Zero : ((Java.Lang.Object)valueListener).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/util/List;ZLandroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/util/List;ZLandroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
			GC.KeepAlive(affineFormats);
			GC.KeepAlive(field);
			GC.KeepAlive(listener);
			GC.KeepAlive(valueListener);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;Ljava/util/List;Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;ZLandroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V", "")]
	public unsafe MaskedTextChangedListener(string primaryFormat, IList<string> affineFormats, AffinityCalculationStrategy affinityCalculationStrategy, bool autocomplete, EditText field, ITextWatcher listener, IValueListener valueListener)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		IntPtr intPtr = JNIEnv.NewString(primaryFormat);
		IntPtr intPtr2 = JavaList<string>.ToLocalJniHandle(affineFormats);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue(intPtr2);
			ptr[2] = new JniArgumentValue(affinityCalculationStrategy?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(autocomplete);
			ptr[4] = new JniArgumentValue(field?.Handle ?? IntPtr.Zero);
			ptr[5] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			ptr[6] = new JniArgumentValue((valueListener == null) ? IntPtr.Zero : ((Java.Lang.Object)valueListener).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/util/List;Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;ZLandroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/util/List;Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;ZLandroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
			GC.KeepAlive(affineFormats);
			GC.KeepAlive(affinityCalculationStrategy);
			GC.KeepAlive(field);
			GC.KeepAlive(listener);
			GC.KeepAlive(valueListener);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;Ljava/util/List;Ljava/util/List;Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;ZZLandroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;Z)V", "")]
	public unsafe MaskedTextChangedListener(string primaryFormat, IList<string> affineFormats, IList<Notation> customNotations, AffinityCalculationStrategy affinityCalculationStrategy, bool autocomplete, bool autoskip, EditText field, ITextWatcher listener, IValueListener valueListener, bool rightToLeft)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		IntPtr intPtr = JNIEnv.NewString(primaryFormat);
		IntPtr intPtr2 = JavaList<string>.ToLocalJniHandle(affineFormats);
		IntPtr intPtr3 = JavaList<Notation>.ToLocalJniHandle(customNotations);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[10];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue(intPtr2);
			ptr[2] = new JniArgumentValue(intPtr3);
			ptr[3] = new JniArgumentValue(affinityCalculationStrategy?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(autocomplete);
			ptr[5] = new JniArgumentValue(autoskip);
			ptr[6] = new JniArgumentValue(field?.Handle ?? IntPtr.Zero);
			ptr[7] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			ptr[8] = new JniArgumentValue((valueListener == null) ? IntPtr.Zero : ((Java.Lang.Object)valueListener).Handle);
			ptr[9] = new JniArgumentValue(rightToLeft);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/util/List;Ljava/util/List;Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;ZZLandroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;Z)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/util/List;Ljava/util/List;Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;ZZLandroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;Z)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
			JNIEnv.DeleteLocalRef(intPtr3);
			GC.KeepAlive(affineFormats);
			GC.KeepAlive(customNotations);
			GC.KeepAlive(affinityCalculationStrategy);
			GC.KeepAlive(field);
			GC.KeepAlive(listener);
			GC.KeepAlive(valueListener);
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

	private static Delegate GetAfterTextChanged_Landroid_text_Editable_Handler()
	{
		if ((object)cb_afterTextChanged_Landroid_text_Editable_ == null)
		{
			cb_afterTextChanged_Landroid_text_Editable_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_AfterTextChanged_Landroid_text_Editable_));
		}
		return cb_afterTextChanged_Landroid_text_Editable_;
	}

	private static void n_AfterTextChanged_Landroid_text_Editable_(IntPtr jnienv, IntPtr native__this, IntPtr native_edit)
	{
		MaskedTextChangedListener? maskedTextChangedListener = Java.Lang.Object.GetObject<MaskedTextChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IEditable edit = Java.Lang.Object.GetObject<IEditable>(native_edit, JniHandleOwnership.DoNotTransfer);
		maskedTextChangedListener.AfterTextChanged(edit);
	}

	[Register("afterTextChanged", "(Landroid/text/Editable;)V", "GetAfterTextChanged_Landroid_text_Editable_Handler")]
	public unsafe virtual void AfterTextChanged(IEditable edit)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((edit == null) ? IntPtr.Zero : ((Java.Lang.Object)edit).Handle);
		_members.InstanceMethods.InvokeVirtualVoidMethod("afterTextChanged.(Landroid/text/Editable;)V", this, ptr);
		GC.KeepAlive(edit);
	}

	private static Delegate GetBeforeTextChanged_Ljava_lang_CharSequence_IIIHandler()
	{
		if ((object)cb_beforeTextChanged_Ljava_lang_CharSequence_III == null)
		{
			cb_beforeTextChanged_Ljava_lang_CharSequence_III = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, int, int, int>(n_BeforeTextChanged_Ljava_lang_CharSequence_III));
		}
		return cb_beforeTextChanged_Ljava_lang_CharSequence_III;
	}

	private static void n_BeforeTextChanged_Ljava_lang_CharSequence_III(IntPtr jnienv, IntPtr native__this, IntPtr native_s, int start, int count, int after)
	{
		MaskedTextChangedListener? maskedTextChangedListener = Java.Lang.Object.GetObject<MaskedTextChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ICharSequence s = Java.Lang.Object.GetObject<ICharSequence>(native_s, JniHandleOwnership.DoNotTransfer);
		maskedTextChangedListener.BeforeTextChanged(s, start, count, after);
	}

	[Register("beforeTextChanged", "(Ljava/lang/CharSequence;III)V", "GetBeforeTextChanged_Ljava_lang_CharSequence_IIIHandler")]
	public unsafe virtual void BeforeTextChanged(ICharSequence s, int start, int count, int after)
	{
		IntPtr intPtr = CharSequence.ToLocalJniHandle(s);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue(start);
			ptr[2] = new JniArgumentValue(count);
			ptr[3] = new JniArgumentValue(after);
			_members.InstanceMethods.InvokeVirtualVoidMethod("beforeTextChanged.(Ljava/lang/CharSequence;III)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(s);
		}
	}

	public void BeforeTextChanged(string s, int start, int count, int after)
	{
		Java.Lang.String obj = ((s == null) ? null : new Java.Lang.String(s));
		BeforeTextChanged(obj, start, count, after);
		obj?.Dispose();
	}

	private static Delegate GetOnFocusChange_Landroid_view_View_ZHandler()
	{
		if ((object)cb_onFocusChange_Landroid_view_View_Z == null)
		{
			cb_onFocusChange_Landroid_view_View_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, bool>(n_OnFocusChange_Landroid_view_View_Z));
		}
		return cb_onFocusChange_Landroid_view_View_Z;
	}

	private static void n_OnFocusChange_Landroid_view_View_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_view, bool hasFocus)
	{
		MaskedTextChangedListener? maskedTextChangedListener = Java.Lang.Object.GetObject<MaskedTextChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
		maskedTextChangedListener.OnFocusChange(view, hasFocus);
	}

	[Register("onFocusChange", "(Landroid/view/View;Z)V", "GetOnFocusChange_Landroid_view_View_ZHandler")]
	public unsafe virtual void OnFocusChange(View view, bool hasFocus)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
		ptr[1] = new JniArgumentValue(hasFocus);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onFocusChange.(Landroid/view/View;Z)V", this, ptr);
		GC.KeepAlive(view);
	}

	private static Delegate GetOnTextChanged_Ljava_lang_CharSequence_IIIHandler()
	{
		if ((object)cb_onTextChanged_Ljava_lang_CharSequence_III == null)
		{
			cb_onTextChanged_Ljava_lang_CharSequence_III = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, int, int, int>(n_OnTextChanged_Ljava_lang_CharSequence_III));
		}
		return cb_onTextChanged_Ljava_lang_CharSequence_III;
	}

	private static void n_OnTextChanged_Ljava_lang_CharSequence_III(IntPtr jnienv, IntPtr native__this, IntPtr native_text, int cursorPosition, int before, int count)
	{
		MaskedTextChangedListener? maskedTextChangedListener = Java.Lang.Object.GetObject<MaskedTextChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ICharSequence text = Java.Lang.Object.GetObject<ICharSequence>(native_text, JniHandleOwnership.DoNotTransfer);
		maskedTextChangedListener.OnTextChanged(text, cursorPosition, before, count);
	}

	[Register("onTextChanged", "(Ljava/lang/CharSequence;III)V", "GetOnTextChanged_Ljava_lang_CharSequence_IIIHandler")]
	public unsafe virtual void OnTextChanged(ICharSequence text, int cursorPosition, int before, int count)
	{
		IntPtr intPtr = CharSequence.ToLocalJniHandle(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue(cursorPosition);
			ptr[2] = new JniArgumentValue(before);
			ptr[3] = new JniArgumentValue(count);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onTextChanged.(Ljava/lang/CharSequence;III)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(text);
		}
	}

	public void OnTextChanged(string text, int cursorPosition, int before, int count)
	{
		Java.Lang.String obj = ((text == null) ? null : new Java.Lang.String(text));
		OnTextChanged(obj, cursorPosition, before, count);
		obj?.Dispose();
	}

	[Register("placeholder", "()Ljava/lang/String;", "")]
	public unsafe string Placeholder()
	{
		return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("placeholder.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetText_Ljava_lang_String_Landroid_widget_EditText_Ljava_lang_Boolean_Handler()
	{
		if ((object)cb_setText_Ljava_lang_String_Landroid_widget_EditText_Ljava_lang_Boolean_ == null)
		{
			cb_setText_Ljava_lang_String_Landroid_widget_EditText_Ljava_lang_Boolean_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>(n_SetText_Ljava_lang_String_Landroid_widget_EditText_Ljava_lang_Boolean_));
		}
		return cb_setText_Ljava_lang_String_Landroid_widget_EditText_Ljava_lang_Boolean_;
	}

	private static IntPtr n_SetText_Ljava_lang_String_Landroid_widget_EditText_Ljava_lang_Boolean_(IntPtr jnienv, IntPtr native__this, IntPtr native_text, IntPtr native_field, IntPtr native_autocomplete)
	{
		MaskedTextChangedListener? maskedTextChangedListener = Java.Lang.Object.GetObject<MaskedTextChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string text = JNIEnv.GetString(native_text, JniHandleOwnership.DoNotTransfer);
		EditText field = Java.Lang.Object.GetObject<EditText>(native_field, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Boolean autocomplete = Java.Lang.Object.GetObject<Java.Lang.Boolean>(native_autocomplete, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(maskedTextChangedListener.SetText(text, field, autocomplete));
	}

	[Register("setText", "(Ljava/lang/String;Landroid/widget/EditText;Ljava/lang/Boolean;)Lcom/redmadrobot/inputmask/helper/Mask$Result;", "GetSetText_Ljava_lang_String_Landroid_widget_EditText_Ljava_lang_Boolean_Handler")]
	public unsafe virtual Mask.Result SetText(string text, EditText field, Java.Lang.Boolean autocomplete)
	{
		IntPtr intPtr = JNIEnv.NewString(text);
		Mask.Result result;
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue(field?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(autocomplete?.Handle ?? IntPtr.Zero);
			result = Java.Lang.Object.GetObject<Mask.Result>(_members.InstanceMethods.InvokeVirtualObjectMethod("setText.(Ljava/lang/String;Landroid/widget/EditText;Ljava/lang/Boolean;)Lcom/redmadrobot/inputmask/helper/Mask$Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
		}
		GC.KeepAlive(field);
		GC.KeepAlive(autocomplete);
		return result;
	}

	private static Delegate GetSetText_Ljava_lang_String_Ljava_lang_Boolean_Handler()
	{
		if ((object)cb_setText_Ljava_lang_String_Ljava_lang_Boolean_ == null)
		{
			cb_setText_Ljava_lang_String_Ljava_lang_Boolean_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>(n_SetText_Ljava_lang_String_Ljava_lang_Boolean_));
		}
		return cb_setText_Ljava_lang_String_Ljava_lang_Boolean_;
	}

	private static IntPtr n_SetText_Ljava_lang_String_Ljava_lang_Boolean_(IntPtr jnienv, IntPtr native__this, IntPtr native_text, IntPtr native_autocomplete)
	{
		MaskedTextChangedListener? maskedTextChangedListener = Java.Lang.Object.GetObject<MaskedTextChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string text = JNIEnv.GetString(native_text, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Boolean autocomplete = Java.Lang.Object.GetObject<Java.Lang.Boolean>(native_autocomplete, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(maskedTextChangedListener.SetText(text, autocomplete));
	}

	[Register("setText", "(Ljava/lang/String;Ljava/lang/Boolean;)Lcom/redmadrobot/inputmask/helper/Mask$Result;", "GetSetText_Ljava_lang_String_Ljava_lang_Boolean_Handler")]
	public unsafe virtual Mask.Result SetText(string text, Java.Lang.Boolean autocomplete)
	{
		IntPtr intPtr = JNIEnv.NewString(text);
		Mask.Result result;
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue(autocomplete?.Handle ?? IntPtr.Zero);
			result = Java.Lang.Object.GetObject<Mask.Result>(_members.InstanceMethods.InvokeVirtualObjectMethod("setText.(Ljava/lang/String;Ljava/lang/Boolean;)Lcom/redmadrobot/inputmask/helper/Mask$Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
		}
		GC.KeepAlive(autocomplete);
		return result;
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

	private IValueListenerImplementor __CreateIValueListenerImplementor()
	{
		return new IValueListenerImplementor(this);
	}
}
