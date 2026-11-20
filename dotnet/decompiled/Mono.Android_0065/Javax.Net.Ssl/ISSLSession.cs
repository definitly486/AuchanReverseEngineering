using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Security;
using Java.Security.Cert;
using Javax.Security.Cert;

namespace Javax.Net.Ssl;

[Register("javax/net/ssl/SSLSession", "", "Javax.Net.Ssl.ISSLSessionInvoker")]
public interface ISSLSession : IJavaObject, IDisposable, IJavaPeerable
{
	int ApplicationBufferSize { get; }

	string? CipherSuite { get; }

	long CreationTime { get; }

	bool IsValid { get; }

	long LastAccessedTime { get; }

	IPrincipal? LocalPrincipal { get; }

	int PacketBufferSize { get; }

	string? PeerHost { get; }

	int PeerPort { get; }

	IPrincipal? PeerPrincipal { get; }

	string? Protocol { get; }

	ISSLSessionContext? SessionContext { get; }

	byte[]? GetId();

	Java.Security.Cert.Certificate[]? GetLocalCertificates();

	Javax.Security.Cert.X509Certificate[]? GetPeerCertificateChain();

	Java.Security.Cert.Certificate[]? GetPeerCertificates();

	Java.Lang.Object? GetValue(string? name);

	string[]? GetValueNames();

	void Invalidate();

	void PutValue(string? name, Java.Lang.Object? value);

	void RemoveValue(string? name);
}
