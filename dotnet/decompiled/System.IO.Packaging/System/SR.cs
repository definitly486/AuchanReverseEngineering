using System.Resources;
using System.Runtime.CompilerServices;
using FxResources.System.IO.Packaging;

namespace System;

internal static class SR
{
	private static ResourceManager s_resourceManager;

	internal static ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new ResourceManager(typeof(SR)));

	internal static string BadPackageFormat => GetResourceString("BadPackageFormat");

	internal static string CannotModifyReadOnlyContainer => GetResourceString("CannotModifyReadOnlyContainer");

	internal static string CannotRetrievePartsOfWriteOnlyContainer => GetResourceString("CannotRetrievePartsOfWriteOnlyContainer");

	internal static string ContainerAndPartModeIncompatible => GetResourceString("ContainerAndPartModeIncompatible");

	internal static string ContentTypeCannotHaveLeadingTrailingLWS => GetResourceString("ContentTypeCannotHaveLeadingTrailingLWS");

	internal static string CreateNewNotSupported => GetResourceString("CreateNewNotSupported");

	internal static string DefaultTagDoesNotMatchSchema => GetResourceString("DefaultTagDoesNotMatchSchema");

	internal static string ElementIsNotEmptyElement => GetResourceString("ElementIsNotEmptyElement");

	internal static string EncodingNotSupported => GetResourceString("EncodingNotSupported");

	internal static string ExpectedRelationshipsElementTag => GetResourceString("ExpectedRelationshipsElementTag");

	internal static string ExpectingParameterValuePairs => GetResourceString("ExpectingParameterValuePairs");

	internal static string ExpectingSemicolon => GetResourceString("ExpectingSemicolon");

	internal static string InvalidLinearWhiteSpaceCharacter => GetResourceString("InvalidLinearWhiteSpaceCharacter");

	internal static string InvalidParameterValue => GetResourceString("InvalidParameterValue");

	internal static string InvalidParameterValuePair => GetResourceString("InvalidParameterValuePair");

	internal static string InvalidPartUri => GetResourceString("InvalidPartUri");

	internal static string InvalidRelationshipType => GetResourceString("InvalidRelationshipType");

	internal static string InvalidToken_ContentType => GetResourceString("InvalidToken_ContentType");

	internal static string InvalidTypeSubType => GetResourceString("InvalidTypeSubType");

	internal static string InvalidValueForTheAttribute => GetResourceString("InvalidValueForTheAttribute");

	internal static string InvalidXmlBaseAttributePresent => GetResourceString("InvalidXmlBaseAttributePresent");

	internal static string NotAUniqueRelationshipId => GetResourceString("NotAUniqueRelationshipId");

	internal static string NotAValidRelationshipPartUri => GetResourceString("NotAValidRelationshipPartUri");

	internal static string NotAValidXmlIdString => GetResourceString("NotAValidXmlIdString");

	internal static string NullStreamReturned => GetResourceString("NullStreamReturned");

	internal static string ObjectDisposed => GetResourceString("ObjectDisposed");

	internal static string OverrideTagDoesNotMatchSchema => GetResourceString("OverrideTagDoesNotMatchSchema");

	internal static string PackagePartDeleted => GetResourceString("PackagePartDeleted");

	internal static string ParentContainerClosed => GetResourceString("ParentContainerClosed");

	internal static string PartAlreadyExists => GetResourceString("PartAlreadyExists");

	internal static string PartDoesNotExist => GetResourceString("PartDoesNotExist");

	internal static string PartNamePrefixExists => GetResourceString("PartNamePrefixExists");

	internal static string PartUriCannotHaveAFragment => GetResourceString("PartUriCannotHaveAFragment");

	internal static string PartUriIsEmpty => GetResourceString("PartUriIsEmpty");

	internal static string PartUriShouldNotEndWithForwardSlash => GetResourceString("PartUriShouldNotEndWithForwardSlash");

	internal static string PartUriShouldNotStartWithTwoForwardSlashes => GetResourceString("PartUriShouldNotStartWithTwoForwardSlashes");

	internal static string PartUriShouldStartWithForwardSlash => GetResourceString("PartUriShouldStartWithForwardSlash");

	internal static string RelationshipPartIncorrectContentType => GetResourceString("RelationshipPartIncorrectContentType");

	internal static string RelationshipPartsCannotHaveRelationships => GetResourceString("RelationshipPartsCannotHaveRelationships");

	internal static string RelationshipPartUriExpected => GetResourceString("RelationshipPartUriExpected");

	internal static string RelationshipPartUriNotExpected => GetResourceString("RelationshipPartUriNotExpected");

	internal static string RelationshipsTagHasExtraAttributes => GetResourceString("RelationshipsTagHasExtraAttributes");

	internal static string RelationshipTagDoesntMatchSchema => GetResourceString("RelationshipTagDoesntMatchSchema");

	internal static string RelationshipTargetMustBeRelative => GetResourceString("RelationshipTargetMustBeRelative");

	internal static string RelationshipToRelationshipIllegal => GetResourceString("RelationshipToRelationshipIllegal");

	internal static string RequiredAttributeEmpty => GetResourceString("RequiredAttributeEmpty");

	internal static string RequiredAttributeMissing => GetResourceString("RequiredAttributeMissing");

	internal static string RequiredRelationshipAttributeMissing => GetResourceString("RequiredRelationshipAttributeMissing");

	internal static string StreamObjectDisposed => GetResourceString("StreamObjectDisposed");

	internal static string TruncateNotSupported => GetResourceString("TruncateNotSupported");

	internal static string TypesElementExpected => GetResourceString("TypesElementExpected");

	internal static string TypesTagHasExtraAttributes => GetResourceString("TypesTagHasExtraAttributes");

	internal static string TypesXmlDoesNotMatchSchema => GetResourceString("TypesXmlDoesNotMatchSchema");

	internal static string UnknownTagEncountered => GetResourceString("UnknownTagEncountered");

	internal static string UnsupportedCombinationOfModeAccess => GetResourceString("UnsupportedCombinationOfModeAccess");

	internal static string URIShouldNotBeAbsolute => GetResourceString("URIShouldNotBeAbsolute");

	internal static string XCRChoiceAfterFallback => GetResourceString("XCRChoiceAfterFallback");

	internal static string XCRChoiceNotFound => GetResourceString("XCRChoiceNotFound");

	internal static string XCRChoiceOnlyInAC => GetResourceString("XCRChoiceOnlyInAC");

	internal static string XCRCompatCycle => GetResourceString("XCRCompatCycle");

	internal static string XCRDuplicatePreserve => GetResourceString("XCRDuplicatePreserve");

	internal static string XCRDuplicateProcessContent => GetResourceString("XCRDuplicateProcessContent");

	internal static string XCRDuplicateWildcardPreserve => GetResourceString("XCRDuplicateWildcardPreserve");

	internal static string XCRDuplicateWildcardProcessContent => GetResourceString("XCRDuplicateWildcardProcessContent");

	internal static string XCRFallbackOnlyInAC => GetResourceString("XCRFallbackOnlyInAC");

	internal static string XCRInvalidACChild => GetResourceString("XCRInvalidACChild");

	internal static string XCRInvalidAttribInElement => GetResourceString("XCRInvalidAttribInElement");

	internal static string XCRInvalidFormat => GetResourceString("XCRInvalidFormat");

	internal static string XCRInvalidPreserve => GetResourceString("XCRInvalidPreserve");

	internal static string XCRInvalidProcessContent => GetResourceString("XCRInvalidProcessContent");

	internal static string XCRInvalidRequiresAttribute => GetResourceString("XCRInvalidRequiresAttribute");

	internal static string XCRInvalidXMLName => GetResourceString("XCRInvalidXMLName");

	internal static string XCRMultipleFallbackFound => GetResourceString("XCRMultipleFallbackFound");

	internal static string XCRMustUnderstandFailed => GetResourceString("XCRMustUnderstandFailed");

	internal static string XCRNSPreserveNotIgnorable => GetResourceString("XCRNSPreserveNotIgnorable");

	internal static string XCRNSProcessContentNotIgnorable => GetResourceString("XCRNSProcessContentNotIgnorable");

	internal static string XCRRequiresAttribNotFound => GetResourceString("XCRRequiresAttribNotFound");

	internal static string XCRUndefinedPrefix => GetResourceString("XCRUndefinedPrefix");

	internal static string XCRUnknownCompatAttrib => GetResourceString("XCRUnknownCompatAttrib");

	internal static string XCRUnknownCompatElement => GetResourceString("XCRUnknownCompatElement");

	internal static string CreateNewOnNonEmptyStream => GetResourceString("CreateNewOnNonEmptyStream");

	internal static string ZipZeroSizeFileIsNotValidArchive => GetResourceString("ZipZeroSizeFileIsNotValidArchive");

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool UsingResourceKeys()
	{
		return false;
	}

	internal static string GetResourceString(string resourceKey, string defaultString = null)
	{
		if (UsingResourceKeys())
		{
			return defaultString ?? resourceKey;
		}
		string text = null;
		try
		{
			text = ResourceManager.GetString(resourceKey);
		}
		catch (MissingManifestResourceException)
		{
		}
		if (defaultString != null && resourceKey.Equals(text))
		{
			return defaultString;
		}
		return text;
	}

	internal static string Format(string resourceFormat, object p1)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1);
		}
		return string.Format(resourceFormat, p1);
	}

	internal static string Format(string resourceFormat, object p1, object p2)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2);
		}
		return string.Format(resourceFormat, p1, p2);
	}
}
