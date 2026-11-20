using System;
using System.ComponentModel;
using System.Globalization;

namespace Splat;

public abstract class AllocationFreeLoggerBase(ILogger inner) : IAllocationFreeLogger, IAllocationFreeErrorLogger, ILogger
{
	public LogLevel Level => inner.Level;

	public bool IsDebugEnabled => Level <= LogLevel.Debug;

	public bool IsInfoEnabled => Level <= LogLevel.Info;

	public bool IsWarnEnabled => Level <= LogLevel.Warn;

	public bool IsErrorEnabled => Level <= LogLevel.Error;

	public bool IsFatalEnabled => Level <= LogLevel.Fatal;

	public virtual void Debug<TArgument>([Localizable(false)] string messageFormat, TArgument argument)
	{
		if (IsDebugEnabled)
		{
			inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument), LogLevel.Debug);
		}
	}

	public virtual void Debug<TArgument>(Exception exception, string messageFormat, TArgument argument)
	{
		if (IsDebugEnabled)
		{
			inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument), LogLevel.Debug);
		}
	}

	public virtual void Debug<TArgument1, TArgument2>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2)
	{
		if (IsDebugEnabled)
		{
			inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2), LogLevel.Debug);
		}
	}

	public void Debug<TArgument1, TArgument2>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2)
	{
		if (IsDebugEnabled)
		{
			inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2), LogLevel.Debug);
		}
	}

	public virtual void Debug<TArgument1, TArgument2, TArgument3>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
	{
		if (IsDebugEnabled)
		{
			inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3), LogLevel.Debug);
		}
	}

	public void Debug<TArgument1, TArgument2, TArgument3>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
	{
		if (IsDebugEnabled)
		{
			inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3), LogLevel.Debug);
		}
	}

	public virtual void Debug<TArgument1, TArgument2, TArgument3, TArgument4>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4)
	{
		if (IsDebugEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			global::_003C_003Ey__InlineArray4<object> buffer = default(global::_003C_003Ey__InlineArray4<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 3) = argument4;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray4<object>, object>(in buffer, 4)), LogLevel.Debug);
		}
	}

	public void Debug<TArgument1, TArgument2, TArgument3, TArgument4>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4)
	{
		if (IsDebugEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			global::_003C_003Ey__InlineArray4<object> buffer = default(global::_003C_003Ey__InlineArray4<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 3) = argument4;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray4<object>, object>(in buffer, 4)), LogLevel.Debug);
		}
	}

	public virtual void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5)
	{
		if (IsDebugEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray5<object> buffer = default(_003C_003Ey__InlineArray5<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 4) = argument5;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray5<object>, object>(in buffer, 5)), LogLevel.Debug);
		}
	}

	public void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5)
	{
		if (IsDebugEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray5<object> buffer = default(_003C_003Ey__InlineArray5<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 4) = argument5;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray5<object>, object>(in buffer, 5)), LogLevel.Debug);
		}
	}

	public virtual void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6)
	{
		if (IsDebugEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray6<object> buffer = default(_003C_003Ey__InlineArray6<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 5) = argument6;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray6<object>, object>(in buffer, 6)), LogLevel.Debug);
		}
	}

	public void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6)
	{
		if (IsDebugEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray6<object> buffer = default(_003C_003Ey__InlineArray6<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 5) = argument6;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray6<object>, object>(in buffer, 6)), LogLevel.Debug);
		}
	}

	public virtual void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7)
	{
		if (IsDebugEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray7<object> buffer = default(_003C_003Ey__InlineArray7<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 6) = argument7;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray7<object>, object>(in buffer, 7)), LogLevel.Debug);
		}
	}

	public void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7)
	{
		if (IsDebugEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray7<object> buffer = default(_003C_003Ey__InlineArray7<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 6) = argument7;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray7<object>, object>(in buffer, 7)), LogLevel.Debug);
		}
	}

	public virtual void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8)
	{
		if (IsDebugEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			global::_003C_003Ey__InlineArray8<object> buffer = default(global::_003C_003Ey__InlineArray8<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 7) = argument8;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray8<object>, object>(in buffer, 8)), LogLevel.Debug);
		}
	}

	public void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8)
	{
		if (IsDebugEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			global::_003C_003Ey__InlineArray8<object> buffer = default(global::_003C_003Ey__InlineArray8<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 7) = argument8;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray8<object>, object>(in buffer, 8)), LogLevel.Debug);
		}
	}

	public virtual void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9)
	{
		if (IsDebugEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray9<object> buffer = default(_003C_003Ey__InlineArray9<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 7) = argument8;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 8) = argument9;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray9<object>, object>(in buffer, 9)), LogLevel.Debug);
		}
	}

	public void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9)
	{
		if (IsDebugEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray9<object> buffer = default(_003C_003Ey__InlineArray9<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 7) = argument8;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 8) = argument9;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray9<object>, object>(in buffer, 9)), LogLevel.Debug);
		}
	}

	public virtual void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10)
	{
		if (IsDebugEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray10<object> buffer = default(_003C_003Ey__InlineArray10<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 7) = argument8;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 8) = argument9;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 9) = argument10;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray10<object>, object>(in buffer, 10)), LogLevel.Debug);
		}
	}

	public void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10)
	{
		if (IsDebugEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray10<object> buffer = default(_003C_003Ey__InlineArray10<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 7) = argument8;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 8) = argument9;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 9) = argument10;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray10<object>, object>(in buffer, 10)), LogLevel.Debug);
		}
	}

	public virtual void Info<TArgument>([Localizable(false)] string messageFormat, TArgument argument)
	{
		if (IsInfoEnabled)
		{
			inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument), LogLevel.Info);
		}
	}

	public void Info<TArgument>(Exception exception, string messageFormat, TArgument argument)
	{
		if (IsInfoEnabled)
		{
			inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument), LogLevel.Info);
		}
	}

	public virtual void Info<TArgument1, TArgument2>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2)
	{
		if (IsInfoEnabled)
		{
			inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2), LogLevel.Info);
		}
	}

	public void Info<TArgument1, TArgument2>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2)
	{
		if (IsInfoEnabled)
		{
			inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2), LogLevel.Info);
		}
	}

	public virtual void Info<TArgument1, TArgument2, TArgument3>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
	{
		if (IsInfoEnabled)
		{
			inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3), LogLevel.Info);
		}
	}

	public void Info<TArgument1, TArgument2, TArgument3>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
	{
		if (IsInfoEnabled)
		{
			inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3), LogLevel.Info);
		}
	}

	public virtual void Info<TArgument1, TArgument2, TArgument3, TArgument4>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4)
	{
		if (IsInfoEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			global::_003C_003Ey__InlineArray4<object> buffer = default(global::_003C_003Ey__InlineArray4<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 3) = argument4;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray4<object>, object>(in buffer, 4)), LogLevel.Info);
		}
	}

	public void Info<TArgument1, TArgument2, TArgument3, TArgument4>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4)
	{
		if (IsInfoEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			global::_003C_003Ey__InlineArray4<object> buffer = default(global::_003C_003Ey__InlineArray4<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 3) = argument4;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray4<object>, object>(in buffer, 4)), LogLevel.Info);
		}
	}

	public virtual void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5)
	{
		if (IsInfoEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray5<object> buffer = default(_003C_003Ey__InlineArray5<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 4) = argument5;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray5<object>, object>(in buffer, 5)), LogLevel.Info);
		}
	}

	public void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5)
	{
		if (IsInfoEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray5<object> buffer = default(_003C_003Ey__InlineArray5<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 4) = argument5;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray5<object>, object>(in buffer, 5)), LogLevel.Info);
		}
	}

	public virtual void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6)
	{
		if (IsInfoEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray6<object> buffer = default(_003C_003Ey__InlineArray6<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 5) = argument6;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray6<object>, object>(in buffer, 6)), LogLevel.Info);
		}
	}

	public void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6)
	{
		if (IsInfoEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray6<object> buffer = default(_003C_003Ey__InlineArray6<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 5) = argument6;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray6<object>, object>(in buffer, 6)), LogLevel.Info);
		}
	}

	public virtual void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7)
	{
		if (IsInfoEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray7<object> buffer = default(_003C_003Ey__InlineArray7<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 6) = argument7;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray7<object>, object>(in buffer, 7)), LogLevel.Info);
		}
	}

	public void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7)
	{
		if (IsInfoEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray7<object> buffer = default(_003C_003Ey__InlineArray7<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 6) = argument7;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray7<object>, object>(in buffer, 7)), LogLevel.Info);
		}
	}

	public virtual void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8)
	{
		if (IsInfoEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			global::_003C_003Ey__InlineArray8<object> buffer = default(global::_003C_003Ey__InlineArray8<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 7) = argument8;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray8<object>, object>(in buffer, 8)), LogLevel.Info);
		}
	}

	public void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8)
	{
		if (IsInfoEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			global::_003C_003Ey__InlineArray8<object> buffer = default(global::_003C_003Ey__InlineArray8<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 7) = argument8;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray8<object>, object>(in buffer, 8)), LogLevel.Info);
		}
	}

	public virtual void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9)
	{
		if (IsInfoEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray9<object> buffer = default(_003C_003Ey__InlineArray9<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 7) = argument8;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 8) = argument9;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray9<object>, object>(in buffer, 9)), LogLevel.Info);
		}
	}

	public void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9)
	{
		if (IsInfoEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray9<object> buffer = default(_003C_003Ey__InlineArray9<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 7) = argument8;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 8) = argument9;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray9<object>, object>(in buffer, 9)), LogLevel.Info);
		}
	}

	public virtual void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10)
	{
		if (IsInfoEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray10<object> buffer = default(_003C_003Ey__InlineArray10<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 7) = argument8;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 8) = argument9;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 9) = argument10;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray10<object>, object>(in buffer, 10)), LogLevel.Info);
		}
	}

	public void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10)
	{
		if (IsInfoEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray10<object> buffer = default(_003C_003Ey__InlineArray10<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 7) = argument8;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 8) = argument9;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 9) = argument10;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray10<object>, object>(in buffer, 10)), LogLevel.Info);
		}
	}

	public virtual void Warn<TArgument>([Localizable(false)] string messageFormat, TArgument argument)
	{
		if (IsWarnEnabled)
		{
			inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument), LogLevel.Warn);
		}
	}

	public void Warn<TArgument>(Exception exception, string messageFormat, TArgument argument)
	{
		if (IsWarnEnabled)
		{
			inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument), LogLevel.Warn);
		}
	}

	public virtual void Warn<TArgument1, TArgument2>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2)
	{
		if (IsWarnEnabled)
		{
			inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2), LogLevel.Warn);
		}
	}

	public void Warn<TArgument1, TArgument2>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2)
	{
		if (IsWarnEnabled)
		{
			inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2), LogLevel.Warn);
		}
	}

	public virtual void Warn<TArgument1, TArgument2, TArgument3>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
	{
		if (IsWarnEnabled)
		{
			inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3), LogLevel.Warn);
		}
	}

	public void Warn<TArgument1, TArgument2, TArgument3>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
	{
		if (IsWarnEnabled)
		{
			inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3), LogLevel.Warn);
		}
	}

	public virtual void Warn<TArgument1, TArgument2, TArgument3, TArgument4>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4)
	{
		if (IsWarnEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			global::_003C_003Ey__InlineArray4<object> buffer = default(global::_003C_003Ey__InlineArray4<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 3) = argument4;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray4<object>, object>(in buffer, 4)), LogLevel.Warn);
		}
	}

	public void Warn<TArgument1, TArgument2, TArgument3, TArgument4>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4)
	{
		if (IsWarnEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			global::_003C_003Ey__InlineArray4<object> buffer = default(global::_003C_003Ey__InlineArray4<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 3) = argument4;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray4<object>, object>(in buffer, 4)), LogLevel.Warn);
		}
	}

	public virtual void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5)
	{
		if (IsWarnEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray5<object> buffer = default(_003C_003Ey__InlineArray5<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 4) = argument5;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray5<object>, object>(in buffer, 5)), LogLevel.Warn);
		}
	}

	public void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5)
	{
		if (IsWarnEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray5<object> buffer = default(_003C_003Ey__InlineArray5<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 4) = argument5;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray5<object>, object>(in buffer, 5)), LogLevel.Warn);
		}
	}

	public virtual void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6)
	{
		if (IsWarnEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray6<object> buffer = default(_003C_003Ey__InlineArray6<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 5) = argument6;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray6<object>, object>(in buffer, 6)), LogLevel.Warn);
		}
	}

	public void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6)
	{
		if (IsWarnEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray6<object> buffer = default(_003C_003Ey__InlineArray6<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 5) = argument6;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray6<object>, object>(in buffer, 6)), LogLevel.Warn);
		}
	}

	public virtual void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7)
	{
		if (IsWarnEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray7<object> buffer = default(_003C_003Ey__InlineArray7<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 6) = argument7;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray7<object>, object>(in buffer, 7)), LogLevel.Warn);
		}
	}

	public void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7)
	{
		if (IsWarnEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray7<object> buffer = default(_003C_003Ey__InlineArray7<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 6) = argument7;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray7<object>, object>(in buffer, 7)), LogLevel.Warn);
		}
	}

	public virtual void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8)
	{
		if (IsWarnEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			global::_003C_003Ey__InlineArray8<object> buffer = default(global::_003C_003Ey__InlineArray8<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 7) = argument8;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray8<object>, object>(in buffer, 8)), LogLevel.Warn);
		}
	}

	public void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8)
	{
		if (IsWarnEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			global::_003C_003Ey__InlineArray8<object> buffer = default(global::_003C_003Ey__InlineArray8<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 7) = argument8;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray8<object>, object>(in buffer, 8)), LogLevel.Warn);
		}
	}

	public virtual void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9)
	{
		if (IsWarnEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray9<object> buffer = default(_003C_003Ey__InlineArray9<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 7) = argument8;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 8) = argument9;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray9<object>, object>(in buffer, 9)), LogLevel.Warn);
		}
	}

	public void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9)
	{
		if (IsWarnEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray9<object> buffer = default(_003C_003Ey__InlineArray9<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 7) = argument8;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 8) = argument9;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray9<object>, object>(in buffer, 9)), LogLevel.Warn);
		}
	}

	public virtual void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10)
	{
		if (IsWarnEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray10<object> buffer = default(_003C_003Ey__InlineArray10<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 7) = argument8;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 8) = argument9;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 9) = argument10;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray10<object>, object>(in buffer, 10)), LogLevel.Warn);
		}
	}

	public void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10)
	{
		if (IsWarnEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray10<object> buffer = default(_003C_003Ey__InlineArray10<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 7) = argument8;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 8) = argument9;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 9) = argument10;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray10<object>, object>(in buffer, 10)), LogLevel.Warn);
		}
	}

	public virtual void Error<TArgument>([Localizable(false)] string messageFormat, TArgument argument)
	{
		if (IsErrorEnabled)
		{
			inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument), LogLevel.Error);
		}
	}

	public void Error<TArgument>(Exception exception, string messageFormat, TArgument argument)
	{
		if (IsErrorEnabled)
		{
			inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument), LogLevel.Error);
		}
	}

	public virtual void Error<TArgument1, TArgument2>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2)
	{
		if (IsErrorEnabled)
		{
			inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2), LogLevel.Error);
		}
	}

	public void Error<TArgument1, TArgument2>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2)
	{
		if (IsErrorEnabled)
		{
			inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2), LogLevel.Error);
		}
	}

	public virtual void Error<TArgument1, TArgument2, TArgument3>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
	{
		if (IsErrorEnabled)
		{
			inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3), LogLevel.Error);
		}
	}

	public void Error<TArgument1, TArgument2, TArgument3>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
	{
		if (IsErrorEnabled)
		{
			inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3), LogLevel.Error);
		}
	}

	public virtual void Error<TArgument1, TArgument2, TArgument3, TArgument4>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4)
	{
		if (IsErrorEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			global::_003C_003Ey__InlineArray4<object> buffer = default(global::_003C_003Ey__InlineArray4<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 3) = argument4;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray4<object>, object>(in buffer, 4)), LogLevel.Error);
		}
	}

	public void Error<TArgument1, TArgument2, TArgument3, TArgument4>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4)
	{
		if (IsErrorEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			global::_003C_003Ey__InlineArray4<object> buffer = default(global::_003C_003Ey__InlineArray4<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 3) = argument4;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray4<object>, object>(in buffer, 4)), LogLevel.Error);
		}
	}

	public virtual void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5)
	{
		if (IsErrorEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray5<object> buffer = default(_003C_003Ey__InlineArray5<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 4) = argument5;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray5<object>, object>(in buffer, 5)), LogLevel.Error);
		}
	}

	public void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5)
	{
		if (IsErrorEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray5<object> buffer = default(_003C_003Ey__InlineArray5<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 4) = argument5;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray5<object>, object>(in buffer, 5)), LogLevel.Error);
		}
	}

	public virtual void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6)
	{
		if (IsErrorEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray6<object> buffer = default(_003C_003Ey__InlineArray6<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 5) = argument6;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray6<object>, object>(in buffer, 6)), LogLevel.Error);
		}
	}

	public void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6)
	{
		if (IsErrorEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray6<object> buffer = default(_003C_003Ey__InlineArray6<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 5) = argument6;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray6<object>, object>(in buffer, 6)), LogLevel.Error);
		}
	}

	public virtual void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7)
	{
		if (IsErrorEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray7<object> buffer = default(_003C_003Ey__InlineArray7<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 6) = argument7;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray7<object>, object>(in buffer, 7)), LogLevel.Error);
		}
	}

	public void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7)
	{
		if (IsErrorEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray7<object> buffer = default(_003C_003Ey__InlineArray7<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 6) = argument7;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray7<object>, object>(in buffer, 7)), LogLevel.Error);
		}
	}

	public virtual void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8)
	{
		if (IsErrorEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			global::_003C_003Ey__InlineArray8<object> buffer = default(global::_003C_003Ey__InlineArray8<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 7) = argument8;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray8<object>, object>(in buffer, 8)), LogLevel.Error);
		}
	}

	public void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8)
	{
		if (IsErrorEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			global::_003C_003Ey__InlineArray8<object> buffer = default(global::_003C_003Ey__InlineArray8<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 7) = argument8;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray8<object>, object>(in buffer, 8)), LogLevel.Error);
		}
	}

	public virtual void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9)
	{
		if (IsErrorEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray9<object> buffer = default(_003C_003Ey__InlineArray9<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 7) = argument8;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 8) = argument9;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray9<object>, object>(in buffer, 9)), LogLevel.Error);
		}
	}

	public void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9)
	{
		if (IsErrorEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray9<object> buffer = default(_003C_003Ey__InlineArray9<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 7) = argument8;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 8) = argument9;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray9<object>, object>(in buffer, 9)), LogLevel.Error);
		}
	}

	public virtual void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10)
	{
		if (IsErrorEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray10<object> buffer = default(_003C_003Ey__InlineArray10<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 7) = argument8;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 8) = argument9;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 9) = argument10;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray10<object>, object>(in buffer, 10)), LogLevel.Error);
		}
	}

	public void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10)
	{
		if (IsErrorEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray10<object> buffer = default(_003C_003Ey__InlineArray10<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 7) = argument8;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 8) = argument9;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 9) = argument10;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray10<object>, object>(in buffer, 10)), LogLevel.Error);
		}
	}

	public virtual void Fatal<TArgument>([Localizable(false)] string messageFormat, TArgument argument)
	{
		if (IsFatalEnabled)
		{
			inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument), LogLevel.Fatal);
		}
	}

	public void Fatal<TArgument>(Exception exception, string messageFormat, TArgument argument)
	{
		if (IsFatalEnabled)
		{
			inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument), LogLevel.Fatal);
		}
	}

	public virtual void Fatal<TArgument1, TArgument2>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2)
	{
		if (IsFatalEnabled)
		{
			inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2), LogLevel.Fatal);
		}
	}

	public void Fatal<TArgument1, TArgument2>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2)
	{
		if (IsFatalEnabled)
		{
			inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2), LogLevel.Fatal);
		}
	}

	public virtual void Fatal<TArgument1, TArgument2, TArgument3>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
	{
		if (IsFatalEnabled)
		{
			inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3), LogLevel.Fatal);
		}
	}

	public void Fatal<TArgument1, TArgument2, TArgument3>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
	{
		if (IsFatalEnabled)
		{
			inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3), LogLevel.Fatal);
		}
	}

	public virtual void Fatal<TArgument1, TArgument2, TArgument3, TArgument4>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4)
	{
		if (IsFatalEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			global::_003C_003Ey__InlineArray4<object> buffer = default(global::_003C_003Ey__InlineArray4<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 3) = argument4;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray4<object>, object>(in buffer, 4)), LogLevel.Fatal);
		}
	}

	public void Fatal<TArgument1, TArgument2, TArgument3, TArgument4>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4)
	{
		if (IsFatalEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			global::_003C_003Ey__InlineArray4<object> buffer = default(global::_003C_003Ey__InlineArray4<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 3) = argument4;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray4<object>, object>(in buffer, 4)), LogLevel.Fatal);
		}
	}

	public virtual void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5)
	{
		if (IsFatalEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray5<object> buffer = default(_003C_003Ey__InlineArray5<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 4) = argument5;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray5<object>, object>(in buffer, 5)), LogLevel.Fatal);
		}
	}

	public void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5)
	{
		if (IsFatalEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray5<object> buffer = default(_003C_003Ey__InlineArray5<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 4) = argument5;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray5<object>, object>(in buffer, 5)), LogLevel.Fatal);
		}
	}

	public virtual void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6)
	{
		if (IsFatalEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray6<object> buffer = default(_003C_003Ey__InlineArray6<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 5) = argument6;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray6<object>, object>(in buffer, 6)), LogLevel.Fatal);
		}
	}

	public void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6)
	{
		if (IsFatalEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray6<object> buffer = default(_003C_003Ey__InlineArray6<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<object>, object>(ref buffer, 5) = argument6;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray6<object>, object>(in buffer, 6)), LogLevel.Fatal);
		}
	}

	public virtual void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7)
	{
		if (IsFatalEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray7<object> buffer = default(_003C_003Ey__InlineArray7<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 6) = argument7;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray7<object>, object>(in buffer, 7)), LogLevel.Fatal);
		}
	}

	public void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7)
	{
		if (IsFatalEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray7<object> buffer = default(_003C_003Ey__InlineArray7<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 6) = argument7;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray7<object>, object>(in buffer, 7)), LogLevel.Fatal);
		}
	}

	public virtual void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8)
	{
		if (IsFatalEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			global::_003C_003Ey__InlineArray8<object> buffer = default(global::_003C_003Ey__InlineArray8<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 7) = argument8;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray8<object>, object>(in buffer, 8)), LogLevel.Fatal);
		}
	}

	public void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8)
	{
		if (IsFatalEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			global::_003C_003Ey__InlineArray8<object> buffer = default(global::_003C_003Ey__InlineArray8<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray8<object>, object>(ref buffer, 7) = argument8;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray8<object>, object>(in buffer, 8)), LogLevel.Fatal);
		}
	}

	public virtual void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9)
	{
		if (IsFatalEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray9<object> buffer = default(_003C_003Ey__InlineArray9<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 7) = argument8;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 8) = argument9;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray9<object>, object>(in buffer, 9)), LogLevel.Fatal);
		}
	}

	public void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9)
	{
		if (IsFatalEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray9<object> buffer = default(_003C_003Ey__InlineArray9<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 7) = argument8;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 8) = argument9;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray9<object>, object>(in buffer, 9)), LogLevel.Fatal);
		}
	}

	public virtual void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10)
	{
		if (IsFatalEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray10<object> buffer = default(_003C_003Ey__InlineArray10<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 7) = argument8;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 8) = argument9;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 9) = argument10;
			logger.Write(string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray10<object>, object>(in buffer, 10)), LogLevel.Fatal);
		}
	}

	public void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10)
	{
		if (IsFatalEnabled)
		{
			ILogger logger = inner;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			_003C_003Ey__InlineArray10<object> buffer = default(_003C_003Ey__InlineArray10<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 0) = argument1;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 1) = argument2;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 2) = argument3;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 3) = argument4;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 4) = argument5;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 5) = argument6;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 6) = argument7;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 7) = argument8;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 8) = argument9;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<object>, object>(ref buffer, 9) = argument10;
			logger.Write(exception, string.Format(invariantCulture, messageFormat, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray10<object>, object>(in buffer, 10)), LogLevel.Fatal);
		}
	}

	public void Write([Localizable(false)] string message, LogLevel logLevel)
	{
		inner.Write(message, logLevel);
	}

	public void Write(Exception exception, [Localizable(false)] string message, LogLevel logLevel)
	{
		inner.Write(exception, message, logLevel);
	}

	public void Write([Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
	{
		inner.Write(message, type, logLevel);
	}

	public void Write(Exception exception, [Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
	{
		inner.Write(exception, message, type, logLevel);
	}
}
