using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using CsvHelper.Delegates;

namespace CsvHelper;

public class CsvParser : IParser, IDisposable
{
	[DebuggerDisplay("Start = {Start}, Length = {Length}, Buffer.Length = {Buffer.Length}")]
	protected readonly struct ProcessedField
	{
		public readonly int Start;

		public readonly int Length;

		public readonly char[] Buffer;

		public ProcessedField(int start, int length, char[] buffer)
		{
			Start = start;
			Length = length;
			Buffer = buffer;
		}
	}

	private enum ReadLineResult
	{
		None,
		Complete,
		Incomplete
	}

	private enum ParserState
	{
		None,
		Spaces,
		BlankLine,
		Delimiter,
		LineEnding,
		NewLine
	}

	[DebuggerDisplay("Start = {Start}, Length = {Length}, QuoteCount = {QuoteCount}, IsBad = {IsBad}")]
	private struct Field
	{
		public int Start;

		public int Length;

		public int QuoteCount;

		public bool IsBad;

		public bool IsProcessed;
	}

	private readonly IParserConfiguration configuration;

	private readonly FieldCache fieldCache = new FieldCache();

	private readonly TextReader reader;

	private readonly char quote;

	private readonly char escape;

	private readonly bool countBytes;

	private readonly Encoding encoding;

	private readonly bool ignoreBlankLines;

	private readonly char comment;

	private readonly bool allowComments;

	private readonly BadDataFound? badDataFound;

	private readonly bool lineBreakInQuotedFieldIsBadData;

	private readonly TrimOptions trimOptions;

	private readonly char[] whiteSpaceChars;

	private readonly bool leaveOpen;

	private readonly CsvMode mode;

	private readonly string newLine;

	private readonly char newLineFirstChar;

	private readonly bool isNewLineSet;

	private readonly bool cacheFields;

	private readonly string[] delimiterValues;

	private readonly bool detectDelimiter;

	private readonly double maxFieldSize;

	private string delimiter;

	private char delimiterFirstChar;

	private char[] buffer;

	private int bufferSize;

	private int charsRead;

	private int bufferPosition;

	private int rowStartPosition;

	private int fieldStartPosition;

	private int row;

	private int rawRow;

	private long charCount;

	private long byteCount;

	private bool inQuotes;

	private bool inEscape;

	private Field[] fields;

	private string[] processedFields;

	private int fieldsPosition;

	private bool disposed;

	private int quoteCount;

	private char[] processFieldBuffer;

	private int processFieldBufferSize;

	private ParserState state;

	private int delimiterPosition = 1;

	private int newLinePosition = 1;

	private bool fieldIsBadData;

	private bool fieldIsQuoted;

	private bool isProcessingField;

	private bool isRecordProcessed;

	private string[] record = Array.Empty<string>();

	public long CharCount => charCount;

	public long ByteCount => byteCount;

	public int Row => row;

