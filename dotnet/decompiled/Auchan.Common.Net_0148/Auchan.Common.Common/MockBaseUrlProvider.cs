using Auchan.Common.Networking;

namespace Auchan.Common.Common;

public class MockBaseUrlProvider : IEnvironmentBaseUrlProvider
{
	public string BaseUrlForEnvironment(Environment env)
	{
		return "https://3e6dddaa-6cc5-4d3a-940a-0d4c51c4cd59.mock.pstmn.io/577166438";
	}
}
