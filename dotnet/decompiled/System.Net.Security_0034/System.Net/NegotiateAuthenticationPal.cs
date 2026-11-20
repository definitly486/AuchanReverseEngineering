using System.Buffers;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.ComponentModel;
using System.Formats.Asn1;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace System.Net;

internal abstract class NegotiateAuthenticationPal : IDisposable
{
	internal sealed class UnsupportedNegotiateAuthenticationPal : NegotiateAuthenticationPal
	{
		private string _package;

		private string _targetName;

		private NegotiateAuthenticationStatusCode _statusCode;

		public override bool IsAuthenticated => false;

		public override bool IsSigned => false;

		public override bool IsEncrypted => false;

		public override string Package => _package;

		public override string TargetName => _targetName;

		public override TokenImpersonationLevel ImpersonationLevel => TokenImpersonationLevel.Impersonation;

		public UnsupportedNegotiateAuthenticationPal(NegotiateAuthenticationClientOptions clientOptions, NegotiateAuthenticationStatusCode statusCode = NegotiateAuthenticationStatusCode.Unsupported)
		{
			_package = clientOptions.Package;
			_targetName = clientOptions.TargetName;
			_statusCode = statusCode;
		}

		public override void Dispose()
		{
		}

		public override byte[] GetOutgoingBlob(ReadOnlySpan<byte> incomingBlob, out NegotiateAuthenticationStatusCode statusCode)
		{
			statusCode = _statusCode;
			return null;
		}

		public override void GetMIC(ReadOnlySpan<byte> message, IBufferWriter<byte> signature)
		{
			throw new InvalidOperationException();
		}

		public override bool VerifyMIC(ReadOnlySpan<byte> message, ReadOnlySpan<byte> signature)
		{
			throw new InvalidOperationException();
		}
	}

	internal sealed class ManagedNtlmNegotiateAuthenticationPal : NegotiateAuthenticationPal
	{
		private enum MessageType : byte
		{
			Negotiate = 1,
			Challenge,
			Authenticate
		}

		[Flags]
		private enum Flags : uint
		{
			NegotiateUnicode = 1u,
			NegotiateOEM = 2u,
			TargetName = 4u,
			NegotiateSign = 0x10u,
			NegotiateSeal = 0x20u,
			NegotiateDatagram = 0x40u,
			NegotiateLMKey = 0x80u,
			NegotiateNtlm = 0x200u,
			NegotiateAnonymous = 0x800u,
			NegotiateDomainSupplied = 0x1000u,
			NegotiateWorkstationSupplied = 0x2000u,
			NegotiateAlwaysSign = 0x8000u,
			TargetTypeDomain = 0x10000u,
			TargetTypeServer = 0x20000u,
			NegotiateNtlm2 = 0x80000u,
			RequestIdenityToken = 0x100000u,
			RequestNonNtSessionKey = 0x400000u,
			NegotiateTargetInfo = 0x800000u,
			NegotiateVersion = 0x2000000u,
			Negotiate128 = 0x20000000u,
			NegotiateKeyExchange = 0x40000000u,
			Negotiate56 = 0x80000000u
		}

		private enum AvId
		{
			EOL,
			NbComputerName,
			NbDomainName,
			DnsComputerName,
			DnsDomainName,
			DnsTreeName,
			Flags,
			Timestamp,
			SingleHost,
			TargetName,
			ChannelBindings
		}

		private struct MessageField
		{
			public ushort Length;

			public ushort MaximumLength;

			public int PayloadOffset;
		}

		private struct MessageHeader
		{
			public unsafe fixed byte Header[8];

			public MessageType MessageType;

			private byte _unused1;

			private byte _unused2;

			private byte _unused3;
		}

		private struct Version
		{
			public byte VersionMajor;

			public byte VersionMinor;

			public ushort ProductBuild;

			private byte _unused4;

			private byte _unused5;

			private byte _unused6;

			public byte CurrentRevision;
		}

		private struct NegotiateMessage
		{
			public MessageHeader Header;

			public Flags Flags;

			public MessageField DomainName;

			public MessageField WorkStation;

			public Version Version;
		}

		private struct ChallengeMessage
		{
			public MessageHeader Header;

			public MessageField TargetName;

			public Flags Flags;

			public unsafe fixed byte ServerChallenge[8];

			private ulong _unused;

			public MessageField TargetInfo;

			public Version Version;
		}

		private struct AuthenticateMessage
		{
			public MessageHeader Header;

			public MessageField LmChallengeResponse;

			public MessageField NtChallengeResponse;

			public MessageField DomainName;

			public MessageField UserName;

			public MessageField Workstation;

			public MessageField EncryptedRandomSessionKey;

			public Flags Flags;

			public Version Version;

			public unsafe fixed byte Mic[16];
		}

		private struct NtChallengeResponse
		{
			public unsafe fixed byte Hmac[16];

			public byte Responserversion;

