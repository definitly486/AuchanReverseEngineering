using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using CsvHelper.Configuration.Attributes;
using CsvHelper.Delegates;

namespace CsvHelper.Configuration;

public record CsvConfiguration : IReaderConfiguration, IParserConfiguration, IWriterConfiguration
{
	public virtual bool AllowComments { get; set; }

	public virtual BadDataFound? BadDataFound { get; set; } = ConfigurationFunctions.BadDataFound;

	public virtual int BufferSize { get; set; } = 4096;

	public virtual bool CacheFields { get; set; }

	public virtual char Comment { get; set; } = '#';

	public virtual bool CountBytes { get; set; }

	public virtual CultureInfo CultureInfo { get; protected internal set; }

	public virtual string Delimiter { get; set; }

	public virtual bool DetectDelimiter { get; set; }

	public virtual GetDelimiter GetDelimiter { get; set; } = ConfigurationFunctions.GetDelimiter;

	public virtual string[] DetectDelimiterValues { get; set; } = new string[4] { ",", ";", "|", "\t" };

	public virtual bool DetectColumnCountChanges { get; set; }

	public virtual IComparer<string>? DynamicPropertySort { get; set; }

	public virtual Encoding Encoding { get; set; } = System.Text.Encoding.UTF8;

	public virtual char Escape { get; set; } = '"';

	public virtual bool ExceptionMessagesContainRawData { get; set; } = true;

	public virtual GetConstructor GetConstructor { get; set; } = ConfigurationFunctions.GetConstructor;

	public virtual GetDynamicPropertyName GetDynamicPropertyName { get; set; } = ConfigurationFunctions.GetDynamicPropertyName;

	public virtual bool HasHeaderRecord { get; set; } = true;

	public virtual HeaderValidated? HeaderValidated { get; set; } = ConfigurationFunctions.HeaderValidated;

	public virtual bool IgnoreBlankLines { get; set; } = true;

	public virtual bool IgnoreReferences { get; set; }

	public virtual bool IncludePrivateMembers { get; set; }

	public virtual char[] InjectionCharacters { get; set; } = new char[6] { '=', '@', '+', '-', '\t', '\r' };

	public virtual char InjectionEscapeCharacter { get; set; } = '\'';

	public virtual InjectionOptions InjectionOptions { get; set; }

	public bool IsNewLineSet { get; private set; }

	public virtual bool LineBreakInQuotedFieldIsBadData { get; set; }

	public double MaxFieldSize { get; set; }

	public virtual MemberTypes MemberTypes { get; set; } = MemberTypes.Properties;

	public virtual MissingFieldFound? MissingFieldFound { get; set; } = ConfigurationFunctions.MissingFieldFound;

	public virtual CsvMode Mode { get; set; }

	public virtual string NewLine
	{
		get
		{
			return newLine;
		}
		set
		{
			IsNewLineSet = true;
			newLine = value;
		}
	}

	public virtual PrepareHeaderForMatch PrepareHeaderForMatch { get; set; } = ConfigurationFunctions.PrepareHeaderForMatch;

	public virtual int ProcessFieldBufferSize { get; set; } = 1024;

	public virtual char Quote { get; set; } = '"';

	public virtual ReadingExceptionOccurred? ReadingExceptionOccurred { get; set; } = ConfigurationFunctions.ReadingExceptionOccurred;

	public virtual ReferenceHeaderPrefix? ReferenceHeaderPrefix { get; set; }

	public ShouldQuote ShouldQuote { get; set; } = ConfigurationFunctions.ShouldQuote;

	public virtual ShouldSkipRecord? ShouldSkipRecord { get; set; }

	public virtual ShouldUseConstructorParameters ShouldUseConstructorParameters { get; set; } = ConfigurationFunctions.ShouldUseConstructorParameters;

	public virtual TrimOptions TrimOptions { get; set; }

	public virtual bool UseNewObjectForNullReferenceMembers { get; set; } = true;

	public virtual char[] WhiteSpaceChars { get; set; } = new char[1] { ' ' };

	private string newLine = "\r\n";

	public CsvConfiguration(CultureInfo cultureInfo)
	{
		CultureInfo = cultureInfo;
		Delimiter = cultureInfo.TextInfo.ListSeparator;
	}

