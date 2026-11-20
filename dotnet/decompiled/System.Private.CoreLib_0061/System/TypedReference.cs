using System.Reflection;
using System.Runtime.CompilerServices;

namespace System;

[CLSCompliant(false)]
public ref struct TypedReference
{
	private readonly RuntimeTypeHandle type;

	private readonly ref byte _value;

	private readonly nint _type;

	internal bool IsNull
	{
		get
		{
			if (Unsafe.IsNullRef(in _value))
			{
				return _type == IntPtr.Zero;
			}
			return false;
		}
	}

	private TypedReference(ref byte target, RuntimeType targetType)
	{
		type = new RuntimeTypeHandle(targetType);
		_value = ref target;
		_type = RuntimeTypeHandle.GetMonoClass(targetType);
	}

	public unsafe static object? ToObject(TypedReference value)
	{
		return InternalToObject(&value);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal unsafe static extern object InternalToObject(void* value);

	public static TypedReference MakeTypedReference(object target, FieldInfo[] flds)
	{
		ArgumentNullException.ThrowIfNull(target, "target");
		ArgumentNullException.ThrowIfNull(flds, "flds");
		if (flds.Length == 0)
		{
			throw new ArgumentException("Arg_ArrayZeroError", "flds");
		}
		ref byte target2 = ref Unsafe.NullRef<byte>();
		RuntimeType runtimeType = (RuntimeType)target.GetType();
		for (int i = 0; i < flds.Length; i++)
		{
			RuntimeFieldInfo runtimeFieldInfo = (flds[i] as RuntimeFieldInfo) ?? throw new ArgumentException("Argument_MustBeRuntimeFieldInfo");
			if (runtimeFieldInfo.IsStatic)
			{
				throw new ArgumentException(SR.Format("Argument_TypedReferenceInvalidField", runtimeFieldInfo.Name));
			}
			if (runtimeType != runtimeFieldInfo.GetDeclaringTypeInternal() && !runtimeType.IsSubclassOf(runtimeFieldInfo.GetDeclaringTypeInternal()))
			{
				throw new MissingMemberException("MissingMemberTypeRef");
			}
			RuntimeType runtimeType2 = (RuntimeType)runtimeFieldInfo.FieldType;
			if (i < flds.Length - 1 && !runtimeType2.IsValueType)
			{
				throw new MissingMemberException("MissingMemberNestErr");
			}
			target2 = ref i != 0 ? ref RuntimeFieldHandle.GetFieldDataReference(ref target2, runtimeFieldInfo) : ref RuntimeFieldHandle.GetFieldDataReference(target, runtimeFieldInfo);
			runtimeType = runtimeType2;
		}
		return new TypedReference(ref target2, runtimeType);
	}

	public override int GetHashCode()
	{
		if (_type == IntPtr.Zero)
		{
			return 0;
		}
		return __reftype(this).GetHashCode();
	}

	public override bool Equals(object? o)
	{
		throw new NotSupportedException("NotSupported_NYI");
	}

	public static Type GetTargetType(TypedReference value)
	{
		return __reftype(value);
	}

	public static RuntimeTypeHandle TargetTypeToken(TypedReference value)
	{
		return __reftype(value).TypeHandle;
	}

	public static void SetTypedReference(TypedReference target, object? value)
	{
		throw new NotSupportedException();
	}
}
