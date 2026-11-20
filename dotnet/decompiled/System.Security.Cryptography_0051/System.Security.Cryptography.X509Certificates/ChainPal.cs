using System.Collections.Generic;
using System.Runtime.InteropServices;
using Internal.Cryptography;

namespace System.Security.Cryptography.X509Certificates;

internal sealed class ChainPal
{
	private sealed class AndroidCertPath : IChainPal, IDisposable
	{
		private SafeX509ChainContextHandle _chainContext;

		private bool _isValid;

		public X509ChainElement[] ChainElements { get; private set; }

		public X509ChainStatus[] ChainStatus { get; private set; }

		public void Dispose()
		{
			_chainContext?.Dispose();
		}

		public bool? Verify(X509VerificationFlags flags, out Exception exception)
		{
			exception = null;
			if (!_isValid)
			{
				return false;
			}
			return UnixChainVerifier.Verify(ChainElements, flags);
		}

		internal void Initialize(ICertificatePal cert, X509Certificate2Collection extraStore, X509Certificate2Collection customTrustStore, X509ChainTrustMode trustMode)
		{
			List<SafeHandle> list = new List<SafeHandle> { ((AndroidCertificatePal)cert).SafeHandle };
			if (extraStore != null)
			{
				foreach (X509Certificate2 item in extraStore)
				{
					list.Add(((AndroidCertificatePal)item.Pal).SafeHandle);
				}
			}
			List<SafeHandle> list2 = new List<SafeHandle>();
			bool flag = trustMode == X509ChainTrustMode.CustomRootTrust;
			if (flag && customTrustStore != null)
			{
				foreach (X509Certificate2 item2 in customTrustStore)
				{
					SafeHandle safeHandle = ((AndroidCertificatePal)item2.Pal).SafeHandle;
					if (item2.SubjectName.RawData.ContentsEqual(item2.IssuerName.RawData))
					{
						list2.Add(safeHandle);
					}
					else
					{
						list.Add(safeHandle);
					}
				}
			}
			int i = 0;
			int j = 0;
			try
			{
				nint[] array = new nint[list.Count];
				for (i = 0; i < list.Count; i++)
				{
					SafeHandle safeHandle2 = list[i];
					bool success = false;
					safeHandle2.DangerousAddRef(ref success);
					array[i] = safeHandle2.DangerousGetHandle();
				}
				_chainContext = global::Interop.AndroidCrypto.X509ChainCreateContext(((AndroidCertificatePal)cert).SafeHandle, array);
				if (flag)
				{
					if (list2.Count == 0)
					{
						throw new PlatformNotSupportedException("Chain_EmptyCustomTrustNotSupported");
					}
					nint[] array2 = new nint[list2.Count];
					for (j = 0; j < list2.Count; j++)
					{
						SafeHandle safeHandle3 = list2[j];
						bool success2 = false;
						safeHandle3.DangerousAddRef(ref success2);
						array2[j] = safeHandle3.DangerousGetHandle();
					}
					if (global::Interop.AndroidCrypto.X509ChainSetCustomTrustStore(_chainContext, array2, array2.Length) != 1)
					{
						throw new CryptographicException();
					}
				}
			}
			finally
			{
				for (i--; i >= 0; i--)
				{
					list[i].DangerousRelease();
				}
				for (j--; j >= 0; j--)
				{
					list2[j].DangerousRelease();
				}
			}
		}

		internal void Evaluate(DateTime verificationTime, OidCollection applicationPolicy, OidCollection certificatePolicy, X509RevocationMode revocationMode, X509RevocationFlag revocationFlag)
		{
			long timeInMsFromUnixEpoch = new DateTimeOffset(verificationTime).ToUnixTimeMilliseconds();
			_isValid = global::Interop.AndroidCrypto.X509ChainBuild(_chainContext, timeInMsFromUnixEpoch);
			if (!_isValid)
			{
				ChainElements = Array.Empty<X509ChainElement>();
				global::Interop.AndroidCrypto.ValidationError[] array = global::Interop.AndroidCrypto.X509ChainGetErrors(_chainContext);
				X509ChainStatus[] array2 = new X509ChainStatus[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					global::Interop.AndroidCrypto.ValidationError error = array[i];
					array2[i] = ValidationErrorToChainStatus(error);
					Marshal.FreeHGlobal(error.Message);
				}
				ChainStatus = array2;
				return;
			}
			if (global::Interop.AndroidCrypto.X509ChainValidate(_chainContext, revocationMode, revocationFlag, out var checkedRevocation) != 1)
			{
				throw new CryptographicException();
			}
			X509Certificate2[] array3 = global::Interop.AndroidCrypto.X509ChainGetCertificates(_chainContext);
			List<X509ChainStatus> list = new List<X509ChainStatus>();
			List<X509ChainStatus>[] array4 = new List<X509ChainStatus>[array3.Length];
			int num = -1;
			int num2 = -1;
			Dictionary<int, List<X509ChainStatus>> statusByIndex = GetStatusByIndex(_chainContext);
			foreach (int key in statusByIndex.Keys)
			{
				List<X509ChainStatus> list2 = statusByIndex[key];
				for (int j = 0; j < list2.Count; j++)
				{
					X509ChainStatus status = list2[j];
					AddUniqueStatus(list, ref status);
				}
				if (key != -1)
				{
					array4[key] = statusByIndex[key];
					if (statusByIndex[key].Exists((X509ChainStatus s) => s.Status == X509ChainStatusFlags.Revoked || s.Status == X509ChainStatusFlags.RevocationStatusUnknown))
					{
						num2 = Math.Max(key, num2);
					}
					else
					{
						num = Math.Max(key, num);
					}
				}
			}
			if (num > 0)
			{
				X509ChainStatus statusToSet = new X509ChainStatus
				{
					Status = X509ChainStatusFlags.PartialChain,
					StatusInformation = "Chain_PartialChain"
				};
				AddStatusFromIndexToEndCertificate(num - 1, ref statusToSet, array4, list);
			}
			if (num2 > 0)
			{
				X509ChainStatus statusToSet2 = new X509ChainStatus
				{
					Status = X509ChainStatusFlags.RevocationStatusUnknown,
					StatusInformation = "Chain_RevocationStatusUnknown"
				};
				AddStatusFromIndexToEndCertificate(num2 - 1, ref statusToSet2, array4, list);
			}
			if (revocationMode != X509RevocationMode.NoCheck && checkedRevocation == 0)
			{
				X509ChainStatus statusToSet3 = new X509ChainStatus
				{
					Status = X509ChainStatusFlags.RevocationStatusUnknown,
					StatusInformation = "Chain_RevocationStatusUnknown"
				};
				AddStatusFromIndexToEndCertificate(array4.Length - 1, ref statusToSet3, array4, list);
			}
			if (!IsPolicyMatch(array3, applicationPolicy, certificatePolicy))
			{
				X509ChainStatus statusToSet4 = new X509ChainStatus
				{
					Status = X509ChainStatusFlags.NotValidForUsage,
					StatusInformation = "Chain_NoPolicyMatch"
				};
				AddStatusFromIndexToEndCertificate(array4.Length - 1, ref statusToSet4, array4, list);
			}
			X509ChainElement[] array5 = new X509ChainElement[array3.Length];
			for (int num3 = 0; num3 < array3.Length; num3++)
			{
				X509ChainStatus[] chainElementStatus = ((array4[num3] == null) ? Array.Empty<X509ChainStatus>() : array4[num3].ToArray());
				array5[num3] = new X509ChainElement(array3[num3], chainElementStatus, string.Empty);
			}
			ChainElements = array5;
			ChainStatus = list.ToArray();
		}

