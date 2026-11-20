using System.Buffers.Binary;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit;

[StructLayout(LayoutKind.Sequential)]
internal sealed class RuntimeILGenerator : ILGenerator
{
	private struct LabelFixup
	{
		public int offset;

		public int pos;

		public int label_idx;
	}

	private struct LabelData
	{
		public int addr;

		public int maxStack;

		public LabelData(int addr, int maxStack)
		{
			this.addr = addr;
			this.maxStack = maxStack;
		}
	}

	private byte[] code;

	private int code_len;

	private int max_stack;

	private int cur_stack;

	private RuntimeLocalBuilder[] locals;

	private ILExceptionInfo[] ex_handlers;

	private int num_token_fixups;

	private object token_fixups;

	private LabelData[] labels;

	private int num_labels;

	private LabelFixup[] fixups;

	private int num_fixups;

	internal Module module;

	private int cur_block;

	private Int32Stack open_blocks;

	private ITokenGenerator token_gen;

	[MemberNotNullWhen(true, "open_blocks")]
	private bool InExceptionBlock
	{
		[MemberNotNullWhen(true, "open_blocks")]
		get
		{
			if (open_blocks != null)
			{
				return open_blocks.Count > 0;
			}
			return false;
		}
	}

	internal ITokenGenerator TokenGenerator => token_gen;

	public override int ILOffset => code_len;

	internal RuntimeILGenerator(Module m, ITokenGenerator token_gen, int size)
	{
		if (size < 0)
		{
			size = 128;
		}
		code = new byte[size];
		module = m;
		this.token_gen = token_gen;
	}

	private void make_room(int nbytes)
	{
		if (code_len + nbytes >= code.Length)
		{
			byte[] destinationArray = new byte[(code_len + nbytes) * 2 + 128];
			Array.Copy(code, 0, destinationArray, 0, code.Length);
			code = destinationArray;
		}
	}

	private void emit_int(int val)
	{
		BinaryPrimitives.WriteInt32LittleEndian(code.AsSpan(code_len), val);
		code_len += 4;
	}

	private void ll_emit(OpCode opcode)
	{
		if (opcode.Size == 2)
		{
			code[code_len++] = (byte)(opcode.Value >> 8);
		}
		code[code_len++] = (byte)(opcode.Value & 0xFF);
		switch (opcode.StackBehaviourPush)
		{
		case StackBehaviour.Push1:
		case StackBehaviour.Pushi:
		case StackBehaviour.Pushi8:
		case StackBehaviour.Pushr4:
		case StackBehaviour.Pushr8:
		case StackBehaviour.Pushref:
		case StackBehaviour.Varpush:
			cur_stack++;
			break;
		case StackBehaviour.Push1_push1:
			cur_stack += 2;
			break;
		}
		if (max_stack < cur_stack)
		{
			max_stack = cur_stack;
		}
		switch (opcode.StackBehaviourPop)
		{
		case StackBehaviour.Pop1:
		case StackBehaviour.Popi:
		case StackBehaviour.Popref:
			cur_stack--;
			break;
		case StackBehaviour.Pop1_pop1:
		case StackBehaviour.Popi_pop1:
		case StackBehaviour.Popi_popi:
		case StackBehaviour.Popi_popi8:
		case StackBehaviour.Popi_popr4:
		case StackBehaviour.Popi_popr8:
		case StackBehaviour.Popref_pop1:
		case StackBehaviour.Popref_popi:
			cur_stack -= 2;
			break;
		case StackBehaviour.Popi_popi_popi:
		case StackBehaviour.Popref_popi_popi:
		case StackBehaviour.Popref_popi_popi8:
		case StackBehaviour.Popref_popi_popr4:
		case StackBehaviour.Popref_popi_popr8:
		case StackBehaviour.Popref_popi_popref:
			cur_stack -= 3;
			break;
		case StackBehaviour.Push0:
		case StackBehaviour.Push1:
		case StackBehaviour.Push1_push1:
		case StackBehaviour.Pushi:
		case StackBehaviour.Pushi8:
		case StackBehaviour.Pushr4:
		case StackBehaviour.Pushr8:
		case StackBehaviour.Pushref:
		case StackBehaviour.Varpop:
			break;
		}
	}

	private static int target_len(OpCode opcode)
	{
		if (opcode.OperandType == OperandType.InlineBrTarget)
		{
			return 4;
		}
		return 1;
	}

