namespace System.Collections.Generic;

public interface IAlternateEqualityComparer<in TAlternate, T>
{
	bool Equals(TAlternate alternate, T other);

	int GetHashCode(TAlternate alternate);

	T Create(TAlternate alternate);
}
