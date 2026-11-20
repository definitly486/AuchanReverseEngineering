using System;
using System.ComponentModel;

namespace Splat;

public interface IAllocationFreeErrorLogger : ILogger
{
	void Debug<TArgument>(Exception exception, [Localizable(false)] string messageFormat, TArgument argument);

	void Debug<TArgument1, TArgument2>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2);

	void Debug<TArgument1, TArgument2, TArgument3>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3);

	void Debug<TArgument1, TArgument2, TArgument3, TArgument4>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4);

	void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5);

	void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6);

	void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7);

	void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8);

	void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9);

	void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10);

	void Info<TArgument>(Exception exception, [Localizable(false)] string messageFormat, TArgument argument);

	void Info<TArgument1, TArgument2>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2);

	void Info<TArgument1, TArgument2, TArgument3>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3);

	void Info<TArgument1, TArgument2, TArgument3, TArgument4>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4);

	void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5);

	void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6);

	void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7);

	void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8);

	void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9);

	void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10);

	void Warn<TArgument>(Exception exception, [Localizable(false)] string messageFormat, TArgument argument);

	void Warn<TArgument1, TArgument2>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2);

	void Warn<TArgument1, TArgument2, TArgument3>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3);

	void Warn<TArgument1, TArgument2, TArgument3, TArgument4>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4);

	void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5);

	void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6);

	void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7);

	void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8);

	void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9);

	void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10);

	void Error<TArgument>(Exception exception, [Localizable(false)] string messageFormat, TArgument argument);

	void Error<TArgument1, TArgument2>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2);

	void Error<TArgument1, TArgument2, TArgument3>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3);

	void Error<TArgument1, TArgument2, TArgument3, TArgument4>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4);

	void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5);

	void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6);

	void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7);

	void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8);

	void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9);

	void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10);

	void Fatal<TArgument>(Exception exception, [Localizable(false)] string messageFormat, TArgument argument);

	void Fatal<TArgument1, TArgument2>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2);

	void Fatal<TArgument1, TArgument2, TArgument3>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3);

	void Fatal<TArgument1, TArgument2, TArgument3, TArgument4>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4);

	void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5);

	void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6);

	void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7);

	void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8);

	void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9);

	void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10);
}
