using System.Text;

namespace System;

internal interface IModifierSpec
{
	Type Resolve(Type type);

	StringBuilder Append(StringBuilder sb);
}
