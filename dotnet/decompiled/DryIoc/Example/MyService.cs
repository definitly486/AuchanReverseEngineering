namespace Example;

public class MyService : IService
{
	public MyService(IDependencyA a, DependencyB<string> b, RuntimeDependencyC c)
	{
	}
}
