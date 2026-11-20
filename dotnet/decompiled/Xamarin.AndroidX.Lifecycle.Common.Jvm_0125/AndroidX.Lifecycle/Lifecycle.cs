using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Kotlin.Enums;
using Xamarin.KotlinX.Coroutines.Flow;

namespace AndroidX.Lifecycle;

[Register("androidx/lifecycle/Lifecycle", DoNotGenerateAcw = true)]
public abstract class Lifecycle : Java.Lang.Object
{
	[Register("androidx/lifecycle/Lifecycle$Event", DoNotGenerateAcw = true)]
	public sealed class Event : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/Lifecycle$Event", typeof(Event));

		[Register("ON_ANY")]
		public static Event? OnAny => Java.Lang.Object.GetObject<Event>(_members.StaticFields.GetObjectValue("ON_ANY.Landroidx/lifecycle/Lifecycle$Event;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ON_CREATE")]
		public static Event? OnCreate => Java.Lang.Object.GetObject<Event>(_members.StaticFields.GetObjectValue("ON_CREATE.Landroidx/lifecycle/Lifecycle$Event;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ON_DESTROY")]
		public static Event? OnDestroy => Java.Lang.Object.GetObject<Event>(_members.StaticFields.GetObjectValue("ON_DESTROY.Landroidx/lifecycle/Lifecycle$Event;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ON_PAUSE")]
		public static Event? OnPause => Java.Lang.Object.GetObject<Event>(_members.StaticFields.GetObjectValue("ON_PAUSE.Landroidx/lifecycle/Lifecycle$Event;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ON_RESUME")]
		public static Event? OnResume => Java.Lang.Object.GetObject<Event>(_members.StaticFields.GetObjectValue("ON_RESUME.Landroidx/lifecycle/Lifecycle$Event;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ON_START")]
		public static Event? OnStart => Java.Lang.Object.GetObject<Event>(_members.StaticFields.GetObjectValue("ON_START.Landroidx/lifecycle/Lifecycle$Event;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ON_STOP")]
		public static Event? OnStop => Java.Lang.Object.GetObject<Event>(_members.StaticFields.GetObjectValue("ON_STOP.Landroidx/lifecycle/Lifecycle$Event;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe static IEnumEntries Entries
		{
			[Register("getEntries", "()Lkotlin/enums/EnumEntries;", "")]
			get
			{
				return Java.Lang.Object.GetObject<IEnumEntries>(_members.StaticMethods.InvokeObjectMethod("getEntries.()Lkotlin/enums/EnumEntries;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe State TargetState
		{
			[Register("getTargetState", "()Landroidx/lifecycle/Lifecycle$State;", "")]
			get
			{
				return Java.Lang.Object.GetObject<State>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTargetState.()Landroidx/lifecycle/Lifecycle$State;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal Event(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("downFrom", "(Landroidx/lifecycle/Lifecycle$State;)Landroidx/lifecycle/Lifecycle$Event;", "")]
		public unsafe static Event? DownFrom(State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Event>(_members.StaticMethods.InvokeObjectMethod("downFrom.(Landroidx/lifecycle/Lifecycle$State;)Landroidx/lifecycle/Lifecycle$Event;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(state);
			}
		}

		[Register("downTo", "(Landroidx/lifecycle/Lifecycle$State;)Landroidx/lifecycle/Lifecycle$Event;", "")]
		public unsafe static Event? DownTo(State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Event>(_members.StaticMethods.InvokeObjectMethod("downTo.(Landroidx/lifecycle/Lifecycle$State;)Landroidx/lifecycle/Lifecycle$Event;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(state);
			}
		}

		[Register("upFrom", "(Landroidx/lifecycle/Lifecycle$State;)Landroidx/lifecycle/Lifecycle$Event;", "")]
		public unsafe static Event? UpFrom(State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Event>(_members.StaticMethods.InvokeObjectMethod("upFrom.(Landroidx/lifecycle/Lifecycle$State;)Landroidx/lifecycle/Lifecycle$Event;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(state);
			}
		}

		[Register("upTo", "(Landroidx/lifecycle/Lifecycle$State;)Landroidx/lifecycle/Lifecycle$Event;", "")]
		public unsafe static Event? UpTo(State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Event>(_members.StaticMethods.InvokeObjectMethod("upTo.(Landroidx/lifecycle/Lifecycle$State;)Landroidx/lifecycle/Lifecycle$Event;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(state);
			}
		}

		[Register("valueOf", "(Ljava/lang/String;)Landroidx/lifecycle/Lifecycle$Event;", "")]
		public unsafe static Event? ValueOf(string? value)
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Event>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/lifecycle/Lifecycle$Event;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Landroidx/lifecycle/Lifecycle$Event;", "")]
		public unsafe static Event[]? Values()
		{
			return (Event[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/lifecycle/Lifecycle$Event;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Event));
		}
	}

	[Register("androidx/lifecycle/Lifecycle$State", DoNotGenerateAcw = true)]
	public sealed class State : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/Lifecycle$State", typeof(State));

		[Register("CREATED")]
		public static State? Created => Java.Lang.Object.GetObject<State>(_members.StaticFields.GetObjectValue("CREATED.Landroidx/lifecycle/Lifecycle$State;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DESTROYED")]
		public static State? Destroyed => Java.Lang.Object.GetObject<State>(_members.StaticFields.GetObjectValue("DESTROYED.Landroidx/lifecycle/Lifecycle$State;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("INITIALIZED")]
		public static State? Initialized => Java.Lang.Object.GetObject<State>(_members.StaticFields.GetObjectValue("INITIALIZED.Landroidx/lifecycle/Lifecycle$State;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("RESUMED")]
		public static State? Resumed => Java.Lang.Object.GetObject<State>(_members.StaticFields.GetObjectValue("RESUMED.Landroidx/lifecycle/Lifecycle$State;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("STARTED")]
		public static State? Started => Java.Lang.Object.GetObject<State>(_members.StaticFields.GetObjectValue("STARTED.Landroidx/lifecycle/Lifecycle$State;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe static IEnumEntries Entries
		{
			[Register("getEntries", "()Lkotlin/enums/EnumEntries;", "")]
			get
			{
				return Java.Lang.Object.GetObject<IEnumEntries>(_members.StaticMethods.InvokeObjectMethod("getEntries.()Lkotlin/enums/EnumEntries;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal State(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("isAtLeast", "(Landroidx/lifecycle/Lifecycle$State;)Z", "")]
		public unsafe bool IsAtLeast(State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isAtLeast.(Landroidx/lifecycle/Lifecycle$State;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(state);
			}
		}

		[Register("valueOf", "(Ljava/lang/String;)Landroidx/lifecycle/Lifecycle$State;", "")]
		public unsafe static State? ValueOf(string? value)
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<State>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/lifecycle/Lifecycle$State;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Landroidx/lifecycle/Lifecycle$State;", "")]
		public unsafe static State[]? Values()
		{
			return (State[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/lifecycle/Lifecycle$State;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(State));
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/Lifecycle", typeof(Lifecycle));

	private static Delegate? cb_getCurrentState_GetCurrentState_Landroidx_lifecycle_Lifecycle_State_;

	private static Delegate? cb_getCurrentStateFlow_GetCurrentStateFlow_Lkotlinx_coroutines_flow_StateFlow_;

	private static Delegate? cb_addObserver_AddObserver_Landroidx_lifecycle_LifecycleObserver__V;

	private static Delegate? cb_removeObserver_RemoveObserver_Landroidx_lifecycle_LifecycleObserver__V;

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

	public abstract State CurrentState
	{
		[Register("getCurrentState", "()Landroidx/lifecycle/Lifecycle$State;", "GetGetCurrentStateHandler")]
		get;
	}

	public unsafe virtual IStateFlow CurrentStateFlow
	{
		[Register("getCurrentStateFlow", "()Lkotlinx/coroutines/flow/StateFlow;", "GetGetCurrentStateFlowHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IStateFlow>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCurrentStateFlow.()Lkotlinx/coroutines/flow/StateFlow;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe AtomicReference InternalScopeRef
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getInternalScopeRef", "()Landroidx/lifecycle/AtomicReference;", "")]
		get
		{
			return Java.Lang.Object.GetObject<AtomicReference>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getInternalScopeRef.()Landroidx/lifecycle/AtomicReference;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("setInternalScopeRef", "(Landroidx/lifecycle/AtomicReference;)V", "")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setInternalScopeRef.(Landroidx/lifecycle/AtomicReference;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	protected Lifecycle(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Lifecycle()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetCurrentStateHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCurrentState);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCurrentState(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Lifecycle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurrentState);
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

	private static Delegate GetGetCurrentStateFlowHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCurrentStateFlow);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCurrentStateFlow(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Lifecycle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurrentStateFlow);
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

	private static Delegate GetAddObserver_Landroidx_lifecycle_LifecycleObserver_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddObserver_Landroidx_lifecycle_LifecycleObserver_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddObserver_Landroidx_lifecycle_LifecycleObserver_(nint jnienv, nint native__this, nint native_observer)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Lifecycle? lifecycle = Java.Lang.Object.GetObject<Lifecycle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILifecycleObserver observer = Java.Lang.Object.GetObject<ILifecycleObserver>(native_observer, JniHandleOwnership.DoNotTransfer);
			lifecycle.AddObserver(observer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("addObserver", "(Landroidx/lifecycle/LifecycleObserver;)V", "GetAddObserver_Landroidx_lifecycle_LifecycleObserver_Handler")]
	public abstract void AddObserver(ILifecycleObserver observer);

	private static Delegate GetRemoveObserver_Landroidx_lifecycle_LifecycleObserver_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveObserver_Landroidx_lifecycle_LifecycleObserver_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveObserver_Landroidx_lifecycle_LifecycleObserver_(nint jnienv, nint native__this, nint native_observer)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Lifecycle? lifecycle = Java.Lang.Object.GetObject<Lifecycle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILifecycleObserver observer = Java.Lang.Object.GetObject<ILifecycleObserver>(native_observer, JniHandleOwnership.DoNotTransfer);
			lifecycle.RemoveObserver(observer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("removeObserver", "(Landroidx/lifecycle/LifecycleObserver;)V", "GetRemoveObserver_Landroidx_lifecycle_LifecycleObserver_Handler")]
	public abstract void RemoveObserver(ILifecycleObserver observer);
}
