using System.Buffers;

namespace System.Net.Security;

internal struct ProtocolToken
{
	internal SecurityStatusPal Status;

	internal byte[] Payload;

	internal int Size;

	internal bool RentBuffer;

	internal bool Failed
	{
		get
		{
			if (Status.ErrorCode != SecurityStatusPalErrorCode.OK)
			{
				return Status.ErrorCode != SecurityStatusPalErrorCode.ContinueNeeded;
			}
			return false;
		}
	}

	internal bool Done => Status.ErrorCode == SecurityStatusPalErrorCode.OK;

	internal void SetPayload(ReadOnlySpan<byte> payload)
	{
		Size = payload.Length;
		if (Size > 0)
		{
			Payload = (RentBuffer ? ArrayPool<byte>.Shared.Rent(Size) : new byte[Size]);
			payload.CopyTo(new Span<byte>(Payload, 0, Size));
		}
	}

	internal ReadOnlyMemory<byte> AsMemory()
	{
		return new ReadOnlyMemory<byte>(Payload, 0, Size);
	}

	internal void ReleasePayload()
	{
		byte[] payload = Payload;
		Payload = null;
		Size = 0;
		if (RentBuffer && payload != null)
		{
			ArrayPool<byte>.Shared.Return(payload);
		}
	}

	internal Exception GetException()
	{
		if (!Done)
		{
			return SslStreamPal.GetException(Status);
		}
		return null;
	}
}
