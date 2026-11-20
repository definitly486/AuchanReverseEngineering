using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace System.Data;

[Serializable]
[ToolboxItem(false)]
[DesignTimeVisible(false)]
[DefaultProperty("TableName")]
[DefaultEvent("RowChanging")]
[Editor("Microsoft.VSDesigner.Data.Design.DataTableEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[XmlSchemaProvider("GetDataTableSchema")]
[TypeForwardedFrom("System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
public class DataTable : MarshalByValueComponent, ISerializable, IXmlSerializable
{
	internal struct DSRowDiffIdUsageSection
	{
		private DataSet _targetDS;

		internal void Prepare(DataSet ds)
		{
			_targetDS = ds;
			for (int i = 0; i < ds.Tables.Count; i++)
			{
				ds.Tables[i]._rowDiffId = null;
			}
		}
	}

	private DataSet _dataSet;

	private DataView _defaultView;

	internal long _nextRowID;

	internal readonly DataRowCollection _rowCollection;

	internal readonly DataColumnCollection _columnCollection;

	private readonly ConstraintCollection _constraintCollection;

	private int _elementColumnCount;

	internal DataRelationCollection _parentRelationsCollection;

	internal DataRelationCollection _childRelationsCollection;

	internal readonly RecordManager _recordManager;

	internal readonly List<Index> _indexes;

	private List<Index> _shadowIndexes;

	private int _shadowCount;

	internal PropertyCollection _extendedProperties;

	private string _tableName = string.Empty;

	internal string _tableNamespace;

	private string _tablePrefix = string.Empty;

	internal DataExpression _displayExpression;

	internal bool _fNestedInDataset = true;

	private CultureInfo _culture;

	private bool _cultureUserSet;

	private CompareInfo _compareInfo;

	private CompareOptions _compareFlags = CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth;

	private IFormatProvider _formatProvider;

	private StringComparer _hashCodeProvider;

	private bool _caseSensitive;

	private bool _caseSensitiveUserSet;

	internal string _encodedTableName;

	internal DataColumn _xmlText;

	internal DataColumn _colUnique;

	internal decimal _minOccurs = 1m;

	internal decimal _maxOccurs = 1m;

	internal bool _repeatableElement;

	private object _typeName;

	internal UniqueConstraint _primaryKey;

	internal IndexField[] _primaryIndex = Array.Empty<IndexField>();

	private DataColumn[] _delayedSetPrimaryKey;

	private Index _loadIndex;

	private Index _loadIndexwithOriginalAdded;

	private Index _loadIndexwithCurrentDeleted;

	private int _suspendIndexEvents;

	private bool _inDataLoad;

	private bool _enforceConstraints = true;

	internal bool _suspendEnforceConstraints;

	protected internal bool fInitInProgress;

	internal bool _fInLoadDiffgram;

	private byte _isTypedDataTable;

	private DataRow[] _emptyDataRowArray;

	private PropertyDescriptorCollection _propertyDescriptorCollectionCache;

	private DataRelation[] _nestedParentRelations = Array.Empty<DataRelation>();

	internal List<DataColumn> _dependentColumns;

	private bool _mergingData;

	private DataRowChangeEventHandler _onRowChangedDelegate;

	private DataRowChangeEventHandler _onRowChangingDelegate;

	private DataRowChangeEventHandler _onRowDeletingDelegate;

	private DataRowChangeEventHandler _onRowDeletedDelegate;

	private DataColumnChangeEventHandler _onColumnChangedDelegate;

	private DataColumnChangeEventHandler _onColumnChangingDelegate;

	private DataTableClearEventHandler _onTableClearingDelegate;

	private DataTableClearEventHandler _onTableClearedDelegate;

	private DataTableNewRowEventHandler _onTableNewRowDelegate;

	private PropertyChangedEventHandler _onPropertyChangingDelegate;

	private readonly DataRowBuilder _rowBuilder;

	internal readonly List<DataView> _delayedViews = new List<DataView>();

	private readonly List<DataViewListener> _dataViewListeners = new List<DataViewListener>();

	internal Hashtable _rowDiffId;

	internal readonly ReaderWriterLockSlim _indexesLock = new ReaderWriterLockSlim();

	internal int _ukColumnPositionForInference = -1;

	private SerializationFormat _remotingFormat;

	private static int s_objectTypeCount;

	private readonly int _objectID = Interlocked.Increment(ref s_objectTypeCount);

	public bool CaseSensitive
	{
		get
		{
			return _caseSensitive;
		}
		set
		{
			if (_caseSensitive != value)
			{
				bool caseSensitive = _caseSensitive;
				bool caseSensitiveUserSet = _caseSensitiveUserSet;
				_caseSensitive = value;
				_caseSensitiveUserSet = true;
				if (DataSet != null && !DataSet.ValidateCaseConstraint())
				{
					_caseSensitive = caseSensitive;
					_caseSensitiveUserSet = caseSensitiveUserSet;
					throw ExceptionBuilder.CannotChangeCaseLocale();
				}
				SetCaseSensitiveValue(value, userSet: true, resetIndexes: true);
			}
			_caseSensitiveUserSet = true;
		}
	}

	internal bool AreIndexEventsSuspended => 0 < _suspendIndexEvents;

	[Browsable(false)]
	public bool IsInitialized => !fInitInProgress;

	private bool IsTypedDataTable
	{
		get
		{
			switch (_isTypedDataTable)
			{
			case 0:
				_isTypedDataTable = (byte)((GetType() != typeof(DataTable)) ? 1u : 2u);
				return 1 == _isTypedDataTable;
			case 1:
				return true;
			default:
				return false;
			}
		}
	}

	internal bool SelfNested
	{
		get
		{
			foreach (DataRelation parentRelation in ParentRelations)
			{
				if (parentRelation.Nested && parentRelation.ParentTable == this)
				{
					return true;
				}
			}
			return false;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal List<Index> LiveIndexes
	{
		get
		{
			if (!AreIndexEventsSuspended)
			{
				int num = _indexes.Count - 1;
				while (0 <= num)
				{
					Index index = _indexes[num];
					if (index.RefCount <= 1)
					{
						index.RemoveRef();
					}
					num--;
				}
			}
			return _indexes;
		}
	}

	[DefaultValue(SerializationFormat.Xml)]
	public SerializationFormat RemotingFormat
	{
		get
		{
			return _remotingFormat;
		}
		set
		{
			switch (value)
			{
			case SerializationFormat.Binary:
				if (!System.LocalAppContextSwitches.AllowUnsafeSerializationFormatBinary)
				{
					throw ExceptionBuilder.SerializationFormatBinaryNotSupported();
				}
				break;
			default:
				throw ExceptionBuilder.InvalidRemotingFormat(value);
			case SerializationFormat.Xml:
				break;
			}
			if (DataSet != null && value != DataSet.RemotingFormat)
			{
				throw ExceptionBuilder.CanNotSetRemotingFormat();
			}
			_remotingFormat = value;
		}
	}

	internal int UKColumnPositionForInference
	{
		get
		{
			return _ukColumnPositionForInference;
		}
		set
		{
			_ukColumnPositionForInference = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public DataRelationCollection ChildRelations => _childRelationsCollection ?? (_childRelationsCollection = new DataRelationCollection.DataTableRelationCollection(this, fParentCollection: false));

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public DataColumnCollection Columns => _columnCollection;

	private CompareInfo CompareInfo => _compareInfo ?? (_compareInfo = Locale.CompareInfo);

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public ConstraintCollection Constraints => _constraintCollection;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public DataSet? DataSet => _dataSet;

	[Browsable(false)]
	public DataView DefaultView
	{
		get
		{
			DataView dataView = _defaultView;
			if (dataView == null)
			{
				if (_dataSet != null)
				{
					dataView = _dataSet.DefaultViewManager.CreateDataView(this);
				}
				else
				{
					dataView = new DataView(this, locked: true);
					dataView.SetIndex2("", DataViewRowState.CurrentRows, null, fireEvent: true);
				}
				dataView = Interlocked.CompareExchange(ref _defaultView, dataView, null);
				if (dataView == null)
				{
					dataView = _defaultView;
				}
			}
			return dataView;
		}
	}

	[DefaultValue("")]
	public string DisplayExpression
	{
		get
		{
			return DisplayExpressionInternal;
		}
		[RequiresUnreferencedCode("Members from types used in the expressions may be trimmed if not referenced directly.")]
		[param: AllowNull]
		set
		{
			_displayExpression = ((!string.IsNullOrEmpty(value)) ? new DataExpression(this, value) : null);
		}
	}

	internal string DisplayExpressionInternal
	{
		get
		{
			if (_displayExpression == null)
			{
				return string.Empty;
			}
			return _displayExpression.Expression;
		}
	}

	internal bool EnforceConstraints
	{
		get
		{
			if (SuspendEnforceConstraints)
			{
				return false;
			}
			if (_dataSet != null)
			{
				return _dataSet.EnforceConstraints;
			}
			return _enforceConstraints;
		}
		set
		{
			if (_dataSet == null && _enforceConstraints != value)
			{
				if (value)
				{
					EnableConstraints();
				}
				_enforceConstraints = value;
			}
		}
	}

	internal bool SuspendEnforceConstraints => _suspendEnforceConstraints;

	[Browsable(false)]
	public PropertyCollection ExtendedProperties => _extendedProperties ?? (_extendedProperties = new PropertyCollection());

	internal IFormatProvider FormatProvider
	{
		get
		{
			if (_formatProvider == null)
			{
				CultureInfo cultureInfo = Locale;
				if (cultureInfo.IsNeutralCulture)
				{
					cultureInfo = CultureInfo.InvariantCulture;
				}
				_formatProvider = cultureInfo;
			}
			return _formatProvider;
		}
	}

	[Browsable(false)]
	public bool HasErrors
	{
		get
		{
			for (int i = 0; i < Rows.Count; i++)
			{
				if (Rows[i].HasErrors)
				{
					return true;
				}
			}
			return false;
		}
	}

	public CultureInfo Locale
	{
		get
		{
			return _culture;
		}
		set
		{
			long scopeId = DataCommonEventSource.Log.EnterScope("<ds.DataTable.set_Locale|API> {0}", ObjectID);
			try
			{
				bool cultureUserSet = true;
				if (value == null)
				{
					cultureUserSet = false;
					value = ((_dataSet != null) ? _dataSet.Locale : _culture);
				}
				if (_culture != value && !_culture.Equals(value))
				{
					bool flag = false;
					bool flag2 = false;
					CultureInfo culture = _culture;
					bool cultureUserSet2 = _cultureUserSet;
					try
					{
						_cultureUserSet = true;
						SetLocaleValue(value, userSet: true, resetIndexes: false);
						if (DataSet == null || DataSet.ValidateLocaleConstraint())
						{
							flag = false;
							SetLocaleValue(value, userSet: true, resetIndexes: true);
							flag = true;
						}
					}
					catch
					{
						flag2 = true;
						throw;
					}
					finally
					{
						if (!flag)
						{
							try
							{
								SetLocaleValue(culture, userSet: true, resetIndexes: true);
							}
							catch (Exception e) when (ADP.IsCatchableExceptionType(e))
							{
								ADP.TraceExceptionWithoutRethrow(e);
							}
							_cultureUserSet = cultureUserSet2;
							if (!flag2)
							{
								throw ExceptionBuilder.CannotChangeCaseLocale(null);
							}
						}
					}
					SetLocaleValue(value, userSet: true, resetIndexes: true);
				}
				_cultureUserSet = cultureUserSet;
			}
			finally
			{
				DataCommonEventSource.Log.ExitScope(scopeId);
			}
		}
	}

	[DefaultValue(50)]
	public int MinimumCapacity
	{
		get
		{
			return _recordManager.MinimumCapacity;
		}
		set
		{
			if (value != _recordManager.MinimumCapacity)
			{
				_recordManager.MinimumCapacity = value;
			}
		}
	}

	internal int RecordCapacity => _recordManager.RecordCapacity;

	internal int ElementColumnCount
	{
		get
		{
			return _elementColumnCount;
		}
		set
		{
			if (value > 0 && _xmlText != null)
			{
				throw ExceptionBuilder.TableCannotAddToSimpleContent();
			}
			_elementColumnCount = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public DataRelationCollection ParentRelations => _parentRelationsCollection ?? (_parentRelationsCollection = new DataRelationCollection.DataTableRelationCollection(this, fParentCollection: true));

	internal bool MergingData
	{
		get
		{
			return _mergingData;
		}
		set
		{
			_mergingData = value;
		}
	}

	internal DataRelation[] NestedParentRelations => _nestedParentRelations;

	internal int NestedParentsCount
	{
		get
		{
			int num = 0;
			foreach (DataRelation parentRelation in ParentRelations)
			{
				if (parentRelation.Nested)
				{
					num++;
				}
			}
			return num;
		}
	}

	[Editor("Microsoft.VSDesigner.Data.Design.PrimaryKeyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[TypeConverter(typeof(PrimaryKeyTypeConverter))]
	public DataColumn[] PrimaryKey
	{
		get
		{
			UniqueConstraint primaryKey = _primaryKey;
			if (primaryKey != null)
			{
				return primaryKey.Key.ToArray();
			}
			return Array.Empty<DataColumn>();
		}
		[param: AllowNull]
		set
		{
			UniqueConstraint uniqueConstraint = null;
			if (fInitInProgress && value != null)
			{
				_delayedSetPrimaryKey = value;
				return;
			}
			if (value != null && value.Length != 0)
			{
				int num = 0;
				for (int i = 0; i < value.Length && value[i] != null; i++)
				{
					num++;
				}
				if (num != 0)
				{
					DataColumn[] array = value;
					if (num != value.Length)
					{
						array = new DataColumn[num];
						for (int j = 0; j < num; j++)
						{
							array[j] = value[j];
						}
					}
					uniqueConstraint = new UniqueConstraint(array);
					if (uniqueConstraint.Table != this)
					{
						throw ExceptionBuilder.TableForeignPrimaryKey();
					}
				}
			}
			if (uniqueConstraint == _primaryKey || (uniqueConstraint != null && uniqueConstraint.Equals(_primaryKey)))
			{
				return;
			}
			UniqueConstraint uniqueConstraint2;
			if ((uniqueConstraint2 = (UniqueConstraint)Constraints.FindConstraint(uniqueConstraint)) != null)
			{
				uniqueConstraint.ColumnsReference.CopyTo(uniqueConstraint2.Key.ColumnsReference, 0);
				uniqueConstraint = uniqueConstraint2;
			}
			UniqueConstraint primaryKey = _primaryKey;
			_primaryKey = null;
			if (primaryKey != null)
			{
				primaryKey.ConstraintIndex.RemoveRef();
				if (_loadIndex != null)
				{
					_loadIndex.RemoveRef();
					_loadIndex = null;
				}
				if (_loadIndexwithOriginalAdded != null)
				{
					_loadIndexwithOriginalAdded.RemoveRef();
					_loadIndexwithOriginalAdded = null;
				}
				if (_loadIndexwithCurrentDeleted != null)
				{
					_loadIndexwithCurrentDeleted.RemoveRef();
					_loadIndexwithCurrentDeleted = null;
				}
				Constraints.Remove(primaryKey);
			}
			if (uniqueConstraint != null && uniqueConstraint2 == null)
			{
				Constraints.Add(uniqueConstraint);
			}
			_primaryKey = uniqueConstraint;
			_primaryIndex = ((uniqueConstraint != null) ? uniqueConstraint.Key.GetIndexDesc() : Array.Empty<IndexField>());
			if (_primaryKey != null)
			{
				uniqueConstraint.ConstraintIndex.AddRef();
				for (int k = 0; k < uniqueConstraint.ColumnsReference.Length; k++)
				{
					uniqueConstraint.ColumnsReference[k].AllowDBNull = false;
				}
			}
		}
	}

	[Browsable(false)]
	public DataRowCollection Rows => _rowCollection;

	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue("")]
	public string TableName
	{
		get
		{
			return _tableName;
		}
		[param: AllowNull]
		set
		{
			long scopeId = DataCommonEventSource.Log.EnterScope("<ds.DataTable.set_TableName|API> {0}, value='{1}'", ObjectID, value);
			try
			{
				if (value == null)
				{
					value = string.Empty;
				}
				CultureInfo locale = Locale;
				if (string.Compare(_tableName, value, ignoreCase: true, locale) != 0)
				{
					if (_dataSet != null)
					{
						if (value.Length == 0)
						{
							throw ExceptionBuilder.NoTableName();
						}
						if (string.Compare(value, _dataSet.DataSetName, ignoreCase: true, _dataSet.Locale) == 0 && !_fNestedInDataset)
						{
							throw ExceptionBuilder.DatasetConflictingName(_dataSet.DataSetName);
						}
						DataRelation[] nestedParentRelations = NestedParentRelations;
						if (nestedParentRelations.Length == 0)
						{
							_dataSet.Tables.RegisterName(value, Namespace);
						}
						else
						{
							DataRelation[] array = nestedParentRelations;
							for (int i = 0; i < array.Length; i++)
							{
								if (!array[i].ParentTable.Columns.CanRegisterName(value))
								{
									throw ExceptionBuilder.CannotAddDuplicate2(value);
								}
							}
							_dataSet.Tables.RegisterName(value, Namespace);
							array = nestedParentRelations;
							foreach (DataRelation obj in array)
							{
								obj.ParentTable.Columns.RegisterColumnName(value, null);
								obj.ParentTable.Columns.UnregisterName(TableName);
							}
						}
						if (_tableName.Length != 0)
						{
							_dataSet.Tables.UnregisterName(_tableName);
						}
					}
					RaisePropertyChanging("TableName");
					_tableName = value;
					_encodedTableName = null;
				}
				else if (string.Compare(_tableName, value, ignoreCase: false, locale) != 0)
				{
					RaisePropertyChanging("TableName");
					_tableName = value;
					_encodedTableName = null;
				}
			}
			finally
			{
				DataCommonEventSource.Log.ExitScope(scopeId);
			}
		}
	}

	internal string EncodedTableName
	{
		get
		{
			string text = _encodedTableName;
			if (text == null)
			{
				text = (_encodedTableName = XmlConvert.EncodeLocalName(TableName));
			}
			return text;
		}
	}

	public string Namespace
	{
		get
		{
			return _tableNamespace ?? GetInheritedNamespace(new List<DataTable>());
		}
		[param: AllowNull]
		set
		{
			long scopeId = DataCommonEventSource.Log.EnterScope("<ds.DataTable.set_Namespace|API> {0}, value='{1}'", ObjectID, value);
			try
			{
				if (value != _tableNamespace)
				{
					if (_dataSet != null)
					{
						string text = value ?? GetInheritedNamespace(new List<DataTable>());
						if (text != Namespace)
						{
							if (_dataSet.Tables.Contains(TableName, text, checkProperty: true, caseSensitive: true))
							{
								throw ExceptionBuilder.DuplicateTableName2(TableName, text);
							}
							CheckCascadingNamespaceConflict(text);
						}
					}
					CheckNamespaceValidityForNestedRelations(value);
					DoRaiseNamespaceChange();
				}
				_tableNamespace = value;
			}
			finally
			{
				DataCommonEventSource.Log.ExitScope(scopeId);
			}
		}
	}

	[DefaultValue("")]
	public string Prefix
	{
		get
		{
			return _tablePrefix;
		}
		[param: AllowNull]
		set
		{
			if (value == null)
			{
				value = string.Empty;
			}
			DataCommonEventSource.Log.Trace("<ds.DataTable.set_Prefix|API> {0}, value='{1}'", ObjectID, value);
			if (XmlConvert.DecodeName(value) == value && XmlConvert.EncodeName(value) != value)
			{
				throw ExceptionBuilder.InvalidPrefix(value);
			}
			_tablePrefix = value;
		}
	}

	internal DataColumn? XmlText
	{
		get
		{
			return _xmlText;
		}
		set
		{
			if (_xmlText == value)
			{
				return;
			}
			if (_xmlText != null)
			{
				if (value != null)
				{
					throw ExceptionBuilder.MultipleTextOnlyColumns();
				}
				Columns.Remove(_xmlText);
			}
			else if (value != Columns[value.ColumnName])
			{
				Columns.Add(value);
			}
			_xmlText = value;
		}
	}

	internal decimal MaxOccurs
	{
		get
		{
			return _maxOccurs;
		}
		set
		{
			_maxOccurs = value;
		}
	}

	internal decimal MinOccurs
	{
		get
		{
			return _minOccurs;
		}
		set
		{
			_minOccurs = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override ISite? Site
	{
		get
		{
			return base.Site;
		}
		set
		{
			ISite site = Site;
			if (value == null && site != null)
			{
				IContainer container = site.Container;
				if (container != null)
				{
					for (int i = 0; i < Columns.Count; i++)
					{
						if (Columns[i].Site != null)
						{
							container.Remove(Columns[i]);
						}
					}
				}
			}
			base.Site = value;
		}
	}

	internal bool NeedColumnChangeEvents
	{
		get
		{
			if (!IsTypedDataTable && _onColumnChangingDelegate == null)
			{
				return _onColumnChangedDelegate != null;
			}
			return true;
		}
	}

	internal XmlQualifiedName TypeName
	{
		get
		{
			if (_typeName != null)
			{
				return (XmlQualifiedName)_typeName;
			}
			return XmlQualifiedName.Empty;
		}
		set
		{
			_typeName = value;
		}
	}

	internal Hashtable RowDiffId => _rowDiffId ?? (_rowDiffId = new Hashtable());

	internal int ObjectID => _objectID;

	public DataTable()
	{
		GC.SuppressFinalize(this);
		DataCommonEventSource.Log.Trace("<ds.DataTable.DataTable|API> {0}", ObjectID);
		_nextRowID = 1L;
		_recordManager = new RecordManager(this);
		_culture = CultureInfo.CurrentCulture;
		_columnCollection = new DataColumnCollection(this);
		_constraintCollection = new ConstraintCollection(this);
		_rowCollection = new DataRowCollection(this);
		_indexes = new List<Index>();
		_rowBuilder = new DataRowBuilder(this, -1);
	}

	public DataTable(string? tableName)
		: this()
	{
		_tableName = tableName ?? "";
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2112:ReflectionToRequiresUnreferencedCode", Justification = "CreateInstance's use of GetType uses only the parameterless constructor. Warnings are about serialization related constructors.")]
	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	[RequiresDynamicCode("Members from serialized types may use dynamic code generation.")]
	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected DataTable(SerializationInfo info, StreamingContext context)
		: this()
	{
		bool isSingleTable = context.Context == null || Convert.ToBoolean(context.Context, CultureInfo.InvariantCulture);
		SerializationFormat serializationFormat = SerializationFormat.Xml;
		SerializationInfoEnumerator enumerator = info.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (enumerator.Name == "DataTable.RemotingFormat")
			{
				serializationFormat = (SerializationFormat)enumerator.Value;
			}
		}
		if (serializationFormat == SerializationFormat.Binary && !System.LocalAppContextSwitches.AllowUnsafeSerializationFormatBinary)
		{
			throw ExceptionBuilder.SerializationFormatBinaryNotSupported();
		}
		DeserializeDataTable(info, isSingleTable, serializationFormat);
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Binary serialization is unsafe in general and is planned to be obsoleted. We do not want to mark interface or ctors of this class as unsafe as that would show many unnecessary warnings elsewhere.")]
	[UnconditionalSuppressMessage("AotAnalysis", "IL3050:RequiresDynamicCode", Justification = "Binary serialization is unsafe in general and is planned to be obsoleted. We do not want to mark interface or ctors of this class as unsafe as that would show many unnecessary warnings elsewhere.")]
	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		SerializationFormat remotingFormat = RemotingFormat;
		bool isSingleTable = context.Context == null || Convert.ToBoolean(context.Context, CultureInfo.InvariantCulture);
		SerializeDataTable(info, isSingleTable, remotingFormat);
	}

	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	[RequiresDynamicCode("Members from serialized types may use dynamic code generation.")]
	private void SerializeDataTable(SerializationInfo info, bool isSingleTable, SerializationFormat remotingFormat)
	{
		info.AddValue("DataTable.RemotingVersion", new Version(2, 0));
		if (remotingFormat != SerializationFormat.Xml)
		{
			info.AddValue("DataTable.RemotingFormat", remotingFormat);
		}
		if (remotingFormat != SerializationFormat.Xml)
		{
			SerializeTableSchema(info, isSingleTable);
			if (isSingleTable)
			{
				SerializeTableData(info, 0);
			}
			return;
		}
		string namespaceURI = string.Empty;
		bool flag = false;
		if (_dataSet == null)
		{
			DataSet dataSet = new DataSet("tmpDataSet");
			dataSet.SetLocaleValue(_culture, _cultureUserSet);
			dataSet.CaseSensitive = CaseSensitive;
			dataSet._namespaceURI = Namespace;
			dataSet.Tables.Add(this);
			flag = true;
		}
		else
		{
			namespaceURI = _dataSet.Namespace;
			_dataSet._namespaceURI = Namespace;
		}
		info.AddValue("XmlSchema", _dataSet.GetXmlSchemaForRemoting(this));
		info.AddValue("XmlDiffGram", System.Data.DataSet.GetRemotingDiffGram(this));
		if (flag)
		{
			_dataSet.Tables.Remove(this);
		}
		else
		{
			_dataSet._namespaceURI = namespaceURI;
		}
	}

	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	[RequiresDynamicCode("Members from serialized types may use dynamic code generation.")]
	internal void DeserializeDataTable(SerializationInfo info, bool isSingleTable, SerializationFormat remotingFormat)
	{
		if (remotingFormat != SerializationFormat.Xml)
		{
			DeserializeTableSchema(info, isSingleTable);
			if (isSingleTable)
			{
				DeserializeTableData(info, 0);
				ResetIndexes();
			}
			return;
		}
		string text = (string)info.GetValue("XmlSchema", typeof(string));
		string text2 = (string)info.GetValue("XmlDiffGram", typeof(string));
		if (text != null)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(text)));
			DataTable dataTable = dataSet.Tables[0];
			dataTable.CloneTo(this, null, skipExpressionColumns: false);
			Namespace = dataTable.Namespace;
			if (text2 != null)
			{
				dataSet.Tables.Remove(dataSet.Tables[0]);
				dataSet.Tables.Add(this);
				dataSet.ReadXml(new XmlTextReader(new StringReader(text2)), XmlReadMode.DiffGram);
				dataSet.Tables.Remove(this);
			}
		}
	}

	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	internal void SerializeTableSchema(SerializationInfo info, bool isSingleTable)
	{
		info.AddValue("DataTable.TableName", TableName);
		info.AddValue("DataTable.Namespace", Namespace);
		info.AddValue("DataTable.Prefix", Prefix);
		info.AddValue("DataTable.CaseSensitive", _caseSensitive);
		info.AddValue("DataTable.caseSensitiveAmbient", !_caseSensitiveUserSet);
		info.AddValue("DataTable.LocaleLCID", Locale.LCID);
		info.AddValue("DataTable.MinimumCapacity", _recordManager.MinimumCapacity);
		info.AddValue("DataTable.NestedInDataSet", _fNestedInDataset);
		info.AddValue("DataTable.TypeName", TypeName.ToString());
		info.AddValue("DataTable.RepeatableElement", _repeatableElement);
		info.AddValue("DataTable.ExtendedProperties", ExtendedProperties);
		info.AddValue("DataTable.Columns.Count", Columns.Count);
		if (isSingleTable && !CheckForClosureOnExpressionTables(new List<DataTable> { this }))
		{
			throw ExceptionBuilder.CanNotRemoteDataTable();
		}
		IFormatProvider invariantCulture = CultureInfo.InvariantCulture;
		for (int i = 0; i < Columns.Count; i++)
		{
			info.AddValue(string.Format(invariantCulture, "DataTable.DataColumn_{0}.ColumnName", i), Columns[i].ColumnName);
			info.AddValue(string.Format(invariantCulture, "DataTable.DataColumn_{0}.Namespace", i), Columns[i]._columnUri);
			info.AddValue(string.Format(invariantCulture, "DataTable.DataColumn_{0}.Prefix", i), Columns[i].Prefix);
			info.AddValue(string.Format(invariantCulture, "DataTable.DataColumn_{0}.ColumnMapping", i), Columns[i].ColumnMapping);
			info.AddValue(string.Format(invariantCulture, "DataTable.DataColumn_{0}.AllowDBNull", i), Columns[i].AllowDBNull);
			info.AddValue(string.Format(invariantCulture, "DataTable.DataColumn_{0}.AutoIncrement", i), Columns[i].AutoIncrement);
			info.AddValue(string.Format(invariantCulture, "DataTable.DataColumn_{0}.AutoIncrementStep", i), Columns[i].AutoIncrementStep);
			info.AddValue(string.Format(invariantCulture, "DataTable.DataColumn_{0}.AutoIncrementSeed", i), Columns[i].AutoIncrementSeed);
			info.AddValue(string.Format(invariantCulture, "DataTable.DataColumn_{0}.Caption", i), Columns[i].Caption);
			info.AddValue(string.Format(invariantCulture, "DataTable.DataColumn_{0}.DefaultValue", i), Columns[i].DefaultValue);
			info.AddValue(string.Format(invariantCulture, "DataTable.DataColumn_{0}.ReadOnly", i), Columns[i].ReadOnly);
			info.AddValue(string.Format(invariantCulture, "DataTable.DataColumn_{0}.MaxLength", i), Columns[i].MaxLength);
			info.AddValue(string.Format(invariantCulture, "DataTable.DataColumn_{0}.DataType_AssemblyQualifiedName", i), Columns[i].DataType.AssemblyQualifiedName);
			info.AddValue(string.Format(invariantCulture, "DataTable.DataColumn_{0}.XmlDataType", i), Columns[i].XmlDataType);
			info.AddValue(string.Format(invariantCulture, "DataTable.DataColumn_{0}.SimpleType", i), Columns[i].SimpleType);
			info.AddValue(string.Format(invariantCulture, "DataTable.DataColumn_{0}.DateTimeMode", i), Columns[i].DateTimeMode);
			info.AddValue(string.Format(invariantCulture, "DataTable.DataColumn_{0}.AutoIncrementCurrent", i), Columns[i].AutoIncrementCurrent);
			if (isSingleTable)
			{
				info.AddValue(string.Format(invariantCulture, "DataTable.DataColumn_{0}.Expression", i), Columns[i].Expression);
			}
			info.AddValue(string.Format(invariantCulture, "DataTable.DataColumn_{0}.ExtendedProperties", i), Columns[i]._extendedProperties);
		}
		if (isSingleTable)
		{
			SerializeConstraints(info, 0, allConstraints: false);
		}
	}

	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	internal void DeserializeTableSchema(SerializationInfo info, bool isSingleTable)
	{
		_tableName = info.GetString("DataTable.TableName");
		_tableNamespace = info.GetString("DataTable.Namespace");
		_tablePrefix = info.GetString("DataTable.Prefix");
		bool boolean = info.GetBoolean("DataTable.CaseSensitive");
		SetCaseSensitiveValue(boolean, userSet: true, resetIndexes: false);
		_caseSensitiveUserSet = !info.GetBoolean("DataTable.caseSensitiveAmbient");
		CultureInfo culture = new CultureInfo((int)info.GetValue("DataTable.LocaleLCID", typeof(int)));
		SetLocaleValue(culture, userSet: true, resetIndexes: false);
		_cultureUserSet = true;
		MinimumCapacity = info.GetInt32("DataTable.MinimumCapacity");
		_fNestedInDataset = info.GetBoolean("DataTable.NestedInDataSet");
		string name = info.GetString("DataTable.TypeName");
		_typeName = new XmlQualifiedName(name);
		_repeatableElement = info.GetBoolean("DataTable.RepeatableElement");
		_extendedProperties = (PropertyCollection)info.GetValue("DataTable.ExtendedProperties", typeof(PropertyCollection));
		int @int = info.GetInt32("DataTable.Columns.Count");
		string[] array = new string[@int];
		IFormatProvider invariantCulture = CultureInfo.InvariantCulture;
		for (int i = 0; i < @int; i++)
		{
			DataColumn dataColumn = new DataColumn();
			dataColumn.ColumnName = info.GetString(string.Format(invariantCulture, "DataTable.DataColumn_{0}.ColumnName", i));
			dataColumn._columnUri = info.GetString(string.Format(invariantCulture, "DataTable.DataColumn_{0}.Namespace", i));
			dataColumn.Prefix = info.GetString(string.Format(invariantCulture, "DataTable.DataColumn_{0}.Prefix", i));
			string typeName = (string)info.GetValue(string.Format(invariantCulture, "DataTable.DataColumn_{0}.DataType_AssemblyQualifiedName", i), typeof(string));
			dataColumn.DataType = Type.GetType(typeName, throwOnError: true);
			dataColumn.XmlDataType = (string)info.GetValue(string.Format(invariantCulture, "DataTable.DataColumn_{0}.XmlDataType", i), typeof(string));
			dataColumn.SimpleType = (SimpleType)info.GetValue(string.Format(invariantCulture, "DataTable.DataColumn_{0}.SimpleType", i), typeof(SimpleType));
			dataColumn.ColumnMapping = (MappingType)info.GetValue(string.Format(invariantCulture, "DataTable.DataColumn_{0}.ColumnMapping", i), typeof(MappingType));
			dataColumn.DateTimeMode = (DataSetDateTime)info.GetValue(string.Format(invariantCulture, "DataTable.DataColumn_{0}.DateTimeMode", i), typeof(DataSetDateTime));
			dataColumn.AllowDBNull = info.GetBoolean(string.Format(invariantCulture, "DataTable.DataColumn_{0}.AllowDBNull", i));
			dataColumn.AutoIncrement = info.GetBoolean(string.Format(invariantCulture, "DataTable.DataColumn_{0}.AutoIncrement", i));
			dataColumn.AutoIncrementStep = info.GetInt64(string.Format(invariantCulture, "DataTable.DataColumn_{0}.AutoIncrementStep", i));
			dataColumn.AutoIncrementSeed = info.GetInt64(string.Format(invariantCulture, "DataTable.DataColumn_{0}.AutoIncrementSeed", i));
			dataColumn.Caption = info.GetString(string.Format(invariantCulture, "DataTable.DataColumn_{0}.Caption", i));
			dataColumn.DefaultValue = info.GetValue(string.Format(invariantCulture, "DataTable.DataColumn_{0}.DefaultValue", i), typeof(object));
			dataColumn.ReadOnly = info.GetBoolean(string.Format(invariantCulture, "DataTable.DataColumn_{0}.ReadOnly", i));
			dataColumn.MaxLength = info.GetInt32(string.Format(invariantCulture, "DataTable.DataColumn_{0}.MaxLength", i));
			dataColumn.AutoIncrementCurrent = info.GetValue(string.Format(invariantCulture, "DataTable.DataColumn_{0}.AutoIncrementCurrent", i), typeof(object));
			if (isSingleTable)
			{
				array[i] = info.GetString(string.Format(invariantCulture, "DataTable.DataColumn_{0}.Expression", i));
			}
			dataColumn._extendedProperties = (PropertyCollection)info.GetValue(string.Format(invariantCulture, "DataTable.DataColumn_{0}.ExtendedProperties", i), typeof(PropertyCollection));
			Columns.Add(dataColumn);
		}
		if (isSingleTable)
		{
			for (int j = 0; j < @int; j++)
			{
				if (array[j] != null)
				{
					Columns[j].Expression = array[j];
				}
			}
		}
		if (isSingleTable)
		{
			DeserializeConstraints(info, 0, allConstraints: false);
		}
	}

	internal void SerializeConstraints(SerializationInfo info, int serIndex, bool allConstraints)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < Constraints.Count; i++)
		{
			Constraint constraint = Constraints[i];
			if (constraint is UniqueConstraint uniqueConstraint)
			{
				int[] array = new int[uniqueConstraint.Columns.Length];
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = uniqueConstraint.Columns[j].Ordinal;
				}
				ArrayList arrayList2 = new ArrayList();
				arrayList2.Add("U");
				arrayList2.Add(uniqueConstraint.ConstraintName);
				arrayList2.Add(array);
				arrayList2.Add(uniqueConstraint.IsPrimaryKey);
				arrayList2.Add(uniqueConstraint.ExtendedProperties);
				arrayList.Add(arrayList2);
				continue;
			}
			ForeignKeyConstraint foreignKeyConstraint = constraint as ForeignKeyConstraint;
			if (allConstraints || (foreignKeyConstraint.Table == this && foreignKeyConstraint.RelatedTable == this))
			{
				int[] array2 = new int[foreignKeyConstraint.RelatedColumns.Length + 1];
				array2[0] = (allConstraints ? DataSet.Tables.IndexOf(foreignKeyConstraint.RelatedTable) : 0);
				for (int k = 1; k < array2.Length; k++)
				{
					array2[k] = foreignKeyConstraint.RelatedColumns[k - 1].Ordinal;
				}
				int[] array3 = new int[foreignKeyConstraint.Columns.Length + 1];
				array3[0] = (allConstraints ? DataSet.Tables.IndexOf(foreignKeyConstraint.Table) : 0);
				for (int l = 1; l < array3.Length; l++)
				{
					array3[l] = foreignKeyConstraint.Columns[l - 1].Ordinal;
				}
				ArrayList arrayList3 = new ArrayList();
				arrayList3.Add("F");
				arrayList3.Add(foreignKeyConstraint.ConstraintName);
				arrayList3.Add(array2);
				arrayList3.Add(array3);
				arrayList3.Add(new int[3]
				{
					(int)foreignKeyConstraint.AcceptRejectRule,
					(int)foreignKeyConstraint.UpdateRule,
					(int)foreignKeyConstraint.DeleteRule
				});
				arrayList3.Add(foreignKeyConstraint.ExtendedProperties);
				arrayList.Add(arrayList3);
			}
		}
		info.AddValue(string.Format(CultureInfo.InvariantCulture, "DataTable_{0}.Constraints", serIndex), arrayList);
	}

	internal void DeserializeConstraints(SerializationInfo info, int serIndex, bool allConstraints)
	{
		foreach (ArrayList item in (ArrayList)info.GetValue(string.Format(CultureInfo.InvariantCulture, "DataTable_{0}.Constraints", serIndex), typeof(ArrayList)))
		{
			if (((string)item[0]).Equals("U"))
			{
				string name = (string)item[1];
				int[] array = (int[])item[2];
				bool isPrimaryKey = (bool)item[3];
				PropertyCollection extendedProperties = (PropertyCollection)item[4];
				DataColumn[] array2 = new DataColumn[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array2[i] = Columns[array[i]];
				}
				UniqueConstraint uniqueConstraint = new UniqueConstraint(name, array2, isPrimaryKey);
				uniqueConstraint._extendedProperties = extendedProperties;
				Constraints.Add(uniqueConstraint);
				continue;
			}
			string constraintName = (string)item[1];
			int[] array3 = (int[])item[2];
			int[] array4 = (int[])item[3];
			int[] array5 = (int[])item[4];
			PropertyCollection extendedProperties2 = (PropertyCollection)item[5];
			DataTable dataTable = ((!allConstraints) ? this : DataSet.Tables[array3[0]]);
			DataColumn[] array6 = new DataColumn[array3.Length - 1];
			for (int j = 0; j < array6.Length; j++)
			{
				array6[j] = dataTable.Columns[array3[j + 1]];
			}
			DataTable dataTable2 = ((!allConstraints) ? this : DataSet.Tables[array4[0]]);
			DataColumn[] array7 = new DataColumn[array4.Length - 1];
			for (int k = 0; k < array7.Length; k++)
			{
				array7[k] = dataTable2.Columns[array4[k + 1]];
			}
			ForeignKeyConstraint foreignKeyConstraint = new ForeignKeyConstraint(constraintName, array6, array7);
			foreignKeyConstraint.AcceptRejectRule = (AcceptRejectRule)array5[0];
			foreignKeyConstraint.UpdateRule = (Rule)array5[1];
			foreignKeyConstraint.DeleteRule = (Rule)array5[2];
			foreignKeyConstraint._extendedProperties = extendedProperties2;
			Constraints.Add(foreignKeyConstraint, addUniqueWhenAddingForeign: false);
		}
	}

	internal void SerializeExpressionColumns(SerializationInfo info, int serIndex)
	{
		int count = Columns.Count;
		for (int i = 0; i < count; i++)
		{
			info.AddValue(string.Format(CultureInfo.InvariantCulture, "DataTable_{0}.DataColumn_{1}.Expression", serIndex, i), Columns[i].Expression);
		}
	}

	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	internal void DeserializeExpressionColumns(SerializationInfo info, int serIndex)
	{
		int count = Columns.Count;
		for (int i = 0; i < count; i++)
		{
			string text = info.GetString(string.Format(CultureInfo.InvariantCulture, "DataTable_{0}.DataColumn_{1}.Expression", serIndex, i));
			if (text.Length != 0)
			{
				Columns[i].Expression = text;
			}
		}
	}

	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	internal void SerializeTableData(SerializationInfo info, int serIndex)
	{
		int count = Columns.Count;
		int count2 = Rows.Count;
		int num = 0;
		int num2 = 0;
		BitArray bitArray = new BitArray(count2 * 3, defaultValue: false);
		for (int i = 0; i < count2; i++)
		{
			int num3 = i * 3;
			DataRow dataRow = Rows[i];
			DataRowState rowState = dataRow.RowState;
			switch (rowState)
			{
			case DataRowState.Added:
				bitArray[num3 + 1] = true;
				break;
			case DataRowState.Modified:
				bitArray[num3] = true;
				num++;
				break;
			case DataRowState.Deleted:
				bitArray[num3] = true;
				bitArray[num3 + 1] = true;
				break;
			default:
				throw ExceptionBuilder.InvalidRowState(rowState);
			case DataRowState.Unchanged:
				break;
			}
			if (-1 != dataRow._tempRecord)
			{
				bitArray[num3 + 2] = true;
				num2++;
			}
		}
		int num4 = count2 + num + num2;
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		if (num4 > 0)
		{
			for (int j = 0; j < count; j++)
			{
				object emptyColumnStore = Columns[j].GetEmptyColumnStore(num4);
				arrayList.Add(emptyColumnStore);
				BitArray value = new BitArray(num4);
				arrayList2.Add(value);
			}
		}
		int num5 = 0;
		Hashtable hashtable = new Hashtable();
		Hashtable hashtable2 = new Hashtable();
		for (int k = 0; k < count2; k++)
		{
			int num6 = Rows[k].CopyValuesIntoStore(arrayList, arrayList2, num5);
			GetRowAndColumnErrors(k, hashtable, hashtable2);
			num5 += num6;
		}
		IFormatProvider invariantCulture = CultureInfo.InvariantCulture;
		info.AddValue(string.Format(invariantCulture, "DataTable_{0}.Rows.Count", serIndex), count2);
		info.AddValue(string.Format(invariantCulture, "DataTable_{0}.Records.Count", serIndex), num4);
		info.AddValue(string.Format(invariantCulture, "DataTable_{0}.RowStates", serIndex), bitArray);
		info.AddValue(string.Format(invariantCulture, "DataTable_{0}.Records", serIndex), arrayList);
		info.AddValue(string.Format(invariantCulture, "DataTable_{0}.NullBits", serIndex), arrayList2);
		info.AddValue(string.Format(invariantCulture, "DataTable_{0}.RowErrors", serIndex), hashtable);
		info.AddValue(string.Format(invariantCulture, "DataTable_{0}.ColumnErrors", serIndex), hashtable2);
	}

	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	internal void DeserializeTableData(SerializationInfo info, int serIndex)
	{
		bool enforceConstraints = _enforceConstraints;
		bool inDataLoad = _inDataLoad;
		try
		{
			_enforceConstraints = false;
			_inDataLoad = true;
			IFormatProvider invariantCulture = CultureInfo.InvariantCulture;
			int @int = info.GetInt32(string.Format(invariantCulture, "DataTable_{0}.Rows.Count", serIndex));
			int int2 = info.GetInt32(string.Format(invariantCulture, "DataTable_{0}.Records.Count", serIndex));
			BitArray bitArray = (BitArray)info.GetValue(string.Format(invariantCulture, "DataTable_{0}.RowStates", serIndex), typeof(BitArray));
			ArrayList arrayList = (ArrayList)info.GetValue(string.Format(invariantCulture, "DataTable_{0}.Records", serIndex), typeof(ArrayList));
			ArrayList arrayList2 = (ArrayList)info.GetValue(string.Format(invariantCulture, "DataTable_{0}.NullBits", serIndex), typeof(ArrayList));
			Hashtable hashtable = (Hashtable)info.GetValue(string.Format(invariantCulture, "DataTable_{0}.RowErrors", serIndex), typeof(Hashtable));
			hashtable.OnDeserialization(this);
			Hashtable hashtable2 = (Hashtable)info.GetValue(string.Format(invariantCulture, "DataTable_{0}.ColumnErrors", serIndex), typeof(Hashtable));
			hashtable2.OnDeserialization(this);
			if (int2 <= 0)
			{
				return;
			}
			for (int i = 0; i < Columns.Count; i++)
			{
				Columns[i].SetStorage(arrayList[i], (BitArray)arrayList2[i]);
			}
			int num = 0;
			DataRow[] array = new DataRow[int2];
			for (int j = 0; j < @int; j++)
			{
				DataRow dataRow = (array[num] = NewEmptyRow());
				int num2 = j * 3;
				switch (ConvertToRowState(bitArray, num2))
				{
				case DataRowState.Unchanged:
					dataRow._oldRecord = num;
					dataRow._newRecord = num;
					num++;
					break;
				case DataRowState.Added:
					dataRow._oldRecord = -1;
					dataRow._newRecord = num;
					num++;
					break;
				case DataRowState.Modified:
					dataRow._oldRecord = num;
					dataRow._newRecord = num + 1;
					array[num + 1] = dataRow;
					num += 2;
					break;
				case DataRowState.Deleted:
					dataRow._oldRecord = num;
					dataRow._newRecord = -1;
					num++;
					break;
				}
				if (bitArray[num2 + 2])
				{
					dataRow._tempRecord = num;
					array[num] = dataRow;
					num++;
				}
				else
				{
					dataRow._tempRecord = -1;
				}
				Rows.ArrayAdd(dataRow);
				dataRow.rowID = _nextRowID;
				_nextRowID++;
				ConvertToRowError(j, hashtable, hashtable2);
			}
			_recordManager.SetRowCache(array);
			ResetIndexes();
		}
		finally
		{
			_enforceConstraints = enforceConstraints;
			_inDataLoad = inDataLoad;
		}
	}

	private static DataRowState ConvertToRowState(BitArray bitStates, int bitIndex)
	{
		bool flag = bitStates[bitIndex];
		bool flag2 = bitStates[bitIndex + 1];
		if (!flag && !flag2)
		{
			return DataRowState.Unchanged;
		}
		if (!flag && flag2)
		{
			return DataRowState.Added;
		}
		if (flag && !flag2)
		{
			return DataRowState.Modified;
		}
		if (flag && flag2)
		{
			return DataRowState.Deleted;
		}
		throw ExceptionBuilder.InvalidRowBitPattern();
	}

	internal void GetRowAndColumnErrors(int rowIndex, Hashtable rowErrors, Hashtable colErrors)
	{
		DataRow dataRow = Rows[rowIndex];
		if (!dataRow.HasErrors)
		{
			return;
		}
		rowErrors.Add(rowIndex, dataRow.RowError);
		DataColumn[] columnsInError = dataRow.GetColumnsInError();
		if (columnsInError.Length != 0)
		{
			int[] array = new int[columnsInError.Length];
			string[] array2 = new string[columnsInError.Length];
			for (int i = 0; i < columnsInError.Length; i++)
			{
				array[i] = columnsInError[i].Ordinal;
				array2[i] = dataRow.GetColumnError(columnsInError[i]);
			}
			ArrayList arrayList = new ArrayList();
			arrayList.Add(array);
			arrayList.Add(array2);
			colErrors.Add(rowIndex, arrayList);
		}
	}

	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	private void ConvertToRowError(int rowIndex, Hashtable rowErrors, Hashtable colErrors)
	{
		DataRow dataRow = Rows[rowIndex];
		if (rowErrors.ContainsKey(rowIndex))
		{
			dataRow.RowError = (string)rowErrors[rowIndex];
		}
		if (colErrors.ContainsKey(rowIndex))
		{
			ArrayList obj = (ArrayList)colErrors[rowIndex];
			int[] array = (int[])obj[0];
			string[] array2 = (string[])obj[1];
			for (int i = 0; i < array.Length; i++)
			{
				dataRow.SetColumnError(array[i], array2[i]);
			}
		}
	}

	internal void RestoreIndexEvents(bool forceReset)
	{
		DataCommonEventSource.Log.Trace("<ds.DataTable.RestoreIndexEvents|Info> {0}, {1}", ObjectID, _suspendIndexEvents);
		if (0 >= _suspendIndexEvents)
		{
			return;
		}
		_suspendIndexEvents--;
		if (_suspendIndexEvents != 0)
		{
			return;
		}
		Exception ex = null;
		SetShadowIndexes();
		try
		{
			int count = _shadowIndexes.Count;
			for (int i = 0; i < count; i++)
			{
				Index index = _shadowIndexes[i];
				try
				{
					if (forceReset || index.HasRemoteAggregate)
					{
						index.Reset();
					}
					else
					{
						index.FireResetEvent();
					}
				}
				catch (Exception ex2) when (ADP.IsCatchableExceptionType(ex2))
				{
					ExceptionBuilder.TraceExceptionWithoutRethrow(ex2);
					if (ex2 == null)
					{
						ex = ex2;
					}
				}
			}
			if (ex != null)
			{
				throw ex;
			}
		}
		finally
		{
			RestoreShadowIndexes();
		}
	}

	internal void SuspendIndexEvents()
	{
		DataCommonEventSource.Log.Trace("<ds.DataTable.SuspendIndexEvents|Info> {0}, {1}", ObjectID, _suspendIndexEvents);
		_suspendIndexEvents++;
	}

	internal bool SetCaseSensitiveValue(bool isCaseSensitive, bool userSet, bool resetIndexes)
	{
		if (userSet || (!_caseSensitiveUserSet && _caseSensitive != isCaseSensitive))
		{
			_caseSensitive = isCaseSensitive;
			if (isCaseSensitive)
			{
				_compareFlags = CompareOptions.None;
			}
			else
			{
				_compareFlags = CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth;
			}
			if (resetIndexes)
			{
				ResetIndexes();
				foreach (Constraint constraint in Constraints)
				{
					constraint.CheckConstraint();
				}
			}
			return true;
		}
		return false;
	}

	internal bool ShouldSerializeCaseSensitive()
	{
		return _caseSensitiveUserSet;
	}

	private void ResetConstraints()
	{
		Constraints.Clear();
	}

	internal void SetDataSet(DataSet dataSet)
	{
		if (_dataSet != dataSet)
		{
			_dataSet = dataSet;
			if (DataSet != null)
			{
				_defaultView = null;
			}
			if (dataSet != null)
			{
				_remotingFormat = dataSet.RemotingFormat;
			}
		}
	}

	internal void EnableConstraints()
	{
		bool flag = false;
		foreach (Constraint constraint in Constraints)
		{
			if (constraint is UniqueConstraint)
			{
				flag |= constraint.IsConstraintViolated();
			}
		}
		foreach (DataColumn column in Columns)
		{
			if (!column.AllowDBNull)
			{
				flag |= column.IsNotAllowDBNullViolated();
			}
			if (column.MaxLength >= 0)
			{
				flag |= column.IsMaxLengthViolated();
			}
		}
		if (flag)
		{
			EnforceConstraints = false;
			throw ExceptionBuilder.EnforceConstraint();
		}
	}

	internal bool SetLocaleValue(CultureInfo culture, bool userSet, bool resetIndexes)
	{
		if (userSet || resetIndexes || (!_cultureUserSet && !_culture.Equals(culture)))
		{
			_culture = culture;
			_compareInfo = null;
			_formatProvider = null;
			_hashCodeProvider = null;
			foreach (DataColumn column in Columns)
			{
				column._hashCode = GetSpecialHashCode(column.ColumnName);
			}
			if (resetIndexes)
			{
				ResetIndexes();
				foreach (Constraint constraint in Constraints)
				{
					constraint.CheckConstraint();
				}
			}
			return true;
		}
		return false;
	}

	internal bool ShouldSerializeLocale()
	{
		return _cultureUserSet;
	}

	internal void CacheNestedParent()
	{
		_nestedParentRelations = FindNestedParentRelations();
	}

	private DataRelation[] FindNestedParentRelations()
	{
		List<DataRelation> list = null;
		foreach (DataRelation parentRelation in ParentRelations)
		{
			if (parentRelation.Nested)
			{
				if (list == null)
				{
					list = new List<DataRelation>();
				}
				list.Add(parentRelation);
			}
		}
		if (list != null && list.Count != 0)
		{
			return list.ToArray();
		}
		return Array.Empty<DataRelation>();
	}

	private string GetInheritedNamespace(List<DataTable> visitedTables)
	{
		DataRelation[] nestedParentRelations = NestedParentRelations;
		if (nestedParentRelations.Length != 0)
		{
			foreach (DataRelation dataRelation in nestedParentRelations)
			{
				if (dataRelation.ParentTable._tableNamespace != null)
				{
					return dataRelation.ParentTable._tableNamespace;
				}
			}
			int j;
			for (j = 0; j < nestedParentRelations.Length && (nestedParentRelations[j].ParentTable == this || visitedTables.Contains(nestedParentRelations[j].ParentTable)); j++)
			{
			}
			if (j < nestedParentRelations.Length)
			{
				DataTable parentTable = nestedParentRelations[j].ParentTable;
				if (!visitedTables.Contains(parentTable))
				{
					visitedTables.Add(parentTable);
				}
				return parentTable.GetInheritedNamespace(visitedTables);
			}
		}
		if (DataSet != null)
		{
			return DataSet.Namespace;
		}
		return string.Empty;
	}

	internal bool IsNamespaceInherited()
	{
		return _tableNamespace == null;
	}

	internal void CheckCascadingNamespaceConflict(string realNamespace)
	{
		foreach (DataRelation childRelation in ChildRelations)
		{
			if (childRelation.Nested && childRelation.ChildTable != this && childRelation.ChildTable._tableNamespace == null)
			{
				DataTable childTable = childRelation.ChildTable;
				if (_dataSet.Tables.Contains(childTable.TableName, realNamespace, checkProperty: false, caseSensitive: true))
				{
					throw ExceptionBuilder.DuplicateTableName2(TableName, realNamespace);
				}
				childTable.CheckCascadingNamespaceConflict(realNamespace);
			}
		}
	}

	internal void CheckNamespaceValidityForNestedRelations(string realNamespace)
	{
		foreach (DataRelation childRelation in ChildRelations)
		{
			if (childRelation.Nested)
			{
				if (realNamespace != null)
				{
					childRelation.ChildTable.CheckNamespaceValidityForNestedParentRelations(realNamespace, this);
				}
				else
				{
					childRelation.ChildTable.CheckNamespaceValidityForNestedParentRelations(GetInheritedNamespace(new List<DataTable>()), this);
				}
			}
		}
		if (realNamespace == null)
		{
			CheckNamespaceValidityForNestedParentRelations(GetInheritedNamespace(new List<DataTable>()), this);
		}
	}

	internal void CheckNamespaceValidityForNestedParentRelations(string ns, DataTable parentTable)
	{
		foreach (DataRelation parentRelation in ParentRelations)
		{
			if (parentRelation.Nested && parentRelation.ParentTable != parentTable && parentRelation.ParentTable.Namespace != ns)
			{
				throw ExceptionBuilder.InValidNestedRelation(TableName);
			}
		}
	}

	internal void DoRaiseNamespaceChange()
	{
		RaisePropertyChanging("Namespace");
		foreach (DataColumn column in Columns)
		{
			if (column._columnUri == null)
			{
				column.RaisePropertyChanging("Namespace");
			}
		}
		foreach (DataRelation childRelation in ChildRelations)
		{
			if (childRelation.Nested && childRelation.ChildTable != this)
			{
				childRelation.ChildTable.DoRaiseNamespaceChange();
			}
		}
	}

	internal static void SetKeyValues(DataKey key, object[] keyValues, int record)
	{
		for (int i = 0; i < keyValues.Length; i++)
		{
			key.ColumnsReference[i][record] = keyValues[i];
		}
	}

	internal DataRow FindByIndex(Index ndx, object[] key)
	{
		Range range = ndx.FindRecords(key);
		if (!range.IsNull)
		{
			return _recordManager[ndx.GetRecord(range.Min)];
		}
		return null;
	}

	internal DataRow FindMergeTarget(DataRow row, DataKey key, Index ndx)
	{
		DataRow result = null;
		if (key.HasValue)
		{
			int record = ((row._oldRecord == -1) ? row._newRecord : row._oldRecord);
			object[] keyValues = key.GetKeyValues(record);
			result = FindByIndex(ndx, keyValues);
		}
		return result;
	}

	private void SetMergeRecords(DataRow row, int newRecord, int oldRecord, DataRowAction action)
	{
		if (newRecord != -1)
		{
			SetNewRecord(row, newRecord, action, isInMerge: true);
			SetOldRecord(row, oldRecord);
			return;
		}
		SetOldRecord(row, oldRecord);
		if (row._newRecord != -1)
		{
			SetNewRecord(row, newRecord, action, isInMerge: true);
		}
	}

	internal DataRow MergeRow(DataRow row, DataRow targetRow, bool preserveChanges, Index idxSearch)
	{
		if (targetRow == null)
		{
			targetRow = NewEmptyRow();
			targetRow._oldRecord = _recordManager.ImportRecord(row.Table, row._oldRecord);
			targetRow._newRecord = targetRow._oldRecord;
			if (row._oldRecord != row._newRecord)
			{
				targetRow._newRecord = _recordManager.ImportRecord(row.Table, row._newRecord);
			}
			InsertRow(targetRow, -1L);
		}
		else
		{
			int tempRecord = targetRow._tempRecord;
			targetRow._tempRecord = -1;
			try
			{
				DataRowState rowState = targetRow.RowState;
				int num = ((rowState == DataRowState.Added) ? targetRow._newRecord : targetRow._oldRecord);
				if (targetRow.RowState == DataRowState.Unchanged && row.RowState == DataRowState.Unchanged)
				{
					int oldRecord = targetRow._oldRecord;
					int newRecord = (preserveChanges ? _recordManager.CopyRecord(this, oldRecord, -1) : targetRow._newRecord);
					oldRecord = _recordManager.CopyRecord(row.Table, row._oldRecord, targetRow._oldRecord);
					SetMergeRecords(targetRow, newRecord, oldRecord, DataRowAction.Change);
				}
				else if (row._newRecord == -1)
				{
					int oldRecord = targetRow._oldRecord;
					int newRecord = ((!preserveChanges) ? (-1) : ((targetRow.RowState == DataRowState.Unchanged) ? _recordManager.CopyRecord(this, oldRecord, -1) : targetRow._newRecord));
					oldRecord = _recordManager.CopyRecord(row.Table, row._oldRecord, oldRecord);
					if (num != ((rowState == DataRowState.Added) ? newRecord : oldRecord))
					{
						SetMergeRecords(targetRow, newRecord, oldRecord, (newRecord == -1) ? DataRowAction.Delete : DataRowAction.Change);
						idxSearch.Reset();
						num = ((rowState == DataRowState.Added) ? newRecord : oldRecord);
					}
					else
					{
						SetMergeRecords(targetRow, newRecord, oldRecord, (newRecord == -1) ? DataRowAction.Delete : DataRowAction.Change);
					}
				}
				else
				{
					int oldRecord = targetRow._oldRecord;
					int newRecord = targetRow._newRecord;
					if (targetRow.RowState == DataRowState.Unchanged)
					{
						newRecord = _recordManager.CopyRecord(this, oldRecord, -1);
					}
					oldRecord = _recordManager.CopyRecord(row.Table, row._oldRecord, oldRecord);
					if (!preserveChanges)
					{
						newRecord = _recordManager.CopyRecord(row.Table, row._newRecord, newRecord);
					}
					SetMergeRecords(targetRow, newRecord, oldRecord, DataRowAction.Change);
				}
				if (rowState == DataRowState.Added && targetRow._oldRecord != -1)
				{
					idxSearch.Reset();
				}
			}
			finally
			{
				targetRow._tempRecord = tempRecord;
			}
		}
		if (row.HasErrors)
		{
			if (targetRow.RowError.Length == 0)
			{
				targetRow.RowError = row.RowError;
			}
			else
			{
				DataRow dataRow = targetRow;
				dataRow.RowError = dataRow.RowError + " ]:[ " + row.RowError;
			}
			DataColumn[] columnsInError = row.GetColumnsInError();
			for (int i = 0; i < columnsInError.Length; i++)
			{
				DataColumn column = targetRow.Table.Columns[columnsInError[i].ColumnName];
				targetRow.SetColumnError(column, row.GetColumnError(columnsInError[i]));
			}
		}
		else if (!preserveChanges)
		{
			targetRow.ClearErrors();
		}
		return targetRow;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual DataTable CreateInstance()
	{
		return (DataTable)Activator.CreateInstance(GetType(), nonPublic: true);
	}

	internal DataTable Clone(DataSet cloneDS)
	{
		long scopeId = DataCommonEventSource.Log.EnterScope("<ds.DataTable.Clone|INFO> {0}, cloneDS={1}", ObjectID, cloneDS?.ObjectID ?? 0);
		try
		{
			DataTable dataTable = CreateInstance();
			if (dataTable.Columns.Count > 0)
			{
				dataTable.Reset();
			}
			return CloneTo(dataTable, cloneDS, skipExpressionColumns: false);
		}
		finally
		{
			DataCommonEventSource.Log.ExitScope(scopeId);
		}
	}

	private DataTable CloneTo(DataTable clone, DataSet cloneDS, bool skipExpressionColumns)
	{
		clone._tableName = _tableName;
		clone._tableNamespace = _tableNamespace;
		clone._tablePrefix = _tablePrefix;
		clone._fNestedInDataset = _fNestedInDataset;
		clone._culture = _culture;
		clone._cultureUserSet = _cultureUserSet;
		clone._compareInfo = _compareInfo;
		clone._compareFlags = _compareFlags;
		clone._formatProvider = _formatProvider;
		clone._hashCodeProvider = _hashCodeProvider;
		clone._caseSensitive = _caseSensitive;
		clone._caseSensitiveUserSet = _caseSensitiveUserSet;
		clone._displayExpression = _displayExpression;
		clone._typeName = _typeName;
		clone._repeatableElement = _repeatableElement;
		clone.MinimumCapacity = MinimumCapacity;
		clone.RemotingFormat = RemotingFormat;
		DataColumnCollection columns = Columns;
		for (int i = 0; i < columns.Count; i++)
		{
			clone.Columns.Add(columns[i].Clone());
		}
		if (!skipExpressionColumns && cloneDS == null)
		{
			for (int j = 0; j < columns.Count; j++)
			{
				clone.Columns[columns[j].ColumnName].CopyExpressionFrom(columns[j]);
			}
		}
		DataColumn[] primaryKey = PrimaryKey;
		if (primaryKey.Length != 0)
		{
			DataColumn[] array = new DataColumn[primaryKey.Length];
			for (int k = 0; k < primaryKey.Length; k++)
			{
				array[k] = clone.Columns[primaryKey[k].Ordinal];
			}
			clone.PrimaryKey = array;
		}
		for (int l = 0; l < Constraints.Count; l++)
		{
			ForeignKeyConstraint foreignKeyConstraint = Constraints[l] as ForeignKeyConstraint;
			UniqueConstraint uniqueConstraint = Constraints[l] as UniqueConstraint;
			if (foreignKeyConstraint != null)
			{
				if (foreignKeyConstraint.Table != foreignKeyConstraint.RelatedTable)
				{
					continue;
				}
				ForeignKeyConstraint foreignKeyConstraint2 = foreignKeyConstraint.Clone(clone);
				if (foreignKeyConstraint2 != null)
				{
					Constraint constraint = clone.Constraints.FindConstraint(foreignKeyConstraint2);
					if (constraint != null)
					{
						constraint.ConstraintName = Constraints[l].ConstraintName;
					}
				}
			}
			else
			{
				if (uniqueConstraint == null)
				{
					continue;
				}
				UniqueConstraint uniqueConstraint2 = uniqueConstraint.Clone(clone);
				if (uniqueConstraint2 == null)
				{
					continue;
				}
				Constraint constraint2 = clone.Constraints.FindConstraint(uniqueConstraint2);
				if (constraint2 == null)
				{
					continue;
				}
				constraint2.ConstraintName = Constraints[l].ConstraintName;
				foreach (object key in uniqueConstraint2.ExtendedProperties.Keys)
				{
					constraint2.ExtendedProperties[key] = uniqueConstraint2.ExtendedProperties[key];
				}
			}
		}
		for (int m = 0; m < Constraints.Count; m++)
		{
			if (clone.Constraints.Contains(Constraints[m].ConstraintName, caseSensitive: true))
			{
				continue;
			}
			ForeignKeyConstraint foreignKeyConstraint3 = Constraints[m] as ForeignKeyConstraint;
			UniqueConstraint uniqueConstraint3 = Constraints[m] as UniqueConstraint;
			if (foreignKeyConstraint3 != null)
			{
				if (foreignKeyConstraint3.Table == foreignKeyConstraint3.RelatedTable)
				{
					ForeignKeyConstraint foreignKeyConstraint4 = foreignKeyConstraint3.Clone(clone);
					if (foreignKeyConstraint4 != null)
					{
						clone.Constraints.Add(foreignKeyConstraint4);
					}
				}
			}
			else if (uniqueConstraint3 != null)
			{
				clone.Constraints.Add(uniqueConstraint3.Clone(clone));
			}
		}
		if (_extendedProperties != null)
		{
			foreach (object key2 in _extendedProperties.Keys)
			{
				clone.ExtendedProperties[key2] = _extendedProperties[key2];
			}
		}
		return clone;
	}

	internal void AddRow(DataRow row, int proposedID)
	{
		InsertRow(row, proposedID, -1);
	}

	internal void InsertRow(DataRow row, int proposedID, int pos)
	{
		InsertRow(row, proposedID, pos, fireEvent: true);
	}

	internal void InsertRow(DataRow row, long proposedID, int pos, bool fireEvent)
	{
		if (row == null)
		{
			throw ExceptionBuilder.ArgumentNull("row");
		}
		if (row.Table != this)
		{
			throw ExceptionBuilder.RowAlreadyInOtherCollection();
		}
		if (row.rowID != -1)
		{
			throw ExceptionBuilder.RowAlreadyInTheCollection();
		}
		row.BeginEdit();
		int tempRecord = row._tempRecord;
		row._tempRecord = -1;
		if (proposedID == -1)
		{
			proposedID = _nextRowID;
		}
		bool flag;
		if (flag = _nextRowID <= proposedID)
		{
			_nextRowID = checked(proposedID + 1);
		}
		try
		{
			Exception deferredException;
			try
			{
				row.rowID = proposedID;
				SetNewRecordWorker(row, tempRecord, DataRowAction.Add, isInMerge: false, suppressEnsurePropertyChanged: false, pos, fireEvent, out deferredException);
			}
			catch
			{
				if (flag && _nextRowID == proposedID + 1)
				{
					_nextRowID = proposedID;
				}
				row.rowID = -1L;
				row._tempRecord = tempRecord;
				throw;
			}
			if (deferredException != null)
			{
				throw deferredException;
			}
			if (!EnforceConstraints)
			{
				return;
			}
			int count = _columnCollection.Count;
			for (int i = 0; i < count; i++)
			{
				DataColumn dataColumn = _columnCollection[i];
				if (dataColumn.Computed)
				{
					dataColumn.CheckColumnConstraint(row, DataRowAction.Add);
				}
			}
		}
		finally
		{
			row.ResetLastChangedColumn();
		}
	}

	internal static void CheckNotModifying(DataRow row)
	{
		if (row._tempRecord != -1)
		{
			row.EndEdit();
		}
	}

	public void Clear()
	{
		Clear(clearAll: true);
	}

	internal void Clear(bool clearAll)
	{
		long scopeId = DataCommonEventSource.Log.EnterScope("<ds.DataTable.Clear|INFO> {0}, clearAll={1}", ObjectID, clearAll);
		try
		{
			_rowDiffId = null;
			_dataSet?.OnClearFunctionCalled(this);
			bool flag = Rows.Count != 0;
			DataTableClearEventArgs e = null;
			if (flag)
			{
				e = new DataTableClearEventArgs(this);
				OnTableClearing(e);
			}
			if (_dataSet != null && _dataSet.EnforceConstraints)
			{
				ParentForeignKeyConstraintEnumerator parentForeignKeyConstraintEnumerator = new ParentForeignKeyConstraintEnumerator(_dataSet, this);
				while (parentForeignKeyConstraintEnumerator.GetNext())
				{
					parentForeignKeyConstraintEnumerator.GetForeignKeyConstraint().CheckCanClearParentTable(this);
				}
			}
			_recordManager.Clear(clearAll);
			foreach (DataRow row in Rows)
			{
				row._oldRecord = -1;
				row._newRecord = -1;
				row._tempRecord = -1;
				row.rowID = -1L;
				row.RBTreeNodeId = 0;
			}
			Rows.ArrayClear();
			ResetIndexes();
			if (flag)
			{
				OnTableCleared(e);
			}
			foreach (DataColumn column in Columns)
			{
				EvaluateDependentExpressions(column);
			}
		}
		finally
		{
			DataCommonEventSource.Log.ExitScope(scopeId);
		}
	}

	internal void CascadeAll(DataRow row, DataRowAction action)
	{
		if (_dataSet != null && _dataSet._fEnableCascading)
		{
			ParentForeignKeyConstraintEnumerator parentForeignKeyConstraintEnumerator = new ParentForeignKeyConstraintEnumerator(_dataSet, this);
			while (parentForeignKeyConstraintEnumerator.GetNext())
			{
				parentForeignKeyConstraintEnumerator.GetForeignKeyConstraint().CheckCascade(row, action);
			}
		}
	}

	internal void CommitRow(DataRow row)
	{
		DataRowChangeEventArgs args = OnRowChanging(null, row, DataRowAction.Commit);
		if (!_inDataLoad)
		{
			CascadeAll(row, DataRowAction.Commit);
		}
		SetOldRecord(row, row._newRecord);
		OnRowChanged(args, row, DataRowAction.Commit);
	}

	internal int Compare(string s1, string s2)
	{
		return Compare(s1, s2, null);
	}

	internal int Compare(string s1, string s2, CompareInfo comparer)
	{
		if ((object)s1 == s2)
		{
			return 0;
		}
		if (s1 == null)
		{
			return -1;
		}
		if (s2 == null)
		{
			return 1;
		}
		int num = s1.Length;
		int num2 = s2.Length;
		while (num > 0 && (s1[num - 1] == ' ' || s1[num - 1] == '\u3000'))
		{
			num--;
		}
		while (num2 > 0 && (s2[num2 - 1] == ' ' || s2[num2 - 1] == '\u3000'))
		{
			num2--;
		}
		return (comparer ?? CompareInfo).Compare(s1, 0, num, s2, 0, num2, _compareFlags);
	}

	internal int IndexOf(string s1, string s2)
	{
		return CompareInfo.IndexOf(s1, s2, _compareFlags);
	}

	internal bool IsSuffix(string s1, string s2)
	{
		return CompareInfo.IsSuffix(s1, s2, _compareFlags);
	}

	internal void DeleteRow(DataRow row)
	{
		if (row._newRecord == -1)
		{
			throw ExceptionBuilder.RowAlreadyDeleted();
		}
		SetNewRecord(row, -1, DataRowAction.Delete);
	}

	internal static string FormatSortString(IndexField[] indexDesc)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < indexDesc.Length; i++)
		{
			IndexField indexField = indexDesc[i];
			if (0 < stringBuilder.Length)
			{
				stringBuilder.Append(", ");
			}
			stringBuilder.Append(indexField.Column.ColumnName);
			if (indexField.IsDescending)
			{
				stringBuilder.Append(" DESC");
			}
		}
		return stringBuilder.ToString();
	}

	internal void FreeRecord(ref int record)
	{
		_recordManager.FreeRecord(ref record);
	}

	internal Index GetIndex(string sort, DataViewRowState recordStates, IFilter rowFilter)
	{
		return GetIndex(ParseSortString(sort), recordStates, rowFilter);
	}

	internal Index GetIndex(IndexField[] indexDesc, DataViewRowState recordStates, IFilter rowFilter)
	{
		_indexesLock.EnterUpgradeableReadLock();
		try
		{
			for (int i = 0; i < _indexes.Count; i++)
			{
				Index index = _indexes[i];
				if (index != null && index.Equal(indexDesc, recordStates, rowFilter))
				{
					return index;
				}
			}
		}
		finally
		{
			_indexesLock.ExitUpgradeableReadLock();
		}
		Index index2 = new Index(this, indexDesc, recordStates, rowFilter);
		index2.AddRef();
		return index2;
	}

	internal List<DataViewListener> GetListeners()
	{
		return _dataViewListeners;
	}

	internal int GetSpecialHashCode(string name)
	{
		int i;
		for (i = 0; i < name.Length && '\u3000' > name[i]; i++)
		{
		}
		if (name.Length == i)
		{
			if (_hashCodeProvider == null)
			{
				_hashCodeProvider = StringComparer.Create(Locale, ignoreCase: true);
			}
			return _hashCodeProvider.GetHashCode(name);
		}
		return 0;
	}

	internal void InsertRow(DataRow row, long proposedID)
	{
		long scopeId = DataCommonEventSource.Log.EnterScope("<ds.DataTable.InsertRow|INFO> {0}, row={1}", ObjectID, row._objectID);
		try
		{
			if (row.Table != this)
			{
				throw ExceptionBuilder.RowAlreadyInOtherCollection();
			}
			if (row.rowID != -1)
			{
				throw ExceptionBuilder.RowAlreadyInTheCollection();
			}
			if (row._oldRecord == -1 && row._newRecord == -1)
			{
				throw ExceptionBuilder.RowEmpty();
			}
			if (proposedID == -1)
			{
				proposedID = _nextRowID;
			}
			row.rowID = proposedID;
			if (_nextRowID <= proposedID)
			{
				_nextRowID = checked(proposedID + 1);
			}
			DataRowChangeEventArgs args = null;
			if (row._newRecord != -1)
			{
				row._tempRecord = row._newRecord;
				row._newRecord = -1;
				try
				{
					args = RaiseRowChanging(null, row, DataRowAction.Add, fireEvent: true);
				}
				catch
				{
					row._tempRecord = -1;
					throw;
				}
				row._newRecord = row._tempRecord;
				row._tempRecord = -1;
			}
			if (row._oldRecord != -1)
			{
				_recordManager[row._oldRecord] = row;
			}
			if (row._newRecord != -1)
			{
				_recordManager[row._newRecord] = row;
			}
			Rows.ArrayAdd(row);
			if (row.RowState == DataRowState.Unchanged)
			{
				RecordStateChanged(row._oldRecord, DataViewRowState.None, DataViewRowState.Unchanged);
			}
			else
			{
				RecordStateChanged(row._oldRecord, DataViewRowState.None, row.GetRecordState(row._oldRecord), row._newRecord, DataViewRowState.None, row.GetRecordState(row._newRecord));
			}
			if (_dependentColumns != null && _dependentColumns.Count > 0)
			{
				EvaluateExpressions(row, DataRowAction.Add, null);
			}
			RaiseRowChanged(args, row, DataRowAction.Add);
		}
		finally
		{
			DataCommonEventSource.Log.ExitScope(scopeId);
		}
	}

	internal int NewRecord()
	{
		return NewRecord(-1);
	}

	internal int NewUninitializedRecord()
	{
		return _recordManager.NewRecordBase();
	}

	internal int NewRecord(int sourceRecord)
	{
		int num = _recordManager.NewRecordBase();
		int count = _columnCollection.Count;
		if (-1 == sourceRecord)
		{
			for (int i = 0; i < count; i++)
			{
				_columnCollection[i].Init(num);
			}
		}
		else
		{
			for (int j = 0; j < count; j++)
			{
				_columnCollection[j].Copy(sourceRecord, num);
			}
		}
		return num;
	}

	internal DataRow NewEmptyRow()
	{
		_rowBuilder._record = -1;
		DataRow dataRow = NewRowFromBuilder(_rowBuilder);
		_dataSet?.OnDataRowCreated(dataRow);
		return dataRow;
	}

	private DataRow NewUninitializedRow()
	{
		return NewRow(NewUninitializedRecord());
	}

	public DataRow NewRow()
	{
		DataRow dataRow = NewRow(-1);
		NewRowCreated(dataRow);
		return dataRow;
	}

	internal DataRow CreateEmptyRow()
	{
		DataRow dataRow = NewUninitializedRow();
		foreach (DataColumn column in Columns)
		{
			if (XmlToDatasetMap.IsMappedColumn(column))
			{
				continue;
			}
			if (!column.AutoIncrement)
			{
				if (column.AllowDBNull)
				{
					dataRow[column] = DBNull.Value;
				}
				else if (column.DefaultValue != null)
				{
					dataRow[column] = column.DefaultValue;
				}
			}
			else
			{
				column.Init(dataRow._tempRecord);
			}
		}
		return dataRow;
	}

	private void NewRowCreated(DataRow row)
	{
		if (_onTableNewRowDelegate != null)
		{
			DataTableNewRowEventArgs e = new DataTableNewRowEventArgs(row);
			OnTableNewRow(e);
		}
	}

	internal DataRow NewRow(int record)
	{
		if (-1 == record)
		{
			record = NewRecord(-1);
		}
		_rowBuilder._record = record;
		DataRow dataRow = NewRowFromBuilder(_rowBuilder);
		_recordManager[record] = dataRow;
		_dataSet?.OnDataRowCreated(dataRow);
		return dataRow;
	}

	protected virtual DataRow NewRowFromBuilder(DataRowBuilder builder)
	{
		return new DataRow(builder);
	}

	protected virtual Type GetRowType()
	{
		return typeof(DataRow);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UnconditionalSuppressMessage("AOT analysis", "IL3050:RequiresDynamicCode", Justification = "Array.CreateInstance operates over a reference type making the call safe for AOT")]
	protected internal DataRow[] NewRowArray(int size)
	{
		if (IsTypedDataTable)
		{
			if (size == 0)
			{
				if (_emptyDataRowArray == null)
				{
					_emptyDataRowArray = (DataRow[])Array.CreateInstance(GetRowType(), 0);
				}
				return _emptyDataRowArray;
			}
			return (DataRow[])Array.CreateInstance(GetRowType(), size);
		}
		if (size != 0)
		{
			return new DataRow[size];
		}
		return Array.Empty<DataRow>();
	}

	protected internal virtual void OnColumnChanging(DataColumnChangeEventArgs e)
	{
		if (_onColumnChangingDelegate != null)
		{
			DataCommonEventSource.Log.Trace("<ds.DataTable.OnColumnChanging|INFO> {0}", ObjectID);
			_onColumnChangingDelegate(this, e);
		}
	}

	protected internal virtual void OnColumnChanged(DataColumnChangeEventArgs e)
	{
		if (_onColumnChangedDelegate != null)
		{
			DataCommonEventSource.Log.Trace("<ds.DataTable.OnColumnChanged|INFO> {0}", ObjectID);
			_onColumnChangedDelegate(this, e);
		}
	}

	protected virtual void OnPropertyChanging(PropertyChangedEventArgs pcevent)
	{
		if (_onPropertyChangingDelegate != null)
		{
			DataCommonEventSource.Log.Trace("<ds.DataTable.OnPropertyChanging|INFO> {0}", ObjectID);
			_onPropertyChangingDelegate(this, pcevent);
		}
	}

	internal void OnRemoveColumnInternal(DataColumn column)
	{
		OnRemoveColumn(column);
	}

	protected virtual void OnRemoveColumn(DataColumn column)
	{
	}

	private DataRowChangeEventArgs OnRowChanged(DataRowChangeEventArgs args, DataRow eRow, DataRowAction eAction)
	{
		if (_onRowChangedDelegate != null || IsTypedDataTable)
		{
			if (args == null)
			{
				args = new DataRowChangeEventArgs(eRow, eAction);
			}
			OnRowChanged(args);
		}
		return args;
	}

	private DataRowChangeEventArgs OnRowChanging(DataRowChangeEventArgs args, DataRow eRow, DataRowAction eAction)
	{
		if (_onRowChangingDelegate != null || IsTypedDataTable)
		{
			if (args == null)
			{
				args = new DataRowChangeEventArgs(eRow, eAction);
			}
			OnRowChanging(args);
		}
		return args;
	}

	protected virtual void OnRowChanged(DataRowChangeEventArgs e)
	{
		if (_onRowChangedDelegate != null)
		{
			DataCommonEventSource.Log.Trace("<ds.DataTable.OnRowChanged|INFO> {0}", ObjectID);
			_onRowChangedDelegate(this, e);
		}
	}

	protected virtual void OnRowChanging(DataRowChangeEventArgs e)
	{
		if (_onRowChangingDelegate != null)
		{
			DataCommonEventSource.Log.Trace("<ds.DataTable.OnRowChanging|INFO> {0}", ObjectID);
			_onRowChangingDelegate(this, e);
		}
	}

	protected virtual void OnRowDeleting(DataRowChangeEventArgs e)
	{
		if (_onRowDeletingDelegate != null)
		{
			DataCommonEventSource.Log.Trace("<ds.DataTable.OnRowDeleting|INFO> {0}", ObjectID);
			_onRowDeletingDelegate(this, e);
		}
	}

	protected virtual void OnRowDeleted(DataRowChangeEventArgs e)
	{
		if (_onRowDeletedDelegate != null)
		{
			DataCommonEventSource.Log.Trace("<ds.DataTable.OnRowDeleted|INFO> {0}", ObjectID);
			_onRowDeletedDelegate(this, e);
		}
	}

	protected virtual void OnTableCleared(DataTableClearEventArgs e)
	{
		if (_onTableClearedDelegate != null)
		{
			DataCommonEventSource.Log.Trace("<ds.DataTable.OnTableCleared|INFO> {0}", ObjectID);
			_onTableClearedDelegate(this, e);
		}
	}

	protected virtual void OnTableClearing(DataTableClearEventArgs e)
	{
		if (_onTableClearingDelegate != null)
		{
			DataCommonEventSource.Log.Trace("<ds.DataTable.OnTableClearing|INFO> {0}", ObjectID);
			_onTableClearingDelegate(this, e);
		}
	}

	protected virtual void OnTableNewRow(DataTableNewRowEventArgs e)
	{
		if (_onTableNewRowDelegate != null)
		{
			DataCommonEventSource.Log.Trace("<ds.DataTable.OnTableNewRow|INFO> {0}", ObjectID);
			_onTableNewRowDelegate(this, e);
		}
	}

	internal IndexField[] ParseSortString(string sortString)
	{
		IndexField[] array = Array.Empty<IndexField>();
		if (sortString != null && 0 < sortString.Length)
		{
			string[] array2 = sortString.Split(',', StringSplitOptions.TrimEntries);
			array = new IndexField[array2.Length];
			for (int i = 0; i < array2.Length; i++)
			{
				string text = array2[i];
				int length = text.Length;
				bool isDescending = false;
				if (length >= 5 && string.Compare(text, length - 4, " ASC", 0, 4, StringComparison.OrdinalIgnoreCase) == 0)
				{
					text = text.AsSpan(0, length - 4).Trim().ToString();
				}
				else if (length >= 6 && string.Compare(text, length - 5, " DESC", 0, 5, StringComparison.OrdinalIgnoreCase) == 0)
				{
					isDescending = true;
					text = text.AsSpan(0, length - 5).Trim().ToString();
				}
				if (text.StartsWith('['))
				{
					if (!text.EndsWith(']'))
					{
						throw ExceptionBuilder.InvalidSortString(array2[i]);
					}
					text = text.Substring(1, text.Length - 2);
				}
				DataColumn dataColumn = Columns[text];
				if (dataColumn == null)
				{
					throw ExceptionBuilder.ColumnOutOfRange(text);
				}
				array[i] = new IndexField(dataColumn, isDescending);
			}
		}
		return array;
	}

	internal void RaisePropertyChanging(string name)
	{
		OnPropertyChanging(new PropertyChangedEventArgs(name));
	}

	internal void RecordChanged(int record)
	{
		SetShadowIndexes();
		try
		{
			int count = _shadowIndexes.Count;
			for (int i = 0; i < count; i++)
			{
				Index index = _shadowIndexes[i];
				if (0 < index.RefCount)
				{
					index.RecordChanged(record);
				}
			}
		}
		finally
		{
			RestoreShadowIndexes();
		}
	}

	internal void RecordChanged(int[] oldIndex, int[] newIndex)
	{
		SetShadowIndexes();
		try
		{
			int count = _shadowIndexes.Count;
			for (int i = 0; i < count; i++)
			{
				Index index = _shadowIndexes[i];
				if (0 < index.RefCount)
				{
					index.RecordChanged(oldIndex[i], newIndex[i]);
				}
			}
		}
		finally
		{
			RestoreShadowIndexes();
		}
	}

	internal void RecordStateChanged(int record, DataViewRowState oldState, DataViewRowState newState)
	{
		SetShadowIndexes();
		try
		{
			int count = _shadowIndexes.Count;
			for (int i = 0; i < count; i++)
			{
				Index index = _shadowIndexes[i];
				if (0 < index.RefCount)
				{
					index.RecordStateChanged(record, oldState, newState);
				}
			}
		}
		finally
		{
			RestoreShadowIndexes();
		}
	}

	internal void RecordStateChanged(int record1, DataViewRowState oldState1, DataViewRowState newState1, int record2, DataViewRowState oldState2, DataViewRowState newState2)
	{
		SetShadowIndexes();
		try
		{
			int count = _shadowIndexes.Count;
			for (int i = 0; i < count; i++)
			{
				Index index = _shadowIndexes[i];
				if (0 < index.RefCount)
				{
					if (record1 != -1 && record2 != -1)
					{
						index.RecordStateChanged(record1, oldState1, newState1, record2, oldState2, newState2);
					}
					else if (record1 != -1)
					{
						index.RecordStateChanged(record1, oldState1, newState1);
					}
					else if (record2 != -1)
					{
						index.RecordStateChanged(record2, oldState2, newState2);
					}
				}
			}
		}
		finally
		{
			RestoreShadowIndexes();
		}
	}

	internal int[] RemoveRecordFromIndexes(DataRow row, DataRowVersion version)
	{
		int num = LiveIndexes.Count;
		int[] array = new int[num];
		int recordFromVersion = row.GetRecordFromVersion(version);
		DataViewRowState recordState = row.GetRecordState(recordFromVersion);
		while (--num >= 0)
		{
			if (row.HasVersion(version) && (recordState & _indexes[num].RecordStates) != DataViewRowState.None)
			{
				int index = _indexes[num].GetIndex(recordFromVersion);
				if (index > -1)
				{
					array[num] = index;
					_indexes[num].DeleteRecordFromIndex(index);
				}
				else
				{
					array[num] = -1;
				}
			}
			else
			{
				array[num] = -1;
			}
		}
		return array;
	}

	internal int[] InsertRecordToIndexes(DataRow row, DataRowVersion version)
	{
		int num = LiveIndexes.Count;
		int[] array = new int[num];
		int recordFromVersion = row.GetRecordFromVersion(version);
		DataViewRowState recordState = row.GetRecordState(recordFromVersion);
		while (--num >= 0)
		{
			if (row.HasVersion(version))
			{
				if ((recordState & _indexes[num].RecordStates) != DataViewRowState.None)
				{
					array[num] = _indexes[num].InsertRecordToIndex(recordFromVersion);
				}
				else
				{
					array[num] = -1;
				}
			}
		}
		return array;
	}

	internal static void SilentlySetValue(DataRow dr, DataColumn dc, DataRowVersion version, object newValue)
	{
		int recordFromVersion = dr.GetRecordFromVersion(version);
		if ((DataStorage.IsTypeCustomType(dc.DataType) && newValue != dc[recordFromVersion]) || !dc.CompareValueToChecked(recordFromVersion, newValue))
		{
			int[] oldIndex = dr.Table.RemoveRecordFromIndexes(dr, version);
			dc.SetValue(recordFromVersion, newValue);
			int[] newIndex = dr.Table.InsertRecordToIndexes(dr, version);
			if (dr.HasVersion(version))
			{
				if (version != DataRowVersion.Original)
				{
					dr.Table.RecordChanged(oldIndex, newIndex);
				}
				if (dc._dependentColumns != null)
				{
					dc.Table.EvaluateDependentExpressions(dc._dependentColumns, dr, version, null);
				}
			}
		}
		dr.ResetLastChangedColumn();
	}

	internal void RemoveRow(DataRow row, bool check)
	{
		if (row.rowID == -1)
		{
			throw ExceptionBuilder.RowAlreadyRemoved();
		}
		if (check && _dataSet != null)
		{
			ParentForeignKeyConstraintEnumerator parentForeignKeyConstraintEnumerator = new ParentForeignKeyConstraintEnumerator(_dataSet, this);
			while (parentForeignKeyConstraintEnumerator.GetNext())
			{
				parentForeignKeyConstraintEnumerator.GetForeignKeyConstraint().CheckCanRemoveParentRow(row);
			}
		}
		int record = row._oldRecord;
		int record2 = row._newRecord;
		DataViewRowState recordState = row.GetRecordState(record);
		DataViewRowState recordState2 = row.GetRecordState(record2);
		row._oldRecord = -1;
		row._newRecord = -1;
		if (record == record2)
		{
			record = -1;
		}
		RecordStateChanged(record, recordState, DataViewRowState.None, record2, recordState2, DataViewRowState.None);
		FreeRecord(ref record);
		FreeRecord(ref record2);
		row.rowID = -1L;
		Rows.ArrayRemove(row);
	}

	public virtual void Reset()
	{
		long scopeId = DataCommonEventSource.Log.EnterScope("<ds.DataTable.Reset|API> {0}", ObjectID);
		try
		{
			Clear();
			ResetConstraints();
			DataRelationCollection parentRelations = ParentRelations;
			int num = parentRelations.Count;
			while (num > 0)
			{
				num--;
				parentRelations.RemoveAt(num);
			}
			parentRelations = ChildRelations;
			num = parentRelations.Count;
			while (num > 0)
			{
				num--;
				parentRelations.RemoveAt(num);
			}
			Columns.Clear();
			_indexes.Clear();
		}
		finally
		{
			DataCommonEventSource.Log.ExitScope(scopeId);
		}
	}

	internal void ResetIndexes()
	{
		ResetInternalIndexes(null);
	}

	internal void ResetInternalIndexes(DataColumn column)
	{
		SetShadowIndexes();
		try
		{
			int count = _shadowIndexes.Count;
			for (int i = 0; i < count; i++)
			{
				Index index = _shadowIndexes[i];
				if (0 >= index.RefCount)
				{
					continue;
				}
				if (column == null)
				{
					index.Reset();
					continue;
				}
				bool flag = false;
				IndexField[] indexFields = index._indexFields;
				for (int j = 0; j < indexFields.Length; j++)
				{
					IndexField indexField = indexFields[j];
					if (column == indexField.Column)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					index.Reset();
				}
			}
		}
		finally
		{
			RestoreShadowIndexes();
		}
	}

	internal void RollbackRow(DataRow row)
	{
		row.CancelEdit();
		SetNewRecord(row, row._oldRecord, DataRowAction.Rollback);
	}

	private DataRowChangeEventArgs RaiseRowChanged(DataRowChangeEventArgs args, DataRow eRow, DataRowAction eAction)
	{
		try
		{
			if (UpdatingCurrent(eAction) && (IsTypedDataTable || _onRowChangedDelegate != null))
			{
				args = OnRowChanged(args, eRow, eAction);
			}
			else if (DataRowAction.Delete == eAction && eRow._newRecord == -1 && (IsTypedDataTable || _onRowDeletedDelegate != null))
			{
				if (args == null)
				{
					args = new DataRowChangeEventArgs(eRow, eAction);
				}
				OnRowDeleted(args);
			}
		}
		catch (Exception e) when (ADP.IsCatchableExceptionType(e))
		{
			ExceptionBuilder.TraceExceptionWithoutRethrow(e);
		}
		return args;
	}

	private DataRowChangeEventArgs RaiseRowChanging(DataRowChangeEventArgs args, DataRow eRow, DataRowAction eAction)
	{
		if (UpdatingCurrent(eAction) && (IsTypedDataTable || _onRowChangingDelegate != null))
		{
			eRow._inChangingEvent = true;
			try
			{
				args = OnRowChanging(args, eRow, eAction);
			}
			finally
			{
				eRow._inChangingEvent = false;
			}
		}
		else if (DataRowAction.Delete == eAction && eRow._newRecord != -1 && (IsTypedDataTable || _onRowDeletingDelegate != null))
		{
			eRow._inDeletingEvent = true;
			try
			{
				if (args == null)
				{
					args = new DataRowChangeEventArgs(eRow, eAction);
				}
				OnRowDeleting(args);
			}
			finally
			{
				eRow._inDeletingEvent = false;
			}
		}
		return args;
	}

	private DataRowChangeEventArgs RaiseRowChanging(DataRowChangeEventArgs args, DataRow eRow, DataRowAction eAction, bool fireEvent)
	{
		if (EnforceConstraints)
		{
			int count = _columnCollection.Count;
			for (int i = 0; i < count; i++)
			{
				DataColumn dataColumn = _columnCollection[i];
				if (!dataColumn.Computed || eAction != DataRowAction.Add)
				{
					dataColumn.CheckColumnConstraint(eRow, eAction);
				}
			}
			int count2 = _constraintCollection.Count;
			for (int j = 0; j < count2; j++)
			{
				_constraintCollection[j].CheckConstraint(eRow, eAction);
			}
		}
		if (fireEvent)
		{
			args = RaiseRowChanging(args, eRow, eAction);
		}
		if (!_inDataLoad && !MergingData && eAction != DataRowAction.Nothing && eAction != DataRowAction.ChangeOriginal)
		{
			CascadeAll(eRow, eAction);
		}
		return args;
	}

	internal void SetNewRecord(DataRow row, int proposedRecord, DataRowAction action = DataRowAction.Change, bool isInMerge = false, bool fireEvent = true, bool suppressEnsurePropertyChanged = false)
	{
		SetNewRecordWorker(row, proposedRecord, action, isInMerge, suppressEnsurePropertyChanged, -1, fireEvent, out var deferredException);
		if (deferredException != null)
		{
			throw deferredException;
		}
	}

	private void SetNewRecordWorker(DataRow row, int proposedRecord, DataRowAction action, bool isInMerge, bool suppressEnsurePropertyChanged, int position, bool fireEvent, out Exception deferredException)
	{
		deferredException = null;
		if (row._tempRecord != proposedRecord)
		{
			if (!_inDataLoad)
			{
				row.CheckInTable();
				CheckNotModifying(row);
			}
			if (proposedRecord == row._newRecord)
			{
				if (isInMerge)
				{
					RaiseRowChanged(null, row, action);
				}
				return;
			}
			row._tempRecord = proposedRecord;
		}
		DataRowChangeEventArgs args = null;
		try
		{
			row._action = action;
			args = RaiseRowChanging(null, row, action, fireEvent);
		}
		catch
		{
			row._tempRecord = -1;
			throw;
		}
		finally
		{
			row._action = DataRowAction.Nothing;
		}
		row._tempRecord = -1;
		int record = row._newRecord;
		int num = ((proposedRecord != -1) ? proposedRecord : ((row.RowState != DataRowState.Unchanged) ? row._oldRecord : (-1)));
		if (action == DataRowAction.Add)
		{
			if (position == -1)
			{
				Rows.ArrayAdd(row);
			}
			else
			{
				Rows.ArrayInsert(row, position);
			}
		}
		List<DataRow> list = null;
		if ((action == DataRowAction.Delete || action == DataRowAction.Change) && _dependentColumns != null && _dependentColumns.Count > 0)
		{
			list = new List<DataRow>();
			for (int i = 0; i < ParentRelations.Count; i++)
			{
				DataRelation dataRelation = ParentRelations[i];
				if (dataRelation.ChildTable == row.Table)
				{
					list.InsertRange(list.Count, row.GetParentRows(dataRelation));
				}
			}
			for (int j = 0; j < ChildRelations.Count; j++)
			{
				DataRelation dataRelation2 = ChildRelations[j];
				if (dataRelation2.ParentTable == row.Table)
				{
					list.InsertRange(list.Count, row.GetChildRows(dataRelation2));
				}
			}
		}
		if (!suppressEnsurePropertyChanged && !row.HasPropertyChanged && row._newRecord != proposedRecord && -1 != proposedRecord && -1 != row._newRecord)
		{
			row.LastChangedColumn = null;
			row.LastChangedColumn = null;
		}
		if (LiveIndexes.Count != 0)
		{
			if (-1 == record && -1 != proposedRecord && -1 != row._oldRecord && proposedRecord != row._oldRecord)
			{
				record = row._oldRecord;
			}
			DataViewRowState recordState = row.GetRecordState(record);
			DataViewRowState recordState2 = row.GetRecordState(num);
			row._newRecord = proposedRecord;
			if (proposedRecord != -1)
			{
				_recordManager[proposedRecord] = row;
			}
			DataViewRowState recordState3 = row.GetRecordState(record);
			DataViewRowState recordState4 = row.GetRecordState(num);
			RecordStateChanged(record, recordState, recordState3, num, recordState2, recordState4);
		}
		else
		{
			row._newRecord = proposedRecord;
			if (proposedRecord != -1)
			{
				_recordManager[proposedRecord] = row;
			}
		}
		row.ResetLastChangedColumn();
		if (-1 != record && record != row._oldRecord && record != row._tempRecord && record != row._newRecord && row == _recordManager[record])
		{
			FreeRecord(ref record);
		}
		if (row.RowState == DataRowState.Detached && row.rowID != -1)
		{
			RemoveRow(row, check: false);
		}
		if (_dependentColumns != null && _dependentColumns.Count > 0)
		{
			try
			{
				EvaluateExpressions(row, action, list);
			}
			catch (Exception ex)
			{
				if (action != DataRowAction.Add)
				{
					throw;
				}
				deferredException = ex;
			}
		}
		try
		{
			if (fireEvent)
			{
				RaiseRowChanged(args, row, action);
			}
		}
		catch (Exception e) when (ADP.IsCatchableExceptionType(e))
		{
			ExceptionBuilder.TraceExceptionWithoutRethrow(e);
		}
	}

	internal void SetOldRecord(DataRow row, int proposedRecord)
	{
		if (!_inDataLoad)
		{
			row.CheckInTable();
			CheckNotModifying(row);
		}
		if (proposedRecord == row._oldRecord)
		{
			return;
		}
		int record = row._oldRecord;
		try
		{
			if (LiveIndexes.Count != 0)
			{
				if (-1 == record && -1 != proposedRecord && -1 != row._newRecord && proposedRecord != row._newRecord)
				{
					record = row._newRecord;
				}
				DataViewRowState recordState = row.GetRecordState(record);
				DataViewRowState recordState2 = row.GetRecordState(proposedRecord);
				row._oldRecord = proposedRecord;
				if (proposedRecord != -1)
				{
					_recordManager[proposedRecord] = row;
				}
				DataViewRowState recordState3 = row.GetRecordState(record);
				DataViewRowState recordState4 = row.GetRecordState(proposedRecord);
				RecordStateChanged(record, recordState, recordState3, proposedRecord, recordState2, recordState4);
			}
			else
			{
				row._oldRecord = proposedRecord;
				if (proposedRecord != -1)
				{
					_recordManager[proposedRecord] = row;
				}
			}
		}
		finally
		{
			if (record != -1 && record != row._tempRecord && record != row._oldRecord && record != row._newRecord)
			{
				FreeRecord(ref record);
			}
			if (row.RowState == DataRowState.Detached && row.rowID != -1)
			{
				RemoveRow(row, check: false);
			}
		}
	}

	private void RestoreShadowIndexes()
	{
		_shadowCount--;
		if (_shadowCount == 0)
		{
			_shadowIndexes = null;
		}
	}

	private void SetShadowIndexes()
	{
		if (_shadowIndexes == null)
		{
			_shadowIndexes = LiveIndexes;
			_shadowCount = 1;
		}
		else
		{
			_shadowCount++;
		}
	}

	internal void ShadowIndexCopy()
	{
		if (_shadowIndexes == _indexes)
		{
			_shadowIndexes = new List<Index>(_indexes);
		}
	}

	public override string ToString()
	{
		if (_displayExpression != null)
		{
			return TableName + " + " + DisplayExpressionInternal;
		}
		return TableName;
	}

	internal static bool UpdatingCurrent(DataRowAction action)
	{
		if (action != DataRowAction.Add && action != DataRowAction.Change && action != DataRowAction.Rollback && action != DataRowAction.ChangeOriginal)
		{
			return action == DataRowAction.ChangeCurrentAndOriginal;
		}
		return true;
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "DataColumn with null expression and int data type is safe.")]
	internal DataColumn AddUniqueKey(int position)
	{
		if (_colUnique != null)
		{
			return _colUnique;
		}
		DataColumn[] primaryKey = PrimaryKey;
		if (primaryKey.Length == 1)
		{
			return primaryKey[0];
		}
		DataColumn dataColumn = new DataColumn(XMLSchema.GenUniqueColumnName(TableName + "_Id", this), typeof(int), null, MappingType.Hidden);
		dataColumn.Prefix = _tablePrefix;
		dataColumn.AutoIncrement = true;
		dataColumn.AllowDBNull = false;
		dataColumn.Unique = true;
		if (position == -1)
		{
			Columns.Add(dataColumn);
		}
		else
		{
			for (int num = Columns.Count - 1; num >= position; num--)
			{
				Columns[num].SetOrdinalInternal(num + 1);
			}
			Columns.AddAt(position, dataColumn);
			dataColumn.SetOrdinalInternal(position);
		}
		if (primaryKey.Length == 0)
		{
			PrimaryKey = new DataColumn[1] { dataColumn };
		}
		_colUnique = dataColumn;
		return _colUnique;
	}

	internal DataColumn AddUniqueKey()
	{
		return AddUniqueKey(-1);
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Expression is null and potential problem with data type has already been reported when constructing parentKey")]
	internal DataColumn AddForeignKey(DataColumn parentKey)
	{
		DataColumn dataColumn = new DataColumn(XMLSchema.GenUniqueColumnName(parentKey.ColumnName, this), parentKey.DataType, null, MappingType.Hidden);
		Columns.Add(dataColumn);
		return dataColumn;
	}

	internal void UpdatePropertyDescriptorCollectionCache()
	{
		_propertyDescriptorCollectionCache = null;
	}

	internal PropertyDescriptorCollection GetPropertyDescriptorCollection()
	{
		if (_propertyDescriptorCollectionCache == null)
		{
			int count = Columns.Count;
			int count2 = ChildRelations.Count;
			PropertyDescriptor[] array = new PropertyDescriptor[count + count2];
			for (int i = 0; i < count; i++)
			{
				array[i] = new DataColumnPropertyDescriptor(Columns[i]);
			}
			for (int j = 0; j < count2; j++)
			{
				array[count + j] = new DataRelationPropertyDescriptor(ChildRelations[j]);
			}
			_propertyDescriptorCollectionCache = new PropertyDescriptorCollection(array);
		}
		return _propertyDescriptorCollectionCache;
	}

	private static bool CheckForClosureOnExpressionTables(List<DataTable> tableList)
	{
		foreach (DataTable table in tableList)
		{
			foreach (DataColumn column in table.Columns)
			{
				if (column.Expression.Length == 0)
				{
					continue;
				}
				DataColumn[] dependency = column.DataExpression.GetDependency();
				for (int i = 0; i < dependency.Length; i++)
				{
					if (!tableList.Contains(dependency[i].Table))
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	internal static void ReadEndElement(XmlReader reader)
	{
		while (reader.NodeType == XmlNodeType.Whitespace)
		{
			reader.Skip();
		}
		if (reader.NodeType == XmlNodeType.None)
		{
			reader.Skip();
		}
		else if (reader.NodeType == XmlNodeType.EndElement)
		{
			reader.ReadEndElement();
		}
	}

	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	[RequiresDynamicCode("Members from serialized types may use dynamic code generation.")]
	internal void ReadXSDSchema(XmlReader reader)
	{
		XmlSchemaSet xmlSchemaSet = new XmlSchemaSet();
		while (reader.LocalName == "schema" && reader.NamespaceURI == "http://www.w3.org/2001/XMLSchema")
		{
			XmlSchema schema = XmlSchema.Read(reader, null);
			xmlSchemaSet.Add(schema);
			ReadEndElement(reader);
		}
		xmlSchemaSet.Compile();
		new XSDSchema().LoadSchema(xmlSchemaSet, this);
	}

	public static XmlSchemaComplexType GetDataTableSchema(XmlSchemaSet? schemaSet)
	{
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny item = new XmlSchemaAny
		{
			Namespace = "http://www.w3.org/2001/XMLSchema",
			MinOccurs = 0m,
			MaxOccurs = decimal.MaxValue,
			ProcessContents = XmlSchemaContentProcessing.Lax
		};
		xmlSchemaSequence.Items.Add(item);
		item = new XmlSchemaAny
		{
			Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
			MinOccurs = 1m,
			ProcessContents = XmlSchemaContentProcessing.Lax
		};
		xmlSchemaSequence.Items.Add(item);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		return xmlSchemaComplexType;
	}

	XmlSchema IXmlSerializable.GetSchema()
	{
		_ = 0;
		throw new NotSupportedException("DataSet_XmlSerializationUnsupported");
	}

	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	[RequiresDynamicCode("Members from serialized types may use dynamic code generation.")]
	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2046:UnrecognizedReflectionPattern", Justification = "https://github.com/mono/linker/issues/1187 Trimmer thinks this implements IXmlSerializable.GetSchema() and warns about not matching attributes.")]
	protected virtual XmlSchema? GetSchema()
	{
		if (GetType() == typeof(DataTable))
		{
			return null;
		}
		MemoryStream memoryStream = new MemoryStream();
		XmlWriter xw = new XmlTextWriter(memoryStream, null);
		new XmlTreeGen(SchemaFormat.WebService).Save(this, xw);
		memoryStream.Position = 0L;
		return XmlSchema.Read(new XmlTextReader(memoryStream), null);
	}

	void IXmlSerializable.ReadXml(XmlReader reader)
	{
		_ = 0;
		throw new NotSupportedException("DataSet_XmlSerializationUnsupported");
	}

	void IXmlSerializable.WriteXml(XmlWriter writer)
	{
		_ = 0;
		throw new NotSupportedException("DataSet_XmlSerializationUnsupported");
	}

	internal void AddDependentColumn(DataColumn expressionColumn)
	{
		if (_dependentColumns == null)
		{
			_dependentColumns = new List<DataColumn>();
		}
		if (!_dependentColumns.Contains(expressionColumn))
		{
			_dependentColumns.Add(expressionColumn);
		}
	}

	internal void RemoveDependentColumn(DataColumn expressionColumn)
	{
		if (_dependentColumns != null && _dependentColumns.Contains(expressionColumn))
		{
			_dependentColumns.Remove(expressionColumn);
		}
	}

	internal void EvaluateExpressions()
	{
		if (_dependentColumns == null || 0 >= _dependentColumns.Count)
		{
			return;
		}
		foreach (DataRow row in Rows)
		{
			if (row._oldRecord != -1 && row._oldRecord != row._newRecord)
			{
				EvaluateDependentExpressions(_dependentColumns, row, DataRowVersion.Original, null);
			}
			if (row._newRecord != -1)
			{
				EvaluateDependentExpressions(_dependentColumns, row, DataRowVersion.Current, null);
			}
			if (row._tempRecord != -1)
			{
				EvaluateDependentExpressions(_dependentColumns, row, DataRowVersion.Proposed, null);
			}
		}
	}

	internal void EvaluateExpressions(DataRow row, DataRowAction action, List<DataRow> cachedRows)
	{
		if (action == DataRowAction.Add || action == DataRowAction.Change || (action == DataRowAction.Rollback && (row._oldRecord != -1 || row._newRecord != -1)))
		{
			if (row._oldRecord != -1 && row._oldRecord != row._newRecord)
			{
				EvaluateDependentExpressions(_dependentColumns, row, DataRowVersion.Original, cachedRows);
			}
			if (row._newRecord != -1)
			{
				EvaluateDependentExpressions(_dependentColumns, row, DataRowVersion.Current, cachedRows);
			}
			if (row._tempRecord != -1)
			{
				EvaluateDependentExpressions(_dependentColumns, row, DataRowVersion.Proposed, cachedRows);
			}
			return;
		}
		switch (action)
		{
		case DataRowAction.Rollback:
			if (row._oldRecord != -1 || row._newRecord != -1)
			{
				break;
			}
			goto case DataRowAction.Delete;
		case DataRowAction.Delete:
			if (_dependentColumns == null)
			{
				break;
			}
			foreach (DataColumn dependentColumn in _dependentColumns)
			{
				if (dependentColumn.DataExpression == null || !dependentColumn.DataExpression.HasLocalAggregate() || dependentColumn.Table != this)
				{
					continue;
				}
				for (int i = 0; i < Rows.Count; i++)
				{
					DataRow dataRow = Rows[i];
					if (dataRow._oldRecord != -1 && dataRow._oldRecord != dataRow._newRecord)
					{
						EvaluateDependentExpressions(_dependentColumns, dataRow, DataRowVersion.Original, null);
					}
				}
				for (int j = 0; j < Rows.Count; j++)
				{
					DataRow dataRow2 = Rows[j];
					if (dataRow2._tempRecord != -1)
					{
						EvaluateDependentExpressions(_dependentColumns, dataRow2, DataRowVersion.Proposed, null);
					}
				}
				for (int k = 0; k < Rows.Count; k++)
				{
					DataRow dataRow3 = Rows[k];
					if (dataRow3._newRecord != -1)
					{
						EvaluateDependentExpressions(_dependentColumns, dataRow3, DataRowVersion.Current, null);
					}
				}
				break;
			}
			if (cachedRows == null)
			{
				break;
			}
			{
				foreach (DataRow cachedRow in cachedRows)
				{
					if (cachedRow._oldRecord != -1 && cachedRow._oldRecord != cachedRow._newRecord)
					{
						cachedRow.Table.EvaluateDependentExpressions(cachedRow.Table._dependentColumns, cachedRow, DataRowVersion.Original, null);
					}
					if (cachedRow._newRecord != -1)
					{
						cachedRow.Table.EvaluateDependentExpressions(cachedRow.Table._dependentColumns, cachedRow, DataRowVersion.Current, null);
					}
					if (cachedRow._tempRecord != -1)
					{
						cachedRow.Table.EvaluateDependentExpressions(cachedRow.Table._dependentColumns, cachedRow, DataRowVersion.Proposed, null);
					}
				}
				break;
			}
		}
	}

	internal void EvaluateExpressions(DataColumn column)
	{
		int count = column._table.Rows.Count;
		if (column.DataExpression.IsTableAggregate() && count > 0)
		{
			object value = column.DataExpression.Evaluate();
			for (int i = 0; i < count; i++)
			{
				DataRow dataRow = column._table.Rows[i];
				if (dataRow._oldRecord != -1 && dataRow._oldRecord != dataRow._newRecord)
				{
					column[dataRow._oldRecord] = value;
				}
				if (dataRow._newRecord != -1)
				{
					column[dataRow._newRecord] = value;
				}
				if (dataRow._tempRecord != -1)
				{
					column[dataRow._tempRecord] = value;
				}
			}
		}
		else
		{
			for (int j = 0; j < count; j++)
			{
				DataRow dataRow2 = column._table.Rows[j];
				if (dataRow2._oldRecord != -1 && dataRow2._oldRecord != dataRow2._newRecord)
				{
					column[dataRow2._oldRecord] = column.DataExpression.Evaluate(dataRow2, DataRowVersion.Original);
				}
				if (dataRow2._newRecord != -1)
				{
					column[dataRow2._newRecord] = column.DataExpression.Evaluate(dataRow2, DataRowVersion.Current);
				}
				if (dataRow2._tempRecord != -1)
				{
					column[dataRow2._tempRecord] = column.DataExpression.Evaluate(dataRow2, DataRowVersion.Proposed);
				}
			}
		}
		column._table.ResetInternalIndexes(column);
		EvaluateDependentExpressions(column);
	}

	internal void EvaluateDependentExpressions(DataColumn column)
	{
		if (column._dependentColumns == null)
		{
			return;
		}
		foreach (DataColumn dependentColumn in column._dependentColumns)
		{
			if (dependentColumn._table != null && column != dependentColumn)
			{
				EvaluateExpressions(dependentColumn);
			}
		}
	}

	internal void EvaluateDependentExpressions(List<DataColumn> columns, DataRow row, DataRowVersion version, List<DataRow> cachedRows)
	{
		if (columns == null)
		{
			return;
		}
		int count = columns.Count;
		for (int i = 0; i < count; i++)
		{
			if (columns[i].Table != this)
			{
				continue;
			}
			DataColumn dataColumn = columns[i];
			if (dataColumn.DataExpression != null && dataColumn.DataExpression.HasLocalAggregate())
			{
				DataRowVersion dataRowVersion = ((version == DataRowVersion.Proposed) ? DataRowVersion.Default : version);
				bool flag = dataColumn.DataExpression.IsTableAggregate();
				object newValue = null;
				if (flag)
				{
					newValue = dataColumn.DataExpression.Evaluate(row, dataRowVersion);
				}
				for (int j = 0; j < Rows.Count; j++)
				{
					DataRow dataRow = Rows[j];
					if (dataRow.RowState != DataRowState.Deleted && (dataRowVersion != DataRowVersion.Original || (dataRow._oldRecord != -1 && dataRow._oldRecord != dataRow._newRecord)))
					{
						if (!flag)
						{
							newValue = dataColumn.DataExpression.Evaluate(dataRow, dataRowVersion);
						}
						SilentlySetValue(dataRow, dataColumn, dataRowVersion, newValue);
					}
				}
			}
			else if (row.RowState != DataRowState.Deleted && (version != DataRowVersion.Original || (row._oldRecord != -1 && row._oldRecord != row._newRecord)))
			{
				SilentlySetValue(row, dataColumn, version, (dataColumn.DataExpression == null) ? dataColumn.DefaultValue : dataColumn.DataExpression.Evaluate(row, version));
			}
		}
		count = columns.Count;
		for (int k = 0; k < count; k++)
		{
			DataColumn dataColumn2 = columns[k];
			if (dataColumn2.Table == this && (dataColumn2.DataExpression == null || dataColumn2.DataExpression.HasLocalAggregate()))
			{
				continue;
			}
			DataRowVersion dataRowVersion2 = ((version == DataRowVersion.Proposed) ? DataRowVersion.Default : version);
			if (cachedRows != null)
			{
				foreach (DataRow cachedRow in cachedRows)
				{
					if (cachedRow.Table == dataColumn2.Table && (dataRowVersion2 != DataRowVersion.Original || cachedRow._newRecord != cachedRow._oldRecord) && cachedRow != null && cachedRow.RowState != DataRowState.Deleted && (version != DataRowVersion.Original || cachedRow._oldRecord != -1))
					{
						object newValue2 = dataColumn2.DataExpression.Evaluate(cachedRow, dataRowVersion2);
						SilentlySetValue(cachedRow, dataColumn2, dataRowVersion2, newValue2);
					}
				}
			}
			for (int l = 0; l < ParentRelations.Count; l++)
			{
				DataRelation dataRelation = ParentRelations[l];
				if (dataRelation.ParentTable != dataColumn2.Table)
				{
					continue;
				}
				DataRow[] parentRows = row.GetParentRows(dataRelation, version);
				foreach (DataRow dataRow2 in parentRows)
				{
					if ((cachedRows == null || !cachedRows.Contains(dataRow2)) && (dataRowVersion2 != DataRowVersion.Original || dataRow2._newRecord != dataRow2._oldRecord) && dataRow2 != null && dataRow2.RowState != DataRowState.Deleted && (version != DataRowVersion.Original || dataRow2._oldRecord != -1))
					{
						object newValue3 = dataColumn2.DataExpression.Evaluate(dataRow2, dataRowVersion2);
						SilentlySetValue(dataRow2, dataColumn2, dataRowVersion2, newValue3);
					}
				}
			}
			for (int n = 0; n < ChildRelations.Count; n++)
			{
				DataRelation dataRelation2 = ChildRelations[n];
				if (dataRelation2.ChildTable != dataColumn2.Table)
				{
					continue;
				}
				DataRow[] parentRows = row.GetChildRows(dataRelation2, version);
				foreach (DataRow dataRow3 in parentRows)
				{
					if ((cachedRows == null || !cachedRows.Contains(dataRow3)) && (dataRowVersion2 != DataRowVersion.Original || dataRow3._newRecord != dataRow3._oldRecord) && dataRow3 != null && dataRow3.RowState != DataRowState.Deleted && (version != DataRowVersion.Original || dataRow3._oldRecord != -1))
					{
						object newValue4 = dataColumn2.DataExpression.Evaluate(dataRow3, dataRowVersion2);
						SilentlySetValue(dataRow3, dataColumn2, dataRowVersion2, newValue4);
					}
				}
			}
		}
	}
}
