using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using CsvHelper.Expressions;
using CsvHelper.TypeConversion;

namespace CsvHelper;

public class CsvWriter : IWriter, IWriterRow, IDisposable, IAsyncDisposable
{
	private readonly TextWriter writer;

	private readonly CsvContext context;

	private readonly Lazy<RecordManager> recordManager;

	private readonly TypeConverterCache typeConverterCache;

	private readonly TrimOptions trimOptions;

	private readonly ShouldQuote shouldQuote;

	private readonly MemberMapData reusableMemberMapData = new MemberMapData(null);

	private readonly Dictionary<Type, TypeConverterOptions> typeConverterOptionsCache = new Dictionary<Type, TypeConverterOptions>();

	private readonly string quoteString;

	private readonly char quote;

	private readonly CultureInfo cultureInfo;

	private readonly char comment;

	private readonly bool hasHeaderRecord;

	private readonly bool includePrivateMembers;

	private readonly IComparer<string>? dynamicPropertySort;

	private readonly string delimiter;

	private readonly bool leaveOpen;

	private readonly string newLine;

	private readonly char[] injectionCharacters;

	private readonly char injectionEscapeCharacter;

	private readonly InjectionOptions injectionOptions;

	private readonly CsvMode mode;

	private readonly string escapeString;

	private readonly string escapeQuoteString;

	private readonly string escapeDelimiterString;

	private readonly string escapeNewlineString;

	private readonly string escapeEscapeString;

	private bool disposed;

	private bool hasHeaderBeenWritten;

	private int row = 1;

	private int index;

	private char[] buffer;

	private int bufferSize;

	private int bufferPosition;

	private Type? fieldType;

	public virtual string?[]? HeaderRecord { get; private set; }

	public virtual int Row => row;

	public virtual int Index => index;

	public virtual CsvContext Context => context;

	public virtual IWriterConfiguration Configuration { get; private set; }

	public CsvWriter(TextWriter writer, CultureInfo culture, bool leaveOpen = false)
		: this(writer, new CsvConfiguration(culture), leaveOpen)
	{
	}

	public CsvWriter(TextWriter writer, IWriterConfiguration configuration, bool leaveOpen = false)
	{
		CsvWriter csvWriter = this;
		configuration.Validate();
		this.writer = writer;
		Configuration = configuration;
		context = new CsvContext(this);
		typeConverterCache = context.TypeConverterCache;
		recordManager = new Lazy<RecordManager>(() => ObjectResolver.Current.Resolve<RecordManager>(new object[1] { csvWriter }));
		comment = configuration.Comment;
		bufferSize = configuration.BufferSize;
		delimiter = configuration.Delimiter;
		cultureInfo = configuration.CultureInfo;
		dynamicPropertySort = configuration.DynamicPropertySort;
		escapeDelimiterString = new string(configuration.Delimiter.SelectMany((char c) => new char[2] { configuration.Escape, c }).ToArray());
		escapeNewlineString = new string(configuration.NewLine.SelectMany((char c) => new char[2] { configuration.Escape, c }).ToArray());
		escapeQuoteString = new string(new char[2] { configuration.Escape, configuration.Quote });
		escapeEscapeString = new string(new char[2] { configuration.Escape, configuration.Escape });
		hasHeaderRecord = configuration.HasHeaderRecord;
		includePrivateMembers = configuration.IncludePrivateMembers;
		injectionCharacters = configuration.InjectionCharacters;
		injectionEscapeCharacter = configuration.InjectionEscapeCharacter;
		this.leaveOpen = leaveOpen;
		mode = configuration.Mode;
		newLine = configuration.NewLine;
		quote = configuration.Quote;
		quoteString = configuration.Quote.ToString();
		escapeString = configuration.Escape.ToString();
		injectionOptions = configuration.InjectionOptions;
		shouldQuote = configuration.ShouldQuote;
		trimOptions = configuration.TrimOptions;
		buffer = new char[bufferSize];
	}

	public virtual void WriteConvertedField(string? field, Type fieldType)
	{
		this.fieldType = fieldType;
		if (field != null)
		{
			WriteField(field);
		}
	}

