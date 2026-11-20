using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Serialization;
using System.Threading;

namespace System;

[StackTraceHidden]
internal static class ThrowHelper
{
	[DoesNotReturn]
	internal static void ThrowArithmeticException(string message)
	{
		throw new ArithmeticException(message);
	}

	[DoesNotReturn]
	internal static void ThrowAccessViolationException()
	{
		throw new AccessViolationException();
	}

	[DoesNotReturn]
	internal static void ThrowArrayTypeMismatchException()
	{
		throw new ArrayTypeMismatchException();
	}

	[DoesNotReturn]
	internal static void ThrowInvalidTypeWithPointersNotSupported(Type targetType)
	{
		throw new ArgumentException(SR.Format("Argument_InvalidTypeWithPointersNotSupported", targetType));
	}

	[DoesNotReturn]
	internal static void ThrowIndexOutOfRangeException()
	{
		throw new IndexOutOfRangeException();
	}

	[DoesNotReturn]
	internal static void ThrowArgumentOutOfRangeException()
	{
		throw new ArgumentOutOfRangeException();
	}

	[DoesNotReturn]
	internal static void ThrowArgumentException_DestinationTooShort()
	{
		throw new ArgumentException("Argument_DestinationTooShort", "destination");
	}

	[DoesNotReturn]
	internal static void ThrowArgumentException_InvalidTimeSpanStyles()
	{
		throw new ArgumentException("Argument_InvalidTimeSpanStyles", "styles");
	}

	[DoesNotReturn]
	internal static void ThrowArgumentException_InvalidEnumValue<TEnum>(TEnum value, [CallerArgumentExpression("value")] string argumentName = "")
	{
		throw new ArgumentException(SR.Format("Argument_InvalidEnumValue", value, typeof(TEnum).Name), argumentName);
	}

	[DoesNotReturn]
	internal static void ThrowArgumentException_OverlapAlignmentMismatch()
	{
		throw new ArgumentException("Argument_OverlapAlignmentMismatch");
	}

	[DoesNotReturn]
	internal static void ThrowArgumentException_CannotExtractScalar(ExceptionArgument argument)
	{
		throw GetArgumentException(ExceptionResource.Argument_CannotExtractScalar, argument);
	}

	[DoesNotReturn]
	internal static void ThrowArgumentException_TupleIncorrectType(object obj)
	{
		throw new ArgumentException(SR.Format("ArgumentException_ValueTupleIncorrectType", obj.GetType()), "other");
	}

