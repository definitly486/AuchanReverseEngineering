using System.Buffers;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO.Pipelines;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json;

internal static class ThrowHelper
{
	[DoesNotReturn]
	public static void ThrowArgumentNullException(string parameterName)
	{
		throw new ArgumentNullException(parameterName);
	}

	[DoesNotReturn]
	public static void ThrowArgumentOutOfRangeException_NewLine(string parameterName)
	{
		throw GetArgumentOutOfRangeException(parameterName, "InvalidNewLine");
	}

	[DoesNotReturn]
	public static void ThrowArgumentOutOfRangeException_IndentCharacter(string parameterName)
	{
		throw GetArgumentOutOfRangeException(parameterName, "InvalidIndentCharacter");
	}

	[DoesNotReturn]
	public static void ThrowArgumentOutOfRangeException_IndentSize(string parameterName, int minimumSize, int maximumSize)
	{
		throw GetArgumentOutOfRangeException(parameterName, System.SR.Format("InvalidIndentSize", minimumSize, maximumSize));
	}

	[DoesNotReturn]
	public static void ThrowArgumentOutOfRangeException_MaxDepthMustBePositive(string parameterName)
	{
		throw GetArgumentOutOfRangeException(parameterName, "MaxDepthMustBePositive");
	}

	private static ArgumentOutOfRangeException GetArgumentOutOfRangeException(string parameterName, string message)
	{
		return new ArgumentOutOfRangeException(parameterName, message);
	}

	[DoesNotReturn]
	public static void ThrowArgumentOutOfRangeException_CommentEnumMustBeInRange(string parameterName)
	{
		throw GetArgumentOutOfRangeException(parameterName, "CommentHandlingMustBeValid");
	}

	[DoesNotReturn]
	public static void ThrowArgumentOutOfRangeException_JsonConverterFactory_TypeNotSupported(Type typeToConvert)
	{
		throw new ArgumentOutOfRangeException("typeToConvert", System.SR.Format("SerializerConverterFactoryInvalidArgument", typeToConvert.FullName));
	}

	private static ArgumentException GetArgumentException(string message)
	{
		return new ArgumentException(message);
	}