	public string[]? Record
	{
		get
		{
			if (isRecordProcessed)
			{
				return record;
			}
			if (fieldsPosition == 0)
			{
				return null;
			}
			string[] array = new string[fieldsPosition];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = this[i];
			}
			record = array;
			isRecordProcessed = true;
			return record;
		}
	}

	public string RawRecord => new string(buffer, rowStartPosition, bufferPosition - rowStartPosition);

	public int Count => fieldsPosition;

	public int RawRow => rawRow;

	public string Delimiter => delimiter;

	public CsvContext Context { get; private set; }

	public IParserConfiguration Configuration => configuration;

	public string this[int index]
	{
		get
		{
			if (isProcessingField)
			{
				string message = "You can't access IParser[int] or IParser.Record inside of the BadDataFound callback. Use BadDataFoundArgs.Field and BadDataFoundArgs.RawRecord instead.";
				throw new ParserException(Context, message);
			}
			isProcessingField = true;
			string field = GetField(index);
			isProcessingField = false;
			return field;
		}
	}

	public CsvParser(TextReader reader, CultureInfo culture, bool leaveOpen = false)
		: this(reader, new CsvConfiguration(culture), leaveOpen)
	{
	}

	public CsvParser(TextReader reader, IParserConfiguration configuration, bool leaveOpen = false)
	{
		this.reader = reader ?? throw new ArgumentNullException("reader");
		this.configuration = configuration ?? throw new ArgumentNullException("configuration");
		configuration.Validate();
		Context = new CsvContext(this);
		allowComments = configuration.AllowComments;
		badDataFound = configuration.BadDataFound;
		bufferSize = configuration.BufferSize;
		cacheFields = configuration.CacheFields;
		comment = configuration.Comment;
		countBytes = configuration.CountBytes;
		delimiter = configuration.Delimiter;
		delimiterFirstChar = configuration.Delimiter[0];
		delimiterValues = configuration.DetectDelimiterValues;
		detectDelimiter = configuration.DetectDelimiter;
		encoding = configuration.Encoding;
		escape = configuration.Escape;
		ignoreBlankLines = configuration.IgnoreBlankLines;
		isNewLineSet = configuration.IsNewLineSet;
		this.leaveOpen = leaveOpen;
		lineBreakInQuotedFieldIsBadData = configuration.LineBreakInQuotedFieldIsBadData;
		maxFieldSize = configuration.MaxFieldSize;
		newLine = configuration.NewLine;
		newLineFirstChar = configuration.NewLine[0];
		mode = configuration.Mode;
		processFieldBufferSize = configuration.ProcessFieldBufferSize;
		quote = configuration.Quote;
		whiteSpaceChars = configuration.WhiteSpaceChars;
		trimOptions = configuration.TrimOptions;
		buffer = new char[bufferSize];
		processFieldBuffer = new char[processFieldBufferSize];
		fields = new Field[128];
		processedFields = new string[128];
	}

	public bool Read()
	{
		isRecordProcessed = false;
		rowStartPosition = bufferPosition;
		fieldStartPosition = rowStartPosition;
		fieldsPosition = 0;
		quoteCount = 0;
		row++;
		rawRow++;
		char c = '\0';
		char cPrev = c;
		do
		{
			if (bufferPosition >= charsRead)
			{
				if (!FillBuffer())
				{
					return ReadEndOfFile();
				}
				if (row == 1 && detectDelimiter)
				{
					DetectDelimiter();
				}
			}
		}
		while (ReadLine(ref c, ref cPrev) != ReadLineResult.Complete);
		return true;
	}

	public async Task<bool> ReadAsync()
	{
		isRecordProcessed = false;
		rowStartPosition = bufferPosition;
		fieldStartPosition = rowStartPosition;
		fieldsPosition = 0;
		quoteCount = 0;
		row++;
		rawRow++;
		char c = '\0';
		char cPrev = c;
		do
		{
			if (bufferPosition >= charsRead)
			{
				if (!(await FillBufferAsync().ConfigureAwait(continueOnCapturedContext: false)))
				{
					return ReadEndOfFile();
				}
				if (row == 1 && detectDelimiter)
				{
					DetectDelimiter();
				}
			}
		}
		while (ReadLine(ref c, ref cPrev) != ReadLineResult.Complete);
		return true;
	}

	private void DetectDelimiter()
	{
		string text = new string(buffer, 0, charsRead);
		string text2 = configuration.GetDelimiter(new GetDelimiterArgs(text, configuration));
		if (text2 != null)
		{
			delimiter = text2;
			delimiterFirstChar = text2[0];
			configuration.Validate();
		}
	}

	private ReadLineResult ReadLine(ref char c, ref char cPrev)
	{
		while (bufferPosition < charsRead)
		{
			if (state != ParserState.None)
			{
				ReadLineResult readLineResult = state switch
				{
					ParserState.Spaces => ReadSpaces(ref c), 
					ParserState.BlankLine => ReadBlankLine(ref c), 
					ParserState.Delimiter => ReadDelimiter(ref c), 
					ParserState.LineEnding => ReadLineEnding(ref c), 
					ParserState.NewLine => ReadNewLine(ref c), 
					_ => throw new InvalidOperationException($"Parser state '{state}' is not valid."), 
				};
				int num = readLineResult switch
				{
					ReadLineResult.Complete => (state == ParserState.LineEnding || state == ParserState.NewLine) ? 1 : 0, 
					ReadLineResult.Incomplete => 1, 
					_ => 0, 
				};
				if (readLineResult == ReadLineResult.Complete)
				{
					state = ParserState.None;
				}
				if (num != 0)
				{
					return readLineResult;
				}
			}
			cPrev = c;
			c = buffer[bufferPosition];
			bufferPosition++;
			charCount++;
			if (countBytes)
			{
				byteCount += encoding.GetByteCount(new char[1] { c });
			}
			if (maxFieldSize > 0.0 && (double)(bufferPosition - fieldStartPosition - 1) > maxFieldSize)
			{
				throw new MaxFieldSizeException(Context);
			}
			if (rowStartPosition == bufferPosition - 1 && ((allowComments && c == comment) || (ignoreBlankLines && (((c == '\r' || c == '\n') && !isNewLineSet) || (c == newLineFirstChar && isNewLineSet)))))
			{
				state = ParserState.BlankLine;
				if (ReadBlankLine(ref c) == ReadLineResult.Complete)
				{
					state = ParserState.None;
					continue;
				}
				return ReadLineResult.Incomplete;
			}
			if (mode == CsvMode.RFC4180)
			{
				bool flag = fieldStartPosition == bufferPosition - 1;
				if (flag)
				{
					if ((trimOptions & TrimOptions.Trim) == TrimOptions.Trim && ArrayHelper.Contains(whiteSpaceChars, in c))
					{
						ReadLineResult readLineResult2 = ReadSpaces(ref c);
						if (readLineResult2 == ReadLineResult.Incomplete)
						{
							fieldStartPosition = bufferPosition;
							return readLineResult2;
						}
					}
					fieldIsQuoted = c == quote;
				}
				if (fieldIsQuoted)
				{
					if (c == quote || c == escape)
					{
						quoteCount++;
						if (!inQuotes && !flag && cPrev != escape)
						{
							fieldIsBadData = true;
						}
						else if (!fieldIsBadData)
						{
							inQuotes = !inQuotes;
						}
					}
					if (inQuotes)
					{
						if (c != '\r' && (c != '\n' || cPrev == '\r'))
						{
							continue;
						}
						rawRow++;
						if (!lineBreakInQuotedFieldIsBadData)
						{
							continue;
						}
						fieldIsBadData = true;
					}
				}
				else if (c == quote || c == escape)
				{
					fieldIsBadData = true;
				}
			}
			else if (mode == CsvMode.Escape)
			{
				if (inEscape)
				{
					inEscape = false;
					continue;
				}
				if (c == escape)
				{
					inEscape = true;
					continue;
				}
			}
			if (c == delimiterFirstChar)
			{
				state = ParserState.Delimiter;
				ReadLineResult readLineResult3 = ReadDelimiter(ref c);
				if (readLineResult3 == ReadLineResult.Incomplete)
				{
					return readLineResult3;
				}
				state = ParserState.None;
				continue;
			}
			if (!isNewLineSet && (c == '\r' || c == '\n'))
			{
				state = ParserState.LineEnding;
				ReadLineResult num2 = ReadLineEnding(ref c);
				if (num2 == ReadLineResult.Complete)
				{
					state = ParserState.None;
				}
				return num2;
			}
			if (!isNewLineSet || c != newLineFirstChar)
			{
				continue;
			}
			state = ParserState.NewLine;
			ReadLineResult num3 = ReadNewLine(ref c);
			if (num3 == ReadLineResult.Complete)
			{
				state = ParserState.None;
			}
			return num3;
		}
		return ReadLineResult.Incomplete;
	}

	private ReadLineResult ReadSpaces(ref char c)
	{
		while (ArrayHelper.Contains(whiteSpaceChars, in c))
		{
			if (bufferPosition >= charsRead)
			{
				return ReadLineResult.Incomplete;
			}
			c = buffer[bufferPosition];
			bufferPosition++;
			charCount++;
			if (countBytes)
			{
				byteCount += encoding.GetByteCount(new char[1] { c });
			}
		}
		return ReadLineResult.Complete;
	}

	private ReadLineResult ReadBlankLine(ref char c)
	{
		while (bufferPosition < charsRead)
		{
			if (c == '\r' || c == '\n')
			{
				ReadLineResult num = ReadLineEnding(ref c);
				if (num == ReadLineResult.Complete)
				{
					rowStartPosition = bufferPosition;
					fieldStartPosition = rowStartPosition;
					row++;
					rawRow++;
				}
				return num;
			}
			c = buffer[bufferPosition];
			bufferPosition++;
			charCount++;
			if (countBytes)
			{
				byteCount += encoding.GetByteCount(new char[1] { c });
			}
		}
		return ReadLineResult.Incomplete;
	}

	private ReadLineResult ReadDelimiter(ref char c)
	{
		for (int i = delimiterPosition; i < delimiter.Length; i++)
		{
			if (bufferPosition >= charsRead)
			{
				return ReadLineResult.Incomplete;
			}
			delimiterPosition++;
			c = buffer[bufferPosition];
			if (c != delimiter[i])
			{
				c = buffer[bufferPosition - 1];
				delimiterPosition = 1;
				return ReadLineResult.Complete;
			}
			bufferPosition++;
			charCount++;
			if (countBytes)
			{
				byteCount += encoding.GetByteCount(new char[1] { c });
			}
			if (bufferPosition >= charsRead)
			{
				return ReadLineResult.Incomplete;
			}
		}
		AddField(fieldStartPosition, bufferPosition - fieldStartPosition - delimiter.Length);
		fieldStartPosition = bufferPosition;
		delimiterPosition = 1;
		fieldIsBadData = false;
		return ReadLineResult.Complete;
	}

	private ReadLineResult ReadLineEnding(ref char c)
	{
		int num = 1;
		if (c == '\r')
		{
			if (bufferPosition >= charsRead)
			{
				return ReadLineResult.Incomplete;
			}
			c = buffer[bufferPosition];
			if (c == '\n')
			{
				num++;
				bufferPosition++;
				charCount++;
				if (countBytes)
				{
					byteCount += encoding.GetByteCount(new char[1] { c });
				}
			}
		}
		if (state == ParserState.LineEnding)
		{
			AddField(fieldStartPosition, bufferPosition - fieldStartPosition - num);
		}
		fieldIsBadData = false;
		return ReadLineResult.Complete;
	}

	private ReadLineResult ReadNewLine(ref char c)
	{
		for (int i = newLinePosition; i < newLine.Length; i++)
		{
			if (bufferPosition >= charsRead)
			{
				return ReadLineResult.Incomplete;
			}
			newLinePosition++;
			c = buffer[bufferPosition];
			if (c != newLine[i])
			{
				c = buffer[bufferPosition - 1];
				newLinePosition = 1;
				return ReadLineResult.Complete;
			}
			bufferPosition++;
			charCount++;
			if (countBytes)
			{
				byteCount += encoding.GetByteCount(new char[1] { c });
			}
			if (bufferPosition >= charsRead)
			{
				return ReadLineResult.Incomplete;
			}
		}
		AddField(fieldStartPosition, bufferPosition - fieldStartPosition - newLine.Length);
		fieldStartPosition = bufferPosition;
		newLinePosition = 1;
		fieldIsBadData = false;
		return ReadLineResult.Complete;
	}

	private bool ReadEndOfFile()
	{
		ParserState parserState = state;
		state = ParserState.None;
		switch (parserState)
		{
		case ParserState.BlankLine:
			return false;
		case ParserState.Delimiter:
			AddField(fieldStartPosition, bufferPosition - fieldStartPosition - delimiter.Length);
			fieldStartPosition = bufferPosition;
			AddField(fieldStartPosition, bufferPosition - fieldStartPosition);
			return true;
		case ParserState.LineEnding:
			AddField(fieldStartPosition, bufferPosition - fieldStartPosition - 1);
			return true;
		case ParserState.NewLine:
			AddField(fieldStartPosition, bufferPosition - fieldStartPosition - newLine.Length);
			return true;
		default:
			if (rowStartPosition < bufferPosition)
			{
				AddField(fieldStartPosition, bufferPosition - fieldStartPosition);
			}
			return fieldsPosition > 0;
		}
	}

	private void AddField(int start, int length)
	{
		if (fieldsPosition >= fields.Length)
		{
			int newSize = fields.Length * 2;
			Array.Resize(ref fields, newSize);
			Array.Resize(ref processedFields, newSize);
		}
		ref Field reference = ref fields[fieldsPosition];
		reference.Start = start - rowStartPosition;
		reference.Length = length;
		reference.QuoteCount = quoteCount;
		reference.IsBad = fieldIsBadData;
		reference.IsProcessed = false;
		fieldsPosition++;
		quoteCount = 0;
	}

	private bool FillBuffer()
	{
		if (rowStartPosition == 0 && charCount > 0 && charsRead == bufferSize)
		{
			bufferSize *= 2;
			char[] array = new char[bufferSize];
			buffer.CopyTo(array, 0);
			buffer = array;
		}
		int num = Math.Max(charsRead - rowStartPosition, 0);
		Array.Copy(buffer, rowStartPosition, buffer, 0, num);
		fieldStartPosition -= rowStartPosition;
		rowStartPosition = 0;
		bufferPosition = num;
		charsRead = reader.Read(buffer, num, buffer.Length - num);
		if (charsRead == 0)
		{
			return false;
		}
		charsRead += num;
		return true;
	}

	private async Task<bool> FillBufferAsync()
	{
		if (rowStartPosition == 0 && charCount > 0 && charsRead == bufferSize)
		{
			bufferSize *= 2;
			char[] array = new char[bufferSize];
			buffer.CopyTo(array, 0);
			buffer = array;
		}
		int charsLeft = Math.Max(charsRead - rowStartPosition, 0);
		Array.Copy(buffer, rowStartPosition, buffer, 0, charsLeft);
		fieldStartPosition -= rowStartPosition;
		rowStartPosition = 0;
		bufferPosition = charsLeft;
		charsRead = await reader.ReadAsync(buffer, charsLeft, buffer.Length - charsLeft).ConfigureAwait(continueOnCapturedContext: false);
		if (charsRead == 0)
		{
			return false;
		}
		charsRead += charsLeft;
		return true;
	}

	private string GetField(int index)
	{
		if (index > fieldsPosition)
		{
			throw new IndexOutOfRangeException();
		}
		ref Field reference = ref fields[index];
		if (reference.Length == 0)
		{
			return string.Empty;
		}
		if (reference.IsProcessed)
		{
			return processedFields[index];
		}
		int start = reference.Start + rowStartPosition;
		int length = reference.Length;
		int num = reference.QuoteCount;
		ProcessedField processedField = mode switch
		{
			CsvMode.RFC4180 => reference.IsBad ? ProcessRFC4180BadField(start, length) : ProcessRFC4180Field(start, length, num), 
			CsvMode.Escape => ProcessEscapeField(start, length), 
			CsvMode.NoEscape => ProcessNoEscapeField(start, length), 
			_ => throw new InvalidOperationException($"ParseMode '{mode}' is not handled."), 
		};
		string text = (cacheFields ? fieldCache.GetField(processedField.Buffer, processedField.Start, processedField.Length) : new string(processedField.Buffer, processedField.Start, processedField.Length));
		processedFields[index] = text;
		reference.IsProcessed = true;
		return text;
	}

	protected ProcessedField ProcessRFC4180Field(int start, int length, int quoteCount)
	{
		int start2 = start;
		int length2 = length;
		if ((trimOptions & TrimOptions.Trim) == TrimOptions.Trim)
		{
			ArrayHelper.Trim(buffer, ref start2, ref length2, whiteSpaceChars);
		}
		if (quoteCount == 0)
		{
			return new ProcessedField(start2, length2, buffer);
		}
		if (buffer[start2] != quote || buffer[start2 + length2 - 1] != quote || (length2 == 1 && buffer[start2] == quote))
		{
			return ProcessRFC4180BadField(start, length);
		}
		start2++;
		length2 -= 2;
		if ((trimOptions & TrimOptions.InsideQuotes) == TrimOptions.InsideQuotes)
		{
			ArrayHelper.Trim(buffer, ref start2, ref length2, whiteSpaceChars);
		}
		if (quoteCount == 2)
		{
			return new ProcessedField(start2, length2, buffer);
		}
		if (length2 > processFieldBuffer.Length)
		{
			while (length2 > processFieldBufferSize)
			{
				processFieldBufferSize *= 2;
			}
			processFieldBuffer = new char[processFieldBufferSize];
		}
		bool flag = false;
		int num = 0;
		for (int i = start2; i < start2 + length2; i++)
		{
			char c = buffer[i];
			if (flag)
			{
				flag = false;
			}
			else if (c == escape)
			{
				flag = true;
				continue;
			}
			processFieldBuffer[num] = c;
			num++;
		}
		return new ProcessedField(0, num, processFieldBuffer);
	}

	protected ProcessedField ProcessRFC4180BadField(int start, int length)
	{
		BadDataFoundArgs args = new BadDataFoundArgs(new string(buffer, start, length), RawRecord, Context);
		badDataFound?.Invoke(args);
		int start2 = start;
		int length2 = length;
		if ((trimOptions & TrimOptions.Trim) == TrimOptions.Trim)
		{
			ArrayHelper.Trim(buffer, ref start2, ref length2, whiteSpaceChars);
		}
		if (buffer[start2] != quote)
		{
			return new ProcessedField(start2, length2, buffer);
		}
		if (length2 > processFieldBuffer.Length)
		{
			while (length2 > processFieldBufferSize)
			{
				processFieldBufferSize *= 2;
			}
			processFieldBuffer = new char[processFieldBufferSize];
		}
		bool flag = false;
		int num = 0;
		char c = '\0';
		bool flag2 = false;
		for (int i = start2 + 1; i < start2 + length2; i++)
		{
			char c2 = c;
			c = buffer[i];
			if (flag)
			{
				flag = false;
				if (c == quote)
				{
					continue;
				}
				if (c2 == quote)
				{
					flag2 = true;
				}
			}
			if (c == escape && !flag2)
			{
				flag = true;
				continue;
			}
			processFieldBuffer[num] = c;
			num++;
		}
		return new ProcessedField(0, num, processFieldBuffer);
	}

	protected ProcessedField ProcessEscapeField(int start, int length)
	{
		int start2 = start;
		int length2 = length;
		if ((trimOptions & TrimOptions.Trim) == TrimOptions.Trim)
		{
			ArrayHelper.Trim(buffer, ref start2, ref length2, whiteSpaceChars);
		}
		if (length2 > processFieldBuffer.Length)
		{
			while (length2 > processFieldBufferSize)
			{
				processFieldBufferSize *= 2;
			}
			processFieldBuffer = new char[processFieldBufferSize];
		}
		bool flag = false;
		int num = 0;
		for (int i = start2; i < start2 + length2; i++)
		{
			char c = buffer[i];
			if (flag)
			{
				flag = false;
			}
			else if (c == escape)
			{
				flag = true;
				continue;
			}
			processFieldBuffer[num] = c;
			num++;
		}
		return new ProcessedField(0, num, processFieldBuffer);
	}

	protected ProcessedField ProcessNoEscapeField(int start, int length)
	{
		int start2 = start;
		int length2 = length;
		if ((trimOptions & TrimOptions.Trim) == TrimOptions.Trim)
		{
			ArrayHelper.Trim(buffer, ref start2, ref length2, whiteSpaceChars);
		}
		return new ProcessedField(start2, length2, buffer);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposed)
		{
			if (disposing && !leaveOpen)
			{
				reader?.Dispose();
			}
			disposed = true;
		}
	}
}
