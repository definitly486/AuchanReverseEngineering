using System;
using System.Runtime.Versioning;

namespace Android.Text;

[Flags]
public enum InputTypes
{
	ClassDatetime = 4,
	ClassNumber = 2,
	ClassPhone = 3,
	ClassText = 1,
	DatetimeVariationDate = 0x10,
	DatetimeVariationNormal = 0,
	DatetimeVariationTime = 0x20,
	MaskClass = 0xF,
	MaskFlags = 0xFFF000,
	MaskVariation = 0xFF0,
	Null = 0,
	NumberFlagDecimal = 0x2000,
	NumberFlagSigned = 0x1000,
	NumberVariationNormal = 0,
	NumberVariationPassword = 0x10,
	TextFlagAutoComplete = 0x10000,
	TextFlagAutoCorrect = 0x8000,
	TextFlagCapCharacters = 0x1000,
	TextFlagCapSentences = 0x4000,
	TextFlagCapWords = 0x2000,
	[SupportedOSPlatform("android33.0")]
	TextFlagEnableTextConversionSuggestions = 0x100000,
	TextFlagImeMultiLine = 0x40000,
	TextFlagMultiLine = 0x20000,
	TextFlagNoSuggestions = 0x80000,
	TextVariationEmailAddress = 0x20,
	TextVariationEmailSubject = 0x30,
	TextVariationFilter = 0xB0,
	TextVariationLongMessage = 0x50,
	TextVariationNormal = 0,
	TextVariationPassword = 0x80,
	TextVariationPersonName = 0x60,
	TextVariationPhonetic = 0xC0,
	TextVariationPostalAddress = 0x70,
	TextVariationShortMessage = 0x40,
	TextVariationUri = 0x10,
	TextVariationVisiblePassword = 0x90,
	TextVariationWebEditText = 0xA0,
	TextVariationWebEmailAddress = 0xD0,
	TextVariationWebPassword = 0xE0
}
