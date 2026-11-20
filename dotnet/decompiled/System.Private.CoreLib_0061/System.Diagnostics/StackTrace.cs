using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace System.Diagnostics;

public class StackTrace
{
	internal enum TraceFormat
	{
		Normal,
		TrailingNewLine
	}

	public const int METHODS_TO_SKIP = 0;

	private int _numOfFrames;

	private int _methodsToSkip;

	private StackFrame[] _stackFrames;

	[FeatureSwitchDefinition("System.Diagnostics.StackTrace.IsSupported")]
	internal static bool IsSupported { get; } = InitializeIsSupported();

	public virtual int FrameCount => _numOfFrames;

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void GetTrace(ObjectHandleOnStack ex, ObjectHandleOnStack res, int skipFrames, bool needFileInfo);

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "StackFrame.GetMethod is getting compared to null but nothing else on it is touched.")]
	private void InitializeForCurrentThread(int skipFrames, bool needFileInfo)
	{
		skipFrames += 2;
		List<StackFrame> list = new List<StackFrame>();
		while (skipFrames >= 0)
		{
			StackFrame stackFrame = new StackFrame(skipFrames, needFileInfo);
			if (stackFrame.GetMethod() == null)
			{
				break;
			}
			list.Add(stackFrame);
			skipFrames++;
		}
		_stackFrames = list.ToArray();
		_numOfFrames = _stackFrames.Length;
	}

	private void InitializeForException(Exception e, int skipFrames, bool needFileInfo)
	{
		MonoStackFrame[] o = null;
		GetTrace(ObjectHandleOnStack.Create(ref e), ObjectHandleOnStack.Create(ref o), skipFrames, needFileInfo);
		_numOfFrames = o.Length;
		MonoStackFrame[] foreignExceptionsFrames = e.foreignExceptionsFrames;
		int num;
		if (foreignExceptionsFrames != null)
		{
			num = foreignExceptionsFrames.Length;
			_numOfFrames += num;
			_stackFrames = new StackFrame[_numOfFrames];
			for (int i = 0; i < foreignExceptionsFrames.Length; i++)
			{
				_stackFrames[i] = new StackFrame(foreignExceptionsFrames[i], needFileInfo);
			}
		}
		else
		{
			_stackFrames = new StackFrame[_numOfFrames];
			num = 0;
		}
		for (int j = 0; j < o.Length; j++)
		{
			_stackFrames[num + j] = new StackFrame(o[j], needFileInfo);
		}
	}

	private static bool InitializeIsSupported()
	{
		if (!AppContext.TryGetSwitch("System.Diagnostics.StackTrace.IsSupported", out var isEnabled))
		{
			return true;
		}
		return isEnabled;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StackTrace()
	{
		InitializeForCurrentThread(0, needFileInfo: false);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StackTrace(bool fNeedFileInfo)
	{
		InitializeForCurrentThread(0, fNeedFileInfo);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StackTrace(int skipFrames)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(skipFrames, "skipFrames");
		InitializeForCurrentThread(skipFrames, needFileInfo: false);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StackTrace(int skipFrames, bool fNeedFileInfo)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(skipFrames, "skipFrames");
		InitializeForCurrentThread(skipFrames, fNeedFileInfo);
	}

	public StackTrace(Exception e)
	{
		ArgumentNullException.ThrowIfNull(e, "e");
		InitializeForException(e, 0, needFileInfo: false);
	}

	public StackTrace(Exception e, bool fNeedFileInfo)
	{
		ArgumentNullException.ThrowIfNull(e, "e");
		InitializeForException(e, 0, fNeedFileInfo);
	}

	public StackTrace(Exception e, int skipFrames)
	{
		ArgumentNullException.ThrowIfNull(e, "e");
		ArgumentOutOfRangeException.ThrowIfNegative(skipFrames, "skipFrames");
		InitializeForException(e, skipFrames, needFileInfo: false);
	}

	public StackTrace(Exception e, int skipFrames, bool fNeedFileInfo)
	{
		ArgumentNullException.ThrowIfNull(e, "e");
		ArgumentOutOfRangeException.ThrowIfNegative(skipFrames, "skipFrames");
		InitializeForException(e, skipFrames, fNeedFileInfo);
	}

	public StackTrace(StackFrame frame)
	{
		_stackFrames = new StackFrame[1] { frame };
		_numOfFrames = 1;
	}

	public StackTrace(IEnumerable<StackFrame> frames)
	{
		ArgumentNullException.ThrowIfNull(frames, "frames");
		List<StackFrame> list = new List<StackFrame>(frames);
		_stackFrames = list.ToArray();
		_numOfFrames = list.Count;
	}

	public virtual StackFrame? GetFrame(int index)
	{
		if (_stackFrames != null && index < _numOfFrames && index >= 0)
		{
			return _stackFrames[index + _methodsToSkip];
		}
		return null;
	}

	public virtual StackFrame[] GetFrames()
	{
		if (_stackFrames == null || _numOfFrames <= 0)
		{
			return Array.Empty<StackFrame>();
		}
		StackFrame[] array = new StackFrame[_numOfFrames];
		Array.Copy(_stackFrames, _methodsToSkip, array, 0, _numOfFrames);
		return array;
	}

	public override string ToString()
	{
		return ToString(TraceFormat.TrailingNewLine);
	}

	internal string ToString(TraceFormat traceFormat)
	{
		StringBuilder stringBuilder = new StringBuilder(256);
		ToString(traceFormat, stringBuilder);
		return stringBuilder.ToString();
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "ToString is best effort when it comes to available information.")]
	internal void ToString(TraceFormat traceFormat, StringBuilder sb)
	{
		if (1 == 0)
		{
		}
		string value = "at";
		if (1 == 0)
		{
		}
		string format = "in {0}:line {1}";
		if (1 == 0)
		{
		}
		string format2 = "in {0}:token 0x{1:x}+0x{2:x}";
		bool flag = true;
		for (int i = 0; i < _numOfFrames; i++)
		{
			StackFrame frame = GetFrame(i);
			MethodBase method = frame?.GetMethod();
			if (!(method != null) || (!ShowInStackTrace(method) && i != _numOfFrames - 1))
			{
				continue;
			}
			if (flag)
			{
				flag = false;
			}
			else
			{
				sb.AppendLine();
			}
			sb.Append("   ").Append(value).Append(' ');
			bool flag2 = false;
			Type declaringType = method.DeclaringType;
			string name = method.Name;
			bool flag3 = false;
			if (declaringType != null && IsDefinedSafe(declaringType, typeof(CompilerGeneratedAttribute), inherit: false))
			{
				flag2 = declaringType.IsAssignableTo(typeof(IAsyncStateMachine));
				if (flag2 || declaringType.IsAssignableTo(typeof(IEnumerator)))
				{
					flag3 = TryResolveStateMachineMethod(ref method, out declaringType);
				}
			}
			if (declaringType != null)
			{
				string fullName = declaringType.FullName;
				foreach (char c in fullName)
				{
					sb.Append((c == '+') ? '.' : c);
				}
				sb.Append('.');
			}
			sb.Append(method.Name);
			if (method is MethodInfo { IsGenericMethod: not false } methodInfo)
			{
				Type[] genericArguments = methodInfo.GetGenericArguments();
				sb.Append('[');
				int k = 0;
				bool flag4 = true;
				for (; k < genericArguments.Length; k++)
				{
					if (!flag4)
					{
						sb.Append(',');
					}
					else
					{
						flag4 = false;
					}
					sb.Append(genericArguments[k].Name);
				}
				sb.Append(']');
			}
			ReadOnlySpan<ParameterInfo> readOnlySpan = default(ReadOnlySpan<ParameterInfo>);
			bool flag5 = true;
			try
			{
				readOnlySpan = method.GetParametersAsSpan();
			}
			catch
			{
				flag5 = false;
			}
			if (flag5)
			{
				sb.Append('(');
				bool flag6 = true;
				for (int l = 0; l < readOnlySpan.Length; l++)
				{
					if (!flag6)
					{
						sb.Append(", ");
					}
					else
					{
						flag6 = false;
					}
					string value2 = "<UnknownType>";
					if (readOnlySpan[l].ParameterType != null)
					{
						value2 = readOnlySpan[l].ParameterType.Name;
					}
					sb.Append(value2);
					string name2 = readOnlySpan[l].Name;
					if (name2 != null)
					{
						sb.Append(' ');
						sb.Append(name2);
					}
				}
				sb.Append(')');
			}
			if (flag3)
			{
				sb.Append('+');
				sb.Append(name);
				sb.Append('(').Append(')');
			}
			if (frame.GetILOffset() != -1)
			{
				string fileName = frame.GetFileName();
				if (fileName != null)
				{
					sb.Append(' ');
					sb.AppendFormat(CultureInfo.InvariantCulture, format, fileName, frame.GetFileLineNumber());
				}
				else if (LocalAppContextSwitches.ShowILOffsets && method.ReflectedType != null)
				{
					string scopeName = method.ReflectedType.Module.ScopeName;
					try
					{
						int metadataToken = method.MetadataToken;
						sb.Append(' ');
						sb.AppendFormat(CultureInfo.InvariantCulture, format2, scopeName, metadataToken, frame.GetILOffset());
					}
					catch (InvalidOperationException)
					{
					}
				}
			}
			if (frame.IsLastFrameFromForeignExceptionStackTrace && !flag2)
			{
				sb.AppendLine();
				if (1 == 0)
				{
				}
				sb.Append("--- End of stack trace from previous location ---");
			}
		}
		if (traceFormat == TraceFormat.TrailingNewLine)
		{
			sb.AppendLine();
		}
	}

	private static bool ShowInStackTrace(MethodBase mb)
	{
		if ((mb.MethodImplementationFlags & MethodImplAttributes.AggressiveInlining) != MethodImplAttributes.IL)
		{
			return false;
		}
		if (IsDefinedSafe(mb, typeof(StackTraceHiddenAttribute), inherit: false))
		{
			return false;
		}
		Type declaringType = mb.DeclaringType;
		if (declaringType != null && IsDefinedSafe(declaringType, typeof(StackTraceHiddenAttribute), inherit: false))
		{
			return false;
		}
		return true;
	}

	private static bool IsDefinedSafe(MemberInfo memberInfo, Type attributeType, bool inherit)
	{
		try
		{
			return memberInfo.IsDefined(attributeType, inherit);
		}
		catch
		{
			return false;
		}
	}

	private static Attribute[] GetCustomAttributesSafe(MemberInfo memberInfo, Type attributeType, bool inherit)
	{
		try
		{
			return Attribute.GetCustomAttributes(memberInfo, attributeType, inherit);
		}
		catch
		{
			return null;
		}
	}

	private static bool TryResolveStateMachineMethod(ref MethodBase method, out Type declaringType)
	{
		declaringType = method.DeclaringType;
		Type declaringType2 = declaringType.DeclaringType;
		if (declaringType2 == null)
		{
			return false;
		}
		MethodInfo[] array = GetDeclaredMethods(declaringType2);
		if (array == null)
		{
			return false;
		}
		MethodInfo[] array2 = array;
		foreach (MethodInfo methodInfo in array2)
		{
			StateMachineAttribute[] array3 = (StateMachineAttribute[])GetCustomAttributesSafe(methodInfo, typeof(StateMachineAttribute), inherit: false);
			if (array3 == null)
			{
				continue;
			}
			bool flag = false;
			bool flag2 = false;
			StateMachineAttribute[] array4 = array3;
			foreach (StateMachineAttribute stateMachineAttribute in array4)
			{
				if (stateMachineAttribute.StateMachineType == declaringType)
				{
					flag = true;
					flag2 = flag2 || stateMachineAttribute is IteratorStateMachineAttribute || stateMachineAttribute is AsyncIteratorStateMachineAttribute;
				}
			}
			if (flag)
			{
				method = methodInfo;
				declaringType = methodInfo.DeclaringType;
				return flag2;
			}
		}
		return false;
		[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2070:UnrecognizedReflectionPattern", Justification = "Using Reflection to find the state machine's corresponding method is safe because the corresponding method is the only caller of the state machine. If the state machine is present, the corresponding method will be, too.")]
		static MethodInfo[] GetDeclaredMethods(Type type)
		{
			return type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}
	}
}