			public byte HiResponserversion;

			private byte _reserved1;

			private byte _reserved2;

			private int _reserved3;

			public long Time;

			public unsafe fixed byte ClientChallenge[8];

			private int _reserved4;

			public unsafe fixed byte ServerInfo[4];
		}

		private readonly NetworkCredential _credential;

		private readonly string _spn;

		private readonly ChannelBinding _channelBinding;

		private readonly ProtectionLevel _protectionLevel;

		private byte[] _negotiateMessage;

		private byte[] _clientSigningKey;

		private byte[] _serverSigningKey;

		private byte[] _clientSealingKey;

		private byte[] _serverSealingKey;

		private RC4 _clientSeal;

		private RC4 _serverSeal;

		private uint _clientSequenceNumber;

		private uint _serverSequenceNumber;

		private bool _isAuthenticated;

		private static readonly byte[] s_workstation = Encoding.Unicode.GetBytes(Environment.MachineName);

		private static readonly Version s_version = new Version
		{
			VersionMajor = 6,
			VersionMinor = 1,
			ProductBuild = 7600,
			CurrentRevision = 15
		};

		private static ReadOnlySpan<byte> NtlmHeader => "NTLMSSP\0"u8;

		private static ReadOnlySpan<byte> ClientSigningKeyMagic => "session key to client-to-server signing key magic constant\0"u8;

		private static ReadOnlySpan<byte> ServerSigningKeyMagic => "session key to server-to-client signing key magic constant\0"u8;

		private static ReadOnlySpan<byte> ClientSealingKeyMagic => "session key to client-to-server sealing key magic constant\0"u8;

		private static ReadOnlySpan<byte> ServerSealingKeyMagic => "session key to server-to-client sealing key magic constant\0"u8;

		public override bool IsAuthenticated => _isAuthenticated;

		public override bool IsSigned => _protectionLevel != ProtectionLevel.None;

		public override bool IsEncrypted => _protectionLevel == ProtectionLevel.EncryptAndSign;

		public override string Package => "NTLM";

		public override string TargetName => _spn;

		public override TokenImpersonationLevel ImpersonationLevel => TokenImpersonationLevel.Impersonation;

		private ManagedNtlmNegotiateAuthenticationPal(NegotiateAuthenticationClientOptions clientOptions)
		{
			_credential = clientOptions.Credential;
			_spn = clientOptions.TargetName;
			_channelBinding = clientOptions.Binding;
			_protectionLevel = clientOptions.RequiredProtectionLevel;
			if (!System.Net.NetEventSource.Log.IsEnabled())
			{
			}
		}

		public new static NegotiateAuthenticationPal Create(NegotiateAuthenticationClientOptions clientOptions)
		{
			if (clientOptions.Credential == CredentialCache.DefaultNetworkCredentials || string.IsNullOrWhiteSpace(clientOptions.Credential.UserName) || string.IsNullOrWhiteSpace(clientOptions.Credential.Password))
			{
				if (System.Net.NetEventSource.Log.IsEnabled())
				{
				}
				return new UnsupportedNegotiateAuthenticationPal(clientOptions, NegotiateAuthenticationStatusCode.UnknownCredentials);
			}
			return new ManagedNtlmNegotiateAuthenticationPal(clientOptions);
		}

		public override void Dispose()
		{
			_negotiateMessage = null;
			_clientSigningKey = null;
			_serverSigningKey = null;
			_clientSealingKey = null;
			_serverSealingKey = null;
			_clientSeal?.Dispose();
			_serverSeal?.Dispose();
			_clientSeal = null;
			_serverSeal = null;
			_clientSequenceNumber = 0u;
			_serverSequenceNumber = 0u;
			_isAuthenticated = false;
		}

		public unsafe override byte[] GetOutgoingBlob(ReadOnlySpan<byte> incomingBlob, out NegotiateAuthenticationStatusCode statusCode)
		{
			byte[] result;
			if (_negotiateMessage == null)
			{
				Flags flags = Flags.NegotiateUnicode | Flags.TargetName | Flags.NegotiateSign | Flags.NegotiateNtlm | Flags.NegotiateAlwaysSign | Flags.NegotiateNtlm2 | Flags.NegotiateTargetInfo | Flags.NegotiateVersion | Flags.Negotiate128 | Flags.NegotiateKeyExchange;
				if (_protectionLevel == ProtectionLevel.EncryptAndSign)
				{
					flags |= Flags.NegotiateSeal;
				}
				_negotiateMessage = new byte[sizeof(NegotiateMessage)];
				CreateNtlmNegotiateMessage(_negotiateMessage, flags);
				result = _negotiateMessage;
				statusCode = NegotiateAuthenticationStatusCode.ContinueNeeded;
			}
			else
			{
				_isAuthenticated = true;
				result = ProcessChallenge(incomingBlob, out statusCode);
			}
			return result;
		}

