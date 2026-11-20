using System;

namespace EBind;

public delegate T CreateDelegateWithItsGetter<T>(Func<T> selfAccessor) where T : Delegate;
