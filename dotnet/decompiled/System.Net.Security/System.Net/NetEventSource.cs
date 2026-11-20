using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace System.Net;

[EventSource(Name = "Private.InternalDiagnostics.System.Net.Security")]
internal sealed class NetEventSource : EventSource
{
	public static class Keywords
	{
		public const EventKeywords Default = (EventKeywords)1L;

		public const EventKeywords Debug = (EventKeywords)2L;
	}

	public static readonly System.Net.NetEventSource Log = new System.Net.NetEventSource();

	[NonEvent]
	public void SslStreamCtor(SslStream sslStream, Stream innerStream)
	{
		string text = null;
		string remoteId = null;
		if (innerStream is NetworkStream networkStream)
		{
			try
			{
				text = networkStream.Socket.LocalEndPoint?.ToString();
				remoteId = networkStream.Socket.RemoteEndPoint?.ToString();
			}
			catch
			{
			}
		}
		if (text == null)
		{
			text = IdOf(innerStream);
		}
		SslStreamCtor(IdOf(sslStream), text, remoteId);
	}

	[Event(25, Keywords = (EventKeywords)1L, Level = EventLevel.Informational)]
	private void SslStreamCtor(string thisOrContextObject, string localId, string remoteId)
	{
		WriteEvent(25, thisOrContextObject, localId, remoteId);
	}

	[NonEvent]
	public void LocatingPrivateKey(X509Certificate x509Certificate, object instance)
	{
		LocatingPrivateKey(x509Certificate.ToString(fVerbose: true), GetHashCode(instance));
	}

	[Event(5, Keywords = (EventKeywords)1L, Level = EventLevel.Informational)]
	private void LocatingPrivateKey(string x509Certificate, int sslStreamHash)
	{
		WriteEvent(5, x509Certificate, sslStreamHash);
	}

	[NonEvent]
	public void CertIsType2(object instance)
	{
		CertIsType2(GetHashCode(instance));
	}

	[Event(6, Keywords = (EventKeywords)1L, Level = EventLevel.Informational)]
	private void CertIsType2(int sslStreamHash)
	{
		WriteEvent(6, sslStreamHash);
	}

	[NonEvent]
	public void FoundCertInStore(bool serverMode, object instance)
	{
		FoundCertInStore(serverMode ? "LocalMachine" : "CurrentUser", GetHashCode(instance));
	}

	[Event(7, Keywords = (EventKeywords)1L, Level = EventLevel.Informational)]
	private void FoundCertInStore(string store, int sslStreamHash)
	{
		WriteEvent(7, store, sslStreamHash);
	}

	[NonEvent]
	public void NotFoundCertInStore(object instance)
	{
		NotFoundCertInStore(GetHashCode(instance));
	}

	[Event(8, Keywords = (EventKeywords)1L, Level = EventLevel.Informational)]
	private void NotFoundCertInStore(int sslStreamHash)
	{
		WriteEvent(8, sslStreamHash);
	}

	[NonEvent]
	public void CertificateFromDelegate(SslStream SslStream)
	{
		CertificateFromDelegate(GetHashCode(SslStream));
	}

	[Event(10, Keywords = (EventKeywords)1L, Level = EventLevel.Informational)]
	private void CertificateFromDelegate(int sslStreamHash)
	{
		WriteEvent(10, sslStreamHash);
	}

	[NonEvent]
	public void NoDelegateNoClientCert(SslStream SslStream)
	{
		NoDelegateNoClientCert(GetHashCode(SslStream));
	}

	[Event(11, Keywords = (EventKeywords)1L, Level = EventLevel.Informational)]
	private void NoDelegateNoClientCert(int sslStreamHash)
	{
		WriteEvent(11, sslStreamHash);
	}

	[NonEvent]
	public void NoDelegateButClientCert(SslStream SslStream)
	{
		NoDelegateButClientCert(GetHashCode(SslStream));
	}

	[Event(12, Keywords = (EventKeywords)1L, Level = EventLevel.Informational)]
	private void NoDelegateButClientCert(int sslStreamHash)
	{
		WriteEvent(12, sslStreamHash);
	}

	[NonEvent]
	public void AttemptingRestartUsingCert(X509Certificate clientCertificate, SslStream SslStream)
	{
		AttemptingRestartUsingCert(clientCertificate?.ToString(fVerbose: true), GetHashCode(SslStream));
	}