		private static void CreateNtlmNegotiateMessage(Span<byte> asBytes, Flags requiredFlags)
		{
			ref NegotiateMessage reference = ref MemoryMarshal.AsRef<NegotiateMessage>(asBytes);
			asBytes.Clear();
			NtlmHeader.CopyTo(asBytes);
			reference.Header.MessageType = MessageType.Negotiate;
			reference.Flags = requiredFlags;
			reference.Version = s_version;
		}

		private unsafe static int GetFieldLength(MessageField field)
		{
			return BinaryPrimitives.ReadInt16LittleEndian(new ReadOnlySpan<byte>(&field, sizeof(MessageField)));
		}

		private unsafe static int GetFieldOffset(MessageField field)
		{
			return BinaryPrimitives.ReadInt16LittleEndian(new ReadOnlySpan<byte>(&field, sizeof(MessageField)).Slice(4));
		}

		private static ReadOnlySpan<byte> GetField(MessageField field, ReadOnlySpan<byte> payload)
		{
			int fieldOffset = GetFieldOffset(field);
			int fieldLength = GetFieldLength(field);
			if (fieldLength == 0 || fieldOffset + fieldLength > payload.Length)
			{
				return ReadOnlySpan<byte>.Empty;
			}
			return payload.Slice(GetFieldOffset(field), GetFieldLength(field));
		}

		private static void SetField(ref MessageField field, int length, int offset)
		{
			if (length > 32767)
			{
				throw new Win32Exception(-2146893792);
			}
			Span<byte> destination = MemoryMarshal.AsBytes(new Span<MessageField>(ref field));
			BinaryPrimitives.WriteInt16LittleEndian(destination, (short)length);
			BinaryPrimitives.WriteInt16LittleEndian(destination.Slice(2), (short)length);
			BinaryPrimitives.WriteInt32LittleEndian(destination.Slice(4), offset);
		}

		private static void AddToPayload(ref MessageField field, ReadOnlySpan<byte> data, Span<byte> payload, ref int offset)
		{
			SetField(ref field, data.Length, offset);
			data.CopyTo(payload.Slice(offset));
			offset += data.Length;
		}

		private static void AddToPayload(ref MessageField field, ReadOnlySpan<char> data, Span<byte> payload, ref int offset)
		{
			int bytes = Encoding.Unicode.GetBytes(data, payload.Slice(offset));
			SetField(ref field, bytes, offset);
			offset += bytes;
		}

		private static void makeNtlm2Hash(string domain, string userName, ReadOnlySpan<char> password, Span<byte> hash)
		{
			if (password.Length > 128)
			{
				throw new Win32Exception(-2146893792);
			}
			Span<byte> span = stackalloc byte[16];
			Span<byte> span2 = stackalloc byte[Encoding.Unicode.GetByteCount(password)];
			try
			{
				Encoding.Unicode.GetBytes(password, span2);
				MD4.HashData(span2, span);
				byte[] bytes = Encoding.Unicode.GetBytes(userName.ToUpperInvariant() + domain);
				HMACMD5.HashData(span, bytes, hash);
			}
			finally
			{
				CryptographicOperations.ZeroMemory(span2);
				CryptographicOperations.ZeroMemory(span);
			}
		}

		private unsafe void makeNtlm2ChallengeResponse(DateTime time, ReadOnlySpan<byte> ntlm2hash, ReadOnlySpan<byte> serverChallenge, Span<byte> clientChallenge, ReadOnlySpan<byte> serverInfo, ref MessageField field, Span<byte> payload, ref int payloadOffset)
		{
			Span<byte> destination = payload.Slice(payloadOffset, sizeof(NtChallengeResponse) + serverInfo.Length);
			ref NtChallengeResponse reference = ref MemoryMarshal.AsRef<NtChallengeResponse>(destination.Slice(0, sizeof(NtChallengeResponse)));
			reference.HiResponserversion = 1;
			reference.Responserversion = 1;
			reference.Time = time.ToFileTimeUtc();
			clientChallenge.CopyTo(MemoryMarshal.CreateSpan(ref reference.ClientChallenge[0], 8));
			serverInfo.CopyTo(MemoryMarshal.CreateSpan(ref reference.ServerInfo[0], serverInfo.Length));
			using (IncrementalHash incrementalHash = IncrementalHash.CreateHMAC(HashAlgorithmName.MD5, ntlm2hash))
			{
				incrementalHash.AppendData(serverChallenge);
				incrementalHash.AppendData(destination.Slice(16));
				incrementalHash.GetHashAndReset(destination);
			}
			SetField(ref field, destination.Length, payloadOffset);
			payloadOffset += destination.Length;
		}