	[DoesNotReturn]
	internal static void ThrowArgumentOutOfRange_IndexMustBeLessException()
	{
		throw GetArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_IndexMustBeLess);
	}

	[DoesNotReturn]
	internal static void ThrowArgumentOutOfRange_IndexMustBeLessOrEqualException()
	{
		throw GetArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_IndexMustBeLessOrEqual);
	}

	[DoesNotReturn]
	internal static void ThrowArgumentException_BadComparer(object comparer)
	{
		throw new ArgumentException(SR.Format("Arg_BogusIComparer", comparer));
	}

	[DoesNotReturn]
	internal static void ThrowIndexArgumentOutOfRange_NeedNonNegNumException()
	{
		throw GetArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
	}

	[DoesNotReturn]
	internal static void ThrowValueArgumentOutOfRange_NeedNonNegNumException()
	{
		throw GetArgumentOutOfRangeException(ExceptionArgument.value, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
	}

	[DoesNotReturn]
	internal static void ThrowLengthArgumentOutOfRange_ArgumentOutOfRange_NeedNonNegNum()
	{
		throw GetArgumentOutOfRangeException(ExceptionArgument.length, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
	}

	[DoesNotReturn]
	internal static void ThrowStartIndexArgumentOutOfRange_ArgumentOutOfRange_IndexMustBeLessOrEqual()
	{
		throw GetArgumentOutOfRangeException(ExceptionArgument.startIndex, ExceptionResource.ArgumentOutOfRange_IndexMustBeLessOrEqual);
	}

	[DoesNotReturn]
	internal static void ThrowStartIndexArgumentOutOfRange_ArgumentOutOfRange_IndexMustBeLess()
	{
		throw GetArgumentOutOfRangeException(ExceptionArgument.startIndex, ExceptionResource.ArgumentOutOfRange_IndexMustBeLess);
	}

	[DoesNotReturn]
	internal static void ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count()
	{
		throw GetArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_Count);
	}

	[DoesNotReturn]
	internal static void ThrowArgumentOutOfRange_Year()
	{
		throw GetArgumentOutOfRangeException(ExceptionArgument.year, ExceptionResource.ArgumentOutOfRange_Year);
	}

	[DoesNotReturn]
	internal static void ThrowArgumentOutOfRange_Month(int month)
	{
		throw new ArgumentOutOfRangeException("month", month, "ArgumentOutOfRange_Month");
	}

	[DoesNotReturn]
	internal static void ThrowArgumentOutOfRange_DayNumber(int dayNumber)
	{
		throw new ArgumentOutOfRangeException("dayNumber", dayNumber, "ArgumentOutOfRange_DayNumber");
	}

	[DoesNotReturn]
	internal static void ThrowArgumentOutOfRange_BadYearMonthDay()
	{
		throw new ArgumentOutOfRangeException(null, "ArgumentOutOfRange_BadYearMonthDay");
	}

	[DoesNotReturn]
	internal static void ThrowArgumentOutOfRange_BadHourMinuteSecond()
	{
		throw new ArgumentOutOfRangeException(null, "ArgumentOutOfRange_BadHourMinuteSecond");
	}

	[DoesNotReturn]
	internal static void ThrowArgumentOutOfRange_TimeSpanTooLong()
	{
		throw new ArgumentOutOfRangeException(null, "Overflow_TimeSpanTooLong");
	}

	[DoesNotReturn]
	internal static void ThrowArgumentOutOfRange_RoundingDigits(string name)
	{
		throw new ArgumentOutOfRangeException(name, "ArgumentOutOfRange_RoundingDigits");
	}

	[DoesNotReturn]
	internal static void ThrowArgumentOutOfRange_RoundingDigits_MathF(string name)
	{
		throw new ArgumentOutOfRangeException(name, "ArgumentOutOfRange_RoundingDigits_MathF");
	}

	[DoesNotReturn]
	internal static void ThrowArgumentOutOfRange_Range<T>(string parameterName, T value, T minInclusive, T maxInclusive)
	{
		throw new ArgumentOutOfRangeException(parameterName, value, SR.Format("ArgumentOutOfRange_Range", minInclusive, maxInclusive));
	}

	[DoesNotReturn]
	internal static void ThrowOverflowException()
	{
		throw new OverflowException();
	}

	[DoesNotReturn]
	internal static void ThrowOverflowException_NegateTwosCompNum()
	{
		throw new OverflowException("Overflow_NegateTwosCompNum");
	}

	[DoesNotReturn]
	internal static void ThrowOverflowException_TimeSpanTooLong()
	{
		throw new OverflowException("Overflow_TimeSpanTooLong");
	}

	[DoesNotReturn]
	internal static void ThrowOverflowException_TimeSpanDuration()
	{
		throw new OverflowException("Overflow_Duration");
	}

	[DoesNotReturn]
	internal static void ThrowArgumentException_Arg_CannotBeNaN()
	{
		throw new ArgumentException("Arg_CannotBeNaN");
	}

	[DoesNotReturn]
	internal static void ThrowArgumentException_Arg_CannotBeNaN(ExceptionArgument argument)
	{
		throw new ArgumentException("Arg_CannotBeNaN", GetArgumentName(argument));
	}

	[DoesNotReturn]
	internal static void ThrowWrongKeyTypeArgumentException<T>(T key, Type targetType)
	{
		throw GetWrongKeyTypeArgumentException(key, targetType);
	}

	[DoesNotReturn]
	internal static void ThrowWrongValueTypeArgumentException<T>(T value, Type targetType)
	{
		throw GetWrongValueTypeArgumentException(value, targetType);
	}

	private static ArgumentException GetAddingDuplicateWithKeyArgumentException(object key)
	{
		return new ArgumentException(SR.Format("Argument_AddingDuplicateWithKey", key));
	}

	[DoesNotReturn]
	internal static void ThrowAddingDuplicateWithKeyArgumentException<T>(T key)
	{
		throw GetAddingDuplicateWithKeyArgumentException(key);
	}

	[DoesNotReturn]
	internal static void ThrowKeyNotFoundException<T>(T key)
	{
		throw GetKeyNotFoundException(key);
	}

	[DoesNotReturn]
	internal static void ThrowArgumentException(ExceptionResource resource)
	{
		throw GetArgumentException(resource);
	}

	[DoesNotReturn]
	internal static void ThrowArgumentException(ExceptionResource resource, ExceptionArgument argument)
	{
		throw GetArgumentException(resource, argument);
	}

	[DoesNotReturn]
	internal static void ThrowArgumentException_HandleNotSync(string paramName)
	{
		throw new ArgumentException("Arg_HandleNotSync", paramName);
	}

	[DoesNotReturn]
	internal static void ThrowArgumentException_HandleNotAsync(string paramName)
	{
		throw new ArgumentException("Arg_HandleNotAsync", paramName);
	}

	[DoesNotReturn]
	internal static void ThrowArgumentNullException(ExceptionArgument argument)
	{
		throw new ArgumentNullException(GetArgumentName(argument));
	}

	[DoesNotReturn]
	internal static void ThrowArgumentNullException(ExceptionArgument argument, ExceptionResource resource)
	{
		throw new ArgumentNullException(GetArgumentName(argument), GetResourceString(resource));
	}

	[DoesNotReturn]
	internal static void ThrowArgumentOutOfRangeException(ExceptionArgument argument)
	{
		throw new ArgumentOutOfRangeException(GetArgumentName(argument));
	}

	[DoesNotReturn]
	internal static void ThrowArgumentOutOfRangeException(ExceptionArgument argument, ExceptionResource resource)
	{
		throw GetArgumentOutOfRangeException(argument, resource);
	}

	[DoesNotReturn]
	internal static void ThrowArgumentOutOfRangeException(ExceptionArgument argument, int paramNumber, ExceptionResource resource)
	{
		throw GetArgumentOutOfRangeException(argument, paramNumber, resource);
	}

	[DoesNotReturn]
	internal static void ThrowEndOfFileException()
	{
		throw CreateEndOfFileException();
	}

	internal static Exception CreateEndOfFileException()
	{
		return new EndOfStreamException("IO_EOF_ReadBeyondEOF");
	}

	[DoesNotReturn]
	internal static void ThrowInvalidOperationException()
	{
		throw new InvalidOperationException();
	}

	[DoesNotReturn]
	internal static void ThrowInvalidOperationException(ExceptionResource resource)
	{
		throw GetInvalidOperationException(resource);
	}

	[DoesNotReturn]
	internal static void ThrowInvalidOperationException(ExceptionResource resource, Exception e)
	{
		throw new InvalidOperationException(GetResourceString(resource), e);
	}

	[DoesNotReturn]
	internal static void ThrowSerializationException(ExceptionResource resource)
	{
		throw new SerializationException(GetResourceString(resource));
	}

	[DoesNotReturn]
	internal static void ThrowRankException(ExceptionResource resource)
	{
		throw new RankException(GetResourceString(resource));
	}

	[DoesNotReturn]
	internal static void ThrowNotSupportedException(ExceptionResource resource)
	{
		throw new NotSupportedException(GetResourceString(resource));
	}

	[DoesNotReturn]
	internal static void ThrowNotSupportedException_UnseekableStream()
	{
		throw new NotSupportedException("NotSupported_UnseekableStream");
	}

	[DoesNotReturn]
	internal static void ThrowNotSupportedException_UnreadableStream()
	{
		throw new NotSupportedException("NotSupported_UnreadableStream");
	}

	[DoesNotReturn]
	internal static void ThrowNotSupportedException_UnwritableStream()
	{
		throw new NotSupportedException("NotSupported_UnwritableStream");
	}

	[DoesNotReturn]
	internal static void ThrowObjectDisposedException(object instance)
	{
		throw new ObjectDisposedException(instance?.GetType().FullName);
	}

	[DoesNotReturn]
	internal static void ThrowObjectDisposedException(Type type)
	{
		throw new ObjectDisposedException(type?.FullName);
	}

	[DoesNotReturn]
	internal static void ThrowObjectDisposedException_StreamClosed(string objectName)
	{
		throw new ObjectDisposedException(objectName, "ObjectDisposed_StreamClosed");
	}

	[DoesNotReturn]
	internal static void ThrowObjectDisposedException_FileClosed()
	{
		throw new ObjectDisposedException(null, "ObjectDisposed_FileClosed");
	}

	[DoesNotReturn]
	internal static void ThrowObjectDisposedException(ExceptionResource resource)
	{
		throw new ObjectDisposedException(null, GetResourceString(resource));
	}

	[DoesNotReturn]
	internal static void ThrowNotSupportedException()
	{
		throw new NotSupportedException();
	}

	[DoesNotReturn]
	internal static void ThrowAggregateException(List<Exception> exceptions)
	{
		throw new AggregateException(exceptions);
	}

	[DoesNotReturn]
	internal static void ThrowOutOfMemoryException()
	{
		throw new OutOfMemoryException();
	}

	[DoesNotReturn]
	internal static void ThrowDivideByZeroException()
	{
		throw new DivideByZeroException();
	}

	[DoesNotReturn]
	internal static void ThrowOutOfMemoryException_StringTooLong()
	{
		throw new OutOfMemoryException("OutOfMemory_StringTooLong");
	}

	[DoesNotReturn]
	internal static void ThrowOutOfMemoryException_LockEnter_WaiterCountOverflow()
	{
		throw new OutOfMemoryException("Lock_Enter_WaiterCountOverflow_OutOfMemoryException");
	}

	[DoesNotReturn]
	internal static void ThrowArgumentException_Argument_IncompatibleArrayType()
	{
		throw new ArgumentException("Argument_IncompatibleArrayType");
	}

	[DoesNotReturn]
	internal static void ThrowArgumentException_InvalidHandle(string paramName)
	{
		throw new ArgumentException("Arg_InvalidHandle", paramName);
	}

	[DoesNotReturn]
	internal static void ThrowUnexpectedStateForKnownCallback(object state)
	{
		throw new ArgumentOutOfRangeException("state", state, "Argument_UnexpectedStateForKnownCallback");
	}

	[DoesNotReturn]
	internal static void ThrowInvalidOperationException_InvalidOperation_EnumNotStarted()
	{
		throw new InvalidOperationException("InvalidOperation_EnumNotStarted");
	}

	[DoesNotReturn]
	internal static void ThrowInvalidOperationException_InvalidOperation_EnumEnded()
	{
		throw new InvalidOperationException("InvalidOperation_EnumEnded");
	}

	[DoesNotReturn]
	internal static void ThrowInvalidOperationException_EnumCurrent(int index)
	{
		throw GetInvalidOperationException_EnumCurrent(index);
	}

	[DoesNotReturn]
	internal static void ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion()
	{
		throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
	}

	[DoesNotReturn]
	internal static void ThrowInvalidOperationException_InvalidOperation_EnumOpCantHappen()
	{
		throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
	}

	[DoesNotReturn]
	internal static void ThrowInvalidOperationException_InvalidOperation_NoValue()
	{
		throw new InvalidOperationException("InvalidOperation_NoValue");
	}

	[DoesNotReturn]
	internal static void ThrowInvalidOperationException_ConcurrentOperationsNotSupported()
	{
		throw new InvalidOperationException("InvalidOperation_ConcurrentOperationsNotSupported");
	}

	[DoesNotReturn]
	internal static void ThrowInvalidOperationException_HandleIsNotInitialized()
	{
		throw new InvalidOperationException("InvalidOperation_HandleIsNotInitialized");
	}

	[DoesNotReturn]
	internal static void ThrowInvalidOperationException_HandleIsNotPinned()
	{
		throw new InvalidOperationException("InvalidOperation_HandleIsNotPinned");
	}

	[DoesNotReturn]
	internal static void ThrowArraySegmentCtorValidationFailedExceptions(Array array, int offset, int count)
	{
		throw GetArraySegmentCtorValidationFailedException(array, offset, count);
	}

	[DoesNotReturn]
	internal static void ThrowInvalidOperationException_InvalidUtf8()
	{
		throw new InvalidOperationException("InvalidOperation_InvalidUtf8");
	}

	[DoesNotReturn]
	internal static void ThrowFormatException_BadFormatSpecifier()
	{
		throw new FormatException("Argument_BadFormatSpecifier");
	}

	[DoesNotReturn]
	internal static void ThrowFormatException_BadHexChar()
	{
		throw new FormatException("Format_BadHexChar");
	}

	[DoesNotReturn]
	internal static void ThrowFormatException_BadHexLength()
	{
		throw new FormatException("Format_BadHexLength");
	}

	[DoesNotReturn]
	internal static void ThrowFormatException_NeedSingleChar()
	{
		throw new FormatException("Format_NeedSingleChar");
	}

	[DoesNotReturn]
	internal static void ThrowFormatException_BadBoolean(ReadOnlySpan<char> value)
	{
		throw new FormatException(SR.Format("Format_BadBoolean", new string(value)));
	}

	[DoesNotReturn]
	internal static void ThrowArgumentOutOfRangeException_PrecisionTooLarge()
	{
		throw new ArgumentOutOfRangeException("precision", SR.Format("Argument_PrecisionTooLarge", (byte)99));
	}

	[DoesNotReturn]
	internal static void ThrowArgumentOutOfRangeException_SymbolDoesNotFit()
	{
		throw new ArgumentOutOfRangeException("symbol", "Argument_BadFormatSpecifier");
	}

	[DoesNotReturn]
	internal static void ThrowArgumentOutOfRangeException_NeedNonNegNum(string paramName)
	{
		throw new ArgumentOutOfRangeException(paramName, "ArgumentOutOfRange_NeedNonNegNum");
	}

	[DoesNotReturn]
	internal static void ArgumentOutOfRangeException_Enum_Value()
	{
		throw new ArgumentOutOfRangeException("value", "ArgumentOutOfRange_Enum");
	}

	[DoesNotReturn]
	internal static void ThrowFormatInvalidString()
	{
		throw new FormatException("Format_InvalidString");
	}

	[DoesNotReturn]
	internal static void ThrowFormatInvalidString(int offset, ExceptionResource resource)
	{
		throw new FormatException(SR.Format("Format_InvalidStringWithOffsetAndReason", offset, GetResourceString(resource)));
	}

	[DoesNotReturn]
	internal static void ThrowFormatIndexOutOfRange()
	{
		throw new FormatException("Format_IndexOutOfRange");
	}

	[DoesNotReturn]
	internal static void ThrowSynchronizationLockException_LockExit()
	{
		throw new SynchronizationLockException("Lock_Exit_SynchronizationLockException");
	}

	internal static AmbiguousMatchException GetAmbiguousMatchException(MemberInfo memberInfo)
	{
		Type declaringType = memberInfo.DeclaringType;
		return new AmbiguousMatchException(SR.Format("Arg_AmbiguousMatchException_MemberInfo", declaringType, memberInfo));
	}

	internal static AmbiguousMatchException GetAmbiguousMatchException(Attribute attribute)
	{
		return new AmbiguousMatchException(SR.Format("Arg_AmbiguousMatchException_Attribute", attribute));
	}

	private static Exception GetArraySegmentCtorValidationFailedException(Array array, int offset, int count)
	{
		if (array == null)
		{
			return new ArgumentNullException("array");
		}
		if (offset < 0)
		{
			return new ArgumentOutOfRangeException("offset", "ArgumentOutOfRange_NeedNonNegNum");
		}
		if (count < 0)
		{
			return new ArgumentOutOfRangeException("count", "ArgumentOutOfRange_NeedNonNegNum");
		}
		return new ArgumentException("Argument_InvalidOffLen");
	}

	private static ArgumentException GetArgumentException(ExceptionResource resource)
	{
		return new ArgumentException(GetResourceString(resource));
	}

	private static InvalidOperationException GetInvalidOperationException(ExceptionResource resource)
	{
		return new InvalidOperationException(GetResourceString(resource));
	}

	private static ArgumentException GetWrongKeyTypeArgumentException(object key, Type targetType)
	{
		return new ArgumentException(SR.Format("Arg_WrongType", key, targetType), "key");
	}

	private static ArgumentException GetWrongValueTypeArgumentException(object value, Type targetType)
	{
		return new ArgumentException(SR.Format("Arg_WrongType", value, targetType), "value");
	}

	private static KeyNotFoundException GetKeyNotFoundException(object key)
	{
		return new KeyNotFoundException(SR.Format("Arg_KeyNotFoundWithKey", key));
	}

	private static ArgumentOutOfRangeException GetArgumentOutOfRangeException(ExceptionArgument argument, ExceptionResource resource)
	{
		return new ArgumentOutOfRangeException(GetArgumentName(argument), GetResourceString(resource));
	}

	private static ArgumentException GetArgumentException(ExceptionResource resource, ExceptionArgument argument)
	{
		return new ArgumentException(GetResourceString(resource), GetArgumentName(argument));
	}

	private static ArgumentOutOfRangeException GetArgumentOutOfRangeException(ExceptionArgument argument, int paramNumber, ExceptionResource resource)
	{
		return new ArgumentOutOfRangeException(GetArgumentName(argument) + "[" + paramNumber + "]", GetResourceString(resource));
	}

	private static InvalidOperationException GetInvalidOperationException_EnumCurrent(int index)
	{
		return new InvalidOperationException((index < 0) ? "InvalidOperation_EnumNotStarted" : "InvalidOperation_EnumEnded");
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static void IfNullAndNullsAreIllegalThenThrow<T>(object value, ExceptionArgument argName)
	{
		if (default(T) != null && value == null)
		{
			ThrowArgumentNullException(argName);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static void ThrowForUnsupportedNumericsVectorBaseType<T>()
	{
		if (!Vector<T>.IsSupported)
		{
			ThrowNotSupportedException(ExceptionResource.Arg_TypeNotSupported);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static void ThrowForUnsupportedIntrinsicsVector64BaseType<T>()
	{
		if (!Vector64<T>.IsSupported)
		{
			ThrowNotSupportedException(ExceptionResource.Arg_TypeNotSupported);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static void ThrowForUnsupportedIntrinsicsVector128BaseType<T>()
	{
		if (!Vector128<T>.IsSupported)
		{
			ThrowNotSupportedException(ExceptionResource.Arg_TypeNotSupported);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static void ThrowForUnsupportedIntrinsicsVector256BaseType<T>()
	{
		if (!Vector256<T>.IsSupported)
		{
			ThrowNotSupportedException(ExceptionResource.Arg_TypeNotSupported);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static void ThrowForUnsupportedIntrinsicsVector512BaseType<T>()
	{
		if (!Vector512<T>.IsSupported)
		{
			ThrowNotSupportedException(ExceptionResource.Arg_TypeNotSupported);
		}
	}

	private static string GetArgumentName(ExceptionArgument argument)
	{
		return argument switch
		{
			ExceptionArgument.obj => "obj", 
			ExceptionArgument.dictionary => "dictionary", 
			ExceptionArgument.array => "array", 
			ExceptionArgument.info => "info", 
			ExceptionArgument.key => "key", 
			ExceptionArgument.text => "text", 
			ExceptionArgument.values => "values", 
			ExceptionArgument.value => "value", 
			ExceptionArgument.startIndex => "startIndex", 
			ExceptionArgument.task => "task", 
			ExceptionArgument.bytes => "bytes", 
			ExceptionArgument.byteIndex => "byteIndex", 
			ExceptionArgument.byteCount => "byteCount", 
			ExceptionArgument.ch => "ch", 
			ExceptionArgument.chars => "chars", 
			ExceptionArgument.charIndex => "charIndex", 
			ExceptionArgument.charCount => "charCount", 
			ExceptionArgument.s => "s", 
			ExceptionArgument.input => "input", 
			ExceptionArgument.ownedMemory => "ownedMemory", 
			ExceptionArgument.list => "list", 
			ExceptionArgument.index => "index", 
			ExceptionArgument.capacity => "capacity", 
			ExceptionArgument.collection => "collection", 
			ExceptionArgument.item => "item", 
			ExceptionArgument.converter => "converter", 
			ExceptionArgument.match => "match", 
			ExceptionArgument.count => "count", 
			ExceptionArgument.action => "action", 
			ExceptionArgument.comparison => "comparison", 
			ExceptionArgument.exceptions => "exceptions", 
			ExceptionArgument.exception => "exception", 
			ExceptionArgument.pointer => "pointer", 
			ExceptionArgument.start => "start", 
			ExceptionArgument.format => "format", 
			ExceptionArgument.formats => "formats", 
			ExceptionArgument.culture => "culture", 
			ExceptionArgument.comparer => "comparer", 
			ExceptionArgument.comparable => "comparable", 
			ExceptionArgument.source => "source", 
			ExceptionArgument.length => "length", 
			ExceptionArgument.comparisonType => "comparisonType", 
			ExceptionArgument.manager => "manager", 
			ExceptionArgument.sourceBytesToCopy => "sourceBytesToCopy", 
			ExceptionArgument.callBack => "callBack", 
			ExceptionArgument.creationOptions => "creationOptions", 
			ExceptionArgument.function => "function", 
			ExceptionArgument.scheduler => "scheduler", 
			ExceptionArgument.continuation => "continuation", 
			ExceptionArgument.continuationAction => "continuationAction", 
			ExceptionArgument.continuationFunction => "continuationFunction", 
			ExceptionArgument.tasks => "tasks", 
			ExceptionArgument.asyncResult => "asyncResult", 
			ExceptionArgument.beginMethod => "beginMethod", 
			ExceptionArgument.endMethod => "endMethod", 
			ExceptionArgument.endFunction => "endFunction", 
			ExceptionArgument.cancellationToken => "cancellationToken", 
			ExceptionArgument.continuationOptions => "continuationOptions", 
			ExceptionArgument.delay => "delay", 
			ExceptionArgument.millisecondsDelay => "millisecondsDelay", 
			ExceptionArgument.millisecondsTimeout => "millisecondsTimeout", 
			ExceptionArgument.stateMachine => "stateMachine", 
			ExceptionArgument.timeout => "timeout", 
			ExceptionArgument.type => "type", 
			ExceptionArgument.sourceIndex => "sourceIndex", 
			ExceptionArgument.destinationIndex => "destinationIndex", 
			ExceptionArgument.pHandle => "pHandle", 
			ExceptionArgument.handle => "handle", 
			ExceptionArgument.other => "other", 
			ExceptionArgument.newSize => "newSize", 
			ExceptionArgument.lengths => "lengths", 
			ExceptionArgument.len => "len", 
			ExceptionArgument.keys => "keys", 
			ExceptionArgument.indices => "indices", 
			ExceptionArgument.index1 => "index1", 
			ExceptionArgument.index2 => "index2", 
			ExceptionArgument.index3 => "index3", 
			ExceptionArgument.endIndex => "endIndex", 
			ExceptionArgument.elementType => "elementType", 
			ExceptionArgument.arrayIndex => "arrayIndex", 
			ExceptionArgument.year => "year", 
			ExceptionArgument.codePoint => "codePoint", 
			ExceptionArgument.str => "str", 
			ExceptionArgument.options => "options", 
			ExceptionArgument.prefix => "prefix", 
			ExceptionArgument.suffix => "suffix", 
			ExceptionArgument.buffer => "buffer", 
			ExceptionArgument.buffers => "buffers", 
			ExceptionArgument.offset => "offset", 
			ExceptionArgument.stream => "stream", 
			ExceptionArgument.anyOf => "anyOf", 
			ExceptionArgument.overlapped => "overlapped", 
			ExceptionArgument.minimumBytes => "minimumBytes", 
			ExceptionArgument.arrayType => "arrayType", 
			ExceptionArgument.divisor => "divisor", 
			ExceptionArgument.factor => "factor", 
			ExceptionArgument.set => "set", 
			_ => "", 
		};
	}

	private static string GetResourceString(ExceptionResource resource)
	{
		return resource switch
		{
			ExceptionResource.ArgumentOutOfRange_IndexMustBeLessOrEqual => "ArgumentOutOfRange_IndexMustBeLessOrEqual", 
			ExceptionResource.ArgumentOutOfRange_IndexMustBeLess => "ArgumentOutOfRange_IndexMustBeLess", 
			ExceptionResource.ArgumentOutOfRange_IndexCount => "ArgumentOutOfRange_IndexCount", 
			ExceptionResource.ArgumentOutOfRange_IndexCountBuffer => "ArgumentOutOfRange_IndexCountBuffer", 
			ExceptionResource.ArgumentOutOfRange_Count => "ArgumentOutOfRange_Count", 
			ExceptionResource.ArgumentOutOfRange_Year => "ArgumentOutOfRange_Year", 
			ExceptionResource.Arg_ArrayPlusOffTooSmall => "Arg_ArrayPlusOffTooSmall", 
			ExceptionResource.Arg_ByteArrayTooSmallForValue => "Arg_ByteArrayTooSmallForValue", 
			ExceptionResource.NotSupported_ReadOnlyCollection => "NotSupported_ReadOnlyCollection", 
			ExceptionResource.Arg_RankMultiDimNotSupported => "Arg_RankMultiDimNotSupported", 
			ExceptionResource.Arg_NonZeroLowerBound => "Arg_NonZeroLowerBound", 
			ExceptionResource.ArgumentOutOfRange_GetCharCountOverflow => "ArgumentOutOfRange_GetCharCountOverflow", 
			ExceptionResource.ArgumentOutOfRange_ListInsert => "ArgumentOutOfRange_ListInsert", 
			ExceptionResource.ArgumentOutOfRange_NeedNonNegNum => "ArgumentOutOfRange_NeedNonNegNum", 
			ExceptionResource.ArgumentOutOfRange_SmallCapacity => "ArgumentOutOfRange_SmallCapacity", 
			ExceptionResource.Argument_InvalidOffLen => "Argument_InvalidOffLen", 
			ExceptionResource.Argument_CannotExtractScalar => "Argument_CannotExtractScalar", 
			ExceptionResource.ArgumentOutOfRange_BiggerThanCollection => "ArgumentOutOfRange_BiggerThanCollection", 
			ExceptionResource.Serialization_MissingKeys => "Serialization_MissingKeys", 
			ExceptionResource.Serialization_NullKey => "Serialization_NullKey", 
			ExceptionResource.NotSupported_KeyCollectionSet => "NotSupported_KeyCollectionSet", 
			ExceptionResource.NotSupported_ValueCollectionSet => "NotSupported_ValueCollectionSet", 
			ExceptionResource.InvalidOperation_NullArray => "InvalidOperation_NullArray", 
			ExceptionResource.TaskT_TransitionToFinal_AlreadyCompleted => "TaskT_TransitionToFinal_AlreadyCompleted", 
			ExceptionResource.TaskCompletionSourceT_TrySetException_NullException => "TaskCompletionSourceT_TrySetException_NullException", 
			ExceptionResource.TaskCompletionSourceT_TrySetException_NoExceptions => "TaskCompletionSourceT_TrySetException_NoExceptions", 
			ExceptionResource.NotSupported_StringComparison => "NotSupported_StringComparison", 
			ExceptionResource.ConcurrentCollection_SyncRoot_NotSupported => "ConcurrentCollection_SyncRoot_NotSupported", 
			ExceptionResource.Task_MultiTaskContinuation_NullTask => "Task_MultiTaskContinuation_NullTask", 
			ExceptionResource.InvalidOperation_WrongAsyncResultOrEndCalledMultiple => "InvalidOperation_WrongAsyncResultOrEndCalledMultiple", 
			ExceptionResource.Task_MultiTaskContinuation_EmptyTaskList => "Task_MultiTaskContinuation_EmptyTaskList", 
			ExceptionResource.Task_Start_TaskCompleted => "Task_Start_TaskCompleted", 
			ExceptionResource.Task_Start_Promise => "Task_Start_Promise", 
			ExceptionResource.Task_Start_ContinuationTask => "Task_Start_ContinuationTask", 
			ExceptionResource.Task_Start_AlreadyStarted => "Task_Start_AlreadyStarted", 
			ExceptionResource.Task_RunSynchronously_Continuation => "Task_RunSynchronously_Continuation", 
			ExceptionResource.Task_RunSynchronously_Promise => "Task_RunSynchronously_Promise", 
			ExceptionResource.Task_RunSynchronously_TaskCompleted => "Task_RunSynchronously_TaskCompleted", 
			ExceptionResource.Task_RunSynchronously_AlreadyStarted => "Task_RunSynchronously_AlreadyStarted", 
			ExceptionResource.AsyncMethodBuilder_InstanceNotInitialized => "AsyncMethodBuilder_InstanceNotInitialized", 
			ExceptionResource.Task_ContinueWith_ESandLR => "Task_ContinueWith_ESandLR", 
			ExceptionResource.Task_ContinueWith_NotOnAnything => "Task_ContinueWith_NotOnAnything", 
			ExceptionResource.Task_InvalidTimerTimeSpan => "Task_InvalidTimerTimeSpan", 
			ExceptionResource.Task_Delay_InvalidMillisecondsDelay => "Task_Delay_InvalidMillisecondsDelay", 
			ExceptionResource.Task_Dispose_NotCompleted => "Task_Dispose_NotCompleted", 
			ExceptionResource.Task_ThrowIfDisposed => "Task_ThrowIfDisposed", 
			ExceptionResource.Task_WaitMulti_NullTask => "Task_WaitMulti_NullTask", 
			ExceptionResource.ArgumentException_OtherNotArrayOfCorrectLength => "ArgumentException_OtherNotArrayOfCorrectLength", 
			ExceptionResource.ArgumentNull_Array => "ArgumentNull_Array", 
			ExceptionResource.ArgumentNull_SafeHandle => "ArgumentNull_SafeHandle", 
			ExceptionResource.ArgumentOutOfRange_EndIndexStartIndex => "ArgumentOutOfRange_EndIndexStartIndex", 
			ExceptionResource.ArgumentOutOfRange_Enum => "ArgumentOutOfRange_Enum", 
			ExceptionResource.ArgumentOutOfRange_HugeArrayNotSupported => "ArgumentOutOfRange_HugeArrayNotSupported", 
			ExceptionResource.Argument_AddingDuplicate => "Argument_AddingDuplicate", 
			ExceptionResource.Argument_InvalidArgumentForComparison => "Argument_InvalidArgumentForComparison", 
			ExceptionResource.Arg_LowerBoundsMustMatch => "Arg_LowerBoundsMustMatch", 
			ExceptionResource.Arg_MustBeType => "Arg_MustBeType", 
			ExceptionResource.Arg_Need1DArray => "Arg_Need1DArray", 
			ExceptionResource.Arg_Need2DArray => "Arg_Need2DArray", 
			ExceptionResource.Arg_Need3DArray => "Arg_Need3DArray", 
			ExceptionResource.Arg_NeedAtLeast1Rank => "Arg_NeedAtLeast1Rank", 
			ExceptionResource.Arg_RankIndices => "Arg_RankIndices", 
			ExceptionResource.Arg_RanksAndBounds => "Arg_RanksAndBounds", 
			ExceptionResource.InvalidOperation_IComparerFailed => "InvalidOperation_IComparerFailed", 
			ExceptionResource.NotSupported_FixedSizeCollection => "NotSupported_FixedSizeCollection", 
			ExceptionResource.Rank_MultiDimNotSupported => "Rank_MultiDimNotSupported", 
			ExceptionResource.Arg_TypeNotSupported => "Arg_TypeNotSupported", 
			ExceptionResource.Argument_SpansMustHaveSameLength => "Argument_SpansMustHaveSameLength", 
			ExceptionResource.Argument_InvalidFlag => "Argument_InvalidFlag", 
			ExceptionResource.CancellationTokenSource_Disposed => "CancellationTokenSource_Disposed", 
			ExceptionResource.Argument_AlignmentMustBePow2 => "Argument_AlignmentMustBePow2", 
			ExceptionResource.ArgumentOutOfRange_NotGreaterThanBufferLength => "ArgumentOutOfRange_NotGreaterThanBufferLength", 
			ExceptionResource.InvalidOperation_SpanOverlappedOperation => "InvalidOperation_SpanOverlappedOperation", 
			ExceptionResource.InvalidOperation_TimeProviderNullLocalTimeZone => "InvalidOperation_TimeProviderNullLocalTimeZone", 
			ExceptionResource.InvalidOperation_TimeProviderInvalidTimestampFrequency => "InvalidOperation_TimeProviderInvalidTimestampFrequency", 
			ExceptionResource.Format_UnexpectedClosingBrace => "Format_UnexpectedClosingBrace", 
			ExceptionResource.Format_UnclosedFormatItem => "Format_UnclosedFormatItem", 
			ExceptionResource.Format_ExpectedAsciiDigit => "Format_ExpectedAsciiDigit", 
			ExceptionResource.Argument_HasToBeArrayClass => "Argument_HasToBeArrayClass", 
			ExceptionResource.InvalidOperation_IncompatibleComparer => "InvalidOperation_IncompatibleComparer", 
			_ => "", 
		};
	}
}