	[Event(13, Keywords = (EventKeywords)1L, Level = EventLevel.Informational)]
	private void AttemptingRestartUsingCert(string clientCertificate, int sslStreamHash)
	{
		WriteEvent(13, clientCertificate, sslStreamHash);
	}

	[NonEvent]
	public void NoIssuersTryAllCerts(SslStream SslStream)
	{
		NoIssuersTryAllCerts(GetHashCode(SslStream));
	}

	[Event(14, Keywords = (EventKeywords)1L, Level = EventLevel.Informational)]
	private void NoIssuersTryAllCerts(int sslStreamHash)
	{
		WriteEvent(14, sslStreamHash);
	}

	[NonEvent]
	public void LookForMatchingCerts(int issuersCount, SslStream SslStream)
	{
		LookForMatchingCerts(issuersCount, GetHashCode(SslStream));
	}

	[Event(15, Keywords = (EventKeywords)1L, Level = EventLevel.Informational)]
	private void LookForMatchingCerts(int issuersCount, int sslStreamHash)
	{
		WriteEvent(15, issuersCount, sslStreamHash);
	}

	[NonEvent]
	public void SelectedCert(X509Certificate clientCertificate, SslStream SslStream)
	{
		SelectedCert(clientCertificate?.ToString(fVerbose: true), GetHashCode(SslStream));
	}

	[Event(16, Keywords = (EventKeywords)1L, Level = EventLevel.Informational)]
	private void SelectedCert(string clientCertificate, int sslStreamHash)
	{
		WriteEvent(16, clientCertificate, sslStreamHash);
	}

	[NonEvent]
	public void CertsAfterFiltering(int filteredCertsCount, SslStream SslStream)
	{
		CertsAfterFiltering(filteredCertsCount, GetHashCode(SslStream));
	}

	[Event(17, Keywords = (EventKeywords)1L, Level = EventLevel.Informational)]
	private void CertsAfterFiltering(int filteredCertsCount, int sslStreamHash)
	{
		WriteEvent(17, filteredCertsCount, sslStreamHash);
	}

	[NonEvent]
	public void FindingMatchingCerts(SslStream SslStream)
	{
		FindingMatchingCerts(GetHashCode(SslStream));
	}

	[Event(18, Keywords = (EventKeywords)1L, Level = EventLevel.Informational)]
	private void FindingMatchingCerts(int sslStreamHash)
	{
		WriteEvent(18, sslStreamHash);
	}

	[NonEvent]
	public void UsingCachedCredential(SslStream SslStream)
	{
		UsingCachedCredential(GetHashCode(SslStream));
	}

	[Event(19, Keywords = (EventKeywords)1L, Level = EventLevel.Informational)]
	private void UsingCachedCredential(int sslStreamHash)
	{
		WriteEvent(19, sslStreamHash);
	}

	[Event(20, Keywords = (EventKeywords)1L, Level = EventLevel.Informational)]
	public void SspiSelectedCipherSuite(string process, SslProtocols sslProtocol, CipherAlgorithmType cipherAlgorithm, int cipherStrength, HashAlgorithmType hashAlgorithm, int hashStrength, ExchangeAlgorithmType keyExchangeAlgorithm, int keyExchangeStrength)
	{
		WriteEvent(20, process, (int)sslProtocol, (int)cipherAlgorithm, cipherStrength, (int)hashAlgorithm, hashStrength, (int)keyExchangeAlgorithm, keyExchangeStrength);
	}

	[NonEvent]
	public void RemoteCertificateError(SslStream SslStream, string message)
	{
		RemoteCertificateError(GetHashCode(SslStream), message);
	}

	[Event(21, Keywords = (EventKeywords)1L, Level = EventLevel.Verbose)]
	private void RemoteCertificateError(int sslStreamHash, string message)
	{
		WriteEvent(21, sslStreamHash, message);
	}

	[NonEvent]
	public void RemoteCertDeclaredValid(SslStream SslStream)
	{
		RemoteCertDeclaredValid(GetHashCode(SslStream));
	}

	[Event(22, Keywords = (EventKeywords)1L, Level = EventLevel.Verbose)]
	private void RemoteCertDeclaredValid(int sslStreamHash)
	{
		WriteEvent(22, sslStreamHash);
	}

	[NonEvent]
	public void RemoteCertHasNoErrors(SslStream SslStream)
	{
		RemoteCertHasNoErrors(GetHashCode(SslStream));
	}