		private unsafe void WriteChannelBindingHash(Span<byte> hashBuffer)
		{
			if (_channelBinding != null)
			{
				int num = sizeof(SecChannelBindings);
				nint pointer = _channelBinding.DangerousGetHandle() + num;
				int num2 = _channelBinding.Size - num;
				Span<byte> span = stackalloc byte[20];
				span.Clear();
				BinaryPrimitives.WriteInt32LittleEndian(span.Slice(16), num2);
				using IncrementalHash incrementalHash = IncrementalHash.CreateHash(HashAlgorithmName.MD5);
				incrementalHash.AppendData(span);
				incrementalHash.AppendData(new Span<byte>((void*)pointer, num2));
				incrementalHash.GetHashAndReset(hashBuffer);
				return;
			}
			hashBuffer.Clear();
		}

		private byte[] ProcessTargetInfo(ReadOnlySpan<byte> targetInfo, out DateTime time, out bool hasNbNames)
		{
			int num = ((_spn != null) ? Encoding.Unicode.GetByteCount(_spn) : 0);
			if (num > 32767)
			{
				throw new Win32Exception(-2146893792);
			}
			bool flag = false;
			bool flag2 = false;
			byte[] array = new byte[targetInfo.Length + 20 + 4 + num + 8];
			int num2 = 0;
			time = DateTime.UtcNow;
			if (targetInfo.Length > 0)
			{
				ReadOnlySpan<byte> readOnlySpan = targetInfo;
				while (readOnlySpan.Length >= 4)
				{
					AvId avId = (AvId)readOnlySpan[0];
					byte b = readOnlySpan[2];
					int num3 = (readOnlySpan[3] << 8) + b;
					if (avId == AvId.EOL)
					{
						break;
					}
					switch (avId)
					{
					case AvId.Timestamp:
						time = DateTime.FromFileTimeUtc(BitConverter.ToInt64(readOnlySpan.Slice(4, 8)));
						break;
					case AvId.TargetName:
					case AvId.ChannelBindings:
						readOnlySpan = readOnlySpan.Slice(num3 + 4);
						continue;
					case AvId.NbComputerName:
						flag = true;
						break;
					case AvId.NbDomainName:
						flag2 = true;
						break;
					}
					readOnlySpan.Slice(0, num3 + 4).CopyTo(array.AsSpan(num2, num3 + 4));
					num2 += num3 + 4;
					readOnlySpan = readOnlySpan.Slice(num3 + 4);
				}
			}
			hasNbNames = flag && flag2;
			array[num2] = 9;
			BinaryPrimitives.WriteUInt16LittleEndian(array.AsSpan(2 + num2), (ushort)num);
			if (_spn != null)
			{
				Encoding.Unicode.GetBytes(_spn.AsSpan(), array.AsSpan(4 + num2));
			}
			num2 += num + 4;
			array[num2] = 10;
			array[num2 + 2] = 16;
			WriteChannelBindingHash(array.AsSpan(num2 + 4, 16));
			num2 += 20;
			array[num2] = 6;
			array[num2 + 2] = 4;
			array[num2 + 4] = 2;
			num2 += 8;
			num2 += 4;
			if (num2 == array.Length)
			{
				return array;
			}
			return array.AsSpan(num2).ToArray();
		}

		private static byte[] DeriveKey(ReadOnlySpan<byte> exportedSessionKey, ReadOnlySpan<byte> magic)
		{
			using IncrementalHash incrementalHash = IncrementalHash.CreateHash(HashAlgorithmName.MD5);
			incrementalHash.AppendData(exportedSessionKey);
			incrementalHash.AppendData(magic);
			return incrementalHash.GetHashAndReset();
		}

