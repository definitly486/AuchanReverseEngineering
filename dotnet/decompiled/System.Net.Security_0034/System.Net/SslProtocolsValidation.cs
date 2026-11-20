using System.Security.Authentication;

namespace System.Net;

internal static class SslProtocolsValidation
{
	public static (int MinIndex, int MaxIndex) ValidateContiguous(this SslProtocols protocols, ReadOnlySpan<SslProtocols> orderedSslProtocols)
	{
		Span<bool> span = stackalloc bool[orderedSslProtocols.Length];
		for (int i = 0; i < orderedSslProtocols.Length; i++)
		{
			span[i] = (protocols & orderedSslProtocols[i]) != 0;
		}
		int num = -1;
		int num2 = -1;
		for (int j = 0; j < span.Length; j++)
		{
			if (!span[j])
			{
				continue;
			}
			num = j;
			for (int k = j + 1; k < span.Length; k++)
			{
				if (span[k])
				{
					continue;
				}
				num2 = k - 1;
				for (int l = k + 1; l < span.Length; l++)
				{
					if (span[l])
					{
						throw new PlatformNotSupportedException(System.SR.Format("net_security_sslprotocol_contiguous", protocols));
					}
				}
				break;
			}
			break;
		}
		if (num == -1)
		{
			throw new PlatformNotSupportedException("net_securityprotocolnotsupported");
		}
		if (num2 == -1)
		{
			num2 = orderedSslProtocols.Length - 1;
		}
		return (MinIndex: num, MaxIndex: num2);
	}
}
