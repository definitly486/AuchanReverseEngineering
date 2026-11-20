using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace System.Diagnostics;

public class StackFrame
{
	private MethodBase _method;

	private int _nativeOffset;

	private int _ilOffset;

	private string _fileName;

	private int _lineNumber;

	private int _columnNumber;

	private bool _isLastFrameFromForeignExceptionStackTrace;

	public const int OFFSET_UNKNOWN = -1;

	internal bool IsLastFrameFromForeignExceptionStackTrace => _isLastFrameFromForeignExceptionStackTrace;

	internal StackFrame(MonoStackFrame monoStackFrame, bool needFileInfo)
	{
		_method = monoStackFrame.methodBase;
		_nativeOffset = monoStackFrame.nativeOffset;
		_ilOffset = monoStackFrame.ilOffset;
		if (needFileInfo)
		{
			_fileName = monoStackFrame.fileName;
			_lineNumber = monoStackFrame.lineNumber;
			_columnNumber = monoStackFrame.columnNumber;
		}
		_isLastFrameFromForeignExceptionStackTrace = monoStackFrame.isLastFrameFromForeignException;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BuildStackFrame(int skipFrames, bool needFileInfo)
	{
		if (skipFrames + 3 < 0)
		{
			return;
		}
		MethodBase o = null;
		string o2 = null;
		if (GetFrameInfo(skipFrames + 3, needFileInfo, ObjectHandleOnStack.Create(ref o), ObjectHandleOnStack.Create(ref o2), out var ilOffset, out var nativeOffset, out var line, out var column))
		{
			_method = o;
			_ilOffset = ilOffset;
			_nativeOffset = nativeOffset;
			if (needFileInfo)
			{
				_fileName = o2;
				_lineNumber = line;
				_columnNumber = column;
			}
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool GetFrameInfo(int skipFrames, bool needFileInfo, ObjectHandleOnStack out_method, ObjectHandleOnStack out_file, out int ilOffset, out int nativeOffset, out int line, out int column);

	private void InitMembers()
	{
		_nativeOffset = -1;
		_ilOffset = -1;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StackFrame()
	{
		InitMembers();
		BuildStackFrame(0, needFileInfo: false);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StackFrame(bool needFileInfo)
	{
		InitMembers();
		BuildStackFrame(0, needFileInfo);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StackFrame(int skipFrames)
	{
		InitMembers();
		BuildStackFrame(skipFrames, needFileInfo: false);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StackFrame(int skipFrames, bool needFileInfo)
	{
		InitMembers();
		BuildStackFrame(skipFrames, needFileInfo);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StackFrame(string? fileName, int lineNumber)
	{
		InitMembers();
		BuildStackFrame(0, needFileInfo: false);
		_fileName = fileName;
		_lineNumber = lineNumber;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StackFrame(string? fileName, int lineNumber, int colNumber)
	{
		InitMembers();
		BuildStackFrame(0, needFileInfo: false);
		_fileName = fileName;
		_lineNumber = lineNumber;
		_columnNumber = colNumber;
	}

	[RequiresUnreferencedCode("Metadata for the method might be incomplete or removed. Consider using DiagnosticMethodInfo.Create instead")]
	public virtual MethodBase? GetMethod()
	{
		return _method;
	}

	public virtual int GetNativeOffset()
	{
		return _nativeOffset;
	}

	public virtual int GetILOffset()
	{
		return _ilOffset;
	}

	public virtual string? GetFileName()
	{
		return _fileName;
	}

	public virtual int GetFileLineNumber()
	{
		return _lineNumber;
	}

	public virtual int GetFileColumnNumber()
	{
		return _columnNumber;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(255);
		bool flag2;
		if (_method != null)
		{
			stringBuilder.Append(_method.Name);
			if (_method is MethodInfo { IsGenericMethod: not false } methodInfo)
			{
				Type[] genericArguments = methodInfo.GetGenericArguments();
				stringBuilder.Append('<');
				int i = 0;
				bool flag = true;
				for (; i < genericArguments.Length; i++)
				{
					if (!flag)
					{
						stringBuilder.Append(',');
					}
					else
					{
						flag = false;
					}
					stringBuilder.Append(genericArguments[i].Name);
				}
				stringBuilder.Append('>');
			}
			flag2 = true;
		}
		else
		{
			flag2 = false;
		}
		if (flag2)
		{
			stringBuilder.Append(" at offset ");
			if (_nativeOffset == -1)
			{
				stringBuilder.Append("<offset unknown>");
			}
			else
			{
				stringBuilder.Append(_nativeOffset);
			}
			stringBuilder.Append(" in file:line:column ");
			stringBuilder.Append(_fileName ?? "<filename unknown>");
			stringBuilder.Append(':');
			stringBuilder.Append(_lineNumber);
			stringBuilder.Append(':');
			stringBuilder.Append(_columnNumber);
		}
		else
		{
			stringBuilder.Append("<null>");
		}
		stringBuilder.AppendLine();
		return stringBuilder.ToString();
	}
}
