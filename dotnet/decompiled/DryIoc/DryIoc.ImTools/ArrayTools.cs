using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DryIoc.ImTools;

public static class ArrayTools
{
	private static class EmptyArray<T>
	{
		public static readonly T[] Value = new T[0];
	}

	public static T[] Empty<T>()
	{
		return EmptyArray<T>.Value;
	}

	public static T[] One<T>(this T one)
	{
		return new T[1] { one };
	}

	public static bool IsNullOrEmpty<T>(this T[] source)
	{
		if (source != null)
		{
			return source.Length == 0;
		}
		return true;
	}

	public static T[] EmptyIfNull<T>(this T[] source)
	{
		return source ?? Empty<T>();
	}

	public static T[] ToArrayOrSelf<T>(this IEnumerable<T> source)
	{
		object obj;
		if (source != null)
		{
			obj = source as T[];
			if (obj == null)
			{
				return source.ToArray();
			}
		}
		else
		{
			obj = Empty<T>();
		}
		return (T[])obj;
	}

	public static IList<T> ToListOrSelf<T>(this IEnumerable<T> source)
	{
		object obj;
		if (source != null)
		{
			obj = source as IList<T>;
			if (obj == null)
			{
				return source.ToList();
			}
		}
		else
		{
			IList<T> list = Empty<T>();
			obj = list;
		}
		return (IList<T>)obj;
	}

