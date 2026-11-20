using System.Threading.Tasks;

namespace Auchan.Common.Networking;

public interface IEnvironmentBaseUrlProvider
{
	string BaseUrlForEnvironment(Environment env);

	Task<string> BaseUrlForEnvironmentAsync(Environment env)
	{
		return Task.FromResult(BaseUrlForEnvironment(env));
	}

	protected static string BaseUrlForEnvironment(Environment env, string production, string preprod, string stageFormat)
	{
		switch (env)
		{
		case Environment.Production:
			return production;
		case Environment.Preprod:
			return preprod;
		default:
		{
			int num = (int)(env - 2 + 1);
			return string.Format(stageFormat, num);
		}
		}
	}
}
public interface IEnvironmentBaseUrlProvider<T> : IEnvironmentBaseUrlProvider
{
}