	private void InternalEndClause()
	{
		switch (ex_handlers[cur_block].LastClauseType())
		{
		case -1:
		case 0:
		case 1:
			Emit(OpCodes.Leave, ex_handlers[cur_block].end);
			break;
		case 2:
		case 4:
			Emit(OpCodes.Endfinally);
			break;
		case 3:
			break;
		}
	}

	public override void BeginCatchBlock(Type exceptionType)
	{
		if (!InExceptionBlock)
		{
			throw new NotSupportedException("Argument_NotInExceptionBlock");
		}
		if (exceptionType != null && exceptionType.IsUserType)
		{
			throw new NotSupportedException("PlatformNotSupported_UserDefinedSubclassesOfType");
		}
		if (ex_handlers[cur_block].LastClauseType() == -1)
		{
			if (exceptionType != null)
			{
				throw new ArgumentException("Argument_ShouldNotSpecifyExceptionType");
			}
			Emit(OpCodes.Endfilter);
			ex_handlers[cur_block].PatchFilterClause(code_len);
		}
		else
		{
			InternalEndClause();
			ex_handlers[cur_block].AddCatch(exceptionType, code_len);
		}
		cur_stack = 1;
		if (max_stack < cur_stack)
		{
			max_stack = cur_stack;
		}
	}

	public override void BeginExceptFilterBlock()
	{
		if (!InExceptionBlock)
		{
			throw new NotSupportedException("Argument_NotInExceptionBlock");
		}
		InternalEndClause();
		ex_handlers[cur_block].AddFilter(code_len);
	}

	public override Label BeginExceptionBlock()
	{
		Int32Stack obj = open_blocks ?? (open_blocks = new Int32Stack(2));
		if (ex_handlers != null)
		{
			cur_block = ex_handlers.Length;
			ILExceptionInfo[] destinationArray = new ILExceptionInfo[cur_block + 1];
			Array.Copy(ex_handlers, destinationArray, cur_block);
			ex_handlers = destinationArray;
		}
		else
		{
			ex_handlers = new ILExceptionInfo[1];
			cur_block = 0;
		}
		obj.Push(cur_block);
		ex_handlers[cur_block].start = code_len;
		return ex_handlers[cur_block].end = DefineLabel();
	}

	public override void BeginFaultBlock()
	{
		if (!InExceptionBlock)
		{
			throw new NotSupportedException("Argument_NotInExceptionBlock");
		}
		if (ex_handlers[cur_block].LastClauseType() == -1)
		{
			Emit(OpCodes.Leave, ex_handlers[cur_block].end);
			ex_handlers[cur_block].PatchFilterClause(code_len);
		}
		InternalEndClause();
		ex_handlers[cur_block].AddFault(code_len);
	}

	public override void BeginFinallyBlock()
	{
		if (!InExceptionBlock)
		{
			throw new NotSupportedException("Argument_NotInExceptionBlock");
		}
		InternalEndClause();
		if (ex_handlers[cur_block].LastClauseType() == -1)
		{
			Emit(OpCodes.Leave, ex_handlers[cur_block].end);
			ex_handlers[cur_block].PatchFilterClause(code_len);
		}
		ex_handlers[cur_block].AddFinally(code_len);
	}

	public override void BeginScope()
	{
	}

	public override LocalBuilder DeclareLocal(Type localType, bool pinned)
	{
		ArgumentNullException.ThrowIfNull(localType, "localType");
		if (localType.IsUserType)
		{
			throw new NotSupportedException("PlatformNotSupported_UserDefinedSubclassesOfType");
		}
		RuntimeLocalBuilder runtimeLocalBuilder = new RuntimeLocalBuilder(localType, this);
		runtimeLocalBuilder.is_pinned = pinned;
		if (locals != null)
		{
			RuntimeLocalBuilder[] array = new RuntimeLocalBuilder[locals.Length + 1];
			Array.Copy(locals, array, locals.Length);
			array[locals.Length] = runtimeLocalBuilder;
			locals = array;
		}
		else
		{
			locals = new RuntimeLocalBuilder[1];
			locals[0] = runtimeLocalBuilder;
		}
		runtimeLocalBuilder.position = (ushort)(locals.Length - 1);
		return runtimeLocalBuilder;
	}

