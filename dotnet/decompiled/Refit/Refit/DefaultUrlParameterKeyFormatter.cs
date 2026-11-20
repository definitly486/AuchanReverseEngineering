namespace Refit;

public class DefaultUrlParameterKeyFormatter : IUrlParameterKeyFormatter
{
	public virtual string Format(string key)
	{
		return key;
	}
}