	public virtual void WriteField(string? field)
	{
		if (field != null && (trimOptions & TrimOptions.Trim) == TrimOptions.Trim)
		{
			field = field.Trim();
		}
		if ((object)fieldType == null)
		{
			fieldType = typeof(string);
		}
		ShouldQuoteArgs args = new ShouldQuoteArgs(field, fieldType, this);
		bool flag = shouldQuote(args);
		WriteField(field, flag);
	}

	public virtual void WriteField(string? field, bool shouldQuote)
	{
		if (mode == CsvMode.RFC4180)
		{
			if (shouldQuote)
			{
				if (escapeString != quoteString)
				{
					field = field?.Replace(escapeString, escapeEscapeString);
				}
				field = field?.Replace(quoteString, escapeQuoteString);
				field = quote + field + quote;
			}
		}
		else if (mode == CsvMode.Escape)
		{
			field = field?.Replace(escapeString, escapeEscapeString).Replace(quoteString, escapeQuoteString).Replace(delimiter, escapeDelimiterString)
				.Replace(newLine, escapeNewlineString);
		}
		if (injectionOptions != InjectionOptions.None)
		{
			field = SanitizeForInjection(field);
		}
		if (index > 0)
		{
			WriteToBuffer(delimiter);
		}
		WriteToBuffer(field);
		index++;
		fieldType = null;
	}

	public virtual void WriteField<T>(T? field)
	{
		Type type = ((field == null) ? typeof(string) : field.GetType());
		ITypeConverter converter = typeConverterCache.GetConverter(type);
		WriteField(field, converter);
	}

	public virtual void WriteField<T>(T? field, ITypeConverter converter)
	{
		Type type = ((field == null) ? typeof(string) : field.GetType());
		reusableMemberMapData.TypeConverter = converter;
		if (!typeConverterOptionsCache.TryGetValue(type, out TypeConverterOptions value))
		{
			value = TypeConverterOptions.Merge(new TypeConverterOptions
			{
				CultureInfo = cultureInfo
			}, context.TypeConverterOptionsCache.GetOptions(type));
			typeConverterOptionsCache.Add(type, value);
		}
		reusableMemberMapData.TypeConverterOptions = value;
		string field2 = converter.ConvertToString(field, this, reusableMemberMapData);
		WriteConvertedField(field2, type);
	}

	public virtual void WriteField<T, TConverter>(T? field)
	{
		ITypeConverter converter = typeConverterCache.GetConverter<TConverter>();
		WriteField(field, converter);
	}

	public virtual void WriteComment(string? text)
	{
		WriteField(comment + text, shouldQuote: false);
	}

	public virtual void WriteHeader<T>()
	{
		WriteHeader(typeof(T));
	}

	public virtual void WriteHeader(Type type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (type == typeof(object))
		{
			return;
		}
		if (context.Maps[type] == null)
		{
			context.Maps.Add(context.AutoMap(type));
		}
		MemberMapCollection memberMapCollection = new MemberMapCollection();
		memberMapCollection.AddMembers(context.Maps[type]);
		List<string> list = new List<string>();
		foreach (MemberMap item in memberMapCollection)
		{
			if (!CanWrite(item))
			{
				continue;
			}
			if (item.Data.IndexEnd >= item.Data.Index)
			{
				int num = item.Data.IndexEnd - item.Data.Index + 1;
				for (int i = 1; i <= num; i++)
				{
					string text = item.Data.Names.FirstOrDefault() + i;
					WriteField(text);
					list.Add(text);
				}
			}
			else
			{
				string text2 = item.Data.Names.FirstOrDefault();
				WriteField(text2);
				list.Add(text2);
			}
		}
		HeaderRecord = list.ToArray();
		hasHeaderBeenWritten = true;
	}

	public virtual void WriteDynamicHeader(IDynamicMetaObjectProvider? record)
	{
		if (record == null)
		{
			throw new ArgumentNullException("record");
		}
		List<string> list = record.GetMetaObject(Expression.Constant(record)).GetDynamicMemberNames().ToList();
		if (dynamicPropertySort != null)
		{
			list = list.OrderBy((string name) => name, dynamicPropertySort).ToList();
		}
		HeaderRecord = list.ToArray();
		foreach (string item in list)
		{
			WriteField(item);
		}
		hasHeaderBeenWritten = true;
	}

