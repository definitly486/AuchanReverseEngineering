using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Lifecycle.ViewModels;

[Register("androidx/lifecycle/viewmodel/CreationExtras", DoNotGenerateAcw = true)]
public abstract class CreationExtras : Java.Lang.Object
{
	[Register("androidx/lifecycle/viewmodel/CreationExtras$Key", "", "AndroidX.Lifecycle.ViewModels.CreationExtras/IKeyInvoker")]
	[JavaTypeParameters(new string[] { "T" })]
	public interface IKey : IJavaObject, IDisposable, IJavaPeerable
	{
	}

	[Register("androidx/lifecycle/viewmodel/CreationExtras$Key", DoNotGenerateAcw = true)]
	internal class IKeyInvoker : Java.Lang.Object, IKey, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_lifecycle_viewmodel_CreationExtras_Key = new XAPeerMembers("androidx/lifecycle/viewmodel/CreationExtras$Key", typeof(IKeyInvoker));

		private static nint java_class_ref => _members_androidx_lifecycle_viewmodel_CreationExtras_Key.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_lifecycle_viewmodel_CreationExtras_Key;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_lifecycle_viewmodel_CreationExtras_Key.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_lifecycle_viewmodel_CreationExtras_Key.ManagedPeerType;

		public IKeyInvoker(nint handle, JniHandleOwnership transfer)
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/viewmodel/CreationExtras", typeof(CreationExtras));

	private static Delegate? cb_get_Get_Landroidx_lifecycle_viewmodel_CreationExtras_Key__Ljava_lang_Object_;

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

	protected CreationExtras(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGet_Landroidx_lifecycle_viewmodel_CreationExtras_Key_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Get_Landroidx_lifecycle_viewmodel_CreationExtras_Key_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Get_Landroidx_lifecycle_viewmodel_CreationExtras_Key_(nint jnienv, nint native__this, nint native_key)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CreationExtras? creationExtras = Java.Lang.Object.GetObject<CreationExtras>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IKey key = Java.Lang.Object.GetObject<IKey>(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(creationExtras.Get(key));
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

	[Register("get", "(Landroidx/lifecycle/viewmodel/CreationExtras$Key;)Ljava/lang/Object;", "GetGet_Landroidx_lifecycle_viewmodel_CreationExtras_Key_Handler")]
	[JavaTypeParameters(new string[] { "T" })]
	public abstract Java.Lang.Object? Get(IKey key);
}