	public override Label DefineLabel()
	{
		if (labels == null)
		{
			labels = new LabelData[4];
		}
		else if (num_labels >= labels.Length)
		{
			LabelData[] destinationArray = new LabelData[labels.Length * 2];
			Array.Copy(labels, destinationArray, labels.Length);
			labels = destinationArray;
		}
		labels[num_labels] = new LabelData(-1, 0);
		return new Label(num_labels++);
	}

	public override void Emit(OpCode opcode)
	{
		make_room(2);
		ll_emit(opcode);
	}

	public override void Emit(OpCode opcode, byte arg)
	{
		make_room(3);
		ll_emit(opcode);
		code[code_len++] = arg;
	}

	public override void Emit(OpCode opcode, ConstructorInfo con)
	{
		int token = token_gen.GetToken(con, create_open_instance: true);
		make_room(6);
		ll_emit(opcode);
		emit_int(token);
		if (opcode.StackBehaviourPop == StackBehaviour.Varpop)
		{
			cur_stack -= con.GetParametersCount();
		}
	}

	public override void Emit(OpCode opcode, double arg)
	{
		make_room(10);
		ll_emit(opcode);
		BinaryPrimitives.WriteDoubleLittleEndian(code.AsSpan(code_len), arg);
		code_len += 8;
	}

	public override void Emit(OpCode opcode, FieldInfo field)
	{
		int token = token_gen.GetToken(field, create_open_instance: true);
		make_room(6);
		ll_emit(opcode);
		emit_int(token);
	}

	public override void Emit(OpCode opcode, short arg)
	{
		make_room(4);
		ll_emit(opcode);
		BinaryPrimitives.WriteInt16LittleEndian(code.AsSpan(code_len), arg);
		code_len += 2;
	}

	public override void Emit(OpCode opcode, int arg)
	{
		make_room(6);
		ll_emit(opcode);
		emit_int(arg);
	}

	public override void Emit(OpCode opcode, long arg)
	{
		make_room(10);
		ll_emit(opcode);
		BinaryPrimitives.WriteInt64LittleEndian(code.AsSpan(code_len), arg);
		code_len += 8;
	}

	public override void Emit(OpCode opcode, Label label)
	{
		int num = target_len(opcode);
		make_room(6);
		ll_emit(opcode);
		if (cur_stack > labels[label.m_label].maxStack)
		{
			labels[label.m_label].maxStack = cur_stack;
		}
		if (fixups == null)
		{
			fixups = new LabelFixup[4];
		}
		else if (num_fixups >= fixups.Length)
		{
			LabelFixup[] destinationArray = new LabelFixup[fixups.Length * 2];
			Array.Copy(fixups, destinationArray, fixups.Length);
			fixups = destinationArray;
		}
		fixups[num_fixups].offset = num;
		fixups[num_fixups].pos = code_len;
		fixups[num_fixups].label_idx = label.m_label;
		num_fixups++;
		code_len += num;
	}

	public override void Emit(OpCode opcode, Label[] labels)
	{
		ArgumentNullException.ThrowIfNull(labels, "labels");
		int num = labels.Length;
		make_room(6 + num * 4);
		ll_emit(opcode);
		for (int i = 0; i < num; i++)
		{
			if (cur_stack > this.labels[labels[i].m_label].maxStack)
			{
				this.labels[labels[i].m_label].maxStack = cur_stack;
			}
		}
		emit_int(num);
		if (fixups == null)
		{
			fixups = new LabelFixup[4 + num];
		}
		else if (num_fixups + num >= fixups.Length)
		{
			LabelFixup[] destinationArray = new LabelFixup[num + fixups.Length * 2];
			Array.Copy(fixups, destinationArray, fixups.Length);
			fixups = destinationArray;
		}
		int num2 = 0;
		int num3 = num * 4;
		while (num2 < num)
		{
			fixups[num_fixups].offset = num3;
			fixups[num_fixups].pos = code_len;
			fixups[num_fixups].label_idx = labels[num2].m_label;
			num_fixups++;
			code_len += 4;
			num2++;
			num3 -= 4;
		}
	}

