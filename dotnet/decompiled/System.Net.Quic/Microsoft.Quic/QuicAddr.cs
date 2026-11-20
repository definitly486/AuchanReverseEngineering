using System.Runtime.InteropServices;

namespace Microsoft.Quic;

[StructLayout(LayoutKind.Explicit)]
internal struct QuicAddr
{
	[FieldOffset(0)]
	public QuicAddrIn Ipv4;

	[FieldOffset(0)]
	public QuicAddrIn6 Ipv6;

	[FieldOffset(0)]
	public QuicAddrFamilyAndLen FamilyLen;

	public int Family
	{
		get
		{
			if (false)
			{
			}
			return FamilyLen.sin_family;
		}
	}
}
