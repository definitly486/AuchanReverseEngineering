using System.Collections.Generic;

namespace System.Reflection;

internal sealed class RuntimeMethodBody : MethodBody
{
	private byte[] _IL;

	private ExceptionHandlingClause[] _exceptionHandlingClauses;

	private LocalVariableInfo[] _localVariables;

	private int _localSignatureMetadataToken;

	private int _maxStackSize;

	private bool _initLocals;

	public override int LocalSignatureMetadataToken => _localSignatureMetadataToken;

	public override IList<LocalVariableInfo> LocalVariables => Array.AsReadOnly(_localVariables);

	public override int MaxStackSize => _maxStackSize;

	public override bool InitLocals => _initLocals;

	public override IList<ExceptionHandlingClause> ExceptionHandlingClauses => Array.AsReadOnly(_exceptionHandlingClauses);

	internal RuntimeMethodBody(ExceptionHandlingClause[] clauses, LocalVariableInfo[] locals, byte[] il, bool init_locals, int sig_token, int max_stack)
	{
		_exceptionHandlingClauses = clauses;
		_localVariables = locals;
		_IL = il;
		_initLocals = init_locals;
		_localSignatureMetadataToken = sig_token;
		_maxStackSize = max_stack;
	}

	public override byte[] GetILAsByteArray()
	{
		return _IL;
	}
}
