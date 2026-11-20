using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Org.Xml.Sax;

[Register("org/xml/sax/EntityResolver", DoNotGenerateAcw = true)]
internal class IEntityResolverInvoker : Java.Lang.Object, IEntityResolver, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_org_xml_sax_EntityResolver = new XAPeerMembers("org/xml/sax/EntityResolver", typeof(IEntityResolverInvoker));

	private static Delegate? cb_resolveEntity_ResolveEntity_Ljava_lang_String_Ljava_lang_String__Lorg_xml_sax_InputSource_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_org_xml_sax_EntityResolver;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_org_xml_sax_EntityResolver.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_org_xml_sax_EntityResolver.ManagedPeerType;

	public IEntityResolverInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetResolveEntity_Ljava_lang_String_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPLL_L(n_ResolveEntity_Ljava_lang_String_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ResolveEntity_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_publicId, nint native_systemId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEntityResolver? entityResolver = Java.Lang.Object.GetObject<IEntityResolver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string publicId = JNIEnv.GetString(native_publicId, JniHandleOwnership.DoNotTransfer);
			string systemId = JNIEnv.GetString(native_systemId, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(entityResolver.ResolveEntity(publicId, systemId));
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

	public unsafe InputSource? ResolveEntity(string? publicId, string? systemId)
	{
		nint num = JNIEnv.NewString(publicId);
		nint num2 = JNIEnv.NewString(systemId);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return Java.Lang.Object.GetObject<InputSource>(_members_org_xml_sax_EntityResolver.InstanceMethods.InvokeAbstractObjectMethod("resolveEntity.(Ljava/lang/String;Ljava/lang/String;)Lorg/xml/sax/InputSource;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
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