	[Event(23, Keywords = (EventKeywords)1L, Level = EventLevel.Verbose)]
	private void RemoteCertHasNoErrors(int sslStreamHash)
	{
		WriteEvent(23, sslStreamHash);
	}

	[NonEvent]
	public void RemoteCertUserDeclaredInvalid(SslStream SslStream)
	{
		RemoteCertUserDeclaredInvalid(GetHashCode(SslStream));
	}

	[Event(24, Keywords = (EventKeywords)1L, Level = EventLevel.Verbose)]
	private void RemoteCertUserDeclaredInvalid(int sslStreamHash)
	{
		WriteEvent(24, sslStreamHash);
	}

	[NonEvent]
	public void SentFrame(SslStream sslStream, ReadOnlySpan<byte> frame)
	{
		TlsFrameHelper.TlsFrameInfo info = default(TlsFrameHelper.TlsFrameInfo);
		bool flag = TlsFrameHelper.TryGetFrameInfo(frame, ref info);
		SentFrame(IdOf(sslStream), info.ToString(), flag ? 1 : 0);
	}

	[Event(26, Keywords = (EventKeywords)1L, Level = EventLevel.Verbose)]
	private void SentFrame(string sslStream, string tlsFrame, int isComplete)
	{
		WriteEvent(26, sslStream, tlsFrame, isComplete);
	}

	[NonEvent]
	public void ReceivedFrame(SslStream sslStream, TlsFrameHelper.TlsFrameInfo frameInfo)
	{
		ReceivedFrame(IdOf(sslStream), frameInfo.ToString(), 1);
	}

	[Event(27, Keywords = (EventKeywords)1L, Level = EventLevel.Verbose)]
	private void ReceivedFrame(string sslStream, string tlsFrame, int isComplete)
	{
		WriteEvent(27, sslStream, tlsFrame, isComplete);
	}

	[NonEvent]
	public void CertificateFromCertContext(SslStream sslStream)
	{
		CertificateFromCertContext(GetHashCode(sslStream));
	}

