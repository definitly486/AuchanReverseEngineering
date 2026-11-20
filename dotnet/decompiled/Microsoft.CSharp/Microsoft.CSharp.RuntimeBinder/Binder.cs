using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Microsoft.CSharp.RuntimeBinder;

[EditorBrowsable(EditorBrowsableState.Never)]
public static class Binder
{
	[RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
	[RequiresDynamicCode("The 'dynamic' feature requires runtime-code generation, which is incompatible with AOT.")]
	public static CallSiteBinder Convert(CSharpBinderFlags flags, Type type, Type? context)
	{
		CSharpConversionKind conversionKind = (((flags & CSharpBinderFlags.ConvertExplicit) != CSharpBinderFlags.None) ? CSharpConversionKind.ExplicitConversion : (((flags & CSharpBinderFlags.ConvertArrayIndex) != CSharpBinderFlags.None) ? CSharpConversionKind.ArrayCreationConversion : CSharpConversionKind.ImplicitConversion));
		bool isChecked = (flags & CSharpBinderFlags.CheckedContext) != 0;
		return new CSharpConvertBinder(type, conversionKind, isChecked, context).TryGetExisting();
	}

	[RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
	[RequiresDynamicCode("The 'dynamic' feature requires runtime-code generation, which is incompatible with AOT.")]
	public static CallSiteBinder GetMember(CSharpBinderFlags flags, string name, Type? context, IEnumerable<CSharpArgumentInfo>? argumentInfo)
	{
		bool resultIndexed = (flags & CSharpBinderFlags.ResultIndexed) != 0;
		return new CSharpGetMemberBinder(name, resultIndexed, context, argumentInfo).TryGetExisting();
	}

	[RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
	[RequiresDynamicCode("The 'dynamic' feature requires runtime-code generation, which is incompatible with AOT.")]
	public static CallSiteBinder SetMember(CSharpBinderFlags flags, string name, Type? context, IEnumerable<CSharpArgumentInfo>? argumentInfo)
	{
		bool isCompoundAssignment = (flags & CSharpBinderFlags.ValueFromCompoundAssignment) != 0;
		bool isChecked = (flags & CSharpBinderFlags.CheckedContext) != 0;
		return new CSharpSetMemberBinder(name, isCompoundAssignment, isChecked, context, argumentInfo).TryGetExisting();
	}
}
