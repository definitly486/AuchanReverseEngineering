using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace System.Runtime.Serialization.Formatters.Binary;

[Obsolete("BinaryFormatter serialization is obsolete and should not be used. See https://aka.ms/binaryformatter for more information.", DiagnosticId = "SYSLIB0011", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
public sealed class BinaryFormatter
{
	internal ISurrogateSelector _surrogates;

	internal StreamingContext _context;

	internal FormatterTypeStyle _typeFormat = FormatterTypeStyle.TypesAlways;

	internal TypeFilterLevel _securityLevel = TypeFilterLevel.Full;

	public BinaryFormatter()
		: this(null, new StreamingContext(StreamingContextStates.All))
	{
	}

	public BinaryFormatter(ISurrogateSelector? selector, StreamingContext context)
	{
		_surrogates = selector;
		_context = context;
	}

	[RequiresDynamicCode("BinaryFormatter serialization uses dynamic code generation, the type of objects being processed cannot be statically discovered.")]
	[RequiresUnreferencedCode("BinaryFormatter serialization is not trim compatible because the type of objects being processed cannot be statically discovered.")]
	public object Deserialize(Stream serializationStream)
	{
		throw new PlatformNotSupportedException("BinaryFormatter_Removed");
	}

	[RequiresUnreferencedCode("BinaryFormatter serialization is not trim compatible because the type of objects being processed cannot be statically discovered.")]
	public void Serialize(Stream serializationStream, object graph)
	{
		throw new PlatformNotSupportedException("BinaryFormatter_Removed");
	}
}
