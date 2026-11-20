namespace NLog.MessageTemplates;

internal readonly struct LiteralHole
{
	public readonly Literal Literal;

	public readonly Hole Hole;

	public bool MaybePositionalTemplate
	{
		get
		{
			if (Literal.Skip != 0 && Hole.Index != -1)
			{
				return Hole.CaptureType == CaptureType.Normal;
			}
			return false;
		}
	}

	public LiteralHole(in Literal literal, in Hole hole)
	{
		Literal = literal;
		Hole = hole;
	}
}
