using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions;

[Serializable]
public readonly struct Maybe<T> : IEquatable<Maybe<T>>, IEquatable<object>, IMaybe<T>
{
	private static class Configuration
	{
		public static string NoValueException = "Maybe has no value.";
	}

	private readonly bool _isValueSet;

	private readonly T? _value;

	public T Value => GetValueOrThrow();

	public static Maybe<T> None => default(Maybe<T>);

	[MemberNotNullWhen(true, "_value")]
	public bool HasValue
	{
		[MemberNotNullWhen(true, "_value")]
		get
		{
			return _isValueSet;
		}
	}

	[MemberNotNullWhen(false, "_value")]
	public bool HasNoValue
	{
		[MemberNotNullWhen(false, "_value")]
		get
		{
			return !HasValue;
		}
	}

	public T GetValueOrThrow(string? errorMessage = null)
	{
		if (HasNoValue)
		{
			throw new InvalidOperationException(errorMessage ?? Configuration.NoValueException);
		}
		return _value;
	}

	public T GetValueOrThrow(Exception exception)
	{
		if (HasNoValue)
		{
			throw exception;
		}
		return _value;
	}

	public T GetValueOrDefault(T defaultValue)
	{
		if (HasNoValue)
		{
			return defaultValue;
		}
		return _value;
	}

	public T? GetValueOrDefault()
	{
		if (HasNoValue)
		{
			return default(T);
		}
		return _value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool TryGetValue([NotNullWhen(true)][MaybeNullWhen(false)] out T? value)
	{
		value = _value;
		return _isValueSet;
	}

	private Maybe(T? value)
	{
		if (value == null)
		{
			_isValueSet = false;
			_value = default(T);
		}
		else
		{
			_isValueSet = true;
			_value = value;
		}
	}

	public static implicit operator Maybe<T>(T? value)
	{
		if (value is Maybe<T>)
		{
			object obj = value;
			return (Maybe<T>)((obj is Maybe<T>) ? obj : null);
		}
		return Maybe.From(value);
	}

	public static implicit operator Maybe<T>(Maybe _)
	{
		return None;
	}

	public static Maybe<T> From(T? value)
	{
		return new Maybe<T>(value);
	}

	public static Maybe<T> From(Func<T?> func)
	{
		return new Maybe<T>(func());
	}

	public static async Task<Maybe<T>> From(Task<T?> valueTask)
	{
		return new Maybe<T>(await valueTask);
	}

	public static async Task<Maybe<T>> From(Func<Task<T?>> valueTaskFunc)
	{
		return new Maybe<T>(await valueTaskFunc());
	}

	public static bool operator ==(Maybe<T> maybe, T? value)
	{
		if (value is Maybe<T>)
		{
			object obj = value;
			Maybe<T> other = (Maybe<T>)((obj is Maybe<T>) ? obj : null);
			return maybe.Equals(other);
		}
		if (maybe.HasNoValue)
		{
			return value == null;
		}
		return maybe._value.Equals(value);
	}

	public static bool operator !=(Maybe<T> maybe, T value)
	{
		return !(maybe == value);
	}

	public static bool operator ==(Maybe<T> maybe, object other)
	{
		return maybe.Equals(other);
	}

	public static bool operator !=(Maybe<T> maybe, object other)
	{
		return !(maybe == other);
	}

	public static bool operator ==(Maybe<T> first, Maybe<T> second)
	{
		return first.Equals(second);
	}

	public static bool operator !=(Maybe<T> first, Maybe<T> second)
	{
		return !(first == second);
	}

	public override bool Equals(object? obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is Maybe<T> other)
		{
			return Equals(other);
		}
		if (obj is T val)
		{
			return Equals(val);
		}
		return false;
	}

	public bool Equals(Maybe<T> other)
	{
		if (HasNoValue && other.HasNoValue)
		{
			return true;
		}
		if (HasNoValue || other.HasNoValue)
		{
			return false;
		}
		return EqualityComparer<T>.Default.Equals(_value, other._value);
	}

	public override int GetHashCode()
	{
		if (HasNoValue)
		{
			return 0;
		}
		return _value.GetHashCode();
	}

	public override string ToString()
	{
		if (HasNoValue)
		{
			return "No value";
		}
		return _value.ToString() ?? _value.GetType().Name;
	}
}
[StructLayout(LayoutKind.Sequential, Size = 1)]
public readonly struct Maybe
{
	public static Maybe None => default(Maybe);

	public static Maybe<T> From<T>(T? value)
	{
		return Maybe<T>.From(value);
	}

	public static Maybe<T> From<T>(Func<T?> func)
	{
		return Maybe<T>.From(func);
	}

	public static Task<Maybe<T>> From<T>(Task<T?> valueTask)
	{
		return Maybe<T>.From(valueTask);
	}

	public static Task<Maybe<T>> From<T>(Func<Task<T?>> valueTaskFunc)
	{
		return Maybe<T>.From(valueTaskFunc);
	}
}