	[DoesNotReturn]
	public static void ThrowArgumentException_ValueTooLarge(long tokenLength)
	{
		throw GetArgumentException(System.SR.Format("ValueTooLarge", tokenLength));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_NeedLargerSpan()
	{
		throw GetInvalidOperationException("FailedToGetLargerSpan");
	}

	private static InvalidOperationException GetInvalidOperationException(string message)
	{
		return new InvalidOperationException(message)
		{
			Source = "System.Text.Json.Rethrowable"
		};
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ExpectedNumber(JsonTokenType tokenType)
	{
		throw GetInvalidOperationException("number", tokenType);
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ExpectedBoolean(JsonTokenType tokenType)
	{
		throw GetInvalidOperationException("boolean", tokenType);
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ExpectedString(JsonTokenType tokenType)
	{
		throw GetInvalidOperationException("string", tokenType);
	}

	private static InvalidOperationException GetInvalidOperationException(string message, JsonTokenType tokenType)
	{
		return GetInvalidOperationException(System.SR.Format("InvalidCast", tokenType, message));
	}

	[DoesNotReturn]
	internal static void ThrowJsonElementWrongTypeException(JsonTokenType expectedType, JsonTokenType actualType)
	{
		throw GetJsonElementWrongTypeException(expectedType.ToValueKind(), actualType.ToValueKind());
	}

	internal static InvalidOperationException GetJsonElementWrongTypeException(JsonValueKind expectedType, JsonValueKind actualType)
	{
		return GetInvalidOperationException(System.SR.Format("JsonElementHasWrongType", expectedType, actualType));
	}

	[DoesNotReturn]
	public static void ThrowJsonReaderException(ref Utf8JsonReader json, ExceptionResource resource, byte nextByte = 0, ReadOnlySpan<byte> bytes = default(ReadOnlySpan<byte>))
	{
		throw GetJsonReaderException(ref json, resource, nextByte, bytes);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static JsonException GetJsonReaderException(ref Utf8JsonReader json, ExceptionResource resource, byte nextByte, ReadOnlySpan<byte> bytes)
	{
		string resourceString = GetResourceString(ref json, resource, nextByte, JsonHelpers.Utf8GetString(bytes));
		long lineNumber = json.CurrentState._lineNumber;
		long bytePositionInLine = json.CurrentState._bytePositionInLine;
		return new JsonReaderException(resourceString + $" LineNumber: {lineNumber} | BytePositionInLine: {bytePositionInLine}.", lineNumber, bytePositionInLine);
	}

	private static bool IsPrintable(byte value)
	{
		if (value >= 32)
		{
			return value < 127;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static string GetPrintableString(byte value)
	{
		if (!IsPrintable(value))
		{
			return $"0x{value:X2}";
		}
		char c = (char)value;
		return c.ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetResourceString(ref Utf8JsonReader json, ExceptionResource resource, byte nextByte, string characters)
	{
		string printableString = GetPrintableString(nextByte);
		string result = "";
		switch (resource)
		{
		case ExceptionResource.ArrayDepthTooLarge:
			result = System.SR.Format("ArrayDepthTooLarge", json.CurrentState.Options.MaxDepth);
			break;
		case ExceptionResource.MismatchedObjectArray:
			result = System.SR.Format("MismatchedObjectArray", printableString);
			break;
		case ExceptionResource.TrailingCommaNotAllowedBeforeArrayEnd:
			result = "TrailingCommaNotAllowedBeforeArrayEnd";
			break;
		case ExceptionResource.TrailingCommaNotAllowedBeforeObjectEnd:
			result = "TrailingCommaNotAllowedBeforeObjectEnd";
			break;
		case ExceptionResource.EndOfStringNotFound:
			result = "EndOfStringNotFound";
			break;
		case ExceptionResource.RequiredDigitNotFoundAfterSign:
			result = System.SR.Format("RequiredDigitNotFoundAfterSign", printableString);
			break;
		case ExceptionResource.RequiredDigitNotFoundAfterDecimal:
			result = System.SR.Format("RequiredDigitNotFoundAfterDecimal", printableString);
			break;
		case ExceptionResource.RequiredDigitNotFoundEndOfData:
			result = "RequiredDigitNotFoundEndOfData";
			break;
		case ExceptionResource.ExpectedEndAfterSingleJson:
			result = System.SR.Format("ExpectedEndAfterSingleJson", printableString);
			break;
		case ExceptionResource.ExpectedEndOfDigitNotFound:
			result = System.SR.Format("ExpectedEndOfDigitNotFound", printableString);
			break;
		case ExceptionResource.ExpectedNextDigitEValueNotFound:
			result = System.SR.Format("ExpectedNextDigitEValueNotFound", printableString);
			break;
		case ExceptionResource.ExpectedSeparatorAfterPropertyNameNotFound:
			result = System.SR.Format("ExpectedSeparatorAfterPropertyNameNotFound", printableString);
			break;
		case ExceptionResource.ExpectedStartOfPropertyNotFound:
			result = System.SR.Format("ExpectedStartOfPropertyNotFound", printableString);
			break;
		case ExceptionResource.ExpectedStartOfPropertyOrValueNotFound:
			result = "ExpectedStartOfPropertyOrValueNotFound";
			break;
		case ExceptionResource.ExpectedStartOfPropertyOrValueAfterComment:
			result = System.SR.Format("ExpectedStartOfPropertyOrValueAfterComment", printableString);
			break;
		case ExceptionResource.ExpectedStartOfValueNotFound:
			result = System.SR.Format("ExpectedStartOfValueNotFound", printableString);
			break;
		case ExceptionResource.ExpectedValueAfterPropertyNameNotFound:
			result = "ExpectedValueAfterPropertyNameNotFound";
			break;
		case ExceptionResource.FoundInvalidCharacter:
			result = System.SR.Format("FoundInvalidCharacter", printableString);
			break;
		case ExceptionResource.InvalidEndOfJsonNonPrimitive:
			result = System.SR.Format("InvalidEndOfJsonNonPrimitive", json.TokenType);
			break;
		case ExceptionResource.ObjectDepthTooLarge:
			result = System.SR.Format("ObjectDepthTooLarge", json.CurrentState.Options.MaxDepth);
			break;
		case ExceptionResource.ExpectedFalse:
			result = System.SR.Format("ExpectedFalse", characters);
			break;
		case ExceptionResource.ExpectedNull:
			result = System.SR.Format("ExpectedNull", characters);
			break;
		case ExceptionResource.ExpectedTrue:
			result = System.SR.Format("ExpectedTrue", characters);
			break;
		case ExceptionResource.InvalidCharacterWithinString:
			result = System.SR.Format("InvalidCharacterWithinString", printableString);
			break;
		case ExceptionResource.InvalidCharacterAfterEscapeWithinString:
			result = System.SR.Format("InvalidCharacterAfterEscapeWithinString", printableString);
			break;
		case ExceptionResource.InvalidHexCharacterWithinString:
			result = System.SR.Format("InvalidHexCharacterWithinString", printableString);
			break;
		case ExceptionResource.EndOfCommentNotFound:
			result = "EndOfCommentNotFound";
			break;
		case ExceptionResource.ZeroDepthAtEnd:
			result = System.SR.Format("ZeroDepthAtEnd");
			break;
		case ExceptionResource.ExpectedJsonTokens:
			result = "ExpectedJsonTokens";
			break;
		case ExceptionResource.NotEnoughData:
			result = "NotEnoughData";
			break;
		case ExceptionResource.ExpectedOneCompleteToken:
			result = "ExpectedOneCompleteToken";
			break;
		case ExceptionResource.InvalidCharacterAtStartOfComment:
			result = System.SR.Format("InvalidCharacterAtStartOfComment", printableString);
			break;
		case ExceptionResource.UnexpectedEndOfDataWhileReadingComment:
			result = System.SR.Format("UnexpectedEndOfDataWhileReadingComment");
			break;
		case ExceptionResource.UnexpectedEndOfLineSeparator:
			result = System.SR.Format("UnexpectedEndOfLineSeparator");
			break;
		case ExceptionResource.InvalidLeadingZeroInNumber:
			result = System.SR.Format("InvalidLeadingZeroInNumber", printableString);
			break;
		}
		return result;
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException(ExceptionResource resource, int currentDepth, int maxDepth, byte token, JsonTokenType tokenType)
	{
		throw GetInvalidOperationException(resource, currentDepth, maxDepth, token, tokenType);
	}

	[DoesNotReturn]
	public static void ThrowArgumentException_InvalidUTF8(ReadOnlySpan<byte> value)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = Math.Min(value.Length, 10);
		for (int i = 0; i < num; i++)
		{
			byte value2 = value[i];
			if (IsPrintable(value2))
			{
				stringBuilder.Append((char)value2);
				continue;
			}
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(2, 1, stringBuilder2);
			handler.AppendLiteral("0x");
			handler.AppendFormatted(value2, "X2");
			stringBuilder2.Append(ref handler);
		}
		if (num < value.Length)
		{
			stringBuilder.Append("...");
		}
		throw new ArgumentException(System.SR.Format("CannotEncodeInvalidUTF8", stringBuilder));
	}

	[DoesNotReturn]
	public static void ThrowArgumentException_InvalidUTF16(int charAsInt)
	{
		throw new ArgumentException(System.SR.Format("CannotEncodeInvalidUTF16", $"0x{charAsInt:X2}"));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ReadInvalidUTF16(int charAsInt)
	{
		throw GetInvalidOperationException(System.SR.Format("CannotReadInvalidUTF16", $"0x{charAsInt:X2}"));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ReadIncompleteUTF16()
	{
		throw GetInvalidOperationException("CannotReadIncompleteUTF16");
	}

	public static InvalidOperationException GetInvalidOperationException_ReadInvalidUTF8(DecoderFallbackException innerException = null)
	{
		return GetInvalidOperationException("CannotTranscodeInvalidUtf8", innerException);
	}

	public static ArgumentException GetArgumentException_ReadInvalidUTF16(EncoderFallbackException innerException)
	{
		return new ArgumentException("CannotTranscodeInvalidUtf16", innerException);
	}

	public static InvalidOperationException GetInvalidOperationException(string message, Exception innerException)
	{
		return new InvalidOperationException(message, innerException)
		{
			Source = "System.Text.Json.Rethrowable"
		};
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static InvalidOperationException GetInvalidOperationException(ExceptionResource resource, int currentDepth, int maxDepth, byte token, JsonTokenType tokenType)
	{
		InvalidOperationException invalidOperationException = GetInvalidOperationException(GetResourceString(resource, currentDepth, maxDepth, token, tokenType));
		invalidOperationException.Source = "System.Text.Json.Rethrowable";
		return invalidOperationException;
	}

	[DoesNotReturn]
	public static void ThrowOutOfMemoryException(uint capacity)
	{
		throw new OutOfMemoryException(System.SR.Format("BufferMaximumSizeExceeded", capacity));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetResourceString(ExceptionResource resource, int currentDepth, int maxDepth, byte token, JsonTokenType tokenType)
	{
		string result = "";
		switch (resource)
		{
		case ExceptionResource.MismatchedObjectArray:
			result = ((tokenType == JsonTokenType.PropertyName) ? System.SR.Format("CannotWriteEndAfterProperty", (char)token) : System.SR.Format("MismatchedObjectArray", (char)token));
			break;
		case ExceptionResource.DepthTooLarge:
			result = System.SR.Format("DepthTooLarge", currentDepth & 0x7FFFFFFF, maxDepth);
			break;
		case ExceptionResource.CannotStartObjectArrayWithoutProperty:
			result = System.SR.Format("CannotStartObjectArrayWithoutProperty", tokenType);
			break;
		case ExceptionResource.CannotStartObjectArrayAfterPrimitiveOrClose:
			result = System.SR.Format("CannotStartObjectArrayAfterPrimitiveOrClose", tokenType);
			break;
		case ExceptionResource.CannotWriteValueWithinObject:
			result = System.SR.Format("CannotWriteValueWithinObject", tokenType);
			break;
		case ExceptionResource.CannotWritePropertyWithinArray:
			result = ((tokenType == JsonTokenType.PropertyName) ? System.SR.Format("CannotWritePropertyAfterProperty") : System.SR.Format("CannotWritePropertyWithinArray", tokenType));
			break;
		case ExceptionResource.CannotWriteValueAfterPrimitiveOrClose:
			result = System.SR.Format("CannotWriteValueAfterPrimitiveOrClose", tokenType);
			break;
		case ExceptionResource.CannotWriteWithinString:
			result = "CannotWriteWithinString";
			break;
		}
		return result;
	}

	public static void ThrowFormatException(NumericType numericType)
	{
		string message = "";
		switch (numericType)
		{
		case NumericType.Byte:
			message = "FormatByte";
			break;
		case NumericType.SByte:
			message = "FormatSByte";
			break;
		case NumericType.Int16:
			message = "FormatInt16";
			break;
		case NumericType.Int32:
			message = "FormatInt32";
			break;
		case NumericType.Int64:
			message = "FormatInt64";
			break;
		case NumericType.Int128:
			message = "FormatInt128";
			break;
		case NumericType.UInt16:
			message = "FormatUInt16";
			break;
		case NumericType.UInt32:
			message = "FormatUInt32";
			break;
		case NumericType.UInt64:
			message = "FormatUInt64";
			break;
		case NumericType.UInt128:
			message = "FormatUInt128";
			break;
		case NumericType.Half:
			message = "FormatHalf";
			break;
		case NumericType.Single:
			message = "FormatSingle";
			break;
		case NumericType.Double:
			message = "FormatDouble";
			break;
		case NumericType.Decimal:
			message = "FormatDecimal";
			break;
		}
		throw new FormatException(message)
		{
			Source = "System.Text.Json.Rethrowable"
		};
	}

	[DoesNotReturn]
	public static void ThrowObjectDisposedException_Utf8JsonWriter()
	{
		throw new ObjectDisposedException("Utf8JsonWriter");
	}

	[DoesNotReturn]
	public static void ThrowObjectDisposedException_JsonDocument()
	{
		throw new ObjectDisposedException("JsonDocument");
	}

	[DoesNotReturn]
	public static void ThrowArgumentException_DeserializeWrongType(Type type, object value)
	{
		throw new ArgumentException(System.SR.Format("DeserializeWrongType", type, value.GetType()));
	}

	[DoesNotReturn]
	public static void ThrowArgumentException_SerializerDoesNotSupportComments(string paramName)
	{
		throw new ArgumentException("JsonSerializerDoesNotSupportComments", paramName);
	}

	[DoesNotReturn]
	public static void ThrowNotSupportedException_SerializationNotSupported(Type propertyType)
	{
		throw new NotSupportedException(System.SR.Format("SerializationNotSupportedType", propertyType));
	}

	[DoesNotReturn]
	public static void ThrowJsonException_DeserializeUnableToConvertValue(Type propertyType)
	{
		throw new JsonException(System.SR.Format("DeserializeUnableToConvertValue", propertyType))
		{
			AppendPathInformation = true
		};
	}

	[DoesNotReturn]
	public static void ThrowInvalidCastException_DeserializeUnableToAssignValue(Type typeOfValue, Type declaredType)
	{
		throw new InvalidCastException(System.SR.Format("DeserializeUnableToAssignValue", typeOfValue, declaredType));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_DeserializeUnableToAssignNull(Type declaredType)
	{
		throw new InvalidOperationException(System.SR.Format("DeserializeUnableToAssignNull", declaredType));
	}

	[DoesNotReturn]
	public static void ThrowJsonException_PropertyGetterDisallowNull(string propertyName, Type declaringType)
	{
		throw new JsonException(System.SR.Format("PropertyGetterDisallowNull", propertyName, declaringType))
		{
			AppendPathInformation = true
		};
	}

	[DoesNotReturn]
	public static void ThrowJsonException_PropertySetterDisallowNull(string propertyName, Type declaringType)
	{
		throw new JsonException(System.SR.Format("PropertySetterDisallowNull", propertyName, declaringType))
		{
			AppendPathInformation = true
		};
	}

	[DoesNotReturn]
	public static void ThrowJsonException_ConstructorParameterDisallowNull(string parameterName, Type declaringType)
	{
		throw new JsonException(System.SR.Format("ConstructorParameterDisallowNull", parameterName, declaringType))
		{
			AppendPathInformation = true
		};
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ObjectCreationHandlingPopulateNotSupportedByConverter(JsonPropertyInfo propertyInfo)
	{
		throw new InvalidOperationException(System.SR.Format("ObjectCreationHandlingPopulateNotSupportedByConverter", propertyInfo.Name, propertyInfo.DeclaringType));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ObjectCreationHandlingPropertyMustHaveAGetter(JsonPropertyInfo propertyInfo)
	{
		throw new InvalidOperationException(System.SR.Format("ObjectCreationHandlingPropertyMustHaveAGetter", propertyInfo.Name, propertyInfo.DeclaringType));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ObjectCreationHandlingPropertyValueTypeMustHaveASetter(JsonPropertyInfo propertyInfo)
	{
		throw new InvalidOperationException(System.SR.Format("ObjectCreationHandlingPropertyValueTypeMustHaveASetter", propertyInfo.Name, propertyInfo.DeclaringType));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ObjectCreationHandlingPropertyCannotAllowPolymorphicDeserialization(JsonPropertyInfo propertyInfo)
	{
		throw new InvalidOperationException(System.SR.Format("ObjectCreationHandlingPropertyCannotAllowPolymorphicDeserialization", propertyInfo.Name, propertyInfo.DeclaringType));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ObjectCreationHandlingPropertyCannotAllowReadOnlyMember(JsonPropertyInfo propertyInfo)
	{
		throw new InvalidOperationException(System.SR.Format("ObjectCreationHandlingPropertyCannotAllowReadOnlyMember", propertyInfo.Name, propertyInfo.DeclaringType));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ObjectCreationHandlingPropertyCannotAllowReferenceHandling()
	{
		throw new InvalidOperationException("ObjectCreationHandlingPropertyCannotAllowReferenceHandling");
	}

	[DoesNotReturn]
	public static void ThrowNotSupportedException_ObjectCreationHandlingPropertyDoesNotSupportParameterizedConstructors()
	{
		throw new NotSupportedException("ObjectCreationHandlingPropertyDoesNotSupportParameterizedConstructors");
	}

	[DoesNotReturn]
	public static void ThrowJsonException_SerializationConverterRead(JsonConverter converter)
	{
		throw new JsonException(System.SR.Format("SerializationConverterRead", converter))
		{
			AppendPathInformation = true
		};
	}

	[DoesNotReturn]
	public static void ThrowJsonException_SerializationConverterWrite(JsonConverter converter)
	{
		throw new JsonException(System.SR.Format("SerializationConverterWrite", converter))
		{
			AppendPathInformation = true
		};
	}

	[DoesNotReturn]
	public static void ThrowJsonException_SerializerCycleDetected(int maxDepth)
	{
		throw new JsonException(System.SR.Format("SerializerCycleDetected", maxDepth))
		{
			AppendPathInformation = true
		};
	}

	[DoesNotReturn]
	public static void ThrowJsonException(string message = null)
	{
		throw new JsonException(message)
		{
			AppendPathInformation = true
		};
	}

	[DoesNotReturn]
	public static void ThrowArgumentException_CannotSerializeInvalidType(string paramName, Type typeToConvert, Type declaringType, string propertyName)
	{
		if (declaringType == null)
		{
			throw new ArgumentException(System.SR.Format("CannotSerializeInvalidType", typeToConvert), paramName);
		}
		throw new ArgumentException(System.SR.Format("CannotSerializeInvalidMember", typeToConvert, propertyName, declaringType), paramName);
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ResolverTypeNotCompatible(Type requestedType, Type actualType)
	{
		throw new InvalidOperationException(System.SR.Format("ResolverTypeNotCompatible", actualType, requestedType));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ResolverTypeInfoOptionsNotCompatible()
	{
		throw new InvalidOperationException("ResolverTypeInfoOptionsNotCompatible");
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_JsonSerializerOptionsNoTypeInfoResolverSpecified()
	{
		throw new InvalidOperationException("JsonSerializerOptionsNoTypeInfoResolverSpecified");
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_JsonSerializerIsReflectionDisabled()
	{
		throw new InvalidOperationException("JsonSerializerIsReflectionDisabled");
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializerOptionsReadOnly(JsonSerializerContext context)
	{
		throw new InvalidOperationException((context == null) ? "SerializerOptionsReadOnly" : "SerializerContextOptionsReadOnly");
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_TypeInfoImmutable()
	{
		throw new InvalidOperationException("TypeInfoImmutable");
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializerPropertyNameConflict(Type type, string propertyName)
	{
		throw new InvalidOperationException(System.SR.Format("SerializerPropertyNameConflict", type, propertyName));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializerPropertyNameNull(JsonPropertyInfo jsonPropertyInfo)
	{
		throw new InvalidOperationException(System.SR.Format("SerializerPropertyNameNull", jsonPropertyInfo.DeclaringType, jsonPropertyInfo.MemberName));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_JsonPropertyRequiredAndNotDeserializable(JsonPropertyInfo jsonPropertyInfo)
	{
		throw new InvalidOperationException(System.SR.Format("JsonPropertyRequiredAndNotDeserializable", jsonPropertyInfo.Name, jsonPropertyInfo.DeclaringType));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_JsonPropertyRequiredAndExtensionData(JsonPropertyInfo jsonPropertyInfo)
	{
		throw new InvalidOperationException(System.SR.Format("JsonPropertyRequiredAndExtensionData", jsonPropertyInfo.Name, jsonPropertyInfo.DeclaringType));
	}

	[DoesNotReturn]
	public static void ThrowJsonException_JsonRequiredPropertyMissing(JsonTypeInfo parent, BitArray assignedOrNotRequiredPropertiesSet)
	{
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = true;
		ReadOnlySpan<JsonPropertyInfo> propertyCache = parent.PropertyCache;
		for (int i = 0; i < propertyCache.Length; i++)
		{
			JsonPropertyInfo jsonPropertyInfo = propertyCache[i];
			if (!assignedOrNotRequiredPropertiesSet[jsonPropertyInfo.PropertyIndex])
			{
				if (!flag)
				{
					stringBuilder.Append(CultureInfo.CurrentUICulture.TextInfo.ListSeparator);
					stringBuilder.Append(' ');
				}
				stringBuilder.Append('\'');
				stringBuilder.Append(jsonPropertyInfo.Name);
				stringBuilder.Append('\'');
				flag = false;
				if (stringBuilder.Length >= 60)
				{
					break;
				}
			}
		}
		throw new JsonException(System.SR.Format("JsonRequiredPropertiesMissing", parent.Type, stringBuilder.ToString()));
	}

	[DoesNotReturn]
	public static void ThrowJsonException_DuplicatePropertyNotAllowed(JsonPropertyInfo property)
	{
		throw new JsonException(System.SR.Format("DuplicatePropertiesNotAllowed_JsonPropertyInfo", property.Name, property.DeclaringType));
	}

	[DoesNotReturn]
	public static void ThrowJsonException_DuplicatePropertyNotAllowed(string name)
	{
		throw new JsonException(System.SR.Format("DuplicatePropertiesNotAllowed_NameSpan", Truncate(name.AsSpan())));
	}

	[DoesNotReturn]
	public static void ThrowJsonException_DuplicatePropertyNotAllowed(ReadOnlySpan<byte> nameBytes)
	{
		string text = JsonHelpers.Utf8GetString(nameBytes);
		throw new JsonException(System.SR.Format("DuplicatePropertiesNotAllowed_NameSpan", Truncate(text.AsSpan())));
	}

	private static string Truncate(ReadOnlySpan<char> str)
	{
		if (str.Length <= 15)
		{
			return str.ToString();
		}
		Span<char> destination = stackalloc char[18];
		str.Slice(0, 15).CopyTo(destination);
		destination[15] = (destination[16] = (destination[17] = '.'));
		return destination.ToString();
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializerConverterFactoryReturnsNull(Type converterType)
	{
		throw new InvalidOperationException(System.SR.Format("SerializerConverterFactoryReturnsNull", converterType));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializerConverterFactoryReturnsJsonConverterFactorty(Type converterType)
	{
		throw new InvalidOperationException(System.SR.Format("SerializerConverterFactoryReturnsJsonConverterFactory", converterType));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_MultiplePropertiesBindToConstructorParameters(Type parentType, string parameterName, string firstMatchName, string secondMatchName)
	{
		throw new InvalidOperationException(System.SR.Format("MultipleMembersBindWithConstructorParameter", firstMatchName, secondMatchName, parentType, parameterName));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ConstructorParameterIncompleteBinding(Type parentType)
	{
		throw new InvalidOperationException(System.SR.Format("ConstructorParamIncompleteBinding", parentType));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ExtensionDataCannotBindToCtorParam(string propertyName, JsonPropertyInfo jsonPropertyInfo)
	{
		throw new InvalidOperationException(System.SR.Format("ExtensionDataCannotBindToCtorParam", propertyName, jsonPropertyInfo.DeclaringType));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_JsonIncludeOnInaccessibleProperty(string memberName, Type declaringType)
	{
		throw new InvalidOperationException(System.SR.Format("JsonIncludeOnInaccessibleProperty", memberName, declaringType));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_IgnoreConditionOnValueTypeInvalid(string clrPropertyName, Type propertyDeclaringType)
	{
		throw new InvalidOperationException(System.SR.Format("IgnoreConditionOnValueTypeInvalid", clrPropertyName, propertyDeclaringType));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_NumberHandlingOnPropertyInvalid(JsonPropertyInfo jsonPropertyInfo)
	{
		throw new InvalidOperationException(System.SR.Format("NumberHandlingOnPropertyInvalid", jsonPropertyInfo.MemberName, jsonPropertyInfo.DeclaringType));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ConverterCanConvertMultipleTypes(Type runtimePropertyType, JsonConverter jsonConverter)
	{
		throw new InvalidOperationException(System.SR.Format("ConverterCanConvertMultipleTypes", jsonConverter.GetType(), jsonConverter.Type, runtimePropertyType));
	}

	[DoesNotReturn]
	public static void ThrowNotSupportedException_ObjectWithParameterizedCtorRefMetadataNotSupported(ReadOnlySpan<byte> propertyName, ref Utf8JsonReader reader, scoped ref ReadStack state)
	{
		JsonTypeInfo topJsonTypeInfoWithParameterizedConstructor = state.GetTopJsonTypeInfoWithParameterizedConstructor();
		state.Current.JsonPropertyName = propertyName.ToArray();
		NotSupportedException innerException = new NotSupportedException(System.SR.Format("ObjectWithParameterizedCtorRefMetadataNotSupported", topJsonTypeInfoWithParameterizedConstructor.Type));
		ThrowNotSupportedException(ref state, in reader, innerException);
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_JsonTypeInfoOperationNotPossibleForKind(JsonTypeInfoKind kind)
	{
		throw new InvalidOperationException(System.SR.Format("InvalidJsonTypeInfoOperationForKind", kind));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_JsonTypeInfoOnDeserializingCallbacksNotSupported(Type type)
	{
		throw new InvalidOperationException(System.SR.Format("OnDeserializingCallbacksNotSupported", type));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_CreateObjectConverterNotCompatible(Type type)
	{
		throw new InvalidOperationException(System.SR.Format("CreateObjectConverterNotCompatible", type));
	}

	[DoesNotReturn]
	public static void ReThrowWithPath(scoped ref ReadStack state, JsonReaderException ex)
	{
		string text = state.JsonPath();
		string message = ex.Message;
		int num = message.AsSpan().LastIndexOf(" LineNumber: ".AsSpan());
		message = ((num < 0) ? (message + " Path: " + text + ".") : $"{message.Substring(0, num)} Path: {text} |{message.Substring(num)}");
		throw new JsonException(message, text, ex.LineNumber, ex.BytePositionInLine, ex);
	}

	[DoesNotReturn]
	public static void ReThrowWithPath(scoped ref ReadStack state, in Utf8JsonReader reader, Exception ex)
	{
		JsonException ex2 = new JsonException(null, ex);
		AddJsonExceptionInformation(ref state, in reader, ex2);
		throw ex2;
	}

	public static void AddJsonExceptionInformation(scoped ref ReadStack state, in Utf8JsonReader reader, JsonException ex)
	{
		long lineNumber = reader.CurrentState._lineNumber;
		ex.LineNumber = lineNumber;
		long bytePositionInLine = reader.CurrentState._bytePositionInLine;
		ex.BytePositionInLine = bytePositionInLine;
		string value = (ex.Path = state.JsonPath());
		string text2 = ex._message;
		if (string.IsNullOrEmpty(text2))
		{
			Type p = state.Current.JsonPropertyInfo?.PropertyType ?? state.Current.JsonTypeInfo.Type;
			text2 = System.SR.Format("DeserializeUnableToConvertValue", p);
			ex.AppendPathInformation = true;
		}
		if (ex.AppendPathInformation)
		{
			text2 += $" Path: {value} | LineNumber: {lineNumber} | BytePositionInLine: {bytePositionInLine}.";
			ex.SetMessage(text2);
		}
	}

	[DoesNotReturn]
	public static void ReThrowWithPath(ref WriteStack state, Exception ex)
	{
		JsonException ex2 = new JsonException(null, ex);
		AddJsonExceptionInformation(ref state, ex2);
		throw ex2;
	}

	public static void AddJsonExceptionInformation(ref WriteStack state, JsonException ex)
	{
		string text = (ex.Path = state.PropertyPath());
		string text3 = ex._message;
		if (string.IsNullOrEmpty(text3))
		{
			text3 = System.SR.Format("SerializeUnableToSerialize");
			ex.AppendPathInformation = true;
		}
		if (ex.AppendPathInformation)
		{
			text3 = text3 + " Path: " + text + ".";
			ex.SetMessage(text3);
		}
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializationDuplicateTypeAttribute(Type classType, Type attribute)
	{
		throw new InvalidOperationException(System.SR.Format("SerializationDuplicateTypeAttribute", classType, attribute));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ExtensionDataConflictsWithUnmappedMemberHandling(Type classType, JsonPropertyInfo jsonPropertyInfo)
	{
		throw new InvalidOperationException(System.SR.Format("ExtensionDataConflictsWithUnmappedMemberHandling", classType, jsonPropertyInfo.MemberName));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializationDataExtensionPropertyInvalid(JsonPropertyInfo jsonPropertyInfo)
	{
		throw new InvalidOperationException(System.SR.Format("SerializationDataExtensionPropertyInvalid", jsonPropertyInfo.PropertyType, jsonPropertyInfo.MemberName));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_NodeJsonObjectCustomConverterNotAllowedOnExtensionProperty()
	{
		throw new InvalidOperationException("NodeJsonObjectCustomConverterNotAllowedOnExtensionProperty");
	}

	[DoesNotReturn]
	public static void ThrowNotSupportedException(scoped ref ReadStack state, in Utf8JsonReader reader, Exception innerException)
	{
		string text = innerException.Message;
		Type type = state.Current.JsonPropertyInfo?.PropertyType ?? state.Current.JsonTypeInfo.Type;
		if (!text.Contains(type.ToString()))
		{
			if (text.Length > 0)
			{
				text += " ";
			}
			text += System.SR.Format("SerializationNotSupportedParentType", type);
		}
		long lineNumber = reader.CurrentState._lineNumber;
		long bytePositionInLine = reader.CurrentState._bytePositionInLine;
		text += $" Path: {state.JsonPath()} | LineNumber: {lineNumber} | BytePositionInLine: {bytePositionInLine}.";
		throw new NotSupportedException(text, innerException);
	}

	[DoesNotReturn]
	public static void ThrowNotSupportedException(ref WriteStack state, Exception innerException)
	{
		string text = innerException.Message;
		Type type = state.Current.JsonPropertyInfo?.PropertyType ?? state.Current.JsonTypeInfo.Type;
		if (!text.Contains(type.ToString()))
		{
			if (text.Length > 0)
			{
				text += " ";
			}
			text += System.SR.Format("SerializationNotSupportedParentType", type);
		}
		text = text + " Path: " + state.PropertyPath() + ".";
		throw new NotSupportedException(text, innerException);
	}

	[DoesNotReturn]
	public static void ThrowNotSupportedException_DeserializeNoConstructor(JsonTypeInfo typeInfo, ref Utf8JsonReader reader, scoped ref ReadStack state)
	{
		Type type = typeInfo.Type;
		string message;
		if (type.IsInterface || type.IsAbstract)
		{
			if (typeInfo.PolymorphicTypeResolver?.UsesTypeDiscriminators ?? false)
			{
				message = System.SR.Format("DeserializationMustSpecifyTypeDiscriminator", type);
			}
			else
			{
				JsonTypeInfoKind kind = typeInfo.Kind;
				bool flag = (uint)(kind - 2) <= 1u;
				message = ((!flag) ? System.SR.Format("DeserializeInterfaceOrAbstractType", type) : System.SR.Format("CannotPopulateCollection", type));
			}
		}
		else
		{
			message = System.SR.Format("DeserializeNoConstructor", "JsonConstructorAttribute", type);
		}
		ThrowNotSupportedException(ref state, in reader, new NotSupportedException(message));
	}

	[DoesNotReturn]
	public static void ThrowJsonException_MetadataValuesInvalidToken(JsonTokenType tokenType)
	{
		ThrowJsonException(System.SR.Format("MetadataInvalidTokenAfterValues", tokenType));
	}

	[DoesNotReturn]
	public static void ThrowJsonException_MetadataValueWasNotString(JsonTokenType tokenType)
	{
		ThrowJsonException(System.SR.Format("MetadataValueWasNotString", tokenType));
	}

	[DoesNotReturn]
	public static void ThrowJsonException_MetadataReferenceObjectCannotContainOtherProperties(ReadOnlySpan<byte> propertyName, scoped ref ReadStack state)
	{
		state.Current.JsonPropertyName = propertyName.ToArray();
		ThrowJsonException_MetadataReferenceObjectCannotContainOtherProperties();
	}

	[DoesNotReturn]
	public static void ThrowJsonException_MetadataUnexpectedProperty(ReadOnlySpan<byte> propertyName, scoped ref ReadStack state)
	{
		state.Current.JsonPropertyName = propertyName.ToArray();
		ThrowJsonException(System.SR.Format("MetadataUnexpectedProperty"));
	}

	[DoesNotReturn]
	public static void ThrowJsonException_UnmappedJsonProperty(Type type, string unmappedPropertyName)
	{
		throw new JsonException(System.SR.Format("UnmappedJsonProperty", unmappedPropertyName, type));
	}

	[DoesNotReturn]
	public static void ThrowJsonException_MetadataReferenceObjectCannotContainOtherProperties()
	{
		ThrowJsonException("MetadataReferenceCannotContainOtherProperties");
	}

	[DoesNotReturn]
	public static void ThrowJsonException_MetadataIdCannotBeCombinedWithRef(ReadOnlySpan<byte> propertyName, scoped ref ReadStack state)
	{
		state.Current.JsonPropertyName = propertyName.ToArray();
		ThrowJsonException("MetadataIdCannotBeCombinedWithRef");
	}

	[DoesNotReturn]
	public static void ThrowJsonException_MetadataStandaloneValuesProperty(scoped ref ReadStack state, ReadOnlySpan<byte> propertyName)
	{
		state.Current.JsonPropertyName = propertyName.ToArray();
		ThrowJsonException("MetadataStandaloneValuesProperty");
	}

	[DoesNotReturn]
	public static void ThrowJsonException_MetadataInvalidPropertyWithLeadingDollarSign(ReadOnlySpan<byte> propertyName, scoped ref ReadStack state, in Utf8JsonReader reader)
	{
		if (state.Current.IsProcessingDictionary())
		{
			state.Current.JsonPropertyNameAsString = reader.GetString();
		}
		else
		{
			state.Current.JsonPropertyName = propertyName.ToArray();
		}
		ThrowJsonException("MetadataInvalidPropertyWithLeadingDollarSign");
	}

	[DoesNotReturn]
	public static void ThrowJsonException_DuplicateMetadataProperty(ReadOnlySpan<byte> utf8PropertyName)
	{
		ThrowJsonException(System.SR.Format("DuplicateMetadataProperty", JsonHelpers.Utf8GetString(utf8PropertyName)));
	}

	[DoesNotReturn]
	public static void ThrowJsonException_MetadataInvalidReferenceToValueType(Type propertyType)
	{
		ThrowJsonException(System.SR.Format("MetadataInvalidReferenceToValueType", propertyType));
	}

	[DoesNotReturn]
	public static void ThrowJsonException_MetadataInvalidPropertyInArrayMetadata(scoped ref ReadStack state, Type propertyType, in Utf8JsonReader reader)
	{
		state.Current.JsonPropertyName = (reader.HasValueSequence ? reader.ValueSequence.ToArray<byte>() : reader.ValueSpan.ToArray());
		string p = reader.GetString();
		ThrowJsonException(System.SR.Format("MetadataPreservedArrayFailed", System.SR.Format("MetadataInvalidPropertyInArrayMetadata", p), System.SR.Format("DeserializeUnableToConvertValue", propertyType)));
	}

	[DoesNotReturn]
	public static void ThrowJsonException_MetadataCannotParsePreservedObjectIntoImmutable(Type propertyType)
	{
		ThrowJsonException(System.SR.Format("MetadataCannotParsePreservedObjectToImmutable", propertyType));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_MetadataReferenceOfTypeCannotBeAssignedToType(string referenceId, Type currentType, Type typeToConvert)
	{
		throw new InvalidOperationException(System.SR.Format("MetadataReferenceOfTypeCannotBeAssignedToType", referenceId, currentType, typeToConvert));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_JsonPropertyInfoIsBoundToDifferentJsonTypeInfo(JsonPropertyInfo propertyInfo)
	{
		throw new InvalidOperationException(System.SR.Format("JsonPropertyInfoBoundToDifferentParent", propertyInfo.Name, propertyInfo.DeclaringTypeInfo.Type.FullName));
	}

	[DoesNotReturn]
	internal static void ThrowUnexpectedMetadataException(ReadOnlySpan<byte> propertyName, ref Utf8JsonReader reader, scoped ref ReadStack state)
	{
		if (JsonSerializer.GetMetadataPropertyName(propertyName, state.Current.BaseJsonTypeInfo.PolymorphicTypeResolver) != MetadataPropertyName.None)
		{
			ThrowJsonException_MetadataUnexpectedProperty(propertyName, ref state);
		}
		else
		{
			ThrowJsonException_MetadataInvalidPropertyWithLeadingDollarSign(propertyName, ref state, in reader);
		}
	}

	[DoesNotReturn]
	public static void ThrowNotSupportedException_NoMetadataForType(Type type, IJsonTypeInfoResolver resolver)
	{
		throw new NotSupportedException(System.SR.Format("NoMetadataForType", type, resolver?.ToString() ?? "<null>"));
	}

	public static NotSupportedException GetNotSupportedException_AmbiguousMetadataForType(Type type, Type match1, Type match2)
	{
		return new NotSupportedException(System.SR.Format("AmbiguousMetadataForType", type, match1, match2));
	}

	public static Exception GetInvalidOperationException_NoMetadataForTypeProperties(IJsonTypeInfoResolver resolver, Type type)
	{
		return new InvalidOperationException(System.SR.Format("NoMetadataForTypeProperties", resolver?.ToString() ?? "<null>", type));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_NoMetadataForTypeProperties(IJsonTypeInfoResolver resolver, Type type)
	{
		throw GetInvalidOperationException_NoMetadataForTypeProperties(resolver, type);
	}

	[DoesNotReturn]
	public static void ThrowNotSupportedException_BaseConverterDoesNotSupportMetadata(Type derivedType)
	{
		throw new NotSupportedException(System.SR.Format("Polymorphism_DerivedConverterDoesNotSupportMetadata", derivedType));
	}

	[DoesNotReturn]
	public static void ThrowNotSupportedException_DerivedConverterDoesNotSupportMetadata(Type derivedType)
	{
		throw new NotSupportedException(System.SR.Format("Polymorphism_DerivedConverterDoesNotSupportMetadata", derivedType));
	}

	[DoesNotReturn]
	public static void ThrowNotSupportedException_RuntimeTypeNotSupported(Type baseType, Type runtimeType)
	{
		throw new NotSupportedException(System.SR.Format("Polymorphism_RuntimeTypeNotSupported", runtimeType, baseType));
	}

	[DoesNotReturn]
	public static void ThrowNotSupportedException_RuntimeTypeDiamondAmbiguity(Type baseType, Type runtimeType, Type derivedType1, Type derivedType2)
	{
		throw new NotSupportedException(System.SR.Format("Polymorphism_RuntimeTypeDiamondAmbiguity", runtimeType, derivedType1, derivedType2, baseType));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_TypeDoesNotSupportPolymorphism(Type baseType)
	{
		throw new InvalidOperationException(System.SR.Format("Polymorphism_TypeDoesNotSupportPolymorphism", baseType));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_DerivedTypeNotSupported(Type baseType, Type derivedType)
	{
		throw new InvalidOperationException(System.SR.Format("Polymorphism_DerivedTypeIsNotSupported", derivedType, baseType));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_DerivedTypeIsAlreadySpecified(Type baseType, Type derivedType)
	{
		throw new InvalidOperationException(System.SR.Format("Polymorphism_DerivedTypeIsAlreadySpecified", baseType, derivedType));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_TypeDicriminatorIdIsAlreadySpecified(Type baseType, object typeDiscriminator)
	{
		throw new InvalidOperationException(System.SR.Format("Polymorphism_TypeDicriminatorIdIsAlreadySpecified", baseType, typeDiscriminator));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_InvalidCustomTypeDiscriminatorPropertyName()
	{
		throw new InvalidOperationException("Polymorphism_InvalidCustomTypeDiscriminatorPropertyName");
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_PropertyConflictsWithMetadataPropertyName(Type type, string propertyName)
	{
		throw new InvalidOperationException(System.SR.Format("Polymorphism_PropertyConflictsWithMetadataPropertyName", type, propertyName));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_PolymorphicTypeConfigurationDoesNotSpecifyDerivedTypes(Type baseType)
	{
		throw new InvalidOperationException(System.SR.Format("Polymorphism_ConfigurationDoesNotSpecifyDerivedTypes", baseType));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_UnsupportedEnumIdentifier(Type enumType, string enumName)
	{
		throw new InvalidOperationException(System.SR.Format("UnsupportedEnumIdentifier", enumType.Name, enumName));
	}

	[DoesNotReturn]
	public static void ThrowJsonException_UnrecognizedTypeDiscriminator(object typeDiscriminator)
	{
		ThrowJsonException(System.SR.Format("Polymorphism_UnrecognizedTypeDiscriminator", typeDiscriminator));
	}

	[DoesNotReturn]
	public static void ThrowOperationCanceledException_PipeWriteCanceled()
	{
		throw new OperationCanceledException("PipeWriterCanceled");
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_PipeWriterDoesNotImplementUnflushedBytes(PipeWriter pipeWriter)
	{
		throw new InvalidOperationException(System.SR.Format("PipeWriter_DoesNotImplementUnflushedBytes", pipeWriter.GetType().Name));
	}
}
