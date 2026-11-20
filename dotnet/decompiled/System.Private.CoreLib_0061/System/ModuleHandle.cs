using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace System;

public struct ModuleHandle : IEquatable<ModuleHandle>
{
	private readonly nint value;

	public static readonly ModuleHandle EmptyHandle = new ModuleHandle(IntPtr.Zero);

	internal nint Value => value;

	public int MDStreamVersion
	{
		get
		{
			if (value == IntPtr.Zero)
			{
				throw new ArgumentNullException(string.Empty, "Arg_InvalidHandle");
			}
			return RuntimeModule.GetMDStreamVersion(value);
		}
	}

	internal ModuleHandle(nint v)
	{
		value = v;
	}

	[RequiresUnreferencedCode("Trimming changes metadata tokens")]
	public RuntimeFieldHandle ResolveFieldHandle(int fieldToken)
	{
		return ResolveFieldHandle(fieldToken, null, null);
	}

	[RequiresUnreferencedCode("Trimming changes metadata tokens")]
	public RuntimeMethodHandle ResolveMethodHandle(int methodToken)
	{
		return ResolveMethodHandle(methodToken, null, null);
	}

	[RequiresUnreferencedCode("Trimming changes metadata tokens")]
	public RuntimeTypeHandle ResolveTypeHandle(int typeToken)
	{
		return ResolveTypeHandle(typeToken, null, null);
	}

	private static nint[] ptrs_from_handles(RuntimeTypeHandle[] handles)
	{
		if (handles == null)
		{
			return null;
		}
		nint[] array = new nint[handles.Length];
		for (int i = 0; i < handles.Length; i++)
		{
			array[i] = handles[i].Value;
		}
		return array;
	}

	[RequiresUnreferencedCode("Trimming changes metadata tokens")]
	public RuntimeTypeHandle ResolveTypeHandle(int typeToken, RuntimeTypeHandle[]? typeInstantiationContext, RuntimeTypeHandle[]? methodInstantiationContext)
	{
		if (value == IntPtr.Zero)
		{
			throw new ArgumentNullException(string.Empty, "Arg_InvalidHandle");
		}
		ResolveTokenError error;
		nint num = RuntimeModule.ResolveTypeToken(value, typeToken, ptrs_from_handles(typeInstantiationContext), ptrs_from_handles(methodInstantiationContext), out error);
		if (num == IntPtr.Zero)
		{
			throw new TypeLoadException(SR.Format("ClassLoad_General_Hex", typeToken, ((IntPtr)value).ToInt64()));
		}
		return new RuntimeTypeHandle(num);
	}

	[RequiresUnreferencedCode("Trimming changes metadata tokens")]
	public RuntimeMethodHandle ResolveMethodHandle(int methodToken, RuntimeTypeHandle[]? typeInstantiationContext, RuntimeTypeHandle[]? methodInstantiationContext)
	{
		if (value == IntPtr.Zero)
		{
			throw new ArgumentNullException(string.Empty, "Arg_InvalidHandle");
		}
		ResolveTokenError error;
		nint num = RuntimeModule.ResolveMethodToken(value, methodToken, ptrs_from_handles(typeInstantiationContext), ptrs_from_handles(methodInstantiationContext), out error);
		if (num == IntPtr.Zero)
		{
			throw new Exception(SR.Format("ClassLoad_General_Hex", methodToken, ((IntPtr)value).ToInt64()));
		}
		return new RuntimeMethodHandle(num);
	}

	[RequiresUnreferencedCode("Trimming changes metadata tokens")]
	public RuntimeFieldHandle ResolveFieldHandle(int fieldToken, RuntimeTypeHandle[]? typeInstantiationContext, RuntimeTypeHandle[]? methodInstantiationContext)
	{
		if (value == IntPtr.Zero)
		{
			throw new ArgumentNullException(string.Empty, "Arg_InvalidHandle");
		}
		ResolveTokenError error;
		nint num = RuntimeModule.ResolveFieldToken(value, fieldToken, ptrs_from_handles(typeInstantiationContext), ptrs_from_handles(methodInstantiationContext), out error);
		if (num == IntPtr.Zero)
		{
			throw new Exception(SR.Format("ClassLoad_General_Hex", fieldToken, ((IntPtr)value).ToInt64()));
		}
		return new RuntimeFieldHandle(num);
	}

	[RequiresUnreferencedCode("Trimming changes metadata tokens")]
	public RuntimeFieldHandle GetRuntimeFieldHandleFromMetadataToken(int fieldToken)
	{
		return ResolveFieldHandle(fieldToken);
	}

	[RequiresUnreferencedCode("Trimming changes metadata tokens")]
	public RuntimeMethodHandle GetRuntimeMethodHandleFromMetadataToken(int methodToken)
	{
		return ResolveMethodHandle(methodToken);
	}

	[RequiresUnreferencedCode("Trimming changes metadata tokens")]
	public RuntimeTypeHandle GetRuntimeTypeHandleFromMetadataToken(int typeToken)
	{
		return ResolveTypeHandle(typeToken);
	}

	public override bool Equals([NotNullWhen(true)] object? obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		return value == ((ModuleHandle)obj).Value;
	}

	public bool Equals(ModuleHandle handle)
	{
		return value == handle.Value;
	}

	public override int GetHashCode()
	{
		return ((IntPtr)value).GetHashCode();
	}

	public static bool operator ==(ModuleHandle left, ModuleHandle right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(ModuleHandle left, ModuleHandle right)
	{
		return !object.Equals(left, right);
	}
}
