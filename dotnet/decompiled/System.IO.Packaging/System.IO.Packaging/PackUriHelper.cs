namespace System.IO.Packaging;

public static class PackUriHelper
{
	internal sealed class ValidatedPartUri : Uri, IComparable<ValidatedPartUri>, IEquatable<ValidatedPartUri>
	{
		private string _partUriString;

		private string _normalizedPartUriString;

		private string _partUriExtension;

		private bool _isNormalized;

		private bool _isRelationshipPartUri;

		private static readonly string s_relationshipPartUpperCaseExtension = ".RELS";

		private static readonly string s_relationshipPartUpperCaseSegmentName = "_RELS";

		private static readonly string s_relsrelsUpperCaseExtension = s_relationshipPartUpperCaseExtension + s_relationshipPartUpperCaseExtension;

		private static readonly Uri s_containerRelationshipNormalizedPartUri = new ValidatedPartUri("/_RELS/.RELS", isNormalized: true, computeIsRelationship: false, isRelationshipPartUri: true);

		internal string PartUriString => _partUriString;

		internal string PartUriExtension
		{
			get
			{
				if (_partUriExtension == null)
				{
					_partUriExtension = Path.GetExtension(_partUriString);
					if (_partUriExtension.Length > 0)
					{
						_partUriExtension = _partUriExtension.Substring(1);
					}
				}
				return _partUriExtension;
			}
		}

		internal string NormalizedPartUriString
		{
			get
			{
				if (_normalizedPartUriString == null)
				{
					_normalizedPartUriString = GetNormalizedPartUriString();
				}
				return _normalizedPartUriString;
			}
		}

		internal bool IsRelationshipPartUri => _isRelationshipPartUri;

		internal ValidatedPartUri(string partUriString)
			: this(partUriString, isNormalized: false, computeIsRelationship: true, isRelationshipPartUri: false)
		{
		}

		internal ValidatedPartUri(string partUriString, bool isRelationshipUri)
			: this(partUriString, isNormalized: false, computeIsRelationship: false, isRelationshipUri)
		{
		}

		int IComparable<ValidatedPartUri>.CompareTo(ValidatedPartUri otherPartUri)
		{
			return Compare(otherPartUri);
		}

		bool IEquatable<ValidatedPartUri>.Equals(ValidatedPartUri otherPartUri)
		{
			return Compare(otherPartUri) == 0;
		}

		private ValidatedPartUri(string partUriString, bool isNormalized, bool computeIsRelationship, bool isRelationshipPartUri)
			: base(partUriString, UriKind.Relative)
		{
			_partUriString = partUriString;
			_isNormalized = isNormalized;
			if (computeIsRelationship)
			{
				_isRelationshipPartUri = IsRelationshipUri();
			}
			else
			{
				_isRelationshipPartUri = isRelationshipPartUri;
			}
		}

		private bool IsRelationshipUri()
		{
			bool flag = false;
			if (!NormalizedPartUriString.EndsWith(s_relationshipPartUpperCaseExtension, StringComparison.Ordinal))
			{
				return false;
			}
			if (ComparePartUri(s_containerRelationshipNormalizedPartUri, this) == 0)
			{
				return true;
			}
			string[] array = NormalizedPartUriString.Split(s_forwardSlashCharArray);
			if (array.Length >= 3 && array[^1].Length > s_relationshipPartExtensionName.Length)
			{
				flag = string.CompareOrdinal(array[^2], s_relationshipPartUpperCaseSegmentName) == 0;
			}
			if (array.Length > 3 && flag && array[^1].EndsWith(s_relsrelsUpperCaseExtension, StringComparison.Ordinal) && string.CompareOrdinal(array[^3], s_relationshipPartUpperCaseSegmentName) == 0)
			{
				throw new ArgumentException(System.SR.NotAValidRelationshipPartUri);
			}
			return flag;
		}

		private string GetNormalizedPartUriString()
		{
			if (_isNormalized)
			{
				return _partUriString;
			}
			return _partUriString.ToUpperInvariant();
		}

		private int Compare(ValidatedPartUri otherPartUri)
		{
			if (otherPartUri == null)
			{
				return 1;
			}
			return string.CompareOrdinal(NormalizedPartUriString, otherPartUri.NormalizedPartUriString);
		}
	}

	private static readonly char[] HexUpperChars;

