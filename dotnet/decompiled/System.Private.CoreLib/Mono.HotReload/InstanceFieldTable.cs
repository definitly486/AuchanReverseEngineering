using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Mono.HotReload;

internal sealed class InstanceFieldTable
{
	private sealed class InstanceFields
	{
		private readonly Dictionary<uint, FieldStore> _fields;

		private readonly object _lock;

		public InstanceFields()
		{
			_fields = new Dictionary<uint, FieldStore>();
			_lock = new object();
		}

		[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Hot reload required untrimmed apps")]
		public FieldStore LookupOrAdd(RuntimeTypeHandle type, uint key)
		{
			if (_fields.TryGetValue(key, out var value))
			{
				return value;
			}
			lock (_lock)
			{
				if (_fields.TryGetValue(key, out var value2))
				{
					return value2;
				}
				FieldStore fieldStore = FieldStore.Create(type);
				_fields.Add(key, fieldStore);
				return fieldStore;
			}
		}
	}

	private static readonly InstanceFieldTable _singleton = new InstanceFieldTable();

	private readonly ConditionalWeakTable<object, InstanceFields> _table;

	internal static FieldStore GetInstanceFieldFieldStore(object inst, nint type, uint fielddef_token)
	{
		return _singleton.GetOrCreateInstanceFields(inst).LookupOrAdd(new RuntimeTypeHandle(type), fielddef_token);
	}

	private InstanceFieldTable()
	{
		_table = new ConditionalWeakTable<object, InstanceFields>();
	}

	private InstanceFields GetOrCreateInstanceFields(object key)
	{
		return _table.GetOrCreateValue(key);
	}
}