	public static T[] Copy<T>(this T[] source)
	{
		if (source == null || source.Length == 0)
		{
			return source;
		}
		int num = source.Length;
		T[] array = new T[num];
		if (num < 6)
		{
			for (int i = 0; i < num; i++)
			{
				array[i] = source[i];
			}
		}
		else
		{
			Array.Copy(source, 0, array, 0, num);
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T[] CopyNonEmpty<T>(this T[] source)
	{
		int num = source.Length;
		T[] array = new T[num];
		Array.Copy(source, 0, array, 0, num);
		return array;
	}

	public static T[] Append<T>(this T[] source, params T[] added)
	{
		if (added == null || added.Length == 0)
		{
			return source;
		}
		if (source == null || source.Length == 0)
		{
			return added;
		}
		int num = source.Length;
		int num2 = added.Length;
		T[] array = new T[num + num2];
		if (num < 6)
		{
			for (int i = 0; i < num; i++)
			{
				array[i] = source[i];
			}
		}
		else
		{
			Array.Copy(source, 0, array, 0, num);
		}
		if (num2 < 6)
		{
			for (int j = 0; j < num2; j++)
			{
				array[num + j] = added[j];
			}
		}
		else
		{
			Array.Copy(added, 0, array, num, num2);
		}
		return array;
	}

	public static T[] Append<T>(this IEnumerable<T> source, IEnumerable<T> other)
	{
		return source.ToArrayOrSelf().Append(other.ToArrayOrSelf());
	}

	public static T[] AppendOrUpdate<T>(this T[] source, T value, int index = -1)
	{
		if (source == null || source.Length == 0)
		{
			return new T[1] { value };
		}
		int num = source.Length;
		index = ((index < 0) ? num : index);
		T[] array = new T[(index < num) ? num : (num + 1)];
		if (num < 6)
		{
			for (int i = 0; i < num; i++)
			{
				array[i] = source[i];
			}
		}
		else
		{
			Array.Copy(source, 0, array, 0, num);
		}
		array[index] = value;
		return array;
	}

	public static T[] UpdateNonEmpty<T>(this T[] source, T value, int index)
	{
		int num = source.Length;
		T[] array = new T[num];
		if (num < 6)
		{
			for (int i = 0; i < num; i++)
			{
				array[i] = source[i];
			}
		}
		else
		{
			Array.Copy(source, 0, array, 0, num);
		}
		array[index] = value;
		return array;
	}

	public static T[] AppendNonEmpty<T>(this T[] source, params T[] added)
	{
		int num = source.Length;
		int num2 = added.Length;
		T[] array = new T[num + num2];
		if (num < 6)
		{
			for (int i = 0; i < num; i++)
			{
				array[i] = source[i];
			}
		}
		else
		{
			Array.Copy(source, 0, array, 0, num);
		}
		if (num2 < 6)
		{
			for (int j = 0; j < num2; j++)
			{
				array[num + j] = added[j];
			}
		}
		else
		{
			Array.Copy(added, 0, array, num, num2);
		}
		return array;
	}

	public static T[] Append<T>(this T[] source, T value)
	{
		if (source == null || source.Length == 0)
		{
			return new T[1] { value };
		}
		int num = source.Length;
		T[] array = new T[num + 1];
		if (num < 6)
		{
			for (int i = 0; i < num; i++)
			{
				array[i] = source[i];
			}
		}
		else
		{
			Array.Copy(source, 0, array, 0, num);
		}
		array[num] = value;
		return array;
	}

	public static T[] AppendToNonEmpty<T>(this T[] source, T value)
	{
		int num = source.Length;
		T[] array = new T[num + 1];
		if (num < 6)
		{
			for (int i = 0; i < num; i++)
			{
				array[i] = source[i];
			}
		}
		else
		{
			Array.Copy(source, 0, array, 0, num);
		}
		array[num] = value;
		return array;
	}

	public static T[] PrependToNonEmpty<T>(this T[] source, T value)
	{
		int num = source.Length;
		T[] array = new T[num + 1];
		if (num < 6)
		{
			for (int i = 0; i < num; i++)
			{
				array[i + 1] = source[i];
			}
		}
		else
		{
			Array.Copy(source, 0, array, 1, num);
		}
		array[0] = value;
		return array;
	}

	public static int IndexOf<T>(this T[] source, Func<T, bool> predicate)
	{
		if (source != null && source.Length != 0)
		{
			for (int i = 0; i < source.Length; i++)
			{
				if (predicate(source[i]))
				{
					return i;
				}
			}
		}
		return -1;
	}

	public static int IndexOf<T, S>(this T[] source, S state, Func<S, T, bool> predicate)
	{
		if (source != null && source.Length != 0)
		{
			for (int i = 0; i < source.Length; i++)
			{
				if (predicate(state, source[i]))
				{
					return i;
				}
			}
		}
		return -1;
	}

	public static int IndexOf<T>(this T[] source, T value)
	{
		if (source != null && source.Length != 0)
		{
			for (int i = 0; i < source.Length; i++)
			{
				T val = source[i];
				if (object.Equals(val, value))
				{
					return i;
				}
			}
		}
		return -1;
	}

	public static int IndexOfReference<T>(this T[] source, T reference) where T : class
	{
		if (source != null && source.Length != 0)
		{
			for (int i = 0; i < source.Length; i++)
			{
				if (source[i] == reference)
				{
					return i;
				}
			}
		}
		return -1;
	}

	public static T[] RemoveAt<T>(this T[] source, int index)
	{
		if (source == null || source.Length == 0 || index < 0 || index >= source.Length)
		{
			return source;
		}
		if (index == 0 && source.Length == 1)
		{
			return new T[0];
		}
		T[] array = new T[source.Length - 1];
		if (index != 0)
		{
			Array.Copy(source, 0, array, 0, index);
		}
		if (index != array.Length)
		{
			Array.Copy(source, index + 1, array, index, array.Length - index);
		}
		return array;
	}

	public static T[] Remove<T>(this T[] source, T value)
	{
		return source.RemoveAt(source.IndexOf(value));
	}

	public static T FindFirst<T>(this T[] source, Func<T, bool> predicate)
	{
		if (source != null && source.Length != 0)
		{
			foreach (T val in source)
			{
				if (predicate(val))
				{
					return val;
				}
			}
		}
		return default(T);
	}

	public static T FindFirst<T, S>(this T[] source, S state, Func<S, T, bool> predicate)
	{
		if (source != null && source.Length != 0)
		{
			foreach (T val in source)
			{
				if (predicate(state, val))
				{
					return val;
				}
			}
		}
		return default(T);
	}

	public static T FindFirst<T>(this IEnumerable<T> source, Func<T, bool> predicate)
	{
		if (!(source is T[] source2))
		{
			return source.FirstOrDefault(predicate);
		}
		return source2.FindFirst(predicate);
	}

	public static T SingleOrDefaultIfMany<T>(this IEnumerable<T> source)
	{
		if (source is IList<T> list)
		{
			if (list.Count != 1)
			{
				return default(T);
			}
			return list[0];
		}
		if (source == null)
		{
			return default(T);
		}
		using IEnumerator<T> enumerator = source.GetEnumerator();
		if (!enumerator.MoveNext())
		{
			return default(T);
		}
		T current = enumerator.Current;
		return (!enumerator.MoveNext()) ? current : default(T);
	}

	public static void ForEach<T>(this T[] source, Action<T> action)
	{
		if (!source.IsNullOrEmpty())
		{
			for (int i = 0; i < source.Length; i++)
			{
				action(source[i]);
			}
		}
	}

	public static T[] Copy<T>(this T[] source, int sourcePos, int count)
	{
		T[] array = new T[count];
		if (count == 1)
		{
			array[0] = source[sourcePos];
		}
		else
		{
			Array.Copy(source, sourcePos, array, 0, count);
		}
		return array;
	}

	private static R[] Copy<T, R>(this T[] source, int sourcePos, int count, Func<T, R> map)
	{
		R[] array = new R[count];
		if (count == 1)
		{
			array[0] = map(source[sourcePos]);
		}
		else
		{
			int num = 0;
			int num2 = sourcePos;
			while (num < count)
			{
				array[num] = map(source[num2]);
				num++;
				num2++;
			}
		}
		return array;
	}

	private static R[] Copy<S, T, R>(this T[] source, S state, int sourcePos, int count, Func<S, T, R> map)
	{
		R[] array = new R[count];
		if (count == 1)
		{
			array[0] = map(state, source[sourcePos]);
		}
		else
		{
			int num = 0;
			int num2 = sourcePos;
			while (num < count)
			{
				array[num] = map(state, source[num2]);
				num++;
				num2++;
			}
		}
		return array;
	}

	private static R[] Copy<A, B, T, R>(this T[] source, A a, B b, int sourcePos, int count, Func<A, B, T, R> map)
	{
		R[] array = new R[count];
		if (count == 1)
		{
			array[0] = map(a, b, source[sourcePos]);
		}
		else
		{
			int num = 0;
			int num2 = sourcePos;
			while (num < count)
			{
				array[num] = map(a, b, source[num2]);
				num++;
				num2++;
			}
		}
		return array;
	}

	public static T[] AppendTo<T>(this T[] source, T[] results, int sourcePos, int count)
	{
		int num = results.Length;
		Array.Resize(ref results, num + count);
		if (count == 1)
		{
			results[num] = source[sourcePos];
		}
		else
		{
			Array.Copy(source, sourcePos, results, num, count);
		}
		return results;
	}

	private static R[] AppendTo<T, R>(this T[] source, R[] results, int sourcePos, int count, Func<T, R> map)
	{
		int num = results.Length;
		Array.Resize(ref results, num + count);
		if (count == 1)
		{
			results[num] = map(source[sourcePos]);
		}
		else
		{
			int num2 = num;
			int num3 = sourcePos;
			while (num2 < results.Length)
			{
				results[num2] = map(source[num3]);
				num2++;
				num3++;
			}
		}
		return results;
	}

	private static R[] AppendTo<S, T, R>(this T[] source, S state, R[] results, int sourcePos, int count, Func<S, T, R> map)
	{
		int num = results.Length;
		Array.Resize(ref results, num + count);
		if (count == 1)
		{
			results[num] = map(state, source[sourcePos]);
		}
		else
		{
			int num2 = num;
			int num3 = sourcePos;
			while (num2 < results.Length)
			{
				results[num2] = map(state, source[num3]);
				num2++;
				num3++;
			}
		}
		return results;
	}

	private static R[] AppendTo<A, B, T, R>(this T[] source, A a, B b, R[] results, int sourcePos, int count, Func<A, B, T, R> map)
	{
		int num = results.Length;
		Array.Resize(ref results, num + count);
		if (count == 1)
		{
			results[num] = map(a, b, source[sourcePos]);
		}
		else
		{
			int num2 = num;
			int num3 = sourcePos;
			while (num2 < results.Length)
			{
				results[num2] = map(a, b, source[num3]);
				num2++;
				num3++;
			}
		}
		return results;
	}

	public static T[] Match<T>(this T[] source, Func<T, bool> condition)
	{
		if (source == null || source.Length == 0)
		{
			return source;
		}
		if (source.Length == 1)
		{
			if (!condition(source[0]))
			{
				return Empty<T>();
			}
			return source;
		}
		if (source.Length == 2)
		{
			bool flag = condition(source[0]);
			bool flag2 = condition(source[1]);
			if (!(flag && flag2))
			{
				if (!flag)
				{
					if (!flag2)
					{
						return Empty<T>();
					}
					return new T[1] { source[1] };
				}
				return new T[1] { source[0] };
			}
			return source;
		}
		if (source.Length == 3)
		{
			bool flag3 = condition(source[0]);
			bool flag4 = condition(source[1]);
			bool flag5 = condition(source[2]);
			if (!(flag3 && flag4 && flag5))
			{
				if (!flag3)
				{
					if (!flag4)
					{
						if (!flag5)
						{
							return Empty<T>();
						}
						return new T[1] { source[2] };
					}
					if (flag5)
					{
						return new T[2]
						{
							source[1],
							source[2]
						};
					}
					return new T[1] { source[1] };
				}
				if (!flag4)
				{
					if (flag5)
					{
						return new T[2]
						{
							source[0],
							source[2]
						};
					}
					return new T[1] { source[0] };
				}
				return new T[2]
				{
					source[0],
					source[1]
				};
			}
			return source;
		}
		int num = 0;
		T[] array = null;
		bool flag6 = false;
		int i;
		for (i = 0; i < source.Length; i++)
		{
			if (!(flag6 = condition(source[i])))
			{
				if (i != 0 && i > num)
				{
					array = ((array == null) ? source.Copy(num, i - num) : source.AppendTo(array, num, i - num));
				}
				num = i + 1;
			}
		}
		if (flag6 && num != 0)
		{
			if (array != null)
			{
				return source.AppendTo(array, num, i - num);
			}
			return source.Copy(num, i - num);
		}
		T[] array2 = array;
		if (array2 == null)
		{
			if (num == 0)
			{
				return source;
			}
			array2 = Empty<T>();
		}
		return array2;
	}

	public static T[] Match<S, T>(this T[] source, S state, Func<S, T, bool> condition)
	{
		if (source == null || source.Length == 0)
		{
			return source;
		}
		if (source.Length == 1)
		{
			if (!condition(state, source[0]))
			{
				return Empty<T>();
			}
			return source;
		}
		if (source.Length == 2)
		{
			bool flag = condition(state, source[0]);
			bool flag2 = condition(state, source[1]);
			if (!(flag && flag2))
			{
				if (!flag)
				{
					if (!flag2)
					{
						return Empty<T>();
					}
					return new T[1] { source[1] };
				}
				return new T[1] { source[0] };
			}
			return source;
		}
		if (source.Length == 3)
		{
			bool flag3 = condition(state, source[0]);
			bool flag4 = condition(state, source[1]);
			bool flag5 = condition(state, source[2]);
			if (!(flag3 && flag4 && flag5))
			{
				if (!flag3)
				{
					if (!flag4)
					{
						if (!flag5)
						{
							return Empty<T>();
						}
						return new T[1] { source[2] };
					}
					if (flag5)
					{
						return new T[2]
						{
							source[1],
							source[2]
						};
					}
					return new T[1] { source[1] };
				}
				if (!flag4)
				{
					if (flag5)
					{
						return new T[2]
						{
							source[0],
							source[2]
						};
					}
					return new T[1] { source[0] };
				}
				return new T[2]
				{
					source[0],
					source[1]
				};
			}
			return source;
		}
		int num = 0;
		T[] array = null;
		bool flag6 = false;
		int i;
		for (i = 0; i < source.Length; i++)
		{
			if (!(flag6 = condition(state, source[i])))
			{
				if (i != 0 && i > num)
				{
					array = ((array == null) ? source.Copy(num, i - num) : source.AppendTo(array, num, i - num));
				}
				num = i + 1;
			}
		}
		if (flag6 && num != 0)
		{
			if (array != null)
			{
				return source.AppendTo(array, num, i - num);
			}
			return source.Copy(num, i - num);
		}
		T[] array2 = array;
		if (array2 == null)
		{
			if (num == 0)
			{
				return source;
			}
			array2 = Empty<T>();
		}
		return array2;
	}

	public static T[] Match<A, B, T>(this T[] source, A a, B b, Func<A, B, T, bool> condition)
	{
		if (source == null || source.Length == 0)
		{
			return source;
		}
		if (source.Length == 1)
		{
			if (!condition(a, b, source[0]))
			{
				return Empty<T>();
			}
			return source;
		}
		if (source.Length == 2)
		{
			bool flag = condition(a, b, source[0]);
			bool flag2 = condition(a, b, source[1]);
			if (!(flag && flag2))
			{
				if (!flag)
				{
					if (!flag2)
					{
						return Empty<T>();
					}
					return new T[1] { source[1] };
				}
				return new T[1] { source[0] };
			}
			return source;
		}
		int num = 0;
		T[] array = null;
		bool flag3 = false;
		int i;
		for (i = 0; i < source.Length; i++)
		{
			if (!(flag3 = condition(a, b, source[i])))
			{
				if (i != 0 && i > num)
				{
					array = ((array == null) ? source.Copy(num, i - num) : source.AppendTo(array, num, i - num));
				}
				num = i + 1;
			}
		}
		if (flag3 && num != 0)
		{
			if (array != null)
			{
				return source.AppendTo(array, num, i - num);
			}
			return source.Copy(num, i - num);
		}
		T[] array2 = array;
		if (array2 == null)
		{
			if (num == 0)
			{
				return source;
			}
			array2 = Empty<T>();
		}
		return array2;
	}

	public static R[] Match<T, R>(this T[] source, Func<T, bool> condition, Func<T, R> map)
	{
		if (source == null)
		{
			return null;
		}
		if (source.Length == 0)
		{
			return Empty<R>();
		}
		if (source.Length == 1)
		{
			T arg = source[0];
			if (!condition(arg))
			{
				return Empty<R>();
			}
			return new R[1] { map(arg) };
		}
		if (source.Length == 2)
		{
			bool flag = condition(source[0]);
			bool flag2 = condition(source[1]);
			if (!(flag && flag2))
			{
				if (!flag)
				{
					if (!flag2)
					{
						return Empty<R>();
					}
					return new R[1] { map(source[1]) };
				}
				return new R[1] { map(source[0]) };
			}
			return new R[2]
			{
				map(source[0]),
				map(source[1])
			};
		}
		if (source.Length == 3)
		{
			bool flag3 = condition(source[0]);
			bool flag4 = condition(source[1]);
			bool flag5 = condition(source[2]);
			if (!(flag3 && flag4 && flag5))
			{
				if (!flag3)
				{
					if (!flag4)
					{
						if (!flag5)
						{
							return Empty<R>();
						}
						return new R[1] { map(source[2]) };
					}
					if (flag5)
					{
						return new R[2]
						{
							map(source[1]),
							map(source[2])
						};
					}
					return new R[1] { map(source[1]) };
				}
				if (!flag4)
				{
					if (flag5)
					{
						return new R[2]
						{
							map(source[0]),
							map(source[2])
						};
					}
					return new R[1] { map(source[0]) };
				}
				return new R[2]
				{
					map(source[0]),
					map(source[1])
				};
			}
			return new R[3]
			{
				map(source[0]),
				map(source[1]),
				map(source[2])
			};
		}
		int num = 0;
		R[] array = null;
		bool flag6 = false;
		int i;
		for (i = 0; i < source.Length; i++)
		{
			if (!(flag6 = condition(source[i])))
			{
				if (i != 0 && i > num)
				{
					array = ((array == null) ? source.Copy(num, i - num, map) : source.AppendTo(array, num, i - num, map));
				}
				num = i + 1;
			}
		}
		if (flag6 && num != 0)
		{
			if (array != null)
			{
				return source.AppendTo(array, num, i - num, map);
			}
			return source.Copy(num, i - num, map);
		}
		R[] array2 = array;
		if (array2 == null)
		{
			if (num != 0)
			{
				return Empty<R>();
			}
			array2 = source.Copy(0, source.Length, map);
		}
		return array2;
	}

	public static R[] Match<S, T, R>(this T[] source, S state, Func<S, T, bool> condition, Func<S, T, R> map)
	{
		if (source == null)
		{
			return null;
		}
		if (source.Length == 0)
		{
			return Empty<R>();
		}
		if (source.Length == 1)
		{
			T arg = source[0];
			if (!condition(state, arg))
			{
				return Empty<R>();
			}
			return new R[1] { map(state, arg) };
		}
		if (source.Length == 2)
		{
			bool flag = condition(state, source[0]);
			bool flag2 = condition(state, source[1]);
			if (!(flag && flag2))
			{
				if (!flag)
				{
					if (!flag2)
					{
						return Empty<R>();
					}
					return new R[1] { map(state, source[1]) };
				}
				return new R[1] { map(state, source[0]) };
			}
			return new R[2]
			{
				map(state, source[0]),
				map(state, source[1])
			};
		}
		if (source.Length == 3)
		{
			bool flag3 = condition(state, source[0]);
			bool flag4 = condition(state, source[1]);
			bool flag5 = condition(state, source[2]);
			if (!(flag3 && flag4 && flag5))
			{
				if (!flag3)
				{
					if (!flag4)
					{
						if (!flag5)
						{
							return Empty<R>();
						}
						return new R[1] { map(state, source[2]) };
					}
					if (flag5)
					{
						return new R[2]
						{
							map(state, source[1]),
							map(state, source[2])
						};
					}
					return new R[1] { map(state, source[1]) };
				}
				if (!flag4)
				{
					if (flag5)
					{
						return new R[2]
						{
							map(state, source[0]),
							map(state, source[2])
						};
					}
					return new R[1] { map(state, source[0]) };
				}
				return new R[2]
				{
					map(state, source[0]),
					map(state, source[1])
				};
			}
			return new R[3]
			{
				map(state, source[0]),
				map(state, source[1]),
				map(state, source[2])
			};
		}
		int num = 0;
		R[] array = null;
		bool flag6 = false;
		int i;
		for (i = 0; i < source.Length; i++)
		{
			if (!(flag6 = condition(state, source[i])))
			{
				if (i != 0 && i > num)
				{
					array = ((array == null) ? source.Copy(state, num, i - num, map) : source.AppendTo(state, array, num, i - num, map));
				}
				num = i + 1;
			}
		}
		if (flag6 && num != 0)
		{
			if (array != null)
			{
				return source.AppendTo(state, array, num, i - num, map);
			}
			return source.Copy(state, num, i - num, map);
		}
		R[] array2 = array;
		if (array2 == null)
		{
			if (num != 0)
			{
				return Empty<R>();
			}
			array2 = source.Copy(state, 0, source.Length, map);
		}
		return array2;
	}

	public static R[] Match<A, B, T, R>(this T[] source, A a, B b, Func<A, B, T, bool> condition, Func<A, B, T, R> map)
	{
		if (source == null)
		{
			return null;
		}
		if (source.Length == 0)
		{
			return Empty<R>();
		}
		if (source.Length == 1)
		{
			T arg = source[0];
			if (!condition(a, b, arg))
			{
				return Empty<R>();
			}
			return new R[1] { map(a, b, arg) };
		}
		if (source.Length == 2)
		{
			bool flag = condition(a, b, source[0]);
			bool flag2 = condition(a, b, source[1]);
			if (!(flag && flag2))
			{
				if (!flag)
				{
					if (!flag2)
					{
						return Empty<R>();
					}
					return new R[1] { map(a, b, source[1]) };
				}
				return new R[1] { map(a, b, source[0]) };
			}
			return new R[2]
			{
				map(a, b, source[0]),
				map(a, b, source[1])
			};
		}
		int num = 0;
		R[] array = null;
		bool flag3 = false;
		int i;
		for (i = 0; i < source.Length; i++)
		{
			if (!(flag3 = condition(a, b, source[i])))
			{
				if (i != 0 && i > num)
				{
					array = ((array == null) ? source.Copy(a, b, num, i - num, map) : source.AppendTo(a, b, array, num, i - num, map));
				}
				num = i + 1;
			}
		}
		if (flag3 && num != 0)
		{
			if (array != null)
			{
				return source.AppendTo(a, b, array, num, i - num, map);
			}
			return source.Copy(a, b, num, i - num, map);
		}
		R[] array2 = array;
		if (array2 == null)
		{
			if (num != 0)
			{
				return Empty<R>();
			}
			array2 = source.Copy(a, b, 0, source.Length, map);
		}
		return array2;
	}

	public static R[] Map<T, R>(this T[] source, Func<T, R> map)
	{
		if (source == null)
		{
			return null;
		}
		int num = source.Length;
		switch (num)
		{
		case 0:
			return Empty<R>();
		case 1:
			return new R[1] { map(source[0]) };
		case 2:
			return new R[2]
			{
				map(source[0]),
				map(source[1])
			};
		default:
		{
			R[] array = new R[num];
			for (int i = 0; i < source.Length; i++)
			{
				array[i] = map(source[i]);
			}
			return array;
		}
		}
	}

	public static R[] Map<T, S, R>(this T[] source, S state, Func<S, T, R> map)
	{
		if (source == null)
		{
			return null;
		}
		int num = source.Length;
		switch (num)
		{
		case 0:
			return Empty<R>();
		case 1:
			return new R[1] { map(state, source[0]) };
		case 2:
			return new R[2]
			{
				map(state, source[0]),
				map(state, source[1])
			};
		default:
		{
			R[] array = new R[num];
			for (int i = 0; i < source.Length; i++)
			{
				array[i] = map(state, source[i]);
			}
			return array;
		}
		}
	}

	public static R[] Map<T, A, B, R>(this T[] source, A a, B b, Func<A, B, T, R> map)
	{
		if (source == null)
		{
			return null;
		}
		int num = source.Length;
		switch (num)
		{
		case 0:
			return Empty<R>();
		case 1:
			return new R[1] { map(a, b, source[0]) };
		case 2:
			return new R[2]
			{
				map(a, b, source[0]),
				map(a, b, source[1])
			};
		default:
		{
			R[] array = new R[num];
			for (int i = 0; i < source.Length; i++)
			{
				array[i] = map(a, b, source[i]);
			}
			return array;
		}
		}
	}

	public static IEnumerable<R> Map<T, R>(this IEnumerable<T> source, Func<T, R> map)
	{
		if (!(source is T[] source2))
		{
			return source?.Select(map);
		}
		return source2.Map(map);
	}

	public static IEnumerable<T> Match<T>(this IEnumerable<T> source, Func<T, bool> condition)
	{
		if (!(source is T[] source2))
		{
			return source?.Where(condition);
		}
		return source2.Match(condition);
	}

	public static IEnumerable<R> Match<T, R>(this IEnumerable<T> source, Func<T, bool> condition, Func<T, R> map)
	{
		if (!(source is T[] source2))
		{
			return source?.Where(condition).Select(map);
		}
		return source2.Match(condition, map);
	}
}