	private static readonly Uri s_defaultUri;

	private static readonly Uri s_packageRootUri;

	private static readonly char[] s_specialCharacterChars;

	private static readonly string s_relationshipPartSegmentName;

	private static readonly string s_relationshipPartExtensionName;

	internal static readonly char[] s_forwardSlashCharArray;

	internal static readonly char BackwardSlashChar;

	public static readonly string UriSchemePack;

	internal static Uri PackageRootUri => s_packageRootUri;

	public static Uri CreatePartUri(Uri partUri)
	{
		if (partUri == null)
		{
			throw new ArgumentNullException("partUri");
		}
		ThrowIfAbsoluteUri(partUri);
		string components = partUri.GetComponents(UriComponents.SerializationInfoString, UriFormat.SafeUnescaped);
		ThrowIfPartNameStartsWithTwoSlashes(components);
		ThrowIfFragmentPresent(components);
		Uri partUri2 = new Uri(s_defaultUri, partUri);
		string stringForPartUriFromAnyUri = GetStringForPartUriFromAnyUri(partUri2);
		if (stringForPartUriFromAnyUri == string.Empty)
		{
			throw new ArgumentException(System.SR.PartUriIsEmpty);
		}
		ThrowIfPartNameEndsWithSlash(stringForPartUriFromAnyUri);
		return new ValidatedPartUri(stringForPartUriFromAnyUri);
	}

	public static Uri ResolvePartUri(Uri sourcePartUri, Uri targetUri)
	{
		if (sourcePartUri == null)
		{
			throw new ArgumentNullException("sourcePartUri");
		}
		if (targetUri == null)
		{
			throw new ArgumentNullException("targetUri");
		}
		ThrowIfAbsoluteUri(sourcePartUri);
		ThrowIfAbsoluteUri(targetUri);
		Uri uri = ((!(sourcePartUri == PackageRootUri)) ? new Uri(new Uri(s_defaultUri, ValidatePartUri(sourcePartUri)), targetUri) : new Uri(s_defaultUri, targetUri));
		return new Uri(uri.AbsolutePath, UriKind.Relative);
	}

	public static int ComparePartUri(Uri firstPartUri, Uri secondPartUri)
	{
		if (firstPartUri != null)
		{
			firstPartUri = ValidatePartUri(firstPartUri);
		}
		if (secondPartUri != null)
		{
			secondPartUri = ValidatePartUri(secondPartUri);
		}
		if (firstPartUri == null || secondPartUri == null)
		{
			return CompareUsingSystemUri(firstPartUri, secondPartUri);
		}
		return ((IComparable<ValidatedPartUri>)firstPartUri).CompareTo((ValidatedPartUri)secondPartUri);
	}

	public static bool IsRelationshipPartUri(Uri partUri)
	{
		if (partUri == null)
		{
			throw new ArgumentNullException("partUri");
		}
		if (!(partUri is ValidatedPartUri))
		{
			partUri = ValidatePartUri(partUri);
		}
		return ((ValidatedPartUri)partUri).IsRelationshipPartUri;
	}

	public static Uri GetRelationshipPartUri(Uri partUri)
	{
		if (partUri == null)
		{
			throw new ArgumentNullException("partUri");
		}
		if (Uri.Compare(partUri, PackageRootUri, UriComponents.SerializationInfoString, UriFormat.UriEscaped, StringComparison.Ordinal) == 0)
		{
			return PackageRelationship.ContainerRelationshipPartName;
		}
		partUri = ValidatePartUri(partUri);
		if (IsRelationshipPartUri(partUri))
		{
			throw new ArgumentException(System.SR.RelationshipPartUriNotExpected);
		}
		string partUriString = ((ValidatedPartUri)partUri).PartUriString;
		string fileName = Path.GetFileName(partUriString);
		partUriString = partUriString.Substring(0, partUriString.Length - fileName.Length);
		partUriString = Path.Combine(partUriString, s_relationshipPartSegmentName, fileName);
		partUriString = partUriString.Replace(BackwardSlashChar, '/');
		partUriString += s_relationshipPartExtensionName;
		return new ValidatedPartUri(partUriString, isRelationshipUri: true);
	}