	public override void Emit(OpCode opcode, LocalBuilder local)
	{
		ArgumentNullException.ThrowIfNull(local, "local");
		if (!(local is RuntimeLocalBuilder runtimeLocalBuilder) || runtimeLocalBuilder.ilgen != this)
		{
			throw new ArgumentException("Argument_UnmatchedMethodForLocal", "local");
		}
		uint position = runtimeLocalBuilder.position;
		if ((opcode == OpCodes.Ldloca_S || opcode == OpCodes.Ldloc_S || opcode == OpCodes.Stloc_S) && position > 255)
		{
			throw new InvalidOperationException("InvalidOperation_BadInstructionOrIndexOutOfBound");
		}
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		make_room(6);
		if (opcode.StackBehaviourPop == StackBehaviour.Pop1)
		{
			cur_stack--;
			flag2 = true;
		}
		else if (opcode.StackBehaviourPush == StackBehaviour.Push1 || opcode.StackBehaviourPush == StackBehaviour.Pushi)
		{
			cur_stack++;
			flag3 = true;
			if (cur_stack > max_stack)
			{
				max_stack = cur_stack;
			}
			flag = opcode.StackBehaviourPush == StackBehaviour.Pushi;
		}
		if (flag)
		{
			if (position < 256)
			{
				code[code_len++] = 18;
				code[code_len++] = (byte)position;
				return;
			}
			code[code_len++] = 254;
			code[code_len++] = 13;
			code[code_len++] = (byte)(position & 0xFF);
			code[code_len++] = (byte)((position >> 8) & 0xFF);
		}
		else if (flag2)
		{
			if (position < 4)
			{
				code[code_len++] = (byte)(10 + position);
				return;
			}
			if (position < 256)
			{
				code[code_len++] = 19;
				code[code_len++] = (byte)position;
				return;
			}
			code[code_len++] = 254;
			code[code_len++] = 14;
			code[code_len++] = (byte)(position & 0xFF);
			code[code_len++] = (byte)((position >> 8) & 0xFF);
		}
		else if (flag3)
		{
			if (position < 4)
			{
				code[code_len++] = (byte)(6 + position);
				return;
			}
			if (position < 256)
			{
				code[code_len++] = 17;
				code[code_len++] = (byte)position;
				return;
			}
			code[code_len++] = 254;
			code[code_len++] = 12;
			code[code_len++] = (byte)(position & 0xFF);
			code[code_len++] = (byte)((position >> 8) & 0xFF);
		}
		else
		{
			ll_emit(opcode);
		}
	}

	public override void Emit(OpCode opcode, MethodInfo meth)
	{
		ArgumentNullException.ThrowIfNull(meth, "meth");
		if (meth is DynamicMethod && (opcode == OpCodes.Ldftn || opcode == OpCodes.Ldvirtftn || opcode == OpCodes.Ldtoken))
		{
			throw new ArgumentException("Argument_InvalidOpCodeOnDynamicMethod");
		}
		int token = token_gen.GetToken(meth, create_open_instance: true);
		make_room(6);
		ll_emit(opcode);
		emit_int(token);
		if (meth.ReturnType != typeof(void))
		{
			cur_stack++;
		}
		if (opcode.StackBehaviourPop == StackBehaviour.Varpop)
		{
			cur_stack -= meth.GetParametersCount();
		}
	}

	private void Emit(OpCode opcode, MethodInfo method, int token)
	{
		make_room(6);
		ll_emit(opcode);
		emit_int(token);
		if (method.ReturnType != typeof(void))
		{
			cur_stack++;
		}
		if (opcode.StackBehaviourPop == StackBehaviour.Varpop)
		{
			cur_stack -= method.GetParametersCount();
		}
	}

	public override void Emit(OpCode opcode, SignatureHelper signature)
	{
		int token = token_gen.GetToken(signature);
		make_room(6);
		ll_emit(opcode);
		emit_int(token);
	}

	public override void Emit(OpCode opcode, float arg)
	{
		make_room(6);
		ll_emit(opcode);
		BinaryPrimitives.WriteSingleLittleEndian(code.AsSpan(code_len), arg);
		code_len += 4;
	}

	public override void Emit(OpCode opcode, string str)
	{
		int token = token_gen.GetToken(str);
		make_room(6);
		ll_emit(opcode);
		emit_int(token);
	}

	public override void Emit(OpCode opcode, Type cls)
	{
		make_room(6);
		ll_emit(opcode);
		int token = token_gen.GetToken(cls, opcode != OpCodes.Ldtoken);
		emit_int(token);
	}