		private static void AddStatusFromIndexToEndCertificate(int index, ref X509ChainStatus statusToSet, List<X509ChainStatus>[] statuses, List<X509ChainStatus> overallStatus)
		{
			AddUniqueStatus(overallStatus, ref statusToSet);
			for (int num = index; num >= 0; num--)
			{
				int num2 = num;
				if (statuses[num2] == null)
				{
					statuses[num2] = new List<X509ChainStatus>();
				}
				AddUniqueStatus(statuses[num], ref statusToSet);
			}
		}

		private static void AddUniqueStatus(List<X509ChainStatus> list, ref X509ChainStatus status)
		{
			X509ChainStatusFlags statusFlags = status.Status;
			string statusInfo = status.StatusInformation;
			if (!list.Exists((X509ChainStatus s) => s.Status == statusFlags && s.StatusInformation == statusInfo))
			{
				list.Add(status);
			}
		}

		private static Dictionary<int, List<X509ChainStatus>> GetStatusByIndex(SafeX509ChainContextHandle ctx)
		{
			Dictionary<int, List<X509ChainStatus>> dictionary = new Dictionary<int, List<X509ChainStatus>>();
			global::Interop.AndroidCrypto.ValidationError[] array = global::Interop.AndroidCrypto.X509ChainGetErrors(ctx);
			for (int i = 0; i < array.Length; i++)
			{
				global::Interop.AndroidCrypto.ValidationError error = array[i];
				X509ChainStatus item = ValidationErrorToChainStatus(error);
				Marshal.FreeHGlobal(error.Message);
				if (!dictionary.TryGetValue(error.Index, out var value))
				{
					value = new List<X509ChainStatus>();
					dictionary.Add(error.Index, value);
				}
				value.Add(item);
			}
			return dictionary;
		}

		private static X509ChainStatus ValidationErrorToChainStatus(global::Interop.AndroidCrypto.ValidationError error)
		{
			X509ChainStatusFlags status = (X509ChainStatusFlags)error.Status;
			return new X509ChainStatus
			{
				Status = status,
				StatusInformation = Marshal.PtrToStringUni(error.Message)
			};
		}

		private static bool IsPolicyMatch(X509Certificate2[] certs, OidCollection applicationPolicy, OidCollection certificatePolicy)
		{
			bool flag = applicationPolicy != null && applicationPolicy.Count > 0;
			bool flag2 = certificatePolicy != null && certificatePolicy.Count > 0;
			if (!flag && !flag2)
			{
				return true;
			}
			CertificatePolicyChain certificatePolicyChain = new CertificatePolicyChain(new List<X509Certificate2>(certs));
			if (flag2 && !certificatePolicyChain.MatchesCertificatePolicies(certificatePolicy))
			{
				return false;
			}
			if (flag && !certificatePolicyChain.MatchesApplicationPolicies(applicationPolicy))
			{
				return false;
			}
			return true;
		}
	}

	internal static IChainPal BuildChain(bool useMachineContext, ICertificatePal cert, X509Certificate2Collection extraStore, OidCollection applicationPolicy, OidCollection certificatePolicy, X509RevocationMode revocationMode, X509RevocationFlag revocationFlag, X509Certificate2Collection customTrustStore, X509ChainTrustMode trustMode, DateTime verificationTime, TimeSpan timeout, bool disableAia)
	{
		AndroidCertPath androidCertPath = new AndroidCertPath();
		try
		{
			androidCertPath.Initialize(cert, extraStore, customTrustStore, trustMode);
			androidCertPath.Evaluate(verificationTime, applicationPolicy, certificatePolicy, revocationMode, revocationFlag);
			return androidCertPath;
		}
		catch
		{
			androidCertPath.Dispose();
			throw;
		}
	}
}
