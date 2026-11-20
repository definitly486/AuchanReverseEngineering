using System.Runtime.CompilerServices;
using System.Threading;

namespace DryIoc.ImTools;

public sealed class St<A>
{
	public A a;

	internal static St<A> Pooled;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Pool()
	{
		Pooled = this;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Reset()
	{
		a = default(A);
		Pooled = this;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public A ResetButGetA()
	{
		A result = a;
		a = default(A);
		Pooled = this;
		return result;
	}
}
public sealed class St<A, B>
{
	public A a;

	public B b;

	internal static St<A, B> Pooled;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public St<A, B> Pool()
	{
		return Pooled = this;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Reset()
	{
		a = default(A);
		b = default(B);
		Pooled = this;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public A ResetButGetA()
	{
		A result = a;
		a = default(A);
		b = default(B);
		Pooled = this;
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public B ResetButGetB()
	{
		B result = b;
		a = default(A);
		b = default(B);
		Pooled = this;
		return result;
	}
}
public static class St
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static St<A> Of<A>(A a)
	{
		return new St<A>
		{
			a = a
		};
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static St<A> Rent<A>(A a)
	{
		St<A> st = Interlocked.Exchange(ref St<A>.Pooled, null) ?? new St<A>();
		st.a = a;
		return st;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static St<A, B> Of<A, B>(A a, B b)
	{
		return new St<A, B>
		{
			a = a,
			b = b
		};
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static St<A, B> Rent<A, B>(A a, B b)
	{
		St<A, B> st = Interlocked.Exchange(ref St<A, B>.Pooled, null) ?? new St<A, B>();
		st.a = a;
		st.b = b;
		return st;
	}
}
