using System;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Runtime.CompilerServices;
using Microsoft.CSharp.RuntimeBinder.Semantics;

namespace Microsoft.CSharp.RuntimeBinder;

[RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
[RequiresDynamicCode("The 'dynamic' feature requires runtime-code generation, which is incompatible with AOT.")]
internal sealed class CSharpSetIndexBinder : SetIndexBinder, ICSharpBinder
{
	public string Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public BindingFlag BindingFlags => (BindingFlag)0;

	public bool IsBinderThatCanHaveRefReceiver => true;

	internal bool IsCompoundAssignment
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Expr DispatchPayload(RuntimeBinder runtimeBinder, ArgumentObject[] arguments, LocalVariableSymbol[] locals)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PopulateSymbolTableWithName(Type callingType, ArgumentObject[] arguments)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	CSharpArgumentInfo ICSharpBinder.GetArgumentInfo(int index)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetGetBinderEquivalenceHash()
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsEquivalentTo(ICSharpBinder other)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override DynamicMetaObject FallbackSetIndex(DynamicMetaObject target, DynamicMetaObject[] indexes, DynamicMetaObject value, DynamicMetaObject errorSuggestion)
	{
		throw new NotSupportedException("Linked away");
	}
}
