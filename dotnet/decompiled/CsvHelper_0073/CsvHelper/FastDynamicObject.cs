using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CsvHelper;

internal class FastDynamicObject : IDynamicMetaObjectProvider, IDictionary<string, object?>, ICollection<KeyValuePair<string, object?>>, IEnumerable<KeyValuePair<string, object?>>, IEnumerable
{
	private class FastDynamicMetaObject : DynamicMetaObject
	{
		private static readonly MethodInfo getValueMethod = typeof(IDictionary<string, object>).GetProperty("Item").GetGetMethod();

		private static readonly MethodInfo setValueMethod = typeof(FastDynamicObject).GetMethod("SetValue", BindingFlags.Instance | BindingFlags.NonPublic);

		public FastDynamicMetaObject(Expression expression, BindingRestrictions restrictions)
			: base(expression, restrictions)
		{
		}

		public FastDynamicMetaObject(Expression expression, BindingRestrictions restrictions, object value)
			: base(expression, restrictions, value)
		{
		}

		public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
		{
			Expression[] parameters = new Expression[1] { System.Linq.Expressions.Expression.Constant(binder.Name) };
			return CallMethod(getValueMethod, parameters);
		}

		public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
		{
			Expression[] parameters = new Expression[2]
			{
				System.Linq.Expressions.Expression.Constant(binder.Name),
				System.Linq.Expressions.Expression.Convert(value.Expression, typeof(object))
			};
			return CallMethod(setValueMethod, parameters);
		}

		public override DynamicMetaObject BindInvokeMember(InvokeMemberBinder binder, DynamicMetaObject[] args)
		{
			Expression[] parameters = new Expression[1] { System.Linq.Expressions.Expression.Constant(binder.Name) };
			return CallMethod(getValueMethod, parameters);
		}

		public override IEnumerable<string> GetDynamicMemberNames()
		{
			if (base.HasValue && base.Value is IDictionary<string, object> dictionary)
			{
				return dictionary.Keys;
			}
			return Array.Empty<string>();
		}

		private DynamicMetaObject CallMethod(MethodInfo method, Expression[] parameters)
		{
			return new DynamicMetaObject(System.Linq.Expressions.Expression.Call(System.Linq.Expressions.Expression.Convert(base.Expression, base.LimitType), method, parameters), BindingRestrictions.GetTypeRestriction(base.Expression, base.LimitType));
		}
	}

	private readonly Dictionary<string, object?> dict;

	object? IDictionary<string, object>.this[string key]
	{
		get
		{
			if (!dict.ContainsKey(key))
			{
				throw new CsvHelperException("FastDynamicObject does not contain a definition for '" + key + "'.");
			}
			return dict[key];
		}
		set
		{
			SetValue(key, value);
		}
	}

	ICollection<string> IDictionary<string, object>.Keys => dict.Keys;

	ICollection<object?> IDictionary<string, object>.Values => dict.Values;

	int ICollection<KeyValuePair<string, object>>.Count => dict.Count;

	bool ICollection<KeyValuePair<string, object>>.IsReadOnly => false;

	public FastDynamicObject()
	{
		dict = new Dictionary<string, object>();
	}

	private object? SetValue(string key, object? value)
	{
		dict[key] = value;
		return value;
	}

	DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
	{
		return new FastDynamicMetaObject(parameter, BindingRestrictions.Empty, this);
	}

	void IDictionary<string, object>.Add(string key, object? value)
	{
		SetValue(key, value);
	}

	void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object?> item)
	{
		SetValue(item.Key, item.Value);
	}

	void ICollection<KeyValuePair<string, object>>.Clear()
	{
		dict.Clear();
	}

	bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object?> item)
	{
		return dict.Contains(item);
	}

	bool IDictionary<string, object>.ContainsKey(string key)
	{
		return dict.ContainsKey(key);
	}

	void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object?>[] array, int arrayIndex)
	{
		if (arrayIndex < 0 || arrayIndex >= array.Length)
		{
			throw new ArgumentOutOfRangeException("arrayIndex must be greater than or equal to 0 and less then array length.");
		}
		if (dict.Count + arrayIndex > array.Length)
		{
			throw new ArgumentException("The number of elements in FastDynamicMetaObject is greater than the available space from arrayIndex to the end of the destination array.");
		}
		int num = arrayIndex;
		foreach (KeyValuePair<string, object> item in dict)
		{
			array[num] = item;
			num++;
		}
	}

	IEnumerator<KeyValuePair<string, object?>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
	{
		return dict.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return dict.GetEnumerator();
	}

	bool IDictionary<string, object>.Remove(string key)
	{
		return dict.Remove(key);
	}

	bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object?> item)
	{
		return dict.Remove(item.Key);
	}

	bool IDictionary<string, object>.TryGetValue(string key, out object? value)
	{
		return dict.TryGetValue(key, out value);
	}
}
