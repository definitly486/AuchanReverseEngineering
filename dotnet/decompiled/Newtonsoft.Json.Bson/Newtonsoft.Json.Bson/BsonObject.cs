using System.Collections;
using System.Collections.Generic;

namespace Newtonsoft.Json.Bson;

internal class BsonObject : Newtonsoft.Json.Bson.BsonToken, IEnumerable<Newtonsoft.Json.Bson.BsonProperty>, IEnumerable
{
	private readonly List<Newtonsoft.Json.Bson.BsonProperty> _children = new List<Newtonsoft.Json.Bson.BsonProperty>();

	public override Newtonsoft.Json.Bson.BsonType Type => Newtonsoft.Json.Bson.BsonType.Object;

	public void Add(string name, Newtonsoft.Json.Bson.BsonToken token)
	{
		_children.Add(new Newtonsoft.Json.Bson.BsonProperty
		{
			Name = new Newtonsoft.Json.Bson.BsonString(name, includeLength: false),
			Value = token
		});
		token.Parent = this;
	}

	public IEnumerator<Newtonsoft.Json.Bson.BsonProperty> GetEnumerator()
	{
		return _children.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
