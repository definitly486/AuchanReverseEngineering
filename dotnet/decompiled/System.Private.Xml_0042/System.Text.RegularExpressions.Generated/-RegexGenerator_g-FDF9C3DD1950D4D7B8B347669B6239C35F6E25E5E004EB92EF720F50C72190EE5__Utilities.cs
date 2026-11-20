using System.Buffers;
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
internal static class _003CRegexGenerator_g_003EFDF9C3DD1950D4D7B8B347669B6239C35F6E25E5E004EB92EF720F50C72190EE5__Utilities
{
	internal static readonly TimeSpan s_defaultTimeout = ((AppContext.GetData("REGEX_DEFAULT_MATCH_TIMEOUT") is TimeSpan timeSpan) ? timeSpan : Regex.InfiniteMatchTimeout);

	internal static readonly bool s_hasTimeout = s_defaultTimeout != Regex.InfiniteMatchTimeout;

	internal static readonly SearchValues<string> s_indexOfString_24E3F0A96FA8DE99FB25D242D87DAC774B6CA6628023D99447766181AE8B5C1F;

	internal static readonly SearchValues<string> s_indexOfString_49E5939642BED022FF4CCC68711C353694EC5E15398AE4B384C29A17BD819BDF;

	internal static readonly SearchValues<string> s_indexOfString_A33692426CD23EBB54EC2CE470CB74EA3BB2120AA9FB6C85181C764DD117847E;

	internal static readonly SearchValues<string> s_indexOfString_C94AE607B1711C3F90CF8B8C224548ED74A865FE986797F62276464CE6F9271D;

	internal static readonly SearchValues<string> s_indexOfString__x_OrdinalIgnoreCase;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static void StackPush(ref int[] stack, ref int pos, int arg0)
	{
		int[] array = stack;
		int num = pos;
		if ((uint)num < (uint)array.Length)
		{
			array[num] = arg0;
			pos++;
		}
		else
		{
			WithResize(ref stack, ref pos, arg0);
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		static void WithResize(ref int[] reference, ref int reference2, int arg1)
		{
			Array.Resize(ref reference, reference2 * 2);
			StackPush(ref reference, ref reference2, arg1);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static void StackPush(ref int[] stack, ref int pos, int arg0, int arg1)
	{
		int[] array = stack;
		int num = pos;
		if ((uint)(num + 1) < (uint)array.Length)
		{
			array[num] = arg0;
			array[num + 1] = arg1;
			pos += 2;
		}
		else
		{
			WithResize(ref stack, ref pos, arg0, arg1);
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		static void WithResize(ref int[] reference, ref int reference2, int arg2, int arg3)
		{
			Array.Resize(ref reference, (reference2 + 1) * 2);
			StackPush(ref reference, ref reference2, arg2, arg3);
		}
	}

	static _003CRegexGenerator_g_003EFDF9C3DD1950D4D7B8B347669B6239C35F6E25E5E004EB92EF720F50C72190EE5__Utilities()
	{
		string reference = "paramsRead[";
		s_indexOfString_24E3F0A96FA8DE99FB25D242D87DAC774B6CA6628023D99447766181AE8B5C1F = SearchValues.Create(new ReadOnlySpan<string>(in reference), StringComparison.Ordinal);
		string reference2 = "UnknownNode((object)";
		s_indexOfString_49E5939642BED022FF4CCC68711C353694EC5E15398AE4B384C29A17BD819BDF = SearchValues.Create(new ReadOnlySpan<string>(in reference2), StringComparison.Ordinal);
		string reference3 = "UnknownNode(null, @\"";
		s_indexOfString_A33692426CD23EBB54EC2CE470CB74EA3BB2120AA9FB6C85181C764DD117847E = SearchValues.Create(new ReadOnlySpan<string>(in reference3), StringComparison.Ordinal);
		string reference4 = "((";
		s_indexOfString_C94AE607B1711C3F90CF8B8C224548ED74A865FE986797F62276464CE6F9271D = SearchValues.Create(new ReadOnlySpan<string>(in reference4), StringComparison.Ordinal);
		string reference5 = "_x";
		s_indexOfString__x_OrdinalIgnoreCase = SearchValues.Create(new ReadOnlySpan<string>(in reference5), StringComparison.OrdinalIgnoreCase);
	}
}