	[Event(28, Keywords = (EventKeywords)1L, Level = EventLevel.Informational)]
	public void CertificateFromCertContext(int sslStreamHash)
	{
		WriteEvent(28, sslStreamHash);
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:UnrecognizedReflectionPattern", Justification = "Parameters to this method are primitive and are trimmer safe")]
	[NonEvent]
	private unsafe void WriteEvent(int eventId, string arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8)
	{
		if (arg1 == null)
		{
			arg1 = "";
		}
		fixed (char* dataPointer = arg1)
		{
			EventData* ptr = stackalloc EventData[8];
			*ptr = new EventData
			{
				DataPointer = (nint)dataPointer,
				Size = (arg1.Length + 1) * 2
			};
			ptr[1] = new EventData
			{
				DataPointer = (nint)(&arg2),
				Size = 4
			};
			ptr[2] = new EventData
			{
				DataPointer = (nint)(&arg3),
				Size = 4
			};
			ptr[3] = new EventData
			{
				DataPointer = (nint)(&arg4),
				Size = 4
			};
			ptr[4] = new EventData
			{
				DataPointer = (nint)(&arg5),
				Size = 4
			};
			ptr[5] = new EventData
			{
				DataPointer = (nint)(&arg6),
				Size = 4
			};
			ptr[6] = new EventData
			{
				DataPointer = (nint)(&arg7),
				Size = 4
			};
			ptr[7] = new EventData
			{
				DataPointer = (nint)(&arg8),
				Size = 4
			};
			WriteEventCore(eventId, 8, ptr);
		}
	}

	[NonEvent]
	public static void Info(object thisOrContextObject, FormattableString formattableString = null, [CallerMemberName] string memberName = null)
	{
		Log.Info(IdOf(thisOrContextObject), memberName, (formattableString != null) ? Format(formattableString) : "");
	}

	[NonEvent]
	public static void Info(object thisOrContextObject, object message, [CallerMemberName] string memberName = null)
	{
		Log.Info(IdOf(thisOrContextObject), memberName, Format(message));
	}

	[Event(1, Level = EventLevel.Informational, Keywords = (EventKeywords)1L)]
	private void Info(string thisOrContextObject, string memberName, string message)
	{
		WriteEvent(1, thisOrContextObject, memberName ?? "(?)", message);
	}

	[NonEvent]
	public static void Error(object thisOrContextObject, FormattableString formattableString, [CallerMemberName] string memberName = null)
	{
		Log.ErrorMessage(IdOf(thisOrContextObject), memberName, Format(formattableString));
	}

	[NonEvent]
	public static void Error(object thisOrContextObject, object message, [CallerMemberName] string memberName = null)
	{
		Log.ErrorMessage(IdOf(thisOrContextObject), memberName, Format(message));
	}

	[Event(2, Level = EventLevel.Error, Keywords = (EventKeywords)1L)]
	private void ErrorMessage(string thisOrContextObject, string memberName, string message)
	{
		WriteEvent(2, thisOrContextObject, memberName ?? "(?)", message);
	}

	[NonEvent]
	public static string IdOf(object value)
	{
		if (value == null)
		{
			return "(null)";
		}
		return value.GetType().Name + "#" + GetHashCode(value);
	}

	[NonEvent]
	public static int GetHashCode(object value)
	{
		return value?.GetHashCode() ?? 0;
	}

	[NonEvent]
	public static string Format(object value)
	{
		if (value == null)
		{
			return "(null)";
		}
		string result = null;
		AdditionalCustomizedToString(value, ref result);
		if (result != null)
		{
			return result;
		}
		if (value is Array array)
		{
			return $"{array.GetType().GetElementType()}[{((Array)value).Length}]";
		}
		if (value is ICollection collection)
		{
			return $"{collection.GetType().Name}({collection.Count})";
		}
		if (value is SafeHandle safeHandle)
		{
			return $"{safeHandle.GetType().Name}:{safeHandle.GetHashCode()}(0x{safeHandle.DangerousGetHandle():X})";
		}
		if (value is nint)
		{
			return $"0x{value:X}";
		}
		string text = value.ToString();
		if (text == null || text == value.GetType().FullName)
		{
			return IdOf(value);
		}
		return value.ToString();
	}

	[NonEvent]
	private static string Format(FormattableString s)
	{
		switch (s.ArgumentCount)
		{
		case 0:
			return s.Format;
		case 1:
			return string.Format(s.Format, Format(s.GetArgument(0)));
		case 2:
			return string.Format(s.Format, Format(s.GetArgument(0)), Format(s.GetArgument(1)));
		case 3:
			return string.Format(s.Format, Format(s.GetArgument(0)), Format(s.GetArgument(1)), Format(s.GetArgument(2)));
		default:
		{
			string[] array = new string[s.ArgumentCount];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Format(s.GetArgument(i));
			}
			string format = s.Format;
			object[] array2 = array;
			return string.Format(format, (ReadOnlySpan<object>)array2);
		}
		}
	}

