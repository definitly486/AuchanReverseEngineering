using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Org.Xml.Sax;

[Register("org/xml/sax/ErrorHandler", DoNotGenerateAcw = true)]
internal class IErrorHandlerInvoker : Java.Lang.Object, IErrorHandler, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_org_xml_sax_ErrorHandler = new XAPeerMembers("org/xml/sax/ErrorHandler", typeof(IErrorHandlerInvoker));

	private static Delegate? cb_error_Error_Lorg_xml_sax_SAXParseException__V;

	private static Delegate? cb_fatalError_FatalError_Lorg_xml_sax_SAXParseException__V;

	private static Delegate? cb_warning_Warning_Lorg_xml_sax_SAXParseException__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_org_xml_sax_ErrorHandler;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_org_xml_sax_ErrorHandler.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_org_xml_sax_ErrorHandler.ManagedPeerType;

	public IErrorHandlerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetError_Lorg_xml_sax_SAXParseException_Handler()
	{
		return new _JniMarshal_PPL_V(n_Error_Lorg_xml_sax_SAXParseException_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Error_Lorg_xml_sax_SAXParseException_(nint jnienv, nint native__this, nint native_exception)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IErrorHandler? errorHandler = Java.Lang.Object.GetObject<IErrorHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SAXParseException exception = Java.Lang.Object.GetObject<SAXParseException>(native_exception, JniHandleOwnership.DoNotTransfer);
			errorHandler.Error(exception);
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

	public unsafe void Error(SAXParseException? exception)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(exception?.Handle ?? IntPtr.Zero);
			_members_org_xml_sax_ErrorHandler.InstanceMethods.InvokeAbstractVoidMethod("error.(Lorg/xml/sax/SAXParseException;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(exception);
		}
	}

	private static Delegate GetFatalError_Lorg_xml_sax_SAXParseException_Handler()
	{
		return new _JniMarshal_PPL_V(n_FatalError_Lorg_xml_sax_SAXParseException_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_FatalError_Lorg_xml_sax_SAXParseException_(nint jnienv, nint native__this, nint native_exception)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IErrorHandler? errorHandler = Java.Lang.Object.GetObject<IErrorHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SAXParseException exception = Java.Lang.Object.GetObject<SAXParseException>(native_exception, JniHandleOwnership.DoNotTransfer);
			errorHandler.FatalError(exception);
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

	public unsafe void FatalError(SAXParseException? exception)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(exception?.Handle ?? IntPtr.Zero);
			_members_org_xml_sax_ErrorHandler.InstanceMethods.InvokeAbstractVoidMethod("fatalError.(Lorg/xml/sax/SAXParseException;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(exception);
		}
	}

	private static Delegate GetWarning_Lorg_xml_sax_SAXParseException_Handler()
	{
		return new _JniMarshal_PPL_V(n_Warning_Lorg_xml_sax_SAXParseException_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Warning_Lorg_xml_sax_SAXParseException_(nint jnienv, nint native__this, nint native_exception)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IErrorHandler? errorHandler = Java.Lang.Object.GetObject<IErrorHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SAXParseException exception = Java.Lang.Object.GetObject<SAXParseException>(native_exception, JniHandleOwnership.DoNotTransfer);
			errorHandler.Warning(exception);
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

	public unsafe void Warning(SAXParseException? exception)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(exception?.Handle ?? IntPtr.Zero);
			_members_org_xml_sax_ErrorHandler.InstanceMethods.InvokeAbstractVoidMethod("warning.(Lorg/xml/sax/SAXParseException;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(exception);
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
