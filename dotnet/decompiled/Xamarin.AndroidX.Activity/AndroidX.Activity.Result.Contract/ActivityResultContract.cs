using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Activity.Result.Contract;

[Register("androidx/activity/result/contract/ActivityResultContract", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "I", "O" })]
public abstract class ActivityResultContract : Java.Lang.Object
{
	[Register("androidx/activity/result/contract/ActivityResultContract$SynchronousResult", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "T" })]
	public sealed class SynchronousResult : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/result/contract/ActivityResultContract$SynchronousResult", typeof(SynchronousResult));

		internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe Java.Lang.Object? Value
		{
			[Register("getValue", "()Ljava/lang/Object;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getValue.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal SynchronousResult(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/Object;)V", "")]
		public unsafe SynchronousResult(Java.Lang.Object? value)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Object;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/result/contract/ActivityResultContract", typeof(ActivityResultContract));

	private static Delegate? cb_createIntent_CreateIntent_Landroid_content_Context_Ljava_lang_Object__Landroid_content_Intent_;

	private static Delegate? cb_getSynchronousResult_GetSynchronousResult_Landroid_content_Context_Ljava_lang_Object__Landroidx_activity_result_contract_ActivityResultContract_SynchronousResult_;

	private static Delegate? cb_parseResult_ParseResult_ILandroid_content_Intent__Ljava_lang_Object_;

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected ActivityResultContract(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ActivityResultContract()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetCreateIntent_Landroid_content_Context_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_CreateIntent_Landroid_content_Context_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CreateIntent_Landroid_content_Context_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_context, nint native_input)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ActivityResultContract? activityResultContract = Java.Lang.Object.GetObject<ActivityResultContract>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object input = Java.Lang.Object.GetObject<Java.Lang.Object>(native_input, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(activityResultContract.CreateIntent(context, input));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("createIntent", "(Landroid/content/Context;Ljava/lang/Object;)Landroid/content/Intent;", "GetCreateIntent_Landroid_content_Context_Ljava_lang_Object_Handler")]
	public abstract Intent CreateIntent(Context context, Java.Lang.Object? input);

	private static Delegate GetGetSynchronousResult_Landroid_content_Context_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_GetSynchronousResult_Landroid_content_Context_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSynchronousResult_Landroid_content_Context_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_context, nint native_input)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ActivityResultContract? activityResultContract = Java.Lang.Object.GetObject<ActivityResultContract>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object input = Java.Lang.Object.GetObject<Java.Lang.Object>(native_input, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(activityResultContract.GetSynchronousResult(context, input));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getSynchronousResult", "(Landroid/content/Context;Ljava/lang/Object;)Landroidx/activity/result/contract/ActivityResultContract$SynchronousResult;", "GetGetSynchronousResult_Landroid_content_Context_Ljava_lang_Object_Handler")]
	public unsafe virtual SynchronousResult? GetSynchronousResult(Context context, Java.Lang.Object? input)
	{
		nint num = JNIEnv.ToLocalJniHandle(input);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<SynchronousResult>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSynchronousResult.(Landroid/content/Context;Ljava/lang/Object;)Landroidx/activity/result/contract/ActivityResultContract$SynchronousResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(context);
			GC.KeepAlive(input);
		}
	}

	private static Delegate GetParseResult_ILandroid_content_Intent_Handler()
	{
		return new global::_JniMarshal_PPIL_L(n_ParseResult_ILandroid_content_Intent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ParseResult_ILandroid_content_Intent_(nint jnienv, nint native__this, int resultCode, nint native_intent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ActivityResultContract? activityResultContract = Java.Lang.Object.GetObject<ActivityResultContract>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(activityResultContract.ParseResult(resultCode, intent));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("parseResult", "(ILandroid/content/Intent;)Ljava/lang/Object;", "GetParseResult_ILandroid_content_Intent_Handler")]
	public abstract Java.Lang.Object? ParseResult(int resultCode, Intent? intent);
}
