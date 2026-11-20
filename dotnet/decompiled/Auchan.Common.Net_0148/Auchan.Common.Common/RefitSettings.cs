using Refit;

namespace Auchan.Common.Common;

public sealed class RefitSettings<Tag> : RefitSettings
{
	public RefitSettings()
	{
	}

	public RefitSettings(IHttpContentSerializer contentSerializer, IUrlParameterFormatter? urlParameterFormatter = null, IFormUrlEncodedParameterFormatter? formUrlEncodedParameterFormatter = null)
		: base(contentSerializer, urlParameterFormatter, formUrlEncodedParameterFormatter)
	{
	}
}
