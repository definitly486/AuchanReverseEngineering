using System.Collections;
using System.Collections.Generic;

namespace Newtonsoft.Json.Bson;

internal class BsonArray : Newtonsoft.Json.Bson.BsonToken, IEnumerable<Newtonsoft.Json.Bson.BsonToken>, IEnumerable
{
	private readonly List<Newtonsoft.Json.Bson.BsonToken> _children = new List<Newtonsoft.Json.Bson.BsonToken>();

	public override Newtonsoft.Json.Bson.BsonType Type => Newtonsoft.Json.Bson.BsonType.Array;

	public void Add(Newtonsoft.Json.Bson.BsonToken token)
	{
		_children.Add(token);
		token.Parent = this;
	}

	public IEnumerator<Newtonsoft.Json.Bson.BsonToken> GetEnumerator()
	{
		return _children.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