	public virtual void WriteRecord<T>(T? record)
	{
		try
		{
			RecordTypeInfo typeInfoForRecord = GetTypeInfoForRecord(record);
			recordManager.Value.GetWriteDelegate<T>(typeInfoForRecord)(record);
		}
		catch (TargetInvocationException ex)
		{
			if (ex.InnerException != null)
			{
				throw ex.InnerException;
			}
			throw;
		}
		catch (Exception ex2) when (!(ex2 is CsvHelperException))
		{
			throw new WriterException(context, "An unexpected error occurred. See inner exception for details.", ex2);
		}
	}

	public virtual void WriteRecords(IEnumerable records)
	{
		IEnumerator enumerator = records.GetEnumerator();
		try
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			if (WriteHeaderFromRecord(enumerator.Current))
			{
				NextRecord();
			}
			Action<object> action = null;
			RecordTypeInfo typeInfo = default(RecordTypeInfo);
			do
			{
				object current = enumerator.Current;
				if (current == null)
				{
					NextRecord();
					continue;
				}
				if (action == null || typeInfo.RecordType != current.GetType())
				{
					typeInfo = GetTypeInfoForRecord(current);
					action = recordManager.Value.GetWriteDelegate<object>(typeInfo);
				}
				action(current);
				NextRecord();
			}
			while (enumerator.MoveNext());
		}
		catch (Exception ex) when (!(ex is CsvHelperException))
		{
			throw new WriterException(context, "An unexpected error occurred. See inner exception for details.", ex);
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	public virtual void WriteRecords<T>(IEnumerable<T> records)
	{
		using IEnumerator<T> enumerator = records.GetEnumerator() ?? throw new InvalidOperationException("Enumerator is null.");
		try
		{
			if (WriteHeaderFromType<T>())
			{
				NextRecord();
			}
			if (!enumerator.MoveNext())
			{
				return;
			}
			if (WriteHeaderFromRecord(enumerator.Current))
			{
				NextRecord();
			}
			Action<T> action = null;
			RecordTypeInfo typeInfo = default(RecordTypeInfo);
			do
			{
				T current = enumerator.Current;
				if (action == null || (current != null && typeInfo.RecordType != typeof(T)))
				{
					typeInfo = GetTypeInfoForRecord(current);
					action = recordManager.Value.GetWriteDelegate<T>(typeInfo);
				}
				action(current);
				NextRecord();
			}
			while (enumerator.MoveNext());
		}
		catch (Exception ex) when (!(ex is CsvHelperException))
		{
			throw new WriterException(context, "An unexpected error occurred. See inner exception for details.", ex);
		}
	}

	public virtual async Task WriteRecordsAsync(IEnumerable records, CancellationToken cancellationToken = default(CancellationToken))
	{
		IEnumerator enumerator = records.GetEnumerator();
		try
		{
			_ = 1;
			try
			{
				if (!enumerator.MoveNext())
				{
					goto end_IL_0048;
				}
				if (WriteHeaderFromRecord(enumerator.Current))
				{
					await NextRecordAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
				Action<object?> write = null;
				RecordTypeInfo writeType = default(RecordTypeInfo);
				do
				{
					cancellationToken.ThrowIfCancellationRequested();
					object current = enumerator.Current;
					if (write == null || (current != null && writeType.RecordType != current.GetType()))
					{
						writeType = GetTypeInfoForRecord(current);
						write = recordManager.Value.GetWriteDelegate<object>(writeType);
					}
					write(current);
					await NextRecordAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
				while (enumerator.MoveNext());
				goto end_IL_0039;
				end_IL_0048:;
			}
			catch (Exception ex) when (!(ex is CsvHelperException))
			{
				throw new WriterException(context, "An unexpected error occurred. See inner exception for details.", ex);
			}
			end_IL_0039:;
		}
		finally
		{
			if (enumerator is IAsyncDisposable asyncDisposable)
			{
				await asyncDisposable.DisposeAsync().ConfigureAwait(continueOnCapturedContext: false);
			}
			else if (enumerator is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
	}

	public virtual async Task WriteRecordsAsync<T>(IEnumerable<T> records, CancellationToken cancellationToken = default(CancellationToken))
	{
		IEnumerator<T> enumerator = records.GetEnumerator() ?? throw new InvalidOperationException("Enumerator is null.");
		try
		{
			_ = 2;
			try
			{
				if (WriteHeaderFromType<T>())
				{
					await NextRecordAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
				if (!enumerator.MoveNext())
				{
					goto end_IL_005f;
				}
				if (WriteHeaderFromRecord(enumerator.Current))
				{
					await NextRecordAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
				Action<T?> write = null;
				RecordTypeInfo writeType = default(RecordTypeInfo);
				do
				{
					cancellationToken.ThrowIfCancellationRequested();
					T current = enumerator.Current;
					if (write == null || (current != null && writeType.RecordType != typeof(T)))
					{
						writeType = GetTypeInfoForRecord(current);
						write = recordManager.Value.GetWriteDelegate<T>(writeType);
					}
					write(current);
					await NextRecordAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
				while (enumerator.MoveNext());
				goto end_IL_0048;
				end_IL_005f:;
			}
			catch (Exception ex) when (!(ex is CsvHelperException))
			{
				throw new WriterException(context, "An unexpected error occurred. See inner exception for details.", ex);
			}
			end_IL_0048:;
		}
		finally
		{
			if (enumerator is IAsyncDisposable asyncDisposable)
			{
				await asyncDisposable.DisposeAsync().ConfigureAwait(continueOnCapturedContext: false);
			}
			else
			{
				enumerator?.Dispose();
			}
		}
	}

	public virtual async Task WriteRecordsAsync<T>(IAsyncEnumerable<T> records, CancellationToken cancellationToken = default(CancellationToken))
	{
		IAsyncEnumerator<T> enumerator = records.GetAsyncEnumerator() ?? throw new InvalidOperationException("Enumerator is null.");
		try
		{
			_ = 4;
			try
			{
				if (WriteHeaderFromType<T>())
				{
					await NextRecordAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
				if (!(await enumerator.MoveNextAsync()))
				{
					goto end_IL_0070;
				}
				if (WriteHeaderFromRecord(enumerator.Current))
				{
					await NextRecordAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
				Action<T?> write = null;
				RecordTypeInfo writeType = default(RecordTypeInfo);
				do
				{
					cancellationToken.ThrowIfCancellationRequested();
					T current = enumerator.Current;
					if (write == null || (current != null && writeType.RecordType != typeof(T)))
					{
						writeType = GetTypeInfoForRecord(current);
						write = recordManager.Value.GetWriteDelegate<T>(writeType);
					}
					write(current);
					await NextRecordAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
				while (await enumerator.MoveNextAsync().ConfigureAwait(continueOnCapturedContext: false));
				goto end_IL_0051;
				end_IL_0070:;
			}
			catch (Exception ex) when (!(ex is CsvHelperException))
			{
				throw new WriterException(context, "An unexpected error occurred. See inner exception for details.", ex);
			}
			end_IL_0051:;
		}
		finally
		{
			IAsyncDisposable asyncDisposable = enumerator;
			if (asyncDisposable != null)
			{
				await asyncDisposable.DisposeAsync().ConfigureAwait(continueOnCapturedContext: false);
			}
			else if (enumerator is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
	}

	public virtual void NextRecord()
	{
		WriteToBuffer(newLine);
		FlushBuffer();
		index = 0;
		row++;
	}

	public virtual async Task NextRecordAsync()
	{
		WriteToBuffer(newLine);
		await FlushBufferAsync().ConfigureAwait(continueOnCapturedContext: false);
		index = 0;
		row++;
	}

	public virtual void Flush()
	{
		FlushBuffer();
		writer.Flush();
	}

	public virtual async Task FlushAsync()
	{
		await FlushBufferAsync().ConfigureAwait(continueOnCapturedContext: false);
		await writer.FlushAsync().ConfigureAwait(continueOnCapturedContext: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	protected virtual void FlushBuffer()
	{
		writer.Write(buffer, 0, bufferPosition);
		bufferPosition = 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	protected virtual async Task FlushBufferAsync()
	{
		await writer.WriteAsync(buffer, 0, bufferPosition).ConfigureAwait(continueOnCapturedContext: false);
		bufferPosition = 0;
	}

	public virtual bool CanWrite(MemberMap memberMap)
	{
		bool flag = memberMap.Data.Ignore;
		if (memberMap.Data.Member is PropertyInfo propertyInfo)
		{
			flag = flag || (propertyInfo.GetGetMethod() == null && !includePrivateMembers) || propertyInfo.GetGetMethod(nonPublic: true) == null;
		}
		return !flag;
	}

	public virtual RecordTypeInfo GetTypeInfoForRecord<T>(T? record)
	{
		Type typeFromHandle = typeof(T);
		if (typeFromHandle == typeof(object) && record != null)
		{
			return new RecordTypeInfo(record.GetType(), isObject: true);
		}
		return new RecordTypeInfo(typeFromHandle, isObject: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	protected virtual string? SanitizeForInjection(string? field)
	{
		if (field == null || field.Length == 0)
		{
			return field;
		}
		int num;
		if (ArrayHelper.Contains(injectionCharacters, field[0]))
		{
			num = 0;
		}
		else
		{
			if (field[0] != quote || field[field.Length - 1] != quote || !ArrayHelper.Contains(injectionCharacters, field[1]))
			{
				return field;
			}
			num = 1;
		}
		if (injectionOptions == InjectionOptions.Exception)
		{
			throw new WriterException(context, $"Injection character '{field[num]}' detected");
		}
		if (injectionOptions == InjectionOptions.Escape)
		{
			field = ((num != 0) ? (quoteString + injectionEscapeCharacter + field.Substring(num)) : (quoteString + injectionEscapeCharacter + field.Replace(quoteString, escapeQuoteString) + quoteString));
		}
		else if (injectionOptions == InjectionOptions.Strip)
		{
			do
			{
				field = field.Substring(1);
			}
			while (field.Length != 0 && ArrayHelper.Contains(injectionCharacters, field[0]));
			if (num == 1)
			{
				field = quoteString + field;
			}
		}
		return field;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	protected void WriteToBuffer(string? value)
	{
		int num = value?.Length ?? 0;
		if (value == null || num == 0)
		{
			return;
		}
		int num2 = bufferPosition + num;
		if (num2 >= bufferSize)
		{
			while (num2 >= bufferSize)
			{
				bufferSize *= 2;
			}
			Array.Resize(ref buffer, bufferSize);
		}
		value.CopyTo(0, buffer, bufferPosition, num);
		bufferPosition += num;
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
			Flush();
			if (disposing && !leaveOpen)
			{
				writer.Dispose();
			}
			disposed = true;
		}
	}

	public async ValueTask DisposeAsync()
	{
		await DisposeAsync(disposing: true).ConfigureAwait(continueOnCapturedContext: false);
		GC.SuppressFinalize(this);
	}

	protected virtual async ValueTask DisposeAsync(bool disposing)
	{
		if (!disposed)
		{
			await FlushAsync().ConfigureAwait(continueOnCapturedContext: false);
			if (disposing && !leaveOpen)
			{
				await writer.DisposeAsync().ConfigureAwait(continueOnCapturedContext: false);
			}
			disposed = true;
		}
	}

	private bool WriteHeaderFromType<T>()
	{
		if (!hasHeaderRecord || hasHeaderBeenWritten)
		{
			return false;
		}
		Type typeFromHandle = typeof(T);
		if (!typeFromHandle.GetTypeInfo().IsPrimitive && typeFromHandle != typeof(object))
		{
			WriteHeader(typeFromHandle);
			return hasHeaderBeenWritten;
		}
		return false;
	}

	private bool WriteHeaderFromRecord(object? record)
	{
		if (!hasHeaderRecord || hasHeaderBeenWritten)
		{
			return false;
		}
		if (record == null)
		{
			return false;
		}
		if (record is IDynamicMetaObjectProvider record2)
		{
			WriteDynamicHeader(record2);
			return true;
		}
		Type type = record.GetType();
		if (!type.GetTypeInfo().IsPrimitive)
		{
			WriteHeader(type);
			return true;
		}
		return false;
	}
}
