using System.CodeDom.Compiler;
using System.Collections;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;

namespace System.Xml.Schema;

internal sealed class StringFacetsChecker : FacetsChecker
{
	[GeneratedRegex("^([a-zA-Z]{1,8})(-[a-zA-Z0-9]{1,8})*$", RegexOptions.ExplicitCapture)]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
	private static Regex LanguageRegex => _003CRegexGenerator_g_003EFDF9C3DD1950D4D7B8B347669B6239C35F6E25E5E004EB92EF720F50C72190EE5__LanguageRegex_2.Instance;

	internal override Exception CheckValueFacets(object value, XmlSchemaDatatype datatype)
	{
		return CheckValueFacets(datatype.ValueConverter.ToString(value), datatype, verifyUri: true);
	}

	internal override Exception CheckValueFacets(string value, XmlSchemaDatatype datatype)
	{
		return CheckValueFacets(value, datatype, verifyUri: true);
	}

	internal static Exception CheckValueFacets(string value, XmlSchemaDatatype datatype, bool verifyUri)
	{
		int length = value.Length;
		RestrictionFacets restriction = datatype.Restriction;
		RestrictionFlags restrictionFlags = restriction?.Flags ?? ((RestrictionFlags)0);
		Exception ex = CheckBuiltInFacets(value, datatype.TypeCode, verifyUri);
		if (ex != null)
		{
			return ex;
		}
		if (restrictionFlags != 0)
		{
			if ((restrictionFlags & RestrictionFlags.Length) != 0 && restriction.Length != length)
			{
				return new XmlSchemaException("Sch_LengthConstraintFailed", string.Empty);
			}
			if ((restrictionFlags & RestrictionFlags.MinLength) != 0 && length < restriction.MinLength)
			{
				return new XmlSchemaException("Sch_MinLengthConstraintFailed", string.Empty);
			}
			if ((restrictionFlags & RestrictionFlags.MaxLength) != 0 && restriction.MaxLength < length)
			{
				return new XmlSchemaException("Sch_MaxLengthConstraintFailed", string.Empty);
			}
			if ((restrictionFlags & RestrictionFlags.Enumeration) != 0 && !MatchEnumeration(value, restriction.Enumeration, datatype))
			{
				return new XmlSchemaException("Sch_EnumerationConstraintFailed", string.Empty);
			}
		}
		return null;
	}

	internal override bool MatchEnumeration(object value, ArrayList enumeration, XmlSchemaDatatype datatype)
	{
		return MatchEnumeration(datatype.ValueConverter.ToString(value), enumeration, datatype);
	}

	private static bool MatchEnumeration(string value, ArrayList enumeration, XmlSchemaDatatype datatype)
	{
		if (datatype.TypeCode == XmlTypeCode.AnyUri)
		{
			for (int i = 0; i < enumeration.Count; i++)
			{
				if (value.Equals(((Uri)enumeration[i]).OriginalString))
				{
					return true;
				}
			}
		}
		else
		{
			for (int j = 0; j < enumeration.Count; j++)
			{
				if (value.Equals((string)enumeration[j]))
				{
					return true;
				}
			}
		}
		return false;
	}

	private static Exception CheckBuiltInFacets(string s, XmlTypeCode typeCode, bool verifyUri)
	{
		Exception result = null;
		switch (typeCode)
		{
		case XmlTypeCode.AnyUri:
			if (verifyUri)
			{
				result = XmlConvert.TryToUri(s, out var _);
			}
			break;
		case XmlTypeCode.NormalizedString:
			result = XmlConvert.TryVerifyNormalizedString(s);
			break;
		case XmlTypeCode.Token:
			result = XmlConvert.TryVerifyTOKEN(s);
			break;
		case XmlTypeCode.Language:
			if (string.IsNullOrEmpty(s))
			{
				return new XmlSchemaException("Sch_EmptyAttributeValue", string.Empty);
			}
			if (!LanguageRegex.IsMatch(s))
			{
				return new XmlSchemaException("Sch_InvalidLanguageId", string.Empty);
			}
			break;
		case XmlTypeCode.NmToken:
			result = XmlConvert.TryVerifyNMTOKEN(s);
			break;
		case XmlTypeCode.Name:
			result = XmlConvert.TryVerifyName(s);
			break;
		case XmlTypeCode.NCName:
		case XmlTypeCode.Id:
		case XmlTypeCode.Idref:
		case XmlTypeCode.Entity:
			result = XmlConvert.TryVerifyNCName(s);
			break;
		}
		return result;
	}
}
