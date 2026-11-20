using System.Globalization;

namespace System.Text.RegularExpressions;

internal sealed class RegexInterpreterFactory : RegexRunnerFactory
{
	private readonly RegexInterpreterCode _code = RegexWriter.Write(tree);

	private readonly CultureInfo _culture = tree.Culture;

	public RegexInterpreterFactory(RegexTree tree)
	{
	}

	protected internal override RegexRunner CreateInstance()
	{
		return new RegexInterpreter(_code, _culture);
	}
}
