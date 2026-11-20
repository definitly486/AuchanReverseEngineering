using System.ComponentModel.Design.Serialization;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace System.Collections.Specialized;

[Serializable]
[DefaultMember("Item")]
[TypeForwardedFrom("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
[DesignerSerializer("System.Diagnostics.Design.StringDictionaryCodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
public class StringDictionary : IEnumerable
{
	private readonly Hashtable contents = new Hashtable();

	public virtual ICollection Keys => contents.Keys;

	public virtual IEnumerator GetEnumerator()
	{
		return contents.GetEnumerator();
	}
}