	[Obsolete("This constructor is deprecated and will be removed in the next major release. Use CsvConfiguration(CultureInfo) instead.", false)]
	public CsvConfiguration(CultureInfo cultureInfo, Type attributesType)
	{
		CultureInfo = cultureInfo;
		Delimiter = cultureInfo.TextInfo.ListSeparator;
		ApplyAttributes(attributesType);
	}

	public void Validate()
	{
		string text = Escape.ToString();
		string text2 = Quote.ToString();
		string[] source = new string[3] { "\r", "\n", "\r\n" };
		string[] source2 = WhiteSpaceChars.Select((char c) => c.ToString()).ToArray();
		if (text == Delimiter)
		{
			throw new ConfigurationException($"The escape character '{Escape}' and delimiter '{Delimiter}' cannot be the same.");
		}
		if (text == NewLine && IsNewLineSet)
		{
			throw new ConfigurationException($"The escape character '{Escape}' and new line '{NewLine}' cannot be the same.");
		}
		if (source.Contains(Escape.ToString()) && !IsNewLineSet)
		{
			throw new ConfigurationException($"The escape character '{Escape}' cannot be a line ending. ('\\r', '\\n', '\\r\\n')");
		}
		if (source2.Contains(text))
		{
			throw new ConfigurationException($"The escape character '{Escape}' cannot be a WhiteSpaceChar.");
		}
		if (text2 == Delimiter)
		{
			throw new ConfigurationException($"The quote character '{Quote}' and the delimiter '{Delimiter}' cannot be the same.");
		}
		if (text2 == NewLine && IsNewLineSet)
		{
			throw new ConfigurationException($"The quote character '{Quote}' and new line '{NewLine}' cannot be the same.");
		}
		if (source.Contains(text2))
		{
			throw new ConfigurationException($"The quote character '{Quote}' cannot be a line ending. ('\\r', '\\n', '\\r\\n')");
		}
		if (source2.Contains(text2))
		{
			throw new ConfigurationException($"The quote character '{Quote}' cannot be a WhiteSpaceChar.");
		}
		if (Delimiter == NewLine && IsNewLineSet)
		{
			throw new ConfigurationException($"The delimiter '{Delimiter}' and new line '{NewLine}' cannot be the same.");
		}
		if (source.Contains(Delimiter))
		{
			throw new ConfigurationException("The delimiter '" + Delimiter + "' cannot be a line ending. ('\\r', '\\n', '\\r\\n')");
		}
		if (source2.Contains(Delimiter))
		{
			throw new ConfigurationException("The delimiter '" + Delimiter + "' cannot be a WhiteSpaceChar.");
		}
		if (DetectDelimiter && DetectDelimiterValues.Length == 0)
		{
			throw new ConfigurationException("At least one value is required for DetectDelimiterValues when DetectDelimiter is enabled.");
		}
	}

	public CsvConfiguration ApplyAttributes<T>()
	{
		return ApplyAttributes(typeof(T));
	}

	public CsvConfiguration ApplyAttributes(Type type)
	{
		foreach (IClassMapper item in type.GetCustomAttributes().OfType<IClassMapper>())
		{
			item.ApplyTo(this);
		}
		return this;
	}

	public static CsvConfiguration FromAttributes<T>()
	{
		return FromAttributes(typeof(T));
	}

	public static CsvConfiguration FromAttributes<T>(CultureInfo cultureInfo)
	{
		return FromAttributes(typeof(T), cultureInfo);
	}

