namespace System.Reflection.Emit;

public class DynamicILInfo
{
	private DynamicMethod method;

	public DynamicMethod DynamicMethod => method;

	internal DynamicILInfo(DynamicMethod method)
	{
		this.method = method;
	}

	public int GetTokenFor(byte[] signature)
	{
		throw new NotImplementedException();
	}

	public int GetTokenFor(DynamicMethod method)
	{
		return this.method.GetRuntimeILGenerator().TokenGenerator.GetToken(method, create_open_instance: false);
	}

	public int GetTokenFor(RuntimeFieldHandle field)
	{
		return method.GetRuntimeILGenerator().TokenGenerator.GetToken(FieldInfo.GetFieldFromHandle(field), create_open_instance: false);
	}

	public int GetTokenFor(RuntimeMethodHandle method)
	{
		MethodBase methodFromHandle = MethodBase.GetMethodFromHandle(method);
		return this.method.GetRuntimeILGenerator().TokenGenerator.GetToken(methodFromHandle, create_open_instance: false);
	}

	public int GetTokenFor(RuntimeTypeHandle type)
	{
		Type typeFromHandle = Type.GetTypeFromHandle(type);
		return method.GetRuntimeILGenerator().TokenGenerator.GetToken(typeFromHandle, create_open_instance: false);
	}

	public int GetTokenFor(string literal)
	{
		return method.GetRuntimeILGenerator().TokenGenerator.GetToken(literal);
	}

	public int GetTokenFor(RuntimeMethodHandle method, RuntimeTypeHandle contextType)
	{
		throw new NotImplementedException();
	}

	public int GetTokenFor(RuntimeFieldHandle field, RuntimeTypeHandle contextType)
	{
		throw new NotImplementedException();
	}

	public void SetCode(byte[]? code, int maxStackSize)
	{
		method.GetRuntimeILGenerator().SetCode(code, maxStackSize);
	}

	[CLSCompliant(false)]
	public unsafe void SetCode(byte* code, int codeSize, int maxStackSize)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(codeSize, "codeSize");
		if (codeSize > 0)
		{
			ArgumentNullException.ThrowIfNull(code, "code");
		}
		method.GetRuntimeILGenerator().SetCode(code, codeSize, maxStackSize);
	}

	public void SetExceptions(byte[]? exceptions)
	{
		throw new NotImplementedException();
	}

	[CLSCompliant(false)]
	public unsafe void SetExceptions(byte* exceptions, int exceptionsSize)
	{
		throw new NotImplementedException();
	}

	public void SetLocalSignature(byte[]? localSignature)
	{
		throw new NotImplementedException();
	}

	[CLSCompliant(false)]
	public unsafe void SetLocalSignature(byte* localSignature, int signatureSize)
	{
		byte[] array = new byte[signatureSize];
		for (int i = 0; i < signatureSize; i++)
		{
			array[i] = localSignature[i];
		}
	}
}
