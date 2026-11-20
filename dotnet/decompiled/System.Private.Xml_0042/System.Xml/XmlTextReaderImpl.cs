using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace System.Xml;

internal sealed class XmlTextReaderImpl : XmlReader, IXmlLineInfo, IXmlNamespaceResolver
{
	private enum ParsingFunction
	{
		ElementContent,
		NoData,
		OpenUrl,
		SwitchToInteractive,
		SwitchToInteractiveXmlDecl,
		DocumentContent,
		MoveToElementContent,
		PopElementContext,
		PopEmptyElementContext,
		ResetAttributesRootLevel,
		Error,
		Eof,
		ReaderClosed,
		EntityReference,
		InIncrementalRead,
		FragmentAttribute,
		ReportEndEntity,
		AfterResolveEntityInContent,
		AfterResolveEmptyEntityInContent,
		XmlDeclarationFragment,
		GoToEof,
		PartialTextValue,
		InReadAttributeValue,
		InReadValueChunk,
		InReadContentAsBinary,
		InReadElementContentAsBinary
	}

	private enum ParsingMode
	{
		Full,
		SkipNode,
		SkipContent
	}

	private enum EntityType
	{
		CharacterDec,
		CharacterHex,
		CharacterNamed,
		Expanded,
		Skipped,
		FakeExpanded,
		Unexpanded,
		ExpandedInAttribute
	}

	private enum EntityExpandType
	{
		All,
		OnlyGeneral,
		OnlyCharacter
	}

	private enum IncrementalReadState
	{
		Text,
		StartTag,
		PI,
		CDATA,
		Comment,
		Attributes,
		AttributeValue,
		ReadData,
		EndElement,
		End,
		ReadValueChunk_OnCachedValue,
		ReadValueChunk_OnPartialValue,
		ReadContentAsBinary_OnCachedValue,
		ReadContentAsBinary_OnPartialValue,
		ReadContentAsBinary_End
	}

	private sealed class LaterInitParam
	{
		public bool useAsync;

		public Stream inputStream;

		public byte[] inputBytes;

		public int inputByteCount;

		public Uri inputbaseUri;

		public string inputUriStr;

		public XmlResolver inputUriResolver;

		public XmlParserContext inputContext;

		public TextReader inputTextReader;

		public InitInputType initType = InitInputType.Invalid;
	}

	private enum InitInputType
	{
		UriString,
		Stream,
		TextReader,
		Invalid
	}

	private struct ParsingState
	{
		internal char[] chars;

		internal int charPos;

		internal int charsUsed;

		internal Encoding encoding;

		internal bool appendMode;

		internal Stream stream;

		internal Decoder decoder;

		internal byte[] bytes;

		internal int bytePos;

		internal int bytesUsed;

		internal TextReader textReader;

		internal int lineNo;

		internal int lineStartPos;

		internal string baseUriStr;

		internal Uri baseUri;

		internal bool isEof;

		internal bool isStreamEof;

		internal IDtdEntityInfo entity;

		internal int entityId;

		internal bool eolNormalized;

		internal bool entityResolvedManually;

		internal int LineNo => lineNo;

		internal int LinePos => charPos - lineStartPos;

		internal void Clear()
		{
			chars = null;
			charPos = 0;
			charsUsed = 0;
			encoding = null;
			stream = null;
			decoder = null;
			bytes = null;
			bytePos = 0;
			bytesUsed = 0;
			textReader = null;
			lineNo = 1;
			lineStartPos = -1;
			baseUriStr = string.Empty;
			baseUri = null;
			isEof = false;
			isStreamEof = false;
			eolNormalized = true;
			entityResolvedManually = false;
		}

		internal void Close(bool closeInput)
		{
			if (closeInput)
			{
				if (stream != null)
				{
					stream.Dispose();
				}
				else
				{
					textReader?.Dispose();
				}
			}
		}
	}

	private sealed class XmlContext
	{
		internal XmlSpace xmlSpace;

		internal string xmlLang;

		internal string defaultNamespace;

		internal XmlContext previousContext;

		internal XmlContext()
		{
			xmlSpace = XmlSpace.None;
			xmlLang = string.Empty;
			defaultNamespace = string.Empty;
			previousContext = null;
		}

		internal XmlContext(XmlContext previousContext)
		{
			xmlSpace = previousContext.xmlSpace;
			xmlLang = previousContext.xmlLang;
			defaultNamespace = previousContext.defaultNamespace;
			this.previousContext = previousContext;
		}
	}

	private sealed class NoNamespaceManager : XmlNamespaceManager
	{
		public override string DefaultNamespace => string.Empty;

		public override void PushScope()
		{
		}

		public override bool PopScope()
		{
			return false;
		}

		public override void AddNamespace(string prefix, string uri)
		{
		}

		public override void RemoveNamespace(string prefix, string uri)
		{
		}

		public override IEnumerator GetEnumerator()
		{
			return null;
		}

		public override string LookupNamespace(string prefix)
		{
			return string.Empty;
		}

		public override string LookupPrefix(string uri)
		{
			return null;
		}
	}

	internal sealed class DtdParserProxy : IDtdParserAdapterV1, IDtdParserAdapterWithValidation, IDtdParserAdapter
	{
		private readonly XmlTextReaderImpl _reader;

		XmlNameTable IDtdParserAdapter.NameTable => _reader.DtdParserProxy_NameTable;

		IXmlNamespaceResolver IDtdParserAdapter.NamespaceResolver => _reader.DtdParserProxy_NamespaceResolver;

		Uri IDtdParserAdapter.BaseUri => _reader.DtdParserProxy_BaseUri;

		bool IDtdParserAdapter.IsEof => _reader.DtdParserProxy_IsEof;

		char[] IDtdParserAdapter.ParsingBuffer => _reader.DtdParserProxy_ParsingBuffer;

		int IDtdParserAdapter.ParsingBufferLength => _reader.DtdParserProxy_ParsingBufferLength;

		int IDtdParserAdapter.CurrentPosition
		{
			get
			{
				return _reader.DtdParserProxy_CurrentPosition;
			}
			set
			{
				_reader.DtdParserProxy_CurrentPosition = value;
			}
		}

		int IDtdParserAdapter.EntityStackLength => _reader.DtdParserProxy_EntityStackLength;

		bool IDtdParserAdapter.IsEntityEolNormalized => _reader.DtdParserProxy_IsEntityEolNormalized;

		int IDtdParserAdapter.LineNo => _reader.DtdParserProxy_LineNo;

		int IDtdParserAdapter.LineStartPosition => _reader.DtdParserProxy_LineStartPosition;

		bool IDtdParserAdapterWithValidation.DtdValidation => _reader.DtdParserProxy_DtdValidation;

		IValidationEventHandling IDtdParserAdapterWithValidation.ValidationEventHandling => _reader.DtdParserProxy_ValidationEventHandling;

		bool IDtdParserAdapterV1.Normalization => _reader.DtdParserProxy_Normalization;

		bool IDtdParserAdapterV1.Namespaces => _reader.DtdParserProxy_Namespaces;

		bool IDtdParserAdapterV1.V1CompatibilityMode => _reader.DtdParserProxy_V1CompatibilityMode;

		internal DtdParserProxy(XmlTextReaderImpl reader)
		{
			_reader = reader;
		}

		void IDtdParserAdapter.OnNewLine(int pos)
		{
			_reader.DtdParserProxy_OnNewLine(pos);
		}

		int IDtdParserAdapter.ReadData()
		{
			return _reader.DtdParserProxy_ReadData();
		}

		int IDtdParserAdapter.ParseNumericCharRef(StringBuilder internalSubsetBuilder)
		{
			return _reader.DtdParserProxy_ParseNumericCharRef(internalSubsetBuilder);
		}

		int IDtdParserAdapter.ParseNamedCharRef(bool expand, StringBuilder internalSubsetBuilder)
		{
			return _reader.DtdParserProxy_ParseNamedCharRef(expand, internalSubsetBuilder);
		}

		void IDtdParserAdapter.ParsePI(StringBuilder sb)
		{
			_reader.DtdParserProxy_ParsePI(sb);
		}

		void IDtdParserAdapter.ParseComment(StringBuilder sb)
		{
			_reader.DtdParserProxy_ParseComment(sb);
		}

		bool IDtdParserAdapter.PushEntity(IDtdEntityInfo entity, out int entityId)
		{
			return _reader.DtdParserProxy_PushEntity(entity, out entityId);
		}

		bool IDtdParserAdapter.PopEntity(out IDtdEntityInfo oldEntity, out int newEntityId)
		{
			return _reader.DtdParserProxy_PopEntity(out oldEntity, out newEntityId);
		}

		bool IDtdParserAdapter.PushExternalSubset(string systemId, string publicId)
		{
			return _reader.DtdParserProxy_PushExternalSubset(systemId, publicId);
		}

		void IDtdParserAdapter.PushInternalDtd(string baseUri, string internalDtd)
		{
			_reader.DtdParserProxy_PushInternalDtd(baseUri, internalDtd);
		}

		[DoesNotReturn]
		void IDtdParserAdapter.Throw(Exception e)
		{
			_reader.DtdParserProxy_Throw(e);
		}

		void IDtdParserAdapter.OnSystemId(string systemId, LineInfo keywordLineInfo, LineInfo systemLiteralLineInfo)
		{
			_reader.DtdParserProxy_OnSystemId(systemId, keywordLineInfo, systemLiteralLineInfo);
		}

		void IDtdParserAdapter.OnPublicId(string publicId, LineInfo keywordLineInfo, LineInfo publicLiteralLineInfo)
		{
			_reader.DtdParserProxy_OnPublicId(publicId, keywordLineInfo, publicLiteralLineInfo);
		}
	}

	private sealed class NodeData : IComparable
	{
		internal sealed class AtomizedNameEqualityComparer : IEqualityComparer<NodeData>
		{
			internal static readonly AtomizedNameEqualityComparer Instance = new AtomizedNameEqualityComparer();

			public bool Equals(NodeData x, NodeData y)
			{
				if (x == null)
				{
					return y == null;
				}
				if (y != null && Ref.Equal(x.localName, y.localName))
				{
					return Ref.Equal(x.ns, y.ns);
				}
				return false;
			}

			public int GetHashCode(NodeData node)
			{
				return HashCode.Combine(RuntimeHelpers.GetHashCode(node.localName), RuntimeHelpers.GetHashCode(node.ns));
			}
		}

		private static volatile NodeData s_None;

		internal XmlNodeType type;

		internal string localName;

		internal string prefix;

		internal string ns;

		internal string nameWPrefix;

		private string _value;

		private char[] _chars;

		private int _valueStartPos;

		private int _valueLength;

		internal LineInfo lineInfo;

		internal LineInfo lineInfo2;

		internal char quoteChar;

		internal int depth;

		private bool _isEmptyOrDefault;

		internal int entityId;

		internal bool xmlContextPushed;

		internal NodeData nextAttrValueChunk;

		internal object schemaType;

		internal object typedValue;

		internal static NodeData None => s_None ?? (s_None = new NodeData());

		internal int LineNo => lineInfo.lineNo;

		internal int LinePos => lineInfo.linePos;

		internal bool IsEmptyElement
		{
			get
			{
				if (type == XmlNodeType.Element)
				{
					return _isEmptyOrDefault;
				}
				return false;
			}
			set
			{
				_isEmptyOrDefault = value;
			}
		}

		internal bool IsDefaultAttribute
		{
			get
			{
				if (type == XmlNodeType.Attribute)
				{
					return _isEmptyOrDefault;
				}
				return false;
			}
			set
			{
				_isEmptyOrDefault = value;
			}
		}

		internal bool ValueBuffered => _value == null;

		internal string StringValue
		{
			get
			{
				if (_value == null)
				{
					_value = new string(_chars, _valueStartPos, _valueLength);
				}
				return _value;
			}
		}

		internal NodeData()
		{
			Clear(XmlNodeType.None);
			xmlContextPushed = false;
		}

		internal void TrimSpacesInValue()
		{
			if (ValueBuffered)
			{
				StripSpaces(_chars, _valueStartPos, ref _valueLength);
			}
			else
			{
				_value = StripSpaces(_value);
			}
		}

		[MemberNotNull("_value")]
		[MemberNotNull("nameWPrefix")]
		[MemberNotNull("localName")]
		[MemberNotNull("prefix")]
		[MemberNotNull("ns")]
		internal void Clear(XmlNodeType type)
		{
			this.type = type;
			ClearName();
			_value = string.Empty;
			_valueStartPos = -1;
			schemaType = null;
			typedValue = null;
		}

		[MemberNotNull("localName")]
		[MemberNotNull("prefix")]
		[MemberNotNull("ns")]
		[MemberNotNull("nameWPrefix")]
		internal void ClearName()
		{
			localName = string.Empty;
			prefix = string.Empty;
			ns = string.Empty;
			nameWPrefix = string.Empty;
		}

		internal void SetLineInfo(int lineNo, int linePos)
		{
			lineInfo.Set(lineNo, linePos);
		}

		internal void SetLineInfo2(int lineNo, int linePos)
		{
			lineInfo2.Set(lineNo, linePos);
		}

		internal void SetValueNode(XmlNodeType type, string value)
		{
			this.type = type;
			ClearName();
			_value = value;
			_valueStartPos = -1;
		}

		internal void SetValueNode(XmlNodeType type, char[] chars, int startPos, int len)
		{
			this.type = type;
			ClearName();
			_value = null;
			_chars = chars;
			_valueStartPos = startPos;
			_valueLength = len;
		}

		internal void SetNamedNode(XmlNodeType type, string localName)
		{
			SetNamedNode(type, localName, string.Empty, localName);
		}

		internal void SetNamedNode(XmlNodeType type, string localName, string prefix, string nameWPrefix)
		{
			this.type = type;
			this.localName = localName;
			this.prefix = prefix;
			this.nameWPrefix = nameWPrefix;
			ns = string.Empty;
			_value = string.Empty;
			_valueStartPos = -1;
		}

		internal void SetValue(string value)
		{
			_valueStartPos = -1;
			_value = value;
		}

		internal void SetValue(char[] chars, int startPos, int len)
		{
			_value = null;
			_chars = chars;
			_valueStartPos = startPos;
			_valueLength = len;
		}

		internal void OnBufferInvalidated()
		{
			if (_value == null)
			{
				_value = new string(_chars, _valueStartPos, _valueLength);
			}
			_valueStartPos = -1;
		}

		internal void CopyTo(int valueOffset, StringBuilder sb)
		{
			if (_value == null)
			{
				sb.Append(_chars, _valueStartPos + valueOffset, _valueLength - valueOffset);
			}
			else if (valueOffset <= 0)
			{
				sb.Append(_value);
			}
			else
			{
				sb.Append(_value, valueOffset, _value.Length - valueOffset);
			}
		}

		internal int CopyTo(int valueOffset, char[] buffer, int offset, int length)
		{
			if (_value == null)
			{
				int num = _valueLength - valueOffset;
				if (num > length)
				{
					num = length;
				}
				BlockCopyChars(_chars, _valueStartPos + valueOffset, buffer, offset, num);
				return num;
			}
			int num2 = _value.Length - valueOffset;
			if (num2 > length)
			{
				num2 = length;
			}
			_value.CopyTo(valueOffset, buffer, offset, num2);
			return num2;
		}

		internal int CopyToBinary(IncrementalReadDecoder decoder, int valueOffset)
		{
			if (_value == null)
			{
				return decoder.Decode(_chars, _valueStartPos + valueOffset, _valueLength - valueOffset);
			}
			return decoder.Decode(_value, valueOffset, _value.Length - valueOffset);
		}

		internal void AdjustLineInfo(int valueOffset, bool isNormalized, ref LineInfo lineInfo)
		{
			if (valueOffset != 0)
			{
				if (_valueStartPos != -1)
				{
					XmlTextReaderImpl.AdjustLineInfo(_chars, _valueStartPos, _valueStartPos + valueOffset, isNormalized, ref lineInfo);
				}
				else
				{
					XmlTextReaderImpl.AdjustLineInfo(_value, 0, valueOffset, isNormalized, ref lineInfo);
				}
			}
		}

		internal string GetNameWPrefix(XmlNameTable nt)
		{
			if (nameWPrefix != null)
			{
				return nameWPrefix;
			}
			return CreateNameWPrefix(nt);
		}

		internal string CreateNameWPrefix(XmlNameTable nt)
		{
			if (prefix.Length == 0)
			{
				nameWPrefix = localName;
			}
			else
			{
				nameWPrefix = nt.Add(prefix + ":" + localName);
			}
			return nameWPrefix;
		}

		int IComparable.CompareTo(object obj)
		{
			if (obj is NodeData nodeData)
			{
				if (Ref.Equal(localName, nodeData.localName))
				{
					if (Ref.Equal(ns, nodeData.ns))
					{
						return 0;
					}
					return string.CompareOrdinal(ns, nodeData.ns);
				}
				return string.CompareOrdinal(localName, nodeData.localName);
			}
			return 1;
		}
	}

	private sealed class DtdDefaultAttributeInfoToNodeDataComparer : IComparer<object>
	{
		private static readonly IComparer<object> s_instance = new DtdDefaultAttributeInfoToNodeDataComparer();

		internal static IComparer<object> Instance => s_instance;

		public int Compare(object x, object y)
		{
			if (x == null)
			{
				if (y != null)
				{
					return -1;
				}
				return 0;
			}
			if (y == null)
			{
				return 1;
			}
			string localName;
			string prefix;
			if (x is NodeData nodeData)
			{
				localName = nodeData.localName;
				prefix = nodeData.prefix;
			}
			else
			{
				if (!(x is IDtdDefaultAttributeInfo dtdDefaultAttributeInfo))
				{
					throw new XmlException("Xml_DefaultException", string.Empty);
				}
				localName = dtdDefaultAttributeInfo.LocalName;
				prefix = dtdDefaultAttributeInfo.Prefix;
			}
			string localName2;
			string prefix2;
			if (y is NodeData nodeData2)
			{
				localName2 = nodeData2.localName;
				prefix2 = nodeData2.prefix;
			}
			else
			{
				if (!(y is IDtdDefaultAttributeInfo dtdDefaultAttributeInfo2))
				{
					throw new XmlException("Xml_DefaultException", string.Empty);
				}
				localName2 = dtdDefaultAttributeInfo2.LocalName;
				prefix2 = dtdDefaultAttributeInfo2.Prefix;
			}
			int num = string.Compare(localName, localName2, StringComparison.Ordinal);
			if (num != 0)
			{
				return num;
			}
			return string.Compare(prefix, prefix2, StringComparison.Ordinal);
		}
	}

	internal delegate void OnDefaultAttributeUseDelegate(IDtdDefaultAttributeInfo defaultAttribute, XmlTextReaderImpl coreReader);

	private static UTF8Encoding s_utf8BomThrowing;

	private readonly bool _useAsync;

	private LaterInitParam _laterInitParam;

	private ParsingState _ps;

	private ParsingFunction _parsingFunction;

	private ParsingFunction _nextParsingFunction;

	private ParsingFunction _nextNextParsingFunction;

	private NodeData[] _nodes;

	private NodeData _curNode;

	private int _index;

	private int _curAttrIndex = -1;

	private int _attrCount;

	private int _attrHashtable;

	private int _attrDuplWalkCount;

	private bool _attrNeedNamespaceLookup;

	private bool _fullAttrCleanup;

	private HashSet<NodeData> _attrDuplSet;

	private XmlNameTable _nameTable;

	private bool _nameTableFromSettings;

	private XmlResolver _xmlResolver;

	private readonly string _url = string.Empty;

	private bool _normalize;

	private bool _supportNamespaces = true;

	private WhitespaceHandling _whitespaceHandling;

	private DtdProcessing _dtdProcessing = DtdProcessing.Parse;

	private EntityHandling _entityHandling;

	private readonly bool _ignorePIs;

	private readonly bool _ignoreComments;

	private readonly bool _checkCharacters;

	private readonly int _lineNumberOffset;

	private readonly int _linePositionOffset;

	private readonly bool _closeInput;

	private readonly long _maxCharactersInDocument;

	private readonly long _maxCharactersFromEntities;

	private readonly bool _v1Compat;

	private XmlNamespaceManager _namespaceManager;

	private string _lastPrefix = string.Empty;

	private XmlContext _xmlContext;

	private ParsingState[] _parsingStatesStack;

	private int _parsingStatesStackTop = -1;

	private string _reportedBaseUri = string.Empty;

	private Encoding _reportedEncoding;

	private IDtdInfo _dtdInfo;

	private XmlNodeType _fragmentType = XmlNodeType.Document;

	private XmlParserContext _fragmentParserContext;

	private bool _fragment;

	private IncrementalReadDecoder _incReadDecoder;

	private IncrementalReadState _incReadState;

	private LineInfo _incReadLineInfo;

	private BinHexDecoder _binHexDecoder;

	private Base64Decoder _base64Decoder;

	private int _incReadDepth;

	private int _incReadLeftStartPos;

	private int _incReadLeftEndPos;

	private int _attributeValueBaseEntityId;

	private bool _emptyEntityInAttributeResolved;

	private IValidationEventHandling _validationEventHandling;

	private OnDefaultAttributeUseDelegate _onDefaultAttributeUse;

	private bool _validatingReaderCompatFlag;

	private bool _addDefaultAttributesAndNormalize;

	private readonly StringBuilder _stringBuilder;

	private bool _rootElementParsed;

	private bool _standalone;

	private int _nextEntityId = 1;

	private ParsingMode _parsingMode;

	private ReadState _readState;

	private IDtdEntityInfo _lastEntity;

	private bool _afterResetState;

	private int _documentStartBytePos;

	private int _readValueOffset;

	private long _charactersInDocument;

	private long _charactersFromEntities;

	private HashSet<IDtdEntityInfo> _currentEntities;

	private bool _disableUndeclaredEntityCheck;

	private XmlReader _outerReader;

	private bool _xmlResolverIsSet;

	private readonly string _xml;

	private readonly string _xmlNs;

	private readonly Task<(int, int, int, bool)> _parseText_dummyTask = Task.FromResult((0, 0, 0, false));

