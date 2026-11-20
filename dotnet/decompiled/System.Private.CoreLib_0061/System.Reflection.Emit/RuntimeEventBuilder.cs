using System.Runtime.InteropServices;

namespace System.Reflection.Emit;

[StructLayout(LayoutKind.Sequential)]
internal sealed class RuntimeEventBuilder : EventBuilder
{
	internal string name;

	private Type type;

	private RuntimeTypeBuilder typeb;

	private CustomAttributeBuilder[] cattrs;

	internal MethodBuilder add_method;

	internal MethodBuilder remove_method;

	internal MethodBuilder raise_method;

	internal MethodBuilder[] other_methods;

	internal EventAttributes attrs;

	private int table_idx;

	internal RuntimeEventBuilder(RuntimeTypeBuilder tb, string eventName, EventAttributes eventAttrs, Type eventType)
	{
		name = eventName;
		attrs = eventAttrs;
		type = eventType;
		typeb = tb;
		table_idx = get_next_table_index(20, 1);
	}

	internal int get_next_table_index(int table, int count)
	{
		return typeb.get_next_table_index(table, count);
	}

	protected override void AddOtherMethodCore(MethodBuilder mdBuilder)
	{
		ArgumentNullException.ThrowIfNull(mdBuilder, "mdBuilder");
		RejectIfCreated();
		if (other_methods != null)
		{
			MethodBuilder[] array = new MethodBuilder[other_methods.Length + 1];
			other_methods.CopyTo(array, 0);
			other_methods = array;
		}
		else
		{
			other_methods = new MethodBuilder[1];
		}
		other_methods[other_methods.Length - 1] = mdBuilder;
	}

	protected override void SetAddOnMethodCore(MethodBuilder mdBuilder)
	{
		ArgumentNullException.ThrowIfNull(mdBuilder, "mdBuilder");
		RejectIfCreated();
		add_method = mdBuilder;
	}

	protected override void SetRaiseMethodCore(MethodBuilder mdBuilder)
	{
		ArgumentNullException.ThrowIfNull(mdBuilder, "mdBuilder");
		RejectIfCreated();
		raise_method = mdBuilder;
	}

	protected override void SetRemoveOnMethodCore(MethodBuilder mdBuilder)
	{
		ArgumentNullException.ThrowIfNull(mdBuilder, "mdBuilder");
		RejectIfCreated();
		remove_method = mdBuilder;
	}

	protected override void SetCustomAttributeCore(ConstructorInfo con, ReadOnlySpan<byte> binaryAttribute)
	{
		RejectIfCreated();
		if (con.ReflectedType.FullName == "System.Runtime.CompilerServices.SpecialNameAttribute")
		{
			attrs |= EventAttributes.SpecialName;
			return;
		}
		CustomAttributeBuilder customAttributeBuilder = new CustomAttributeBuilder(con, binaryAttribute);
		if (cattrs != null)
		{
			CustomAttributeBuilder[] array = new CustomAttributeBuilder[cattrs.Length + 1];
			cattrs.CopyTo(array, 0);
			array[cattrs.Length] = customAttributeBuilder;
			cattrs = array;
		}
		else
		{
			cattrs = new CustomAttributeBuilder[1];
			cattrs[0] = customAttributeBuilder;
		}
	}

	private void RejectIfCreated()
	{
		if (typeb.is_created)
		{
			throw new InvalidOperationException("InvalidOperation_MethodBaked");
		}
	}
}