	public static Uri GetSourcePartUriFromRelationshipPartUri(Uri relationshipPartUri)
	{
		if (relationshipPartUri == null)
		{
			throw new ArgumentNullException("relationshipPartUri");
		}
		relationshipPartUri = ValidatePartUri(relationshipPartUri);
		if (!IsRelationshipPartUri(relationshipPartUri))
		{
			throw new ArgumentException(System.SR.RelationshipPartUriExpected);
		}
		if (ComparePartUri(PackageRelationship.ContainerRelationshipPartName, relationshipPartUri) == 0)
		{
			return PackageRootUri;
		}
		string partUriString = ((ValidatedPartUri)relationshipPartUri).PartUriString;
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(partUriString);
		partUriString = partUriString.Substring(0, partUriString.Length - fileNameWithoutExtension.Length - s_relationshipPartExtensionName.Length - 1);
		partUriString = partUriString.Substring(0, partUriString.Length - s_relationshipPartSegmentName.Length);
		partUriString = Path.Combine(partUriString, fileNameWithoutExtension);
		partUriString = partUriString.Replace(BackwardSlashChar, '/');
		return new ValidatedPartUri(partUriString, isRelationshipUri: false);
	}

	internal static bool TryValidatePartUri(Uri partUri, out ValidatedPartUri validatedPartUri)
	{
		ValidatedPartUri validatedPartUri2 = partUri as ValidatedPartUri;
		if (validatedPartUri2 != null)
		{
			validatedPartUri = validatedPartUri2;
			return true;
		}
		string partUriString;
		Exception exceptionIfPartUriInvalid = GetExceptionIfPartUriInvalid(partUri, out partUriString);
		if (exceptionIfPartUriInvalid != null)
		{
			validatedPartUri = null;
			return false;
		}
		validatedPartUri = new ValidatedPartUri(partUriString);
		return true;
	}

	internal static ValidatedPartUri ValidatePartUri(Uri partUri)
	{
		ValidatedPartUri validatedPartUri = partUri as ValidatedPartUri;
		if (validatedPartUri != null)
		{
			return validatedPartUri;
		}
		string partUriString;
		Exception exceptionIfPartUriInvalid = GetExceptionIfPartUriInvalid(partUri, out partUriString);
		if (exceptionIfPartUriInvalid != null)
		{
			throw exceptionIfPartUriInvalid;
		}
		return new ValidatedPartUri(partUriString);
	}

	internal static string GetStringForPartUri(Uri partUri)
	{
		ValidatedPartUri validatedPartUri = (partUri as ValidatedPartUri) ?? ValidatePartUri(partUri);
		return validatedPartUri.PartUriString;
	}

	private static Exception GetExceptionIfPartUriInvalid(Uri partUri, out string partUriString)
	{
		partUriString = string.Empty;
		if (partUri == null)
		{
			return new ArgumentNullException("partUri");
		}
		Exception ex = null;
		ex = GetExceptionIfAbsoluteUri(partUri);
		if (ex != null)
		{
			return ex;
		}
		string stringForPartUriFromAnyUri = GetStringForPartUriFromAnyUri(partUri);
		if (stringForPartUriFromAnyUri == string.Empty)
		{
			return new ArgumentException(System.SR.PartUriIsEmpty);
		}
		if (stringForPartUriFromAnyUri[0] != '/')
		{
			return new ArgumentException(System.SR.PartUriShouldStartWithForwardSlash);
		}
		ex = GetExceptionIfPartNameStartsWithTwoSlashes(stringForPartUriFromAnyUri);
		if (ex != null)
		{
			return ex;
		}
		ex = GetExceptionIfPartNameEndsWithSlash(stringForPartUriFromAnyUri);
		if (ex != null)
		{
			return ex;
		}
		ex = GetExceptionIfFragmentPresent(stringForPartUriFromAnyUri);
		if (ex != null)
		{
			return ex;
		}
		string components = new Uri(s_defaultUri, stringForPartUriFromAnyUri).GetComponents(UriComponents.Path | UriComponents.KeepDelimiter, UriFormat.UriEscaped);
		if (!string.Equals(partUri.OriginalString, components, StringComparison.OrdinalIgnoreCase))
		{
			return new ArgumentException(System.SR.InvalidPartUri);
		}
		partUriString = stringForPartUriFromAnyUri;
		return null;
	}

	private static void ThrowIfAbsoluteUri(Uri uri)
	{
		Exception exceptionIfAbsoluteUri = GetExceptionIfAbsoluteUri(uri);
		if (exceptionIfAbsoluteUri != null)
		{
			throw exceptionIfAbsoluteUri;
		}
	}

