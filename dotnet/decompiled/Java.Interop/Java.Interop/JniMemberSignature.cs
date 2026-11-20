using System;
using System.Collections.Generic;

namespace Java.Interop;

public struct JniMemberSignature : IEquatable<JniMemberSignature>
{
	private string? memberName;

	private string? memberSignature;

	internal static IEnumerable<JniTypeSignature> GetParameterTypesFromMethodSignature(string jniMethodSignature)
	{
		if (jniMethodSignature.Length < "()V".Length || jniMethodSignature[0] != '(')
		{
			throw new ArgumentException("Member signature `" + jniMethodSignature + "` is not a method signature.  Method signatures must start with `(`.", "jniMethodSignature");
		}
		int index = 1;
		while (index < jniMethodSignature.Length && jniMethodSignature[index] != ')')
		{
			(int StartIndex, int Length) tuple = ExtractType(jniMethodSignature, ref index);
			int item = tuple.StartIndex;
			int item2 = tuple.Length;
			string signature = jniMethodSignature.Substring(item, item2);
			yield return JniTypeSignature.Parse(signature);
		}
	}

	public static int GetParameterCountFromMethodSignature(string jniMethodSignature)
	{
		if (jniMethodSignature.Length < "()V".Length || jniMethodSignature[0] != '(')
		{
			throw new ArgumentException("Member signature `" + jniMethodSignature + "` is not a method signature.  Method signatures must start with `(`.", "jniMethodSignature");
		}
		int num = 0;
		int index = 1;
		while (index < jniMethodSignature.Length && jniMethodSignature[index] != ')')
		{
			ExtractType(jniMethodSignature, ref index);
			num++;
		}
		return num;
	}

	internal static (int StartIndex, int Length) ExtractType(string signature, ref int index)
	{
		AssertSignatureIndex(signature, index);
		int num = index++;
		switch (signature[num])
		{
		case '[':
			if (num + 1 >= signature.Length)
			{
				throw new InvalidOperationException($"Missing array type after '[' at index {num} in: `{signature}`");
			}
			ExtractType(signature, ref index);
			return (StartIndex: num, Length: index - num);
		case 'B':
		case 'C':
		case 'D':
		case 'F':
		case 'I':
		case 'J':
		case 'S':
		case 'V':
		case 'Z':
			return (StartIndex: num, Length: 1);
		case 'L':
		{
			int num2 = 0;
			int num3 = index;
			while (num3 < signature.Length)
			{
				char c = signature[num3++];
				if (num2 == 0 && c == ';')
				{
					break;
				}
			}
			if (num3 > signature.Length)
			{
				throw new InvalidOperationException($"Missing reference type after `{signature[num]}` at index {num} in `{signature}`!");
			}
			index = num3;
			return (StartIndex: num, Length: num3 - num);
		}
		default:
			throw new InvalidOperationException($"Unknown JNI Type `{signature[num]}` within: `{signature}`!");
		}
	}

	internal static void AssertSignatureIndex(string signature, int index)
	{
		if (signature == null)
		{
			throw new ArgumentNullException("signature");
		}
		if (signature.Length == 0)
		{
			throw new ArgumentException("Descriptor cannot be empty string", "signature");
		}
		if (index >= signature.Length)
		{
			throw new ArgumentException("index >= descriptor.Length", "index");
		}
	}

	public override int GetHashCode()
	{
		return (memberName?.GetHashCode() ?? 0) ^ (memberSignature?.GetHashCode() ?? 0);
	}

	public override bool Equals(object? obj)
	{
		JniMemberSignature? jniMemberSignature = obj as JniMemberSignature?;
		if (jniMemberSignature.HasValue)
		{
			return Equals(jniMemberSignature.Value);
		}
		return false;
	}

	public bool Equals(JniMemberSignature other)
	{
		if (memberName == other.memberName)
		{
			return memberSignature == other.memberSignature;
		}
		return false;
	}

	public override string ToString()
	{
		return $"{"JniMemberSignature"} {{ {"MemberName"} = {((memberName == null) ? "null" : ("\"" + memberName + "\""))}, {"MemberSignature"} = {((memberSignature == null) ? "null" : ("\"" + memberSignature + "\""))}}}";
	}

	public static bool operator ==(JniMemberSignature a, JniMemberSignature b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(JniMemberSignature a, JniMemberSignature b)
	{
		return !a.Equals(b);
	}
}
