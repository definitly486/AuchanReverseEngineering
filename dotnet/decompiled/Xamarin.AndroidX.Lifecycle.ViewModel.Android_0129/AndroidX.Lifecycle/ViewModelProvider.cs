using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.Lifecycle.ViewModels;
using Java.Interop;
using Java.Lang;
using Kotlin.Reflect;

namespace AndroidX.Lifecycle;

[Register("androidx/lifecycle/ViewModelProvider", DoNotGenerateAcw = true)]
public class ViewModelProvider : Java.Lang.Object
{
	[Register("androidx/lifecycle/ViewModelProvider$Factory$Companion", DoNotGenerateAcw = true)]
	public sealed class FactoryCompanion : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/ViewModelProvider$Factory$Companion", typeof(FactoryCompanion));

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

		internal FactoryCompanion(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("from", "([Landroidx/lifecycle/viewmodel/ViewModelInitializer;)Landroidx/lifecycle/ViewModelProvider$Factory;", "")]
		public unsafe IFactory From(params ViewModelInitializer[] initializers)
		{
			nint num = JNIEnv.NewArray(initializers);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<IFactory>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("from.([Landroidx/lifecycle/viewmodel/ViewModelInitializer;)Landroidx/lifecycle/ViewModelProvider$Factory;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (initializers != null)
				{
					JNIEnv.CopyArray(num, initializers);
					JNIEnv.DeleteLocalRef(num);
				}
				GC.KeepAlive(initializers);
			}
		}
	}

	[Register("androidx/lifecycle/ViewModelProvider$Factory", "", "AndroidX.Lifecycle.ViewModelProvider/IFactoryInvoker")]
	public interface IFactory : IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/ViewModelProvider$Factory", typeof(IFactory), isInterface: true);

		private static Delegate? cb_create_Create_Ljava_lang_Class__Landroidx_lifecycle_ViewModel_;

		private static Delegate? cb_create_Create_Ljava_lang_Class_Landroidx_lifecycle_viewmodel_CreationExtras__Landroidx_lifecycle_ViewModel_;

		private static Delegate? cb_create_Create_Lkotlin_reflect_KClass_Landroidx_lifecycle_viewmodel_CreationExtras__Landroidx_lifecycle_ViewModel_;

		[Register("Companion")]
		static FactoryCompanion Companion => Java.Lang.Object.GetObject<FactoryCompanion>(_members.StaticFields.GetObjectValue("Companion.Landroidx/lifecycle/ViewModelProvider$Factory$Companion;").Handle, JniHandleOwnership.TransferLocalRef);

		private static Delegate GetCreate_Ljava_lang_Class_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_Create_Ljava_lang_Class_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_Create_Ljava_lang_Class_(nint jnienv, nint native__this, nint native_modelClass)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IFactory? factory = Java.Lang.Object.GetObject<IFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Class modelClass = Java.Lang.Object.GetObject<Class>(native_modelClass, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(factory.Create(modelClass));
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

		[Register("create", "(Ljava/lang/Class;)Landroidx/lifecycle/ViewModel;", "GetCreate_Ljava_lang_Class_Handler:AndroidX.Lifecycle.ViewModelProvider/IFactory, Xamarin.AndroidX.Lifecycle.ViewModel.Android")]
		[JavaTypeParameters(new string[] { "T extends androidx.lifecycle.ViewModel" })]
		unsafe Java.Lang.Object Create(Class modelClass)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(modelClass?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("create.(Ljava/lang/Class;)Landroidx/lifecycle/ViewModel;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(modelClass);
			}
		}

		private static Delegate GetCreate_Ljava_lang_Class_Landroidx_lifecycle_viewmodel_CreationExtras_Handler()
		{
			return new global::_JniMarshal_PPLL_L(n_Create_Ljava_lang_Class_Landroidx_lifecycle_viewmodel_CreationExtras_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_Create_Ljava_lang_Class_Landroidx_lifecycle_viewmodel_CreationExtras_(nint jnienv, nint native__this, nint native_modelClass, nint native_extras)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IFactory? factory = Java.Lang.Object.GetObject<IFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Class modelClass = Java.Lang.Object.GetObject<Class>(native_modelClass, JniHandleOwnership.DoNotTransfer);
				CreationExtras extras = Java.Lang.Object.GetObject<CreationExtras>(native_extras, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(factory.Create(modelClass, extras));
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

		[Register("create", "(Ljava/lang/Class;Landroidx/lifecycle/viewmodel/CreationExtras;)Landroidx/lifecycle/ViewModel;", "GetCreate_Ljava_lang_Class_Landroidx_lifecycle_viewmodel_CreationExtras_Handler:AndroidX.Lifecycle.ViewModelProvider/IFactory, Xamarin.AndroidX.Lifecycle.ViewModel.Android")]
		[JavaTypeParameters(new string[] { "T extends androidx.lifecycle.ViewModel" })]
		unsafe Java.Lang.Object Create(Class modelClass, CreationExtras extras)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(modelClass?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("create.(Ljava/lang/Class;Landroidx/lifecycle/viewmodel/CreationExtras;)Landroidx/lifecycle/ViewModel;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(modelClass);
				GC.KeepAlive(extras);
			}
		}

		private static Delegate GetCreate_Lkotlin_reflect_KClass_Landroidx_lifecycle_viewmodel_CreationExtras_Handler()
		{
			return new global::_JniMarshal_PPLL_L(n_Create_Lkotlin_reflect_KClass_Landroidx_lifecycle_viewmodel_CreationExtras_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_Create_Lkotlin_reflect_KClass_Landroidx_lifecycle_viewmodel_CreationExtras_(nint jnienv, nint native__this, nint native_modelClass, nint native_extras)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IFactory? factory = Java.Lang.Object.GetObject<IFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IKClass modelClass = Java.Lang.Object.GetObject<IKClass>(native_modelClass, JniHandleOwnership.DoNotTransfer);
				CreationExtras extras = Java.Lang.Object.GetObject<CreationExtras>(native_extras, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(factory.Create(modelClass, extras));
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

		[Register("create", "(Lkotlin/reflect/KClass;Landroidx/lifecycle/viewmodel/CreationExtras;)Landroidx/lifecycle/ViewModel;", "GetCreate_Lkotlin_reflect_KClass_Landroidx_lifecycle_viewmodel_CreationExtras_Handler:AndroidX.Lifecycle.ViewModelProvider/IFactory, Xamarin.AndroidX.Lifecycle.ViewModel.Android")]
		[JavaTypeParameters(new string[] { "T extends androidx.lifecycle.ViewModel" })]
		unsafe Java.Lang.Object Create(IKClass modelClass, CreationExtras extras)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((modelClass == null) ? IntPtr.Zero : ((Java.Lang.Object)modelClass).Handle);
				ptr[1] = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("create.(Lkotlin/reflect/KClass;Landroidx/lifecycle/viewmodel/CreationExtras;)Landroidx/lifecycle/ViewModel;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(modelClass);
				GC.KeepAlive(extras);
			}
		}

		[Register("from", "([Landroidx/lifecycle/viewmodel/ViewModelInitializer;)Landroidx/lifecycle/ViewModelProvider$Factory;", "")]
		static unsafe IFactory From(params ViewModelInitializer[] initializers)
		{
			nint num = JNIEnv.NewArray(initializers);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<IFactory>(_members.StaticMethods.InvokeObjectMethod("from.([Landroidx/lifecycle/viewmodel/ViewModelInitializer;)Landroidx/lifecycle/ViewModelProvider$Factory;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (initializers != null)
				{
					JNIEnv.CopyArray(num, initializers);
					JNIEnv.DeleteLocalRef(num);
				}
				GC.KeepAlive(initializers);
			}
		}
	}

	[Register("androidx/lifecycle/ViewModelProvider$Factory", DoNotGenerateAcw = true)]
	internal class IFactoryInvoker : Java.Lang.Object, IFactory, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_lifecycle_ViewModelProvider_Factory = new XAPeerMembers("androidx/lifecycle/ViewModelProvider$Factory", typeof(IFactoryInvoker));

		private static nint java_class_ref => _members_androidx_lifecycle_ViewModelProvider_Factory.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_lifecycle_ViewModelProvider_Factory;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_lifecycle_ViewModelProvider_Factory.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_lifecycle_ViewModelProvider_Factory.ManagedPeerType;

		public IFactoryInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		int IJavaPeerable.get_JniIdentityHashCode()
		{
			return base.JniIdentityHashCode;
		}

		JniObjectReference IJavaPeerable.get_PeerReference()
		{
			return base.PeerReference;
		}

		void IJavaPeerable.UnregisterFromRuntime()
		{
			UnregisterFromRuntime();
		}
	}

	[Register("androidx/lifecycle/ViewModelProvider$NewInstanceFactory", DoNotGenerateAcw = true)]
	public class NewInstanceFactory : Java.Lang.Object, IFactory, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/ViewModelProvider$NewInstanceFactory", typeof(NewInstanceFactory));

		private static Delegate? cb_create_Create_Ljava_lang_Class__Landroidx_lifecycle_ViewModel_;

		private static Delegate? cb_create_Create_Ljava_lang_Class_Landroidx_lifecycle_viewmodel_CreationExtras__Landroidx_lifecycle_ViewModel_;

		private static Delegate? cb_create_Create_Lkotlin_reflect_KClass_Landroidx_lifecycle_viewmodel_CreationExtras__Landroidx_lifecycle_ViewModel_;

		[Register("VIEW_MODEL_KEY")]
		public static CreationExtras.IKey ViewModelKey => Java.Lang.Object.GetObject<CreationExtras.IKey>(_members.StaticFields.GetObjectValue("VIEW_MODEL_KEY.Landroidx/lifecycle/viewmodel/CreationExtras$Key;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe static NewInstanceFactory Instance
		{
			[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
			[Register("getInstance", "()Landroidx/lifecycle/ViewModelProvider$NewInstanceFactory;", "")]
			get
			{
				return Java.Lang.Object.GetObject<NewInstanceFactory>(_members.StaticMethods.InvokeObjectMethod("getInstance.()Landroidx/lifecycle/ViewModelProvider$NewInstanceFactory;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected NewInstanceFactory(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe NewInstanceFactory()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetCreate_Ljava_lang_Class_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_Create_Ljava_lang_Class_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_Create_Ljava_lang_Class_(nint jnienv, nint native__this, nint native_modelClass)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				NewInstanceFactory? newInstanceFactory = Java.Lang.Object.GetObject<NewInstanceFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Class modelClass = Java.Lang.Object.GetObject<Class>(native_modelClass, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(newInstanceFactory.Create(modelClass));
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

		[Register("create", "(Ljava/lang/Class;)Landroidx/lifecycle/ViewModel;", "GetCreate_Ljava_lang_Class_Handler")]
		[JavaTypeParameters(new string[] { "T extends androidx.lifecycle.ViewModel" })]
		public unsafe virtual Java.Lang.Object Create(Class modelClass)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(modelClass?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("create.(Ljava/lang/Class;)Landroidx/lifecycle/ViewModel;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(modelClass);
			}
		}

		private static Delegate GetCreate_Ljava_lang_Class_Landroidx_lifecycle_viewmodel_CreationExtras_Handler()
		{
			return new global::_JniMarshal_PPLL_L(n_Create_Ljava_lang_Class_Landroidx_lifecycle_viewmodel_CreationExtras_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_Create_Ljava_lang_Class_Landroidx_lifecycle_viewmodel_CreationExtras_(nint jnienv, nint native__this, nint native_modelClass, nint native_extras)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				NewInstanceFactory? newInstanceFactory = Java.Lang.Object.GetObject<NewInstanceFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Class modelClass = Java.Lang.Object.GetObject<Class>(native_modelClass, JniHandleOwnership.DoNotTransfer);
				CreationExtras extras = Java.Lang.Object.GetObject<CreationExtras>(native_extras, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(newInstanceFactory.Create(modelClass, extras));
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

		[Register("create", "(Ljava/lang/Class;Landroidx/lifecycle/viewmodel/CreationExtras;)Landroidx/lifecycle/ViewModel;", "GetCreate_Ljava_lang_Class_Landroidx_lifecycle_viewmodel_CreationExtras_Handler")]
		[JavaTypeParameters(new string[] { "T extends androidx.lifecycle.ViewModel" })]
		public unsafe virtual Java.Lang.Object Create(Class modelClass, CreationExtras extras)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(modelClass?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("create.(Ljava/lang/Class;Landroidx/lifecycle/viewmodel/CreationExtras;)Landroidx/lifecycle/ViewModel;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(modelClass);
				GC.KeepAlive(extras);
			}
		}

		private static Delegate GetCreate_Lkotlin_reflect_KClass_Landroidx_lifecycle_viewmodel_CreationExtras_Handler()
		{
			return new global::_JniMarshal_PPLL_L(n_Create_Lkotlin_reflect_KClass_Landroidx_lifecycle_viewmodel_CreationExtras_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_Create_Lkotlin_reflect_KClass_Landroidx_lifecycle_viewmodel_CreationExtras_(nint jnienv, nint native__this, nint native_modelClass, nint native_extras)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				NewInstanceFactory? newInstanceFactory = Java.Lang.Object.GetObject<NewInstanceFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IKClass modelClass = Java.Lang.Object.GetObject<IKClass>(native_modelClass, JniHandleOwnership.DoNotTransfer);
				CreationExtras extras = Java.Lang.Object.GetObject<CreationExtras>(native_extras, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(newInstanceFactory.Create(modelClass, extras));
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

		[Register("create", "(Lkotlin/reflect/KClass;Landroidx/lifecycle/viewmodel/CreationExtras;)Landroidx/lifecycle/ViewModel;", "GetCreate_Lkotlin_reflect_KClass_Landroidx_lifecycle_viewmodel_CreationExtras_Handler")]
		[JavaTypeParameters(new string[] { "T extends androidx.lifecycle.ViewModel" })]
		public unsafe virtual Java.Lang.Object Create(IKClass modelClass, CreationExtras extras)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((modelClass == null) ? IntPtr.Zero : ((Java.Lang.Object)modelClass).Handle);
				ptr[1] = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("create.(Lkotlin/reflect/KClass;Landroidx/lifecycle/viewmodel/CreationExtras;)Landroidx/lifecycle/ViewModel;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(modelClass);
				GC.KeepAlive(extras);
			}
		}

		int IJavaPeerable.get_JniIdentityHashCode()
		{
			return base.JniIdentityHashCode;
		}

		JniObjectReference IJavaPeerable.get_PeerReference()
		{
			return base.PeerReference;
		}

		void IJavaPeerable.UnregisterFromRuntime()
		{
			UnregisterFromRuntime();
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/ViewModelProvider", typeof(ViewModelProvider));

	private static Delegate? cb_get_Get_Ljava_lang_Class__Landroidx_lifecycle_ViewModel_;

	private static Delegate? cb_get_Get_Ljava_lang_String_Ljava_lang_Class__Landroidx_lifecycle_ViewModel_;

	[Register("VIEW_MODEL_KEY")]
	public static CreationExtras.IKey ViewModelKey => Java.Lang.Object.GetObject<CreationExtras.IKey>(_members.StaticFields.GetObjectValue("VIEW_MODEL_KEY.Landroidx/lifecycle/viewmodel/CreationExtras$Key;").Handle, JniHandleOwnership.TransferLocalRef);

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

	protected ViewModelProvider(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/lifecycle/ViewModelStore;Landroidx/lifecycle/ViewModelProvider$Factory;)V", "")]
	public unsafe ViewModelProvider(ViewModelStore store, IFactory factory)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(store?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((factory == null) ? IntPtr.Zero : ((Java.Lang.Object)factory).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/lifecycle/ViewModelStore;Landroidx/lifecycle/ViewModelProvider$Factory;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/lifecycle/ViewModelStore;Landroidx/lifecycle/ViewModelProvider$Factory;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(store);
			GC.KeepAlive(factory);
		}
	}

	[Register(".ctor", "(Landroidx/lifecycle/ViewModelStore;Landroidx/lifecycle/ViewModelProvider$Factory;Landroidx/lifecycle/viewmodel/CreationExtras;)V", "")]
	public unsafe ViewModelProvider(ViewModelStore store, IFactory factory, CreationExtras defaultCreationExtras)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(store?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((factory == null) ? IntPtr.Zero : ((Java.Lang.Object)factory).Handle);
			ptr[2] = new JniArgumentValue(defaultCreationExtras?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/lifecycle/ViewModelStore;Landroidx/lifecycle/ViewModelProvider$Factory;Landroidx/lifecycle/viewmodel/CreationExtras;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/lifecycle/ViewModelStore;Landroidx/lifecycle/ViewModelProvider$Factory;Landroidx/lifecycle/viewmodel/CreationExtras;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(store);
			GC.KeepAlive(factory);
			GC.KeepAlive(defaultCreationExtras);
		}
	}

	[Register(".ctor", "(Landroidx/lifecycle/ViewModelStoreOwner;)V", "")]
	public unsafe ViewModelProvider(IViewModelStoreOwner owner)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((owner == null) ? IntPtr.Zero : ((Java.Lang.Object)owner).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/lifecycle/ViewModelStoreOwner;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/lifecycle/ViewModelStoreOwner;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(owner);
		}
	}

	[Register(".ctor", "(Landroidx/lifecycle/ViewModelStoreOwner;Landroidx/lifecycle/ViewModelProvider$Factory;)V", "")]
	public unsafe ViewModelProvider(IViewModelStoreOwner owner, IFactory factory)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((owner == null) ? IntPtr.Zero : ((Java.Lang.Object)owner).Handle);
			ptr[1] = new JniArgumentValue((factory == null) ? IntPtr.Zero : ((Java.Lang.Object)factory).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/lifecycle/ViewModelStoreOwner;Landroidx/lifecycle/ViewModelProvider$Factory;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/lifecycle/ViewModelStoreOwner;Landroidx/lifecycle/ViewModelProvider$Factory;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(owner);
			GC.KeepAlive(factory);
		}
	}

	[Register("create", "(Landroidx/lifecycle/ViewModelStore;Landroidx/lifecycle/ViewModelProvider$Factory;Landroidx/lifecycle/viewmodel/CreationExtras;)Landroidx/lifecycle/ViewModelProvider;", "")]
	public unsafe static ViewModelProvider Create(ViewModelStore store, IFactory factory, CreationExtras extras)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(store?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((factory == null) ? IntPtr.Zero : ((Java.Lang.Object)factory).Handle);
			ptr[2] = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ViewModelProvider>(_members.StaticMethods.InvokeObjectMethod("create.(Landroidx/lifecycle/ViewModelStore;Landroidx/lifecycle/ViewModelProvider$Factory;Landroidx/lifecycle/viewmodel/CreationExtras;)Landroidx/lifecycle/ViewModelProvider;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(store);
			GC.KeepAlive(factory);
			GC.KeepAlive(extras);
		}
	}

	[Register("create", "(Landroidx/lifecycle/ViewModelStoreOwner;Landroidx/lifecycle/ViewModelProvider$Factory;Landroidx/lifecycle/viewmodel/CreationExtras;)Landroidx/lifecycle/ViewModelProvider;", "")]
	public unsafe static ViewModelProvider Create(IViewModelStoreOwner owner, IFactory factory, CreationExtras extras)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue((owner == null) ? IntPtr.Zero : ((Java.Lang.Object)owner).Handle);
			ptr[1] = new JniArgumentValue((factory == null) ? IntPtr.Zero : ((Java.Lang.Object)factory).Handle);
			ptr[2] = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ViewModelProvider>(_members.StaticMethods.InvokeObjectMethod("create.(Landroidx/lifecycle/ViewModelStoreOwner;Landroidx/lifecycle/ViewModelProvider$Factory;Landroidx/lifecycle/viewmodel/CreationExtras;)Landroidx/lifecycle/ViewModelProvider;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(owner);
			GC.KeepAlive(factory);
			GC.KeepAlive(extras);
		}
	}

	private static Delegate GetGet_Ljava_lang_Class_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Get_Ljava_lang_Class_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Get_Ljava_lang_Class_(nint jnienv, nint native__this, nint native_modelClass)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ViewModelProvider? viewModelProvider = Java.Lang.Object.GetObject<ViewModelProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class modelClass = Java.Lang.Object.GetObject<Class>(native_modelClass, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(viewModelProvider.Get(modelClass));
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

	[Register("get", "(Ljava/lang/Class;)Landroidx/lifecycle/ViewModel;", "GetGet_Ljava_lang_Class_Handler")]
	[JavaTypeParameters(new string[] { "T extends androidx.lifecycle.ViewModel" })]
	public unsafe virtual Java.Lang.Object Get(Class modelClass)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(modelClass?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("get.(Ljava/lang/Class;)Landroidx/lifecycle/ViewModel;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(modelClass);
		}
	}

	private static Delegate GetGet_Ljava_lang_String_Ljava_lang_Class_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_Get_Ljava_lang_String_Ljava_lang_Class_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Get_Ljava_lang_String_Ljava_lang_Class_(nint jnienv, nint native__this, nint native_key, nint native_modelClass)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ViewModelProvider? viewModelProvider = Java.Lang.Object.GetObject<ViewModelProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			Class modelClass = Java.Lang.Object.GetObject<Class>(native_modelClass, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(viewModelProvider.Get(key, modelClass));
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

	[Register("get", "(Ljava/lang/String;Ljava/lang/Class;)Landroidx/lifecycle/ViewModel;", "GetGet_Ljava_lang_String_Ljava_lang_Class_Handler")]
	[JavaTypeParameters(new string[] { "T extends androidx.lifecycle.ViewModel" })]
	public unsafe virtual Java.Lang.Object Get(string key, Class modelClass)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(modelClass?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("get.(Ljava/lang/String;Ljava/lang/Class;)Landroidx/lifecycle/ViewModel;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(modelClass);
		}
	}

	[Register("get", "(Ljava/lang/String;Lkotlin/reflect/KClass;)Landroidx/lifecycle/ViewModel;", "")]
	[JavaTypeParameters(new string[] { "T extends androidx.lifecycle.ViewModel" })]
	public unsafe Java.Lang.Object Get(string key, IKClass modelClass)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((modelClass == null) ? IntPtr.Zero : ((Java.Lang.Object)modelClass).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("get.(Ljava/lang/String;Lkotlin/reflect/KClass;)Landroidx/lifecycle/ViewModel;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(modelClass);
		}
	}

	[Register("get", "(Lkotlin/reflect/KClass;)Landroidx/lifecycle/ViewModel;", "")]
	[JavaTypeParameters(new string[] { "T extends androidx.lifecycle.ViewModel" })]
	public unsafe Java.Lang.Object Get(IKClass modelClass)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((modelClass == null) ? IntPtr.Zero : ((Java.Lang.Object)modelClass).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("get.(Lkotlin/reflect/KClass;)Landroidx/lifecycle/ViewModel;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(modelClass);
		}
	}
}
