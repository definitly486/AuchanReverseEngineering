using System.Reflection;

namespace System.Diagnostics.Tracing;

[DefaultMember("Item")]
internal struct SessionMask
{
	private uint m_mask;

	public static SessionMask All => new SessionMask(15u);

	public SessionMask(uint mask = 0u)
	{
		m_mask = mask & 0xF;
	}

	public ulong ToEventKeywords()
	{
		return (ulong)m_mask << 44;
	}
}