	public override void EmitCall(OpCode opcode, MethodInfo methodInfo, Type[] optionalParameterTypes)
	{
		ArgumentNullException.ThrowIfNull(methodInfo, "methodInfo");
		short value = opcode.Value;
		if (value != OpCodes.Call.Value && value != OpCodes.Callvirt.Value)
		{
			throw new NotSupportedException("Argument_NotMethodCallOpcode");
		}
		if ((methodInfo.CallingConvention & CallingConventions.VarArgs) == 0)
		{
			optionalParameterTypes = null;
		}
		if (optionalParameterTypes != null)
		{
			if ((methodInfo.CallingConvention & CallingConventions.VarArgs) == 0)
			{
				throw new InvalidOperationException("InvalidOperation_NotAVarArgCallingConvention");
			}
			int token = token_gen.GetToken(methodInfo, optionalParameterTypes);
			Emit(opcode, methodInfo, token);
		}
		else
		{
			Emit(opcode, methodInfo);
		}
	}

	public override void EmitCalli(OpCode opcode, CallingConvention unmanagedCallConv, Type returnType, Type[] parameterTypes)
	{
		SignatureHelper methodSigHelper = SignatureHelper.GetMethodSigHelper(module as ModuleBuilder, (CallingConventions)0, unmanagedCallConv, returnType, parameterTypes);
		Emit(opcode, methodSigHelper);
	}

	public override void EmitCalli(OpCode opcode, CallingConventions callingConvention, Type returnType, Type[] parameterTypes, Type[] optionalParameterTypes)
	{
		if (optionalParameterTypes != null)
		{
			throw new NotImplementedException();
		}
		SignatureHelper methodSigHelper = SignatureHelper.GetMethodSigHelper(module as ModuleBuilder, callingConvention, (CallingConvention)0, returnType, parameterTypes);
		Emit(opcode, methodSigHelper);
	}

	public override void EndExceptionBlock()
	{
		if (!InExceptionBlock)
		{
			throw new NotSupportedException("Argument_NotInExceptionBlock");
		}
		if (ex_handlers[cur_block].LastClauseType() == -1)
		{
			throw new InvalidOperationException("Argument_BadExceptionCodeGen");
		}
		InternalEndClause();
		MarkLabel(ex_handlers[cur_block].end);
		ex_handlers[cur_block].End(code_len);
		open_blocks.Pop();
		if (open_blocks.Count > 0)
		{
			cur_block = open_blocks.Peek();
		}
	}

	public override void EndScope()
	{
	}

	public override void MarkLabel(Label loc)
	{
		if (loc.m_label < 0 || loc.m_label >= num_labels)
		{
			throw new ArgumentException("Argument_InvalidLabel");
		}
		if (labels[loc.m_label].addr >= 0)
		{
			throw new ArgumentException("Argument_RedefinedLabel");
		}
		labels[loc.m_label].addr = code_len;
		if (labels[loc.m_label].maxStack > cur_stack)
		{
			cur_stack = labels[loc.m_label].maxStack;
		}
	}

	public override void UsingNamespace(string usingNamespace)
	{
		throw new NotImplementedException();
	}

	internal void label_fixup(MethodBase mb)
	{
		for (int i = 0; i < num_fixups; i++)
		{
			if (labels[fixups[i].label_idx].addr < 0)
			{
				throw new ArgumentException(SR.Format("Argument_LabelUnmarked", fixups[i].label_idx + 1, mb.Name));
			}
			int num = labels[fixups[i].label_idx].addr - (fixups[i].pos + fixups[i].offset);
			if (fixups[i].offset == 1)
			{
				code[fixups[i].pos] = (byte)(sbyte)num;
				continue;
			}
			int num2 = code_len;
			code_len = fixups[i].pos;
			emit_int(num);
			code_len = num2;
		}
	}

	internal void SetCode(byte[] code, int max_stack)
	{
		this.code = ((code != null) ? ((byte[])code.Clone()) : Array.Empty<byte>());
		code_len = this.code.Length;
		this.max_stack = max_stack;
		cur_stack = 0;
	}

	internal unsafe void SetCode(byte* code, int code_size, int max_stack)
	{
		this.code = new ReadOnlySpan<byte>(code, code_size).ToArray();
		code_len = code_size;
		this.max_stack = max_stack;
		cur_stack = 0;
	}
}
