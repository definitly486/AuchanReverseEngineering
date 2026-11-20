using System.Collections.Generic;
using System.Linq;

namespace System.Collections.Specialized;

internal class NameValueCollection : Dictionary<string, string>
{
	public string[] AllKeys => base.Keys.ToArray();
}