	private static UTF8Encoding UTF8BomThrowing => s_utf8BomThrowing ?? (s_utf8BomThrowing = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true, throwOnInvalidBytes: true));

	public override XmlReaderSettings Settings
	{
		get
		{
			XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
			if (_nameTableFromSettings)
			{
				xmlReaderSettings.NameTable = _nameTable;
			}
			switch (_fragmentType)
			{
			default:
				xmlReaderSettings.ConformanceLevel = ConformanceLevel.Auto;
				break;
			case XmlNodeType.Element:
				xmlReaderSettings.ConformanceLevel = ConformanceLevel.Fragment;
				break;
			case XmlNodeType.Document:
				xmlReaderSettings.ConformanceLevel = ConformanceLevel.Document;
				break;
			}
			xmlReaderSettings.CheckCharacters = _checkCharacters;
			xmlReaderSettings.LineNumberOffset = _lineNumberOffset;
			xmlReaderSettings.LinePositionOffset = _linePositionOffset;
			xmlReaderSettings.IgnoreWhitespace = _whitespaceHandling == WhitespaceHandling.Significant;
			xmlReaderSettings.IgnoreProcessingInstructions = _ignorePIs;
			xmlReaderSettings.IgnoreComments = _ignoreComments;
			xmlReaderSettings.DtdProcessing = _dtdProcessing;
			xmlReaderSettings.MaxCharactersInDocument = _maxCharactersInDocument;
			xmlReaderSettings.MaxCharactersFromEntities = _maxCharactersFromEntities;
			xmlReaderSettings.XmlResolver = _xmlResolver;
			xmlReaderSettings.ReadOnly = true;
			return xmlReaderSettings;
		}
	}

	public override XmlNodeType NodeType => _curNode.type;

	public override string Name => _curNode.GetNameWPrefix(_nameTable);

	public override string LocalName => _curNode.localName;

	public override string NamespaceURI => _curNode.ns ?? string.Empty;

	public override string Prefix => _curNode.prefix;

	public override string Value
	{
		get
		{
			if (_parsingFunction >= ParsingFunction.PartialTextValue)
			{
				if (_parsingFunction == ParsingFunction.PartialTextValue)
				{
					FinishPartialValue();
					_parsingFunction = _nextParsingFunction;
				}
				else
				{
					FinishOtherValueIterator();
				}
			}
			return _curNode.StringValue;
		}
	}

	public override int Depth => _curNode.depth;

	public override string BaseURI => _reportedBaseUri;

	public override bool IsEmptyElement => _curNode.IsEmptyElement;

	public override bool IsDefault => _curNode.IsDefaultAttribute;

	public override char QuoteChar
	{
		get
		{
			if (_curNode.type != XmlNodeType.Attribute)
			{
				return '"';
			}
			return _curNode.quoteChar;
		}
	}

	public override XmlSpace XmlSpace => _xmlContext.xmlSpace;

	public override string XmlLang => _xmlContext.xmlLang;

	public override ReadState ReadState => _readState;

	public override bool EOF => _parsingFunction == ParsingFunction.Eof;

	public override XmlNameTable NameTable => _nameTable;

	public override bool CanResolveEntity => true;

	public override int AttributeCount => _attrCount;

	internal XmlReader OuterReader
	{
		set
		{
			_outerReader = value;
		}
	}

	public override bool CanReadBinaryContent => true;

	public override bool CanReadValueChunk => true;

	public int LineNumber => _curNode.LineNo;

	public int LinePosition => _curNode.LinePos;

	internal bool Namespaces
	{
		get
		{
			return _supportNamespaces;
		}
		set
		{
			if (_readState != ReadState.Initial)
			{
				throw new InvalidOperationException("Xml_InvalidOperation");
			}
			_supportNamespaces = value;
			if (value)
			{
				if (_namespaceManager is NoNamespaceManager)
				{
					if (_fragment && _fragmentParserContext != null && _fragmentParserContext.NamespaceManager != null)
					{
						_namespaceManager = _fragmentParserContext.NamespaceManager;
					}
					else
					{
						_namespaceManager = new XmlNamespaceManager(_nameTable);
					}
				}
				_xmlContext.defaultNamespace = _namespaceManager.LookupNamespace(string.Empty);
			}
			else
			{
				if (!(_namespaceManager is NoNamespaceManager))
				{
					_namespaceManager = new NoNamespaceManager();
				}
				_xmlContext.defaultNamespace = string.Empty;
			}
		}
	}

	internal bool Normalization
	{
		set
		{
			if (_readState == ReadState.Closed)
			{
				throw new InvalidOperationException("Xml_InvalidOperation");
			}
			_normalize = value;
			if (_ps.entity == null || _ps.entity.IsExternal)
			{
				_ps.eolNormalized = !value;
			}
		}
	}

	internal WhitespaceHandling WhitespaceHandling
	{
		get
		{
			return _whitespaceHandling;
		}
		set
		{
			if (_readState == ReadState.Closed)
			{
				throw new InvalidOperationException("Xml_InvalidOperation");
			}
			if ((uint)value > 2u)
			{
				throw new XmlException("Xml_WhitespaceHandling", string.Empty);
			}
			_whitespaceHandling = value;
		}
	}

	internal DtdProcessing DtdProcessing => _dtdProcessing;

	internal EntityHandling EntityHandling
	{
		set
		{
			if (value != EntityHandling.ExpandEntities && value != EntityHandling.ExpandCharEntities)
			{
				throw new XmlException("Xml_EntityHandling", string.Empty);
			}
			_entityHandling = value;
		}
	}

	internal XmlResolver XmlResolver
	{
		set
		{
			_xmlResolver = value;
			_xmlResolverIsSet = true;
			_ps.baseUri = null;
			for (int i = 0; i <= _parsingStatesStackTop; i++)
			{
				_parsingStatesStack[i].baseUri = null;
			}
		}
	}

	internal XmlNameTable DtdParserProxy_NameTable => _nameTable;

	internal IXmlNamespaceResolver DtdParserProxy_NamespaceResolver => _namespaceManager;

	internal bool DtdParserProxy_DtdValidation => DtdValidation;

	internal bool DtdParserProxy_Normalization => _normalize;

	internal bool DtdParserProxy_Namespaces => _supportNamespaces;

	internal bool DtdParserProxy_V1CompatibilityMode => _v1Compat;

	internal Uri DtdParserProxy_BaseUri
	{
		get
		{
			if (_ps.baseUriStr.Length > 0 && _ps.baseUri == null && _xmlResolver != null)
			{
				_ps.baseUri = _xmlResolver.ResolveUri(null, _ps.baseUriStr);
			}
			return _ps.baseUri;
		}
	}

	internal bool DtdParserProxy_IsEof => _ps.isEof;

	internal char[] DtdParserProxy_ParsingBuffer => _ps.chars;

	internal int DtdParserProxy_ParsingBufferLength => _ps.charsUsed;

	internal int DtdParserProxy_CurrentPosition
	{
		get
		{
			return _ps.charPos;
		}
		set
		{
			_ps.charPos = value;
		}
	}

	internal int DtdParserProxy_EntityStackLength => _parsingStatesStackTop + 1;

	internal bool DtdParserProxy_IsEntityEolNormalized => _ps.eolNormalized;

	internal IValidationEventHandling DtdParserProxy_ValidationEventHandling => _validationEventHandling;

	internal int DtdParserProxy_LineNo => _ps.LineNo;

	internal int DtdParserProxy_LineStartPosition => _ps.lineStartPos;

	private bool IsResolverNull
	{
		get
		{
			if (_xmlResolver != null)
			{
				return !_xmlResolverIsSet;
			}
			return true;
		}
	}

	private bool InAttributeValueIterator
	{
		get
		{
			if (_attrCount > 0)
			{
				return _parsingFunction >= ParsingFunction.InReadAttributeValue;
			}
			return false;
		}
	}

	private bool DtdValidation => _validationEventHandling != null;

	private bool InEntity => _parsingStatesStackTop >= 0;

	internal override IDtdInfo DtdInfo => _dtdInfo;

	internal bool XmlValidatingReaderCompatibilityMode
	{
		set
		{
			_validatingReaderCompatFlag = value;
			if (value)
			{
				_nameTable.Add("http://www.w3.org/2001/XMLSchema");
				_nameTable.Add("http://www.w3.org/2001/XMLSchema-instance");
				_nameTable.Add("urn:schemas-microsoft-com:datatypes");
			}
		}
	}

	internal override XmlNamespaceManager NamespaceManager => _namespaceManager;

	internal ConformanceLevel V1ComformanceLevel
	{
		get
		{
			if (_fragmentType != XmlNodeType.Element)
			{
				return ConformanceLevel.Document;
			}
			return ConformanceLevel.Fragment;
		}
	}

	internal bool DisableUndeclaredEntityCheck
	{
		set
		{
			_disableUndeclaredEntityCheck = value;
		}
	}

	internal XmlTextReaderImpl(XmlNameTable nt)
	{
		_v1Compat = true;
		_outerReader = this;
		_nameTable = nt;
		nt.Add(string.Empty);
		_xmlResolver = null;
		_xml = nt.Add("xml");
		_xmlNs = nt.Add("xmlns");
		_nodes = new NodeData[8];
		_nodes[0] = new NodeData();
		_curNode = _nodes[0];
		_stringBuilder = new StringBuilder();
		_xmlContext = new XmlContext();
		_parsingFunction = ParsingFunction.SwitchToInteractiveXmlDecl;
		_nextParsingFunction = ParsingFunction.DocumentContent;
		_entityHandling = EntityHandling.ExpandCharEntities;
		_whitespaceHandling = WhitespaceHandling.All;
		_closeInput = true;
		_maxCharactersInDocument = 0L;
		_maxCharactersFromEntities = 10000000L;
		_charactersInDocument = 0L;
		_charactersFromEntities = 0L;
		_ps.lineNo = 1;
		_ps.lineStartPos = -1;
	}

	private XmlTextReaderImpl(XmlResolver resolver, XmlReaderSettings settings, XmlParserContext context)
	{
		_useAsync = settings.Async;
		_v1Compat = false;
		_outerReader = this;
		_xmlContext = new XmlContext();
		XmlNameTable xmlNameTable = settings.NameTable;
		if (context == null)
		{
			if (xmlNameTable == null)
			{
				xmlNameTable = new NameTable();
			}
			else
			{
				_nameTableFromSettings = true;
			}
			_nameTable = xmlNameTable;
			_namespaceManager = new XmlNamespaceManager(xmlNameTable);
		}
		else
		{
			SetupFromParserContext(context, settings);
			xmlNameTable = _nameTable;
		}
		xmlNameTable.Add(string.Empty);
		_xml = xmlNameTable.Add("xml");
		_xmlNs = xmlNameTable.Add("xmlns");
		_xmlResolver = resolver;
		_nodes = new NodeData[8];
		_nodes[0] = new NodeData();
		_curNode = _nodes[0];
		_stringBuilder = new StringBuilder();
		_entityHandling = EntityHandling.ExpandEntities;
		_xmlResolverIsSet = settings.IsXmlResolverSet;
		_whitespaceHandling = (settings.IgnoreWhitespace ? WhitespaceHandling.Significant : WhitespaceHandling.All);
		_normalize = true;
		_ignorePIs = settings.IgnoreProcessingInstructions;
		_ignoreComments = settings.IgnoreComments;
		_checkCharacters = settings.CheckCharacters;
		_lineNumberOffset = settings.LineNumberOffset;
		_linePositionOffset = settings.LinePositionOffset;
		_ps.lineNo = _lineNumberOffset + 1;
		_ps.lineStartPos = -_linePositionOffset - 1;
		_curNode.SetLineInfo(_ps.LineNo - 1, _ps.LinePos - 1);
		_dtdProcessing = settings.DtdProcessing;
		_maxCharactersInDocument = settings.MaxCharactersInDocument;
		_maxCharactersFromEntities = settings.MaxCharactersFromEntities;
		_charactersInDocument = 0L;
		_charactersFromEntities = 0L;
		_fragmentParserContext = context;
		_parsingFunction = ParsingFunction.SwitchToInteractiveXmlDecl;
		_nextParsingFunction = ParsingFunction.DocumentContent;
		switch (settings.ConformanceLevel)
		{
		case ConformanceLevel.Auto:
			_fragmentType = XmlNodeType.None;
			_fragment = true;
			break;
		case ConformanceLevel.Fragment:
			_fragmentType = XmlNodeType.Element;
			_fragment = true;
			break;
		default:
			_fragmentType = XmlNodeType.Document;
			break;
		}
	}

	internal XmlTextReaderImpl(Stream input)
		: this(string.Empty, input, new NameTable())
	{
	}

	internal XmlTextReaderImpl(string url, Stream input, XmlNameTable nt)
		: this(nt)
	{
		ConvertAbsoluteUnixPathToAbsoluteUri(ref url, null);
		_namespaceManager = new XmlNamespaceManager(nt);
		if (string.IsNullOrEmpty(url))
		{
			InitStreamInput(input, null);
		}
		else
		{
			InitStreamInput(url, input, null);
		}
		_reportedBaseUri = _ps.baseUriStr;
		_reportedEncoding = _ps.encoding;
	}

	internal XmlTextReaderImpl(TextReader input)
		: this(string.Empty, input, new NameTable())
	{
	}

	internal XmlTextReaderImpl(TextReader input, XmlNameTable nt)
		: this(string.Empty, input, nt)
	{
	}

	internal XmlTextReaderImpl(string url, TextReader input, XmlNameTable nt)
		: this(nt)
	{
		ConvertAbsoluteUnixPathToAbsoluteUri(ref url, null);
		_namespaceManager = new XmlNamespaceManager(nt);
		_reportedBaseUri = url ?? string.Empty;
		InitTextReaderInput(_reportedBaseUri, input);
		_reportedEncoding = _ps.encoding;
	}

	internal XmlTextReaderImpl(string xmlFragment, XmlNodeType fragType, XmlParserContext context)
		: this((context == null || context.NameTable == null) ? new NameTable() : context.NameTable)
	{
		if (xmlFragment == null)
		{
			xmlFragment = string.Empty;
		}
		if (context == null)
		{
			InitStringInput(string.Empty, Encoding.Unicode, xmlFragment);
		}
		else
		{
			_reportedBaseUri = context.BaseURI;
			InitStringInput(context.BaseURI, Encoding.Unicode, xmlFragment);
		}
		InitFragmentReader(fragType, context, allowXmlDeclFragment: false);
		_reportedEncoding = _ps.encoding;
	}

	internal XmlTextReaderImpl(string xmlFragment, XmlParserContext context)
		: this((context == null || context.NameTable == null) ? new NameTable() : context.NameTable)
	{
		InitStringInput((context == null) ? string.Empty : context.BaseURI, Encoding.Unicode, "<?xml " + xmlFragment + "?>");
		InitFragmentReader(XmlNodeType.XmlDeclaration, context, allowXmlDeclFragment: true);
	}

	private void FinishInitUriString()
	{
		Stream stream = ((!_laterInitParam.useAsync) ? ((Stream)_laterInitParam.inputUriResolver.GetEntity(_laterInitParam.inputbaseUri, string.Empty, typeof(Stream))) : ((Stream)_laterInitParam.inputUriResolver.GetEntityAsync(_laterInitParam.inputbaseUri, string.Empty, typeof(Stream)).GetAwaiter().GetResult()));
		if (stream == null)
		{
			throw new XmlException("Xml_CannotResolveUrl", _laterInitParam.inputUriStr);
		}
		Encoding encoding = null;
		if (_laterInitParam.inputContext != null)
		{
			encoding = _laterInitParam.inputContext.Encoding;
		}
		try
		{
			InitStreamInput(_laterInitParam.inputbaseUri, _reportedBaseUri, stream, null, 0, encoding);
			_reportedEncoding = _ps.encoding;
			if (_laterInitParam.inputContext != null && _laterInitParam.inputContext.HasDtdInfo)
			{
				ProcessDtdFromParserContext(_laterInitParam.inputContext);
			}
		}
		catch
		{
			stream.Dispose();
			throw;
		}
		_laterInitParam = null;
	}

	internal XmlTextReaderImpl(Stream stream, byte[] bytes, int byteCount, XmlReaderSettings settings, Uri baseUri, string baseUriStr, XmlParserContext context, bool closeInput)
		: this(settings.GetXmlResolver(), settings, context)
	{
		ConvertAbsoluteUnixPathToAbsoluteUri(ref baseUriStr, settings.GetXmlResolver());
		if (context != null && context.BaseURI != null && context.BaseURI.Length > 0 && !UriEqual(baseUri, baseUriStr, context.BaseURI, settings.GetXmlResolver()))
		{
			if (baseUriStr.Length > 0)
			{
				Throw("Xml_DoubleBaseUri");
			}
			baseUriStr = context.BaseURI;
		}
		_reportedBaseUri = baseUriStr ?? string.Empty;
		_closeInput = closeInput;
		_laterInitParam = new LaterInitParam();
		_laterInitParam.inputStream = stream;
		_laterInitParam.inputBytes = bytes;
		_laterInitParam.inputByteCount = byteCount;
		_laterInitParam.inputbaseUri = baseUri;
		_laterInitParam.inputContext = context;
		_laterInitParam.initType = InitInputType.Stream;
		if (!settings.Async)
		{
			FinishInitStream();
		}
		else
		{
			_laterInitParam.useAsync = true;
		}
	}

	private void FinishInitStream()
	{
		Encoding encoding = null;
		if (_laterInitParam.inputContext != null)
		{
			encoding = _laterInitParam.inputContext.Encoding;
		}
		InitStreamInput(_laterInitParam.inputbaseUri, _reportedBaseUri, _laterInitParam.inputStream, _laterInitParam.inputBytes, _laterInitParam.inputByteCount, encoding);
		_reportedEncoding = _ps.encoding;
		if (_laterInitParam.inputContext != null && _laterInitParam.inputContext.HasDtdInfo)
		{
			ProcessDtdFromParserContext(_laterInitParam.inputContext);
		}
		_laterInitParam = null;
	}

	internal XmlTextReaderImpl(TextReader input, XmlReaderSettings settings, string baseUriStr, XmlParserContext context)
		: this(settings.GetXmlResolver(), settings, context)
	{
		ConvertAbsoluteUnixPathToAbsoluteUri(ref baseUriStr, settings.GetXmlResolver());
		if (context != null && context.BaseURI != null)
		{
			baseUriStr = context.BaseURI;
		}
		_reportedBaseUri = baseUriStr;
		_closeInput = settings.CloseInput;
		_laterInitParam = new LaterInitParam();
		_laterInitParam.inputTextReader = input;
		_laterInitParam.inputContext = context;
		_laterInitParam.initType = InitInputType.TextReader;
		if (!settings.Async)
		{
			FinishInitTextReader();
		}
		else
		{
			_laterInitParam.useAsync = true;
		}
	}

	private void FinishInitTextReader()
	{
		InitTextReaderInput(_reportedBaseUri, _laterInitParam.inputTextReader);
		_reportedEncoding = _ps.encoding;
		if (_laterInitParam.inputContext != null && _laterInitParam.inputContext.HasDtdInfo)
		{
			ProcessDtdFromParserContext(_laterInitParam.inputContext);
		}
		_laterInitParam = null;
	}

	internal XmlTextReaderImpl(string xmlFragment, XmlParserContext context, XmlReaderSettings settings)
		: this(null, settings, context)
	{
		InitStringInput(string.Empty, Encoding.Unicode, xmlFragment);
		_reportedBaseUri = _ps.baseUriStr;
		_reportedEncoding = _ps.encoding;
	}

	public override string GetAttribute(string name)
	{
		int num = (name.Contains(':') ? GetIndexOfAttributeWithPrefix(name) : GetIndexOfAttributeWithoutPrefix(name));
		if (num < 0)
		{
			return null;
		}
		return _nodes[num].StringValue;
	}

	public override string GetAttribute(string localName, string namespaceURI)
	{
		namespaceURI = ((namespaceURI == null) ? string.Empty : _nameTable.Get(namespaceURI));
		string strB = _nameTable.Get(localName);
		for (int i = _index + 1; i < _index + _attrCount + 1; i++)
		{
			if (Ref.Equal(_nodes[i].localName, strB) && Ref.Equal(_nodes[i].ns, namespaceURI))
			{
				return _nodes[i].StringValue;
			}
		}
		return null;
	}

	public override string GetAttribute(int i)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(i, "i");
		ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(i, _attrCount, "i");
		return _nodes[_index + i + 1].StringValue;
	}

	public override bool MoveToAttribute(string name)
	{
		int num = (name.Contains(':') ? GetIndexOfAttributeWithPrefix(name) : GetIndexOfAttributeWithoutPrefix(name));
		if (num >= 0)
		{
			if (InAttributeValueIterator)
			{
				FinishAttributeValueIterator();
			}
			_curAttrIndex = num - _index - 1;
			_curNode = _nodes[num];
			return true;
		}
		return false;
	}

	public override bool MoveToAttribute(string localName, string namespaceURI)
	{
		string strB = ((namespaceURI == null) ? string.Empty : _nameTable.Get(namespaceURI));
		string strB2 = _nameTable.Get(localName);
		for (int i = _index + 1; i < _index + _attrCount + 1; i++)
		{
			if (Ref.Equal(_nodes[i].localName, strB2) && Ref.Equal(_nodes[i].ns, strB))
			{
				_curAttrIndex = i - _index - 1;
				_curNode = _nodes[i];
				if (InAttributeValueIterator)
				{
					FinishAttributeValueIterator();
				}
				return true;
			}
		}
		return false;
	}

	public override void MoveToAttribute(int i)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(i, "i");
		ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(i, _attrCount, "i");
		if (InAttributeValueIterator)
		{
			FinishAttributeValueIterator();
		}
		_curAttrIndex = i;
		_curNode = _nodes[_index + 1 + _curAttrIndex];
	}

	public override bool MoveToFirstAttribute()
	{
		if (_attrCount == 0)
		{
			return false;
		}
		if (InAttributeValueIterator)
		{
			FinishAttributeValueIterator();
		}
		_curAttrIndex = 0;
		_curNode = _nodes[_index + 1];
		return true;
	}

	public override bool MoveToNextAttribute()
	{
		if (_curAttrIndex + 1 < _attrCount)
		{
			if (InAttributeValueIterator)
			{
				FinishAttributeValueIterator();
			}
			_curNode = _nodes[_index + 1 + ++_curAttrIndex];
			return true;
		}
		return false;
	}

	public override bool MoveToElement()
	{
		if (InAttributeValueIterator)
		{
			FinishAttributeValueIterator();
		}
		else if (_curNode.type != XmlNodeType.Attribute)
		{
			return false;
		}
		_curAttrIndex = -1;
		_curNode = _nodes[_index];
		return true;
	}

	private void FinishInit()
	{
		switch (_laterInitParam.initType)
		{
		case InitInputType.UriString:
			FinishInitUriString();
			break;
		case InitInputType.Stream:
			FinishInitStream();
			break;
		case InitInputType.TextReader:
			FinishInitTextReader();
			break;
		}
	}

	public override bool Read()
	{
		if (_laterInitParam != null)
		{
			FinishInit();
		}
		while (true)
		{
			switch (_parsingFunction)
			{
			case ParsingFunction.ElementContent:
				return ParseElementContent();
			case ParsingFunction.DocumentContent:
				return ParseDocumentContent();
			case ParsingFunction.OpenUrl:
				OpenUrl();
				goto case ParsingFunction.SwitchToInteractiveXmlDecl;
			case ParsingFunction.SwitchToInteractive:
				_readState = ReadState.Interactive;
				_parsingFunction = _nextParsingFunction;
				break;
			case ParsingFunction.SwitchToInteractiveXmlDecl:
				_readState = ReadState.Interactive;
				_parsingFunction = _nextParsingFunction;
				if (ParseXmlDeclaration(isTextDecl: false))
				{
					_reportedEncoding = _ps.encoding;
					return true;
				}
				_reportedEncoding = _ps.encoding;
				break;
			case ParsingFunction.ResetAttributesRootLevel:
				ResetAttributes();
				_curNode = _nodes[_index];
				_parsingFunction = ((_index == 0) ? ParsingFunction.DocumentContent : ParsingFunction.ElementContent);
				break;
			case ParsingFunction.MoveToElementContent:
				ResetAttributes();
				_index++;
				_curNode = AddNode(_index, _index);
				_parsingFunction = ParsingFunction.ElementContent;
				break;
			case ParsingFunction.PopElementContext:
				PopElementContext();
				_parsingFunction = _nextParsingFunction;
				break;
			case ParsingFunction.PopEmptyElementContext:
				_curNode = _nodes[_index];
				_curNode.IsEmptyElement = false;
				ResetAttributes();
				PopElementContext();
				_parsingFunction = _nextParsingFunction;
				break;
			case ParsingFunction.EntityReference:
				_parsingFunction = _nextParsingFunction;
				ParseEntityReference();
				return true;
			case ParsingFunction.ReportEndEntity:
				SetupEndEntityNodeInContent();
				_parsingFunction = _nextParsingFunction;
				return true;
			case ParsingFunction.AfterResolveEntityInContent:
				_curNode = AddNode(_index, _index);
				_reportedEncoding = _ps.encoding;
				_reportedBaseUri = _ps.baseUriStr;
				_parsingFunction = _nextParsingFunction;
				break;
			case ParsingFunction.AfterResolveEmptyEntityInContent:
				_curNode = AddNode(_index, _index);
				_curNode.SetValueNode(XmlNodeType.Text, string.Empty);
				_curNode.SetLineInfo(_ps.lineNo, _ps.LinePos);
				_reportedEncoding = _ps.encoding;
				_reportedBaseUri = _ps.baseUriStr;
				_parsingFunction = _nextParsingFunction;
				return true;
			case ParsingFunction.InReadAttributeValue:
				FinishAttributeValueIterator();
				_curNode = _nodes[_index];
				break;
			case ParsingFunction.InIncrementalRead:
				FinishIncrementalRead();
				return true;
			case ParsingFunction.FragmentAttribute:
				return ParseFragmentAttribute();
			case ParsingFunction.XmlDeclarationFragment:
				ParseXmlDeclarationFragment();
				_parsingFunction = ParsingFunction.GoToEof;
				return true;
			case ParsingFunction.GoToEof:
				OnEof();
				return false;
			case ParsingFunction.Error:
			case ParsingFunction.Eof:
			case ParsingFunction.ReaderClosed:
				return false;
			case ParsingFunction.NoData:
				ThrowWithoutLineInfo("Xml_MissingRoot");
				return false;
			case ParsingFunction.PartialTextValue:
				SkipPartialTextValue();
				break;
			case ParsingFunction.InReadValueChunk:
				FinishReadValueChunk();
				break;
			case ParsingFunction.InReadContentAsBinary:
				FinishReadContentAsBinary();
				break;
			case ParsingFunction.InReadElementContentAsBinary:
				FinishReadElementContentAsBinary();
				break;
			}
		}
	}

	public override void Close()
	{
		Close(_closeInput);
	}

	public override void Skip()
	{
		if (_readState != ReadState.Interactive)
		{
			return;
		}
		if (InAttributeValueIterator)
		{
			FinishAttributeValueIterator();
			_curNode = _nodes[_index];
		}
		else
		{
			switch (_parsingFunction)
			{
			case ParsingFunction.InIncrementalRead:
				FinishIncrementalRead();
				break;
			case ParsingFunction.PartialTextValue:
				SkipPartialTextValue();
				break;
			case ParsingFunction.InReadValueChunk:
				FinishReadValueChunk();
				break;
			case ParsingFunction.InReadContentAsBinary:
				FinishReadContentAsBinary();
				break;
			case ParsingFunction.InReadElementContentAsBinary:
				FinishReadElementContentAsBinary();
				break;
			}
		}
		XmlNodeType type = _curNode.type;
		if (type != XmlNodeType.Element)
		{
			if (type != XmlNodeType.Attribute)
			{
				goto IL_00dc;
			}
			_outerReader.MoveToElement();
		}
		if (!_curNode.IsEmptyElement)
		{
			int index = _index;
			_parsingMode = ParsingMode.SkipContent;
			while (_outerReader.Read() && _index > index)
			{
			}
			_parsingMode = ParsingMode.Full;
		}
		goto IL_00dc;
		IL_00dc:
		_outerReader.Read();
	}

	public override string LookupNamespace(string prefix)
	{
		if (!_supportNamespaces)
		{
			return null;
		}
		return _namespaceManager.LookupNamespace(prefix);
	}

	public override bool ReadAttributeValue()
	{
		if (_parsingFunction != ParsingFunction.InReadAttributeValue)
		{
			if (_curNode.type != XmlNodeType.Attribute)
			{
				return false;
			}
			if (_readState != ReadState.Interactive || _curAttrIndex < 0)
			{
				return false;
			}
			if (_parsingFunction == ParsingFunction.InReadValueChunk)
			{
				FinishReadValueChunk();
			}
			if (_parsingFunction == ParsingFunction.InReadContentAsBinary)
			{
				FinishReadContentAsBinary();
			}
			if (_curNode.nextAttrValueChunk == null || _entityHandling == EntityHandling.ExpandEntities)
			{
				NodeData nodeData = AddNode(_index + _attrCount + 1, _curNode.depth + 1);
				nodeData.SetValueNode(XmlNodeType.Text, _curNode.StringValue);
				nodeData.lineInfo = _curNode.lineInfo2;
				nodeData.depth = _curNode.depth + 1;
				_curNode = nodeData;
				nodeData.nextAttrValueChunk = null;
			}
			else
			{
				_curNode = _curNode.nextAttrValueChunk;
				AddNode(_index + _attrCount + 1, _index + 2);
				_nodes[_index + _attrCount + 1] = _curNode;
				_fullAttrCleanup = true;
			}
			_nextParsingFunction = _parsingFunction;
			_parsingFunction = ParsingFunction.InReadAttributeValue;
			_attributeValueBaseEntityId = _ps.entityId;
			return true;
		}
		if (_ps.entityId == _attributeValueBaseEntityId)
		{
			if (_curNode.nextAttrValueChunk != null)
			{
				_curNode = _curNode.nextAttrValueChunk;
				_nodes[_index + _attrCount + 1] = _curNode;
				return true;
			}
			return false;
		}
		return ParseAttributeValueChunk();
	}

	public override void ResolveEntity()
	{
		if (_curNode.type != XmlNodeType.EntityReference)
		{
			throw new InvalidOperationException("Xml_InvalidOperation");
		}
		if (_parsingFunction == ParsingFunction.InReadAttributeValue || _parsingFunction == ParsingFunction.FragmentAttribute)
		{
			switch (HandleGeneralEntityReference(_curNode.localName, isInAttributeValue: true, pushFakeEntityIfNullResolver: true, _curNode.LinePos))
			{
			case EntityType.Expanded:
			case EntityType.ExpandedInAttribute:
				if (_ps.charsUsed - _ps.charPos == 0)
				{
					_emptyEntityInAttributeResolved = true;
				}
				break;
			case EntityType.FakeExpanded:
				_emptyEntityInAttributeResolved = true;
				break;
			default:
				throw new XmlException("Xml_InternalError", string.Empty);
			}
		}
		else
		{
			switch (HandleGeneralEntityReference(_curNode.localName, isInAttributeValue: false, pushFakeEntityIfNullResolver: true, _curNode.LinePos))
			{
			case EntityType.Expanded:
			case EntityType.ExpandedInAttribute:
				_nextParsingFunction = _parsingFunction;
				if (_ps.charsUsed - _ps.charPos == 0 && !_ps.entity.IsExternal)
				{
					_parsingFunction = ParsingFunction.AfterResolveEmptyEntityInContent;
				}
				else
				{
					_parsingFunction = ParsingFunction.AfterResolveEntityInContent;
				}
				break;
			case EntityType.FakeExpanded:
				_nextParsingFunction = _parsingFunction;
				_parsingFunction = ParsingFunction.AfterResolveEmptyEntityInContent;
				break;
			default:
				throw new XmlException("Xml_InternalError", string.Empty);
			}
		}
		_ps.entityResolvedManually = true;
		_index++;
	}

	internal void MoveOffEntityReference()
	{
		if (_outerReader.NodeType == XmlNodeType.EntityReference && _parsingFunction == ParsingFunction.AfterResolveEntityInContent && !_outerReader.Read())
		{
			throw new InvalidOperationException("Xml_InvalidOperation");
		}
	}

	public override string ReadString()
	{
		MoveOffEntityReference();
		return base.ReadString();
	}

	public override int ReadElementContentAsBase64(byte[] buffer, int index, int count)
	{
		ArgumentNullException.ThrowIfNull(buffer, "buffer");
		ArgumentOutOfRangeException.ThrowIfNegative(count, "count");
		ArgumentOutOfRangeException.ThrowIfNegative(index, "index");
		ArgumentOutOfRangeException.ThrowIfGreaterThan(count, buffer.Length - index, "count");
		if (_parsingFunction == ParsingFunction.InReadElementContentAsBinary)
		{
			if (_incReadDecoder == _base64Decoder)
			{
				return ReadElementContentAsBinary(buffer, index, count);
			}
		}
		else
		{
			if (_readState != ReadState.Interactive)
			{
				return 0;
			}
			if (_parsingFunction == ParsingFunction.InReadContentAsBinary)
			{
				throw new InvalidOperationException("Xml_MixingBinaryContentMethods");
			}
			if (_curNode.type != XmlNodeType.Element)
			{
				throw CreateReadElementContentAsException("ReadElementContentAsBinHex");
			}
			if (!InitReadElementContentAsBinary())
			{
				return 0;
			}
		}
		InitBase64Decoder();
		return ReadElementContentAsBinary(buffer, index, count);
	}

	public override int ReadElementContentAsBinHex(byte[] buffer, int index, int count)
	{
		ArgumentNullException.ThrowIfNull(buffer, "buffer");
		ArgumentOutOfRangeException.ThrowIfNegative(count, "count");
		ArgumentOutOfRangeException.ThrowIfNegative(index, "index");
		ArgumentOutOfRangeException.ThrowIfGreaterThan(count, buffer.Length - index, "count");
		if (_parsingFunction == ParsingFunction.InReadElementContentAsBinary)
		{
			if (_incReadDecoder == _binHexDecoder)
			{
				return ReadElementContentAsBinary(buffer, index, count);
			}
		}
		else
		{
			if (_readState != ReadState.Interactive)
			{
				return 0;
			}
			if (_parsingFunction == ParsingFunction.InReadContentAsBinary)
			{
				throw new InvalidOperationException("Xml_MixingBinaryContentMethods");
			}
			if (_curNode.type != XmlNodeType.Element)
			{
				throw CreateReadElementContentAsException("ReadElementContentAsBinHex");
			}
			if (!InitReadElementContentAsBinary())
			{
				return 0;
			}
		}
		InitBinHexDecoder();
		return ReadElementContentAsBinary(buffer, index, count);
	}

	public override int ReadValueChunk(char[] buffer, int index, int count)
	{
		if (!XmlReader.HasValueInternal(_curNode.type))
		{
			throw new InvalidOperationException(System.SR.Format("Xml_InvalidReadValueChunk", _curNode.type));
		}
		ArgumentNullException.ThrowIfNull(buffer, "buffer");
		ArgumentOutOfRangeException.ThrowIfNegative(count, "count");
		ArgumentOutOfRangeException.ThrowIfNegative(index, "index");
		ArgumentOutOfRangeException.ThrowIfGreaterThan(count, buffer.Length - index, "count");
		if (_parsingFunction != ParsingFunction.InReadValueChunk)
		{
			if (_readState != ReadState.Interactive)
			{
				return 0;
			}
			if (_parsingFunction == ParsingFunction.PartialTextValue)
			{
				_incReadState = IncrementalReadState.ReadValueChunk_OnPartialValue;
			}
			else
			{
				_incReadState = IncrementalReadState.ReadValueChunk_OnCachedValue;
				_nextNextParsingFunction = _nextParsingFunction;
				_nextParsingFunction = _parsingFunction;
			}
			_parsingFunction = ParsingFunction.InReadValueChunk;
			_readValueOffset = 0;
		}
		if (count == 0)
		{
			return 0;
		}
		int num = 0;
		int num2 = _curNode.CopyTo(_readValueOffset, buffer, index + num, count - num);
		num += num2;
		_readValueOffset += num2;
		if (num == count)
		{
			if (XmlCharType.IsHighSurrogate(buffer[index + count - 1]))
			{
				num--;
				_readValueOffset--;
				if (num == 0)
				{
					Throw("Xml_NotEnoughSpaceForSurrogatePair");
				}
			}
			return num;
		}
		if (_incReadState == IncrementalReadState.ReadValueChunk_OnPartialValue)
		{
			_curNode.SetValue(string.Empty);
			bool flag = false;
			int startPos = 0;
			int endPos = 0;
			while (num < count && !flag)
			{
				int outOrChars = 0;
				flag = ParseText(out startPos, out endPos, ref outOrChars);
				int num3 = count - num;
				if (num3 > endPos - startPos)
				{
					num3 = endPos - startPos;
				}
				BlockCopyChars(_ps.chars, startPos, buffer, index + num, num3);
				num += num3;
				startPos += num3;
			}
			_incReadState = (flag ? IncrementalReadState.ReadValueChunk_OnCachedValue : IncrementalReadState.ReadValueChunk_OnPartialValue);
			if (num == count && XmlCharType.IsHighSurrogate(buffer[index + count - 1]))
			{
				num--;
				startPos--;
				if (num == 0)
				{
					Throw("Xml_NotEnoughSpaceForSurrogatePair");
				}
			}
			_readValueOffset = 0;
			_curNode.SetValue(_ps.chars, startPos, endPos - startPos);
		}
		return num;
	}

	public bool HasLineInfo()
	{
		return true;
	}

	string IXmlNamespaceResolver.LookupNamespace(string prefix)
	{
		return LookupNamespace(prefix);
	}

	string IXmlNamespaceResolver.LookupPrefix(string namespaceName)
	{
		return LookupPrefix(namespaceName);
	}

	internal string LookupPrefix(string namespaceName)
	{
		return _namespaceManager.LookupPrefix(namespaceName);
	}

	internal void DtdParserProxy_OnNewLine(int pos)
	{
		OnNewLine(pos);
	}

	internal int DtdParserProxy_ReadData()
	{
		return ReadData();
	}

	internal int DtdParserProxy_ParseNumericCharRef(StringBuilder internalSubsetBuilder)
	{
		EntityType entityType;
		return ParseNumericCharRef(expand: true, internalSubsetBuilder, out entityType);
	}

	internal int DtdParserProxy_ParseNamedCharRef(bool expand, StringBuilder internalSubsetBuilder)
	{
		return ParseNamedCharRef(expand, internalSubsetBuilder);
	}

	internal void DtdParserProxy_ParsePI(StringBuilder sb)
	{
		if (sb == null)
		{
			ParsingMode parsingMode = _parsingMode;
			_parsingMode = ParsingMode.SkipNode;
			ParsePI(null);
			_parsingMode = parsingMode;
		}
		else
		{
			ParsePI(sb);
		}
	}

	internal void DtdParserProxy_ParseComment(StringBuilder sb)
	{
		try
		{
			if (sb == null)
			{
				ParsingMode parsingMode = _parsingMode;
				_parsingMode = ParsingMode.SkipNode;
				ParseCDataOrComment(XmlNodeType.Comment);
				_parsingMode = parsingMode;
			}
			else
			{
				NodeData curNode = _curNode;
				_curNode = AddNode(_index + _attrCount + 1, _index);
				ParseCDataOrComment(XmlNodeType.Comment);
				_curNode.CopyTo(0, sb);
				_curNode = curNode;
			}
		}
		catch (XmlException ex)
		{
			if (ex.ResString == "Xml_UnexpectedEOF" && _ps.entity != null)
			{
				SendValidationEvent(XmlSeverityType.Error, "Sch_ParEntityRefNesting", null, _ps.LineNo, _ps.LinePos);
				return;
			}
			throw;
		}
	}

	private XmlResolver GetTempResolver()
	{
		return _xmlResolver ?? XmlReaderSettings.GetDefaultPermissiveResolver();
	}

	internal bool DtdParserProxy_PushEntity(IDtdEntityInfo entity, out int entityId)
	{
		bool result;
		if (entity.IsExternal)
		{
			if (IsResolverNull)
			{
				entityId = -1;
				return false;
			}
			result = PushExternalEntity(entity);
		}
		else
		{
			PushInternalEntity(entity);
			result = true;
		}
		entityId = _ps.entityId;
		return result;
	}

	internal bool DtdParserProxy_PopEntity(out IDtdEntityInfo oldEntity, out int newEntityId)
	{
		if (_parsingStatesStackTop == -1)
		{
			oldEntity = null;
			newEntityId = -1;
			return false;
		}
		oldEntity = _ps.entity;
		PopEntity();
		newEntityId = _ps.entityId;
		return true;
	}

	internal bool DtdParserProxy_PushExternalSubset(string systemId, string publicId)
	{
		if (IsResolverNull)
		{
			return false;
		}
		if (_ps.baseUri == null && !string.IsNullOrEmpty(_ps.baseUriStr))
		{
			_ps.baseUri = _xmlResolver.ResolveUri(null, _ps.baseUriStr);
		}
		PushExternalEntityOrSubset(publicId, systemId, _ps.baseUri, null);
		_ps.entity = null;
		_ps.entityId = 0;
		int charPos = _ps.charPos;
		if (_v1Compat)
		{
			EatWhitespaces(null);
		}
		if (!ParseXmlDeclaration(isTextDecl: true))
		{
			_ps.charPos = charPos;
		}
		return true;
	}

	internal void DtdParserProxy_PushInternalDtd(string baseUri, string internalDtd)
	{
		PushParsingState();
		RegisterConsumedCharacters(internalDtd.Length, inEntityReference: false);
		InitStringInput(baseUri, Encoding.Unicode, internalDtd);
		_ps.entity = null;
		_ps.entityId = 0;
		_ps.eolNormalized = false;
	}

	[DoesNotReturn]
	internal void DtdParserProxy_Throw(Exception e)
	{
		Throw(e);
	}

	internal void DtdParserProxy_OnSystemId(string systemId, LineInfo keywordLineInfo, LineInfo systemLiteralLineInfo)
	{
		NodeData nodeData = AddAttributeNoChecks("SYSTEM", _index + 1);
		nodeData.SetValue(systemId);
		nodeData.lineInfo = keywordLineInfo;
		nodeData.lineInfo2 = systemLiteralLineInfo;
	}

	internal void DtdParserProxy_OnPublicId(string publicId, LineInfo keywordLineInfo, LineInfo publicLiteralLineInfo)
	{
		NodeData nodeData = AddAttributeNoChecks("PUBLIC", _index + 1);
		nodeData.SetValue(publicId);
		nodeData.lineInfo = keywordLineInfo;
		nodeData.lineInfo2 = publicLiteralLineInfo;
	}

	[DoesNotReturn]
	private void Throw(int pos, string res, string arg)
	{
		_ps.charPos = pos;
		Throw(res, arg);
	}

	[DoesNotReturn]
	private void Throw(int pos, string res, string[] args)
	{
		_ps.charPos = pos;
		Throw(res, args);
	}

	[DoesNotReturn]
	private void Throw(int pos, string res)
	{
		_ps.charPos = pos;
		Throw(res, string.Empty);
	}

	[DoesNotReturn]
	private void Throw(string res)
	{
		Throw(res, string.Empty);
	}

	[DoesNotReturn]
	private void Throw(string res, int lineNo, int linePos)
	{
		Throw(new XmlException(res, string.Empty, lineNo, linePos, _ps.baseUriStr));
	}

	[DoesNotReturn]
	private void Throw(string res, string arg)
	{
		Throw(new XmlException(res, arg, _ps.LineNo, _ps.LinePos, _ps.baseUriStr));
	}

	[DoesNotReturn]
	private void Throw(string res, string arg, int lineNo, int linePos)
	{
		Throw(new XmlException(res, arg, lineNo, linePos, _ps.baseUriStr));
	}

	[DoesNotReturn]
	private void Throw(string res, string[] args)
	{
		Throw(new XmlException(res, args, _ps.LineNo, _ps.LinePos, _ps.baseUriStr));
	}

	[DoesNotReturn]
	private void Throw(string res, string arg, Exception innerException)
	{
		Throw(res, new string[1] { arg }, innerException);
	}

	[DoesNotReturn]
	private void Throw(string res, string[] args, Exception innerException)
	{
		Throw(new XmlException(res, args, innerException, _ps.LineNo, _ps.LinePos, _ps.baseUriStr));
	}

	[DoesNotReturn]
	private void Throw(Exception e)
	{
		SetErrorState();
		if (e is XmlException ex)
		{
			_curNode.SetLineInfo(ex.LineNumber, ex.LinePosition);
		}
		throw e;
	}

	[DoesNotReturn]
	private void ReThrow(Exception e, int lineNo, int linePos)
	{
		Throw(new XmlException(e.Message, (Exception)null, lineNo, linePos, _ps.baseUriStr));
	}

	[DoesNotReturn]
	private void ThrowWithoutLineInfo(string res)
	{
		Throw(new XmlException(res, string.Empty, _ps.baseUriStr));
	}

	[DoesNotReturn]
	private void ThrowWithoutLineInfo(string res, string arg)
	{
		Throw(new XmlException(res, arg, _ps.baseUriStr));
	}

	[DoesNotReturn]
	private void ThrowWithoutLineInfo(string res, string[] args, Exception innerException)
	{
		Throw(new XmlException(res, args, innerException, 0, 0, _ps.baseUriStr));
	}

	[DoesNotReturn]
	private void ThrowInvalidChar(char[] data, int length, int invCharPos)
	{
		Throw(invCharPos, "Xml_InvalidCharacter", XmlException.BuildCharExceptionArgs(data, length, invCharPos));
	}

	private void SetErrorState()
	{
		_parsingFunction = ParsingFunction.Error;
		_readState = ReadState.Error;
	}

	private void SendValidationEvent(XmlSeverityType severity, string code, string arg, int lineNo, int linePos)
	{
		SendValidationEvent(severity, new XmlSchemaException(code, arg, _ps.baseUriStr, lineNo, linePos));
	}

	private void SendValidationEvent(XmlSeverityType severity, XmlSchemaException exception)
	{
		_validationEventHandling?.SendEvent(exception, severity);
	}

	private void FinishAttributeValueIterator()
	{
		if (_parsingFunction == ParsingFunction.InReadValueChunk)
		{
			FinishReadValueChunk();
		}
		else if (_parsingFunction == ParsingFunction.InReadContentAsBinary)
		{
			FinishReadContentAsBinary();
		}
		if (_parsingFunction == ParsingFunction.InReadAttributeValue)
		{
			while (_ps.entityId != _attributeValueBaseEntityId)
			{
				HandleEntityEnd(checkEntityNesting: false);
			}
			_emptyEntityInAttributeResolved = false;
			_parsingFunction = _nextParsingFunction;
			_nextParsingFunction = ((_index <= 0) ? ParsingFunction.DocumentContent : ParsingFunction.ElementContent);
		}
	}

	private void InitStreamInput(Stream stream, Encoding encoding)
	{
		InitStreamInput(null, string.Empty, stream, null, 0, encoding);
	}

	private void InitStreamInput(string baseUriStr, Stream stream, Encoding encoding)
	{
		InitStreamInput(null, baseUriStr, stream, null, 0, encoding);
	}

	private void InitStreamInput(Uri baseUri, Stream stream, Encoding encoding)
	{
		InitStreamInput(baseUri, baseUri.ToString(), stream, null, 0, encoding);
	}

	private void InitStreamInput(Uri baseUri, string baseUriStr, Stream stream, Encoding encoding)
	{
		InitStreamInput(baseUri, baseUriStr, stream, null, 0, encoding);
	}

	private void InitStreamInput(Uri baseUri, string baseUriStr, Stream stream, byte[] bytes, int byteCount, Encoding encoding)
	{
		_ps.stream = stream;
		_ps.baseUri = baseUri;
		_ps.baseUriStr = baseUriStr;
		int num;
		if (bytes != null)
		{
			_ps.bytes = bytes;
			_ps.bytesUsed = byteCount;
			num = _ps.bytes.Length;
		}
		else
		{
			num = ((_laterInitParam == null || !_laterInitParam.useAsync) ? XmlReader.CalcBufferSize(stream) : 32768);
			if (_ps.bytes == null || _ps.bytes.Length < num)
			{
				_ps.bytes = new byte[num];
			}
		}
		if (_ps.chars == null || _ps.chars.Length < num + 1)
		{
			_ps.chars = new char[num + 1];
		}
		_ps.bytePos = 0;
		if (_ps.bytesUsed < 4 && _ps.bytes.Length - _ps.bytesUsed > 0)
		{
			int num2 = Math.Min(4, _ps.bytes.Length - _ps.bytesUsed);
			int num3 = stream.ReadAtLeast(_ps.bytes.AsSpan(_ps.bytesUsed), num2, throwOnEndOfStream: false);
			if (num3 < num2)
			{
				_ps.isStreamEof = true;
			}
			_ps.bytesUsed += num3;
		}
		if (encoding == null)
		{
			encoding = DetectEncoding();
		}
		SetupEncoding(encoding);
		EatPreamble();
		_documentStartBytePos = _ps.bytePos;
		_ps.eolNormalized = !_normalize;
		_ps.appendMode = true;
		ReadData();
	}

	private void InitTextReaderInput(string baseUriStr, TextReader input)
	{
		InitTextReaderInput(baseUriStr, null, input);
	}

	private void InitTextReaderInput(string baseUriStr, Uri baseUri, TextReader input)
	{
		_ps.textReader = input;
		_ps.baseUriStr = baseUriStr;
		_ps.baseUri = baseUri;
		if (_ps.chars == null)
		{
			if (_laterInitParam != null && _laterInitParam.useAsync)
			{
				_ps.chars = new char[32769];
			}
			else
			{
				_ps.chars = new char[4097];
			}
		}
		_ps.encoding = Encoding.Unicode;
		_ps.eolNormalized = !_normalize;
		_ps.appendMode = true;
		ReadData();
	}

	private void InitStringInput(string baseUriStr, Encoding originalEncoding, string str)
	{
		_ps.baseUriStr = baseUriStr;
		_ps.baseUri = null;
		int length = str.Length;
		_ps.chars = new char[length + 1];
		str.CopyTo(0, _ps.chars, 0, str.Length);
		_ps.charsUsed = length;
		_ps.chars[length] = '\0';
		_ps.encoding = originalEncoding;
		_ps.eolNormalized = !_normalize;
		_ps.isEof = true;
	}

	private void InitFragmentReader(XmlNodeType fragmentType, XmlParserContext parserContext, bool allowXmlDeclFragment)
	{
		_fragmentParserContext = parserContext;
		if (parserContext != null)
		{
			if (parserContext.NamespaceManager != null)
			{
				_namespaceManager = parserContext.NamespaceManager;
				_xmlContext.defaultNamespace = _namespaceManager.LookupNamespace(string.Empty);
			}
			else
			{
				_namespaceManager = new XmlNamespaceManager(_nameTable);
			}
			_ps.baseUriStr = parserContext.BaseURI;
			_ps.baseUri = null;
			_xmlContext.xmlLang = parserContext.XmlLang;
			_xmlContext.xmlSpace = parserContext.XmlSpace;
		}
		else
		{
			_namespaceManager = new XmlNamespaceManager(_nameTable);
			_ps.baseUriStr = string.Empty;
			_ps.baseUri = null;
		}
		_reportedBaseUri = _ps.baseUriStr;
		if (fragmentType <= XmlNodeType.Attribute)
		{
			if (fragmentType != XmlNodeType.Element)
			{
				if (fragmentType != XmlNodeType.Attribute)
				{
					goto IL_012e;
				}
				_ps.appendMode = false;
				_parsingFunction = ParsingFunction.SwitchToInteractive;
				_nextParsingFunction = ParsingFunction.FragmentAttribute;
			}
			else
			{
				_nextParsingFunction = ParsingFunction.DocumentContent;
			}
		}
		else if (fragmentType != XmlNodeType.Document)
		{
			if (fragmentType != XmlNodeType.XmlDeclaration || !allowXmlDeclFragment)
			{
				goto IL_012e;
			}
			_ps.appendMode = false;
			_parsingFunction = ParsingFunction.SwitchToInteractive;
			_nextParsingFunction = ParsingFunction.XmlDeclarationFragment;
		}
		_fragmentType = fragmentType;
		_fragment = true;
		return;
		IL_012e:
		Throw("Xml_PartialContentNodeTypeNotSupportedEx", fragmentType.ToString());
	}

	private void ProcessDtdFromParserContext(XmlParserContext context)
	{
		switch (_dtdProcessing)
		{
		case DtdProcessing.Prohibit:
			ThrowWithoutLineInfo("Xml_DtdIsProhibitedEx");
			break;
		case DtdProcessing.Parse:
			ParseDtdFromParserContext();
			break;
		case DtdProcessing.Ignore:
			break;
		}
	}

	private void OpenUrl()
	{
		XmlResolver tempResolver = GetTempResolver();
		if (_ps.baseUri == null)
		{
			_ps.baseUri = tempResolver.ResolveUri(null, _url);
			_ps.baseUriStr = _ps.baseUri.ToString();
		}
		try
		{
			_ps.stream = (Stream)tempResolver.GetEntity(_ps.baseUri, null, typeof(Stream));
		}
		catch
		{
			SetErrorState();
			throw;
		}
		if (_ps.stream == null)
		{
			ThrowWithoutLineInfo("Xml_CannotResolveUrl", _ps.baseUriStr);
		}
		InitStreamInput(_ps.baseUri, _ps.baseUriStr, _ps.stream, null);
		_reportedEncoding = _ps.encoding;
	}

	private Encoding DetectEncoding()
	{
		if (_ps.bytesUsed < 2)
		{
			return null;
		}
		int num = (_ps.bytes[0] << 8) | _ps.bytes[1];
		int num2 = ((_ps.bytesUsed >= 4) ? ((_ps.bytes[2] << 8) | _ps.bytes[3]) : 0);
		switch (num)
		{
		case 0:
			switch (num2)
			{
			case 65279:
				return Ucs4Encoding.UCS4_Bigendian;
			case 60:
				return Ucs4Encoding.UCS4_Bigendian;
			case 65534:
				return Ucs4Encoding.UCS4_2143;
			case 15360:
				return Ucs4Encoding.UCS4_2143;
			}
			break;
		case 65279:
			if (num2 == 0)
			{
				return Ucs4Encoding.UCS4_3412;
			}
			return Encoding.BigEndianUnicode;
		case 65534:
			if (num2 == 0)
			{
				return Ucs4Encoding.UCS4_Littleendian;
			}
			return Encoding.Unicode;
		case 15360:
			if (num2 == 0)
			{
				return Ucs4Encoding.UCS4_Littleendian;
			}
			return Encoding.Unicode;
		case 60:
			if (num2 == 0)
			{
				return Ucs4Encoding.UCS4_3412;
			}
			return Encoding.BigEndianUnicode;
		case 19567:
			if (num2 == 42900)
			{
				Throw("Xml_UnknownEncoding", "ebcdic");
			}
			break;
		case 61371:
			if ((num2 & 0xFF00) == 48896)
			{
				return new UTF8Encoding(encoderShouldEmitUTF8Identifier: true, throwOnInvalidBytes: true);
			}
			break;
		}
		return null;
	}

	private void SetupEncoding(Encoding encoding)
	{
		if (encoding == null)
		{
			_ps.encoding = Encoding.UTF8;
			_ps.decoder = new SafeAsciiDecoder();
			return;
		}
		_ps.encoding = encoding;
		_ = _ps;
		string webName = _ps.encoding.WebName;
		Decoder decoder = ((webName == "utf-16") ? new UTF16Decoder(bigEndian: false) : ((!(webName == "utf-16BE")) ? encoding.GetDecoder() : new UTF16Decoder(bigEndian: true)));
		_ps.decoder = decoder;
	}

	private void EatPreamble()
	{
		ReadOnlySpan<byte> preamble = _ps.encoding.Preamble;
		if (((ReadOnlySpan<byte>)_ps.bytes.AsSpan(0, _ps.bytesUsed)).StartsWith(preamble))
		{
			_ps.bytePos = preamble.Length;
		}
	}

	private void SwitchEncoding(Encoding newEncoding)
	{
		if ((newEncoding.WebName != _ps.encoding.WebName || _ps.decoder is SafeAsciiDecoder) && !_afterResetState)
		{
			UnDecodeChars();
			_ps.appendMode = false;
			SetupEncoding(newEncoding);
			ReadData();
		}
	}

	private Encoding CheckEncoding(string newEncodingName)
	{
		if (_ps.stream == null)
		{
			return _ps.encoding;
		}
		if (string.Equals(newEncodingName, "ucs-2", StringComparison.OrdinalIgnoreCase) || string.Equals(newEncodingName, "utf-16", StringComparison.OrdinalIgnoreCase) || string.Equals(newEncodingName, "iso-10646-ucs-2", StringComparison.OrdinalIgnoreCase) || string.Equals(newEncodingName, "ucs-4", StringComparison.OrdinalIgnoreCase))
		{
			if (_ps.encoding.WebName != "utf-16BE" && _ps.encoding.WebName != "utf-16" && !string.Equals(newEncodingName, "ucs-4", StringComparison.OrdinalIgnoreCase))
			{
				if (_afterResetState)
				{
					Throw("Xml_EncodingSwitchAfterResetState", newEncodingName);
				}
				else
				{
					ThrowWithoutLineInfo("Xml_MissingByteOrderMark");
				}
			}
			return _ps.encoding;
		}
		Encoding encoding = null;
		if (string.Equals(newEncodingName, "utf-8", StringComparison.OrdinalIgnoreCase))
		{
			encoding = UTF8BomThrowing;
		}
		else
		{
			try
			{
				encoding = Encoding.GetEncoding(newEncodingName);
			}
			catch (NotSupportedException innerException)
			{
				Throw("Xml_UnknownEncoding", newEncodingName, innerException);
			}
			catch (ArgumentException innerException2)
			{
				Throw("Xml_UnknownEncoding", newEncodingName, innerException2);
			}
		}
		if (_afterResetState && _ps.encoding.WebName != encoding.WebName)
		{
			Throw("Xml_EncodingSwitchAfterResetState", newEncodingName);
		}
		return encoding;
	}

	private void UnDecodeChars()
	{
		if (_maxCharactersInDocument > 0)
		{
			_charactersInDocument -= _ps.charsUsed - _ps.charPos;
		}
		if (_maxCharactersFromEntities > 0 && InEntity)
		{
			_charactersFromEntities -= _ps.charsUsed - _ps.charPos;
		}
		_ps.bytePos = _documentStartBytePos;
		if (_ps.charPos > 0)
		{
			_ps.bytePos += _ps.encoding.GetByteCount(_ps.chars, 0, _ps.charPos);
		}
		_ps.charsUsed = _ps.charPos;
		_ps.isEof = false;
	}

	private void SwitchEncodingToUTF8()
	{
		SwitchEncoding(UTF8BomThrowing);
	}

	private int ReadData()
	{
		if (_ps.isEof)
		{
			return 0;
		}
		int num;
		if (_ps.appendMode)
		{
			if (_ps.charsUsed == _ps.chars.Length - 1)
			{
				for (int i = 0; i < _attrCount; i++)
				{
					_nodes[_index + i + 1].OnBufferInvalidated();
				}
				char[] array = new char[_ps.chars.Length * 2];
				BlockCopyChars(_ps.chars, 0, array, 0, _ps.chars.Length);
				_ps.chars = array;
			}
			if (_ps.stream != null && _ps.bytesUsed - _ps.bytePos < 6 && _ps.bytes.Length - _ps.bytesUsed < 6)
			{
				byte[] array2 = new byte[_ps.bytes.Length * 2];
				BlockCopy(_ps.bytes, 0, array2, 0, _ps.bytesUsed);
				_ps.bytes = array2;
			}
			num = _ps.chars.Length - _ps.charsUsed - 1;
			if (num > 80)
			{
				num = 80;
			}
		}
		else
		{
			int num2 = _ps.chars.Length;
			if (num2 - _ps.charsUsed <= num2 / 2)
			{
				for (int j = 0; j < _attrCount; j++)
				{
					_nodes[_index + j + 1].OnBufferInvalidated();
				}
				int num3 = _ps.charsUsed - _ps.charPos;
				if (num3 < num2 - 1)
				{
					_ps.lineStartPos -= _ps.charPos;
					if (num3 > 0)
					{
						BlockCopyChars(_ps.chars, _ps.charPos, _ps.chars, 0, num3);
					}
					_ps.charPos = 0;
					_ps.charsUsed = num3;
				}
				else
				{
					char[] array3 = new char[_ps.chars.Length * 2];
					BlockCopyChars(_ps.chars, 0, array3, 0, _ps.chars.Length);
					_ps.chars = array3;
				}
			}
			if (_ps.stream != null)
			{
				int num4 = _ps.bytesUsed - _ps.bytePos;
				if (num4 <= 128)
				{
					if (num4 == 0)
					{
						_ps.bytesUsed = 0;
					}
					else
					{
						BlockCopy(_ps.bytes, _ps.bytePos, _ps.bytes, 0, num4);
						_ps.bytesUsed = num4;
					}
					_ps.bytePos = 0;
				}
			}
			num = _ps.chars.Length - _ps.charsUsed - 1;
		}
		if (_ps.stream != null)
		{
			if (!_ps.isStreamEof && _ps.bytePos == _ps.bytesUsed && _ps.bytes.Length - _ps.bytesUsed > 0)
			{
				int num5 = _ps.stream.Read(_ps.bytes, _ps.bytesUsed, _ps.bytes.Length - _ps.bytesUsed);
				if (num5 == 0)
				{
					_ps.isStreamEof = true;
				}
				_ps.bytesUsed += num5;
			}
			int bytePos = _ps.bytePos;
			num = GetChars(num);
			if (num == 0 && _ps.bytePos != bytePos)
			{
				return ReadData();
			}
		}
		else if (_ps.textReader != null)
		{
			num = _ps.textReader.Read(_ps.chars, _ps.charsUsed, _ps.chars.Length - _ps.charsUsed - 1);
			_ps.charsUsed += num;
		}
		else
		{
			num = 0;
		}
		RegisterConsumedCharacters(num, InEntity);
		if (num == 0)
		{
			_ps.isEof = true;
		}
		_ps.chars[_ps.charsUsed] = '\0';
		return num;
	}

	private int GetChars(int maxCharsCount)
	{
		int bytesUsed = _ps.bytesUsed - _ps.bytePos;
		if (bytesUsed == 0)
		{
			return 0;
		}
		int charsUsed;
		try
		{
			_ps.decoder.Convert(_ps.bytes, _ps.bytePos, bytesUsed, _ps.chars, _ps.charsUsed, maxCharsCount, flush: false, out bytesUsed, out charsUsed, out var _);
		}
		catch (ArgumentException)
		{
			InvalidCharRecovery(ref bytesUsed, out charsUsed);
		}
		_ps.bytePos += bytesUsed;
		_ps.charsUsed += charsUsed;
		return charsUsed;
	}

	private void InvalidCharRecovery(ref int bytesCount, out int charsCount)
	{
		int num = 0;
		int i = 0;
		try
		{
			int bytesUsed;
			for (; i < bytesCount; i += bytesUsed)
			{
				_ps.decoder.Convert(_ps.bytes, _ps.bytePos + i, 1, _ps.chars, _ps.charsUsed + num, 2, flush: false, out bytesUsed, out var charsUsed, out var _);
				num += charsUsed;
			}
		}
		catch (ArgumentException)
		{
		}
		if (num == 0)
		{
			Throw(_ps.charsUsed, "Xml_InvalidCharInThisEncoding");
		}
		charsCount = num;
		bytesCount = i;
	}

	internal void Close(bool closeInput)
	{
		if (_parsingFunction != ParsingFunction.ReaderClosed)
		{
			while (InEntity)
			{
				PopParsingState();
			}
			_ps.Close(closeInput);
			_curNode = NodeData.None;
			_parsingFunction = ParsingFunction.ReaderClosed;
			_reportedEncoding = null;
			_reportedBaseUri = string.Empty;
			_readState = ReadState.Closed;
			_fullAttrCleanup = false;
			ResetAttributes();
			_laterInitParam = null;
		}
	}

	private void ShiftBuffer(int sourcePos, int destPos, int count)
	{
		BlockCopyChars(_ps.chars, sourcePos, _ps.chars, destPos, count);
	}

	private bool ParseXmlDeclaration(bool isTextDecl)
	{
		do
		{
			if (_ps.charsUsed - _ps.charPos < 6)
			{
				continue;
			}
			if (!((ReadOnlySpan<char>)_ps.chars.AsSpan(_ps.charPos)).StartsWith("<?xml".AsSpan()) || XmlCharType.IsNameSingleChar(_ps.chars[_ps.charPos + 5]))
			{
				break;
			}
			if (!isTextDecl)
			{
				_curNode.SetLineInfo(_ps.LineNo, _ps.LinePos + 2);
				_curNode.SetNamedNode(XmlNodeType.XmlDeclaration, _xml);
			}
			_ps.charPos += 5;
			StringBuilder stringBuilder = (isTextDecl ? new StringBuilder() : _stringBuilder);
			int num = 0;
			Encoding encoding = null;
			while (true)
			{
				int length = stringBuilder.Length;
				int num2 = EatWhitespaces((num == 0) ? null : stringBuilder);
				if (_ps.chars[_ps.charPos] == '?')
				{
					stringBuilder.Length = length;
					if (_ps.chars[_ps.charPos + 1] == '>')
					{
						break;
					}
					if (_ps.charPos + 1 == _ps.charsUsed)
					{
						goto IL_073d;
					}
					ThrowUnexpectedToken("'>'");
				}
				if (num2 == 0 && num != 0)
				{
					ThrowUnexpectedToken("?>");
				}
				int num3 = ParseName();
				NodeData nodeData = null;
				switch (_ps.chars.AsSpan(_ps.charPos, num3 - _ps.charPos))
				{
				case "version":
					if (num == 0)
					{
						if (!isTextDecl)
						{
							nodeData = AddAttributeNoChecks("version", 1);
						}
						break;
					}
					goto default;
				case "encoding":
					if (num == 1 || (isTextDecl && num == 0))
					{
						if (!isTextDecl)
						{
							nodeData = AddAttributeNoChecks("encoding", 1);
						}
						num = 1;
						break;
					}
					goto default;
				case "standalone":
					if ((num == 1 || num == 2) && !isTextDecl)
					{
						nodeData = AddAttributeNoChecks("standalone", 1);
						num = 2;
						break;
					}
					goto default;
				default:
					Throw(isTextDecl ? "Xml_InvalidTextDecl" : "Xml_InvalidXmlDecl");
					break;
				}
				if (!isTextDecl)
				{
					nodeData.SetLineInfo(_ps.LineNo, _ps.LinePos);
				}
				stringBuilder.Append(_ps.chars, _ps.charPos, num3 - _ps.charPos);
				_ps.charPos = num3;
				if (_ps.chars[_ps.charPos] != '=')
				{
					EatWhitespaces(stringBuilder);
					if (_ps.chars[_ps.charPos] != '=')
					{
						ThrowUnexpectedToken("=");
					}
				}
				stringBuilder.Append('=');
				_ps.charPos++;
				char c = _ps.chars[_ps.charPos];
				if (c != '"' && c != '\'')
				{
					EatWhitespaces(stringBuilder);
					c = _ps.chars[_ps.charPos];
					if (c != '"' && c != '\'')
					{
						ThrowUnexpectedToken("\"", "'");
					}
				}
				stringBuilder.Append(c);
				_ps.charPos++;
				if (!isTextDecl)
				{
					nodeData.quoteChar = c;
					nodeData.SetLineInfo2(_ps.LineNo, _ps.LinePos);
				}
				int i = _ps.charPos;
				char[] chars;
				while (true)
				{
					for (chars = _ps.chars; XmlCharType.IsAttributeValueChar(chars[i]); i++)
					{
					}
					if (_ps.chars[i] == c)
					{
						break;
					}
					if (i == _ps.charsUsed)
					{
						if (ReadData() != 0)
						{
							continue;
						}
						goto IL_071b;
					}
					goto IL_0728;
				}
				switch (num)
				{
				case 0:
					if (((ReadOnlySpan<char>)_ps.chars.AsSpan(_ps.charPos)).StartsWith("1.0".AsSpan()))
					{
						if (!isTextDecl)
						{
							nodeData.SetValue(_ps.chars, _ps.charPos, i - _ps.charPos);
						}
						num = 1;
					}
					else
					{
						string arg = new string(_ps.chars, _ps.charPos, i - _ps.charPos);
						Throw("Xml_InvalidVersionNumber", arg);
					}
					break;
				case 1:
				{
					string text = new string(_ps.chars, _ps.charPos, i - _ps.charPos);
					encoding = CheckEncoding(text);
					if (!isTextDecl)
					{
						nodeData.SetValue(text);
					}
					num = 2;
					break;
				}
				case 2:
				{
					Span<char> span = _ps.chars.AsSpan(_ps.charPos, i - _ps.charPos);
					if (!span.SequenceEqual("yes".AsSpan()))
					{
						if (span.SequenceEqual("no".AsSpan()))
						{
							_standalone = false;
						}
						else
						{
							Throw("Xml_InvalidXmlDecl", _ps.LineNo, _ps.LinePos - 1);
						}
					}
					else
					{
						_standalone = true;
					}
					if (!isTextDecl)
					{
						nodeData.SetValue(_ps.chars, _ps.charPos, i - _ps.charPos);
					}
					num = 3;
					break;
				}
				}
				stringBuilder.Append(chars, _ps.charPos, i - _ps.charPos);
				stringBuilder.Append(c);
				_ps.charPos = i + 1;
				continue;
				IL_0728:
				Throw(isTextDecl ? "Xml_InvalidTextDecl" : "Xml_InvalidXmlDecl");
				goto IL_073d;
				IL_073d:
				if (_ps.isEof || ReadData() == 0)
				{
					Throw("Xml_UnexpectedEOF1");
				}
				continue;
				IL_071b:
				Throw("Xml_UnclosedQuote");
				goto IL_073d;
			}
			if (num == 0)
			{
				Throw(isTextDecl ? "Xml_InvalidTextDecl" : "Xml_InvalidXmlDecl");
			}
			_ps.charPos += 2;
			if (!isTextDecl)
			{
				_curNode.SetValue(stringBuilder.ToString());
				stringBuilder.Length = 0;
				_nextParsingFunction = _parsingFunction;
				_parsingFunction = ParsingFunction.ResetAttributesRootLevel;
			}
			if (encoding == null)
			{
				if (isTextDecl)
				{
					Throw("Xml_InvalidTextDecl");
				}
				if (_afterResetState)
				{
					string webName = _ps.encoding.WebName;
					if (webName != "utf-8" && webName != "utf-16" && webName != "utf-16BE" && !(_ps.encoding is Ucs4Encoding))
					{
						Throw("Xml_EncodingSwitchAfterResetState", (_ps.encoding.GetByteCount("A") == 1) ? "UTF-8" : "UTF-16");
					}
				}
				if (_ps.decoder is SafeAsciiDecoder)
				{
					SwitchEncodingToUTF8();
				}
			}
			else
			{
				SwitchEncoding(encoding);
			}
			_ps.appendMode = false;
			return true;
		}
		while (ReadData() != 0);
		if (!isTextDecl)
		{
			_parsingFunction = _nextParsingFunction;
		}
		if (_afterResetState)
		{
			string webName2 = _ps.encoding.WebName;
			if (webName2 != "utf-8" && webName2 != "utf-16" && webName2 != "utf-16BE" && !(_ps.encoding is Ucs4Encoding))
			{
				Throw("Xml_EncodingSwitchAfterResetState", (_ps.encoding.GetByteCount("A") == 1) ? "UTF-8" : "UTF-16");
			}
		}
		if (_ps.decoder is SafeAsciiDecoder)
		{
			SwitchEncodingToUTF8();
		}
		_ps.appendMode = false;
		return false;
	}

	private bool ParseDocumentContent()
	{
		bool flag = false;
		while (true)
		{
			bool flag2 = false;
			int charPos = _ps.charPos;
			char[] chars = _ps.chars;
			if (chars[charPos] == '<')
			{
				flag2 = true;
				if (_ps.charsUsed - charPos >= 4)
				{
					charPos++;
					switch (chars[charPos])
					{
					case '?':
						_ps.charPos = charPos + 1;
						if (!ParsePI())
						{
							continue;
						}
						return true;
					case '!':
						charPos++;
						if (_ps.charsUsed - charPos < 2)
						{
							break;
						}
						if (chars[charPos] == '-')
						{
							if (chars[charPos + 1] == '-')
							{
								_ps.charPos = charPos + 2;
								if (!ParseComment())
								{
									continue;
								}
								return true;
							}
							ThrowUnexpectedToken(charPos + 1, "-");
							break;
						}
						if (chars[charPos] == '[')
						{
							if (_fragmentType != XmlNodeType.Document)
							{
								charPos++;
								if (_ps.charsUsed - charPos < 6)
								{
									break;
								}
								if (((ReadOnlySpan<char>)chars.AsSpan(charPos)).StartsWith("CDATA[".AsSpan()))
								{
									_ps.charPos = charPos + 6;
									ParseCData();
									if (_fragmentType == XmlNodeType.None)
									{
										_fragmentType = XmlNodeType.Element;
									}
									return true;
								}
								ThrowUnexpectedToken(charPos, "CDATA[");
							}
							else
							{
								Throw(_ps.charPos, "Xml_InvalidRootData");
							}
							break;
						}
						if (_fragmentType == XmlNodeType.Document || _fragmentType == XmlNodeType.None)
						{
							_fragmentType = XmlNodeType.Document;
							_ps.charPos = charPos;
							if (!ParseDoctypeDecl())
							{
								continue;
							}
							return true;
						}
						if (ParseUnexpectedToken(charPos) == "DOCTYPE")
						{
							Throw("Xml_BadDTDLocation");
						}
						else
						{
							ThrowUnexpectedToken(charPos, "<!--", "<[CDATA[");
						}
						break;
					case '/':
						Throw(charPos + 1, "Xml_UnexpectedEndTag");
						break;
					default:
						if (_rootElementParsed)
						{
							if (_fragmentType == XmlNodeType.Document)
							{
								Throw(charPos, "Xml_MultipleRoots");
							}
							if (_fragmentType == XmlNodeType.None)
							{
								_fragmentType = XmlNodeType.Element;
							}
						}
						_ps.charPos = charPos;
						_rootElementParsed = true;
						ParseElement();
						return true;
					}
				}
			}
			else if (chars[charPos] == '&')
			{
				if (_fragmentType != XmlNodeType.Document)
				{
					if (_fragmentType == XmlNodeType.None)
					{
						_fragmentType = XmlNodeType.Element;
					}
					int charRefEndPos;
					switch (HandleEntityReference(isInAttributeValue: false, EntityExpandType.OnlyGeneral, out charRefEndPos))
					{
					case EntityType.Unexpanded:
						if (_parsingFunction == ParsingFunction.EntityReference)
						{
							_parsingFunction = _nextParsingFunction;
						}
						ParseEntityReference();
						return true;
					case EntityType.CharacterDec:
					case EntityType.CharacterHex:
					case EntityType.CharacterNamed:
						if (ParseText())
						{
							return true;
						}
						break;
					}
					continue;
				}
				Throw(charPos, "Xml_InvalidRootData");
			}
			else if (charPos != _ps.charsUsed && (!(_v1Compat || flag) || chars[charPos] != 0))
			{
				if (_fragmentType == XmlNodeType.Document)
				{
					if (ParseRootLevelWhitespace())
					{
						return true;
					}
				}
				else if (ParseText())
				{
					if (_fragmentType == XmlNodeType.None && _curNode.type == XmlNodeType.Text)
					{
						_fragmentType = XmlNodeType.Element;
					}
					return true;
				}
				continue;
			}
			if (ReadData() == 0)
			{
				if (flag2)
				{
					Throw("Xml_InvalidRootData");
				}
				if (!InEntity)
				{
					break;
				}
				if (HandleEntityEnd(checkEntityNesting: true))
				{
					SetupEndEntityNodeInContent();
					return true;
				}
			}
		}
		if (!_rootElementParsed && _fragmentType == XmlNodeType.Document)
		{
			ThrowWithoutLineInfo("Xml_MissingRoot");
		}
		if (_fragmentType == XmlNodeType.None)
		{
			_fragmentType = ((!_rootElementParsed) ? XmlNodeType.Element : XmlNodeType.Document);
		}
		OnEof();
		return false;
	}

	private bool ParseElementContent()
	{
		while (true)
		{
			int charPos = _ps.charPos;
			char[] chars = _ps.chars;
			switch (chars[charPos])
			{
			case '<':
				switch (chars[charPos + 1])
				{
				case '?':
					_ps.charPos = charPos + 2;
					if (!ParsePI())
					{
						continue;
					}
					return true;
				case '!':
					charPos += 2;
					if (_ps.charsUsed - charPos < 2)
					{
						break;
					}
					if (chars[charPos] == '-')
					{
						if (chars[charPos + 1] == '-')
						{
							_ps.charPos = charPos + 2;
							if (!ParseComment())
							{
								continue;
							}
							return true;
						}
						ThrowUnexpectedToken(charPos + 1, "-");
					}
					else if (chars[charPos] == '[')
					{
						charPos++;
						if (_ps.charsUsed - charPos >= 6)
						{
							if (((ReadOnlySpan<char>)chars.AsSpan(charPos)).StartsWith("CDATA[".AsSpan()))
							{
								_ps.charPos = charPos + 6;
								ParseCData();
								return true;
							}
							ThrowUnexpectedToken(charPos, "CDATA[");
						}
					}
					else if (ParseUnexpectedToken(charPos) == "DOCTYPE")
					{
						Throw("Xml_BadDTDLocation");
					}
					else
					{
						ThrowUnexpectedToken(charPos, "<!--", "<[CDATA[");
					}
					break;
				case '/':
					_ps.charPos = charPos + 2;
					ParseEndElement();
					return true;
				default:
					if (charPos + 1 != _ps.charsUsed)
					{
						_ps.charPos = charPos + 1;
						ParseElement();
						return true;
					}
					break;
				}
				break;
			case '&':
				if (!ParseText())
				{
					continue;
				}
				return true;
			default:
				if (charPos != _ps.charsUsed)
				{
					if (!ParseText())
					{
						continue;
					}
					return true;
				}
				break;
			}
			if (ReadData() != 0)
			{
				continue;
			}
			if (_ps.charsUsed - _ps.charPos != 0)
			{
				ThrowUnclosedElements();
			}
			if (!InEntity)
			{
				if (_index == 0 && _fragmentType != XmlNodeType.Document)
				{
					OnEof();
					return false;
				}
				ThrowUnclosedElements();
			}
			if (HandleEntityEnd(checkEntityNesting: true))
			{
				break;
			}
		}
		SetupEndEntityNodeInContent();
		return true;
	}

	private void ThrowUnclosedElements()
	{
		if (_index == 0 && _curNode.type != XmlNodeType.Element)
		{
			Throw(_ps.charsUsed, "Xml_UnexpectedEOF1");
			return;
		}
		int num = ((_parsingFunction == ParsingFunction.InIncrementalRead) ? _index : (_index - 1));
		_stringBuilder.Length = 0;
		while (num >= 0)
		{
			NodeData nodeData = _nodes[num];
			if (nodeData.type == XmlNodeType.Element)
			{
				_stringBuilder.Append(nodeData.GetNameWPrefix(_nameTable));
				if (num > 0)
				{
					_stringBuilder.Append(", ");
				}
				else
				{
					_stringBuilder.Append('.');
				}
			}
			num--;
		}
		Throw(_ps.charsUsed, "Xml_UnexpectedEOFInElementContent", _stringBuilder.ToString());
	}

	private void ParseElement()
	{
		int num = _ps.charPos;
		char[] chars = _ps.chars;
		int colonPos = -1;
		_curNode.SetLineInfo(_ps.LineNo, _ps.LinePos);
		while (true)
		{
			if (XmlCharType.IsStartNCNameSingleChar(chars[num]))
			{
				num++;
				while (true)
				{
					if (XmlCharType.IsNCNameSingleChar(chars[num]))
					{
						num++;
						continue;
					}
					if (chars[num] != ':')
					{
						break;
					}
					if (colonPos == -1)
					{
						goto IL_0088;
					}
					if (!_supportNamespaces)
					{
						num++;
						continue;
					}
					goto IL_006c;
				}
				if (num + 1 < _ps.charsUsed)
				{
					break;
				}
			}
			goto IL_00a0;
			IL_0088:
			colonPos = num;
			num++;
			continue;
			IL_00a0:
			num = ParseQName(out colonPos);
			chars = _ps.chars;
			break;
			IL_006c:
			Throw(num, "Xml_BadNameChar", XmlException.BuildCharExceptionArgs(':', '\0'));
			goto IL_00a0;
		}
		_namespaceManager.PushScope();
		if (colonPos == -1 || !_supportNamespaces)
		{
			_curNode.SetNamedNode(XmlNodeType.Element, _nameTable.Add(chars, _ps.charPos, num - _ps.charPos));
		}
		else
		{
			int charPos = _ps.charPos;
			int num2 = colonPos - charPos;
			if (num2 == _lastPrefix.Length && ((ReadOnlySpan<char>)chars.AsSpan(charPos)).StartsWith(_lastPrefix.AsSpan()))
			{
				_curNode.SetNamedNode(XmlNodeType.Element, _nameTable.Add(chars, colonPos + 1, num - colonPos - 1), _lastPrefix, null);
			}
			else
			{
				_curNode.SetNamedNode(XmlNodeType.Element, _nameTable.Add(chars, colonPos + 1, num - colonPos - 1), _nameTable.Add(chars, _ps.charPos, num2), null);
				_lastPrefix = _curNode.prefix;
			}
		}
		char c = chars[num];
		if (XmlCharType.IsWhiteSpace(c))
		{
			_ps.charPos = num;
			ParseAttributes();
			return;
		}
		switch (c)
		{
		case '>':
			_ps.charPos = num + 1;
			_parsingFunction = ParsingFunction.MoveToElementContent;
			break;
		case '/':
			if (num + 1 == _ps.charsUsed)
			{
				_ps.charPos = num;
				if (ReadData() == 0)
				{
					Throw(num, "Xml_UnexpectedEOF", ">");
				}
				num = _ps.charPos;
				chars = _ps.chars;
			}
			if (chars[num + 1] == '>')
			{
				_curNode.IsEmptyElement = true;
				_nextParsingFunction = _parsingFunction;
				_parsingFunction = ParsingFunction.PopEmptyElementContext;
				_ps.charPos = num + 2;
			}
			else
			{
				ThrowUnexpectedToken(num, ">");
			}
			break;
		default:
			Throw(num, "Xml_BadNameChar", XmlException.BuildCharExceptionArgs(chars, _ps.charsUsed, num));
			break;
		}
		if (_addDefaultAttributesAndNormalize)
		{
			AddDefaultAttributesAndNormalize();
		}
		ElementNamespaceLookup();
	}

	private void AddDefaultAttributesAndNormalize()
	{
		IDtdAttributeListInfo dtdAttributeListInfo = _dtdInfo.LookupAttributeList(_curNode.localName, _curNode.prefix);
		if (dtdAttributeListInfo == null)
		{
			return;
		}
		if (_normalize && dtdAttributeListInfo.HasNonCDataAttributes)
		{
			for (int i = _index + 1; i < _index + 1 + _attrCount; i++)
			{
				NodeData nodeData = _nodes[i];
				IDtdAttributeInfo dtdAttributeInfo = dtdAttributeListInfo.LookupAttribute(nodeData.prefix, nodeData.localName);
				if (dtdAttributeInfo == null || !dtdAttributeInfo.IsNonCDataType)
				{
					continue;
				}
				if (DtdValidation && _standalone && dtdAttributeInfo.IsDeclaredInExternal)
				{
					string stringValue = nodeData.StringValue;
					nodeData.TrimSpacesInValue();
					if (stringValue != nodeData.StringValue)
					{
						SendValidationEvent(XmlSeverityType.Error, "Sch_StandAloneNormalization", nodeData.GetNameWPrefix(_nameTable), nodeData.LineNo, nodeData.LinePos);
					}
				}
				else
				{
					nodeData.TrimSpacesInValue();
				}
			}
		}
		IEnumerable<IDtdDefaultAttributeInfo> enumerable = dtdAttributeListInfo.LookupDefaultAttributes();
		if (enumerable == null)
		{
			return;
		}
		int attrCount = _attrCount;
		NodeData[] array = null;
		if (_attrCount >= 64)
		{
			array = new NodeData[_attrCount];
			Array.Copy(_nodes, _index + 1, array, 0, _attrCount);
			object[] array2 = array;
			Array.Sort(array2, DtdDefaultAttributeInfoToNodeDataComparer.Instance);
		}
		foreach (IDtdDefaultAttributeInfo item in enumerable)
		{
			if (AddDefaultAttributeDtd(item, array) && DtdValidation && _standalone && item.IsDeclaredInExternal)
			{
				string prefix = item.Prefix;
				string arg = ((prefix.Length == 0) ? item.LocalName : (prefix + ":" + item.LocalName));
				SendValidationEvent(XmlSeverityType.Error, "Sch_UnSpecifiedDefaultAttributeInExternalStandalone", arg, _curNode.LineNo, _curNode.LinePos);
			}
		}
		if (attrCount == 0 && _attrNeedNamespaceLookup)
		{
			AttributeNamespaceLookup();
			_attrNeedNamespaceLookup = false;
		}
	}

	private void ParseEndElement()
	{
		NodeData nodeData = _nodes[_index - 1];
		int length = nodeData.prefix.Length;
		int length2 = nodeData.localName.Length;
		while (_ps.charsUsed - _ps.charPos < length + length2 + 1 && ReadData() != 0)
		{
		}
		char[] chars = _ps.chars;
		int num;
		if (nodeData.prefix.Length == 0)
		{
			if (!((ReadOnlySpan<char>)chars.AsSpan(_ps.charPos)).StartsWith(nodeData.localName.AsSpan()))
			{
				ThrowTagMismatch(nodeData);
			}
			num = length2;
		}
		else
		{
			int num2 = _ps.charPos + length;
			if (!((ReadOnlySpan<char>)chars.AsSpan(_ps.charPos)).StartsWith(nodeData.prefix.AsSpan()) || chars[num2] != ':' || !((ReadOnlySpan<char>)chars.AsSpan(num2 + 1)).StartsWith(nodeData.localName.AsSpan()))
			{
				ThrowTagMismatch(nodeData);
			}
			num = length2 + length + 1;
		}
		LineInfo lineInfo = new LineInfo(_ps.lineNo, _ps.LinePos);
		int num3;
		while (true)
		{
			num3 = _ps.charPos + num;
			chars = _ps.chars;
			if (num3 != _ps.charsUsed)
			{
				if (XmlCharType.IsNCNameSingleChar(chars[num3]) || chars[num3] == ':')
				{
					ThrowTagMismatch(nodeData);
				}
				if (chars[num3] != '>')
				{
					char c;
					while (XmlCharType.IsWhiteSpace(c = chars[num3]))
					{
						num3++;
						switch (c)
						{
						case '\n':
							OnNewLine(num3);
							break;
						case '\r':
							if (chars[num3] == '\n')
							{
								num3++;
							}
							else if (num3 == _ps.charsUsed && !_ps.isEof)
							{
								break;
							}
							OnNewLine(num3);
							break;
						}
					}
				}
				if (chars[num3] == '>')
				{
					break;
				}
				if (num3 != _ps.charsUsed)
				{
					ThrowUnexpectedToken(num3, ">");
				}
			}
			if (ReadData() == 0)
			{
				ThrowUnclosedElements();
			}
		}
		_index--;
		_curNode = _nodes[_index];
		nodeData.lineInfo = lineInfo;
		nodeData.type = XmlNodeType.EndElement;
		_ps.charPos = num3 + 1;
		_nextParsingFunction = ((_index > 0) ? _parsingFunction : ParsingFunction.DocumentContent);
		_parsingFunction = ParsingFunction.PopElementContext;
	}

	private void ThrowTagMismatch(NodeData startTag)
	{
		if (startTag.type == XmlNodeType.Element)
		{
			int colonPos;
			int num = ParseQName(out colonPos);
			Throw("Xml_TagMismatchEx", new string[4]
			{
				startTag.GetNameWPrefix(_nameTable),
				startTag.lineInfo.lineNo.ToString(CultureInfo.InvariantCulture),
				startTag.lineInfo.linePos.ToString(CultureInfo.InvariantCulture),
				new string(_ps.chars, _ps.charPos, num - _ps.charPos)
			});
		}
		else
		{
			Throw("Xml_UnexpectedEndTag");
		}
	}

	private void ParseAttributes()
	{
		int num = _ps.charPos;
		char[] chars = _ps.chars;
		NodeData nodeData = null;
		while (true)
		{
			int num2 = 0;
			while (true)
			{
				char c;
				int num3;
				if (XmlCharType.IsWhiteSpace(c = chars[num]))
				{
					switch (c)
					{
					case '\n':
						OnNewLine(num + 1);
						num2++;
						goto IL_0085;
					case '\r':
						if (chars[num + 1] == '\n')
						{
							OnNewLine(num + 2);
							num2++;
							num++;
							goto IL_0085;
						}
						if (num + 1 != _ps.charsUsed)
						{
							OnNewLine(num + 1);
							num2++;
							goto IL_0085;
						}
						break;
					default:
						goto IL_0085;
					}
					_ps.charPos = num;
				}
				else
				{
					num3 = 0;
					char c2;
					if (XmlCharType.IsStartNCNameSingleChar(c2 = chars[num]))
					{
						num3 = 1;
					}
					if (num3 != 0)
					{
						goto IL_0171;
					}
					if (c2 == '>')
					{
						_ps.charPos = num + 1;
						_parsingFunction = ParsingFunction.MoveToElementContent;
						goto IL_0438;
					}
					if (c2 == '/')
					{
						if (num + 1 != _ps.charsUsed)
						{
							if (chars[num + 1] == '>')
							{
								_ps.charPos = num + 2;
								_curNode.IsEmptyElement = true;
								_nextParsingFunction = _parsingFunction;
								_parsingFunction = ParsingFunction.PopEmptyElementContext;
								goto IL_0438;
							}
							ThrowUnexpectedToken(num + 1, ">");
							goto IL_0171;
						}
					}
					else if (num != _ps.charsUsed)
					{
						if (c2 != ':' || _supportNamespaces)
						{
							Throw(num, "Xml_BadStartNameChar", XmlException.BuildCharExceptionArgs(chars, _ps.charsUsed, num));
						}
						goto IL_0171;
					}
				}
				_ps.lineNo -= num2;
				if (ReadData() != 0)
				{
					num = _ps.charPos;
					chars = _ps.chars;
				}
				else
				{
					ThrowUnclosedElements();
				}
				break;
				IL_0438:
				if (_addDefaultAttributesAndNormalize)
				{
					AddDefaultAttributesAndNormalize();
				}
				ElementNamespaceLookup();
				if (_attrNeedNamespaceLookup)
				{
					AttributeNamespaceLookup();
					_attrNeedNamespaceLookup = false;
				}
				if (_attrDuplWalkCount >= 64)
				{
					AttributeDuplCheck();
				}
				return;
				IL_0085:
				num++;
				continue;
				IL_0171:
				if (num == _ps.charPos)
				{
					ThrowExpectingWhitespace(num);
				}
				_ps.charPos = num;
				int linePos = _ps.LinePos;
				int colonPos = -1;
				num += num3;
				while (true)
				{
					char c3;
					if (XmlCharType.IsNCNameSingleChar(c3 = chars[num]))
					{
						num++;
						continue;
					}
					if (c3 == ':')
					{
						if (colonPos != -1)
						{
							if (_supportNamespaces)
							{
								Throw(num, "Xml_BadNameChar", XmlException.BuildCharExceptionArgs(':', '\0'));
								break;
							}
							num++;
							continue;
						}
						colonPos = num;
						num++;
						if (XmlCharType.IsStartNCNameSingleChar(chars[num]))
						{
							num++;
							continue;
						}
						num = ParseQName(out colonPos);
						chars = _ps.chars;
						break;
					}
					if (num + 1 >= _ps.charsUsed)
					{
						num = ParseQName(out colonPos);
						chars = _ps.chars;
					}
					break;
				}
				nodeData = AddAttribute(num, colonPos);
				nodeData.SetLineInfo(_ps.LineNo, linePos);
				if (chars[num] != '=')
				{
					_ps.charPos = num;
					EatWhitespaces(null);
					num = _ps.charPos;
					if (chars[num] != '=')
					{
						ThrowUnexpectedToken("=");
					}
				}
				num++;
				char c4 = chars[num];
				if (c4 != '"' && c4 != '\'')
				{
					_ps.charPos = num;
					EatWhitespaces(null);
					num = _ps.charPos;
					c4 = chars[num];
					if (c4 != '"' && c4 != '\'')
					{
						ThrowUnexpectedToken("\"", "'");
					}
				}
				num++;
				_ps.charPos = num;
				nodeData.quoteChar = c4;
				nodeData.SetLineInfo2(_ps.LineNo, _ps.LinePos);
				char c5;
				while (XmlCharType.IsAttributeValueChar(c5 = chars[num]))
				{
					num++;
				}
				if (c5 == c4)
				{
					nodeData.SetValue(chars, _ps.charPos, num - _ps.charPos);
					num++;
					_ps.charPos = num;
				}
				else
				{
					ParseAttributeValueSlow(num, c4, nodeData);
					num = _ps.charPos;
					chars = _ps.chars;
				}
				if (nodeData.prefix.Length == 0)
				{
					if (Ref.Equal(nodeData.localName, _xmlNs))
					{
						OnDefaultNamespaceDecl(nodeData);
					}
				}
				else if (Ref.Equal(nodeData.prefix, _xmlNs))
				{
					OnNamespaceDecl(nodeData);
				}
				else if (Ref.Equal(nodeData.prefix, _xml))
				{
					OnXmlReservedAttribute(nodeData);
				}
				break;
			}
		}
	}

	private void ElementNamespaceLookup()
	{
		if (_curNode.prefix.Length == 0)
		{
			_curNode.ns = _xmlContext.defaultNamespace;
		}
		else
		{
			_curNode.ns = LookupNamespace(_curNode);
		}
	}

	private void AttributeNamespaceLookup()
	{
		for (int i = _index + 1; i < _index + _attrCount + 1; i++)
		{
			NodeData nodeData = _nodes[i];
			if (nodeData.type == XmlNodeType.Attribute && nodeData.prefix.Length > 0)
			{
				nodeData.ns = LookupNamespace(nodeData);
			}
		}
	}

	private void AttributeDuplCheck()
	{
		if (_attrCount < 64)
		{
			for (int i = _index + 1; i < _index + 1 + _attrCount; i++)
			{
				NodeData nodeData = _nodes[i];
				for (int j = i + 1; j < _index + 1 + _attrCount; j++)
				{
					if (Ref.Equal(nodeData.localName, _nodes[j].localName) && Ref.Equal(nodeData.ns, _nodes[j].ns))
					{
						Throw("Xml_DupAttributeName", _nodes[j].GetNameWPrefix(_nameTable), _nodes[j].LineNo, _nodes[j].LinePos);
					}
				}
			}
			return;
		}
		if (_attrDuplSet == null)
		{
			_attrDuplSet = new HashSet<NodeData>(NodeData.AtomizedNameEqualityComparer.Instance);
		}
		_attrDuplSet.Clear();
		for (int k = _index + 1; k < _index + 1 + _attrCount; k++)
		{
			if (!_attrDuplSet.Add(_nodes[k]))
			{
				Throw("Xml_DupAttributeName", _nodes[k].GetNameWPrefix(_nameTable), _nodes[k].LineNo, _nodes[k].LinePos);
			}
		}
	}

	private void OnDefaultNamespaceDecl(NodeData attr)
	{
		if (_supportNamespaces)
		{
			string text = _nameTable.Add(attr.StringValue);
			attr.ns = _nameTable.Add("http://www.w3.org/2000/xmlns/");
			if (!_curNode.xmlContextPushed)
			{
				PushXmlContext();
			}
			_xmlContext.defaultNamespace = text;
			AddNamespace(string.Empty, text, attr);
		}
	}

	private void OnNamespaceDecl(NodeData attr)
	{
		if (_supportNamespaces)
		{
			string text = _nameTable.Add(attr.StringValue);
			if (text.Length == 0)
			{
				Throw("Xml_BadNamespaceDecl", attr.lineInfo2.lineNo, attr.lineInfo2.linePos - 1);
			}
			AddNamespace(attr.localName, text, attr);
		}
	}

	private void OnXmlReservedAttribute(NodeData attr)
	{
		string localName = attr.localName;
		if (!(localName == "space"))
		{
			if (localName == "lang")
			{
				if (!_curNode.xmlContextPushed)
				{
					PushXmlContext();
				}
				_xmlContext.xmlLang = attr.StringValue;
			}
			return;
		}
		if (!_curNode.xmlContextPushed)
		{
			PushXmlContext();
		}
		ReadOnlySpan<char> span = attr.StringValue.AsSpan().Trim(XmlConvert.WhitespaceChars);
		if (!span.SequenceEqual("preserve".AsSpan()))
		{
			if (span.SequenceEqual("default".AsSpan()))
			{
				_xmlContext.xmlSpace = XmlSpace.Default;
			}
			else
			{
				Throw("Xml_InvalidXmlSpace", attr.StringValue, attr.lineInfo.lineNo, attr.lineInfo.linePos);
			}
		}
		else
		{
			_xmlContext.xmlSpace = XmlSpace.Preserve;
		}
	}

	private void ParseAttributeValueSlow(int curPos, char quoteChar, NodeData attr)
	{
		int charRefEndPos = curPos;
		char[] chars = _ps.chars;
		int entityId = _ps.entityId;
		int num = 0;
		LineInfo lineInfo = new LineInfo(_ps.lineNo, _ps.LinePos);
		NodeData lastChunk = null;
		while (true)
		{
			if (XmlCharType.IsAttributeValueChar(chars[charRefEndPos]))
			{
				charRefEndPos++;
				continue;
			}
			if (charRefEndPos - _ps.charPos > 0)
			{
				_stringBuilder.Append(chars, _ps.charPos, charRefEndPos - _ps.charPos);
				_ps.charPos = charRefEndPos;
			}
			if (chars[charRefEndPos] == quoteChar && entityId == _ps.entityId)
			{
				break;
			}
			switch (chars[charRefEndPos])
			{
			case '\n':
				charRefEndPos++;
				OnNewLine(charRefEndPos);
				if (_normalize)
				{
					_stringBuilder.Append(' ');
					_ps.charPos++;
				}
				continue;
			case '\r':
				if (chars[charRefEndPos + 1] == '\n')
				{
					charRefEndPos += 2;
					if (_normalize)
					{
						_stringBuilder.Append(_ps.eolNormalized ? "  " : " ");
						_ps.charPos = charRefEndPos;
					}
				}
				else
				{
					if (charRefEndPos + 1 >= _ps.charsUsed && !_ps.isEof)
					{
						break;
					}
					charRefEndPos++;
					if (_normalize)
					{
						_stringBuilder.Append(' ');
						_ps.charPos = charRefEndPos;
					}
				}
				OnNewLine(charRefEndPos);
				continue;
			case '\t':
				charRefEndPos++;
				if (_normalize)
				{
					_stringBuilder.Append(' ');
					_ps.charPos++;
				}
				continue;
			case '"':
			case '\'':
			case '>':
				charRefEndPos++;
				continue;
			case '<':
				Throw(charRefEndPos, "Xml_BadAttributeChar", XmlException.BuildCharExceptionArgs('<', '\0'));
				break;
			case '&':
			{
				if (charRefEndPos - _ps.charPos > 0)
				{
					_stringBuilder.Append(chars, _ps.charPos, charRefEndPos - _ps.charPos);
				}
				_ps.charPos = charRefEndPos;
				int entityId2 = _ps.entityId;
				LineInfo lineInfo2 = new LineInfo(_ps.lineNo, _ps.LinePos + 1);
				switch (HandleEntityReference(isInAttributeValue: true, EntityExpandType.All, out charRefEndPos))
				{
				case EntityType.Unexpanded:
					if (_parsingMode == ParsingMode.Full && _ps.entityId == entityId)
					{
						int num3 = _stringBuilder.Length - num;
						if (num3 > 0)
						{
							NodeData nodeData3 = new NodeData();
							nodeData3.lineInfo = lineInfo;
							nodeData3.depth = attr.depth + 1;
							nodeData3.SetValueNode(XmlNodeType.Text, _stringBuilder.ToString(num, num3));
							AddAttributeChunkToList(attr, nodeData3, ref lastChunk);
						}
						_ps.charPos++;
						string text = ParseEntityName();
						NodeData nodeData4 = new NodeData();
						nodeData4.lineInfo = lineInfo2;
						nodeData4.depth = attr.depth + 1;
						nodeData4.SetNamedNode(XmlNodeType.EntityReference, text);
						AddAttributeChunkToList(attr, nodeData4, ref lastChunk);
						_stringBuilder.Append('&');
						_stringBuilder.Append(text);
						_stringBuilder.Append(';');
						num = _stringBuilder.Length;
						lineInfo.Set(_ps.LineNo, _ps.LinePos);
						_fullAttrCleanup = true;
					}
					else
					{
						_ps.charPos++;
						ParseEntityName();
					}
					charRefEndPos = _ps.charPos;
					break;
				case EntityType.ExpandedInAttribute:
					if (_parsingMode == ParsingMode.Full && entityId2 == entityId)
					{
						int num2 = _stringBuilder.Length - num;
						if (num2 > 0)
						{
							NodeData nodeData = new NodeData();
							nodeData.lineInfo = lineInfo;
							nodeData.depth = attr.depth + 1;
							nodeData.SetValueNode(XmlNodeType.Text, _stringBuilder.ToString(num, num2));
							AddAttributeChunkToList(attr, nodeData, ref lastChunk);
						}
						NodeData nodeData2 = new NodeData();
						nodeData2.lineInfo = lineInfo2;
						nodeData2.depth = attr.depth + 1;
						nodeData2.SetNamedNode(XmlNodeType.EntityReference, _ps.entity.Name);
						AddAttributeChunkToList(attr, nodeData2, ref lastChunk);
						_fullAttrCleanup = true;
					}
					charRefEndPos = _ps.charPos;
					break;
				default:
					charRefEndPos = _ps.charPos;
					break;
				case EntityType.CharacterDec:
				case EntityType.CharacterHex:
				case EntityType.CharacterNamed:
					break;
				}
				chars = _ps.chars;
				continue;
			}
			default:
				if (charRefEndPos == _ps.charsUsed)
				{
					break;
				}
				if (XmlCharType.IsHighSurrogate(chars[charRefEndPos]))
				{
					if (charRefEndPos + 1 == _ps.charsUsed)
					{
						break;
					}
					charRefEndPos++;
					if (XmlCharType.IsLowSurrogate(chars[charRefEndPos]))
					{
						charRefEndPos++;
						continue;
					}
				}
				ThrowInvalidChar(chars, _ps.charsUsed, charRefEndPos);
				break;
			}
			if (ReadData() == 0)
			{
				if (_ps.charsUsed - _ps.charPos > 0)
				{
					if (_ps.chars[_ps.charPos] != '\r')
					{
						Throw("Xml_UnexpectedEOF1");
					}
				}
				else
				{
					if (!InEntity)
					{
						if (_fragmentType == XmlNodeType.Attribute)
						{
							if (entityId != _ps.entityId)
							{
								Throw("Xml_EntityRefNesting");
							}
							break;
						}
						Throw("Xml_UnclosedQuote");
					}
					if (HandleEntityEnd(checkEntityNesting: true))
					{
						Throw("Xml_InternalError");
					}
					if (entityId == _ps.entityId)
					{
						num = _stringBuilder.Length;
						lineInfo.Set(_ps.LineNo, _ps.LinePos);
					}
				}
			}
			charRefEndPos = _ps.charPos;
			chars = _ps.chars;
		}
		if (attr.nextAttrValueChunk != null)
		{
			int num4 = _stringBuilder.Length - num;
			if (num4 > 0)
			{
				NodeData nodeData5 = new NodeData();
				nodeData5.lineInfo = lineInfo;
				nodeData5.depth = attr.depth + 1;
				nodeData5.SetValueNode(XmlNodeType.Text, _stringBuilder.ToString(num, num4));
				AddAttributeChunkToList(attr, nodeData5, ref lastChunk);
			}
		}
		_ps.charPos = charRefEndPos + 1;
		attr.SetValue(_stringBuilder.ToString());
		_stringBuilder.Length = 0;
	}

	private static void AddAttributeChunkToList(NodeData attr, NodeData chunk, ref NodeData lastChunk)
	{
		if (lastChunk == null)
		{
			lastChunk = chunk;
			attr.nextAttrValueChunk = chunk;
		}
		else
		{
			lastChunk.nextAttrValueChunk = chunk;
			lastChunk = chunk;
		}
	}

	private bool ParseText()
	{
		int outOrChars = 0;
		int endPos;
		int startPos;
		if (_parsingMode != ParsingMode.Full)
		{
			while (!ParseText(out endPos, out startPos, ref outOrChars))
			{
			}
		}
		else
		{
			_curNode.SetLineInfo(_ps.LineNo, _ps.LinePos);
			if (ParseText(out var startPos2, out var endPos2, ref outOrChars))
			{
				if (endPos2 - startPos2 != 0)
				{
					XmlNodeType textNodeType = GetTextNodeType(outOrChars);
					if (textNodeType != XmlNodeType.None)
					{
						_curNode.SetValueNode(textNodeType, _ps.chars, startPos2, endPos2 - startPos2);
						return true;
					}
				}
			}
			else if (_v1Compat)
			{
				do
				{
					if (endPos2 - startPos2 > 0)
					{
						_stringBuilder.Append(_ps.chars, startPos2, endPos2 - startPos2);
					}
				}
				while (!ParseText(out startPos2, out endPos2, ref outOrChars));
				if (endPos2 - startPos2 > 0)
				{
					_stringBuilder.Append(_ps.chars, startPos2, endPos2 - startPos2);
				}
				XmlNodeType textNodeType2 = GetTextNodeType(outOrChars);
				if (textNodeType2 != XmlNodeType.None)
				{
					_curNode.SetValueNode(textNodeType2, _stringBuilder.ToString());
					_stringBuilder.Length = 0;
					return true;
				}
				_stringBuilder.Length = 0;
			}
			else
			{
				if (outOrChars > 32)
				{
					_curNode.SetValueNode(XmlNodeType.Text, _ps.chars, startPos2, endPos2 - startPos2);
					_nextParsingFunction = _parsingFunction;
					_parsingFunction = ParsingFunction.PartialTextValue;
					return true;
				}
				if (endPos2 - startPos2 > 0)
				{
					_stringBuilder.Append(_ps.chars, startPos2, endPos2 - startPos2);
				}
				bool flag;
				do
				{
					flag = ParseText(out startPos2, out endPos2, ref outOrChars);
					if (endPos2 - startPos2 > 0)
					{
						_stringBuilder.Append(_ps.chars, startPos2, endPos2 - startPos2);
					}
				}
				while (!flag && outOrChars <= 32 && _stringBuilder.Length < 4096);
				XmlNodeType xmlNodeType = ((_stringBuilder.Length < 4096) ? GetTextNodeType(outOrChars) : XmlNodeType.Text);
				if (xmlNodeType != XmlNodeType.None)
				{
					_curNode.SetValueNode(xmlNodeType, _stringBuilder.ToString());
					_stringBuilder.Length = 0;
					if (!flag)
					{
						_nextParsingFunction = _parsingFunction;
						_parsingFunction = ParsingFunction.PartialTextValue;
					}
					return true;
				}
				_stringBuilder.Length = 0;
				if (!flag)
				{
					while (!ParseText(out startPos, out endPos, ref outOrChars))
					{
					}
				}
			}
		}
		if (_parsingFunction == ParsingFunction.ReportEndEntity)
		{
			SetupEndEntityNodeInContent();
			_parsingFunction = _nextParsingFunction;
			return true;
		}
		if (_parsingFunction == ParsingFunction.EntityReference)
		{
			_parsingFunction = _nextNextParsingFunction;
			ParseEntityReference();
			return true;
		}
		return false;
	}

	private bool ParseText(out int startPos, out int endPos, ref int outOrChars)
	{
		char[] chars = _ps.chars;
		int charRefEndPos = _ps.charPos;
		int num = 0;
		int num2 = -1;
		int num3 = outOrChars;
		char c;
		while (true)
		{
			if (XmlCharType.IsTextChar(c = chars[charRefEndPos]))
			{
				num3 |= c;
				charRefEndPos++;
				continue;
			}
			switch (c)
			{
			case '\t':
				charRefEndPos++;
				continue;
			case '\n':
				charRefEndPos++;
				OnNewLine(charRefEndPos);
				continue;
			case '\r':
				if (chars[charRefEndPos + 1] == '\n')
				{
					if (!_ps.eolNormalized && _parsingMode == ParsingMode.Full)
					{
						if (charRefEndPos - _ps.charPos > 0)
						{
							if (num == 0)
							{
								num = 1;
								num2 = charRefEndPos;
							}
							else
							{
								ShiftBuffer(num2 + num, num2, charRefEndPos - num2 - num);
								num2 = charRefEndPos - num;
								num++;
							}
						}
						else
						{
							_ps.charPos++;
						}
					}
					charRefEndPos += 2;
				}
				else
				{
					if (charRefEndPos + 1 >= _ps.charsUsed && !_ps.isEof)
					{
						goto IL_0341;
					}
					if (!_ps.eolNormalized)
					{
						chars[charRefEndPos] = '\n';
					}
					charRefEndPos++;
				}
				OnNewLine(charRefEndPos);
				continue;
			case '&':
			{
				int num5;
				if ((num5 = ParseCharRefInline(charRefEndPos, out var charCount, out var entityType)) > 0)
				{
					if (num > 0)
					{
						ShiftBuffer(num2 + num, num2, charRefEndPos - num2 - num);
					}
					num2 = charRefEndPos - num;
					num += num5 - charRefEndPos - charCount;
					charRefEndPos = num5;
					if (!XmlCharType.IsWhiteSpace(chars[num5 - charCount]) || (_v1Compat && entityType == EntityType.CharacterDec))
					{
						num3 |= 0xFF;
					}
					continue;
				}
				if (charRefEndPos > _ps.charPos)
				{
					break;
				}
				switch (HandleEntityReference(isInAttributeValue: false, EntityExpandType.All, out charRefEndPos))
				{
				case EntityType.Unexpanded:
					break;
				case EntityType.CharacterDec:
					if (!_v1Compat)
					{
						goto case EntityType.CharacterHex;
					}
					num3 |= 0xFF;
					goto IL_023f;
				case EntityType.CharacterHex:
				case EntityType.CharacterNamed:
					if (!XmlCharType.IsWhiteSpace(_ps.chars[charRefEndPos - 1]))
					{
						num3 |= 0xFF;
					}
					goto IL_023f;
				default:
					{
						charRefEndPos = _ps.charPos;
						goto IL_023f;
					}
					IL_023f:
					chars = _ps.chars;
					continue;
				}
				_nextParsingFunction = _parsingFunction;
				_parsingFunction = ParsingFunction.EntityReference;
				goto IL_03fe;
			}
			case ']':
				if (_ps.charsUsed - charRefEndPos >= 3 || _ps.isEof)
				{
					if (chars[charRefEndPos + 1] == ']' && chars[charRefEndPos + 2] == '>')
					{
						Throw(charRefEndPos, "Xml_CDATAEndInText");
					}
					num3 |= 0x5D;
					charRefEndPos++;
					continue;
				}
				goto IL_0341;
			default:
				if (charRefEndPos != _ps.charsUsed)
				{
					char c2 = chars[charRefEndPos];
					if (XmlCharType.IsHighSurrogate(c2))
					{
						if (charRefEndPos + 1 == _ps.charsUsed)
						{
							goto IL_0341;
						}
						charRefEndPos++;
						if (XmlCharType.IsLowSurrogate(chars[charRefEndPos]))
						{
							charRefEndPos++;
							num3 |= c2;
							continue;
						}
					}
					int num4 = charRefEndPos - _ps.charPos;
					if (ZeroEndingStream(charRefEndPos))
					{
						charRefEndPos = _ps.charPos + num4;
						break;
					}
					ThrowInvalidChar(_ps.chars, _ps.charsUsed, _ps.charPos + num4);
				}
				goto IL_0341;
			case '<':
				break;
				IL_0341:
				if (charRefEndPos > _ps.charPos)
				{
					break;
				}
				if (ReadData() == 0)
				{
					if (_ps.charsUsed - _ps.charPos <= 0)
					{
						if (InEntity)
						{
							if (!HandleEntityEnd(checkEntityNesting: true))
							{
								goto IL_03e1;
							}
							_nextParsingFunction = _parsingFunction;
							_parsingFunction = ParsingFunction.ReportEndEntity;
						}
						goto IL_03fe;
					}
					if (_ps.chars[_ps.charPos] != '\r' && _ps.chars[_ps.charPos] != ']')
					{
						Throw("Xml_UnexpectedEOF1");
					}
				}
				goto IL_03e1;
				IL_03e1:
				charRefEndPos = _ps.charPos;
				chars = _ps.chars;
				continue;
				IL_03fe:
				startPos = (endPos = charRefEndPos);
				return true;
			}
			break;
		}
		if (_parsingMode == ParsingMode.Full && num > 0)
		{
			ShiftBuffer(num2 + num, num2, charRefEndPos - num2 - num);
		}
		startPos = _ps.charPos;
		endPos = charRefEndPos - num;
		_ps.charPos = charRefEndPos;
		outOrChars = num3;
		return c == '<';
	}

	private void FinishPartialValue()
	{
		_curNode.CopyTo(_readValueOffset, _stringBuilder);
		int outOrChars = 0;
		int startPos;
		int endPos;
		while (!ParseText(out startPos, out endPos, ref outOrChars))
		{
			_stringBuilder.Append(_ps.chars, startPos, endPos - startPos);
		}
		_stringBuilder.Append(_ps.chars, startPos, endPos - startPos);
		_curNode.SetValue(_stringBuilder.ToString());
		_stringBuilder.Length = 0;
	}

	private void FinishOtherValueIterator()
	{
		switch (_parsingFunction)
		{
		case ParsingFunction.InReadValueChunk:
			if (_incReadState == IncrementalReadState.ReadValueChunk_OnPartialValue)
			{
				FinishPartialValue();
				_incReadState = IncrementalReadState.ReadValueChunk_OnCachedValue;
			}
			else if (_readValueOffset > 0)
			{
				_curNode.SetValue(_curNode.StringValue.Substring(_readValueOffset));
				_readValueOffset = 0;
			}
			break;
		case ParsingFunction.InReadContentAsBinary:
		case ParsingFunction.InReadElementContentAsBinary:
			switch (_incReadState)
			{
			case IncrementalReadState.ReadContentAsBinary_OnPartialValue:
				FinishPartialValue();
				_incReadState = IncrementalReadState.ReadContentAsBinary_OnCachedValue;
				break;
			case IncrementalReadState.ReadContentAsBinary_OnCachedValue:
				if (_readValueOffset > 0)
				{
					_curNode.SetValue(_curNode.StringValue.Substring(_readValueOffset));
					_readValueOffset = 0;
				}
				break;
			case IncrementalReadState.ReadContentAsBinary_End:
				_curNode.SetValue(string.Empty);
				break;
			}
			break;
		case ParsingFunction.InReadAttributeValue:
			break;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SkipPartialTextValue()
	{
		int outOrChars = 0;
		_parsingFunction = _nextParsingFunction;
		int startPos;
		int endPos;
		while (!ParseText(out startPos, out endPos, ref outOrChars))
		{
		}
	}

	private void FinishReadValueChunk()
	{
		_readValueOffset = 0;
		if (_incReadState == IncrementalReadState.ReadValueChunk_OnPartialValue)
		{
			SkipPartialTextValue();
			return;
		}
		_parsingFunction = _nextParsingFunction;
		_nextParsingFunction = _nextNextParsingFunction;
	}

	private void FinishReadContentAsBinary()
	{
		_readValueOffset = 0;
		if (_incReadState == IncrementalReadState.ReadContentAsBinary_OnPartialValue)
		{
			SkipPartialTextValue();
		}
		else
		{
			_parsingFunction = _nextParsingFunction;
			_nextParsingFunction = _nextNextParsingFunction;
		}
		if (_incReadState != IncrementalReadState.ReadContentAsBinary_End)
		{
			while (MoveToNextContentNode(moveIfOnContentNode: true))
			{
			}
		}
	}

	private void FinishReadElementContentAsBinary()
	{
		FinishReadContentAsBinary();
		if (_curNode.type != XmlNodeType.EndElement)
		{
			Throw("Xml_InvalidNodeType", _curNode.type.ToString());
		}
		_outerReader.Read();
	}

	private bool ParseRootLevelWhitespace()
	{
		XmlNodeType whitespaceType = GetWhitespaceType();
		if (whitespaceType == XmlNodeType.None)
		{
			EatWhitespaces(null);
			if (_ps.chars[_ps.charPos] == '<' || _ps.charsUsed - _ps.charPos == 0 || ZeroEndingStream(_ps.charPos))
			{
				return false;
			}
		}
		else
		{
			_curNode.SetLineInfo(_ps.LineNo, _ps.LinePos);
			EatWhitespaces(_stringBuilder);
			if (_ps.chars[_ps.charPos] == '<' || _ps.charsUsed - _ps.charPos == 0 || ZeroEndingStream(_ps.charPos))
			{
				if (_stringBuilder.Length > 0)
				{
					_curNode.SetValueNode(whitespaceType, _stringBuilder.ToString());
					_stringBuilder.Length = 0;
					return true;
				}
				return false;
			}
		}
		if (XmlCharType.IsCharData(_ps.chars[_ps.charPos]))
		{
			Throw("Xml_InvalidRootData");
		}
		else
		{
			ThrowInvalidChar(_ps.chars, _ps.charsUsed, _ps.charPos);
		}
		return false;
	}

	private void ParseEntityReference()
	{
		_ps.charPos++;
		_curNode.SetLineInfo(_ps.LineNo, _ps.LinePos);
		_curNode.SetNamedNode(XmlNodeType.EntityReference, ParseEntityName());
	}

	private EntityType HandleEntityReference(bool isInAttributeValue, EntityExpandType expandType, out int charRefEndPos)
	{
		if (_ps.charPos + 1 == _ps.charsUsed && ReadData() == 0)
		{
			Throw("Xml_UnexpectedEOF1");
		}
		if (_ps.chars[_ps.charPos + 1] == '#')
		{
			charRefEndPos = ParseNumericCharRef(expandType != EntityExpandType.OnlyGeneral, null, out var entityType);
			return entityType;
		}
		charRefEndPos = ParseNamedCharRef(expandType != EntityExpandType.OnlyGeneral, null);
		if (charRefEndPos >= 0)
		{
			return EntityType.CharacterNamed;
		}
		if (expandType == EntityExpandType.OnlyCharacter || (_entityHandling != EntityHandling.ExpandEntities && (!isInAttributeValue || !_validatingReaderCompatFlag)))
		{
			return EntityType.Unexpanded;
		}
		_ps.charPos++;
		int linePos = _ps.LinePos;
		int num;
		try
		{
			num = ParseName();
		}
		catch (XmlException)
		{
			Throw("Xml_ErrorParsingEntityName", _ps.LineNo, linePos);
			return EntityType.Skipped;
		}
		if (_ps.chars[num] != ';')
		{
			ThrowUnexpectedToken(num, ";");
		}
		int linePos2 = _ps.LinePos;
		string name = _nameTable.Add(_ps.chars, _ps.charPos, num - _ps.charPos);
		_ps.charPos = num + 1;
		charRefEndPos = -1;
		EntityType result = HandleGeneralEntityReference(name, isInAttributeValue, pushFakeEntityIfNullResolver: false, linePos2);
		_reportedBaseUri = _ps.baseUriStr;
		_reportedEncoding = _ps.encoding;
		return result;
	}

	private EntityType HandleGeneralEntityReference(string name, bool isInAttributeValue, bool pushFakeEntityIfNullResolver, int entityStartLinePos)
	{
		IDtdEntityInfo dtdEntityInfo = null;
		if (_dtdInfo == null && _fragmentParserContext != null && _fragmentParserContext.HasDtdInfo && _dtdProcessing == DtdProcessing.Parse)
		{
			ParseDtdFromParserContext();
		}
		if (_dtdInfo == null || (dtdEntityInfo = _dtdInfo.LookupEntity(name)) == null)
		{
			if (_disableUndeclaredEntityCheck)
			{
				dtdEntityInfo = new SchemaEntity(new XmlQualifiedName(name), isParameter: false)
				{
					Text = string.Empty
				};
			}
			else
			{
				Throw("Xml_UndeclaredEntity", name, _ps.LineNo, entityStartLinePos);
			}
		}
		if (dtdEntityInfo.IsUnparsedEntity)
		{
			if (_disableUndeclaredEntityCheck)
			{
				dtdEntityInfo = new SchemaEntity(new XmlQualifiedName(name), isParameter: false)
				{
					Text = string.Empty
				};
			}
			else
			{
				Throw("Xml_UnparsedEntityRef", name, _ps.LineNo, entityStartLinePos);
			}
		}
		if (_standalone && dtdEntityInfo.IsDeclaredInExternal)
		{
			Throw("Xml_ExternalEntityInStandAloneDocument", dtdEntityInfo.Name, _ps.LineNo, entityStartLinePos);
		}
		if (dtdEntityInfo.IsExternal)
		{
			if (isInAttributeValue)
			{
				Throw("Xml_ExternalEntityInAttValue", name, _ps.LineNo, entityStartLinePos);
				return EntityType.Skipped;
			}
			if (_parsingMode == ParsingMode.SkipContent)
			{
				return EntityType.Skipped;
			}
			if (IsResolverNull)
			{
				if (pushFakeEntityIfNullResolver)
				{
					PushExternalEntity(dtdEntityInfo);
					_curNode.entityId = _ps.entityId;
					return EntityType.FakeExpanded;
				}
				return EntityType.Skipped;
			}
			PushExternalEntity(dtdEntityInfo);
			_curNode.entityId = _ps.entityId;
			return EntityType.Expanded;
		}
		if (_parsingMode == ParsingMode.SkipContent)
		{
			return EntityType.Skipped;
		}
		PushInternalEntity(dtdEntityInfo);
		_curNode.entityId = _ps.entityId;
		if (!isInAttributeValue || !_validatingReaderCompatFlag)
		{
			return EntityType.Expanded;
		}
		return EntityType.ExpandedInAttribute;
	}

	private bool HandleEntityEnd(bool checkEntityNesting)
	{
		if (_parsingStatesStackTop == -1)
		{
			Throw("Xml_InternalError");
		}
		if (_ps.entityResolvedManually)
		{
			_index--;
			if (checkEntityNesting && _ps.entityId != _nodes[_index].entityId)
			{
				Throw("Xml_IncompleteEntity");
			}
			_lastEntity = _ps.entity;
			PopEntity();
			return true;
		}
		if (checkEntityNesting && _ps.entityId != _nodes[_index].entityId)
		{
			Throw("Xml_IncompleteEntity");
		}
		PopEntity();
		_reportedEncoding = _ps.encoding;
		_reportedBaseUri = _ps.baseUriStr;
		return false;
	}

	private void SetupEndEntityNodeInContent()
	{
		_reportedEncoding = _ps.encoding;
		_reportedBaseUri = _ps.baseUriStr;
		_curNode = _nodes[_index];
		_curNode.SetNamedNode(XmlNodeType.EndEntity, _lastEntity.Name);
		_curNode.lineInfo.Set(_ps.lineNo, _ps.LinePos - 1);
		if (_index == 0 && _parsingFunction == ParsingFunction.ElementContent)
		{
			_parsingFunction = ParsingFunction.DocumentContent;
		}
	}

	private void SetupEndEntityNodeInAttribute()
	{
		_curNode = _nodes[_index + _attrCount + 1];
		_curNode.lineInfo.linePos += _curNode.localName.Length;
		_curNode.type = XmlNodeType.EndEntity;
	}

	private bool ParsePI()
	{
		return ParsePI(null);
	}

	private bool ParsePI(StringBuilder piInDtdStringBuilder)
	{
		if (_parsingMode == ParsingMode.Full)
		{
			_curNode.SetLineInfo(_ps.LineNo, _ps.LinePos);
		}
		int num = ParseName();
		string text = _nameTable.Add(_ps.chars, _ps.charPos, num - _ps.charPos);
		if (string.Equals(text, "xml", StringComparison.OrdinalIgnoreCase))
		{
			Throw(text.Equals("xml") ? "Xml_XmlDeclNotFirst" : "Xml_InvalidPIName", text);
		}
		_ps.charPos = num;
		if (piInDtdStringBuilder == null)
		{
			if (!_ignorePIs && _parsingMode == ParsingMode.Full)
			{
				_curNode.SetNamedNode(XmlNodeType.ProcessingInstruction, text);
			}
		}
		else
		{
			piInDtdStringBuilder.Append(text);
		}
		char c = _ps.chars[_ps.charPos];
		if (EatWhitespaces(piInDtdStringBuilder) == 0)
		{
			if (_ps.charsUsed - _ps.charPos < 2)
			{
				ReadData();
			}
			if (c != '?' || _ps.chars[_ps.charPos + 1] != '>')
			{
				Throw("Xml_BadNameChar", XmlException.BuildCharExceptionArgs(_ps.chars, _ps.charsUsed, _ps.charPos));
			}
		}
		if (ParsePIValue(out var outStartPos, out var outEndPos))
		{
			if (piInDtdStringBuilder == null)
			{
				if (_ignorePIs)
				{
					return false;
				}
				if (_parsingMode == ParsingMode.Full)
				{
					_curNode.SetValue(_ps.chars, outStartPos, outEndPos - outStartPos);
				}
			}
			else
			{
				piInDtdStringBuilder.Append(_ps.chars, outStartPos, outEndPos - outStartPos);
			}
		}
		else
		{
			StringBuilder stringBuilder;
			if (piInDtdStringBuilder == null)
			{
				if (_ignorePIs || _parsingMode != ParsingMode.Full)
				{
					int outStartPos2;
					int outEndPos2;
					while (!ParsePIValue(out outStartPos2, out outEndPos2))
					{
					}
					return false;
				}
				stringBuilder = _stringBuilder;
			}
			else
			{
				stringBuilder = piInDtdStringBuilder;
			}
			do
			{
				stringBuilder.Append(_ps.chars, outStartPos, outEndPos - outStartPos);
			}
			while (!ParsePIValue(out outStartPos, out outEndPos));
			stringBuilder.Append(_ps.chars, outStartPos, outEndPos - outStartPos);
			if (piInDtdStringBuilder == null)
			{
				_curNode.SetValue(_stringBuilder.ToString());
				_stringBuilder.Length = 0;
			}
		}
		return true;
	}

	private bool ParsePIValue(out int outStartPos, out int outEndPos)
	{
		if (_ps.charsUsed - _ps.charPos < 2 && ReadData() == 0)
		{
			Throw(_ps.charsUsed, "Xml_UnexpectedEOF", "PI");
		}
		int num = _ps.charPos;
		char[] chars = _ps.chars;
		int num2 = 0;
		int num3 = -1;
		while (true)
		{
			char c;
			if (XmlCharType.IsTextChar(c = chars[num]) && c != '?')
			{
				num++;
				continue;
			}
			switch (chars[num])
			{
			case '?':
				if (chars[num + 1] == '>')
				{
					if (num2 > 0)
					{
						ShiftBuffer(num3 + num2, num3, num - num3 - num2);
						outEndPos = num - num2;
					}
					else
					{
						outEndPos = num;
					}
					outStartPos = _ps.charPos;
					_ps.charPos = num + 2;
					return true;
				}
				if (num + 1 != _ps.charsUsed)
				{
					num++;
					continue;
				}
				break;
			case '\n':
				num++;
				OnNewLine(num);
				continue;
			case '\r':
				if (chars[num + 1] == '\n')
				{
					if (!_ps.eolNormalized && _parsingMode == ParsingMode.Full)
					{
						if (num - _ps.charPos > 0)
						{
							if (num2 == 0)
							{
								num2 = 1;
								num3 = num;
							}
							else
							{
								ShiftBuffer(num3 + num2, num3, num - num3 - num2);
								num3 = num - num2;
								num2++;
							}
						}
						else
						{
							_ps.charPos++;
						}
					}
					num += 2;
				}
				else
				{
					if (num + 1 >= _ps.charsUsed && !_ps.isEof)
					{
						break;
					}
					if (!_ps.eolNormalized)
					{
						chars[num] = '\n';
					}
					num++;
				}
				OnNewLine(num);
				continue;
			case '\t':
			case '&':
			case '<':
			case ']':
				num++;
				continue;
			default:
				if (num == _ps.charsUsed)
				{
					break;
				}
				if (XmlCharType.IsHighSurrogate(chars[num]))
				{
					if (num + 1 == _ps.charsUsed)
					{
						break;
					}
					num++;
					if (XmlCharType.IsLowSurrogate(chars[num]))
					{
						num++;
						continue;
					}
				}
				ThrowInvalidChar(chars, _ps.charsUsed, num);
				continue;
			}
			break;
		}
		if (num2 > 0)
		{
			ShiftBuffer(num3 + num2, num3, num - num3 - num2);
			outEndPos = num - num2;
		}
		else
		{
			outEndPos = num;
		}
		outStartPos = _ps.charPos;
		_ps.charPos = num;
		return false;
	}

	private bool ParseComment()
	{
		if (_ignoreComments)
		{
			ParsingMode parsingMode = _parsingMode;
			_parsingMode = ParsingMode.SkipNode;
			ParseCDataOrComment(XmlNodeType.Comment);
			_parsingMode = parsingMode;
			return false;
		}
		ParseCDataOrComment(XmlNodeType.Comment);
		return true;
	}

	private void ParseCData()
	{
		ParseCDataOrComment(XmlNodeType.CDATA);
	}

	private void ParseCDataOrComment(XmlNodeType type)
	{
		if (_parsingMode == ParsingMode.Full)
		{
			_curNode.SetLineInfo(_ps.LineNo, _ps.LinePos);
			if (ParseCDataOrComment(type, out var outStartPos, out var outEndPos))
			{
				_curNode.SetValueNode(type, _ps.chars, outStartPos, outEndPos - outStartPos);
				return;
			}
			do
			{
				_stringBuilder.Append(_ps.chars, outStartPos, outEndPos - outStartPos);
			}
			while (!ParseCDataOrComment(type, out outStartPos, out outEndPos));
			_stringBuilder.Append(_ps.chars, outStartPos, outEndPos - outStartPos);
			_curNode.SetValueNode(type, _stringBuilder.ToString());
			_stringBuilder.Length = 0;
		}
		else
		{
			int outStartPos2;
			int outEndPos2;
			while (!ParseCDataOrComment(type, out outStartPos2, out outEndPos2))
			{
			}
		}
	}

	private bool ParseCDataOrComment(XmlNodeType type, out int outStartPos, out int outEndPos)
	{
		if (_ps.charsUsed - _ps.charPos < 3 && ReadData() == 0)
		{
			Throw("Xml_UnexpectedEOF", (type == XmlNodeType.Comment) ? "Comment" : "CDATA");
		}
		int num = _ps.charPos;
		char[] chars = _ps.chars;
		int num2 = 0;
		int num3 = -1;
		char c = ((type == XmlNodeType.Comment) ? '-' : ']');
		while (true)
		{
			char c2;
			if (XmlCharType.IsTextChar(c2 = chars[num]) && c2 != c)
			{
				num++;
				continue;
			}
			if (chars[num] == c)
			{
				if (chars[num + 1] == c)
				{
					if (chars[num + 2] == '>')
					{
						if (num2 > 0)
						{
							ShiftBuffer(num3 + num2, num3, num - num3 - num2);
							outEndPos = num - num2;
						}
						else
						{
							outEndPos = num;
						}
						outStartPos = _ps.charPos;
						_ps.charPos = num + 3;
						return true;
					}
					if (num + 2 == _ps.charsUsed)
					{
						break;
					}
					if (type == XmlNodeType.Comment)
					{
						Throw(num, "Xml_InvalidCommentChars");
					}
				}
				else if (num + 1 == _ps.charsUsed)
				{
					break;
				}
				num++;
				continue;
			}
			switch (chars[num])
			{
			case '\n':
				num++;
				OnNewLine(num);
				continue;
			case '\r':
				if (chars[num + 1] == '\n')
				{
					if (!_ps.eolNormalized && _parsingMode == ParsingMode.Full)
					{
						if (num - _ps.charPos > 0)
						{
							if (num2 == 0)
							{
								num2 = 1;
								num3 = num;
							}
							else
							{
								ShiftBuffer(num3 + num2, num3, num - num3 - num2);
								num3 = num - num2;
								num2++;
							}
						}
						else
						{
							_ps.charPos++;
						}
					}
					num += 2;
				}
				else
				{
					if (num + 1 >= _ps.charsUsed && !_ps.isEof)
					{
						break;
					}
					if (!_ps.eolNormalized)
					{
						chars[num] = '\n';
					}
					num++;
				}
				OnNewLine(num);
				continue;
			case '\t':
			case '&':
			case '<':
			case ']':
				num++;
				continue;
			default:
				if (num == _ps.charsUsed)
				{
					break;
				}
				if (XmlCharType.IsHighSurrogate(chars[num]))
				{
					if (num + 1 == _ps.charsUsed)
					{
						break;
					}
					num++;
					if (XmlCharType.IsLowSurrogate(chars[num]))
					{
						num++;
						continue;
					}
				}
				ThrowInvalidChar(chars, _ps.charsUsed, num);
				break;
			}
			break;
		}
		if (num2 > 0)
		{
			ShiftBuffer(num3 + num2, num3, num - num3 - num2);
			outEndPos = num - num2;
		}
		else
		{
			outEndPos = num;
		}
		outStartPos = _ps.charPos;
		_ps.charPos = num;
		return false;
	}

	private bool ParseDoctypeDecl()
	{
		if (_dtdProcessing == DtdProcessing.Prohibit)
		{
			ThrowWithoutLineInfo(_v1Compat ? "Xml_DtdIsProhibited" : "Xml_DtdIsProhibitedEx");
		}
		while (_ps.charsUsed - _ps.charPos < 8)
		{
			if (ReadData() == 0)
			{
				Throw("Xml_UnexpectedEOF", "DOCTYPE");
			}
		}
		if (!((ReadOnlySpan<char>)_ps.chars.AsSpan(_ps.charPos)).StartsWith("DOCTYPE".AsSpan()))
		{
			ThrowUnexpectedToken((!_rootElementParsed && _dtdInfo == null) ? "DOCTYPE" : "<!--");
		}
		if (!XmlCharType.IsWhiteSpace(_ps.chars[_ps.charPos + 7]))
		{
			ThrowExpectingWhitespace(_ps.charPos + 7);
		}
		if (_dtdInfo != null)
		{
			Throw(_ps.charPos - 2, "Xml_MultipleDTDsProvided");
		}
		if (_rootElementParsed)
		{
			Throw(_ps.charPos - 2, "Xml_DtdAfterRootElement");
		}
		_ps.charPos += 8;
		EatWhitespaces(null);
		if (_dtdProcessing == DtdProcessing.Parse)
		{
			_curNode.SetLineInfo(_ps.LineNo, _ps.LinePos);
			ParseDtd();
			_nextParsingFunction = _parsingFunction;
			_parsingFunction = ParsingFunction.ResetAttributesRootLevel;
			return true;
		}
		SkipDtd();
		return false;
	}

	private void ParseDtd()
	{
		IDtdParser dtdParser = DtdParser.Create();
		_dtdInfo = dtdParser.ParseInternalDtd(new DtdParserProxy(this), saveInternalSubset: true);
		if ((_validatingReaderCompatFlag || !_v1Compat) && (_dtdInfo.HasDefaultAttributes || _dtdInfo.HasNonCDataAttributes))
		{
			_addDefaultAttributesAndNormalize = true;
		}
		_curNode.SetNamedNode(XmlNodeType.DocumentType, _dtdInfo.Name.ToString(), string.Empty, null);
		_curNode.SetValue(_dtdInfo.InternalDtdSubset);
	}

	private void SkipDtd()
	{
		int colonPos;
		int charPos = ParseQName(out colonPos);
		_ps.charPos = charPos;
		EatWhitespaces(null);
		if (_ps.chars[_ps.charPos] == 'P')
		{
			while (_ps.charsUsed - _ps.charPos < 6)
			{
				if (ReadData() == 0)
				{
					Throw("Xml_UnexpectedEOF1");
				}
			}
			if (!((ReadOnlySpan<char>)_ps.chars.AsSpan(_ps.charPos)).StartsWith("PUBLIC".AsSpan()))
			{
				ThrowUnexpectedToken("PUBLIC");
			}
			_ps.charPos += 6;
			if (EatWhitespaces(null) == 0)
			{
				ThrowExpectingWhitespace(_ps.charPos);
			}
			SkipPublicOrSystemIdLiteral();
			if (EatWhitespaces(null) == 0)
			{
				ThrowExpectingWhitespace(_ps.charPos);
			}
			SkipPublicOrSystemIdLiteral();
			EatWhitespaces(null);
		}
		else if (_ps.chars[_ps.charPos] == 'S')
		{
			while (_ps.charsUsed - _ps.charPos < 6)
			{
				if (ReadData() == 0)
				{
					Throw("Xml_UnexpectedEOF1");
				}
			}
			if (!((ReadOnlySpan<char>)_ps.chars.AsSpan(_ps.charPos)).StartsWith("SYSTEM".AsSpan()))
			{
				ThrowUnexpectedToken("SYSTEM");
			}
			_ps.charPos += 6;
			if (EatWhitespaces(null) == 0)
			{
				ThrowExpectingWhitespace(_ps.charPos);
			}
			SkipPublicOrSystemIdLiteral();
			EatWhitespaces(null);
		}
		else if (_ps.chars[_ps.charPos] != '[' && _ps.chars[_ps.charPos] != '>')
		{
			Throw("Xml_ExpectExternalOrClose");
		}
		if (_ps.chars[_ps.charPos] == '[')
		{
			_ps.charPos++;
			SkipUntil(']', recognizeLiterals: true);
			EatWhitespaces(null);
			if (_ps.chars[_ps.charPos] != '>')
			{
				ThrowUnexpectedToken(">");
			}
		}
		else if (_ps.chars[_ps.charPos] == '>')
		{
			_curNode.SetValue(string.Empty);
		}
		else
		{
			Throw("Xml_ExpectSubOrClose");
		}
		_ps.charPos++;
	}

	private void SkipPublicOrSystemIdLiteral()
	{
		char c = _ps.chars[_ps.charPos];
		if (c != '"' && c != '\'')
		{
			ThrowUnexpectedToken("\"", "'");
		}
		_ps.charPos++;
		SkipUntil(c, recognizeLiterals: false);
	}

	private void SkipUntil(char stopChar, bool recognizeLiterals)
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		char c = '"';
		char[] chars = _ps.chars;
		int num = _ps.charPos;
		while (true)
		{
			char c2;
			if (XmlCharType.IsAttributeValueChar(c2 = chars[num]) && chars[num] != stopChar && c2 != '-' && c2 != '?')
			{
				num++;
				continue;
			}
			if (c2 == stopChar && !flag)
			{
				break;
			}
			_ps.charPos = num;
			switch (c2)
			{
			case '\n':
				num++;
				OnNewLine(num);
				continue;
			case '\r':
				if (chars[num + 1] == '\n')
				{
					num += 2;
				}
				else
				{
					if (num + 1 >= _ps.charsUsed && !_ps.isEof)
					{
						break;
					}
					num++;
				}
				OnNewLine(num);
				continue;
			case '<':
				if (chars[num + 1] == '?')
				{
					if (recognizeLiterals && !flag && !flag2)
					{
						flag3 = true;
						num += 2;
						continue;
					}
				}
				else if (chars[num + 1] == '!')
				{
					if (num + 3 >= _ps.charsUsed && !_ps.isEof)
					{
						break;
					}
					if (chars[num + 2] == '-' && chars[num + 3] == '-' && recognizeLiterals && !flag && !flag3)
					{
						flag2 = true;
						num += 4;
						continue;
					}
				}
				else if (num + 1 >= _ps.charsUsed && !_ps.isEof)
				{
					break;
				}
				num++;
				continue;
			case '-':
				if (flag2)
				{
					if (num + 2 >= _ps.charsUsed && !_ps.isEof)
					{
						break;
					}
					if (chars[num + 1] == '-' && chars[num + 2] == '>')
					{
						flag2 = false;
						num += 2;
						continue;
					}
				}
				num++;
				continue;
			case '?':
				if (flag3)
				{
					if (num + 1 >= _ps.charsUsed && !_ps.isEof)
					{
						break;
					}
					if (chars[num + 1] == '>')
					{
						flag3 = false;
						num++;
						continue;
					}
				}
				num++;
				continue;
			case '\t':
			case '&':
			case '>':
			case ']':
				num++;
				continue;
			case '"':
			case '\'':
				if (flag)
				{
					if (c == c2)
					{
						flag = false;
					}
				}
				else if (recognizeLiterals && !flag2 && !flag3)
				{
					flag = true;
					c = c2;
				}
				num++;
				continue;
			default:
				if (num == _ps.charsUsed)
				{
					break;
				}
				if (XmlCharType.IsHighSurrogate(chars[num]))
				{
					if (num + 1 == _ps.charsUsed)
					{
						break;
					}
					num++;
					if (XmlCharType.IsLowSurrogate(chars[num]))
					{
						num++;
						continue;
					}
				}
				ThrowInvalidChar(chars, _ps.charsUsed, num);
				break;
			}
			if (ReadData() == 0)
			{
				if (_ps.charsUsed - _ps.charPos > 0)
				{
					if (_ps.chars[_ps.charPos] != '\r')
					{
						Throw("Xml_UnexpectedEOF1");
					}
				}
				else
				{
					Throw("Xml_UnexpectedEOF1");
				}
			}
			chars = _ps.chars;
			num = _ps.charPos;
		}
		_ps.charPos = num + 1;
	}

	private int EatWhitespaces(StringBuilder sb)
	{
		int num = _ps.charPos;
		int num2 = 0;
		char[] chars = _ps.chars;
		while (true)
		{
			switch (chars[num])
			{
			case '\n':
				num++;
				OnNewLine(num);
				continue;
			case '\r':
				if (chars[num + 1] == '\n')
				{
					int num4 = num - _ps.charPos;
					if (sb != null && !_ps.eolNormalized)
					{
						if (num4 > 0)
						{
							sb.Append(chars, _ps.charPos, num4);
							num2 += num4;
						}
						_ps.charPos = num + 1;
					}
					num += 2;
				}
				else
				{
					if (num + 1 >= _ps.charsUsed && !_ps.isEof)
					{
						break;
					}
					if (!_ps.eolNormalized)
					{
						chars[num] = '\n';
					}
					num++;
				}
				OnNewLine(num);
				continue;
			case '\t':
			case ' ':
				num++;
				continue;
			default:
				if (num != _ps.charsUsed)
				{
					int num3 = num - _ps.charPos;
					if (num3 > 0)
					{
						sb?.Append(_ps.chars, _ps.charPos, num3);
						_ps.charPos = num;
						num2 += num3;
					}
					return num2;
				}
				break;
			}
			int num5 = num - _ps.charPos;
			if (num5 > 0)
			{
				sb?.Append(_ps.chars, _ps.charPos, num5);
				_ps.charPos = num;
				num2 += num5;
			}
			if (ReadData() == 0)
			{
				if (_ps.charsUsed - _ps.charPos == 0)
				{
					break;
				}
				if (_ps.chars[_ps.charPos] != '\r')
				{
					Throw("Xml_UnexpectedEOF1");
				}
			}
			num = _ps.charPos;
			chars = _ps.chars;
		}
		return num2;
	}

	private int ParseCharRefInline(int startPos, out int charCount, out EntityType entityType)
	{
		if (_ps.chars[startPos + 1] == '#')
		{
			return ParseNumericCharRefInline(startPos, expand: true, null, out charCount, out entityType);
		}
		charCount = 1;
		entityType = EntityType.CharacterNamed;
		return ParseNamedCharRefInline(startPos, expand: true, null);
	}

	private int ParseNumericCharRef(bool expand, StringBuilder internalSubsetBuilder, out EntityType entityType)
	{
		int num;
		int charCount;
		while ((num = ParseNumericCharRefInline(_ps.charPos, expand, internalSubsetBuilder, out charCount, out entityType)) == -2)
		{
			if (ReadData() == 0)
			{
				Throw("Xml_UnexpectedEOF");
			}
		}
		if (expand)
		{
			_ps.charPos = num - charCount;
		}
		return num;
	}

	private int ParseNumericCharRefInline(int startPos, bool expand, StringBuilder internalSubsetBuilder, out int charCount, out EntityType entityType)
	{
		int num = 0;
		string res = null;
		char[] chars = _ps.chars;
		int i = startPos + 2;
		charCount = 0;
		int num2 = 0;
		try
		{
			if (chars[i] == 'x')
			{
				i++;
				num2 = i;
				res = "Xml_BadHexEntity";
				while (true)
				{
					int num3 = System.HexConverter.FromChar(chars[i]);
					if (num3 == 255)
					{
						break;
					}
					num = checked(num * 16 + num3);
					i++;
				}
				entityType = EntityType.CharacterHex;
			}
			else
			{
				if (i >= _ps.charsUsed)
				{
					entityType = EntityType.Skipped;
					return -2;
				}
				num2 = i;
				res = "Xml_BadDecimalEntity";
				for (; char.IsAsciiDigit(chars[i]); i++)
				{
					num = checked(num * 10 + chars[i] - 48);
				}
				entityType = EntityType.CharacterDec;
			}
		}
		catch (OverflowException innerException)
		{
			_ps.charPos = i;
			entityType = EntityType.Skipped;
			Throw("Xml_CharEntityOverflow", (string)null, (Exception)innerException);
		}
		if (chars[i] != ';' || num2 == i)
		{
			if (i == _ps.charsUsed)
			{
				return -2;
			}
			Throw(i, res);
		}
		if (num <= 65535)
		{
			char c = (char)num;
			if (!XmlCharType.IsCharData(c) && ((_v1Compat && _normalize) || (!_v1Compat && _checkCharacters)))
			{
				Throw((_ps.chars[startPos + 2] == 'x') ? (startPos + 3) : (startPos + 2), "Xml_InvalidCharacter", XmlException.BuildCharExceptionArgs(c, '\0'));
			}
			if (expand)
			{
				internalSubsetBuilder?.Append(_ps.chars, _ps.charPos, i - _ps.charPos + 1);
				chars[i] = c;
			}
			charCount = 1;
			return i + 1;
		}
		XmlCharType.SplitSurrogateChar(num, out var lowChar, out var highChar);
		if (_normalize && (!XmlCharType.IsHighSurrogate(highChar) || !XmlCharType.IsLowSurrogate(lowChar)))
		{
			Throw((_ps.chars[startPos + 2] == 'x') ? (startPos + 3) : (startPos + 2), "Xml_InvalidCharacter", XmlException.BuildCharExceptionArgs(highChar, lowChar));
		}
		if (expand)
		{
			internalSubsetBuilder?.Append(_ps.chars, _ps.charPos, i - _ps.charPos + 1);
			chars[i - 1] = highChar;
			chars[i] = lowChar;
		}
		charCount = 2;
		return i + 1;
	}

	private int ParseNamedCharRef(bool expand, StringBuilder internalSubsetBuilder)
	{
		do
		{
			int num;
			switch (num = ParseNamedCharRefInline(_ps.charPos, expand, internalSubsetBuilder))
			{
			case -1:
				return -1;
			case -2:
				continue;
			}
			if (expand)
			{
				_ps.charPos = num - 1;
			}
			return num;
		}
		while (ReadData() != 0);
		return -1;
	}

	private int ParseNamedCharRefInline(int startPos, bool expand, StringBuilder internalSubsetBuilder)
	{
		int num = startPos + 1;
		char[] chars = _ps.chars;
		char c = chars[num];
		char c2;
		if ((uint)c <= 103u)
		{
			if (c != 'a')
			{
				if (c != 'g')
				{
					goto IL_0170;
				}
				if (_ps.charsUsed - num >= 3)
				{
					if (chars[num + 1] == 't' && chars[num + 2] == ';')
					{
						num += 3;
						c2 = '>';
						goto IL_0175;
					}
					return -1;
				}
			}
			else
			{
				num++;
				if (chars[num] == 'm')
				{
					if (_ps.charsUsed - num >= 3)
					{
						if (chars[num + 1] == 'p' && chars[num + 2] == ';')
						{
							num += 3;
							c2 = '&';
							goto IL_0175;
						}
						return -1;
					}
				}
				else if (chars[num] == 'p')
				{
					if (_ps.charsUsed - num >= 4)
					{
						if (chars[num + 1] == 'o' && chars[num + 2] == 's' && chars[num + 3] == ';')
						{
							num += 4;
							c2 = '\'';
							goto IL_0175;
						}
						return -1;
					}
				}
				else if (num < _ps.charsUsed)
				{
					return -1;
				}
			}
			goto IL_0172;
		}
		if (c != 'l')
		{
			if (c != 'q')
			{
				goto IL_0170;
			}
			if (_ps.charsUsed - num < 5)
			{
				goto IL_0172;
			}
			if (chars[num + 1] != 'u' || chars[num + 2] != 'o' || chars[num + 3] != 't' || chars[num + 4] != ';')
			{
				return -1;
			}
			num += 5;
			c2 = '"';
		}
		else
		{
			if (_ps.charsUsed - num < 3)
			{
				goto IL_0172;
			}
			if (chars[num + 1] != 't' || chars[num + 2] != ';')
			{
				return -1;
			}
			num += 3;
			c2 = '<';
		}
		goto IL_0175;
		IL_0170:
		return -1;
		IL_0172:
		return -2;
		IL_0175:
		if (expand)
		{
			internalSubsetBuilder?.Append(_ps.chars, _ps.charPos, num - _ps.charPos);
			_ps.chars[num - 1] = c2;
		}
		return num;
	}

	private int ParseName()
	{
		int colonPos;
		return ParseQName(isQName: false, 0, out colonPos);
	}

	private int ParseQName(out int colonPos)
	{
		return ParseQName(isQName: true, 0, out colonPos);
	}

	private int ParseQName(bool isQName, int startOffset, out int colonPos)
	{
		int num = -1;
		int pos = _ps.charPos + startOffset;
		while (true)
		{
			char[] chars = _ps.chars;
			if (XmlCharType.IsStartNCNameSingleChar(chars[pos]))
			{
				pos++;
			}
			else
			{
				if (pos + 1 >= _ps.charsUsed)
				{
					if (ReadDataInName(ref pos))
					{
						continue;
					}
					Throw(pos, "Xml_UnexpectedEOF", "Name");
				}
				if (chars[pos] != ':' || _supportNamespaces)
				{
					Throw(pos, "Xml_BadStartNameChar", XmlException.BuildCharExceptionArgs(chars, _ps.charsUsed, pos));
				}
			}
			while (true)
			{
				if (XmlCharType.IsNCNameSingleChar(chars[pos]))
				{
					pos++;
					continue;
				}
				if (chars[pos] == ':')
				{
					if (_supportNamespaces)
					{
						break;
					}
					num = pos - _ps.charPos;
					pos++;
					continue;
				}
				if (pos == _ps.charsUsed)
				{
					if (ReadDataInName(ref pos))
					{
						chars = _ps.chars;
						continue;
					}
					Throw(pos, "Xml_UnexpectedEOF", "Name");
				}
				colonPos = ((num == -1) ? (-1) : (_ps.charPos + num));
				return pos;
			}
			if (num != -1 || !isQName)
			{
				Throw(pos, "Xml_BadNameChar", XmlException.BuildCharExceptionArgs(':', '\0'));
			}
			num = pos - _ps.charPos;
			pos++;
		}
	}

	private bool ReadDataInName(ref int pos)
	{
		int num = pos - _ps.charPos;
		bool result = ReadData() != 0;
		pos = _ps.charPos + num;
		return result;
	}

	private string ParseEntityName()
	{
		int num;
		try
		{
			num = ParseName();
		}
		catch (XmlException)
		{
			Throw("Xml_ErrorParsingEntityName");
			return null;
		}
		if (_ps.chars[num] != ';')
		{
			Throw("Xml_ErrorParsingEntityName");
		}
		string result = _nameTable.Add(_ps.chars, _ps.charPos, num - _ps.charPos);
		_ps.charPos = num + 1;
		return result;
	}

	private NodeData AddNode(int nodeIndex, int nodeDepth)
	{
		NodeData nodeData = _nodes[nodeIndex];
		if (nodeData != null)
		{
			nodeData.depth = nodeDepth;
			return nodeData;
		}
		return AllocNode(nodeIndex, nodeDepth);
	}

	private NodeData AllocNode(int nodeIndex, int nodeDepth)
	{
		if (nodeIndex >= _nodes.Length - 1)
		{
			NodeData[] array = new NodeData[_nodes.Length * 2];
			Array.Copy(_nodes, array, _nodes.Length);
			_nodes = array;
		}
		ref NodeData reference = ref _nodes[nodeIndex];
		NodeData obj = reference ?? (reference = new NodeData());
		obj.depth = nodeDepth;
		return obj;
	}

	private NodeData AddAttributeNoChecks(string name, int attrDepth)
	{
		NodeData nodeData = AddNode(_index + _attrCount + 1, attrDepth);
		nodeData.SetNamedNode(XmlNodeType.Attribute, _nameTable.Add(name));
		_attrCount++;
		return nodeData;
	}

	private NodeData AddAttribute(int endNamePos, int colonPos)
	{
		if (colonPos == -1 || !_supportNamespaces)
		{
			string text = _nameTable.Add(_ps.chars, _ps.charPos, endNamePos - _ps.charPos);
			return AddAttribute(text, string.Empty, text);
		}
		_attrNeedNamespaceLookup = true;
		int charPos = _ps.charPos;
		int num = colonPos - charPos;
		if (num != _lastPrefix.Length || !((ReadOnlySpan<char>)_ps.chars.AsSpan(_ps.charPos)).StartsWith(_lastPrefix.AsSpan()))
		{
			return AddAttribute(prefix: _lastPrefix = _nameTable.Add(_ps.chars, charPos, num), localName: _nameTable.Add(_ps.chars, colonPos + 1, endNamePos - colonPos - 1), nameWPrefix: null);
		}
		return AddAttribute(_nameTable.Add(_ps.chars, colonPos + 1, endNamePos - colonPos - 1), _lastPrefix, null);
	}

	private NodeData AddAttribute(string localName, string prefix, string nameWPrefix)
	{
		NodeData nodeData = AddNode(_index + _attrCount + 1, _index + 1);
		nodeData.SetNamedNode(XmlNodeType.Attribute, localName, prefix, nameWPrefix);
		int num = 1 << (localName[0] & 0x1F);
		if ((_attrHashtable & num) == 0)
		{
			_attrHashtable |= num;
		}
		else if (_attrDuplWalkCount < 64)
		{
			_attrDuplWalkCount++;
			for (int i = _index + 1; i < _index + _attrCount + 1; i++)
			{
				if (Ref.Equal(_nodes[i].localName, nodeData.localName))
				{
					_attrDuplWalkCount = 64;
					break;
				}
			}
		}
		_attrCount++;
		return nodeData;
	}

	private void PopElementContext()
	{
		_namespaceManager.PopScope();
		if (_curNode.xmlContextPushed)
		{
			PopXmlContext();
		}
	}

	private void OnNewLine(int pos)
	{
		_ps.lineNo++;
		_ps.lineStartPos = pos - 1;
	}

	private void OnEof()
	{
		_curNode = _nodes[0];
		_curNode.Clear(XmlNodeType.None);
		_curNode.SetLineInfo(_ps.LineNo, _ps.LinePos);
		_parsingFunction = ParsingFunction.Eof;
		_readState = ReadState.EndOfFile;
		_reportedEncoding = null;
	}

	private string LookupNamespace(NodeData node)
	{
		string text = _namespaceManager.LookupNamespace(node.prefix);
		if (text != null)
		{
			return text;
		}
		Throw("Xml_UnknownNs", node.prefix, node.LineNo, node.LinePos);
		return null;
	}

	private void AddNamespace(string prefix, string uri, NodeData attr)
	{
		if (uri == "http://www.w3.org/2000/xmlns/")
		{
			if (Ref.Equal(prefix, _xmlNs))
			{
				Throw("Xml_XmlnsPrefix", attr.lineInfo2.lineNo, attr.lineInfo2.linePos);
			}
			else
			{
				Throw("Xml_NamespaceDeclXmlXmlns", prefix, attr.lineInfo2.lineNo, attr.lineInfo2.linePos);
			}
		}
		else if (uri == "http://www.w3.org/XML/1998/namespace" && !Ref.Equal(prefix, _xml) && !_v1Compat)
		{
			Throw("Xml_NamespaceDeclXmlXmlns", prefix, attr.lineInfo2.lineNo, attr.lineInfo2.linePos);
		}
		if (uri.Length == 0 && prefix.Length > 0)
		{
			Throw("Xml_BadNamespaceDecl", attr.lineInfo.lineNo, attr.lineInfo.linePos);
		}
		try
		{
			_namespaceManager.AddNamespace(prefix, uri);
		}
		catch (ArgumentException e)
		{
			ReThrow(e, attr.lineInfo.lineNo, attr.lineInfo.linePos);
		}
	}

	private void ResetAttributes()
	{
		if (_fullAttrCleanup)
		{
			FullAttributeCleanup();
		}
		_curAttrIndex = -1;
		_attrCount = 0;
		_attrHashtable = 0;
		_attrDuplWalkCount = 0;
	}

	private void FullAttributeCleanup()
	{
		for (int i = _index + 1; i < _index + _attrCount + 1; i++)
		{
			NodeData obj = _nodes[i];
			obj.nextAttrValueChunk = null;
			obj.IsDefaultAttribute = false;
		}
		_fullAttrCleanup = false;
	}

	private void PushXmlContext()
	{
		_xmlContext = new XmlContext(_xmlContext);
		_curNode.xmlContextPushed = true;
	}

	private void PopXmlContext()
	{
		_xmlContext = _xmlContext.previousContext;
		_curNode.xmlContextPushed = false;
	}

	private XmlNodeType GetWhitespaceType()
	{
		if (_whitespaceHandling != WhitespaceHandling.None)
		{
			if (_xmlContext.xmlSpace == XmlSpace.Preserve)
			{
				return XmlNodeType.SignificantWhitespace;
			}
			if (_whitespaceHandling == WhitespaceHandling.All)
			{
				return XmlNodeType.Whitespace;
			}
		}
		return XmlNodeType.None;
	}

	private XmlNodeType GetTextNodeType(int orChars)
	{
		if (orChars > 32)
		{
			return XmlNodeType.Text;
		}
		return GetWhitespaceType();
	}

	private void PushExternalEntityOrSubset(string publicId, string systemId, Uri baseUri, string entityName)
	{
		Uri uri;
		if (!string.IsNullOrEmpty(publicId))
		{
			try
			{
				uri = _xmlResolver.ResolveUri(baseUri, publicId);
				if (OpenAndPush(uri))
				{
					return;
				}
			}
			catch (Exception)
			{
			}
		}
		uri = _xmlResolver.ResolveUri(baseUri, systemId);
		try
		{
			if (OpenAndPush(uri))
			{
				return;
			}
		}
		catch (Exception ex2)
		{
			if (_v1Compat)
			{
				throw;
			}
			string message = ex2.Message;
			Throw(new XmlException((entityName == null) ? "Xml_ErrorOpeningExternalDtd" : "Xml_ErrorOpeningExternalEntity", new string[2]
			{
				uri.ToString(),
				message
			}, ex2, 0, 0));
		}
		if (entityName == null)
		{
			ThrowWithoutLineInfo("Xml_CannotResolveExternalSubset", new string[2]
			{
				publicId ?? string.Empty,
				systemId
			}, null);
		}
		else
		{
			Throw((_dtdProcessing == DtdProcessing.Ignore) ? "Xml_CannotResolveEntityDtdIgnored" : "Xml_CannotResolveEntity", entityName);
		}
	}

	private bool OpenAndPush(Uri uri)
	{
		if (_xmlResolver.SupportsType(uri, typeof(TextReader)))
		{
			TextReader textReader = (TextReader)_xmlResolver.GetEntity(uri, null, typeof(TextReader));
			if (textReader == null)
			{
				return false;
			}
			PushParsingState();
			InitTextReaderInput(uri.ToString(), uri, textReader);
		}
		else
		{
			Stream stream = (Stream)_xmlResolver.GetEntity(uri, null, typeof(Stream));
			if (stream == null)
			{
				return false;
			}
			PushParsingState();
			InitStreamInput(uri, stream, null);
		}
		return true;
	}

	private bool PushExternalEntity(IDtdEntityInfo entity)
	{
		if (!IsResolverNull)
		{
			Uri baseUri = null;
			if (!string.IsNullOrEmpty(entity.BaseUriString))
			{
				baseUri = _xmlResolver.ResolveUri(null, entity.BaseUriString);
			}
			PushExternalEntityOrSubset(entity.PublicId, entity.SystemId, baseUri, entity.Name);
			RegisterEntity(entity);
			int charPos = _ps.charPos;
			if (_v1Compat)
			{
				EatWhitespaces(null);
			}
			if (!ParseXmlDeclaration(isTextDecl: true))
			{
				_ps.charPos = charPos;
			}
			return true;
		}
		Encoding encoding = _ps.encoding;
		PushParsingState();
		InitStringInput(entity.SystemId, encoding, string.Empty);
		RegisterEntity(entity);
		RegisterConsumedCharacters(0L, inEntityReference: true);
		return false;
	}

	private void PushInternalEntity(IDtdEntityInfo entity)
	{
		Encoding encoding = _ps.encoding;
		PushParsingState();
		InitStringInput(entity.DeclaredUriString ?? string.Empty, encoding, entity.Text);
		RegisterEntity(entity);
		_ps.lineNo = entity.LineNumber;
		_ps.lineStartPos = -entity.LinePosition - 1;
		_ps.eolNormalized = true;
		RegisterConsumedCharacters(entity.Text.Length, inEntityReference: true);
	}

	private void PopEntity()
	{
		_ps.stream?.Dispose();
		UnregisterEntity();
		PopParsingState();
		_curNode.entityId = _ps.entityId;
	}

	private void RegisterEntity(IDtdEntityInfo entity)
	{
		if (_currentEntities != null && _currentEntities.Contains(entity))
		{
			Throw(entity.IsParameterEntity ? "Xml_RecursiveParEntity" : "Xml_RecursiveGenEntity", entity.Name, _parsingStatesStack[_parsingStatesStackTop].LineNo, _parsingStatesStack[_parsingStatesStackTop].LinePos);
		}
		_ps.entity = entity;
		_ps.entityId = _nextEntityId++;
		if (entity != null)
		{
			if (_currentEntities == null)
			{
				_currentEntities = new HashSet<IDtdEntityInfo>();
			}
			_currentEntities.Add(entity);
		}
	}

	private void UnregisterEntity()
	{
		if (_ps.entity != null)
		{
			_currentEntities.Remove(_ps.entity);
		}
	}

	private void PushParsingState()
	{
		if (_parsingStatesStack == null)
		{
			_parsingStatesStack = new ParsingState[2];
		}
		else if (_parsingStatesStackTop + 1 == _parsingStatesStack.Length)
		{
			ParsingState[] array = new ParsingState[_parsingStatesStack.Length * 2];
			Array.Copy(_parsingStatesStack, array, _parsingStatesStack.Length);
			_parsingStatesStack = array;
		}
		_parsingStatesStackTop++;
		_parsingStatesStack[_parsingStatesStackTop] = _ps;
		_ps.Clear();
	}

	private void PopParsingState()
	{
		_ps.Close(closeInput: true);
		_ps = _parsingStatesStack[_parsingStatesStackTop--];
	}

	private int IncrementalRead()
	{
		int num = 0;
		int num3;
		while (true)
		{
			int num2 = _incReadLeftEndPos - _incReadLeftStartPos;
			if (num2 > 0)
			{
				try
				{
					num3 = _incReadDecoder.Decode(_ps.chars, _incReadLeftStartPos, num2);
				}
				catch (XmlException e)
				{
					ReThrow(e, _incReadLineInfo.lineNo, _incReadLineInfo.linePos);
					return 0;
				}
				if (num3 < num2)
				{
					_incReadLeftStartPos += num3;
					_incReadLineInfo.linePos += num3;
					return num3;
				}
				_incReadLeftStartPos = 0;
				_incReadLeftEndPos = 0;
				_incReadLineInfo.linePos += num3;
				if (_incReadDecoder.IsFull)
				{
					break;
				}
			}
			while (true)
			{
				int outStartPos;
				int i;
				switch (_incReadState)
				{
				case IncrementalReadState.PI:
					if (ParsePIValue(out outStartPos, out i))
					{
						_ps.charPos -= 2;
						_incReadState = IncrementalReadState.Text;
					}
					break;
				case IncrementalReadState.Comment:
					if (ParseCDataOrComment(XmlNodeType.Comment, out outStartPos, out i))
					{
						_ps.charPos -= 3;
						_incReadState = IncrementalReadState.Text;
					}
					break;
				case IncrementalReadState.CDATA:
					if (ParseCDataOrComment(XmlNodeType.CDATA, out outStartPos, out i))
					{
						_ps.charPos -= 3;
						_incReadState = IncrementalReadState.Text;
					}
					break;
				case IncrementalReadState.EndElement:
					_parsingFunction = ParsingFunction.PopElementContext;
					_nextParsingFunction = ((_index <= 0 && _fragmentType == XmlNodeType.Document) ? ParsingFunction.DocumentContent : ParsingFunction.ElementContent);
					_outerReader.Read();
					_incReadState = IncrementalReadState.End;
					goto case IncrementalReadState.End;
				case IncrementalReadState.End:
					return num;
				case IncrementalReadState.ReadData:
					if (ReadData() == 0)
					{
						ThrowUnclosedElements();
					}
					_incReadState = IncrementalReadState.Text;
					goto default;
				default:
				{
					char[] chars = _ps.chars;
					outStartPos = _ps.charPos;
					i = outStartPos;
					while (true)
					{
						_incReadLineInfo.Set(_ps.LineNo, _ps.LinePos);
						if (_incReadState == IncrementalReadState.Attributes)
						{
							char c;
							while (XmlCharType.IsAttributeValueChar(c = chars[i]) && c != '/')
							{
								i++;
							}
						}
						else
						{
							for (; XmlCharType.IsAttributeValueChar(chars[i]); i++)
							{
							}
						}
						if (chars[i] == '&' || chars[i] == '\t')
						{
							i++;
							continue;
						}
						if (i - outStartPos <= 0)
						{
							char c2 = chars[i];
							if ((uint)c2 <= 34u)
							{
								if (c2 == '\n')
								{
									i++;
									OnNewLine(i);
									continue;
								}
								if (c2 == '\r')
								{
									if (chars[i + 1] == '\n')
									{
										i += 2;
									}
									else
									{
										if (i + 1 >= _ps.charsUsed)
										{
											goto IL_069e;
										}
										i++;
									}
									OnNewLine(i);
									continue;
								}
								if (c2 == '"')
								{
									goto IL_063c;
								}
							}
							else if ((uint)c2 <= 47u)
							{
								if (c2 == '\'')
								{
									goto IL_063c;
								}
								if (c2 == '/')
								{
									if (_incReadState == IncrementalReadState.Attributes)
									{
										if (_ps.charsUsed - i < 2)
										{
											goto IL_069e;
										}
										if (chars[i + 1] == '>')
										{
											_incReadState = IncrementalReadState.Text;
											_incReadDepth--;
										}
									}
									i++;
									continue;
								}
							}
							else
							{
								if (c2 == '<')
								{
									if (_incReadState != IncrementalReadState.Text)
									{
										i++;
										continue;
									}
									if (_ps.charsUsed - i < 2)
									{
										goto IL_069e;
									}
									char c3 = chars[i + 1];
									if (c3 != '!')
									{
										int colonPos;
										switch (c3)
										{
										case '?':
											i += 2;
											_incReadState = IncrementalReadState.PI;
											break;
										case '/':
										{
											int num5 = ParseQName(isQName: true, 2, out colonPos);
											string nameWPrefix = _curNode.GetNameWPrefix(_nameTable);
											if (num5 - _ps.charPos - 2 != nameWPrefix.Length || !((ReadOnlySpan<char>)chars.AsSpan(_ps.charPos + 2)).StartsWith(nameWPrefix.AsSpan()) || (_ps.chars[num5] != '>' && !XmlCharType.IsWhiteSpace(_ps.chars[num5])))
											{
												i = num5;
												outStartPos = _ps.charPos;
												chars = _ps.chars;
												continue;
											}
											colonPos = --_incReadDepth;
											if (colonPos > 0)
											{
												i = num5 + 1;
												continue;
											}
											_ps.charPos = num5;
											if (XmlCharType.IsWhiteSpace(_ps.chars[num5]))
											{
												EatWhitespaces(null);
											}
											if (_ps.chars[_ps.charPos] != '>')
											{
												ThrowUnexpectedToken(">");
											}
											goto end_IL_00b7;
										}
										default:
										{
											int num4 = ParseQName(isQName: true, 1, out colonPos);
											if (num4 - _ps.charPos - 1 == _curNode.localName.Length && ((ReadOnlySpan<char>)_ps.chars.AsSpan(_ps.charPos + 1)).StartsWith(_curNode.localName.AsSpan()) && (_ps.chars[num4] == '>' || _ps.chars[num4] == '/' || XmlCharType.IsWhiteSpace(_ps.chars[num4])))
											{
												_incReadDepth++;
												_incReadState = IncrementalReadState.Attributes;
												i = num4;
												break;
											}
											i = num4;
											outStartPos = _ps.charPos;
											chars = _ps.chars;
											continue;
										}
										}
									}
									else
									{
										if (_ps.charsUsed - i < 4)
										{
											goto IL_069e;
										}
										if (chars[i + 2] == '-' && chars[i + 3] == '-')
										{
											i += 4;
											_incReadState = IncrementalReadState.Comment;
										}
										else
										{
											if (_ps.charsUsed - i < 9)
											{
												goto IL_069e;
											}
											if (!((ReadOnlySpan<char>)chars.AsSpan(i + 2)).StartsWith("[CDATA[".AsSpan()))
											{
												continue;
											}
											i += 9;
											_incReadState = IncrementalReadState.CDATA;
										}
									}
									goto IL_06a5;
								}
								if (c2 == '>')
								{
									if (_incReadState == IncrementalReadState.Attributes)
									{
										_incReadState = IncrementalReadState.Text;
									}
									i++;
									continue;
								}
							}
							if (i != _ps.charsUsed)
							{
								i++;
								continue;
							}
							goto IL_069e;
						}
						goto IL_06a5;
						IL_06a5:
						_ps.charPos = i;
						break;
						IL_069e:
						_incReadState = IncrementalReadState.ReadData;
						goto IL_06a5;
						IL_063c:
						switch (_incReadState)
						{
						case IncrementalReadState.AttributeValue:
							if (chars[i] == _curNode.quoteChar)
							{
								_incReadState = IncrementalReadState.Attributes;
							}
							break;
						case IncrementalReadState.Attributes:
							_curNode.quoteChar = chars[i];
							_incReadState = IncrementalReadState.AttributeValue;
							break;
						}
						i++;
					}
					break;
				}
				}
				int num6 = i - outStartPos;
				if (num6 > 0)
				{
					int num7;
					try
					{
						num7 = _incReadDecoder.Decode(_ps.chars, outStartPos, num6);
					}
					catch (XmlException e2)
					{
						ReThrow(e2, _incReadLineInfo.lineNo, _incReadLineInfo.linePos);
						return 0;
					}
					num += num7;
					if (_incReadDecoder.IsFull)
					{
						_incReadLeftStartPos = outStartPos + num7;
						_incReadLeftEndPos = i;
						_incReadLineInfo.linePos += num7;
						return num;
					}
				}
				continue;
				end_IL_00b7:
				break;
			}
			_ps.charPos++;
			_incReadState = IncrementalReadState.EndElement;
		}
		return num3;
	}

	private void FinishIncrementalRead()
	{
		_incReadDecoder = new IncrementalReadDummyDecoder();
		IncrementalRead();
		_incReadDecoder = null;
	}

	private bool ParseFragmentAttribute()
	{
		if (_curNode.type == XmlNodeType.None)
		{
			_curNode.type = XmlNodeType.Attribute;
			_curAttrIndex = 0;
			ParseAttributeValueSlow(_ps.charPos, ' ', _curNode);
		}
		else
		{
			_parsingFunction = ParsingFunction.InReadAttributeValue;
		}
		if (ReadAttributeValue())
		{
			_parsingFunction = ParsingFunction.FragmentAttribute;
			return true;
		}
		OnEof();
		return false;
	}

	private bool ParseAttributeValueChunk()
	{
		char[] chars = _ps.chars;
		int charRefEndPos = _ps.charPos;
		_curNode = AddNode(_index + _attrCount + 1, _index + 2);
		_curNode.SetLineInfo(_ps.LineNo, _ps.LinePos);
		if (_emptyEntityInAttributeResolved)
		{
			_curNode.SetValueNode(XmlNodeType.Text, string.Empty);
			_emptyEntityInAttributeResolved = false;
			return true;
		}
		while (true)
		{
			if (XmlCharType.IsAttributeValueChar(chars[charRefEndPos]))
			{
				charRefEndPos++;
				continue;
			}
			switch (chars[charRefEndPos])
			{
			case '\r':
				charRefEndPos++;
				continue;
			case '\t':
			case '\n':
				if (_normalize)
				{
					chars[charRefEndPos] = ' ';
				}
				charRefEndPos++;
				continue;
			case '"':
			case '\'':
			case '>':
				charRefEndPos++;
				continue;
			case '<':
				Throw(charRefEndPos, "Xml_BadAttributeChar", XmlException.BuildCharExceptionArgs('<', '\0'));
				goto IL_025b;
			case '&':
			{
				if (charRefEndPos - _ps.charPos > 0)
				{
					_stringBuilder.Append(chars, _ps.charPos, charRefEndPos - _ps.charPos);
				}
				_ps.charPos = charRefEndPos;
				EntityType entityType = HandleEntityReference(isInAttributeValue: true, EntityExpandType.OnlyCharacter, out charRefEndPos);
				if ((uint)entityType > 2u)
				{
					if (entityType == EntityType.Unexpanded)
					{
						if (_stringBuilder.Length == 0)
						{
							_curNode.lineInfo.linePos++;
							_ps.charPos++;
							_curNode.SetNamedNode(XmlNodeType.EntityReference, ParseEntityName());
							return true;
						}
						break;
					}
				}
				else
				{
					chars = _ps.chars;
					if (_normalize && XmlCharType.IsWhiteSpace(chars[_ps.charPos]) && charRefEndPos - _ps.charPos == 1)
					{
						chars[_ps.charPos] = ' ';
					}
				}
				chars = _ps.chars;
				continue;
			}
			default:
				{
					if (charRefEndPos != _ps.charsUsed)
					{
						if (XmlCharType.IsHighSurrogate(chars[charRefEndPos]))
						{
							if (charRefEndPos + 1 == _ps.charsUsed)
							{
								goto IL_025b;
							}
							charRefEndPos++;
							if (XmlCharType.IsLowSurrogate(chars[charRefEndPos]))
							{
								charRefEndPos++;
								continue;
							}
						}
						ThrowInvalidChar(chars, _ps.charsUsed, charRefEndPos);
					}
					goto IL_025b;
				}
				IL_025b:
				if (charRefEndPos - _ps.charPos > 0)
				{
					_stringBuilder.Append(chars, _ps.charPos, charRefEndPos - _ps.charPos);
					_ps.charPos = charRefEndPos;
				}
				if (ReadData() == 0)
				{
					if (_stringBuilder.Length > 0)
					{
						break;
					}
					if (HandleEntityEnd(checkEntityNesting: false))
					{
						SetupEndEntityNodeInAttribute();
						return true;
					}
				}
				charRefEndPos = _ps.charPos;
				chars = _ps.chars;
				continue;
			}
			break;
		}
		if (charRefEndPos - _ps.charPos > 0)
		{
			_stringBuilder.Append(chars, _ps.charPos, charRefEndPos - _ps.charPos);
			_ps.charPos = charRefEndPos;
		}
		_curNode.SetValueNode(XmlNodeType.Text, _stringBuilder.ToString());
		_stringBuilder.Length = 0;
		return true;
	}

	private void ParseXmlDeclarationFragment()
	{
		try
		{
			ParseXmlDeclaration(isTextDecl: false);
		}
		catch (XmlException ex)
		{
			ReThrow(ex, ex.LineNumber, ex.LinePosition - 6);
		}
	}

	private void ThrowUnexpectedToken(int pos, string expectedToken)
	{
		ThrowUnexpectedToken(pos, expectedToken, null);
	}

	private void ThrowUnexpectedToken(string expectedToken1)
	{
		ThrowUnexpectedToken(expectedToken1, null);
	}

	private void ThrowUnexpectedToken(int pos, string expectedToken1, string expectedToken2)
	{
		_ps.charPos = pos;
		ThrowUnexpectedToken(expectedToken1, expectedToken2);
	}

	private void ThrowUnexpectedToken(string expectedToken1, string expectedToken2)
	{
		string text = ParseUnexpectedToken();
		if (text == null)
		{
			Throw("Xml_UnexpectedEOF1");
		}
		if (expectedToken2 != null)
		{
			Throw("Xml_UnexpectedTokens2", new string[3] { text, expectedToken1, expectedToken2 });
		}
		else
		{
			Throw("Xml_UnexpectedTokenEx", new string[2] { text, expectedToken1 });
		}
	}

	private string ParseUnexpectedToken(int pos)
	{
		_ps.charPos = pos;
		return ParseUnexpectedToken();
	}

	private string ParseUnexpectedToken()
	{
		if (_ps.charPos == _ps.charsUsed)
		{
			return null;
		}
		if (XmlCharType.IsNCNameSingleChar(_ps.chars[_ps.charPos]))
		{
			int i;
			for (i = _ps.charPos + 1; XmlCharType.IsNCNameSingleChar(_ps.chars[i]); i++)
			{
			}
			return new string(_ps.chars, _ps.charPos, i - _ps.charPos);
		}
		return new string(_ps.chars, _ps.charPos, 1);
	}

	private void ThrowExpectingWhitespace(int pos)
	{
		string text = ParseUnexpectedToken(pos);
		if (text == null)
		{
			Throw(pos, "Xml_UnexpectedEOF1");
		}
		else
		{
			Throw(pos, "Xml_ExpectingWhiteSpace", text);
		}
	}

	private int GetIndexOfAttributeWithoutPrefix(string name)
	{
		string text = _nameTable.Get(name);
		if (text == null)
		{
			return -1;
		}
		for (int i = _index + 1; i < _index + _attrCount + 1; i++)
		{
			if (Ref.Equal(_nodes[i].localName, text) && _nodes[i].prefix.Length == 0)
			{
				return i;
			}
		}
		return -1;
	}

	private int GetIndexOfAttributeWithPrefix(string name)
	{
		name = _nameTable.Add(name);
		if (name == null)
		{
			return -1;
		}
		for (int i = _index + 1; i < _index + _attrCount + 1; i++)
		{
			if (Ref.Equal(_nodes[i].GetNameWPrefix(_nameTable), name))
			{
				return i;
			}
		}
		return -1;
	}

	private bool ZeroEndingStream(int pos)
	{
		if (_v1Compat && pos == _ps.charsUsed - 1 && _ps.chars[pos] == '\0' && ReadData() == 0 && _ps.isStreamEof)
		{
			_ps.charsUsed--;
			return true;
		}
		return false;
	}

	private void ParseDtdFromParserContext()
	{
		IDtdParser dtdParser = DtdParser.Create();
		_dtdInfo = dtdParser.ParseFreeFloatingDtd(_fragmentParserContext.BaseURI, _fragmentParserContext.DocTypeName, _fragmentParserContext.PublicId, _fragmentParserContext.SystemId, _fragmentParserContext.InternalSubset, new DtdParserProxy(this));
		if ((_validatingReaderCompatFlag || !_v1Compat) && (_dtdInfo.HasDefaultAttributes || _dtdInfo.HasNonCDataAttributes))
		{
			_addDefaultAttributesAndNormalize = true;
		}
	}

	private bool InitReadElementContentAsBinary()
	{
		bool isEmptyElement = _curNode.IsEmptyElement;
		_outerReader.Read();
		if (isEmptyElement)
		{
			return false;
		}
		if (!MoveToNextContentNode(moveIfOnContentNode: false))
		{
			if (_curNode.type != XmlNodeType.EndElement)
			{
				Throw("Xml_InvalidNodeType", _curNode.type.ToString());
			}
			_outerReader.Read();
			return false;
		}
		SetupReadContentAsBinaryState(ParsingFunction.InReadElementContentAsBinary);
		_incReadLineInfo.Set(_curNode.LineNo, _curNode.LinePos);
		return true;
	}

	private bool MoveToNextContentNode(bool moveIfOnContentNode)
	{
		do
		{
			switch (_curNode.type)
			{
			case XmlNodeType.Attribute:
				return !moveIfOnContentNode;
			case XmlNodeType.Text:
			case XmlNodeType.CDATA:
			case XmlNodeType.Whitespace:
			case XmlNodeType.SignificantWhitespace:
				if (!moveIfOnContentNode)
				{
					return true;
				}
				break;
			case XmlNodeType.EntityReference:
				_outerReader.ResolveEntity();
				break;
			default:
				return false;
			case XmlNodeType.ProcessingInstruction:
			case XmlNodeType.Comment:
			case XmlNodeType.EndEntity:
				break;
			}
			moveIfOnContentNode = false;
		}
		while (_outerReader.Read());
		return false;
	}

	private void SetupReadContentAsBinaryState(ParsingFunction inReadBinaryFunction)
	{
		if (_parsingFunction == ParsingFunction.PartialTextValue)
		{
			_incReadState = IncrementalReadState.ReadContentAsBinary_OnPartialValue;
		}
		else
		{
			_incReadState = IncrementalReadState.ReadContentAsBinary_OnCachedValue;
			_nextNextParsingFunction = _nextParsingFunction;
			_nextParsingFunction = _parsingFunction;
		}
		_readValueOffset = 0;
		_parsingFunction = inReadBinaryFunction;
	}

	[MemberNotNull("_nameTable")]
	private void SetupFromParserContext(XmlParserContext context, XmlReaderSettings settings)
	{
		XmlNameTable xmlNameTable = settings.NameTable;
		_nameTableFromSettings = xmlNameTable != null;
		if (context.NamespaceManager != null)
		{
			if (xmlNameTable != null && xmlNameTable != context.NamespaceManager.NameTable)
			{
				throw new XmlException("Xml_NametableMismatch");
			}
			_namespaceManager = context.NamespaceManager;
			_xmlContext.defaultNamespace = _namespaceManager.LookupNamespace(string.Empty);
			xmlNameTable = _namespaceManager.NameTable;
		}
		else if (context.NameTable != null)
		{
			if (xmlNameTable != null && xmlNameTable != context.NameTable)
			{
				throw new XmlException("Xml_NametableMismatch", string.Empty);
			}
			xmlNameTable = context.NameTable;
		}
		else if (xmlNameTable == null)
		{
			xmlNameTable = new NameTable();
		}
		_nameTable = xmlNameTable;
		if (_namespaceManager == null)
		{
			_namespaceManager = new XmlNamespaceManager(xmlNameTable);
		}
		_xmlContext.xmlSpace = context.XmlSpace;
		_xmlContext.xmlLang = context.XmlLang;
	}

	internal void SetDtdInfo(IDtdInfo newDtdInfo)
	{
		_dtdInfo = newDtdInfo;
		if (_dtdInfo != null && (_validatingReaderCompatFlag || !_v1Compat) && (_dtdInfo.HasDefaultAttributes || _dtdInfo.HasNonCDataAttributes))
		{
			_addDefaultAttributesAndNormalize = true;
		}
	}

	private bool AddDefaultAttributeDtd(IDtdDefaultAttributeInfo defAttrInfo, NodeData[] nameSortedNodeData)
	{
		if (defAttrInfo.Prefix.Length > 0)
		{
			_attrNeedNamespaceLookup = true;
		}
		string localName = defAttrInfo.LocalName;
		string prefix = defAttrInfo.Prefix;
		if (nameSortedNodeData != null)
		{
			if (Array.BinarySearch(nameSortedNodeData, defAttrInfo, DtdDefaultAttributeInfoToNodeDataComparer.Instance) >= 0)
			{
				return false;
			}
		}
		else
		{
			for (int i = _index + 1; i < _index + 1 + _attrCount; i++)
			{
				if ((object)_nodes[i].localName == localName && (object)_nodes[i].prefix == prefix)
				{
					return false;
				}
			}
		}
		NodeData nodeData = AddDefaultAttributeInternal(defAttrInfo.LocalName, null, defAttrInfo.Prefix, defAttrInfo.DefaultValueExpanded, defAttrInfo.LineNumber, defAttrInfo.LinePosition, defAttrInfo.ValueLineNumber, defAttrInfo.ValueLinePosition, defAttrInfo.IsXmlAttribute);
		if (DtdValidation)
		{
			_onDefaultAttributeUse?.Invoke(defAttrInfo, this);
			nodeData.typedValue = defAttrInfo.DefaultValueTyped;
		}
		return nodeData != null;
	}

	private NodeData AddDefaultAttributeInternal(string localName, string ns, string prefix, string value, int lineNo, int linePos, int valueLineNo, int valueLinePos, bool isXmlAttribute)
	{
		NodeData nodeData = AddAttribute(localName, prefix, (prefix.Length > 0) ? null : localName);
		if (ns != null)
		{
			nodeData.ns = ns;
		}
		nodeData.SetValue(value);
		nodeData.IsDefaultAttribute = true;
		nodeData.lineInfo.Set(lineNo, linePos);
		nodeData.lineInfo2.Set(valueLineNo, valueLinePos);
		if (nodeData.prefix.Length == 0)
		{
			if (Ref.Equal(nodeData.localName, _xmlNs))
			{
				OnDefaultNamespaceDecl(nodeData);
				if (!_attrNeedNamespaceLookup && _nodes[_index].prefix.Length == 0)
				{
					_nodes[_index].ns = _xmlContext.defaultNamespace;
				}
			}
		}
		else if (Ref.Equal(nodeData.prefix, _xmlNs))
		{
			OnNamespaceDecl(nodeData);
			if (!_attrNeedNamespaceLookup)
			{
				string localName2 = nodeData.localName;
				for (int i = _index; i < _index + _attrCount + 1; i++)
				{
					if (_nodes[i].prefix.Equals(localName2))
					{
						_nodes[i].ns = _namespaceManager.LookupNamespace(localName2);
					}
				}
			}
		}
		else if (isXmlAttribute)
		{
			OnXmlReservedAttribute(nodeData);
		}
		_fullAttrCleanup = true;
		return nodeData;
	}

	private int ReadContentAsBinary(byte[] buffer, int index, int count)
	{
		if (_incReadState == IncrementalReadState.ReadContentAsBinary_End)
		{
			return 0;
		}
		_incReadDecoder.SetNextOutputBuffer(buffer, index, count);
		ParsingFunction parsingFunction;
		while (true)
		{
			int num = 0;
			try
			{
				num = _curNode.CopyToBinary(_incReadDecoder, _readValueOffset);
			}
			catch (XmlException e)
			{
				_curNode.AdjustLineInfo(_readValueOffset, _ps.eolNormalized, ref _incReadLineInfo);
				ReThrow(e, _incReadLineInfo.lineNo, _incReadLineInfo.linePos);
			}
			_readValueOffset += num;
			if (_incReadDecoder.IsFull)
			{
				return _incReadDecoder.DecodedCount;
			}
			if (_incReadState == IncrementalReadState.ReadContentAsBinary_OnPartialValue)
			{
				_curNode.SetValue(string.Empty);
				bool flag = false;
				int startPos = 0;
				int endPos = 0;
				while (!_incReadDecoder.IsFull && !flag)
				{
					int outOrChars = 0;
					_incReadLineInfo.Set(_ps.LineNo, _ps.LinePos);
					flag = ParseText(out startPos, out endPos, ref outOrChars);
					try
					{
						num = _incReadDecoder.Decode(_ps.chars, startPos, endPos - startPos);
					}
					catch (XmlException e2)
					{
						ReThrow(e2, _incReadLineInfo.lineNo, _incReadLineInfo.linePos);
					}
					startPos += num;
				}
				_incReadState = (flag ? IncrementalReadState.ReadContentAsBinary_OnCachedValue : IncrementalReadState.ReadContentAsBinary_OnPartialValue);
				_readValueOffset = 0;
				if (_incReadDecoder.IsFull)
				{
					_curNode.SetValue(_ps.chars, startPos, endPos - startPos);
					AdjustLineInfo(_ps.chars, startPos - num, startPos, _ps.eolNormalized, ref _incReadLineInfo);
					_curNode.SetLineInfo(_incReadLineInfo.lineNo, _incReadLineInfo.linePos);
					return _incReadDecoder.DecodedCount;
				}
			}
			parsingFunction = _parsingFunction;
			_parsingFunction = _nextParsingFunction;
			_nextParsingFunction = _nextNextParsingFunction;
			if (!MoveToNextContentNode(moveIfOnContentNode: true))
			{
				break;
			}
			SetupReadContentAsBinaryState(parsingFunction);
			_incReadLineInfo.Set(_curNode.LineNo, _curNode.LinePos);
		}
		SetupReadContentAsBinaryState(parsingFunction);
		_incReadState = IncrementalReadState.ReadContentAsBinary_End;
		return _incReadDecoder.DecodedCount;
	}

	private int ReadElementContentAsBinary(byte[] buffer, int index, int count)
	{
		if (count == 0)
		{
			return 0;
		}
		int num = ReadContentAsBinary(buffer, index, count);
		if (num > 0)
		{
			return num;
		}
		if (_curNode.type != XmlNodeType.EndElement)
		{
			throw new XmlException("Xml_InvalidNodeType", _curNode.type.ToString(), this);
		}
		_parsingFunction = _nextParsingFunction;
		_nextParsingFunction = _nextNextParsingFunction;
		_outerReader.Read();
		return 0;
	}

	private void InitBase64Decoder()
	{
		if (_base64Decoder == null)
		{
			_base64Decoder = new Base64Decoder();
		}
		else
		{
			_base64Decoder.Reset();
		}
		_incReadDecoder = _base64Decoder;
	}

	private void InitBinHexDecoder()
	{
		if (_binHexDecoder == null)
		{
			_binHexDecoder = new BinHexDecoder();
		}
		else
		{
			_binHexDecoder.Reset();
		}
		_incReadDecoder = _binHexDecoder;
	}

	private static bool UriEqual(Uri uri1, string uri1Str, string uri2Str, XmlResolver resolver)
	{
		if (resolver == null)
		{
			return uri1Str == uri2Str;
		}
		if ((object)uri1 == null)
		{
			uri1 = resolver.ResolveUri(null, uri1Str);
		}
		Uri other = resolver.ResolveUri(null, uri2Str);
		return uri1.Equals(other);
	}

	private void RegisterConsumedCharacters(long characters, bool inEntityReference)
	{
		if (_maxCharactersInDocument > 0)
		{
			long num = _charactersInDocument + characters;
			if (num < _charactersInDocument)
			{
				ThrowWithoutLineInfo("Xml_LimitExceeded", "MaxCharactersInDocument");
			}
			else
			{
				_charactersInDocument = num;
			}
			if (_charactersInDocument > _maxCharactersInDocument)
			{
				ThrowWithoutLineInfo("Xml_LimitExceeded", "MaxCharactersInDocument");
			}
		}
		if (_maxCharactersFromEntities > 0 && inEntityReference)
		{
			long num2 = _charactersFromEntities + characters;
			if (num2 < _charactersFromEntities)
			{
				ThrowWithoutLineInfo("Xml_LimitExceeded", "MaxCharactersFromEntities");
			}
			else
			{
				_charactersFromEntities = num2;
			}
			if (_charactersFromEntities > _maxCharactersFromEntities)
			{
				ThrowWithoutLineInfo("Xml_LimitExceeded", "MaxCharactersFromEntities");
			}
		}
	}

	internal static void AdjustLineInfo(char[] chars, int startPos, int endPos, bool isNormalized, ref LineInfo lineInfo)
	{
		AdjustLineInfo(chars.AsSpan(startPos, endPos - startPos), isNormalized, ref lineInfo);
	}

	internal static void AdjustLineInfo(string str, int startPos, int endPos, bool isNormalized, ref LineInfo lineInfo)
	{
		AdjustLineInfo(str.AsSpan(startPos, endPos - startPos), isNormalized, ref lineInfo);
	}

	private static void AdjustLineInfo(ReadOnlySpan<char> chars, bool isNormalized, ref LineInfo lineInfo)
	{
		int num = -1;
		for (int i = 0; i < chars.Length; i++)
		{
			switch (chars[i])
			{
			case '\n':
				lineInfo.lineNo++;
				num = i;
				break;
			case '\r':
				if (!isNormalized)
				{
					lineInfo.lineNo++;
					num = i;
					int num2 = i + 1;
					if ((uint)num2 < (uint)chars.Length && chars[num2] == '\n')
					{
						i++;
						num++;
					}
				}
				break;
			}
		}
		if (num >= 0)
		{
			lineInfo.linePos = chars.Length - num;
		}
	}

	internal static string StripSpaces(string value)
	{
		int length = value.Length;
		if (length <= 0)
		{
			return string.Empty;
		}
		int num = 0;
		StringBuilder stringBuilder = null;
		while (value[num] == ' ')
		{
			num++;
			if (num == length)
			{
				return " ";
			}
		}
		int i;
		for (i = num; i < length; i++)
		{
			if (value[i] != ' ')
			{
				continue;
			}
			int j;
			for (j = i + 1; j < length && value[j] == ' '; j++)
			{
			}
			if (j == length)
			{
				if (stringBuilder == null)
				{
					return value.Substring(num, i - num);
				}
				stringBuilder.Append(value, num, i - num);
				return stringBuilder.ToString();
			}
			if (j > i + 1)
			{
				if (stringBuilder == null)
				{
					stringBuilder = new StringBuilder(length);
				}
				stringBuilder.Append(value, num, i - num + 1);
				num = j;
				i = j - 1;
			}
		}
		if (stringBuilder == null)
		{
			if (num != 0)
			{
				return value.Substring(num, length - num);
			}
			return value;
		}
		if (i > num)
		{
			stringBuilder.Append(value, num, i - num);
		}
		return stringBuilder.ToString();
	}

	internal static void StripSpaces(char[] value, int index, ref int len)
	{
		if (len <= 0)
		{
			return;
		}
		int num = index;
		int num2 = index + len;
		while (value[num] == ' ')
		{
			num++;
			if (num == num2)
			{
				len = 1;
				return;
			}
		}
		int num3 = num - index;
		for (int i = num; i < num2; i++)
		{
			char c;
			if ((c = value[i]) == ' ')
			{
				int j;
				for (j = i + 1; j < num2 && value[j] == ' '; j++)
				{
				}
				if (j == num2)
				{
					num3 += j - i;
					break;
				}
				if (j > i + 1)
				{
					num3 += j - i - 1;
					i = j - 1;
				}
			}
			value[i - num3] = c;
		}
		len -= num3;
	}

	internal static void BlockCopyChars(char[] src, int srcOffset, char[] dst, int dstOffset, int count)
	{
		Buffer.BlockCopy(src, srcOffset * 2, dst, dstOffset * 2, count * 2);
	}

	internal static void BlockCopy(byte[] src, int srcOffset, byte[] dst, int dstOffset, int count)
	{
		Buffer.BlockCopy(src, srcOffset, dst, dstOffset, count);
	}

	private static void ConvertAbsoluteUnixPathToAbsoluteUri([NotNullIfNotNull("url")][NotNullIfNotNull("url")] ref string url, XmlResolver resolver)
	{
		if (url == null || url.Length <= 0 || url[0] != '/')
		{
			return;
		}
		if (resolver != null)
		{
			Uri uri = resolver.ResolveUri(null, url);
			if (uri.IsFile)
			{
				url = uri.ToString();
			}
		}
		else
		{
			url = new Uri(url).ToString();
		}
	}
}
