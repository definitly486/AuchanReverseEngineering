using System;

namespace CSharpFunctionalExtensions;

public abstract class Entity<TId> : IComparable, IComparable<Entity<TId>> where TId : IComparable<TId>
{
	public virtual TId Id { get; protected set; }

	protected Entity()
	{
	}

	protected Entity(TId id)
	{
		Id = id;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Entity<TId> entity))
		{
			return false;
		}
		if ((object)this == entity)
		{
			return true;
		}
		if (ValueObject.GetUnproxiedType(this) != ValueObject.GetUnproxiedType(entity))
		{
			return false;
		}
		if (IsTransient() || entity.IsTransient())
		{
			return false;
		}
		return Id.Equals(entity.Id);
	}

	private bool IsTransient()
	{
		if (Id != null)
		{
			return Id.Equals(default(TId));
		}
		return true;
	}

	public static bool operator ==(Entity<TId> a, Entity<TId> b)
	{
		if ((object)a == null && (object)b == null)
		{
			return true;
		}
		if ((object)a == null || (object)b == null)
		{
			return false;
		}
		return a.Equals(b);
	}

	public static bool operator !=(Entity<TId> a, Entity<TId> b)
	{
		return !(a == b);
	}

	public override int GetHashCode()
	{
		return (ValueObject.GetUnproxiedType(this).ToString() + Id).GetHashCode();
	}

	public virtual int CompareTo(Entity<TId> other)
	{
		if ((object)other == null)
		{
			return 1;
		}
		if ((object)this == other)
		{
			return 0;
		}
		return Id.CompareTo(other.Id);
	}

	public virtual int CompareTo(object other)
	{
		return CompareTo(other as Entity<TId>);
	}
}
public abstract class Entity : Entity<long>
{
	protected Entity()
	{
	}

	protected Entity(long id)
		: base(id)
	{
	}
}
