using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace System.Reactive;

[Serializable]
public abstract class Notification<T> : IEquatable<Notification<T>>
{
	[Serializable]
	[DebuggerDisplay("OnNext({Value})")]
	internal sealed class OnNextNotification : Notification<T>
	{
		public override T Value { get; }

		public override Exception? Exception => null;

		public override NotificationKind Kind => NotificationKind.OnNext;

		public OnNextNotification(T value)
		{
			Value = value;
		}

		public override int GetHashCode()
		{
			T value = Value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		public override bool Equals(Notification<T>? other)
		{
			if ((object)this == other)
			{
				return true;
			}
			if ((object)other == null)
			{
				return false;
			}
			if (other.Kind != NotificationKind.OnNext)
			{
				return false;
			}
			return EqualityComparer<T>.Default.Equals(Value, other.Value);
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "OnNext({0})", Value);
		}
	}

	[Serializable]
	[DebuggerDisplay("OnError({Exception})")]
	internal sealed class OnErrorNotification : Notification<T>
	{
		public override T Value
		{
			get
			{
				Exception.Throw();
				return default(T);
			}
		}

		public override Exception Exception { get; }

		public override NotificationKind Kind => NotificationKind.OnError;

		public OnErrorNotification(Exception exception)
		{
			Exception = exception;
		}

		public override int GetHashCode()
		{
			return Exception.GetHashCode();
		}

		public override bool Equals(Notification<T>? other)
		{
			if ((object)this == other)
			{
				return true;
			}
			if ((object)other == null)
			{
				return false;
			}
			if (other.Kind != NotificationKind.OnError)
			{
				return false;
			}
			return object.Equals(Exception, other.Exception);
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "OnError({0})", Exception.GetType().FullName);
		}
	}

	[Serializable]
	[DebuggerDisplay("OnCompleted()")]
	internal sealed class OnCompletedNotification : Notification<T>
	{
		internal static readonly Notification<T> Instance = new Notification<T>.OnCompletedNotification();

		public override T Value
		{
			get
			{
				throw new InvalidOperationException(Strings_Core.COMPLETED_NO_VALUE);
			}
		}

		public override Exception? Exception => null;

		public override NotificationKind Kind => NotificationKind.OnCompleted;

		private OnCompletedNotification()
		{
		}

		public override int GetHashCode()
		{
			return typeof(T).GetHashCode() ^ 0x213E;
		}

		public override bool Equals(Notification<T>? other)
		{
			if ((object)this == other)
			{
				return true;
			}
			if ((object)other == null)
			{
				return false;
			}
			return other.Kind == NotificationKind.OnCompleted;
		}

		public override string ToString()
		{
			return "OnCompleted()";
		}
	}

	public abstract T Value { get; }

	public abstract Exception? Exception { get; }

	public abstract NotificationKind Kind { get; }

	protected internal Notification()
	{
	}

	public abstract bool Equals(Notification<T>? other);

	public static bool operator ==(Notification<T> left, Notification<T> right)
	{
		if ((object)left == right)
		{
			return true;
		}
		if ((object)left == null || (object)right == null)
		{
			return false;
		}
		return left.Equals(right);
	}

	public static bool operator !=(Notification<T> left, Notification<T> right)
	{
		return !(left == right);
	}

	public override bool Equals(object? obj)
	{
		return Equals(obj as Notification<T>);
	}
}
public static class Notification
{
	public static Notification<T> CreateOnNext<T>(T value)
	{
		return new Notification<T>.OnNextNotification(value);
	}

	public static Notification<T> CreateOnError<T>(Exception error)
	{
		if (error == null)
		{
			throw new ArgumentNullException("error");
		}
		return new Notification<T>.OnErrorNotification(error);
	}

	public static Notification<T> CreateOnCompleted<T>()
	{
		return Notification<T>.OnCompletedNotification.Instance;
	}
}