	private static ArgumentException GetExceptionIfAbsoluteUri(Uri uri)
	{
		if (uri.IsAbsoluteUri)
		{
			return new ArgumentException(System.SR.URIShouldNotBeAbsolute);
		}
		return null;
	}

	private static void ThrowIfFragmentPresent(string partName)
	{
		Exception exceptionIfFragmentPresent = GetExceptionIfFragmentPresent(partName);
		if (exceptionIfFragmentPresent != null)
		{
			throw exceptionIfFragmentPresent;
		}
	}

	private static ArgumentException GetExceptionIfFragmentPresent(string partName)
	{
		if (partName.Contains("#"))
		{
			return new ArgumentException(System.SR.PartUriCannotHaveAFragment);
		}
		return null;
	}

	private static void ThrowIfPartNameEndsWithSlash(string partName)
	{
		Exception exceptionIfPartNameEndsWithSlash = GetExceptionIfPartNameEndsWithSlash(partName);
		if (exceptionIfPartNameEndsWithSlash != null)
		{
			throw exceptionIfPartNameEndsWithSlash;
		}
	}

	private static ArgumentException GetExceptionIfPartNameEndsWithSlash(string partName)
	{
		if (partName.Length > 0 && partName[partName.Length - 1] == '/')
		{
			return new ArgumentException(System.SR.PartUriShouldNotEndWithForwardSlash);
		}
		return null;
	}

	private static void ThrowIfPartNameStartsWithTwoSlashes(string partName)
	{
		Exception exceptionIfPartNameStartsWithTwoSlashes = GetExceptionIfPartNameStartsWithTwoSlashes(partName);
		if (exceptionIfPartNameStartsWithTwoSlashes != null)
		{
			throw exceptionIfPartNameStartsWithTwoSlashes;
		}
	}

	private static ArgumentException GetExceptionIfPartNameStartsWithTwoSlashes(string partName)
	{
		if (partName.Length > 1 && partName[0] == '/' && partName[1] == '/')
		{
			return new ArgumentException(System.SR.PartUriShouldNotStartWithTwoForwardSlashes);
		}
		return null;
	}

	private static int CompareUsingSystemUri(Uri firstUri, Uri secondUri)
	{
		return Uri.Compare(firstUri, secondUri, UriComponents.HttpRequestUrl | UriComponents.UserInfo, UriFormat.UriEscaped, StringComparison.Ordinal);
	}

	private static string GetStringForPartUriFromAnyUri(Uri partUri)
	{
		Uri uri = (partUri.IsAbsoluteUri ? new Uri(partUri.GetComponents(UriComponents.Path | UriComponents.KeepDelimiter, UriFormat.SafeUnescaped), UriKind.Relative) : new Uri(partUri.GetComponents(UriComponents.SerializationInfoString, UriFormat.SafeUnescaped), UriKind.Relative));
		string components = uri.GetComponents(UriComponents.SerializationInfoString, UriFormat.UriEscaped);
		if (IsPartNameEmpty(components))
		{
			return string.Empty;
		}
		return components;
	}

	private static bool IsPartNameEmpty(string partName)
	{
		if (partName.Length != 0)
		{
			if (partName.Length == 1)
			{
				return partName[0] == '/';
			}
			return false;
		}
		return true;
	}

	static PackUriHelper()
	{
		HexUpperChars = new char[16]
		{
			'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
			'A', 'B', 'C', 'D', 'E', 'F'
		};
		s_defaultUri = new Uri("http://defaultcontainer/");
		s_packageRootUri = new Uri("/", UriKind.Relative);
		s_specialCharacterChars = new char[4] { '%', '@', ',', '?' };
		s_relationshipPartSegmentName = "_rels";
		s_relationshipPartExtensionName = ".rels";
		s_forwardSlashCharArray = new char[1] { '/' };
		BackwardSlashChar = '\\';
		UriSchemePack = "pack";
		EnsurePackSchemeRegistered();
	}

	private static void EnsurePackSchemeRegistered()
	{
		if (!UriParser.IsKnownScheme(UriSchemePack))
		{
			UriParser.Register(new GenericUriParser(GenericUriParserOptions.GenericAuthority), UriSchemePack, -1);
		}
	}
}