	public static CsvConfiguration FromAttributes(Type type)
	{
		if (!Attribute.IsDefined(type, typeof(CultureInfoAttribute)))
		{
			throw new ConfigurationException($"A {"CultureInfoAttribute"} is required on type '{type.Name}' to use this method.");
		}
		CsvConfiguration csvConfiguration = new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture);
		csvConfiguration.ApplyAttributes(type);
		return csvConfiguration;
	}

	public static CsvConfiguration FromAttributes(Type type, CultureInfo cultureInfo)
	{
		CsvConfiguration csvConfiguration = new CsvConfiguration(cultureInfo);
		csvConfiguration.ApplyAttributes(type);
		csvConfiguration.CultureInfo = cultureInfo;
		return csvConfiguration;
	}

	[CompilerGenerated]
	protected virtual bool PrintMembers(StringBuilder builder)
	{
		RuntimeHelpers.EnsureSufficientExecutionStack();
		builder.Append("AllowComments = ");
		builder.Append(AllowComments.ToString());
		builder.Append(", BadDataFound = ");
		builder.Append(BadDataFound);
		builder.Append(", BufferSize = ");
		builder.Append(BufferSize.ToString());
		builder.Append(", CacheFields = ");
		builder.Append(CacheFields.ToString());
		builder.Append(", Comment = ");
		builder.Append(Comment.ToString());
		builder.Append(", CountBytes = ");
		builder.Append(CountBytes.ToString());
		builder.Append(", CultureInfo = ");
		builder.Append(CultureInfo);
		builder.Append(", Delimiter = ");
		builder.Append((object?)Delimiter);
		builder.Append(", DetectDelimiter = ");
		builder.Append(DetectDelimiter.ToString());
		builder.Append(", GetDelimiter = ");
		builder.Append(GetDelimiter);
		builder.Append(", DetectDelimiterValues = ");
		builder.Append(DetectDelimiterValues);
		builder.Append(", DetectColumnCountChanges = ");
		builder.Append(DetectColumnCountChanges.ToString());
		builder.Append(", DynamicPropertySort = ");
		builder.Append(DynamicPropertySort);
		builder.Append(", Encoding = ");
		builder.Append(Encoding);
		builder.Append(", Escape = ");
		builder.Append(Escape.ToString());
		builder.Append(", ExceptionMessagesContainRawData = ");
		builder.Append(ExceptionMessagesContainRawData.ToString());
		builder.Append(", GetConstructor = ");
		builder.Append(GetConstructor);
		builder.Append(", GetDynamicPropertyName = ");
		builder.Append(GetDynamicPropertyName);
		builder.Append(", HasHeaderRecord = ");
		builder.Append(HasHeaderRecord.ToString());
		builder.Append(", HeaderValidated = ");
		builder.Append(HeaderValidated);
		builder.Append(", IgnoreBlankLines = ");
		builder.Append(IgnoreBlankLines.ToString());
		builder.Append(", IgnoreReferences = ");
		builder.Append(IgnoreReferences.ToString());
		builder.Append(", IncludePrivateMembers = ");
		builder.Append(IncludePrivateMembers.ToString());
		builder.Append(", InjectionCharacters = ");
		builder.Append((object?)InjectionCharacters);
		builder.Append(", InjectionEscapeCharacter = ");
		builder.Append(InjectionEscapeCharacter.ToString());
		builder.Append(", InjectionOptions = ");
		builder.Append(InjectionOptions.ToString());
		builder.Append(", IsNewLineSet = ");
		builder.Append(IsNewLineSet.ToString());
		builder.Append(", LineBreakInQuotedFieldIsBadData = ");
		builder.Append(LineBreakInQuotedFieldIsBadData.ToString());
		builder.Append(", MaxFieldSize = ");
		builder.Append(MaxFieldSize.ToString());
		builder.Append(", MemberTypes = ");
		builder.Append(MemberTypes.ToString());
		builder.Append(", MissingFieldFound = ");
		builder.Append(MissingFieldFound);
		builder.Append(", Mode = ");
		builder.Append(Mode.ToString());
		builder.Append(", NewLine = ");
		builder.Append((object?)NewLine);
		builder.Append(", PrepareHeaderForMatch = ");
		builder.Append(PrepareHeaderForMatch);
		builder.Append(", ProcessFieldBufferSize = ");
		builder.Append(ProcessFieldBufferSize.ToString());
		builder.Append(", Quote = ");
		builder.Append(Quote.ToString());
		builder.Append(", ReadingExceptionOccurred = ");
		builder.Append(ReadingExceptionOccurred);
		builder.Append(", ReferenceHeaderPrefix = ");
		builder.Append(ReferenceHeaderPrefix);
		builder.Append(", ShouldQuote = ");
		builder.Append(ShouldQuote);
		builder.Append(", ShouldSkipRecord = ");
		builder.Append(ShouldSkipRecord);
		builder.Append(", ShouldUseConstructorParameters = ");
		builder.Append(ShouldUseConstructorParameters);
		builder.Append(", TrimOptions = ");
		builder.Append(TrimOptions.ToString());
		builder.Append(", UseNewObjectForNullReferenceMembers = ");
		builder.Append(UseNewObjectForNullReferenceMembers.ToString());
		builder.Append(", WhiteSpaceChars = ");
		builder.Append((object?)WhiteSpaceChars);
		return true;
	}

	[CompilerGenerated]
	public override int GetHashCode()
	{
		return (((((((((((((((((((((((((((((((((((((((((((EqualityComparer<Type>.Default.GetHashCode(EqualityContract) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(newLine)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(AllowComments)) * -1521134295 + EqualityComparer<CsvHelper.BadDataFound>.Default.GetHashCode(BadDataFound)) * -1521134295 + EqualityComparer<int>.Default.GetHashCode(BufferSize)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(CacheFields)) * -1521134295 + EqualityComparer<char>.Default.GetHashCode(Comment)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(CountBytes)) * -1521134295 + EqualityComparer<System.Globalization.CultureInfo>.Default.GetHashCode(CultureInfo)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Delimiter)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(DetectDelimiter)) * -1521134295 + EqualityComparer<CsvHelper.Delegates.GetDelimiter>.Default.GetHashCode(GetDelimiter)) * -1521134295 + EqualityComparer<string[]>.Default.GetHashCode(DetectDelimiterValues)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(DetectColumnCountChanges)) * -1521134295 + EqualityComparer<IComparer<string>>.Default.GetHashCode(DynamicPropertySort)) * -1521134295 + EqualityComparer<System.Text.Encoding>.Default.GetHashCode(Encoding)) * -1521134295 + EqualityComparer<char>.Default.GetHashCode(Escape)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(ExceptionMessagesContainRawData)) * -1521134295 + EqualityComparer<CsvHelper.GetConstructor>.Default.GetHashCode(GetConstructor)) * -1521134295 + EqualityComparer<CsvHelper.GetDynamicPropertyName>.Default.GetHashCode(GetDynamicPropertyName)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(HasHeaderRecord)) * -1521134295 + EqualityComparer<CsvHelper.HeaderValidated>.Default.GetHashCode(HeaderValidated)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(IgnoreBlankLines)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(IgnoreReferences)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(IncludePrivateMembers)) * -1521134295 + EqualityComparer<char[]>.Default.GetHashCode(InjectionCharacters)) * -1521134295 + EqualityComparer<char>.Default.GetHashCode(InjectionEscapeCharacter)) * -1521134295 + EqualityComparer<InjectionOptions>.Default.GetHashCode(InjectionOptions)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(IsNewLineSet)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(LineBreakInQuotedFieldIsBadData)) * -1521134295 + EqualityComparer<double>.Default.GetHashCode(MaxFieldSize)) * -1521134295 + EqualityComparer<MemberTypes>.Default.GetHashCode(MemberTypes)) * -1521134295 + EqualityComparer<CsvHelper.MissingFieldFound>.Default.GetHashCode(MissingFieldFound)) * -1521134295 + EqualityComparer<CsvMode>.Default.GetHashCode(Mode)) * -1521134295 + EqualityComparer<CsvHelper.PrepareHeaderForMatch>.Default.GetHashCode(PrepareHeaderForMatch)) * -1521134295 + EqualityComparer<int>.Default.GetHashCode(ProcessFieldBufferSize)) * -1521134295 + EqualityComparer<char>.Default.GetHashCode(Quote)) * -1521134295 + EqualityComparer<CsvHelper.ReadingExceptionOccurred>.Default.GetHashCode(ReadingExceptionOccurred)) * -1521134295 + EqualityComparer<CsvHelper.ReferenceHeaderPrefix>.Default.GetHashCode(ReferenceHeaderPrefix)) * -1521134295 + EqualityComparer<CsvHelper.ShouldQuote>.Default.GetHashCode(ShouldQuote)) * -1521134295 + EqualityComparer<CsvHelper.ShouldSkipRecord>.Default.GetHashCode(ShouldSkipRecord)) * -1521134295 + EqualityComparer<CsvHelper.ShouldUseConstructorParameters>.Default.GetHashCode(ShouldUseConstructorParameters)) * -1521134295 + EqualityComparer<TrimOptions>.Default.GetHashCode(TrimOptions)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(UseNewObjectForNullReferenceMembers)) * -1521134295 + EqualityComparer<char[]>.Default.GetHashCode(WhiteSpaceChars);
	}

	[CompilerGenerated]
	public virtual bool Equals(CsvConfiguration? other)
	{
		if ((object)this != other)
		{
			if ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(newLine, other.newLine) && EqualityComparer<bool>.Default.Equals(AllowComments, other.AllowComments) && EqualityComparer<CsvHelper.BadDataFound>.Default.Equals(BadDataFound, other.BadDataFound) && EqualityComparer<int>.Default.Equals(BufferSize, other.BufferSize) && EqualityComparer<bool>.Default.Equals(CacheFields, other.CacheFields) && EqualityComparer<char>.Default.Equals(Comment, other.Comment) && EqualityComparer<bool>.Default.Equals(CountBytes, other.CountBytes) && EqualityComparer<System.Globalization.CultureInfo>.Default.Equals(CultureInfo, other.CultureInfo) && EqualityComparer<string>.Default.Equals(Delimiter, other.Delimiter) && EqualityComparer<bool>.Default.Equals(DetectDelimiter, other.DetectDelimiter) && EqualityComparer<CsvHelper.Delegates.GetDelimiter>.Default.Equals(GetDelimiter, other.GetDelimiter) && EqualityComparer<string[]>.Default.Equals(DetectDelimiterValues, other.DetectDelimiterValues) && EqualityComparer<bool>.Default.Equals(DetectColumnCountChanges, other.DetectColumnCountChanges) && EqualityComparer<IComparer<string>>.Default.Equals(DynamicPropertySort, other.DynamicPropertySort) && EqualityComparer<System.Text.Encoding>.Default.Equals(Encoding, other.Encoding) && EqualityComparer<char>.Default.Equals(Escape, other.Escape) && EqualityComparer<bool>.Default.Equals(ExceptionMessagesContainRawData, other.ExceptionMessagesContainRawData) && EqualityComparer<CsvHelper.GetConstructor>.Default.Equals(GetConstructor, other.GetConstructor) && EqualityComparer<CsvHelper.GetDynamicPropertyName>.Default.Equals(GetDynamicPropertyName, other.GetDynamicPropertyName) && EqualityComparer<bool>.Default.Equals(HasHeaderRecord, other.HasHeaderRecord) && EqualityComparer<CsvHelper.HeaderValidated>.Default.Equals(HeaderValidated, other.HeaderValidated) && EqualityComparer<bool>.Default.Equals(IgnoreBlankLines, other.IgnoreBlankLines) && EqualityComparer<bool>.Default.Equals(IgnoreReferences, other.IgnoreReferences) && EqualityComparer<bool>.Default.Equals(IncludePrivateMembers, other.IncludePrivateMembers) && EqualityComparer<char[]>.Default.Equals(InjectionCharacters, other.InjectionCharacters) && EqualityComparer<char>.Default.Equals(InjectionEscapeCharacter, other.InjectionEscapeCharacter) && EqualityComparer<InjectionOptions>.Default.Equals(InjectionOptions, other.InjectionOptions) && EqualityComparer<bool>.Default.Equals(IsNewLineSet, other.IsNewLineSet) && EqualityComparer<bool>.Default.Equals(LineBreakInQuotedFieldIsBadData, other.LineBreakInQuotedFieldIsBadData) && EqualityComparer<double>.Default.Equals(MaxFieldSize, other.MaxFieldSize) && EqualityComparer<MemberTypes>.Default.Equals(MemberTypes, other.MemberTypes) && EqualityComparer<CsvHelper.MissingFieldFound>.Default.Equals(MissingFieldFound, other.MissingFieldFound) && EqualityComparer<CsvMode>.Default.Equals(Mode, other.Mode) && EqualityComparer<CsvHelper.PrepareHeaderForMatch>.Default.Equals(PrepareHeaderForMatch, other.PrepareHeaderForMatch) && EqualityComparer<int>.Default.Equals(ProcessFieldBufferSize, other.ProcessFieldBufferSize) && EqualityComparer<char>.Default.Equals(Quote, other.Quote) && EqualityComparer<CsvHelper.ReadingExceptionOccurred>.Default.Equals(ReadingExceptionOccurred, other.ReadingExceptionOccurred) && EqualityComparer<CsvHelper.ReferenceHeaderPrefix>.Default.Equals(ReferenceHeaderPrefix, other.ReferenceHeaderPrefix) && EqualityComparer<CsvHelper.ShouldQuote>.Default.Equals(ShouldQuote, other.ShouldQuote) && EqualityComparer<CsvHelper.ShouldSkipRecord>.Default.Equals(ShouldSkipRecord, other.ShouldSkipRecord) && EqualityComparer<CsvHelper.ShouldUseConstructorParameters>.Default.Equals(ShouldUseConstructorParameters, other.ShouldUseConstructorParameters) && EqualityComparer<TrimOptions>.Default.Equals(TrimOptions, other.TrimOptions) && EqualityComparer<bool>.Default.Equals(UseNewObjectForNullReferenceMembers, other.UseNewObjectForNullReferenceMembers))
			{
				return EqualityComparer<char[]>.Default.Equals(WhiteSpaceChars, other.WhiteSpaceChars);
			}
			return false;
		}
		return true;
	}

	[CompilerGenerated]
	protected CsvConfiguration(CsvConfiguration original)
	{
		newLine = original.newLine;
		AllowComments = original.AllowComments;
		BadDataFound = original.BadDataFound;
		BufferSize = original.BufferSize;
		CacheFields = original.CacheFields;
		Comment = original.Comment;
		CountBytes = original.CountBytes;
		CultureInfo = original.CultureInfo;
		Delimiter = original.Delimiter;
		DetectDelimiter = original.DetectDelimiter;
		GetDelimiter = original.GetDelimiter;
		DetectDelimiterValues = original.DetectDelimiterValues;
		DetectColumnCountChanges = original.DetectColumnCountChanges;
		DynamicPropertySort = original.DynamicPropertySort;
		Encoding = original.Encoding;
		Escape = original.Escape;
		ExceptionMessagesContainRawData = original.ExceptionMessagesContainRawData;
		GetConstructor = original.GetConstructor;
		GetDynamicPropertyName = original.GetDynamicPropertyName;
		HasHeaderRecord = original.HasHeaderRecord;
		HeaderValidated = original.HeaderValidated;
		IgnoreBlankLines = original.IgnoreBlankLines;
		IgnoreReferences = original.IgnoreReferences;
		IncludePrivateMembers = original.IncludePrivateMembers;
		InjectionCharacters = original.InjectionCharacters;
		InjectionEscapeCharacter = original.InjectionEscapeCharacter;
		InjectionOptions = original.InjectionOptions;
		IsNewLineSet = original.IsNewLineSet;
		LineBreakInQuotedFieldIsBadData = original.LineBreakInQuotedFieldIsBadData;
		MaxFieldSize = original.MaxFieldSize;
		MemberTypes = original.MemberTypes;
		MissingFieldFound = original.MissingFieldFound;
		Mode = original.Mode;
		PrepareHeaderForMatch = original.PrepareHeaderForMatch;
		ProcessFieldBufferSize = original.ProcessFieldBufferSize;
		Quote = original.Quote;
		ReadingExceptionOccurred = original.ReadingExceptionOccurred;
		ReferenceHeaderPrefix = original.ReferenceHeaderPrefix;
		ShouldQuote = original.ShouldQuote;
		ShouldSkipRecord = original.ShouldSkipRecord;
		ShouldUseConstructorParameters = original.ShouldUseConstructorParameters;
		TrimOptions = original.TrimOptions;
		UseNewObjectForNullReferenceMembers = original.UseNewObjectForNullReferenceMembers;
		WhiteSpaceChars = original.WhiteSpaceChars;
	}
}