		private unsafe byte[] ProcessChallenge(ReadOnlySpan<byte> blob, out NegotiateAuthenticationStatusCode statusCode)
		{
			ref readonly ChallengeMessage reference = ref MemoryMarshal.AsRef<ChallengeMessage>(blob.Slice(0, sizeof(ChallengeMessage)));
			if (reference.Header.MessageType != MessageType.Challenge || !NtlmHeader.SequenceEqual(blob.Slice(0, NtlmHeader.Length)))
			{
				statusCode = NegotiateAuthenticationStatusCode.InvalidToken;
				return null;
			}
			if (!BitConverter.IsLittleEndian)
			{
			}
			Flags flags = reference.Flags;
			GetField(reference.TargetName, blob);
			if ((flags & (Flags.NegotiateUnicode | Flags.TargetName | Flags.NegotiateSign | Flags.NegotiateNtlm | Flags.NegotiateAlwaysSign | Flags.NegotiateNtlm2 | Flags.NegotiateTargetInfo | Flags.NegotiateVersion | Flags.Negotiate128 | Flags.NegotiateKeyExchange)) != (Flags.NegotiateUnicode | Flags.TargetName | Flags.NegotiateSign | Flags.NegotiateNtlm | Flags.NegotiateAlwaysSign | Flags.NegotiateNtlm2 | Flags.NegotiateTargetInfo | Flags.NegotiateVersion | Flags.Negotiate128 | Flags.NegotiateKeyExchange))
			{
				statusCode = NegotiateAuthenticationStatusCode.InvalidToken;
				return null;
			}
			if ((flags & Flags.NegotiateSeal) == 0 && _protectionLevel == ProtectionLevel.EncryptAndSign)
			{
				statusCode = NegotiateAuthenticationStatusCode.QopNotSupported;
				return null;
			}
			ReadOnlySpan<byte> field = GetField(reference.TargetInfo, blob);
			DateTime time;
			bool hasNbNames;
			byte[] array = ProcessTargetInfo(field, out time, out hasNbNames);
			if (!hasNbNames && (flags & (Flags.NegotiateSign | Flags.NegotiateSeal)) != 0)
			{
				statusCode = NegotiateAuthenticationStatusCode.InvalidToken;
				return null;
			}
			byte[] array2 = new byte[sizeof(AuthenticateMessage) + 24 + sizeof(NtChallengeResponse) + array.Length + Encoding.Unicode.GetByteCount(_credential.UserName) + Encoding.Unicode.GetByteCount(_credential.Domain) + s_workstation.Length + 16];
			Span<byte> span = new Span<byte>(array2);
			ref AuthenticateMessage reference2 = ref MemoryMarshal.AsRef<AuthenticateMessage>(span.Slice(0, sizeof(AuthenticateMessage)));
			Span<byte> payload = span;
			int num = sizeof(AuthenticateMessage);
			span.Clear();
			NtlmHeader.CopyTo(span);
			reference2.Header.MessageType = MessageType.Authenticate;
			reference2.Flags = Flags.NegotiateUnicode | Flags.TargetName | Flags.NegotiateSign | Flags.NegotiateNtlm | Flags.NegotiateAlwaysSign | Flags.NegotiateNtlm2 | Flags.NegotiateTargetInfo | Flags.NegotiateVersion | Flags.Negotiate128 | Flags.NegotiateKeyExchange | (flags & Flags.NegotiateSeal);
			reference2.Version = s_version;
			Span<byte> span2 = stackalloc byte[16];
			makeNtlm2Hash(_credential.Domain, _credential.UserName, _credential.Password.AsSpan(), span2);
			Span<byte> span3 = stackalloc byte[8];
			RandomNumberGenerator.Fill(span3);
			SetField(ref reference2.LmChallengeResponse, 24, num);
			payload.Slice(num, 24).Clear();
			num += 24;
			ReadOnlySpan<byte> serverChallenge = blob.Slice(24, 8);
			makeNtlm2ChallengeResponse(time, span2, serverChallenge, span3, array, ref reference2.NtChallengeResponse, payload, ref num);
			AddToPayload(ref reference2.UserName, _credential.UserName.AsSpan(), payload, ref num);
			AddToPayload(ref reference2.DomainName, _credential.Domain.AsSpan(), payload, ref num);
			AddToPayload(ref reference2.Workstation, s_workstation, payload, ref num);
			Span<byte> span4 = stackalloc byte[16];
			RandomNumberGenerator.Fill(span4);
			Span<byte> span5 = stackalloc byte[16];
			HMACMD5.HashData(span2, span.Slice(reference2.NtChallengeResponse.PayloadOffset, 16), span5);
			using (RC4 rC = new RC4(span5))
			{
				Span<byte> output = payload.Slice(num, 16);
				rC.Transform(span4, output);
				SetField(ref reference2.EncryptedRandomSessionKey, 16, num);
				num += 16;
			}
			using (IncrementalHash incrementalHash = IncrementalHash.CreateHMAC(HashAlgorithmName.MD5, span4))
			{
				incrementalHash.AppendData(_negotiateMessage);
				incrementalHash.AppendData(blob);
				incrementalHash.AppendData(array2.AsSpan(0, num));
				incrementalHash.GetHashAndReset(MemoryMarshal.CreateSpan(ref reference2.Mic[0], incrementalHash.HashLengthInBytes));
			}
			_clientSigningKey = DeriveKey(span4, ClientSigningKeyMagic);
			_serverSigningKey = DeriveKey(span4, ServerSigningKeyMagic);
			_clientSealingKey = DeriveKey(span4, ClientSealingKeyMagic);
			_serverSealingKey = DeriveKey(span4, ServerSealingKeyMagic);
			ResetKeys();
			_clientSequenceNumber = 0u;
			_serverSequenceNumber = 0u;
			CryptographicOperations.ZeroMemory(span4);
			statusCode = NegotiateAuthenticationStatusCode.Completed;
			return array2;
		}

		internal void ResetKeys()
		{
			_clientSeal?.Dispose();
			_serverSeal?.Dispose();
			_clientSeal = new RC4(_clientSealingKey);
			_serverSeal = new RC4(_serverSealingKey);
		}

