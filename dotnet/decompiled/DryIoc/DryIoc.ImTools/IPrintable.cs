using System;
using System.Text;

namespace DryIoc.ImTools;

public interface IPrintable
{
	StringBuilder Print(StringBuilder s, Func<StringBuilder, object, StringBuilder> printer);
}