	private static void AdditionalCustomizedToString(object value, ref string result)
	{
		if (value is X509Certificate x509Certificate)
		{
			result = x509Certificate.ToString(fVerbose: true);
		}
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:UnrecognizedReflectionPattern", Justification = "Parameters to this method are primitive and are trimmer safe")]
	[NonEvent]
	private unsafe void WriteEvent(int eventId, string arg1, string arg2, int arg3)
	{
		//The blocks IL_0035 are reachable both inside and outside the pinned region starting at IL_0032. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		if (arg1 == null)
		{
			arg1 = "";
		}
		if (arg2 == null)
		{
			arg2 = "";
		}
		fixed (char* dataPointer = arg1)
		{
			char* intPtr;
			EventData* intPtr2;
			nint num;
			nint num2;
			if (arg2 == null)
			{
				char* dataPointer2;
				intPtr = (dataPointer2 = null);
				EventData* ptr = stackalloc EventData[3];
				intPtr2 = ptr;
				*intPtr2 = new EventData
				{
					DataPointer = (nint)dataPointer,
					Size = (arg1.Length + 1) * 2
				};
				num = (nint)(ptr + 1);
				*(EventData*)num = new EventData
				{
					DataPointer = (nint)dataPointer2,
					Size = (arg2.Length + 1) * 2
				};
				num2 = (nint)(ptr + 2);
				*(EventData*)num2 = new EventData
				{
					DataPointer = (nint)(&arg3),
					Size = 4
				};
				WriteEventCore(eventId, 3, ptr);
				return;
			}
			fixed (char* ptr2 = &arg2.GetPinnableReference())
			{
				char* dataPointer2;
				intPtr = (dataPointer2 = ptr2);
				EventData* ptr = stackalloc EventData[3];
				intPtr2 = ptr;
				*intPtr2 = new EventData
				{
					DataPointer = (nint)dataPointer,
					Size = (arg1.Length + 1) * 2
				};
				num = (nint)(ptr + 1);
				*(EventData*)num = new EventData
				{
					DataPointer = (nint)dataPointer2,
					Size = (arg2.Length + 1) * 2
				};
				num2 = (nint)(ptr + 2);
				*(EventData*)num2 = new EventData
				{
					DataPointer = (nint)(&arg3),
					Size = 4
				};
				WriteEventCore(eventId, 3, ptr);
			}
		}
	}

	[NonEvent]
	public static void DumpBuffer(object thisOrContextObject, ReadOnlySpan<byte> buffer, [CallerMemberName] string memberName = null)
	{
		Log.DumpBuffer(IdOf(thisOrContextObject), memberName, buffer.Slice(0, Math.Min(buffer.Length, 1024)).ToArray());
	}

	[Event(4, Level = EventLevel.Verbose, Keywords = (EventKeywords)2L)]
	private void DumpBuffer(string thisOrContextObject, string memberName, byte[] buffer)
	{
		WriteEvent(4, thisOrContextObject, memberName ?? "(?)", buffer);
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:UnrecognizedReflectionPattern", Justification = "Parameters to this method are primitive and are trimmer safe")]
	[NonEvent]
	private unsafe void WriteEvent(int eventId, string arg1, string arg2, byte[] arg3)
	{
		//The blocks IL_0040, IL_0044, IL_0046, IL_005f, IL_0132 are reachable both inside and outside the pinned region starting at IL_003d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		if (arg1 == null)
		{
			arg1 = "";
		}
		if (arg2 == null)
		{
			arg2 = "";
		}
		if (arg3 == null)
		{
			arg3 = Array.Empty<byte>();
		}
		fixed (char* dataPointer = arg1)
		{
			char* intPtr;
			byte[] array;
			int size;
			EventData* intPtr2;
			nint num;
			nint num2;
			nint num3;
			if (arg2 == null)
			{
				char* dataPointer2;
				intPtr = (dataPointer2 = null);
				array = arg3;
				fixed (byte* ptr = array)
				{
					byte* dataPointer3 = ptr;
					size = arg3.Length;
					EventData* ptr2 = stackalloc EventData[4];
					intPtr2 = ptr2;
					*intPtr2 = new EventData
					{
						DataPointer = (nint)dataPointer,
						Size = (arg1.Length + 1) * 2
					};
					num = (nint)(ptr2 + 1);
					*(EventData*)num = new EventData
					{
						DataPointer = (nint)dataPointer2,
						Size = (arg2.Length + 1) * 2
					};
					num2 = (nint)(ptr2 + 2);
					*(EventData*)num2 = new EventData
					{
						DataPointer = (nint)(&size),
						Size = 4
					};
					num3 = (nint)(ptr2 + 3);
					*(EventData*)num3 = new EventData
					{
						DataPointer = (nint)dataPointer3,
						Size = size
					};
					WriteEventCore(eventId, 4, ptr2);
				}
				return;
			}
			fixed (char* ptr3 = &arg2.GetPinnableReference())
			{
				char* dataPointer2;
				intPtr = (dataPointer2 = ptr3);
				array = arg3;
				fixed (byte* ptr = array)
				{
					byte* dataPointer3 = ptr;
					size = arg3.Length;
					EventData* ptr2 = stackalloc EventData[4];
					intPtr2 = ptr2;
					*intPtr2 = new EventData
					{
						DataPointer = (nint)dataPointer,
						Size = (arg1.Length + 1) * 2
					};
					num = (nint)(ptr2 + 1);
					*(EventData*)num = new EventData
					{
						DataPointer = (nint)dataPointer2,
						Size = (arg2.Length + 1) * 2
					};
					num2 = (nint)(ptr2 + 2);
					*(EventData*)num2 = new EventData
					{
						DataPointer = (nint)(&size),
						Size = 4
					};
					num3 = (nint)(ptr2 + 3);
					*(EventData*)num3 = new EventData
					{
						DataPointer = (nint)dataPointer3,
						Size = size
					};
					WriteEventCore(eventId, 4, ptr2);
				}
			}
		}
	}
}