		private void CalculateSignature(ReadOnlySpan<byte> message, uint sequenceNumber, ReadOnlySpan<byte> signingKey, RC4 seal, Span<byte> signature)
		{
			BinaryPrimitives.WriteInt32LittleEndian(signature, 1);
			BinaryPrimitives.WriteUInt32LittleEndian(signature.Slice(12), sequenceNumber);
			using IncrementalHash incrementalHash = IncrementalHash.CreateHMAC(HashAlgorithmName.MD5, signingKey);
			incrementalHash.AppendData(signature.Slice(12, 4));
			incrementalHash.AppendData(message);
			Span<byte> destination = stackalloc byte[incrementalHash.HashLengthInBytes];
			incrementalHash.GetHashAndReset(destination);
			seal.Transform(destination.Slice(0, 8), signature.Slice(4, 8));
		}

		public override bool VerifyMIC(ReadOnlySpan<byte> message, ReadOnlySpan<byte> signature)
		{
			if (signature.Length != 16 || BinaryPrimitives.ReadInt32LittleEndian(signature) != 1 || _serverSeal == null || _serverSigningKey == null)
			{
				return false;
			}
			Span<byte> span = stackalloc byte[16];
			CalculateSignature(message, _serverSequenceNumber, _serverSigningKey, _serverSeal, span);
			_serverSequenceNumber++;
			return signature.SequenceEqual(span);
		}

		public override void GetMIC(ReadOnlySpan<byte> message, IBufferWriter<byte> signature)
		{
			Span<byte> span = signature.GetSpan(16);
			CalculateSignature(message, _clientSequenceNumber, _clientSigningKey, _clientSeal, span);
			_clientSequenceNumber++;
			signature.Advance(16);
		}
	}

	internal sealed class ManagedSpnegoNegotiateAuthenticationPal : NegotiateAuthenticationPal
	{
		private enum NegState
		{
			Unknown = -1,
			AcceptCompleted,
			AcceptIncomplete,
			Reject,
			RequestMic
		}

		private readonly NegotiateAuthenticationClientOptions _clientOptions;

		private byte[] _spnegoMechList;

		private bool _isAuthenticated;

		private bool _supportKerberos;

		private NegotiateAuthenticationPal _optimisticMechanism;

		private NegotiateAuthenticationPal _mechanism;

		public override bool IsAuthenticated
		{
			get
			{
				if (_isAuthenticated)
				{
					return _mechanism?.IsAuthenticated ?? false;
				}
				return false;
			}
		}

		public override bool IsSigned => _mechanism?.IsSigned ?? false;

		public override bool IsEncrypted => _mechanism?.IsEncrypted ?? false;

		public override string Package => _mechanism?.Package ?? "Negotiate";

		public override string TargetName => _clientOptions.TargetName;

		public override TokenImpersonationLevel ImpersonationLevel => _mechanism?.ImpersonationLevel ?? TokenImpersonationLevel.Impersonation;

		public ManagedSpnegoNegotiateAuthenticationPal(NegotiateAuthenticationClientOptions clientOptions, bool supportKerberos = false)
		{
			_clientOptions = clientOptions;
			_supportKerberos = supportKerberos;
		}

		public override void Dispose()
		{
			_optimisticMechanism?.Dispose();
			_optimisticMechanism = null;
			_mechanism?.Dispose();
			_mechanism = null;
			_isAuthenticated = false;
		}

		public override byte[] GetOutgoingBlob(ReadOnlySpan<byte> incomingBlob, out NegotiateAuthenticationStatusCode statusCode)
		{
			if (_spnegoMechList == null)
			{
				return CreateSpNegoNegotiateMessage(incomingBlob, out statusCode);
			}
			return ProcessSpNegoChallenge(incomingBlob, out statusCode);
		}

		private NegotiateAuthenticationPal CreateMechanismForPackage(string packageName)
		{
			return Create(new NegotiateAuthenticationClientOptions
			{
				Package = packageName,
				Credential = _clientOptions.Credential,
				TargetName = _clientOptions.TargetName,
				Binding = _clientOptions.Binding,
				RequiredProtectionLevel = _clientOptions.RequiredProtectionLevel,
				RequireMutualAuthentication = _clientOptions.RequireMutualAuthentication,
				AllowedImpersonationLevel = _clientOptions.AllowedImpersonationLevel
			});
		}

		private IEnumerable<KeyValuePair<string, string>> EnumerateMechanisms()
		{
			if (_supportKerberos)
			{
				yield return new KeyValuePair<string, string>("Kerberos", "1.2.840.113554.1.2.2");
			}
			yield return new KeyValuePair<string, string>("NTLM", "1.3.6.1.4.1.311.2.2.10");
		}

