using System.Collections.Generic;
using System.IO;
using System.Private.CoreLib;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading;

namespace System;

internal static class SR
{
	private static readonly object _lock = new object();

	private static List<string> _currentlyLoading;

	private static int _infinitelyRecursingCount;

	private static bool _resourceManagerInited;

	private static readonly bool s_usingResourceKeys = true;

	private static ResourceManager s_resourceManager;

	internal static ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new ResourceManager(typeof(Strings)));

	internal static string Acc_CreateAbstEx => "Acc_CreateAbstEx";

	internal static string Acc_CreateArgIterator => "Acc_CreateArgIterator";

	internal static string Acc_CreateGenericEx => "Acc_CreateGenericEx";

	internal static string Acc_CreateInterfaceEx => "Acc_CreateInterfaceEx";

	internal static string Acc_CreateVoid => "Acc_CreateVoid";

	internal static string Acc_NotClassInit => "Acc_NotClassInit";

	internal static string Acc_ReadOnly => "Acc_ReadOnly";

	internal static string Access_Void => "Access_Void";

	internal static string AggregateException_ctor_DefaultMessage => "AggregateException_ctor_DefaultMessage";

	internal static string AggregateException_ctor_InnerExceptionNull => "AggregateException_ctor_InnerExceptionNull";

	internal static string AggregateException_DeserializationFailure => "AggregateException_DeserializationFailure";

	internal static string AggregateException_InnerException => "AggregateException_InnerException";

	internal static string AppDomain_Name => "AppDomain_Name";

	internal static string AppDomain_NoContextPolicies => "AppDomain_NoContextPolicies";

	internal static string AppDomain_Policy_PrincipalTwice => "AppDomain_Policy_PrincipalTwice";

	internal static string Arg_AccessException => "Arg_AccessException";

	internal static string Arg_AccessViolationException => "Arg_AccessViolationException";

	internal static string Arg_AmbiguousImplementationException_NoMessage => "Arg_AmbiguousImplementationException_NoMessage";

	internal static string Arg_AmbiguousMatchException_Attribute => "Arg_AmbiguousMatchException_Attribute";

	internal static string Arg_AmbiguousMatchException_NoMessage => "Arg_AmbiguousMatchException_NoMessage";

	internal static string Arg_AmbiguousMatchException_MemberInfo => "Arg_AmbiguousMatchException_MemberInfo";

	internal static string Arg_ApplicationException => "Arg_ApplicationException";

	internal static string Arg_ArgumentException => "Arg_ArgumentException";

	internal static string Arg_ArgumentOutOfRangeException => "Arg_ArgumentOutOfRangeException";

	internal static string Arg_ArithmeticException => "Arg_ArithmeticException";

	internal static string Arg_ArrayLengthsDiffer => "Arg_ArrayLengthsDiffer";

	internal static string Arg_ArrayPlusOffTooSmall => "Arg_ArrayPlusOffTooSmall";

	internal static string Arg_BitArrayTypeUnsupported => "Arg_BitArrayTypeUnsupported";

	internal static string Arg_ByteArrayTooSmallForValue => "Arg_ByteArrayTooSmallForValue";

	internal static string Arg_ArrayTypeMismatchException => "Arg_ArrayTypeMismatchException";

	internal static string Arg_ArrayZeroError => "Arg_ArrayZeroError";

	internal static string Arg_BadDecimal => "Arg_BadDecimal";

	internal static string Arg_BadImageFormatException => "Arg_BadImageFormatException";

	internal static string Arg_BogusIComparer => "Arg_BogusIComparer";

	internal static string InvalidOperation_IncompatibleComparer => "InvalidOperation_IncompatibleComparer";

	internal static string Arg_BufferTooSmall => "Arg_BufferTooSmall";

	internal static string Arg_CannotBeNaN => "Arg_CannotBeNaN";

	internal static string Arg_CannotHaveNegativeValue => "Arg_CannotHaveNegativeValue";

	internal static string Arg_CannotMixComparisonInfrastructure => "Arg_CannotMixComparisonInfrastructure";

	internal static string Arg_CannotUnloadAppDomainException => "Arg_CannotUnloadAppDomainException";

	internal static string Arg_COMException => "Arg_COMException";

	internal static string Arg_CreatInstAccess => "Arg_CreatInstAccess";

	internal static string Arg_CryptographyException => "Arg_CryptographyException";

	internal static string Arg_CustomAttributeFormatException => "Arg_CustomAttributeFormatException";

	internal static string Arg_DataMisalignedException => "Arg_DataMisalignedException";

	internal static string Arg_DecBitCtor => "Arg_DecBitCtor";

	internal static string Arg_DirectoryNotFoundException => "Arg_DirectoryNotFoundException";

	internal static string Arg_DivideByZero => "Arg_DivideByZero";

	internal static string Arg_DlgtTargMeth => "Arg_DlgtTargMeth";

	internal static string Arg_DlgtTypeMis => "Arg_DlgtTypeMis";

	internal static string Arg_DllNotFoundException => "Arg_DllNotFoundException";

	internal static string Arg_DllNameCannotBeEmpty => "Arg_DllNameCannotBeEmpty";

	internal static string Arg_DuplicateWaitObjectException => "Arg_DuplicateWaitObjectException";

	internal static string Arg_EHClauseNotFilter => "Arg_EHClauseNotFilter";

	internal static string Arg_EmptyArray => "Arg_EmptyArray";

	internal static string Arg_EmptySpan => "Arg_EmptySpan";

	internal static string Arg_EndOfStreamException => "Arg_EndOfStreamException";

	internal static string Arg_EntryPointNotFoundException => "Arg_EntryPointNotFoundException";

	internal static string Arg_EnumAndObjectMustBeSameType => "Arg_EnumAndObjectMustBeSameType";

	internal static string Arg_EnumFormatUnderlyingTypeAndObjectMustBeSameType => "Arg_EnumFormatUnderlyingTypeAndObjectMustBeSameType";

	internal static string Arg_EnumIllegalVal => "Arg_EnumIllegalVal";

	internal static string Arg_EnumUnderlyingTypeAndObjectMustBeSameType => "Arg_EnumUnderlyingTypeAndObjectMustBeSameType";

	internal static string Arg_EnumValueNotFound => "Arg_EnumValueNotFound";

	internal static string Arg_ExecutionEngineException => "Arg_ExecutionEngineException";

	internal static string Arg_ExternalException => "Arg_ExternalException";

	internal static string Arg_EnC_ExpectedPrimitive => "Arg_EnC_ExpectedPrimitive";

	internal static string Arg_FieldAccessException => "Arg_FieldAccessException";

	internal static string Arg_FieldDeclTarget => "Arg_FieldDeclTarget";

	internal static string Arg_FldGetArgErr => "Arg_FldGetArgErr";

	internal static string Arg_FldGetPropSet => "Arg_FldGetPropSet";

	internal static string Arg_FldSetArgErr => "Arg_FldSetArgErr";

	internal static string Arg_FldSetGet => "Arg_FldSetGet";

	internal static string Arg_FldSetInvoke => "Arg_FldSetInvoke";

	internal static string Arg_FldSetPropGet => "Arg_FldSetPropGet";

	internal static string Arg_FormatException => "Arg_FormatException";

	internal static string Arg_GenericArgumentsAfterArrayOrPointerType => "Arg_GenericArgumentsAfterArrayOrPointerType";

	internal static string Arg_GenericParameter => "Arg_GenericParameter";

	internal static string Arg_GetMethNotFnd => "Arg_GetMethNotFnd";

	internal static string Arg_GuidArrayCtor => "Arg_GuidArrayCtor";

	internal static string Arg_HandleNotAsync => "Arg_HandleNotAsync";

	internal static string Arg_HandleNotSync => "Arg_HandleNotSync";

	internal static string Arg_HexBinaryStylesNotSupported => "Arg_HexBinaryStylesNotSupported";

	internal static string Arg_HTCapacityOverflow => "Arg_HTCapacityOverflow";

	internal static string Arg_IndexMustBeInt => "Arg_IndexMustBeInt";

	internal static string Arg_IndexOutOfRangeException => "Arg_IndexOutOfRangeException";

	internal static string Arg_InsufficientExecutionStackException => "Arg_InsufficientExecutionStackException";

	internal static string Arg_InvalidBase => "Arg_InvalidBase";

	internal static string Arg_InvalidCastException => "Arg_InvalidCastException";

	internal static string Arg_InvalidComObjectException => "Arg_InvalidComObjectException";

	internal static string Arg_InvalidFilterCriteriaException => "Arg_InvalidFilterCriteriaException";

	internal static string Arg_InvalidHandle => "Arg_InvalidHandle";

	internal static string Arg_InvalidHexBinaryStyle => "Arg_InvalidHexBinaryStyle";

	internal static string Arg_InvalidNeutralResourcesLanguage_Asm_Culture => "Arg_InvalidNeutralResourcesLanguage_Asm_Culture";

	internal static string Arg_InvalidNeutralResourcesLanguage_FallbackLoc => "Arg_InvalidNeutralResourcesLanguage_FallbackLoc";

	internal static string Arg_InvalidSatelliteContract_Asm_Ver => "Arg_InvalidSatelliteContract_Asm_Ver";

	internal static string Arg_InvalidOleVariantTypeException => "Arg_InvalidOleVariantTypeException";

	internal static string Arg_InvalidOperationException => "Arg_InvalidOperationException";

	internal static string Arg_InvalidTypeInRetType => "Arg_InvalidTypeInRetType";

	internal static string Arg_InvalidTypeInSignature => "Arg_InvalidTypeInSignature";

	internal static string Arg_IOException => "Arg_IOException";

	internal static string Arg_KeyNotFound => "Arg_KeyNotFound";

	internal static string Arg_KeyNotFoundWithKey => "Arg_KeyNotFoundWithKey";

	internal static string Arg_LongerThanDestArray => "Arg_LongerThanDestArray";

	internal static string Arg_LongerThanSrcArray => "Arg_LongerThanSrcArray";

	internal static string Arg_LongerThanSrcString => "Arg_LongerThanSrcString";

	internal static string Arg_LowerBoundsMustMatch => "Arg_LowerBoundsMustMatch";

	internal static string Arg_MarshalDirectiveException => "Arg_MarshalDirectiveException";

	internal static string Arg_MethodAccessException => "Arg_MethodAccessException";

	internal static string Arg_MissingFieldException => "Arg_MissingFieldException";

	internal static string Arg_MissingManifestResourceException => "Arg_MissingManifestResourceException";

	internal static string Arg_MissingMemberException => "Arg_MissingMemberException";

	internal static string Arg_MissingMethodException => "Arg_MissingMethodException";

	internal static string Arg_MulticastNotSupportedException => "Arg_MulticastNotSupportedException";

	internal static string Arg_MustBeBoolean => "Arg_MustBeBoolean";

	internal static string Arg_MustBeByte => "Arg_MustBeByte";

	internal static string Arg_MustBeChar => "Arg_MustBeChar";

	internal static string Arg_MustBeDateOnly => "Arg_MustBeDateOnly";

	internal static string Arg_MustBeTimeOnly => "Arg_MustBeTimeOnly";

	internal static string Arg_MustBeDateTime => "Arg_MustBeDateTime";

	internal static string Arg_MustBeDateTimeOffset => "Arg_MustBeDateTimeOffset";

	internal static string Arg_MustBeDecimal => "Arg_MustBeDecimal";

	internal static string Arg_MustBeDelegate => "Arg_MustBeDelegate";

	internal static string Arg_MustBeDouble => "Arg_MustBeDouble";

	internal static string Arg_MustBeEnum => "Arg_MustBeEnum";

	internal static string Arg_MustBeEnumBaseTypeOrEnum => "Arg_MustBeEnumBaseTypeOrEnum";

	internal static string Arg_MustBeGuid => "Arg_MustBeGuid";

	internal static string Arg_MustBeInt16 => "Arg_MustBeInt16";

	internal static string Arg_MustBeInt32 => "Arg_MustBeInt32";

	internal static string Arg_MustBeInt64 => "Arg_MustBeInt64";

	internal static string Arg_MustBeInt128 => "Arg_MustBeInt128";

	internal static string Arg_MustBeIntPtr => "Arg_MustBeIntPtr";

	internal static string Arg_MustBeInterface => "Arg_MustBeInterface";

	internal static string Arg_MustBeNFloat => "Arg_MustBeNFloat";

	internal static string Arg_MustBePointer => "Arg_MustBePointer";

	internal static string Arg_MustBePrimArray => "Arg_MustBePrimArray";

	internal static string Arg_MustBeRuntimeAssembly => "Arg_MustBeRuntimeAssembly";

	internal static string Arg_MustBeSByte => "Arg_MustBeSByte";

	internal static string Arg_MustBeSingle => "Arg_MustBeSingle";

	internal static string Arg_MustBeString => "Arg_MustBeString";

	internal static string Arg_MustBeTimeSpan => "Arg_MustBeTimeSpan";

	internal static string Arg_MustBeType => "Arg_MustBeType";

	internal static string Arg_MustBeTrue => "Arg_MustBeTrue";

	internal static string Arg_MustBeUInt16 => "Arg_MustBeUInt16";

	internal static string Arg_MustBeUInt32 => "Arg_MustBeUInt32";

	internal static string Arg_MustBeUInt64 => "Arg_MustBeUInt64";

	internal static string Arg_MustBeUInt128 => "Arg_MustBeUInt128";

	internal static string Arg_MustBeUIntPtr => "Arg_MustBeUIntPtr";

	internal static string Arg_MustBeVersion => "Arg_MustBeVersion";

	internal static string Arg_MustContainEnumInfo => "Arg_MustContainEnumInfo";

	internal static string Arg_NamedParamNull => "Arg_NamedParamNull";

	internal static string Arg_NamedParamTooBig => "Arg_NamedParamTooBig";

	internal static string Arg_Need1DArray => "Arg_Need1DArray";

	internal static string Arg_Need2DArray => "Arg_Need2DArray";

	internal static string Arg_Need3DArray => "Arg_Need3DArray";

	internal static string Arg_NeedAtLeast1Rank => "Arg_NeedAtLeast1Rank";

	internal static string Arg_NoAccessSpec => "Arg_NoAccessSpec";

	internal static string Arg_NoDefCTorWithoutTypeName => "Arg_NoDefCTorWithoutTypeName";

	internal static string Arg_NoDefCTor => "Arg_NoDefCTor";

	internal static string Arg_NonZeroLowerBound => "Arg_NonZeroLowerBound";

	internal static string Arg_NoStaticVirtual => "Arg_NoStaticVirtual";

	internal static string Arg_NotFiniteNumberException => "Arg_NotFiniteNumberException";

	internal static string Arg_NotFoundIFace => "Arg_NotFoundIFace";

	internal static string Arg_NotGenericMethodDefinition => "Arg_NotGenericMethodDefinition";

	internal static string Arg_NotGenericParameter => "Arg_NotGenericParameter";

	internal static string Arg_NotGenericTypeDefinition => "Arg_NotGenericTypeDefinition";

	internal static string Arg_NotImplementedException => "Arg_NotImplementedException";

	internal static string Arg_NotSupportedException => "Arg_NotSupportedException";

	internal static string Arg_NullReferenceException => "Arg_NullReferenceException";

	internal static string Arg_ObjObjEx => "Arg_ObjObjEx";

	internal static string Arg_OleAutDateInvalid => "Arg_OleAutDateInvalid";

	internal static string Arg_OleAutDateScale => "Arg_OleAutDateScale";

	internal static string Arg_OverflowException => "Arg_OverflowException";

	internal static string Arg_OutOfMemoryException => "Arg_OutOfMemoryException";

	internal static string Arg_ParamName_Name => "Arg_ParamName_Name";

	internal static string Arg_ParmArraySize => "Arg_ParmArraySize";

	internal static string Arg_ParmCnt => "Arg_ParmCnt";

	internal static string Arg_PathEmpty => "Arg_PathEmpty";

	internal static string Arg_PlatformNotSupported => "Arg_PlatformNotSupported";

	internal static string Arg_PropSetGet => "Arg_PropSetGet";

	internal static string Arg_PropSetInvoke => "Arg_PropSetInvoke";

	internal static string Arg_RankException => "Arg_RankException";

	internal static string Arg_RankIndices => "Arg_RankIndices";

	internal static string Arg_RankMultiDimNotSupported => "Arg_RankMultiDimNotSupported";

	internal static string Arg_RanksAndBounds => "Arg_RanksAndBounds";

	internal static string Arg_ResMgrNotResSet => "Arg_ResMgrNotResSet";

	internal static string Arg_ResourceFileUnsupportedVersion => "Arg_ResourceFileUnsupportedVersion";

	internal static string Arg_ResourceNameNotExist => "Arg_ResourceNameNotExist";

	internal static string Arg_SafeArrayRankMismatchException => "Arg_SafeArrayRankMismatchException";

	internal static string Arg_SafeArrayTypeMismatchException => "Arg_SafeArrayTypeMismatchException";

	internal static string Arg_SecurityException => "Arg_SecurityException";

	internal static string SerializationException => "SerializationException";

	internal static string Arg_SetMethNotFnd => "Arg_SetMethNotFnd";

	internal static string Arg_StackOverflowException => "Arg_StackOverflowException";

	internal static string Arg_SurrogatesNotAllowedAsSingleChar => "Arg_SurrogatesNotAllowedAsSingleChar";

	internal static string Arg_SynchronizationLockException => "Arg_SynchronizationLockException";

	internal static string Arg_SystemException => "Arg_SystemException";

	internal static string Arg_TargetInvocationException => "Arg_TargetInvocationException";

	internal static string Arg_TargetParameterCountException => "Arg_TargetParameterCountException";

	internal static string Arg_ThreadStartException => "Arg_ThreadStartException";

	internal static string Arg_ThreadStateException => "Arg_ThreadStateException";

	internal static string Arg_TimeoutException => "Arg_TimeoutException";

	internal static string Arg_TypeAccessException => "Arg_TypeAccessException";

	internal static string Arg_TypedReference_Null => "Arg_TypedReference_Null";

	internal static string Arg_TypeLoadException => "Arg_TypeLoadException";

	internal static string Arg_TypeLoadNullStr => "Arg_TypeLoadNullStr";

	internal static string Arg_TypeUnloadedException => "Arg_TypeUnloadedException";

	internal static string Arg_UnauthorizedAccessException => "Arg_UnauthorizedAccessException";

	internal static string Arg_UnboundGenField => "Arg_UnboundGenField";

	internal static string Arg_UnboundGenParam => "Arg_UnboundGenParam";

	internal static string Arg_UnknownTypeCode => "Arg_UnknownTypeCode";

	internal static string Arg_UnreachableException => "Arg_UnreachableException";

	internal static string Arg_VarMissNull => "Arg_VarMissNull";

	internal static string Arg_VersionString => "Arg_VersionString";

	internal static string Arg_WrongType => "Arg_WrongType";

	internal static string Argument_AbsolutePathRequired => "Argument_AbsolutePathRequired";

	internal static string Argument_AddingDuplicate => "Argument_AddingDuplicate";

	internal static string Argument_AddingDuplicate__ => "Argument_AddingDuplicate__";

	internal static string Argument_AddingDuplicateWithKey => "Argument_AddingDuplicateWithKey";

	internal static string Argument_AdjustmentRulesNoNulls => "Argument_AdjustmentRulesNoNulls";

	internal static string Argument_AdjustmentRulesOutOfOrder => "Argument_AdjustmentRulesOutOfOrder";

	internal static string Argument_AlignmentMustBePow2 => "Argument_AlignmentMustBePow2";

	internal static string Argument_ArraysInvalid => "Argument_ArraysInvalid";

	internal static string Argument_ArrayParsingError => "Argument_ArrayParsingError";

	internal static string Argument_ArrayTooLarge => "Argument_ArrayTooLarge";

	internal static string Argument_AttributeNamesMustBeUnique => "Argument_AttributeNamesMustBeUnique";

	internal static string Argument_BadConstructor => "Argument_BadConstructor";

	internal static string Argument_BadExceptionCodeGen => "Argument_BadExceptionCodeGen";

	internal static string Argument_BadFieldType => "Argument_BadFieldType";

	internal static string Argument_BadFormatSpecifier => "Argument_BadFormatSpecifier";

	internal static string Argument_BadParameterCountsForConstructor => "Argument_BadParameterCountsForConstructor";

	internal static string Argument_BadParameterTypeForCAB => "Argument_BadParameterTypeForCAB";

	internal static string Argument_BadSigFormat => "Argument_BadSigFormat";

	internal static string Argument_BadSizeForData => "Argument_BadSizeForData";

	internal static string Argument_ByrefQualifierMustBeLastOneOfAType => "Argument_ByrefQualifierMustBeLastOneOfAType";

	internal static string Argument_CannotSetParentToInterface => "Argument_CannotSetParentToInterface";

	internal static string Argument_CodepageNotSupported => "Argument_CodepageNotSupported";

	internal static string Argument_CompareOptionOrdinal => "Argument_CompareOptionOrdinal";

	internal static string Argument_ConflictingDateTimeRoundtripStyles => "Argument_ConflictingDateTimeRoundtripStyles";

	internal static string Argument_ConflictingDateTimeStyles => "Argument_ConflictingDateTimeStyles";

	internal static string Argument_ConstantDoesntMatch => "Argument_ConstantDoesntMatch";

	internal static string Argument_ConstantNotSupported => "Argument_ConstantNotSupported";

	internal static string Argument_ConstructorNeedGenericDeclaringType => "Argument_ConstructorNeedGenericDeclaringType";

	internal static string Argument_ConversionOverflow => "Argument_ConversionOverflow";

	internal static string Argument_ConvertMismatch => "Argument_ConvertMismatch";

	internal static string Argument_CultureIetfNotSupported => "Argument_CultureIetfNotSupported";

	internal static string Argument_CultureInvalidIdentifier => "Argument_CultureInvalidIdentifier";

	internal static string Argument_CultureIsNeutral => "Argument_CultureIsNeutral";

	internal static string Argument_CultureNotSupported => "Argument_CultureNotSupported";

	internal static string Argument_CultureNotSupportedInInvariantMode => "Argument_CultureNotSupportedInInvariantMode";

	internal static string InvalidOperation_ResolvedAssemblyMustBeRuntimeAssembly => "InvalidOperation_ResolvedAssemblyMustBeRuntimeAssembly";

	internal static string InvalidOperation_ResolvedAssemblyRequestedNameMismatch => "InvalidOperation_ResolvedAssemblyRequestedNameMismatch";

	internal static string Argument_CustomCultureCannotBePassedByNumber => "Argument_CustomCultureCannotBePassedByNumber";

	internal static string Argument_CustomModifierLengthInvalidLength => "Argument_CustomModifierLengthInvalidLength";

	internal static string Argument_DateTimeBadBinaryData => "Argument_DateTimeBadBinaryData";

	internal static string Argument_DateTimeHasTicks => "Argument_DateTimeHasTicks";

	internal static string Argument_DateTimeHasTimeOfDay => "Argument_DateTimeHasTimeOfDay";

	internal static string Argument_DateTimeIsInvalid => "Argument_DateTimeIsInvalid";

	internal static string Argument_DateTimeIsNotAmbiguous => "Argument_DateTimeIsNotAmbiguous";

	internal static string Argument_DateTimeKindMustBeUnspecified => "Argument_DateTimeKindMustBeUnspecified";

	internal static string Argument_DateTimeKindMustBeUnspecifiedOrUtc => "Argument_DateTimeKindMustBeUnspecifiedOrUtc";

	internal static string Argument_DateTimeOffsetInvalidDateTimeStyles => "Argument_DateTimeOffsetInvalidDateTimeStyles";

	internal static string Argument_DateTimeOffsetIsNotAmbiguous => "Argument_DateTimeOffsetIsNotAmbiguous";

	internal static string Argument_DestinationTooShort => "Argument_DestinationTooShort";

	internal static string Argument_DuplicateTypeName => "Argument_DuplicateTypeName";

	internal static string Argument_EmitWriteLineType => "Argument_EmitWriteLineType";

	internal static string Argument_EmptyName => "Argument_EmptyName";

	internal static string Argument_EmptyWaithandleArray => "Argument_EmptyWaithandleArray";

	internal static string Argument_EncoderFallbackNotEmpty => "Argument_EncoderFallbackNotEmpty";

	internal static string Argument_EncodingConversionOverflowBytes => "Argument_EncodingConversionOverflowBytes";

	internal static string Argument_EncodingConversionOverflowChars => "Argument_EncodingConversionOverflowChars";

	internal static string Argument_EncodingNotSupported => "Argument_EncodingNotSupported";

	internal static string Argument_EnumTypeDoesNotMatch => "Argument_EnumTypeDoesNotMatch";

	internal static string Argument_FallbackBufferNotEmpty => "Argument_FallbackBufferNotEmpty";

	internal static string Argument_FieldDoesNotBelongToConstructorClass => "Argument_FieldDoesNotBelongToConstructorClass";

	internal static string Argument_FieldDoesNotHaveAValidType => "Argument_FieldDoesNotHaveAValidType";

	internal static string Argument_FieldDoesNotHaveAValidValue => "Argument_FieldDoesNotHaveAValidValue";

	internal static string Argument_FieldPropertyEventAndTypeHandleIncompatibility => "Argument_FieldPropertyEventAndTypeHandleIncompatibility";

	internal static string Argument_FieldNeedGenericDeclaringType => "Argument_FieldNeedGenericDeclaringType";

	internal static string Argument_GenericArgsCount => "Argument_GenericArgsCount";

	internal static string Argument_GenericArgumentCannotBeByrefOrPointerType => "Argument_GenericArgumentCannotBeByrefOrPointerType";

	internal static string Argument_GenericParsingError => "Argument_GenericParsingError";

	internal static string Argument_OpenGenericTypeNotPermitted => "Argument_OpenGenericTypeNotPermitted";

	internal static string Argument_GlobalMembersMustBeStatic => "Argument_GlobalMembersMustBeStatic";

	internal static string Argument_HasToBeArrayClass => "Argument_HasToBeArrayClass";

	internal static string Argument_IdnBadBidi => "Argument_IdnBadBidi";

	internal static string Argument_IdnBadLabelSize => "Argument_IdnBadLabelSize";

	internal static string Argument_IdnBadNameSize => "Argument_IdnBadNameSize";

	internal static string Argument_IdnBadPunycode => "Argument_IdnBadPunycode";

	internal static string Argument_IdnBadStd3 => "Argument_IdnBadStd3";

	internal static string Argument_IdnIllegalName => "Argument_IdnIllegalName";

	internal static string Argument_IllegalEnvVarName => "Argument_IllegalEnvVarName";

	internal static string Argument_ImplementIComparable => "Argument_ImplementIComparable";

	internal static string Argument_InterfaceMap => "Argument_InterfaceMap";

	internal static string Argument_InvalidAppendMode => "Argument_InvalidAppendMode";

	internal static string Argument_InvalidPreallocateAccess => "Argument_InvalidPreallocateAccess";

	internal static string Argument_InvalidPreallocateMode => "Argument_InvalidPreallocateMode";

	internal static string Argument_InvalidUnixCreateMode => "Argument_InvalidUnixCreateMode";

	internal static string Argument_InvalidArgumentForComparison => "Argument_InvalidArgumentForComparison";

	internal static string Argument_InvalidArrayLength => "Argument_InvalidArrayLength";

	internal static string Argument_MultiDimensionalArrayCannotBeBound => "Argument_MultiDimensionalArrayCannotBeBound";

	internal static string Argument_IncompatibleArrayType => "Argument_IncompatibleArrayType";

	internal static string Argument_InvalidArrayType => "Argument_InvalidArrayType";

	internal static string InvalidAssemblyName => "InvalidAssemblyName";

	internal static string Argument_InvalidCalendar => "Argument_InvalidCalendar";

	internal static string Argument_InvalidCharInArraySpecification => "Argument_InvalidCharInArraySpecification";

	internal static string Argument_InvalidCharSequence => "Argument_InvalidCharSequence";

	internal static string Argument_InvalidCharSequenceNoIndex => "Argument_InvalidCharSequenceNoIndex";

	internal static string Argument_InvalidCodePageBytesIndex => "Argument_InvalidCodePageBytesIndex";

	internal static string Argument_InvalidCodePageConversionIndex => "Argument_InvalidCodePageConversionIndex";

	internal static string Argument_InvalidConstructorDeclaringType => "Argument_InvalidConstructorDeclaringType";

	internal static string Argument_InvalidCultureName => "Argument_InvalidCultureName";

	internal static string Argument_InvalidPredefinedCultureName => "Argument_InvalidPredefinedCultureName";

	internal static string Argument_InvalidDateTimeKind => "Argument_InvalidDateTimeKind";

	internal static string Argument_InvalidDateTimeStyles => "Argument_InvalidDateTimeStyles";

	internal static string Argument_InvalidDateStyles => "Argument_InvalidDateStyles";

	internal static string Argument_InvalidDigitSubstitution => "Argument_InvalidDigitSubstitution";

	internal static string Argument_InvalidElementName => "Argument_InvalidElementName";

	internal static string Argument_InvalidElementTag => "Argument_InvalidElementTag";

	internal static string Argument_InvalidElementText => "Argument_InvalidElementText";

	internal static string Argument_InvalidElementValue => "Argument_InvalidElementValue";

	internal static string Argument_InvalidEnum => "Argument_InvalidEnum";

	internal static string Argument_InvalidEnumValue => "Argument_InvalidEnumValue";

	internal static string Argument_InvalidFieldDeclaringType => "Argument_InvalidFieldDeclaringType";

	internal static string Argument_InvalidFileModeAndAccessCombo => "Argument_InvalidFileModeAndAccessCombo";

	internal static string Argument_InvalidFlag => "Argument_InvalidFlag";

	internal static string Argument_InvalidGenericArg => "Argument_InvalidGenericArg";

	internal static string Argument_InvalidGenericArgumentsSeparator => "Argument_InvalidGenericArgumentsSeparator";

	internal static string Argument_InvalidGroupSize => "Argument_InvalidGroupSize";

	internal static string Argument_InvalidHandle => "Argument_InvalidHandle";

	internal static string Argument_InvalidHighSurrogate => "Argument_InvalidHighSurrogate";

	internal static string Argument_InvalidId => "Argument_InvalidId";

	internal static string Argument_InvalidKindOfTypeForCA => "Argument_InvalidKindOfTypeForCA";

	internal static string Argument_InvalidLabel => "Argument_InvalidLabel";

	internal static string Argument_InvalidLowSurrogate => "Argument_InvalidLowSurrogate";

	internal static string Argument_InvalidMemberForNamedArgument => "Argument_InvalidMemberForNamedArgument";

	internal static string Argument_InvalidMethodDeclaringType => "Argument_InvalidMethodDeclaringType";

	internal static string Argument_InvalidName => "Argument_InvalidName";

	internal static string Argument_InvalidNativeDigitCount => "Argument_InvalidNativeDigitCount";

	internal static string Argument_InvalidNativeDigitValue => "Argument_InvalidNativeDigitValue";

	internal static string Argument_InvalidNeutralRegionName => "Argument_InvalidNeutralRegionName";

	internal static string Argument_InvalidNormalizationForm => "Argument_InvalidNormalizationForm";

	internal static string Argument_InvalidNumberStyles => "Argument_InvalidNumberStyles";

	internal static string Argument_InvalidOffLen => "Argument_InvalidOffLen";

	internal static string Argument_InvalidOpCodeOnDynamicMethod => "Argument_InvalidOpCodeOnDynamicMethod";

	internal static string Argument_NullCharInPath => "Argument_NullCharInPath";

	internal static string Argument_InvalidResourceCultureName => "Argument_InvalidResourceCultureName";

	internal static string Argument_InvalidSafeBufferOffLen => "Argument_InvalidSafeBufferOffLen";

	internal static string Argument_InvalidSeekOrigin => "Argument_InvalidSeekOrigin";

	internal static string Argument_InvalidSerializedString => "Argument_InvalidSerializedString";

	internal static string Argument_InvalidStartupHookSignature => "Argument_InvalidStartupHookSignature";

	internal static string Argument_InvalidTimeSpanStyles => "Argument_InvalidTimeSpanStyles";

	internal static string Argument_InvalidToken => "Argument_InvalidToken";

	internal static string Argument_InvalidTypeForDynamicMethod => "Argument_InvalidTypeForDynamicMethod";

	internal static string Argument_InvalidTypeName => "Argument_InvalidTypeName";

	internal static string Argument_InvalidTypeWithPointersNotSupported => "Argument_InvalidTypeWithPointersNotSupported";

	internal static string Argument_InvalidUnity => "Argument_InvalidUnity";

	internal static string Argument_LabelUnmarked => "Argument_LabelUnmarked";

	internal static string Argument_MethodBodyMustBelongToType => "Argument_MethodBodyMustBelongToType";

	internal static string Argument_MethodDeclaringTypeGeneric => "Argument_MethodDeclaringTypeGeneric";

	internal static string Argument_MethodNeedGenericDeclaringType => "Argument_MethodNeedGenericDeclaringType";

	internal static string Argument_MinMaxValue => "Argument_MinMaxValue";

	internal static string Argument_MismatchedArrays => "Argument_MismatchedArrays";

	internal static string Argument_MustBeFalse => "Argument_MustBeFalse";

	internal static string Argument_MustBeRuntimeAssembly => "Argument_MustBeRuntimeAssembly";

	internal static string Argument_MustBeRuntimeFieldInfo => "Argument_MustBeRuntimeFieldInfo";

	internal static string Argument_MustBeRuntimeConstructorInfo => "Argument_MustBeRuntimeConstructorInfo";

	internal static string Argument_MustBeRuntimeMethodInfo => "Argument_MustBeRuntimeMethodInfo";

	internal static string Argument_MustBeRuntimeMethod => "Argument_MustBeRuntimeMethod";

	internal static string Argument_MustBeRuntimeType => "Argument_MustBeRuntimeType";

	internal static string Argument_MustBeTypeBuilder => "Argument_MustBeTypeBuilder";

	internal static string Argument_MustHaveAttributeBaseClass => "Argument_MustHaveAttributeBaseClass";

	internal static string Argument_NativeOverlappedAlreadyFree => "Argument_NativeOverlappedAlreadyFree";

	internal static string Argument_NativeOverlappedWrongBoundHandle => "Argument_NativeOverlappedWrongBoundHandle";

	internal static string Argument_NeedGenericMethodDefinition => "Argument_NeedGenericMethodDefinition";

	internal static string Argument_NeedNonGenericType => "Argument_NeedNonGenericType";

	internal static string Argument_NeedStructWithNoRefs => "Argument_NeedStructWithNoRefs";

	internal static string Argument_NegativeFieldOffsetNotPermitted => "Argument_NegativeFieldOffsetNotPermitted";

	internal static string Argument_NeverValidGenericArgument => "Argument_NeverValidGenericArgument";

	internal static string Argument_NoEra => "Argument_NoEra";

	internal static string Argument_NoRegionInvariantCulture => "Argument_NoRegionInvariantCulture";

	internal static string Argument_NotEnoughBytesToRead => "Argument_NotEnoughBytesToRead";

	internal static string Argument_NotEnoughBytesToWrite => "Argument_NotEnoughBytesToWrite";

	internal static string Argument_NotEnoughGenArguments => "Argument_NotEnoughGenArguments";

	internal static string Argument_NotExceptionType => "Argument_NotExceptionType";

	internal static string Argument_NotInExceptionBlock => "Argument_NotInExceptionBlock";

	internal static string Argument_NotMethodCallOpcode => "Argument_NotMethodCallOpcode";

	internal static string Argument_OffsetAndCapacityOutOfBounds => "Argument_OffsetAndCapacityOutOfBounds";

	internal static string Argument_OffsetLocalMismatch => "Argument_OffsetLocalMismatch";

	internal static string Argument_OffsetOutOfRange => "Argument_OffsetOutOfRange";

	internal static string Argument_OffsetPrecision => "Argument_OffsetPrecision";

	internal static string Argument_OffsetUtcMismatch => "Argument_OffsetUtcMismatch";

	internal static string Argument_OneOfCulturesNotSupported => "Argument_OneOfCulturesNotSupported";

	internal static string Argument_OnlyMscorlib => "Argument_OnlyMscorlib";

	internal static string Argument_OutOfOrderDateTimes => "Argument_OutOfOrderDateTimes";

	internal static string Argument_PathEmpty => "Argument_PathEmpty";

	internal static string Argument_ParameterHasUnmatchedArgumentValue => "Argument_ParameterHasUnmatchedArgumentValue";

	internal static string Argument_ParameterInvalidType => "Argument_ParameterInvalidType";

	internal static string Argument_ParameterInvalidValue => "Argument_ParameterInvalidValue";

	internal static string Argument_TypeParseError => "Argument_TypeParseError";

	internal static string Argument_PreAllocatedAlreadyAllocated => "Argument_PreAllocatedAlreadyAllocated";

	internal static string Argument_RecursiveFallback => "Argument_RecursiveFallback";

	internal static string Argument_RecursiveFallbackBytes => "Argument_RecursiveFallbackBytes";

	internal static string Argument_RedefinedLabel => "Argument_RedefinedLabel";

	internal static string Argument_ResolveType => "Argument_ResolveType";

	internal static string Argument_ResultCalendarRange => "Argument_ResultCalendarRange";

	internal static string Argument_SemaphoreInitialMaximum => "Argument_SemaphoreInitialMaximum";

	internal static string Argument_ShouldNotSpecifyExceptionType => "Argument_ShouldNotSpecifyExceptionType";

	internal static string Argument_ShouldOnlySetVisibilityFlags => "Argument_ShouldOnlySetVisibilityFlags";

	internal static string Argument_StreamNotReadable => "Argument_StreamNotReadable";

	internal static string Argument_StreamNotWritable => "Argument_StreamNotWritable";

	internal static string Argument_StringFirstCharIsZero => "Argument_StringFirstCharIsZero";

	internal static string Argument_TimeSpanHasSeconds => "Argument_TimeSpanHasSeconds";

	internal static string Argument_TimeZoneInfoBadTZif => "Argument_TimeZoneInfoBadTZif";

	internal static string Argument_TimeZoneInfoInvalidTZif => "Argument_TimeZoneInfoInvalidTZif";

	internal static string Argument_ToExclusiveLessThanFromExclusive => "Argument_ToExclusiveLessThanFromExclusive";

	internal static string Argument_TransitionTimesAreIdentical => "Argument_TransitionTimesAreIdentical";

	internal static string Argument_TypedReferenceInvalidField => "Argument_TypedReferenceInvalidField";

	internal static string Argument_TypeMustNotBeComImport => "Argument_TypeMustNotBeComImport";

	internal static string Argument_UnclosedAssemblyQualifiedTypeName => "Argument_UnclosedAssemblyQualifiedTypeName";

	internal static string Argument_UnmanagedMemAccessorWrapAround => "Argument_UnmanagedMemAccessorWrapAround";

	internal static string Argument_UnmanagedTypeOnlyValidOnFields => "Argument_UnmanagedTypeOnlyValidOnFields";

	internal static string Argument_UnmatchedFieldValueAndType => "Argument_UnmatchedFieldValueAndType";

	internal static string Argument_UnmatchedMethodForLocal => "Argument_UnmatchedMethodForLocal";

	internal static string Argument_UnmatchedSquareBracketWhileParsingGenericArgAssemblyName => "Argument_UnmatchedSquareBracketWhileParsingGenericArgAssemblyName";

	internal static string Argument_UTCOutOfRange => "Argument_UTCOutOfRange";

	internal static string ArgumentException_BufferNotFromPool => "ArgumentException_BufferNotFromPool";

	internal static string ArgumentException_OtherNotArrayOfCorrectLength => "ArgumentException_OtherNotArrayOfCorrectLength";

	internal static string ArgumentException_NotIsomorphic => "ArgumentException_NotIsomorphic";

	internal static string ArgumentException_TupleIncorrectType => "ArgumentException_TupleIncorrectType";

	internal static string ArgumentException_TupleLastArgumentNotATuple => "ArgumentException_TupleLastArgumentNotATuple";

	internal static string ArgumentException_ValueTupleIncorrectType => "ArgumentException_ValueTupleIncorrectType";

	internal static string ArgumentException_ValueTupleLastArgumentNotAValueTuple => "ArgumentException_ValueTupleLastArgumentNotAValueTuple";

	internal static string ArgumentNull_Array => "ArgumentNull_Array";

	internal static string ArgumentNull_ArrayElement => "ArgumentNull_ArrayElement";

	internal static string ArgumentNull_ArrayValue => "ArgumentNull_ArrayValue";

	internal static string ArgumentNull_Child => "ArgumentNull_Child";

	internal static string ArgumentNull_Generic => "ArgumentNull_Generic";

	internal static string ArgumentNull_SafeHandle => "ArgumentNull_SafeHandle";

	internal static string ArgumentNull_String => "ArgumentNull_String";

	internal static string ArgumentOutOfRange_ActualValue => "ArgumentOutOfRange_ActualValue";

	internal static string ArgumentOutOfRange_AddValue => "ArgumentOutOfRange_AddValue";

	internal static string ArgumentOutOfRange_ArrayLB => "ArgumentOutOfRange_ArrayLB";

	internal static string ArgumentOutOfRange_BadHourMinuteSecond => "ArgumentOutOfRange_BadHourMinuteSecond";

	internal static string ArgumentOutOfRange_BadYearMonthDay => "ArgumentOutOfRange_BadYearMonthDay";

	internal static string ArgumentOutOfRange_BiggerThanCollection => "ArgumentOutOfRange_BiggerThanCollection";

	internal static string ArgumentOutOfRange_Bounds_Lower_Upper => "ArgumentOutOfRange_Bounds_Lower_Upper";

	internal static string ArgumentOutOfRange_CalendarRange => "ArgumentOutOfRange_CalendarRange";

	internal static string ArgumentOutOfRange_Capacity => "ArgumentOutOfRange_Capacity";

	internal static string ArgumentOutOfRange_Count => "ArgumentOutOfRange_Count";

	internal static string ArgumentOutOfRange_DateArithmetic => "ArgumentOutOfRange_DateArithmetic";

	internal static string ArgumentOutOfRange_DateTimeBadMonths => "ArgumentOutOfRange_DateTimeBadMonths";

	internal static string ArgumentOutOfRange_DateTimeBadTicks => "ArgumentOutOfRange_DateTimeBadTicks";

	internal static string ArgumentOutOfRange_TimeOnlyBadTicks => "ArgumentOutOfRange_TimeOnlyBadTicks";

	internal static string ArgumentOutOfRange_DateTimeBadYears => "ArgumentOutOfRange_DateTimeBadYears";

	internal static string ArgumentOutOfRange_Day => "ArgumentOutOfRange_Day";

	internal static string ArgumentOutOfRange_DayOfWeek => "ArgumentOutOfRange_DayOfWeek";

	internal static string ArgumentOutOfRange_DayParam => "ArgumentOutOfRange_DayParam";

	internal static string ArgumentOutOfRange_DecimalRound => "ArgumentOutOfRange_DecimalRound";

	internal static string ArgumentOutOfRange_EndIndexStartIndex => "ArgumentOutOfRange_EndIndexStartIndex";

	internal static string ArgumentOutOfRange_Enum => "ArgumentOutOfRange_Enum";

	internal static string ArgumentOutOfRange_Era => "ArgumentOutOfRange_Era";

	internal static string ArgumentOutOfRange_FileLengthTooBig => "ArgumentOutOfRange_FileLengthTooBig";

	internal static string ArgumentOutOfRange_FileTimeInvalid => "ArgumentOutOfRange_FileTimeInvalid";

	internal static string ArgumentOutOfRange_GetByteCountOverflow => "ArgumentOutOfRange_GetByteCountOverflow";

	internal static string ArgumentOutOfRange_GetCharCountOverflow => "ArgumentOutOfRange_GetCharCountOverflow";

	internal static string ArgumentOutOfRange_HashtableLoadFactor => "ArgumentOutOfRange_HashtableLoadFactor";

	internal static string ArgumentOutOfRange_HugeArrayNotSupported => "ArgumentOutOfRange_HugeArrayNotSupported";

	internal static string ArgumentOutOfRange_IndexMustBeLess => "ArgumentOutOfRange_IndexMustBeLess";

	internal static string ArgumentOutOfRange_IndexMustBeLessOrEqual => "ArgumentOutOfRange_IndexMustBeLessOrEqual";

	internal static string ArgumentOutOfRange_IndexCount => "ArgumentOutOfRange_IndexCount";

	internal static string ArgumentOutOfRange_IndexCountBuffer => "ArgumentOutOfRange_IndexCountBuffer";

	internal static string ArgumentOutOfRange_IndexLength => "ArgumentOutOfRange_IndexLength";

	internal static string ArgumentOutOfRange_IndexString => "ArgumentOutOfRange_IndexString";

	internal static string ArgumentOutOfRange_InvalidEraValue => "ArgumentOutOfRange_InvalidEraValue";

	internal static string ArgumentOutOfRange_InvalidHighSurrogate => "ArgumentOutOfRange_InvalidHighSurrogate";

	internal static string ArgumentOutOfRange_InvalidLowSurrogate => "ArgumentOutOfRange_InvalidLowSurrogate";

	internal static string ArgumentOutOfRange_InvalidUTF32 => "ArgumentOutOfRange_InvalidUTF32";

	internal static string ArgumentOutOfRange_LengthGreaterThanCapacity => "ArgumentOutOfRange_LengthGreaterThanCapacity";

	internal static string ArgumentOutOfRange_LessEqualToIntegerMaxVal => "ArgumentOutOfRange_LessEqualToIntegerMaxVal";

	internal static string ArgumentOutOfRange_ListInsert => "ArgumentOutOfRange_ListInsert";

	internal static string ArgumentOutOfRange_Month => "ArgumentOutOfRange_Month";

	internal static string ArgumentOutOfRange_DayNumber => "ArgumentOutOfRange_DayNumber";

	internal static string ArgumentOutOfRange_MonthParam => "ArgumentOutOfRange_MonthParam";

	internal static string ArgumentOutOfRange_MustBeNonNegNum => "ArgumentOutOfRange_MustBeNonNegNum";

	internal static string ArgumentOutOfRange_MustBePositive => "ArgumentOutOfRange_MustBePositive";

	internal static string ArgumentOutOfRange_NeedNonNegNum => "ArgumentOutOfRange_NeedNonNegNum";

	internal static string ArgumentOutOfRange_NeedNonNegOrNegative1 => "ArgumentOutOfRange_NeedNonNegOrNegative1";

	internal static string ArgumentOutOfRange_NeedValidId => "ArgumentOutOfRange_NeedValidId";

	internal static string ArgumentOutOfRange_OffsetLength => "ArgumentOutOfRange_OffsetLength";

	internal static string ArgumentOutOfRange_OffsetOut => "ArgumentOutOfRange_OffsetOut";

	internal static string ArgumentOutOfRange_ParamSequence => "ArgumentOutOfRange_ParamSequence";

	internal static string ArgumentOutOfRange_PartialWCHAR => "ArgumentOutOfRange_PartialWCHAR";

	internal static string ArgumentOutOfRange_PositionLessThanCapacityRequired => "ArgumentOutOfRange_PositionLessThanCapacityRequired";

	internal static string ArgumentOutOfRange_Range => "ArgumentOutOfRange_Range";

	internal static string ArgumentOutOfRange_RoundingDigits => "ArgumentOutOfRange_RoundingDigits";

	internal static string ArgumentOutOfRange_RoundingDigits_MathF => "ArgumentOutOfRange_RoundingDigits_MathF";

	internal static string ArgumentOutOfRange_SmallCapacity => "ArgumentOutOfRange_SmallCapacity";

	internal static string ArgumentOutOfRange_StartIndex => "ArgumentOutOfRange_StartIndex";

	internal static string ArgumentOutOfRange_StartIndexLargerThanLength => "ArgumentOutOfRange_StartIndexLargerThanLength";

	internal static string ArgumentOutOfRange_StreamLength => "ArgumentOutOfRange_StreamLength";

	internal static string ArgumentOutOfRange_UIntPtrMax => "ArgumentOutOfRange_UIntPtrMax";

	internal static string ArgumentOutOfRange_UnmanagedMemStreamLength => "ArgumentOutOfRange_UnmanagedMemStreamLength";

	internal static string ArgumentOutOfRange_UnmanagedMemStreamWrapAround => "ArgumentOutOfRange_UnmanagedMemStreamWrapAround";

	internal static string ArgumentOutOfRange_UtcOffset => "ArgumentOutOfRange_UtcOffset";

	internal static string ArgumentOutOfRange_UtcOffsetAndDaylightDelta => "ArgumentOutOfRange_UtcOffsetAndDaylightDelta";

	internal static string ArgumentOutOfRange_Week => "ArgumentOutOfRange_Week";

	internal static string ArgumentOutOfRange_Year => "ArgumentOutOfRange_Year";

	internal static string ArgumentOutOfRange_Generic_MustBeNonZero => "ArgumentOutOfRange_Generic_MustBeNonZero";

	internal static string ArgumentOutOfRange_Generic_MustBeNonNegative => "ArgumentOutOfRange_Generic_MustBeNonNegative";

	internal static string ArgumentOutOfRange_Generic_MustBeNonNegativeNonZero => "ArgumentOutOfRange_Generic_MustBeNonNegativeNonZero";

	internal static string ArgumentOutOfRange_Generic_MustBeLessOrEqual => "ArgumentOutOfRange_Generic_MustBeLessOrEqual";

	internal static string ArgumentOutOfRange_Generic_MustBeLess => "ArgumentOutOfRange_Generic_MustBeLess";

	internal static string ArgumentOutOfRange_Generic_MustBeGreaterOrEqual => "ArgumentOutOfRange_Generic_MustBeGreaterOrEqual";

	internal static string ArgumentOutOfRange_Generic_MustBeGreater => "ArgumentOutOfRange_Generic_MustBeGreater";

	internal static string ArgumentOutOfRange_Generic_MustBeEqual => "ArgumentOutOfRange_Generic_MustBeEqual";

	internal static string ArgumentOutOfRange_Generic_MustBeNotEqual => "ArgumentOutOfRange_Generic_MustBeNotEqual";

	internal static string Arithmetic_NaN => "Arithmetic_NaN";

	internal static string ArrayTypeMismatch_CantAssignType => "ArrayTypeMismatch_CantAssignType";

	internal static string AssemblyLoadContext_Unload_CannotUnloadIfNotCollectible => "AssemblyLoadContext_Unload_CannotUnloadIfNotCollectible";

	internal static string AssemblyLoadContext_Verify_NotUnloading => "AssemblyLoadContext_Verify_NotUnloading";

	internal static string AssertionFailed => "AssertionFailed";

	internal static string AssertionFailed_Cnd => "AssertionFailed_Cnd";

	internal static string AssumptionFailed => "AssumptionFailed";

	internal static string AssumptionFailed_Cnd => "AssumptionFailed_Cnd";

	internal static string AsyncMethodBuilder_InstanceNotInitialized => "AsyncMethodBuilder_InstanceNotInitialized";

	internal static string BadImageFormat_BadILFormat => "BadImageFormat_BadILFormat";

	internal static string BadImageFormat_InvalidType => "BadImageFormat_InvalidType";

	internal static string BadImageFormat_NegativeStringLength => "BadImageFormat_NegativeStringLength";

	internal static string BadImageFormat_ResType_SerBlobMismatch => "BadImageFormat_ResType_SerBlobMismatch";

	internal static string BadImageFormat_ResourceDataLengthInvalid => "BadImageFormat_ResourceDataLengthInvalid";

	internal static string BadImageFormat_ResourceNameCorrupted => "BadImageFormat_ResourceNameCorrupted";

	internal static string BadImageFormat_ResourceNameCorrupted_NameIndex => "BadImageFormat_ResourceNameCorrupted_NameIndex";

	internal static string BadImageFormat_ResourcesDataInvalidOffset => "BadImageFormat_ResourcesDataInvalidOffset";

	internal static string BadImageFormat_ResourcesHeaderCorrupted => "BadImageFormat_ResourcesHeaderCorrupted";

	internal static string BadImageFormat_ResourcesIndexTooLong => "BadImageFormat_ResourcesIndexTooLong";

	internal static string BadImageFormat_ResourcesNameInvalidOffset => "BadImageFormat_ResourcesNameInvalidOffset";

	internal static string BadImageFormat_ResourcesNameTooLong => "BadImageFormat_ResourcesNameTooLong";

	internal static string BadImageFormat_TypeMismatch => "BadImageFormat_TypeMismatch";

	internal static string CancellationToken_CreateLinkedToken_TokensIsEmpty => "CancellationToken_CreateLinkedToken_TokensIsEmpty";

	internal static string CancellationTokenSource_Disposed => "CancellationTokenSource_Disposed";

	internal static string ConcurrentCollection_SyncRoot_NotSupported => "ConcurrentCollection_SyncRoot_NotSupported";

	internal static string CustomMarshaler_MultipleGetInstanceMethods => "CustomMarshaler_MultipleGetInstanceMethods";

	internal static string CustomMarshaler_NoGetInstanceMethod => "CustomMarshaler_NoGetInstanceMethod";

	internal static string CustomMarshaler_UnassignedGenericParams => "CustomMarshaler_UnassignedGenericParams";

	internal static string CustomMarshaler_NullReturnForGetInstance => "CustomMarshaler_NullReturnForGetInstance";

	internal static string EventSource_AbstractMustNotDeclareEventMethods => "EventSource_AbstractMustNotDeclareEventMethods";

	internal static string EventSource_AbstractMustNotDeclareKTOC => "EventSource_AbstractMustNotDeclareKTOC";

	internal static string EventSource_AddScalarOutOfRange => "EventSource_AddScalarOutOfRange";

	internal static string EventSource_BadHexDigit => "EventSource_BadHexDigit";

	internal static string EventSource_ChannelTypeDoesNotMatchEventChannelValue => "EventSource_ChannelTypeDoesNotMatchEventChannelValue";

	internal static string EventSource_DataDescriptorsOutOfRange => "EventSource_DataDescriptorsOutOfRange";

	internal static string EventSource_DuplicateStringKey => "EventSource_DuplicateStringKey";

	internal static string EventSource_EnumKindMismatch => "EventSource_EnumKindMismatch";

	internal static string EventSource_EvenHexDigits => "EventSource_EvenHexDigits";

	internal static string EventSource_EventChannelOutOfRange => "EventSource_EventChannelOutOfRange";

	internal static string EventSource_EventIdReused => "EventSource_EventIdReused";

	internal static string EventSource_EventMustHaveTaskIfNonDefaultOpcode => "EventSource_EventMustHaveTaskIfNonDefaultOpcode";

	internal static string EventSource_EventMustNotBeExplicitImplementation => "EventSource_EventMustNotBeExplicitImplementation";

	internal static string EventSource_EventNameReused => "EventSource_EventNameReused";

	internal static string EventSource_EventParametersMismatch => "EventSource_EventParametersMismatch";

	internal static string EventSource_EventSourceGuidInUse => "EventSource_EventSourceGuidInUse";

	internal static string EventSource_EventTooBig => "EventSource_EventTooBig";

	internal static string EventSource_EventWithAdminChannelMustHaveMessage => "EventSource_EventWithAdminChannelMustHaveMessage";

	internal static string EventSource_IllegalKeywordsValue => "EventSource_IllegalKeywordsValue";

	internal static string EventSource_IllegalOpcodeValue => "EventSource_IllegalOpcodeValue";

	internal static string EventSource_IllegalTaskValue => "EventSource_IllegalTaskValue";

	internal static string EventSource_IllegalValue => "EventSource_IllegalValue";

	internal static string EventSource_IncorrentlyAuthoredTypeInfo => "EventSource_IncorrentlyAuthoredTypeInfo";

	internal static string EventSource_InvalidCommand => "EventSource_InvalidCommand";

	internal static string EventSource_InvalidEventFormat => "EventSource_InvalidEventFormat";

	internal static string EventSource_KeywordCollision => "EventSource_KeywordCollision";

	internal static string EventSource_KeywordNeedPowerOfTwo => "EventSource_KeywordNeedPowerOfTwo";

	internal static string EventSource_ListenerCreatedInsideCallback => "EventSource_ListenerCreatedInsideCallback";

	internal static string EventSource_ListenerNotFound => "EventSource_ListenerNotFound";

	internal static string EventSource_ListenerWriteFailure => "EventSource_ListenerWriteFailure";

	internal static string EventSource_MaxChannelExceeded => "EventSource_MaxChannelExceeded";

	internal static string EventSource_MismatchIdToWriteEvent => "EventSource_MismatchIdToWriteEvent";

	internal static string EventSource_NeedGuid => "EventSource_NeedGuid";

	internal static string EventSource_NeedName => "EventSource_NeedName";

	internal static string EventSource_NeedPositiveId => "EventSource_NeedPositiveId";

	internal static string EventSource_NoFreeBuffers => "EventSource_NoFreeBuffers";

	internal static string EventSource_NonCompliantTypeError => "EventSource_NonCompliantTypeError";

	internal static string EventSource_NoRelatedActivityId => "EventSource_NoRelatedActivityId";

	internal static string EventSource_NotSupportedArrayOfBinary => "EventSource_NotSupportedArrayOfBinary";

	internal static string EventSource_NotSupportedArrayOfNil => "EventSource_NotSupportedArrayOfNil";

	internal static string EventSource_NotSupportedArrayOfNullTerminatedString => "EventSource_NotSupportedArrayOfNullTerminatedString";

	internal static string EventSource_NotSupportedNestedArraysEnums => "EventSource_NotSupportedNestedArraysEnums";

	internal static string EventSource_NullInput => "EventSource_NullInput";

	internal static string EventSource_OpcodeCollision => "EventSource_OpcodeCollision";

	internal static string EventSource_PinArrayOutOfRange => "EventSource_PinArrayOutOfRange";

	internal static string EventSource_RecursiveTypeDefinition => "EventSource_RecursiveTypeDefinition";

	internal static string EventSource_StopsFollowStarts => "EventSource_StopsFollowStarts";

	internal static string EventSource_TaskCollision => "EventSource_TaskCollision";

	internal static string EventSource_TaskOpcodePairReused => "EventSource_TaskOpcodePairReused";

	internal static string EventSource_TooManyArgs => "EventSource_TooManyArgs";

	internal static string EventSource_TooManyFields => "EventSource_TooManyFields";

	internal static string EventSource_ToString => "EventSource_ToString";

	internal static string EventSource_TraitEven => "EventSource_TraitEven";

	internal static string EventSource_TypeMustBeSealedOrAbstract => "EventSource_TypeMustBeSealedOrAbstract";

	internal static string EventSource_TypeMustDeriveFromEventSource => "EventSource_TypeMustDeriveFromEventSource";

	internal static string EventSource_UndefinedChannel => "EventSource_UndefinedChannel";

	internal static string EventSource_UndefinedKeyword => "EventSource_UndefinedKeyword";

	internal static string EventSource_UndefinedOpcode => "EventSource_UndefinedOpcode";

	internal static string EventSource_UnknownEtwTrait => "EventSource_UnknownEtwTrait";

	internal static string EventSource_UnsupportedEventTypeInManifest => "EventSource_UnsupportedEventTypeInManifest";

	internal static string EventSource_UnsupportedMessageProperty => "EventSource_UnsupportedMessageProperty";

	internal static string EventSource_VarArgsParameterMismatch => "EventSource_VarArgsParameterMismatch";

	internal static string Exception_EmptyFieldForCustomAttributeType => "Exception_EmptyFieldForCustomAttributeType";

	internal static string Exception_EndOfInnerExceptionStack => "Exception_EndOfInnerExceptionStack";

	internal static string Exception_EndStackTraceFromPreviousThrow => "Exception_EndStackTraceFromPreviousThrow";

	internal static string Exception_InvalidCustomAttributeLength => "Exception_InvalidCustomAttributeLength";

	internal static string Exception_InvalidProlog => "Exception_InvalidProlog";

	internal static string Exception_UnknownNamedType => "Exception_UnknownNamedType";

	internal static string Exception_UnknownMarshalAsAttributeField => "Exception_UnknownMarshalAsAttributeField";

	internal static string Exception_UnhandledSubType => "Exception_UnhandledSubType";

	internal static string Exception_WasThrown => "Exception_WasThrown";

	internal static string ExecutionContext_ExceptionInAsyncLocalNotification => "ExecutionContext_ExceptionInAsyncLocalNotification";

	internal static string FileNotFound_ResolveAssembly => "FileNotFound_ResolveAssembly";

	internal static string FileNotFound_LoadFile => "FileNotFound_LoadFile";

	internal static string Format_AttributeUsage => "Format_AttributeUsage";

	internal static string Format_Bad7BitInt => "Format_Bad7BitInt";

	internal static string Format_BadBase64Char => "Format_BadBase64Char";

	internal static string Format_BadBoolean => "Format_BadBoolean";

	internal static string Format_BadDatePattern => "Format_BadDatePattern";

	internal static string Format_BadDateTime => "Format_BadDateTime";

	internal static string Format_BadDateOnly => "Format_BadDateOnly";

	internal static string Format_BadTimeOnly => "Format_BadTimeOnly";

	internal static string Format_DateTimeOnlyContainsNoneDateParts => "Format_DateTimeOnlyContainsNoneDateParts";

	internal static string Format_BadDateTimeCalendar => "Format_BadDateTimeCalendar";

	internal static string Format_BadDayOfWeek => "Format_BadDayOfWeek";

	internal static string Format_BadFormatSpecifier => "Format_BadFormatSpecifier";

	internal static string Format_NoFormatSpecifier => "Format_NoFormatSpecifier";

	internal static string Format_BadHexChar => "Format_BadHexChar";

	internal static string Format_BadHexLength => "Format_BadHexLength";

	internal static string Format_BadQuote => "Format_BadQuote";

	internal static string Format_BadTimeSpan => "Format_BadTimeSpan";

	internal static string Format_DateOutOfRange => "Format_DateOutOfRange";

	internal static string Format_EmptyInputString => "Format_EmptyInputString";

	internal static string Format_ExtraJunkAtEnd => "Format_ExtraJunkAtEnd";

	internal static string Format_GuidBrace => "Format_GuidBrace";

	internal static string Format_GuidBraceAfterLastNumber => "Format_GuidBraceAfterLastNumber";

	internal static string Format_GuidComma => "Format_GuidComma";

	internal static string Format_GuidDashes => "Format_GuidDashes";

	internal static string Format_GuidEndBrace => "Format_GuidEndBrace";

	internal static string Format_GuidHexPrefix => "Format_GuidHexPrefix";

	internal static string Format_GuidInvalidChar => "Format_GuidInvalidChar";

	internal static string Format_GuidInvLen => "Format_GuidInvLen";

	internal static string Format_GuidUnrecognized => "Format_GuidUnrecognized";

	internal static string Format_IndexOutOfRange => "Format_IndexOutOfRange";

	internal static string Format_InvalidEnumFormatSpecification => "Format_InvalidEnumFormatSpecification";

	internal static string Format_InvalidGuidFormatSpecification => "Format_InvalidGuidFormatSpecification";

	internal static string Format_InvalidString => "Format_InvalidString";

	internal static string Format_InvalidStringWithValue => "Format_InvalidStringWithValue";

	internal static string Format_InvalidStringWithOffsetAndReason => "Format_InvalidStringWithOffsetAndReason";

	internal static string Format_UnexpectedClosingBrace => "Format_UnexpectedClosingBrace";

	internal static string Format_UnclosedFormatItem => "Format_UnclosedFormatItem";

	internal static string Format_ExpectedAsciiDigit => "Format_ExpectedAsciiDigit";

	internal static string Format_MissingIncompleteDate => "Format_MissingIncompleteDate";

	internal static string Format_NeedSingleChar => "Format_NeedSingleChar";

	internal static string Format_NoParsibleDigits => "Format_NoParsibleDigits";

	internal static string Format_OffsetOutOfRange => "Format_OffsetOutOfRange";

	internal static string Format_RepeatDateTimePattern => "Format_RepeatDateTimePattern";

	internal static string Format_StringZeroLength => "Format_StringZeroLength";

	internal static string Format_UnknownDateTimeWord => "Format_UnknownDateTimeWord";

	internal static string Format_UTCOutOfRange => "Format_UTCOutOfRange";

	internal static string Globalization_cp_1200 => "Globalization_cp_1200";

	internal static string Globalization_cp_12000 => "Globalization_cp_12000";

	internal static string Globalization_cp_12001 => "Globalization_cp_12001";

	internal static string Globalization_cp_1201 => "Globalization_cp_1201";

	internal static string Globalization_cp_20127 => "Globalization_cp_20127";

	internal static string Globalization_cp_28591 => "Globalization_cp_28591";

	internal static string Globalization_cp_65000 => "Globalization_cp_65000";

	internal static string Globalization_cp_65001 => "Globalization_cp_65001";

	internal static string IndexOutOfRange_UMSPosition => "IndexOutOfRange_UMSPosition";

	internal static string InsufficientMemory_MemFailPoint => "InsufficientMemory_MemFailPoint";

	internal static string InsufficientMemory_MemFailPoint_TooBig => "InsufficientMemory_MemFailPoint_TooBig";

	internal static string InsufficientMemory_MemFailPoint_VAFrag => "InsufficientMemory_MemFailPoint_VAFrag";

	internal static string InvalidCast_CannotCastNullToValueType => "InvalidCast_CannotCastNullToValueType";

	internal static string InvalidCast_DBNull => "InvalidCast_DBNull";

	internal static string InvalidCast_DownCastArrayElement => "InvalidCast_DownCastArrayElement";

	internal static string InvalidCast_Empty => "InvalidCast_Empty";

	internal static string InvalidCast_FromDBNull => "InvalidCast_FromDBNull";

	internal static string InvalidCast_FromTo => "InvalidCast_FromTo";

	internal static string InvalidCast_IConvertible => "InvalidCast_IConvertible";

	internal static string InvalidOperation_AbstractMethod => "InvalidOperation_AbstractMethod";

	internal static string InvalidOperation_AsyncFlowCtrlCtxMismatch => "InvalidOperation_AsyncFlowCtrlCtxMismatch";

	internal static string InvalidOperation_AsyncIOInProgress => "InvalidOperation_AsyncIOInProgress";

	internal static string InvalidOperation_BadEmptyMethodBody => "InvalidOperation_BadEmptyMethodBody";

	internal static string InvalidOperation_BadInstructionOrIndexOutOfBound => "InvalidOperation_BadInstructionOrIndexOutOfBound";

	internal static string InvalidOperation_BadInterfaceNotAbstract => "InvalidOperation_BadInterfaceNotAbstract";

	internal static string InvalidOperation_BadInterfaceNotAbstractAndVirtual => "InvalidOperation_BadInterfaceNotAbstractAndVirtual";

	internal static string InvalidOperation_CalledTwice => "InvalidOperation_CalledTwice";

	internal static string InvalidOperation_CannotRegisterSecondResolver => "InvalidOperation_CannotRegisterSecondResolver";

	internal static string InvalidOperation_CannotRegisterSecondHandler => "InvalidOperation_CannotRegisterSecondHandler";

	internal static string InvalidOperation_CannotRestoreUnsuppressedFlow => "InvalidOperation_CannotRestoreUnsuppressedFlow";

	internal static string InvalidOperation_CannotUseAFCOtherThread => "InvalidOperation_CannotUseAFCOtherThread";

	internal static string InvalidOperation_CollectionCorrupted => "InvalidOperation_CollectionCorrupted";

	internal static string InvalidOperation_ConcurrentOperationsNotSupported => "InvalidOperation_ConcurrentOperationsNotSupported";

	internal static string InvalidOperation_DateTimeParsing => "InvalidOperation_DateTimeParsing";

	internal static string InvalidOperation_EnumEnded => "InvalidOperation_EnumEnded";

	internal static string InvalidOperation_EnumFailedVersion => "InvalidOperation_EnumFailedVersion";

	internal static string InvalidOperation_EnumNotStarted => "InvalidOperation_EnumNotStarted";

	internal static string InvalidOperation_EnumOpCantHappen => "InvalidOperation_EnumOpCantHappen";

	internal static string InvalidOperation_GlobalsHaveBeenCreated => "InvalidOperation_GlobalsHaveBeenCreated";

	internal static string InvalidOperation_HandleIsNotInitialized => "InvalidOperation_HandleIsNotInitialized";

	internal static string InvalidOperation_HandleIsNotPinned => "InvalidOperation_HandleIsNotPinned";

	internal static string InvalidOperation_InvalidUtf8 => "InvalidOperation_InvalidUtf8";

	internal static string InvalidOperation_HashInsertFailed => "InvalidOperation_HashInsertFailed";

	internal static string InvalidOperation_IComparerFailed => "InvalidOperation_IComparerFailed";

	internal static string InvalidOperation_MethodBaked => "InvalidOperation_MethodBaked";

	internal static string InvalidOperation_ModuleFieldsMethodsRelyOnCreateGlobalFunctionsMethod => "InvalidOperation_ModuleFieldsMethodsRelyOnCreateGlobalFunctionsMethod";

	internal static string InvalidOperation_MustCallInitialize => "InvalidOperation_MustCallInitialize";

	internal static string InvalidOperation_NativeOverlappedReused => "InvalidOperation_NativeOverlappedReused";

	internal static string InvalidOperation_NoMultiModuleAssembly => "InvalidOperation_NoMultiModuleAssembly";

	internal static string InvalidOperation_NoPublicAddMethod => "InvalidOperation_NoPublicAddMethod";

	internal static string InvalidOperation_NoPublicRemoveMethod => "InvalidOperation_NoPublicRemoveMethod";

	internal static string InvalidOperation_NotADebugModule => "InvalidOperation_NotADebugModule";

	internal static string InvalidOperation_NotAllowedInDynamicMethod => "InvalidOperation_NotAllowedInDynamicMethod";

	internal static string InvalidOperation_NotAVarArgCallingConvention => "InvalidOperation_NotAVarArgCallingConvention";

	internal static string InvalidOperation_NotGenericType => "InvalidOperation_NotGenericType";

	internal static string InvalidOperation_NotWithConcurrentGC => "InvalidOperation_NotWithConcurrentGC";

	internal static string InvalidOperation_NoValue => "InvalidOperation_NoValue";

	internal static string InvalidOperation_NullArray => "InvalidOperation_NullArray";

	internal static string InvalidOperation_NullContext => "InvalidOperation_NullContext";

	internal static string InvalidOperation_Overlapped_Pack => "InvalidOperation_Overlapped_Pack";

	internal static string InvalidOperation_ReadOnly => "InvalidOperation_ReadOnly";

	internal static string InvalidOperation_ResMgrBadResSet_Type => "InvalidOperation_ResMgrBadResSet_Type";

	internal static string InvalidOperation_ResourceNotStream_Name => "InvalidOperation_ResourceNotStream_Name";

	internal static string InvalidOperation_ResourceNotString_Name => "InvalidOperation_ResourceNotString_Name";

	internal static string InvalidOperation_ResourceNotString_Type => "InvalidOperation_ResourceNotString_Type";

	internal static string InvalidOperation_SetLatencyModeNoGC => "InvalidOperation_SetLatencyModeNoGC";

	internal static string InvalidOperation_ShouldNotHaveMethodBody => "InvalidOperation_ShouldNotHaveMethodBody";

	internal static string InvalidOperation_ThreadWrongThreadStart => "InvalidOperation_ThreadWrongThreadStart";

	internal static string InvalidOperation_TimeoutsNotSupported => "InvalidOperation_TimeoutsNotSupported";

	internal static string InvalidOperation_TimerAlreadyClosed => "InvalidOperation_TimerAlreadyClosed";

	internal static string InvalidOperation_TypeHasBeenCreated => "InvalidOperation_TypeHasBeenCreated";

	internal static string InvalidOperation_TypeNotCreated => "InvalidOperation_TypeNotCreated";

	internal static string InvalidOperation_UnderlyingArrayListChanged => "InvalidOperation_UnderlyingArrayListChanged";

	internal static string InvalidOperation_UnknownEnumType => "InvalidOperation_UnknownEnumType";

	internal static string InvalidOperation_WrongAsyncResultOrEndCalledMultiple => "InvalidOperation_WrongAsyncResultOrEndCalledMultiple";

	internal static string InvalidProgram_Default => "InvalidProgram_Default";

	internal static string InvalidTimeZone_InvalidFileData => "InvalidTimeZone_InvalidFileData";

	internal static string InvalidTimeZone_InvalidJulianDay => "InvalidTimeZone_InvalidJulianDay";

	internal static string InvalidTimeZone_NoTTInfoStructures => "InvalidTimeZone_NoTTInfoStructures";

	internal static string InvalidTimeZone_UnparsablePosixMDateString => "InvalidTimeZone_UnparsablePosixMDateString";

	internal static string InvariantFailed => "InvariantFailed";

	internal static string InvariantFailed_Cnd => "InvariantFailed_Cnd";

	internal static string IO_NoFileTableInInMemoryAssemblies => "IO_NoFileTableInInMemoryAssemblies";

	internal static string IO_EOF_ReadBeyondEOF => "IO_EOF_ReadBeyondEOF";

	internal static string IO_FileLoad => "IO_FileLoad";

	internal static string IO_FileName_Name => "IO_FileName_Name";

	internal static string IO_FileNotFound => "IO_FileNotFound";

	internal static string IO_FileNotFound_FileName => "IO_FileNotFound_FileName";

	internal static string IO_AlreadyExists_Name => "IO_AlreadyExists_Name";

	internal static string IO_DiskFull_Path_AllocationSize => "IO_DiskFull_Path_AllocationSize";

	internal static string IO_FileTooLarge_Path_AllocationSize => "IO_FileTooLarge_Path_AllocationSize";

	internal static string IO_FileExists_Name => "IO_FileExists_Name";

	internal static string IO_FileTooLong2GB => "IO_FileTooLong2GB";

	internal static string IO_FixedCapacity => "IO_FixedCapacity";

	internal static string IO_InvalidStringLen_Len => "IO_InvalidStringLen_Len";

	internal static string IO_SeekAppendOverwrite => "IO_SeekAppendOverwrite";

	internal static string IO_SeekBeforeBegin => "IO_SeekBeforeBegin";

	internal static string IO_SetLengthAppendTruncate => "IO_SetLengthAppendTruncate";

	internal static string IO_SharingViolation_File => "IO_SharingViolation_File";

	internal static string IO_SharingViolation_NoFileName => "IO_SharingViolation_NoFileName";

	internal static string IO_StreamTooLong => "IO_StreamTooLong";

	internal static string IO_PathNotFound_NoPathName => "IO_PathNotFound_NoPathName";

	internal static string IO_PathNotFound_Path => "IO_PathNotFound_Path";

	internal static string IO_PathTooLong => "IO_PathTooLong";

	internal static string IO_PathTooLong_Path => "IO_PathTooLong_Path";

	internal static string IO_TooManySymbolicLinkLevels => "IO_TooManySymbolicLinkLevels";

	internal static string IO_UnknownFileName => "IO_UnknownFileName";

	internal static string Lazy_CreateValue_NoParameterlessCtorForT => "Lazy_CreateValue_NoParameterlessCtorForT";

	internal static string Lazy_ctor_ModeInvalid => "Lazy_ctor_ModeInvalid";

	internal static string Lazy_StaticInit_InvalidOperation => "Lazy_StaticInit_InvalidOperation";

	internal static string Lazy_ToString_ValueNotCreated => "Lazy_ToString_ValueNotCreated";

	internal static string Lazy_Value_RecursiveCallsToValue => "Lazy_Value_RecursiveCallsToValue";

	internal static string ManualResetEventSlim_ctor_TooManyWaiters => "ManualResetEventSlim_ctor_TooManyWaiters";

	internal static string MissingConstructor_Name => "MissingConstructor_Name";

	internal static string MissingField => "MissingField";

	internal static string MissingField_Name => "MissingField_Name";

	internal static string MissingManifestResource_MultipleBlobs => "MissingManifestResource_MultipleBlobs";

	internal static string MissingManifestResource_NoNeutralAsm => "MissingManifestResource_NoNeutralAsm";

	internal static string MissingManifestResource_NoNeutralDisk => "MissingManifestResource_NoNeutralDisk";

	internal static string MissingMember => "MissingMember";

	internal static string MissingMember_Name => "MissingMember_Name";

	internal static string MissingMemberNestErr => "MissingMemberNestErr";

	internal static string MissingMemberTypeRef => "MissingMemberTypeRef";

	internal static string MissingMethod_Name => "MissingMethod_Name";

	internal static string MissingSatelliteAssembly_Culture_Name => "MissingSatelliteAssembly_Culture_Name";

	internal static string MissingSatelliteAssembly_Default => "MissingSatelliteAssembly_Default";

	internal static string Multicast_Combine => "Multicast_Combine";

	internal static string MustUseCCRewrite => "MustUseCCRewrite";

	internal static string NotSupported_AbstractNonCLS => "NotSupported_AbstractNonCLS";

	internal static string NotSupported_ActivAttr => "NotSupported_ActivAttr";

	internal static string NotSupported_AssemblyLoadFromHash => "NotSupported_AssemblyLoadFromHash";

	internal static string NotSupported_ByRefLike => "NotSupported_ByRefLike";

	internal static string NotSupported_ByRefToByRefLikeReturn => "NotSupported_ByRefToByRefLikeReturn";

	internal static string NotSupported_ByRefToVoidReturn => "NotSupported_ByRefToVoidReturn";

	internal static string NotSupported_CallToVarArg => "NotSupported_CallToVarArg";

	internal static string NotSupported_CannotCallEqualsOnSpan => "NotSupported_CannotCallEqualsOnSpan";

	internal static string NotSupported_CannotCallGetHashCodeOnSpan => "NotSupported_CannotCallGetHashCodeOnSpan";

	internal static string NotSupported_ChangeType => "NotSupported_ChangeType";

	internal static string NotSupported_ContainsStackPtr => "NotSupported_ContainsStackPtr";

	internal static string NotSupported_CreateInstanceWithTypeBuilder => "NotSupported_CreateInstanceWithTypeBuilder";

	internal static string NotSupported_TypeBuilderInstantiation_ResolvingMembers => "NotSupported_TypeBuilderInstantiation_ResolvingMembers";

	internal static string NotSupported_DynamicAssembly => "NotSupported_DynamicAssembly";

	internal static string NotSupported_DynamicMethodFlags => "NotSupported_DynamicMethodFlags";

	internal static string NotSupported_DynamicModule => "NotSupported_DynamicModule";

	internal static string NotSupported_FixedSizeCollection => "NotSupported_FixedSizeCollection";

	internal static string InvalidOperation_SpanOverlappedOperation => "InvalidOperation_SpanOverlappedOperation";

	internal static string InvalidOperation_TimeProviderNullLocalTimeZone => "InvalidOperation_TimeProviderNullLocalTimeZone";

	internal static string InvalidOperation_TimeProviderInvalidTimestampFrequency => "InvalidOperation_TimeProviderInvalidTimestampFrequency";

	internal static string NotSupported_KeyCollectionSet => "NotSupported_KeyCollectionSet";

	internal static string NotSupported_MaxWaitHandles => "NotSupported_MaxWaitHandles";

	internal static string NotSupported_MemStreamNotExpandable => "NotSupported_MemStreamNotExpandable";

	internal static string NotSupported_MustBeModuleBuilder => "NotSupported_MustBeModuleBuilder";

	internal static string NotSupported_NoCodepageData => "NotSupported_NoCodepageData";

	internal static string InvalidOperation_FunctionMissingUnmanagedCallersOnly => "InvalidOperation_FunctionMissingUnmanagedCallersOnly";

	internal static string NotSupported_NonReflectedType => "NotSupported_NonReflectedType";

	internal static string NotImplemented_NoSupportForModOpt => "NotImplemented_NoSupportForModOpt";

	internal static string NotSupported_NoParentDefaultConstructor => "NotSupported_NoParentDefaultConstructor";

	internal static string NotSupported_NoTypeInfo => "NotSupported_NoTypeInfo";

	internal static string NotSupported_NYI => "NotSupported_NYI";

	internal static string NotSupported_ObsoleteResourcesFile => "NotSupported_ObsoleteResourcesFile";

	internal static string NotSupported_OutputStreamUsingTypeBuilder => "NotSupported_OutputStreamUsingTypeBuilder";

	internal static string NotSupported_RangeCollection => "NotSupported_RangeCollection";

	internal static string NotSupported_Reading => "NotSupported_Reading";

	internal static string NotSupported_ReadOnlyCollection => "NotSupported_ReadOnlyCollection";

	internal static string NotSupported_ResourceObjectSerialization => "NotSupported_ResourceObjectSerialization";

	internal static string NotSupported_StringComparison => "NotSupported_StringComparison";

	internal static string NotSupported_SubclassOverride => "NotSupported_SubclassOverride";

	internal static string NotSupported_Type => "NotSupported_Type";

	internal static string NotSupported_UmsSafeBuffer => "NotSupported_UmsSafeBuffer";

	internal static string NotSupported_UnitySerHolder => "NotSupported_UnitySerHolder";

	internal static string NotSupported_UnreadableStream => "NotSupported_UnreadableStream";

	internal static string NotSupported_UnseekableStream => "NotSupported_UnseekableStream";

	internal static string NotSupported_UnwritableStream => "NotSupported_UnwritableStream";

	internal static string NotSupported_ValueCollectionSet => "NotSupported_ValueCollectionSet";

	internal static string NotSupported_Writing => "NotSupported_Writing";

	internal static string NotSupported_WrongResourceReader_Type => "NotSupported_WrongResourceReader_Type";

	internal static string ObjectDisposed_FileClosed => "ObjectDisposed_FileClosed";

	internal static string ObjectDisposed_Generic => "ObjectDisposed_Generic";

	internal static string ObjectDisposed_ObjectName_Name => "ObjectDisposed_ObjectName_Name";

	internal static string ObjectDisposed_WriterClosed => "ObjectDisposed_WriterClosed";

	internal static string ObjectDisposed_ReaderClosed => "ObjectDisposed_ReaderClosed";

	internal static string ObjectDisposed_ResourceSet => "ObjectDisposed_ResourceSet";

	internal static string ObjectDisposed_StreamClosed => "ObjectDisposed_StreamClosed";

	internal static string ObjectDisposed_ViewAccessorClosed => "ObjectDisposed_ViewAccessorClosed";

	internal static string OperationCanceled => "OperationCanceled";

	internal static string Overflow_Byte => "Overflow_Byte";

	internal static string Overflow_Char => "Overflow_Char";

	internal static string Overflow_Currency => "Overflow_Currency";

	internal static string Overflow_Decimal => "Overflow_Decimal";

	internal static string Overflow_Duration => "Overflow_Duration";

	internal static string Overflow_Int16 => "Overflow_Int16";

	internal static string Overflow_Int32 => "Overflow_Int32";

	internal static string Overflow_Int64 => "Overflow_Int64";

	internal static string Overflow_Int128 => "Overflow_Int128";

	internal static string Overflow_MutexReacquireCount => "Overflow_MutexReacquireCount";

	internal static string Overflow_NegateTwosCompNum => "Overflow_NegateTwosCompNum";

	internal static string Overflow_NegativeUnsigned => "Overflow_NegativeUnsigned";

	internal static string Overflow_SByte => "Overflow_SByte";

	internal static string Overflow_TimeSpanElementTooLarge => "Overflow_TimeSpanElementTooLarge";

	internal static string Overflow_TimeSpanTooLong => "Overflow_TimeSpanTooLong";

	internal static string Overflow_UInt16 => "Overflow_UInt16";

	internal static string Overflow_UInt32 => "Overflow_UInt32";

	internal static string Overflow_UInt64 => "Overflow_UInt64";

	internal static string Overflow_UInt128 => "Overflow_UInt128";

	internal static string PlatformNotSupported_ComInterop => "PlatformNotSupported_ComInterop";

	internal static string PlatformNotSupported_NamedSynchronizationPrimitives => "PlatformNotSupported_NamedSynchronizationPrimitives";

	internal static string PlatformNotSupported_ReflectionOnly => "PlatformNotSupported_ReflectionOnly";

	internal static string PlatformNotSupported_Remoting => "PlatformNotSupported_Remoting";

	internal static string PlatformNotSupported_SecureBinarySerialization => "PlatformNotSupported_SecureBinarySerialization";

	internal static string PlatformNotSupported_StrongNameSigning => "PlatformNotSupported_StrongNameSigning";

	internal static string PlatformNotSupported_OverlappedIO => "PlatformNotSupported_OverlappedIO";

	internal static string PlatformNotSupported_AppDomains => "PlatformNotSupported_AppDomains";

	internal static string PlatformNotSupported_CAS => "PlatformNotSupported_CAS";

	internal static string PlatformNotSupported_Principal => "PlatformNotSupported_Principal";

	internal static string PlatformNotSupported_ThreadAbort => "PlatformNotSupported_ThreadAbort";

	internal static string PlatformNotSupported_ThreadSuspend => "PlatformNotSupported_ThreadSuspend";

	internal static string PlatformNotSupported_UserDefinedSubclassesOfType => "PlatformNotSupported_UserDefinedSubclassesOfType";

	internal static string PostconditionFailed => "PostconditionFailed";

	internal static string PostconditionFailed_Cnd => "PostconditionFailed_Cnd";

	internal static string PostconditionOnExceptionFailed => "PostconditionOnExceptionFailed";

	internal static string PostconditionOnExceptionFailed_Cnd => "PostconditionOnExceptionFailed_Cnd";

	internal static string PreconditionFailed => "PreconditionFailed";

	internal static string PreconditionFailed_Cnd => "PreconditionFailed_Cnd";

	internal static string Rank_MultiDimNotSupported => "Rank_MultiDimNotSupported";

	internal static string ResourceReaderIsClosed => "ResourceReaderIsClosed";

	internal static string Resources_StreamNotValid => "Resources_StreamNotValid";

	internal static string InvalidFilterCriteriaException_CritInt => "InvalidFilterCriteriaException_CritInt";

	internal static string InvalidFilterCriteriaException_CritString => "InvalidFilterCriteriaException_CritString";

	internal static string RFLCT_Targ_ITargMismatch_WithType => "RFLCT_Targ_ITargMismatch_WithType";

	internal static string RFLCT_Targ_StatFldReqTarg => "RFLCT_Targ_StatFldReqTarg";

	internal static string RFLCT_Targ_StatMethReqTarg => "RFLCT_Targ_StatMethReqTarg";

	internal static string RuntimeInstanceNotAllowed => "RuntimeInstanceNotAllowed";

	internal static string RuntimeWrappedException => "RuntimeWrappedException";

	internal static string Security_CannotReadFileData => "Security_CannotReadFileData";

	internal static string SemaphoreSlim_ctor_InitialCountWrong => "SemaphoreSlim_ctor_InitialCountWrong";

	internal static string SemaphoreSlim_ctor_MaxCountWrong => "SemaphoreSlim_ctor_MaxCountWrong";

	internal static string SemaphoreSlim_Release_CountWrong => "SemaphoreSlim_Release_CountWrong";

	internal static string SemaphoreSlim_Wait_TimeoutWrong => "SemaphoreSlim_Wait_TimeoutWrong";

	internal static string SemaphoreSlim_Wait_TimeSpanTimeoutWrong => "SemaphoreSlim_Wait_TimeSpanTimeoutWrong";

	internal static string Serialization_BadParameterInfo => "Serialization_BadParameterInfo";

	internal static string Serialization_CorruptField => "Serialization_CorruptField";

	internal static string Serialization_DateTimeTicksOutOfRange => "Serialization_DateTimeTicksOutOfRange";

	internal static string Serialization_DelegatesNotSupported => "Serialization_DelegatesNotSupported";

	internal static string Serialization_InsufficientState => "Serialization_InsufficientState";

	internal static string Serialization_InvalidData => "Serialization_InvalidData";

	internal static string Serialization_InvalidEscapeSequence => "Serialization_InvalidEscapeSequence";

	internal static string Serialization_InvalidOnDeser => "Serialization_InvalidOnDeser";

	internal static string Serialization_InvalidType => "Serialization_InvalidType";

	internal static string Serialization_KeyValueDifferentSizes => "Serialization_KeyValueDifferentSizes";

	internal static string Serialization_MissingDateTimeData => "Serialization_MissingDateTimeData";

	internal static string Serialization_MissingKeys => "Serialization_MissingKeys";

	internal static string Serialization_MissingValues => "Serialization_MissingValues";

	internal static string Serialization_NoParameterInfo => "Serialization_NoParameterInfo";

	internal static string Serialization_NotFound => "Serialization_NotFound";

	internal static string Serialization_NullKey => "Serialization_NullKey";

	internal static string Serialization_OptionalFieldVersionValue => "Serialization_OptionalFieldVersionValue";

	internal static string Serialization_SameNameTwice => "Serialization_SameNameTwice";

	internal static string Serialization_StringBuilderCapacity => "Serialization_StringBuilderCapacity";

	internal static string Serialization_StringBuilderMaxCapacity => "Serialization_StringBuilderMaxCapacity";

	internal static string SetterHasNoParams => "SetterHasNoParams";

	internal static string Lock_Enter_LockRecursionException => "Lock_Enter_LockRecursionException";

	internal static string Lock_Enter_WaiterCountOverflow_OutOfMemoryException => "Lock_Enter_WaiterCountOverflow_OutOfMemoryException";

	internal static string Lock_Exit_SynchronizationLockException => "Lock_Exit_SynchronizationLockException";

	internal static string NamedWaitHandles_IncompatibleNamePrefix => "NamedWaitHandles_IncompatibleNamePrefix";

	internal static string NamedWaitHandles_ExistingObjectIncompatibleWithCurrentUserOnly => "NamedWaitHandles_ExistingObjectIncompatibleWithCurrentUserOnly";

	internal static string SpinLock_IsHeldByCurrentThread => "SpinLock_IsHeldByCurrentThread";

	internal static string SpinLock_TryEnter_ArgumentOutOfRange => "SpinLock_TryEnter_ArgumentOutOfRange";

	internal static string SpinLock_TryEnter_LockRecursionException => "SpinLock_TryEnter_LockRecursionException";

	internal static string SpinLock_TryReliableEnter_ArgumentException => "SpinLock_TryReliableEnter_ArgumentException";

	internal static string SpinWait_SpinUntil_TimeoutWrong => "SpinWait_SpinUntil_TimeoutWrong";

	internal static string StackTrace_InFileILOffset => "StackTrace_InFileILOffset";

	internal static string StackTrace_InFileLineNumber => "StackTrace_InFileLineNumber";

	internal static string TargetInvocation_MethodCannotBeInvoked => "TargetInvocation_MethodCannotBeInvoked";

	internal static string Task_ContinueWith_ESandLR => "Task_ContinueWith_ESandLR";

	internal static string Task_ContinueWith_NotOnAnything => "Task_ContinueWith_NotOnAnything";

	internal static string Task_InvalidTimerTimeSpan => "Task_InvalidTimerTimeSpan";

	internal static string Task_Delay_InvalidMillisecondsDelay => "Task_Delay_InvalidMillisecondsDelay";

	internal static string Task_Dispose_NotCompleted => "Task_Dispose_NotCompleted";

	internal static string Task_FromAsync_LongRunning => "Task_FromAsync_LongRunning";

	internal static string Task_FromAsync_PreferFairness => "Task_FromAsync_PreferFairness";

	internal static string Task_MultiTaskContinuation_EmptyTaskList => "Task_MultiTaskContinuation_EmptyTaskList";

	internal static string Task_MultiTaskContinuation_FireOptions => "Task_MultiTaskContinuation_FireOptions";

	internal static string Task_MultiTaskContinuation_NullTask => "Task_MultiTaskContinuation_NullTask";

	internal static string Task_RunSynchronously_AlreadyStarted => "Task_RunSynchronously_AlreadyStarted";

	internal static string Task_RunSynchronously_Continuation => "Task_RunSynchronously_Continuation";

	internal static string Task_RunSynchronously_Promise => "Task_RunSynchronously_Promise";

	internal static string Task_RunSynchronously_TaskCompleted => "Task_RunSynchronously_TaskCompleted";

	internal static string Task_Start_AlreadyStarted => "Task_Start_AlreadyStarted";

	internal static string Task_Start_ContinuationTask => "Task_Start_ContinuationTask";

	internal static string Task_Start_Promise => "Task_Start_Promise";

	internal static string Task_Start_TaskCompleted => "Task_Start_TaskCompleted";

	internal static string Task_ThrowIfDisposed => "Task_ThrowIfDisposed";

	internal static string Task_WaitMulti_NullTask => "Task_WaitMulti_NullTask";

	internal static string Task_MustBeCompleted => "Task_MustBeCompleted";

	internal static string TaskT_ConfigureAwait_InvalidOptions => "TaskT_ConfigureAwait_InvalidOptions";

	internal static string TaskCanceledException_ctor_DefaultMessage => "TaskCanceledException_ctor_DefaultMessage";

	internal static string TaskCompletionSourceT_TrySetException_NoExceptions => "TaskCompletionSourceT_TrySetException_NoExceptions";

	internal static string TaskCompletionSourceT_TrySetException_NullException => "TaskCompletionSourceT_TrySetException_NullException";

	internal static string TaskExceptionHolder_UnhandledException => "TaskExceptionHolder_UnhandledException";

	internal static string TaskExceptionHolder_UnknownExceptionType => "TaskExceptionHolder_UnknownExceptionType";

	internal static string TaskScheduler_ExecuteTask_WrongTaskScheduler => "TaskScheduler_ExecuteTask_WrongTaskScheduler";

	internal static string TaskScheduler_FromCurrentSynchronizationContext_NoCurrent => "TaskScheduler_FromCurrentSynchronizationContext_NoCurrent";

	internal static string TaskScheduler_InconsistentStateAfterTryExecuteTaskInline => "TaskScheduler_InconsistentStateAfterTryExecuteTaskInline";

	internal static string TaskSchedulerException_ctor_DefaultMessage => "TaskSchedulerException_ctor_DefaultMessage";

	internal static string TaskT_DebuggerNoResult => "TaskT_DebuggerNoResult";

	internal static string TaskT_TransitionToFinal_AlreadyCompleted => "TaskT_TransitionToFinal_AlreadyCompleted";

	internal static string Thread_GetSetCompressedStack_NotSupported => "Thread_GetSetCompressedStack_NotSupported";

	internal static string Thread_Operation_RequiresCurrentThread => "Thread_Operation_RequiresCurrentThread";

	internal static string Threading_AbandonedMutexException => "Threading_AbandonedMutexException";

	internal static string Threading_WaitHandleCannotBeOpenedException => "Threading_WaitHandleCannotBeOpenedException";

	internal static string Threading_WaitHandleCannotBeOpenedException_InvalidHandle => "Threading_WaitHandleCannotBeOpenedException_InvalidHandle";

	internal static string Threading_WaitHandleTooManyPosts => "Threading_WaitHandleTooManyPosts";

	internal static string Threading_SemaphoreFullException => "Threading_SemaphoreFullException";

	internal static string Threading_ThreadInterrupted => "Threading_ThreadInterrupted";

	internal static string ThreadLocal_Value_RecursiveCallsToValue => "ThreadLocal_Value_RecursiveCallsToValue";

	internal static string ThreadLocal_ValuesNotAvailable => "ThreadLocal_ValuesNotAvailable";

	internal static string TimeZoneNotFound_MissingData => "TimeZoneNotFound_MissingData";

	internal static string TypeInitialization_Default => "TypeInitialization_Default";

	internal static string TypeInitialization_Type => "TypeInitialization_Type";

	internal static string TypeLoad_AssemblyEnumContainsMethodsError => "TypeLoad_AssemblyEnumContainsMethodsError";

	internal static string TypeLoad_AssemblyInaccessibleInterfaceError => "TypeLoad_AssemblyInaccessibleInterfaceError";

	internal static string TypeLoad_AssemblySealedParentTypeError => "TypeLoad_AssemblySealedParentTypeError";

	internal static string TypeLoad_ResolveNestedType => "TypeLoad_ResolveNestedType";

	internal static string TypeLoad_ResolveType => "TypeLoad_ResolveType";

	internal static string TypeLoad_ResolveTypeFromAssembly => "TypeLoad_ResolveTypeFromAssembly";

	internal static string UnauthorizedAccess_IODenied_NoPathName => "UnauthorizedAccess_IODenied_NoPathName";

	internal static string UnauthorizedAccess_IODenied_Path => "UnauthorizedAccess_IODenied_Path";

	internal static string UnauthorizedAccess_MemStreamBuffer => "UnauthorizedAccess_MemStreamBuffer";

	internal static string Verification_Exception => "Verification_Exception";

	internal static string Word_At => "Word_At";

	internal static string DebugAssertBanner => "DebugAssertBanner";

	internal static string DebugAssertLongMessage => "DebugAssertLongMessage";

	internal static string DebugAssertShortMessage => "DebugAssertShortMessage";

	internal static string LockRecursionException_ReadAfterWriteNotAllowed => "LockRecursionException_ReadAfterWriteNotAllowed";

	internal static string LockRecursionException_RecursiveReadNotAllowed => "LockRecursionException_RecursiveReadNotAllowed";

	internal static string LockRecursionException_RecursiveWriteNotAllowed => "LockRecursionException_RecursiveWriteNotAllowed";

	internal static string LockRecursionException_RecursiveUpgradeNotAllowed => "LockRecursionException_RecursiveUpgradeNotAllowed";

	internal static string LockRecursionException_WriteAfterReadNotAllowed => "LockRecursionException_WriteAfterReadNotAllowed";

	internal static string SynchronizationLockException_MisMatchedUpgrade => "SynchronizationLockException_MisMatchedUpgrade";

	internal static string SynchronizationLockException_MisMatchedRead => "SynchronizationLockException_MisMatchedRead";

	internal static string SynchronizationLockException_IncorrectDispose => "SynchronizationLockException_IncorrectDispose";

	internal static string LockRecursionException_UpgradeAfterReadNotAllowed => "LockRecursionException_UpgradeAfterReadNotAllowed";

	internal static string LockRecursionException_UpgradeAfterWriteNotAllowed => "LockRecursionException_UpgradeAfterWriteNotAllowed";

	internal static string SynchronizationLockException_MisMatchedWrite => "SynchronizationLockException_MisMatchedWrite";

	internal static string NotSupported_SignatureType => "NotSupported_SignatureType";

	internal static string HashCode_HashCodeNotSupported => "HashCode_HashCodeNotSupported";

	internal static string HashCode_EqualityNotSupported => "HashCode_EqualityNotSupported";

	internal static string Arg_TypeNotSupported => "Arg_TypeNotSupported";

	internal static string IO_InvalidReadLength => "IO_InvalidReadLength";

	internal static string Arg_BasePathNotFullyQualified => "Arg_BasePathNotFullyQualified";

	internal static string Argument_OverlapAlignmentMismatch => "Argument_OverlapAlignmentMismatch";

	internal static string Arg_MustBeNullTerminatedString => "Arg_MustBeNullTerminatedString";

	internal static string ArgumentOutOfRange_Week_ISO => "ArgumentOutOfRange_Week_ISO";

	internal static string Argument_BadPInvokeMethod => "Argument_BadPInvokeMethod";

	internal static string Argument_BadPInvokeOnInterface => "Argument_BadPInvokeOnInterface";

	internal static string Argument_BadTypeDef => "Argument_BadTypeDef";

	internal static string Argument_CannotExtractScalar => "Argument_CannotExtractScalar";

	internal static string Argument_CannotParsePrecision => "Argument_CannotParsePrecision";

	internal static string Argument_GWithPrecisionNotSupported => "Argument_GWithPrecisionNotSupported";

	internal static string Argument_PrecisionTooLarge => "Argument_PrecisionTooLarge";

	internal static string Argument_PropertyClassUnmatchedWithConstructor => "Argument_PropertyClassUnmatchedWithConstructor";

	internal static string Argument_PropertyInvalidType => "Argument_PropertyInvalidType";

	internal static string Argument_PropertyInvalidValue => "Argument_PropertyInvalidValue";

	internal static string Argument_PropertyMissingSetter => "Argument_PropertyMissingSetter";

	internal static string Argument_PropertyUnmatchingPropertyType => "Argument_PropertyUnmatchingPropertyType";

	internal static string Argument_StructArrayTooLarge => "Argument_StructArrayTooLarge";

	internal static string IndexOutOfRange_ArrayWithOffset => "IndexOutOfRange_ArrayWithOffset";

	internal static string Serialization_DangerousDeserialization_Switch => "Serialization_DangerousDeserialization_Switch";

	internal static string Argument_InvalidStartupHookSimpleAssemblyName => "Argument_InvalidStartupHookSimpleAssemblyName";

	internal static string Argument_StartupHookAssemblyLoadFailed => "Argument_StartupHookAssemblyLoadFailed";

	internal static string InvalidOperation_InvalidHandle => "InvalidOperation_InvalidHandle";

	internal static string Argument_SpansMustHaveSameLength => "Argument_SpansMustHaveSameLength";

	internal static string NotSupported_CannotWriteToBufferedStreamIfReadBufferCannotBeFlushed => "NotSupported_CannotWriteToBufferedStreamIfReadBufferCannotBeFlushed";

	internal static string GenericInvalidData => "GenericInvalidData";

	internal static string Argument_ResourceScopeWrongDirection => "Argument_ResourceScopeWrongDirection";

	internal static string ArgumentNull_TypeRequiredByResourceScope => "ArgumentNull_TypeRequiredByResourceScope";

	internal static string Argument_BadResourceScopeTypeBits => "Argument_BadResourceScopeTypeBits";

	internal static string Argument_BadResourceScopeVisibilityBits => "Argument_BadResourceScopeVisibilityBits";

	internal static string Argument_EmptyString => "Argument_EmptyString";

	internal static string Argument_EmptyOrWhiteSpaceString => "Argument_EmptyOrWhiteSpaceString";

	internal static string Argument_FrameworkNameInvalid => "Argument_FrameworkNameInvalid";

	internal static string Argument_FrameworkNameInvalidVersion => "Argument_FrameworkNameInvalidVersion";

	internal static string Argument_FrameworkNameMissingVersion => "Argument_FrameworkNameMissingVersion";

	internal static string Argument_FrameworkNameTooShort => "Argument_FrameworkNameTooShort";

	internal static string Arg_SwitchExpressionException => "Arg_SwitchExpressionException";

	internal static string Arg_ContextMarshalException => "Arg_ContextMarshalException";

	internal static string Arg_AppDomainUnloadedException => "Arg_AppDomainUnloadedException";

	internal static string SwitchExpressionException_UnmatchedValue => "SwitchExpressionException_UnmatchedValue";

	internal static string Encoding_UTF7_Disabled => "Encoding_UTF7_Disabled";

	internal static string Arg_MustBeHalf => "Arg_MustBeHalf";

	internal static string BinaryFormatter_SerializationDisallowed => "BinaryFormatter_SerializationDisallowed";

	internal static string ResourceManager_ReflectionNotAllowed => "ResourceManager_ReflectionNotAllowed";

	internal static string InvalidOperation_AssemblyNotEditable => "InvalidOperation_AssemblyNotEditable";

	internal static string InvalidOperation_EmptyQueue => "InvalidOperation_EmptyQueue";

	internal static string Arg_FileIsDirectory_Name => "Arg_FileIsDirectory_Name";

	internal static string Arg_InvalidFileAttrs => "Arg_InvalidFileAttrs";

	internal static string Arg_InvalidUnixFileMode => "Arg_InvalidUnixFileMode";

	internal static string Arg_Path2IsRooted => "Arg_Path2IsRooted";

	internal static string Argument_InvalidSubPath => "Argument_InvalidSubPath";

	internal static string IO_CannotReplaceSameFile => "IO_CannotReplaceSameFile";

	internal static string IO_NotAFile => "IO_NotAFile";

	internal static string IO_SourceDestMustBeDifferent => "IO_SourceDestMustBeDifferent";

	internal static string PlatformNotSupported_FileEncryption => "PlatformNotSupported_FileEncryption";

	internal static string Arg_MemberInfoNotFound => "Arg_MemberInfoNotFound";

	internal static string InvalidOperation_BadTZHeader => "InvalidOperation_BadTZHeader";

	internal static string InvalidOperation_ReadTZError => "InvalidOperation_ReadTZError";

	internal static string InvalidOperation_BadIndexLength => "InvalidOperation_BadIndexLength";

	internal static string TimeZoneNotFound_ValidTimeZoneFileMissing => "TimeZoneNotFound_ValidTimeZoneFileMissing";

	internal static string ThreadState_Dead_State => "ThreadState_Dead_State";

	internal static string NullReference_InvokeNullRefReturned => "NullReference_InvokeNullRefReturned";

	internal static string PlatformNotSupported_ReflectionEmit => "PlatformNotSupported_ReflectionEmit";

	internal static string NotSupported_IncompleteTypes => "NotSupported_IncompleteTypes";

	internal static string Security_InvalidAssemblyPublicKey => "Security_InvalidAssemblyPublicKey";

	internal static string ClassLoad_General => "ClassLoad_General";

	internal static string ClassLoad_General_Hex => "ClassLoad_General_Hex";

	internal static string ArgumentOutOfRange_NotGreaterThanBufferLength => "ArgumentOutOfRange_NotGreaterThanBufferLength";

	internal static string Argument_AssemblyGetTypeCannotSpecifyAssembly => "Argument_AssemblyGetTypeCannotSpecifyAssembly";

	internal static string NoMetadataTokenAvailable => "NoMetadataTokenAvailable";

	internal static string ArgumentException_InvalidTypeArgument => "ArgumentException_InvalidTypeArgument";

	internal static string Argument_CannotBeByRefType => "Argument_CannotBeByRefType";

	internal static string CannotCreateByRefOfByRef => "CannotCreateByRefOfByRef";

	internal static string CannotCreatePointerOfByRef => "CannotCreatePointerOfByRef";

	internal static string TypeLoad_MethodOverrideNotVirtual => "TypeLoad_MethodOverrideNotVirtual";

	internal static string Argument_DirectorySeparatorInvalid => "Argument_DirectorySeparatorInvalid";

	internal static string InvalidOperation_NotFunctionPointer => "InvalidOperation_NotFunctionPointer";

	internal static string NotSupported_ModifiedType => "NotSupported_ModifiedType";

	internal static string Argument_UnexpectedStateForKnownCallback => "Argument_UnexpectedStateForKnownCallback";

	internal static string OutOfMemory_StringTooLong => "OutOfMemory_StringTooLong";

	internal static string Argument_SearchValues_UnsupportedStringComparison => "Argument_SearchValues_UnsupportedStringComparison";

	internal static string ComVariant_SafeArray_PlatformNotSupported => "ComVariant_SafeArray_PlatformNotSupported";

	internal static string ComVariant_SizeMustMatchVariantSize => "ComVariant_SizeMustMatchVariantSize";

	internal static string ComVariant_TypeIsNotSupportedType => "ComVariant_TypeIsNotSupportedType";

	internal static string ComVariant_VT_DECIMAL_NotSupported_CreateRaw => "ComVariant_VT_DECIMAL_NotSupported_CreateRaw";

	internal static string ComVariant_VT_DECIMAL_NotSupported_RawDataRef => "ComVariant_VT_DECIMAL_NotSupported_RawDataRef";

	internal static string ComVariant_VT_VARIANT_In_Variant => "ComVariant_VT_VARIANT_In_Variant";

	internal static string UnsupportedType => "UnsupportedType";

	internal static string NotSupported_EmitDebugInfo => "NotSupported_EmitDebugInfo";

	internal static string NotSupported_ReferenceEnumOrPrimitiveTypeRequired => "NotSupported_ReferenceEnumOrPrimitiveTypeRequired";

	private static string InternalGetResourceString(string key)
	{
		if (key.Length == 0)
		{
			return key;
		}
		bool lockTaken = false;
		try
		{
			Monitor.Enter(_lock, ref lockTaken);
			if (_currentlyLoading != null && _currentlyLoading.Count > 0 && _currentlyLoading.LastIndexOf(key) >= 0)
			{
				if (_infinitelyRecursingCount > 0)
				{
					return key;
				}
				_infinitelyRecursingCount++;
				Environment.FailFast($"Encountered infinite recursion while looking up resource '{key}' in {"System.Private.CoreLib"}. Verify the installation of .NET is complete and does not need repairing, and that the state of the process has not become corrupted.");
			}
			if (_currentlyLoading == null)
			{
				_currentlyLoading = new List<string>();
			}
			if (!_resourceManagerInited)
			{
				RuntimeHelpers.RunClassConstructor(typeof(ResourceManager).TypeHandle);
				RuntimeHelpers.RunClassConstructor(typeof(ResourceReader).TypeHandle);
				RuntimeHelpers.RunClassConstructor(typeof(RuntimeResourceSet).TypeHandle);
				RuntimeHelpers.RunClassConstructor(typeof(BinaryReader).TypeHandle);
				_resourceManagerInited = true;
			}
			_currentlyLoading.Add(key);
			string text = ResourceManager.GetString(key, null);
			_currentlyLoading.RemoveAt(_currentlyLoading.Count - 1);
			if (text == null)
			{
				text = key;
			}
			return text;
		}
		catch
		{
			if (lockTaken)
			{
				s_resourceManager = null;
				_currentlyLoading = null;
			}
			throw;
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(_lock);
			}
		}
	}

	private static bool GetUsingResourceKeysSwitchValue()
	{
		return true;
	}

	internal static bool UsingResourceKeys()
	{
		return true;
	}

	private static string GetResourceString(string resourceKey)
	{
		_ = 1;
		return resourceKey;
	}

	internal static string Format(string resourceFormat, object p1)
	{
		_ = 1;
		_003C_003Ey__InlineArray2<object> buffer = default(_003C_003Ey__InlineArray2<object>);
		_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<object>, object>(ref buffer, 0) = resourceFormat;
		_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<object>, object>(ref buffer, 1) = p1;
		return string.Join(", ", _003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray2<object>, object>(in buffer, 2));
	}

	internal static string Format(string resourceFormat, object p1, object p2)
	{
		_ = 1;
		_003C_003Ey__InlineArray3<object> buffer = default(_003C_003Ey__InlineArray3<object>);
		_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray3<object>, object>(ref buffer, 0) = resourceFormat;
		_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray3<object>, object>(ref buffer, 1) = p1;
		_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray3<object>, object>(ref buffer, 2) = p2;
		return string.Join(", ", _003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray3<object>, object>(in buffer, 3));
	}

	internal static string Format(string resourceFormat, object p1, object p2, object p3)
	{
		_ = 1;
		_003C_003Ey__InlineArray4<object> buffer = default(_003C_003Ey__InlineArray4<object>);
		_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray4<object>, object>(ref buffer, 0) = resourceFormat;
		_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray4<object>, object>(ref buffer, 1) = p1;
		_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray4<object>, object>(ref buffer, 2) = p2;
		_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray4<object>, object>(ref buffer, 3) = p3;
		return string.Join(", ", _003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray4<object>, object>(in buffer, 4));
	}

	internal static string Format(string resourceFormat, params object[] args)
	{
		if (args != null)
		{
			_ = 1;
			return resourceFormat + ", " + string.Join(", ", args);
		}
		return resourceFormat;
	}

	internal static string Format(IFormatProvider provider, string resourceFormat, object p1)
	{
		_ = 1;
		_003C_003Ey__InlineArray2<object> buffer = default(_003C_003Ey__InlineArray2<object>);
		_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<object>, object>(ref buffer, 0) = resourceFormat;
		_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<object>, object>(ref buffer, 1) = p1;
		return string.Join(", ", _003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray2<object>, object>(in buffer, 2));
	}

	internal static string Format(IFormatProvider provider, string resourceFormat, object p1, object p2)
	{
		_ = 1;
		_003C_003Ey__InlineArray3<object> buffer = default(_003C_003Ey__InlineArray3<object>);
		_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray3<object>, object>(ref buffer, 0) = resourceFormat;
		_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray3<object>, object>(ref buffer, 1) = p1;
		_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray3<object>, object>(ref buffer, 2) = p2;
		return string.Join(", ", _003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray3<object>, object>(in buffer, 3));
	}
}
