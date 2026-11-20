using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection.Emit;

namespace Mono.CodeGeneration;

[RequiresUnreferencedCode("Mono.Android.Export uses dynamic features.")]
internal class CodeLiteral : CodeExpression
{
	private object value;

	private Type type;

	public CodeLiteral(object value)
	{
		this.value = value;
		if (value != null)
		{
			type = value.GetType();
		}
		else
		{
			type = typeof(object);
		}
	}

	public CodeLiteral(object value, Type type)
	{
		this.value = value;
		this.type = type;
	}

	public override void Generate(ILGenerator gen)
	{
		object obj = value;
		if (obj == null)
		{
			gen.Emit(OpCodes.Ldnull);
			return;
		}
		if (obj is Enum)
		{
			obj = Convert.ChangeType(obj, obj.GetType().UnderlyingSystemType, CultureInfo.InvariantCulture);
		}
		if (obj is Type)
		{
			gen.Emit(OpCodes.Ldtoken, (Type)obj);
			gen.Emit(OpCodes.Call, typeof(Type).GetMethod("GetTypeFromHandle"));
			return;
		}
		switch (Type.GetTypeCode(type))
		{
		case TypeCode.String:
			gen.Emit(OpCodes.Ldstr, (string)obj);
			break;
		case TypeCode.SByte:
		case TypeCode.Byte:
		case TypeCode.Int16:
		case TypeCode.UInt16:
		case TypeCode.Int32:
		case TypeCode.UInt32:
		{
			int num = (int)obj;
			switch (num)
			{
			case 0:
				gen.Emit(OpCodes.Ldc_I4_0);
				break;
			case 1:
				gen.Emit(OpCodes.Ldc_I4_1);
				break;
			case 2:
				gen.Emit(OpCodes.Ldc_I4_2);
				break;
			case 3:
				gen.Emit(OpCodes.Ldc_I4_3);
				break;
			case 4:
				gen.Emit(OpCodes.Ldc_I4_4);
				break;
			case 5:
				gen.Emit(OpCodes.Ldc_I4_5);
				break;
			case 6:
				gen.Emit(OpCodes.Ldc_I4_6);
				break;
			case 7:
				gen.Emit(OpCodes.Ldc_I4_7);
				break;
			case 8:
				gen.Emit(OpCodes.Ldc_I4_8);
				break;
			case -1:
				gen.Emit(OpCodes.Ldc_I4_M1);
				break;
			default:
				gen.Emit(OpCodes.Ldc_I4, num);
				break;
			}
			break;
		}
		case TypeCode.Int64:
		case TypeCode.UInt64:
			gen.Emit(OpCodes.Ldc_I8, (long)obj);
			break;
		case TypeCode.Single:
			gen.Emit(OpCodes.Ldc_R4, (float)obj);
			break;
		case TypeCode.Double:
			gen.Emit(OpCodes.Ldc_R8, (double)obj);
			break;
		case TypeCode.Boolean:
			if ((bool)obj)
			{
				gen.Emit(OpCodes.Ldc_I4_1);
			}
			else
			{
				gen.Emit(OpCodes.Ldc_I4_0);
			}
			break;
		default:
			throw new InvalidOperationException("Literal type " + obj.GetType()?.ToString() + " not supported");
		}
	}

	public override Type GetResultType()
	{
		return type;
	}
}