		private byte[] CreateSpNegoNegotiateMessage(ReadOnlySpan<byte> incomingBlob, out NegotiateAuthenticationStatusCode statusCode)
		{
			AsnWriter asnWriter = new AsnWriter(AsnEncodingRules.DER);
			using (asnWriter.PushSequence(new Asn1Tag(TagClass.Application, 0)))
			{
				asnWriter.WriteObjectIdentifier("1.3.6.1.5.5.2");
				using (asnWriter.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 0)))
				{
					using (asnWriter.PushSequence())
					{
						byte[] array = null;
						using (asnWriter.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 0)))
						{
							AsnWriter asnWriter2 = new AsnWriter(AsnEncodingRules.DER);
							using (asnWriter2.PushSequence())
							{
								foreach (KeyValuePair<string, string> item in EnumerateMechanisms())
								{
									if (_optimisticMechanism == null)
									{
										_optimisticMechanism = CreateMechanismForPackage(item.Key);
										array = _optimisticMechanism.GetOutgoingBlob(incomingBlob, out statusCode);
										if (statusCode != NegotiateAuthenticationStatusCode.ContinueNeeded && statusCode != NegotiateAuthenticationStatusCode.Completed)
										{
											array = null;
											_optimisticMechanism?.Dispose();
											_optimisticMechanism = null;
											if (statusCode != NegotiateAuthenticationStatusCode.Unsupported)
											{
												return null;
											}
											continue;
										}
									}
									asnWriter2.WriteObjectIdentifier(item.Value);
								}
							}
							_spnegoMechList = asnWriter2.Encode();
							asnWriter2.CopyTo(asnWriter);
						}
						if (array != null)
						{
							using (asnWriter.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 2)))
							{
								asnWriter.WriteOctetString(array);
							}
						}
					}
				}
			}
			statusCode = NegotiateAuthenticationStatusCode.ContinueNeeded;
			return asnWriter.Encode();
		}

		private byte[] ProcessSpNegoChallenge(ReadOnlySpan<byte> challenge, out NegotiateAuthenticationStatusCode statusCode)
		{
			NegState negState = NegState.Unknown;
			string text = null;
			byte[] array = null;
			byte[] array2 = null;
			try
			{
				System.Formats.Asn1.AsnValueReader asnValueReader = new System.Formats.Asn1.AsnValueReader(challenge, AsnEncodingRules.DER);
				System.Formats.Asn1.AsnValueReader asnValueReader2 = asnValueReader.ReadSequence(new Asn1Tag(TagClass.ContextSpecific, 1));
				asnValueReader.ThrowIfNotEmpty();
				asnValueReader2 = asnValueReader2.ReadSequence();
				if (asnValueReader2.HasData && asnValueReader2.PeekTag().HasSameClassAndValue(new Asn1Tag(TagClass.ContextSpecific, 0)))
				{
					System.Formats.Asn1.AsnValueReader asnValueReader3 = asnValueReader2.ReadSequence(new Asn1Tag(TagClass.ContextSpecific, 0));
					negState = asnValueReader3.ReadEnumeratedValue<NegState>();
					asnValueReader3.ThrowIfNotEmpty();
				}
				if (asnValueReader2.HasData && asnValueReader2.PeekTag().HasSameClassAndValue(new Asn1Tag(TagClass.ContextSpecific, 1)))
				{
					System.Formats.Asn1.AsnValueReader asnValueReader4 = asnValueReader2.ReadSequence(new Asn1Tag(TagClass.ContextSpecific, 1));
					text = asnValueReader4.ReadObjectIdentifier();
					asnValueReader4.ThrowIfNotEmpty();
				}
				if (asnValueReader2.HasData && asnValueReader2.PeekTag().HasSameClassAndValue(new Asn1Tag(TagClass.ContextSpecific, 2)))
				{
					System.Formats.Asn1.AsnValueReader asnValueReader5 = asnValueReader2.ReadSequence(new Asn1Tag(TagClass.ContextSpecific, 2));
					array = asnValueReader5.ReadOctetString();
					asnValueReader5.ThrowIfNotEmpty();
				}
				if (asnValueReader2.HasData && asnValueReader2.PeekTag().HasSameClassAndValue(new Asn1Tag(TagClass.ContextSpecific, 3)))
				{
					System.Formats.Asn1.AsnValueReader asnValueReader6 = asnValueReader2.ReadSequence(new Asn1Tag(TagClass.ContextSpecific, 3));
					array2 = asnValueReader6.ReadOctetString();
					asnValueReader6.ThrowIfNotEmpty();
				}
				asnValueReader2.ThrowIfNotEmpty();
			}
			catch (AsnContentException)
			{
				statusCode = NegotiateAuthenticationStatusCode.InvalidToken;
				return null;
			}
			string text2 = ((text == "1.3.6.1.4.1.311.2.2.10") ? "NTLM" : ((!(text == "1.2.840.113554.1.2.2")) ? null : "Kerberos"));
			string text3 = text2;
			if (_mechanism == null)
			{
				if (text3 == null)
				{
					statusCode = NegotiateAuthenticationStatusCode.Unsupported;
					return null;
				}
				if (text3 == _optimisticMechanism?.Package)
				{
					_mechanism = _optimisticMechanism;
				}
				else
				{
					_optimisticMechanism?.Dispose();
					_mechanism = CreateMechanismForPackage(text3);
				}
				_optimisticMechanism = null;
			}
			else if (text3 != null && _mechanism.Package != text3)
			{
				statusCode = NegotiateAuthenticationStatusCode.InvalidToken;
				return null;
			}
			if (array != null && array.Length != 0)
			{
				byte[] outgoingBlob = _mechanism.GetOutgoingBlob(array, out statusCode);
				if (statusCode != NegotiateAuthenticationStatusCode.ContinueNeeded && statusCode != NegotiateAuthenticationStatusCode.Completed)
				{
					return null;
				}
				if (outgoingBlob != null && outgoingBlob.Length != 0)
				{
					AsnWriter asnWriter = new AsnWriter(AsnEncodingRules.DER);
					using (asnWriter.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 1)))
					{
						using (asnWriter.PushSequence())
						{
							using (asnWriter.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 2)))
							{
								asnWriter.WriteOctetString(outgoingBlob);
							}
							if (statusCode == NegotiateAuthenticationStatusCode.Completed)
							{
								using (asnWriter.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 3)))
								{
									ArrayBufferWriter<byte> arrayBufferWriter = new ArrayBufferWriter<byte>();
									_mechanism.GetMIC(_spnegoMechList, arrayBufferWriter);
									asnWriter.WriteOctetString(arrayBufferWriter.WrittenSpan);
								}
							}
						}
					}
					statusCode = ((negState == NegState.RequestMic) ? NegotiateAuthenticationStatusCode.ContinueNeeded : NegotiateAuthenticationStatusCode.Completed);
					_isAuthenticated = statusCode == NegotiateAuthenticationStatusCode.Completed;
					return asnWriter.Encode();
				}
			}
			if (array2 != null && !((ReadOnlySpan<byte>)array2.AsSpan()).SequenceEqual((ReadOnlySpan<byte>)array.AsSpan()))
			{
				if (_spnegoMechList == null || negState != NegState.AcceptCompleted)
				{
					statusCode = NegotiateAuthenticationStatusCode.GenericFailure;
					return null;
				}
				if (!_mechanism.VerifyMIC(_spnegoMechList, array2))
				{
					statusCode = NegotiateAuthenticationStatusCode.MessageAltered;
					return null;
				}
				(_mechanism as ManagedNtlmNegotiateAuthenticationPal)?.ResetKeys();
			}
			_isAuthenticated = negState == NegState.AcceptCompleted || negState == NegState.Reject;
			statusCode = negState switch
			{
				NegState.AcceptCompleted => NegotiateAuthenticationStatusCode.Completed, 
				NegState.AcceptIncomplete => NegotiateAuthenticationStatusCode.ContinueNeeded, 
				NegState.Reject => NegotiateAuthenticationStatusCode.UnknownCredentials, 
				_ => NegotiateAuthenticationStatusCode.GenericFailure, 
			};
			return null;
		}

		public override bool VerifyMIC(ReadOnlySpan<byte> message, ReadOnlySpan<byte> signature)
		{
			if (_mechanism == null || !_isAuthenticated)
			{
				throw new InvalidOperationException("net_auth_noauth");
			}
			return _mechanism.VerifyMIC(message, signature);
		}

		public override void GetMIC(ReadOnlySpan<byte> message, IBufferWriter<byte> signature)
		{
			if (_mechanism == null || !_isAuthenticated)
			{
				throw new InvalidOperationException("net_auth_noauth");
			}
			_mechanism.GetMIC(message, signature);
		}
	}

	public abstract bool IsAuthenticated { get; }

	public abstract bool IsSigned { get; }

	public abstract bool IsEncrypted { get; }

	public abstract string Package { get; }

	public abstract string TargetName { get; }

	public abstract TokenImpersonationLevel ImpersonationLevel { get; }

	public abstract void Dispose();

	public abstract byte[] GetOutgoingBlob(ReadOnlySpan<byte> incomingBlob, out NegotiateAuthenticationStatusCode statusCode);

	public abstract void GetMIC(ReadOnlySpan<byte> message, IBufferWriter<byte> signature);

	public abstract bool VerifyMIC(ReadOnlySpan<byte> message, ReadOnlySpan<byte> signature);

	public static NegotiateAuthenticationPal Create(NegotiateAuthenticationClientOptions clientOptions)
	{
		string package = clientOptions.Package;
		if (!(package == "NTLM"))
		{
			if (package == "Negotiate")
			{
				return new ManagedSpnegoNegotiateAuthenticationPal(clientOptions);
			}
			return new UnsupportedNegotiateAuthenticationPal(clientOptions);
		}
		return ManagedNtlmNegotiateAuthenticationPal.Create(clientOptions);
	}
}
