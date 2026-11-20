namespace DryIoc;

public delegate object FactoryDelegate(IResolverContext r);
public delegate TService FactoryDelegate<TService>(IResolverContext r);
