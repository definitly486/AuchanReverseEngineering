using System;
using System.Diagnostics.CodeAnalysis;

namespace Java.Interop;

public struct JniTypeSignature : IEquatable<JniTypeSignature>
{
	public static readonly JniTypeSignature Empty;

	internal bool IsKeyword { get; private set; }

	public string? SimpleReference { get; private set; }

	public int ArrayRank { get; private set; }

	public bool IsValid => SimpleReference != null;

	public string QualifiedReference
	{
		get
		{
			string text = (IsKeyword ? (SimpleReference ?? throw new InvalidOperationException()) : ("L" + SimpleReference + ";"));
			if (ArrayRank != 0)
			{
				return new string('[', ArrayRank) + text;
			}
			return text;
		}
	}

	public string Name
	{
		get
		{
			if (ArrayRank != 0)
			{
				return QualifiedReference;
			}
			return SimpleReference ?? throw new InvalidOperationException();
		}
	}

	public JniTypeSignature(string? simpleReference, int arrayRank = 0, bool keyword = false)
	{
		if (simpleReference != null)
		{
			if (simpleReference.Length < 1)
			{
				throw new ArgumentException("The empty string is not a valid JNI simple reference.", "simpleReference");
			}
			if (simpleReference.IndexOf('.') >= 0)
			{
				throw new ArgumentException("JNI type names do not contain '.', they use '/'. Are you sure you're using a JNI type name?", "simpleReference");
			}
			if (simpleReference[0] == '[')
			{
				throw new ArgumentException("To specify an array, use the ArrayRank property.", "simpleReference");
			}
			if (simpleReference[0] == 'L' && simpleReference[simpleReference.Length - 1] == ';')
			{
				throw new ArgumentException("JNI type references are not supported.", "simpleReference");
			}
		}
		SimpleReference = simpleReference;
		ArrayRank = arrayRank;
		IsKeyword = keyword;
	}

	public JniTypeSignature AddArrayRank(int rank)
	{
		if (SimpleReference == null)
		{
			throw new InvalidOperationException();
		}
		return new JniTypeSignature(SimpleReference, ArrayRank + rank, IsKeyword);
	}

	public JniTypeSignature GetPrimitivePeerTypeSignature()
	{
		if (!IsKeyword)
		{
			return this;
		}
		return SimpleReference switch
		{
			"V" => new JniTypeSignature("java/lang/Void", ArrayRank), 
			"Z" => new JniTypeSignature("java/lang/Boolean", ArrayRank), 
			"B" => new JniTypeSignature("java/lang/Byte", ArrayRank), 
			"C" => new JniTypeSignature("java/lang/Character", ArrayRank), 
			"S" => new JniTypeSignature("java/lang/Short", ArrayRank), 
			"I" => new JniTypeSignature("java/lang/Integer", ArrayRank), 
			"J" => new JniTypeSignature("java/lang/Long", ArrayRank), 
			"F" => new JniTypeSignature("java/lang/Float", ArrayRank), 
			"D" => new JniTypeSignature("java/lang/Double", ArrayRank), 
			_ => throw new InvalidOperationException($"SimpleReference '{SimpleReference}' isn't a known keyword reference, yet is a keyword."), 
		};
	}

	public static JniTypeSignature Parse(string signature)
	{
		JniTypeSignature result;
		Exception ex = TryParseWithException(signature, out result);
		if (ex != null)
		{
			throw ex;
		}
		return result;
	}

	public static bool TryParse(string signature, [NotNullWhen(true)] out JniTypeSignature result)
	{
		if (TryParseWithException(signature, out result) != null)
		{
			return false;
		}
		return true;
	}

	private static Exception? TryParseWithException(string signature, out JniTypeSignature result)
	{
		result = default(JniTypeSignature);
		if (signature == null)
		{
			return new ArgumentNullException("signature");
		}
		if (signature.Length < 1)
		{
			return new ArgumentException("The empty string is not a valid JNI simple reference.", "signature");
		}
		int num = 0;
		int num2 = 0;
		string text = null;
		bool keyword = false;
		while (num < signature.Length && signature[num] == '[')
		{
			num++;
			num2++;
		}
		switch (signature[num])
		{
		case 'B':
		case 'C':
		case 'D':
		case 'F':
		case 'I':
		case 'J':
		case 'S':
		case 'Z':
			if (signature.Length - num > 1)
			{
				text = signature.Substring(num);
				break;
			}
			text = signature[num].ToString();
			keyword = true;
			break;
		case 'L':
		{
			int num3 = signature.IndexOf(';', num);
			if (num3 >= num && num3 != signature.Length - 1)
			{
				return new ArgumentException($"Malformed JNI type reference: trailing text after ';' in '{signature}'.", "signature");
			}
			if (num == 0)
			{
				text = ((num3 > num) ? signature.Substring(num + 1, num3 - num - 1) : signature);
				break;
			}
			if (num3 < num)
			{
				return new ArgumentException($"Malformed JNI type reference; no terminating ';' for type ref: '{signature.Substring(num)}'.", "signature");
			}
			if (num3 != signature.Length - 1)
			{
				return new ArgumentException($"Malformed jNI type reference: invalid trailing text: '{signature.Substring(num)}'.", "signature");
			}
			text = signature.Substring(num + 1, num3 - num - 1);
			break;
		}
		default:
			if (num != 0)
			{
				return new ArgumentException($"Malformed JNI type reference: found unrecognized char '{signature[num]}' in '{signature}'.", "signature");
			}
			text = signature;
			break;
		}
		int num4 = text.IndexOfAny(new char[2] { '.', ';' });
		if (num4 >= 0)
		{
			return new ArgumentException($"Malformed JNI type reference: contains '{text[num4]}': {signature}", "signature");
		}
		result = new JniTypeSignature(text, num2, keyword);
		return null;
	}

	public override int GetHashCode()
	{
		return QualifiedReference.GetHashCode(StringComparison.Ordinal);
	}

	public override bool Equals(object? obj)
	{
		JniTypeSignature? jniTypeSignature = obj as JniTypeSignature?;
		if (jniTypeSignature.HasValue)
		{
			return Equals(jniTypeSignature.Value);
		}
		return false;
	}

	public bool Equals(JniTypeSignature other)
	{
		if (IsKeyword == other.IsKeyword && SimpleReference == other.SimpleReference)
		{
			return ArrayRank == other.ArrayRank;
		}
		return false;
	}

	public override string ToString()
	{
		return $"JniTypeSignature(TypeName={SimpleReference} ArrayRank={ArrayRank} Keyword={IsKeyword})";
	}

	public static bool operator ==(JniTypeSignature lhs, JniTypeSignature rhs)
	{
		return lhs.Equals(rhs);
	}

	public static bool operator !=(JniTypeSignature lhs, JniTypeSignature rhs)
	{
		return !lhs.Equals(rhs);
	}
}
