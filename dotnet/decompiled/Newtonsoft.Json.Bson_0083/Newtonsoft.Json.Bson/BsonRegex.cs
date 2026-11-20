using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Bson;

internal class BsonRegex : Newtonsoft.Json.Bson.BsonToken
{
	public Newtonsoft.Json.Bson.BsonString Pattern
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public Newtonsoft.Json.Bson.BsonString Options
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public override Newtonsoft.Json.Bson.BsonType Type => Newtonsoft.Json.Bson.BsonType.Regex;
}
