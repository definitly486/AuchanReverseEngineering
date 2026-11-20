using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace System.Data;

[Serializable]
[Designer("Microsoft.VSDesigner.Data.VS.DataSetDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[DefaultProperty("DataSetName")]
[ToolboxItem("Microsoft.VSDesigner.Data.VS.DataSetToolboxItem, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[XmlSchemaProvider("GetDataSetSchema")]
[XmlRoot("DataSet")]
[TypeForwardedFrom("System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
public class DataSet : MarshalByValueComponent, IXmlSerializable, ISerializable
{
	private DataViewManager _defaultViewManager;

	private readonly DataTableCollection _tableCollection;

	private readonly DataRelationCollection _relationCollection;

	internal PropertyCollection _extendedProperties;

	private string _dataSetName = "NewDataSet";

	private string _datasetPrefix = string.Empty;

	internal string _namespaceURI = string.Empty;

	private bool _enforceConstraints = true;

	private bool _caseSensitive;

	private CultureInfo _culture;

	private bool _cultureUserSet;

	internal bool _fInReadXml;

	internal bool _fInLoadDiffgram;

	internal bool _fTopLevelTable;

	internal bool _fInitInProgress;

	internal bool _fEnableCascading = true;

	internal bool _fIsSchemaLoading;

	internal string _mainTableName = string.Empty;

	private SerializationFormat _remotingFormat;

	private readonly object _defaultViewManagerLock = new object();

	private static int s_objectTypeCount;

	private readonly int _objectID = Interlocked.Increment(ref s_objectTypeCount);

	private static XmlSchemaComplexType s_schemaTypeForWSDL;

	internal bool _useDataSetSchemaOnly;

	internal bool _udtIsWrapped;

	[CompilerGenerated]
	private PropertyChangedEventHandler PropertyChanging;

	[CompilerGenerated]
	private MergeFailedEventHandler MergeFailed;

	[CompilerGenerated]
	private DataRowCreatedEventHandler DataRowCreated;

	[CompilerGenerated]
	private DataSetClearEventhandler ClearFunctionCalled;

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
			_remotingFormat = value;
			for (int i = 0; i < Tables.Count; i++)
			{
				Tables[i].RemotingFormat = value;
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual SchemaSerializationMode SchemaSerializationMode
	{
		get
		{
			return SchemaSerializationMode.IncludeSchema;
		}
		set
		{
			if (value != SchemaSerializationMode.IncludeSchema)
			{
				throw ExceptionBuilder.CannotChangeSchemaSerializationMode();
			}
		}
	}

	[DefaultValue(false)]
	public bool CaseSensitive
	{
		get
		{
			return _caseSensitive;
		}
		set
		{
			if (_caseSensitive == value)
			{
				return;
			}
			bool caseSensitive = _caseSensitive;
			_caseSensitive = value;
			if (!ValidateCaseConstraint())
			{
				_caseSensitive = caseSensitive;
				throw ExceptionBuilder.CannotChangeCaseLocale();
			}
			foreach (DataTable table in Tables)
			{
				table.SetCaseSensitiveValue(value, userSet: false, resetIndexes: true);
			}
		}
	}

	[Browsable(false)]
	public DataViewManager DefaultViewManager
	{
		get
		{
			if (_defaultViewManager == null)
			{
				lock (_defaultViewManagerLock)
				{
					if (_defaultViewManager == null)
					{
						_defaultViewManager = new DataViewManager(this, locked: true);
					}
				}
			}
			return _defaultViewManager;
		}
	}

	[DefaultValue(true)]
	public bool EnforceConstraints
	{
		get
		{
			return _enforceConstraints;
		}
		set
		{
			long scopeId = DataCommonEventSource.Log.EnterScope("<ds.DataSet.set_EnforceConstraints|API> {0}, {1}", ObjectID, value);
			try
			{
				if (_enforceConstraints != value)
				{
					if (value)
					{
						EnableConstraints();
					}
					_enforceConstraints = value;
				}
			}
			finally
			{
				DataCommonEventSource.Log.ExitScope(scopeId);
			}
		}
	}

	[DefaultValue("")]
	public string DataSetName
	{
		get
		{
			return _dataSetName;
		}
		set
		{
			DataCommonEventSource.Log.Trace("<ds.DataSet.set_DataSetName|API> {0}, '{1}'", ObjectID, value);
			if (value != _dataSetName)
			{
				if (string.IsNullOrEmpty(value))
				{
					throw ExceptionBuilder.SetDataSetNameToEmpty();
				}
				DataTable dataTable = Tables[value, Namespace];
				if (dataTable != null && !dataTable._fNestedInDataset)
				{
					throw ExceptionBuilder.SetDataSetNameConflicting(value);
				}
				RaisePropertyChanging("DataSetName");
				_dataSetName = value;
			}
		}
	}

	[DefaultValue("")]
	public string Namespace
	{
		get
		{
			return _namespaceURI;
		}
		[param: AllowNull]
		set
		{
			DataCommonEventSource.Log.Trace("<ds.DataSet.set_Namespace|API> {0}, '{1}'", ObjectID, value);
			if (value == null)
			{
				value = string.Empty;
			}
			if (!(value != _namespaceURI))
			{
				return;
			}
			RaisePropertyChanging("Namespace");
			foreach (DataTable table in Tables)
			{
				if (table._tableNamespace == null && (table.NestedParentRelations.Length == 0 || (table.NestedParentRelations.Length == 1 && table.NestedParentRelations[0].ChildTable == table)))
				{
					if (Tables.Contains(table.TableName, value, checkProperty: false, caseSensitive: true))
					{
						throw ExceptionBuilder.DuplicateTableName2(table.TableName, value);
					}
					table.CheckCascadingNamespaceConflict(value);
					table.DoRaiseNamespaceChange();
				}
			}
			_namespaceURI = value;
			if (string.IsNullOrEmpty(value))
			{
				_datasetPrefix = string.Empty;
			}
		}
	}

	[DefaultValue("")]
	public string Prefix
	{
		get
		{
			return _datasetPrefix;
		}
		[param: AllowNull]
		set
		{
			if (value == null)
			{
				value = string.Empty;
			}
			if (XmlConvert.DecodeName(value) == value && XmlConvert.EncodeName(value) != value)
			{
				throw ExceptionBuilder.InvalidPrefix(value);
			}
			if (value != _datasetPrefix)
			{
				RaisePropertyChanging("Prefix");
				_datasetPrefix = value;
			}
		}
	}

	[Browsable(false)]
	public PropertyCollection ExtendedProperties => _extendedProperties ?? (_extendedProperties = new PropertyCollection());

	[Browsable(false)]
	public bool HasErrors
	{
		get
		{
			for (int i = 0; i < Tables.Count; i++)
			{
				if (Tables[i].HasErrors)
				{
					return true;
				}
			}
			return false;
		}
	}

	[Browsable(false)]
	public bool IsInitialized => !_fInitInProgress;

	public CultureInfo Locale
	{
		get
		{
			return _culture;
		}
		set
		{
			long scopeId = DataCommonEventSource.Log.EnterScope("<ds.DataSet.set_Locale|API> {0}", ObjectID);
			try
			{
				if (value != null)
				{
					if (!_culture.Equals(value))
					{
						SetLocaleValue(value, userSet: true);
					}
					_cultureUserSet = true;
				}
			}
			finally
			{
				DataCommonEventSource.Log.ExitScope(scopeId);
			}
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
					for (int i = 0; i < Tables.Count; i++)
					{
						if (Tables[i].Site != null)
						{
							container.Remove(Tables[i]);
						}
					}
				}
			}
			base.Site = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public DataRelationCollection Relations => _relationCollection;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public DataTableCollection Tables => _tableCollection;

	internal string MainTableName
	{
		set
		{
			_mainTableName = value;
		}
	}

	internal int ObjectID => _objectID;

	public DataSet()
	{
		GC.SuppressFinalize(this);
		DataCommonEventSource.Log.Trace("<ds.DataSet.DataSet|API> {0}", ObjectID);
		_tableCollection = new DataTableCollection(this);
		_relationCollection = new DataRelationCollection.DataSetRelationCollection(this);
		_culture = CultureInfo.CurrentCulture;
	}

	public DataSet(string dataSetName)
		: this()
	{
		DataSetName = dataSetName;
	}

	[RequiresDynamicCode("Members from serialized types may use dynamic code generation.")]
	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2112:ReflectionToRequiresUnreferencedCode", Justification = "CreateInstanceOfThisType's use of GetType uses only the parameterless constructor, but the annotations preserve all non-public constructors causing a warning for the serialization constructors. Those constructors won't be used here.")]
	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected DataSet(SerializationInfo info, StreamingContext context)
		: this(info, context, ConstructSchema: true)
	{
	}

	[RequiresDynamicCode("Members from serialized types may use dynamic code generation.")]
	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2112:ReflectionToRequiresUnreferencedCode", Justification = "CreateInstanceOfThisType's use of GetType uses only the parameterless constructor, but the annotations preserve all non-public constructors causing a warning for the serialization constructors. Those constructors won't be used here.")]
	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected DataSet(SerializationInfo info, StreamingContext context, bool ConstructSchema)
		: this()
	{
		SerializationFormat serializationFormat = SerializationFormat.Xml;
		SchemaSerializationMode schemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		SerializationInfoEnumerator enumerator = info.GetEnumerator();
		while (enumerator.MoveNext())
		{
			string name = enumerator.Name;
			if (!(name == "DataSet.RemotingFormat"))
			{
				if (name == "SchemaSerializationMode.DataSet")
				{
					schemaSerializationMode = (SchemaSerializationMode)enumerator.Value;
				}
			}
			else
			{
				serializationFormat = (SerializationFormat)enumerator.Value;
			}
		}
		if (serializationFormat == SerializationFormat.Binary && !System.LocalAppContextSwitches.AllowUnsafeSerializationFormatBinary)
		{
			throw ExceptionBuilder.SerializationFormatBinaryNotSupported();
		}
		if (schemaSerializationMode == SchemaSerializationMode.ExcludeSchema)
		{
			InitializeDerivedDataSet();
		}
		if (serializationFormat != SerializationFormat.Xml || ConstructSchema)
		{
			DeserializeDataSet(info, context, serializationFormat, schemaSerializationMode);
		}
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Binary serialization is unsafe in general and is planned to be obsoleted. We do not want to mark interface or ctors of this class as unsafe as that would show many unnecessary warnings elsewhere.")]
	[UnconditionalSuppressMessage("AotAnalysis", "IL3050:RequiresDynamicCode", Justification = "Binary serialization is unsafe in general and is planned to be obsoleted. We do not want to mark interface or ctors of this class as unsafe as that would show many unnecessary warnings elsewhere.")]
	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		SerializationFormat remotingFormat = RemotingFormat;
		SerializeDataSet(info, context, remotingFormat);
	}

	protected virtual void InitializeDerivedDataSet()
	{
	}

	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	[RequiresDynamicCode("Members from serialized types may use dynamic code generation.")]
	private void SerializeDataSet(SerializationInfo info, StreamingContext context, SerializationFormat remotingFormat)
	{
		info.AddValue("DataSet.RemotingVersion", new Version(2, 0));
		if (remotingFormat != SerializationFormat.Xml)
		{
			info.AddValue("DataSet.RemotingFormat", remotingFormat);
		}
		if (SchemaSerializationMode.IncludeSchema != SchemaSerializationMode)
		{
			info.AddValue("SchemaSerializationMode.DataSet", SchemaSerializationMode);
		}
		if (remotingFormat != SerializationFormat.Xml)
		{
			if (SchemaSerializationMode == SchemaSerializationMode.IncludeSchema)
			{
				SerializeDataSetProperties(info);
				info.AddValue("DataSet.Tables.Count", Tables.Count);
				for (int i = 0; i < Tables.Count; i++)
				{
					MemoryStream memoryStream = new MemoryStream();
					new BinaryFormatter(null, new StreamingContext(context.State, false)).Serialize(memoryStream, Tables[i]);
					memoryStream.Position = 0L;
					info.AddValue(string.Format(CultureInfo.InvariantCulture, "DataSet.Tables_{0}", i), memoryStream.GetBuffer());
				}
				for (int j = 0; j < Tables.Count; j++)
				{
					Tables[j].SerializeConstraints(info, j, allConstraints: true);
				}
				SerializeRelations(info);
				for (int k = 0; k < Tables.Count; k++)
				{
					Tables[k].SerializeExpressionColumns(info, k);
				}
			}
			else
			{
				SerializeDataSetProperties(info);
			}
			for (int l = 0; l < Tables.Count; l++)
			{
				Tables[l].SerializeTableData(info, l);
			}
		}
		else
		{
			string xmlSchemaForRemoting = GetXmlSchemaForRemoting(null);
			info.AddValue("XmlSchema", xmlSchemaForRemoting);
			StringWriter stringWriter = new StringWriter(new StringBuilder(EstimatedXmlStringSize() * 2), CultureInfo.InvariantCulture);
			XmlTextWriter writer = new XmlTextWriter(stringWriter);
			WriteXml(writer, XmlWriteMode.DiffGram);
			info.AddValue("XmlDiffGram", stringWriter.ToString());
		}
	}

	[RequiresDynamicCode("Members from serialized types may use dynamic code generation.")]
	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	internal void DeserializeDataSet(SerializationInfo info, StreamingContext context, SerializationFormat remotingFormat, SchemaSerializationMode schemaSerializationMode)
	{
		DeserializeDataSetSchema(info, context, remotingFormat, schemaSerializationMode);
		DeserializeDataSetData(info, remotingFormat);
	}

	[RequiresDynamicCode("Members from serialized types may use dynamic code generation.")]
	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	private void DeserializeDataSetSchema(SerializationInfo info, StreamingContext context, SerializationFormat remotingFormat, SchemaSerializationMode schemaSerializationMode)
	{
		if (remotingFormat != SerializationFormat.Xml)
		{
			if (schemaSerializationMode == SchemaSerializationMode.IncludeSchema)
			{
				DeserializeDataSetProperties(info);
				int @int = info.GetInt32("DataSet.Tables.Count");
				for (int i = 0; i < @int; i++)
				{
					MemoryStream memoryStream = new MemoryStream((byte[])info.GetValue(string.Format(CultureInfo.InvariantCulture, "DataSet.Tables_{0}", i), typeof(byte[])));
					memoryStream.Position = 0L;
					DataTable table = (DataTable)new BinaryFormatter(null, new StreamingContext(context.State, false)).Deserialize(memoryStream);
					Tables.Add(table);
				}
				for (int j = 0; j < @int; j++)
				{
					Tables[j].DeserializeConstraints(info, j, allConstraints: true);
				}
				DeserializeRelations(info);
				for (int k = 0; k < @int; k++)
				{
					Tables[k].DeserializeExpressionColumns(info, k);
				}
			}
			else
			{
				DeserializeDataSetProperties(info);
			}
		}
		else
		{
			string text = (string)info.GetValue("XmlSchema", typeof(string));
			if (text != null)
			{
				ReadXmlSchema(new XmlTextReader(new StringReader(text)), denyResolving: true);
			}
		}
	}

	[RequiresDynamicCode("Members from serialized types may use dynamic code generation.")]
	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	private void DeserializeDataSetData(SerializationInfo info, SerializationFormat remotingFormat)
	{
		if (remotingFormat != SerializationFormat.Xml)
		{
			for (int i = 0; i < Tables.Count; i++)
			{
				Tables[i].DeserializeTableData(info, i);
			}
			return;
		}
		string text = (string)info.GetValue("XmlDiffGram", typeof(string));
		if (text != null)
		{
			ReadXml(new XmlTextReader(new StringReader(text)), XmlReadMode.DiffGram);
		}
	}

	private void SerializeDataSetProperties(SerializationInfo info)
	{
		info.AddValue("DataSet.DataSetName", DataSetName);
		info.AddValue("DataSet.Namespace", Namespace);
		info.AddValue("DataSet.Prefix", Prefix);
		info.AddValue("DataSet.CaseSensitive", CaseSensitive);
		info.AddValue("DataSet.LocaleLCID", Locale.LCID);
		info.AddValue("DataSet.EnforceConstraints", EnforceConstraints);
		info.AddValue("DataSet.ExtendedProperties", ExtendedProperties);
	}

	private void DeserializeDataSetProperties(SerializationInfo info)
	{
		_dataSetName = info.GetString("DataSet.DataSetName");
		_namespaceURI = info.GetString("DataSet.Namespace");
		_datasetPrefix = info.GetString("DataSet.Prefix");
		_caseSensitive = info.GetBoolean("DataSet.CaseSensitive");
		int culture = (int)info.GetValue("DataSet.LocaleLCID", typeof(int));
		_culture = new CultureInfo(culture);
		_cultureUserSet = true;
		_enforceConstraints = info.GetBoolean("DataSet.EnforceConstraints");
		_extendedProperties = (PropertyCollection)info.GetValue("DataSet.ExtendedProperties", typeof(PropertyCollection));
	}

	private void SerializeRelations(SerializationInfo info)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DataRelation relation in Relations)
		{
			int[] array = new int[relation.ParentColumns.Length + 1];
			array[0] = Tables.IndexOf(relation.ParentTable);
			for (int i = 1; i < array.Length; i++)
			{
				array[i] = relation.ParentColumns[i - 1].Ordinal;
			}
			int[] array2 = new int[relation.ChildColumns.Length + 1];
			array2[0] = Tables.IndexOf(relation.ChildTable);
			for (int j = 1; j < array2.Length; j++)
			{
				array2[j] = relation.ChildColumns[j - 1].Ordinal;
			}
			ArrayList arrayList2 = new ArrayList();
			arrayList2.Add(relation.RelationName);
			arrayList2.Add(array);
			arrayList2.Add(array2);
			arrayList2.Add(relation.Nested);
			arrayList2.Add(relation._extendedProperties);
			arrayList.Add(arrayList2);
		}
		info.AddValue("DataSet.Relations", arrayList);
	}

	private void DeserializeRelations(SerializationInfo info)
	{
		foreach (ArrayList item in (ArrayList)info.GetValue("DataSet.Relations", typeof(ArrayList)))
		{
			string relationName = (string)item[0];
			int[] array = (int[])item[1];
			int[] array2 = (int[])item[2];
			bool nested = (bool)item[3];
			PropertyCollection extendedProperties = (PropertyCollection)item[4];
			DataColumn[] array3 = new DataColumn[array.Length - 1];
			for (int i = 0; i < array3.Length; i++)
			{
				array3[i] = Tables[array[0]].Columns[array[i + 1]];
			}
			DataColumn[] array4 = new DataColumn[array2.Length - 1];
			for (int j = 0; j < array4.Length; j++)
			{
				array4[j] = Tables[array2[0]].Columns[array2[j + 1]];
			}
			DataRelation dataRelation = new DataRelation(relationName, array3, array4, createConstraints: false);
			dataRelation.CheckMultipleNested = false;
			dataRelation.Nested = nested;
			dataRelation._extendedProperties = extendedProperties;
			Relations.Add(dataRelation);
			dataRelation.CheckMultipleNested = true;
		}
	}

	internal void FailedEnableConstraints()
	{
		EnforceConstraints = false;
		throw ExceptionBuilder.EnforceConstraint();
	}

	internal void EnableConstraints()
	{
		long scopeId = DataCommonEventSource.Log.EnterScope("<ds.DataSet.EnableConstraints|INFO> {0}", ObjectID);
		try
		{
			bool flag = false;
			ConstraintEnumerator constraintEnumerator = new ConstraintEnumerator(this);
			while (constraintEnumerator.GetNext())
			{
				Constraint constraint = constraintEnumerator.GetConstraint();
				flag |= constraint.IsConstraintViolated();
			}
			foreach (DataTable table in Tables)
			{
				foreach (DataColumn column in table.Columns)
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
			}
			if (flag)
			{
				FailedEnableConstraints();
			}
		}
		finally
		{
			DataCommonEventSource.Log.ExitScope(scopeId);
		}
	}

	internal void SetLocaleValue(CultureInfo value, bool userSet)
	{
		bool flag = false;
		bool flag2 = false;
		int num = 0;
		CultureInfo culture = _culture;
		bool cultureUserSet = _cultureUserSet;
		try
		{
			_culture = value;
			_cultureUserSet = userSet;
			foreach (DataTable table in Tables)
			{
				if (!table.ShouldSerializeLocale())
				{
					table.SetLocaleValue(value, userSet: false, resetIndexes: false);
				}
			}
			flag = ValidateLocaleConstraint();
			if (!flag)
			{
				return;
			}
			flag = false;
			foreach (DataTable table2 in Tables)
			{
				num++;
				if (!table2.ShouldSerializeLocale())
				{
					table2.SetLocaleValue(value, userSet: false, resetIndexes: true);
				}
			}
			flag = true;
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
				_culture = culture;
				_cultureUserSet = cultureUserSet;
				foreach (DataTable table3 in Tables)
				{
					if (!table3.ShouldSerializeLocale())
					{
						table3.SetLocaleValue(culture, userSet: false, resetIndexes: false);
					}
				}
				try
				{
					for (int i = 0; i < num; i++)
					{
						if (!Tables[i].ShouldSerializeLocale())
						{
							Tables[i].SetLocaleValue(culture, userSet: false, resetIndexes: true);
						}
					}
				}
				catch (Exception e) when (ADP.IsCatchableExceptionType(e))
				{
					ADP.TraceExceptionWithoutRethrow(e);
				}
				if (!flag2)
				{
					throw ExceptionBuilder.CannotChangeCaseLocale(null);
				}
			}
		}
	}

	internal bool ShouldSerializeLocale()
	{
		return _cultureUserSet;
	}

	public void Clear()
	{
		long scopeId = DataCommonEventSource.Log.EnterScope("<ds.DataSet.Clear|API> {0}", ObjectID);
		try
		{
			OnClearFunctionCalled(null);
			bool enforceConstraints = EnforceConstraints;
			EnforceConstraints = false;
			for (int i = 0; i < Tables.Count; i++)
			{
				Tables[i].Clear();
			}
			EnforceConstraints = enforceConstraints;
		}
		finally
		{
			DataCommonEventSource.Log.ExitScope(scopeId);
		}
	}

	private DataSet CreateInstanceOfThisType()
	{
		return (DataSet)Activator.CreateInstance(GetType(), nonPublic: true);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual DataSet Clone()
	{
		long scopeId = DataCommonEventSource.Log.EnterScope("<ds.DataSet.Clone|API> {0}", ObjectID);
		try
		{
			DataSet dataSet = CreateInstanceOfThisType();
			if (dataSet.Tables.Count > 0)
			{
				dataSet.Reset();
			}
			dataSet.DataSetName = DataSetName;
			dataSet.CaseSensitive = CaseSensitive;
			dataSet._culture = _culture;
			dataSet._cultureUserSet = _cultureUserSet;
			dataSet.EnforceConstraints = EnforceConstraints;
			dataSet.Namespace = Namespace;
			dataSet.Prefix = Prefix;
			dataSet.RemotingFormat = RemotingFormat;
			dataSet._fIsSchemaLoading = true;
			DataTableCollection tables = Tables;
			for (int i = 0; i < tables.Count; i++)
			{
				DataTable dataTable = tables[i].Clone(dataSet);
				dataTable._tableNamespace = tables[i].Namespace;
				dataSet.Tables.Add(dataTable);
			}
			for (int j = 0; j < tables.Count; j++)
			{
				ConstraintCollection constraints = tables[j].Constraints;
				for (int k = 0; k < constraints.Count; k++)
				{
					if (!(constraints[k] is UniqueConstraint))
					{
						ForeignKeyConstraint foreignKeyConstraint = (ForeignKeyConstraint)constraints[k];
						if (foreignKeyConstraint.Table != foreignKeyConstraint.RelatedTable)
						{
							dataSet.Tables[j].Constraints.Add(constraints[k].Clone(dataSet));
						}
					}
				}
			}
			DataRelationCollection relations = Relations;
			for (int l = 0; l < relations.Count; l++)
			{
				DataRelation dataRelation = relations[l].Clone(dataSet);
				dataRelation.CheckMultipleNested = false;
				dataSet.Relations.Add(dataRelation);
				dataRelation.CheckMultipleNested = true;
			}
			if (_extendedProperties != null)
			{
				foreach (object key in _extendedProperties.Keys)
				{
					dataSet.ExtendedProperties[key] = _extendedProperties[key];
				}
			}
			foreach (DataTable table in Tables)
			{
				foreach (DataColumn column in table.Columns)
				{
					if (column.Expression.Length != 0)
					{
						dataSet.Tables[table.TableName, table.Namespace].Columns[column.ColumnName].CopyExpressionFrom(column);
					}
				}
			}
			for (int m = 0; m < tables.Count; m++)
			{
				dataSet.Tables[m]._tableNamespace = tables[m]._tableNamespace;
			}
			dataSet._fIsSchemaLoading = false;
			return dataSet;
		}
		finally
		{
			DataCommonEventSource.Log.ExitScope(scopeId);
		}
	}

	internal int EstimatedXmlStringSize()
	{
		int num = 100;
		for (int i = 0; i < Tables.Count; i++)
		{
			int num2 = Tables[i].TableName.Length + 4 << 2;
			DataTable dataTable = Tables[i];
			for (int j = 0; j < dataTable.Columns.Count; j++)
			{
				num2 += dataTable.Columns[j].ColumnName.Length + 4 << 2;
				num2 += 20;
			}
			num += dataTable.Rows.Count * num2;
		}
		return num;
	}

	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	[RequiresDynamicCode("Members from serialized types may use dynamic code generation.")]
	internal static string GetRemotingDiffGram(DataTable table)
	{
		StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
		XmlTextWriter xmlw = new XmlTextWriter(stringWriter)
		{
			Formatting = Formatting.Indented
		};
		new NewDiffgramGen(table, writeHierarchy: false).Save(xmlw, table);
		return stringWriter.ToString();
	}

	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	[RequiresDynamicCode("Members from serialized types may use dynamic code generation.")]
	internal string GetXmlSchemaForRemoting(DataTable table)
	{
		StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
		XmlTextWriter xw = new XmlTextWriter(stringWriter)
		{
			Formatting = Formatting.Indented
		};
		if (table == null)
		{
			if (SchemaSerializationMode == SchemaSerializationMode.ExcludeSchema)
			{
				new XmlTreeGen(SchemaFormat.RemotingSkipSchema).Save(this, xw);
			}
			else
			{
				new XmlTreeGen(SchemaFormat.Remoting).Save(this, xw);
			}
		}
		else
		{
			new XmlTreeGen(SchemaFormat.Remoting).Save(table, xw);
		}
		return stringWriter.ToString();
	}

	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	[RequiresDynamicCode("Members from serialized types may use dynamic code generation.")]
	public void ReadXmlSchema(XmlReader? reader)
	{
		ReadXmlSchema(reader, denyResolving: false);
	}

	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	[RequiresDynamicCode("Members from serialized types may use dynamic code generation.")]
	internal void ReadXmlSchema(XmlReader reader, bool denyResolving)
	{
		long scopeId = DataCommonEventSource.Log.EnterScope("<ds.DataSet.ReadXmlSchema|INFO> {0}, reader, denyResolving={1}", ObjectID, denyResolving);
		try
		{
			int depth = -1;
			if (reader == null)
			{
				return;
			}
			if (reader is XmlTextReader)
			{
				((XmlTextReader)reader).WhitespaceHandling = WhitespaceHandling.None;
			}
			XmlDocument xmlDocument = new XmlDocument();
			if (reader.NodeType == XmlNodeType.Element)
			{
				depth = reader.Depth;
			}
			reader.MoveToContent();
			if (reader.NodeType != XmlNodeType.Element)
			{
				return;
			}
			if (reader.LocalName == "Schema" && reader.NamespaceURI == "urn:schemas-microsoft-com:xml-data")
			{
				ReadXDRSchema(reader);
				return;
			}
			if (reader.LocalName == "schema" && reader.NamespaceURI == "http://www.w3.org/2001/XMLSchema")
			{
				ReadXSDSchema(reader);
				return;
			}
			if (reader.LocalName == "schema" && reader.NamespaceURI.StartsWith("http://www.w3.org/", StringComparison.Ordinal))
			{
				throw ExceptionBuilder.DataSetUnsupportedSchema("http://www.w3.org/2001/XMLSchema");
			}
			XmlElement xmlElement = xmlDocument.CreateElement(reader.Prefix, reader.LocalName, reader.NamespaceURI);
			if (reader.HasAttributes)
			{
				int attributeCount = reader.AttributeCount;
				for (int i = 0; i < attributeCount; i++)
				{
					reader.MoveToAttribute(i);
					if (reader.NamespaceURI.Equals("http://www.w3.org/2000/xmlns/"))
					{
						xmlElement.SetAttribute(reader.Name, reader.GetAttribute(i));
						continue;
					}
					XmlAttribute xmlAttribute = xmlElement.SetAttributeNode(reader.LocalName, reader.NamespaceURI);
					xmlAttribute.Prefix = reader.Prefix;
					xmlAttribute.Value = reader.GetAttribute(i);
				}
			}
			reader.Read();
			while (MoveToElement(reader, depth))
			{
				if (reader.LocalName == "Schema" && reader.NamespaceURI == "urn:schemas-microsoft-com:xml-data")
				{
					ReadXDRSchema(reader);
					return;
				}
				if (reader.LocalName == "schema" && reader.NamespaceURI == "http://www.w3.org/2001/XMLSchema")
				{
					ReadXSDSchema(reader);
					return;
				}
				if (reader.LocalName == "schema" && reader.NamespaceURI.StartsWith("http://www.w3.org/", StringComparison.Ordinal))
				{
					throw ExceptionBuilder.DataSetUnsupportedSchema("http://www.w3.org/2001/XMLSchema");
				}
				XmlNode newChild = xmlDocument.ReadNode(reader);
				xmlElement.AppendChild(newChild);
			}
			ReadEndElement(reader);
			xmlDocument.AppendChild(xmlElement);
			InferSchema(xmlDocument, null, XmlReadMode.Auto);
		}
		finally
		{
			DataCommonEventSource.Log.ExitScope(scopeId);
		}
	}

	internal static bool MoveToElement(XmlReader reader, int depth)
	{
		while (!reader.EOF && reader.NodeType != XmlNodeType.EndElement && reader.NodeType != XmlNodeType.Element && reader.Depth > depth)
		{
			reader.Read();
		}
		return reader.NodeType == XmlNodeType.Element;
	}

	private static void MoveToElement(XmlReader reader)
	{
		while (!reader.EOF && reader.NodeType != XmlNodeType.EndElement && reader.NodeType != XmlNodeType.Element)
		{
			reader.Read();
		}
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
		int num = 1;
		if (reader.LocalName == "schema" && reader.NamespaceURI == "http://www.w3.org/2001/XMLSchema" && reader.HasAttributes)
		{
			string attribute = reader.GetAttribute("schemafragmentcount", "urn:schemas-microsoft-com:xml-msdata");
			if (!string.IsNullOrEmpty(attribute))
			{
				num = int.Parse(attribute, null);
			}
		}
		while (reader.LocalName == "schema" && reader.NamespaceURI == "http://www.w3.org/2001/XMLSchema")
		{
			XmlSchema schema = XmlSchema.Read(reader, null);
			xmlSchemaSet.Add(schema);
			ReadEndElement(reader);
			if (--num > 0)
			{
				MoveToElement(reader);
			}
			while (reader.NodeType == XmlNodeType.Whitespace)
			{
				reader.Skip();
			}
		}
		xmlSchemaSet.Compile();
		new XSDSchema().LoadSchema(xmlSchemaSet, this);
	}

	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	internal void ReadXDRSchema(XmlReader reader)
	{
		XmlDocument xmlDocument = new XmlDocument();
		XmlNode xmlNode = xmlDocument.ReadNode(reader);
		xmlDocument.AppendChild(xmlNode);
		XDRSchema xDRSchema = new XDRSchema(this);
		DataSetName = xmlDocument.DocumentElement.LocalName;
		xDRSchema.LoadSchema((XmlElement)xmlNode, this);
	}

	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	[RequiresDynamicCode("Members from serialized types may use dynamic code generation.")]
	public XmlReadMode ReadXml(XmlReader? reader)
	{
		return ReadXml(reader, denyResolving: false);
	}

	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	[RequiresDynamicCode("Members from serialized types may use dynamic code generation.")]
	internal XmlReadMode ReadXml(XmlReader reader, bool denyResolving)
	{
		IDisposable disposable = null;
		long scopeId = DataCommonEventSource.Log.EnterScope("<ds.DataSet.ReadXml|INFO> {0}, denyResolving={1}", ObjectID, denyResolving);
		try
		{
			disposable = TypeLimiter.EnterRestrictedScope(this);
			DataTable.DSRowDiffIdUsageSection dSRowDiffIdUsageSection = default(DataTable.DSRowDiffIdUsageSection);
			try
			{
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				bool isXdr = false;
				int depth = -1;
				XmlReadMode result = XmlReadMode.Auto;
				bool flag4 = false;
				bool flag5 = false;
				dSRowDiffIdUsageSection.Prepare(this);
				if (reader == null)
				{
					return result;
				}
				if (Tables.Count == 0)
				{
					flag4 = true;
				}
				if (reader is XmlTextReader)
				{
					((XmlTextReader)reader).WhitespaceHandling = WhitespaceHandling.Significant;
				}
				XmlDocument xmlDocument = new XmlDocument();
				XmlDataLoader xmlDataLoader = null;
				reader.MoveToContent();
				if (reader.NodeType == XmlNodeType.Element)
				{
					depth = reader.Depth;
				}
				if (reader.NodeType == XmlNodeType.Element)
				{
					if (reader.LocalName == "diffgram" && reader.NamespaceURI == "urn:schemas-microsoft-com:xml-diffgram-v1")
					{
						ReadXmlDiffgram(reader);
						ReadEndElement(reader);
						return XmlReadMode.DiffGram;
					}
					if (reader.LocalName == "Schema" && reader.NamespaceURI == "urn:schemas-microsoft-com:xml-data")
					{
						ReadXDRSchema(reader);
						return XmlReadMode.ReadSchema;
					}
					if (reader.LocalName == "schema" && reader.NamespaceURI == "http://www.w3.org/2001/XMLSchema")
					{
						ReadXSDSchema(reader);
						return XmlReadMode.ReadSchema;
					}
					if (reader.LocalName == "schema" && reader.NamespaceURI.StartsWith("http://www.w3.org/", StringComparison.Ordinal))
					{
						throw ExceptionBuilder.DataSetUnsupportedSchema("http://www.w3.org/2001/XMLSchema");
					}
					XmlElement xmlElement = xmlDocument.CreateElement(reader.Prefix, reader.LocalName, reader.NamespaceURI);
					if (reader.HasAttributes)
					{
						int attributeCount = reader.AttributeCount;
						for (int i = 0; i < attributeCount; i++)
						{
							reader.MoveToAttribute(i);
							if (reader.NamespaceURI.Equals("http://www.w3.org/2000/xmlns/"))
							{
								xmlElement.SetAttribute(reader.Name, reader.GetAttribute(i));
								continue;
							}
							XmlAttribute xmlAttribute = xmlElement.SetAttributeNode(reader.LocalName, reader.NamespaceURI);
							xmlAttribute.Prefix = reader.Prefix;
							xmlAttribute.Value = reader.GetAttribute(i);
						}
					}
					reader.Read();
					string value = reader.Value;
					while (MoveToElement(reader, depth))
					{
						if (reader.LocalName == "diffgram" && reader.NamespaceURI == "urn:schemas-microsoft-com:xml-diffgram-v1")
						{
							ReadXmlDiffgram(reader);
							result = XmlReadMode.DiffGram;
						}
						if (!flag2 && !flag && reader.LocalName == "Schema" && reader.NamespaceURI == "urn:schemas-microsoft-com:xml-data")
						{
							ReadXDRSchema(reader);
							flag2 = true;
							isXdr = true;
							continue;
						}
						if (reader.LocalName == "schema" && reader.NamespaceURI == "http://www.w3.org/2001/XMLSchema")
						{
							ReadXSDSchema(reader);
							flag2 = true;
							continue;
						}
						if (reader.LocalName == "schema" && reader.NamespaceURI.StartsWith("http://www.w3.org/", StringComparison.Ordinal))
						{
							throw ExceptionBuilder.DataSetUnsupportedSchema("http://www.w3.org/2001/XMLSchema");
						}
						if (reader.LocalName == "diffgram" && reader.NamespaceURI == "urn:schemas-microsoft-com:xml-diffgram-v1")
						{
							ReadXmlDiffgram(reader);
							flag3 = true;
							result = XmlReadMode.DiffGram;
							continue;
						}
						while (!reader.EOF && reader.NodeType == XmlNodeType.Whitespace)
						{
							reader.Read();
						}
						if (reader.NodeType != XmlNodeType.Element)
						{
							continue;
						}
						flag = true;
						if (!flag2 && Tables.Count == 0)
						{
							XmlNode newChild = xmlDocument.ReadNode(reader);
							xmlElement.AppendChild(newChild);
							continue;
						}
						if (xmlDataLoader == null)
						{
							xmlDataLoader = new XmlDataLoader(this, isXdr, xmlElement, ignoreSchema: false);
						}
						xmlDataLoader.LoadData(reader);
						flag5 = true;
						result = (flag2 ? XmlReadMode.ReadSchema : XmlReadMode.IgnoreSchema);
					}
					ReadEndElement(reader);
					bool flag6 = false;
					bool fTopLevelTable = _fTopLevelTable;
					if (!flag2 && Tables.Count == 0 && !xmlElement.HasChildNodes)
					{
						_fTopLevelTable = true;
						flag6 = true;
						if (value != null && value.Length > 0)
						{
							xmlElement.InnerText = value;
						}
					}
					if (!flag4 && value != null && value.Length > 0)
					{
						xmlElement.InnerText = value;
					}
					xmlDocument.AppendChild(xmlElement);
					if (xmlDataLoader == null)
					{
						xmlDataLoader = new XmlDataLoader(this, isXdr, xmlElement, ignoreSchema: false);
					}
					if (!flag4 && !flag5)
					{
						XmlElement documentElement = xmlDocument.DocumentElement;
						if (documentElement.ChildNodes.Count == 0 || (documentElement.ChildNodes.Count == 1 && documentElement.FirstChild.GetType() == typeof(XmlText)))
						{
							bool fTopLevelTable2 = _fTopLevelTable;
							if (DataSetName != documentElement.Name && _namespaceURI != documentElement.NamespaceURI && Tables.Contains(documentElement.Name, (documentElement.NamespaceURI.Length == 0) ? null : documentElement.NamespaceURI, checkProperty: false, caseSensitive: true))
							{
								_fTopLevelTable = true;
							}
							try
							{
								xmlDataLoader.LoadData(xmlDocument);
							}
							finally
							{
								_fTopLevelTable = fTopLevelTable2;
							}
						}
					}
					if (!flag3)
					{
						if (!flag2 && Tables.Count == 0)
						{
							InferSchema(xmlDocument, null, XmlReadMode.Auto);
							result = XmlReadMode.InferSchema;
							xmlDataLoader.FromInference = true;
							try
							{
								xmlDataLoader.LoadData(xmlDocument);
							}
							finally
							{
								xmlDataLoader.FromInference = false;
							}
						}
						if (flag6)
						{
							_fTopLevelTable = fTopLevelTable;
						}
					}
				}
				return result;
			}
			finally
			{
			}
		}
		finally
		{
			disposable?.Dispose();
			DataCommonEventSource.Log.ExitScope(scopeId);
		}
	}

	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	[RequiresDynamicCode("Members from serialized types may use dynamic code generation.")]
	internal void InferSchema(XmlDocument xdoc, string[] excludedNamespaces, XmlReadMode mode)
	{
		long scopeId = DataCommonEventSource.Log.EnterScope("<ds.DataSet.InferSchema|INFO> {0}, mode={1}", ObjectID, mode);
		try
		{
			if (excludedNamespaces == null)
			{
				excludedNamespaces = Array.Empty<string>();
			}
			XmlNodeReader instanceDocument = new XmlIgnoreNamespaceReader(xdoc, excludedNamespaces);
			XmlSchemaSet xmlSchemaSet = new XmlSchemaInference
			{
				Occurrence = XmlSchemaInference.InferenceOption.Relaxed,
				TypeInference = ((mode != XmlReadMode.InferTypedSchema) ? XmlSchemaInference.InferenceOption.Relaxed : XmlSchemaInference.InferenceOption.Restricted)
			}.InferSchema(instanceDocument);
			xmlSchemaSet.Compile();
			XSDSchema xSDSchema = new XSDSchema();
			xSDSchema.FromInference = true;
			try
			{
				xSDSchema.LoadSchema(xmlSchemaSet, this);
			}
			finally
			{
				xSDSchema.FromInference = false;
			}
		}
		finally
		{
			DataCommonEventSource.Log.ExitScope(scopeId);
		}
	}

	private bool IsEmpty()
	{
		foreach (DataTable table in Tables)
		{
			if (table.Rows.Count > 0)
			{
				return false;
			}
		}
		return true;
	}

	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	[RequiresDynamicCode("Members from serialized types may use dynamic code generation.")]
	private void ReadXmlDiffgram(XmlReader reader)
	{
		long scopeId = DataCommonEventSource.Log.EnterScope("<ds.DataSet.ReadXmlDiffgram|INFO> {0}", ObjectID);
		try
		{
			int depth = reader.Depth;
			bool enforceConstraints = EnforceConstraints;
			EnforceConstraints = false;
			bool flag = IsEmpty();
			DataSet dataSet;
			if (flag)
			{
				dataSet = this;
			}
			else
			{
				dataSet = Clone();
				dataSet.EnforceConstraints = false;
			}
			foreach (DataTable table in dataSet.Tables)
			{
				table.Rows._nullInList = 0;
			}
			reader.MoveToContent();
			if (reader.LocalName != "diffgram" && reader.NamespaceURI != "urn:schemas-microsoft-com:xml-diffgram-v1")
			{
				return;
			}
			reader.Read();
			if (reader.NodeType == XmlNodeType.Whitespace)
			{
				MoveToElement(reader, reader.Depth - 1);
			}
			dataSet._fInLoadDiffgram = true;
			if (reader.Depth > depth)
			{
				if (reader.NamespaceURI != "urn:schemas-microsoft-com:xml-diffgram-v1" && reader.NamespaceURI != "urn:schemas-microsoft-com:xml-msdata")
				{
					XmlElement topNode = new XmlDocument().CreateElement(reader.Prefix, reader.LocalName, reader.NamespaceURI);
					reader.Read();
					if (reader.NodeType == XmlNodeType.Whitespace)
					{
						MoveToElement(reader, reader.Depth - 1);
					}
					if (reader.Depth - 1 > depth)
					{
						XmlDataLoader xmlDataLoader = new XmlDataLoader(dataSet, IsXdr: false, topNode, ignoreSchema: false);
						xmlDataLoader._isDiffgram = true;
						xmlDataLoader.LoadData(reader);
					}
					ReadEndElement(reader);
					if (reader.NodeType == XmlNodeType.Whitespace)
					{
						MoveToElement(reader, reader.Depth - 1);
					}
				}
				if ((reader.LocalName == "before" && reader.NamespaceURI == "urn:schemas-microsoft-com:xml-diffgram-v1") || (reader.LocalName == "errors" && reader.NamespaceURI == "urn:schemas-microsoft-com:xml-diffgram-v1"))
				{
					new XMLDiffLoader().LoadDiffGram(dataSet, reader);
				}
				while (reader.Depth > depth)
				{
					reader.Read();
				}
				ReadEndElement(reader);
			}
			foreach (DataTable table2 in dataSet.Tables)
			{
				if (table2.Rows._nullInList > 0)
				{
					throw ExceptionBuilder.RowInsertMissing(table2.TableName);
				}
			}
			dataSet._fInLoadDiffgram = false;
			foreach (DataTable table3 in dataSet.Tables)
			{
				DataRelation[] nestedParentRelations = table3.NestedParentRelations;
				DataRelation[] array = nestedParentRelations;
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].ParentTable != table3)
					{
						continue;
					}
					foreach (DataRow row in table3.Rows)
					{
						DataRelation[] array2 = nestedParentRelations;
						foreach (DataRelation rel in array2)
						{
							row.CheckForLoops(rel);
						}
					}
				}
			}
			if (!flag)
			{
				Merge(dataSet);
				if (_dataSetName == "NewDataSet")
				{
					_dataSetName = dataSet._dataSetName;
				}
				dataSet.EnforceConstraints = enforceConstraints;
			}
			EnforceConstraints = enforceConstraints;
		}
		finally
		{
			DataCommonEventSource.Log.ExitScope(scopeId);
		}
	}

	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	[RequiresDynamicCode("Members from serialized types may use dynamic code generation.")]
	public XmlReadMode ReadXml(XmlReader? reader, XmlReadMode mode)
	{
		return ReadXml(reader, mode, denyResolving: false);
	}

	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	[RequiresDynamicCode("Members from serialized types may use dynamic code generation.")]
	internal XmlReadMode ReadXml(XmlReader reader, XmlReadMode mode, bool denyResolving)
	{
		IDisposable disposable = null;
		long scopeId = DataCommonEventSource.Log.EnterScope("<ds.DataSet.ReadXml|INFO> {0}, mode={1}, denyResolving={2}", ObjectID, mode, denyResolving);
		try
		{
			disposable = TypeLimiter.EnterRestrictedScope(this);
			XmlReadMode result = mode;
			if (reader == null)
			{
				return result;
			}
			if (mode == XmlReadMode.Auto)
			{
				return ReadXml(reader);
			}
			DataTable.DSRowDiffIdUsageSection dSRowDiffIdUsageSection = default(DataTable.DSRowDiffIdUsageSection);
			try
			{
				bool flag = false;
				bool flag2 = false;
				bool isXdr = false;
				int depth = -1;
				dSRowDiffIdUsageSection.Prepare(this);
				if (reader is XmlTextReader)
				{
					((XmlTextReader)reader).WhitespaceHandling = WhitespaceHandling.Significant;
				}
				XmlDocument xmlDocument = new XmlDocument();
				if (mode != XmlReadMode.Fragment && reader.NodeType == XmlNodeType.Element)
				{
					depth = reader.Depth;
				}
				reader.MoveToContent();
				XmlDataLoader xmlDataLoader = null;
				if (reader.NodeType == XmlNodeType.Element)
				{
					XmlElement xmlElement = null;
					if (mode == XmlReadMode.Fragment)
					{
						xmlDocument.AppendChild(xmlDocument.CreateElement("ds_sqlXmlWraPPeR"));
						xmlElement = xmlDocument.DocumentElement;
					}
					else
					{
						if (reader.LocalName == "diffgram" && reader.NamespaceURI == "urn:schemas-microsoft-com:xml-diffgram-v1")
						{
							if (mode == XmlReadMode.DiffGram || mode == XmlReadMode.IgnoreSchema)
							{
								ReadXmlDiffgram(reader);
								ReadEndElement(reader);
							}
							else
							{
								reader.Skip();
							}
							return result;
						}
						if (reader.LocalName == "Schema" && reader.NamespaceURI == "urn:schemas-microsoft-com:xml-data")
						{
							if (mode != XmlReadMode.IgnoreSchema && mode != XmlReadMode.InferSchema && mode != XmlReadMode.InferTypedSchema)
							{
								ReadXDRSchema(reader);
							}
							else
							{
								reader.Skip();
							}
							return result;
						}
						if (reader.LocalName == "schema" && reader.NamespaceURI == "http://www.w3.org/2001/XMLSchema")
						{
							if (mode != XmlReadMode.IgnoreSchema && mode != XmlReadMode.InferSchema && mode != XmlReadMode.InferTypedSchema)
							{
								ReadXSDSchema(reader);
							}
							else
							{
								reader.Skip();
							}
							return result;
						}
						if (reader.LocalName == "schema" && reader.NamespaceURI.StartsWith("http://www.w3.org/", StringComparison.Ordinal))
						{
							throw ExceptionBuilder.DataSetUnsupportedSchema("http://www.w3.org/2001/XMLSchema");
						}
						xmlElement = xmlDocument.CreateElement(reader.Prefix, reader.LocalName, reader.NamespaceURI);
						if (reader.HasAttributes)
						{
							int attributeCount = reader.AttributeCount;
							for (int i = 0; i < attributeCount; i++)
							{
								reader.MoveToAttribute(i);
								if (reader.NamespaceURI.Equals("http://www.w3.org/2000/xmlns/"))
								{
									xmlElement.SetAttribute(reader.Name, reader.GetAttribute(i));
									continue;
								}
								XmlAttribute xmlAttribute = xmlElement.SetAttributeNode(reader.LocalName, reader.NamespaceURI);
								xmlAttribute.Prefix = reader.Prefix;
								xmlAttribute.Value = reader.GetAttribute(i);
							}
						}
						reader.Read();
					}
					while (MoveToElement(reader, depth))
					{
						if (reader.LocalName == "Schema" && reader.NamespaceURI == "urn:schemas-microsoft-com:xml-data")
						{
							if (!flag && !flag2 && mode != XmlReadMode.IgnoreSchema && mode != XmlReadMode.InferSchema && mode != XmlReadMode.InferTypedSchema)
							{
								ReadXDRSchema(reader);
								flag = true;
								isXdr = true;
							}
							else
							{
								reader.Skip();
							}
							continue;
						}
						if (reader.LocalName == "schema" && reader.NamespaceURI == "http://www.w3.org/2001/XMLSchema")
						{
							if (mode != XmlReadMode.IgnoreSchema && mode != XmlReadMode.InferSchema && mode != XmlReadMode.InferTypedSchema)
							{
								ReadXSDSchema(reader);
								flag = true;
							}
							else
							{
								reader.Skip();
							}
							continue;
						}
						if (reader.LocalName == "diffgram" && reader.NamespaceURI == "urn:schemas-microsoft-com:xml-diffgram-v1")
						{
							if (mode == XmlReadMode.DiffGram || mode == XmlReadMode.IgnoreSchema)
							{
								ReadXmlDiffgram(reader);
								result = XmlReadMode.DiffGram;
							}
							else
							{
								reader.Skip();
							}
							continue;
						}
						if (reader.LocalName == "schema" && reader.NamespaceURI.StartsWith("http://www.w3.org/", StringComparison.Ordinal))
						{
							throw ExceptionBuilder.DataSetUnsupportedSchema("http://www.w3.org/2001/XMLSchema");
						}
						if (mode == XmlReadMode.DiffGram)
						{
							reader.Skip();
							continue;
						}
						flag2 = true;
						if (mode == XmlReadMode.InferSchema || mode == XmlReadMode.InferTypedSchema)
						{
							XmlNode newChild = xmlDocument.ReadNode(reader);
							xmlElement.AppendChild(newChild);
							continue;
						}
						if (xmlDataLoader == null)
						{
							xmlDataLoader = new XmlDataLoader(this, isXdr, xmlElement, mode == XmlReadMode.IgnoreSchema);
						}
						xmlDataLoader.LoadData(reader);
					}
					ReadEndElement(reader);
					xmlDocument.AppendChild(xmlElement);
					if (xmlDataLoader == null)
					{
						xmlDataLoader = new XmlDataLoader(this, isXdr, mode == XmlReadMode.IgnoreSchema);
					}
					switch (mode)
					{
					case XmlReadMode.DiffGram:
						return result;
					case XmlReadMode.InferSchema:
					case XmlReadMode.InferTypedSchema:
						InferSchema(xmlDocument, null, mode);
						result = XmlReadMode.InferSchema;
						xmlDataLoader.FromInference = true;
						try
						{
							xmlDataLoader.LoadData(xmlDocument);
						}
						finally
						{
							xmlDataLoader.FromInference = false;
						}
						break;
					}
				}
				return result;
			}
			finally
			{
			}
		}
		finally
		{
			disposable?.Dispose();
			DataCommonEventSource.Log.ExitScope(scopeId);
		}
	}

	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	[RequiresDynamicCode("Members from serialized types may use dynamic code generation.")]
	public void WriteXml(XmlWriter? writer, XmlWriteMode mode)
	{
		long scopeId = DataCommonEventSource.Log.EnterScope("<ds.DataSet.WriteXml|API> {0}, mode={1}", ObjectID, mode);
		try
		{
			if (writer != null)
			{
				if (mode == XmlWriteMode.DiffGram)
				{
					new NewDiffgramGen(this).Save(writer);
				}
				else
				{
					new XmlDataTreeWriter(this).Save(writer, mode == XmlWriteMode.WriteSchema);
				}
			}
		}
		finally
		{
			DataCommonEventSource.Log.ExitScope(scopeId);
		}
	}

	public void Merge(DataSet dataSet)
	{
		long scopeId = DataCommonEventSource.Log.EnterScope("<ds.DataSet.Merge|API> {0}, dataSet={1}", ObjectID, dataSet?.ObjectID ?? 0);
		try
		{
			Merge(dataSet, preserveChanges: false, MissingSchemaAction.Add);
		}
		finally
		{
			DataCommonEventSource.Log.ExitScope(scopeId);
		}
	}

	public void Merge(DataSet dataSet, bool preserveChanges, MissingSchemaAction missingSchemaAction)
	{
		long scopeId = DataCommonEventSource.Log.EnterScope("<ds.DataSet.Merge|API> {0}, dataSet={1}, preserveChanges={2}, missingSchemaAction={3}", ObjectID, dataSet?.ObjectID ?? 0, preserveChanges, missingSchemaAction);
		try
		{
			if (dataSet == null)
			{
				throw ExceptionBuilder.ArgumentNull("dataSet");
			}
			if ((uint)(missingSchemaAction - 1) <= 3u)
			{
				new Merger(this, preserveChanges, missingSchemaAction).MergeDataSet(dataSet);
				return;
			}
			throw ADP.InvalidMissingSchemaAction(missingSchemaAction);
		}
		finally
		{
			DataCommonEventSource.Log.ExitScope(scopeId);
		}
	}

	protected virtual void OnPropertyChanging(PropertyChangedEventArgs pcevent)
	{
		PropertyChanging?.Invoke(this, pcevent);
	}

	internal void OnMergeFailed(MergeFailedEventArgs mfevent)
	{
		if (MergeFailed != null)
		{
			MergeFailed(this, mfevent);
			return;
		}
		throw ExceptionBuilder.MergeFailed(mfevent.Conflict);
	}

	internal void RaiseMergeFailed(DataTable table, string conflict, MissingSchemaAction missingSchemaAction)
	{
		if (MissingSchemaAction.Error == missingSchemaAction)
		{
			throw ExceptionBuilder.MergeFailed(conflict);
		}
		OnMergeFailed(new MergeFailedEventArgs(table, conflict));
	}

	internal void OnDataRowCreated(DataRow row)
	{
		DataRowCreated?.Invoke(this, row);
	}

	internal void OnClearFunctionCalled(DataTable table)
	{
		ClearFunctionCalled?.Invoke(this, table);
	}

	protected internal virtual void OnRemoveTable(DataTable table)
	{
	}

	internal void OnRemovedTable(DataTable table)
	{
		_defaultViewManager?.DataViewSettings.Remove(table);
	}

	protected virtual void OnRemoveRelation(DataRelation relation)
	{
	}

	internal void OnRemoveRelationHack(DataRelation relation)
	{
		OnRemoveRelation(relation);
	}

	protected internal void RaisePropertyChanging(string name)
	{
		OnPropertyChanging(new PropertyChangedEventArgs(name));
	}

	internal DataTable[] TopLevelTables()
	{
		return TopLevelTables(forSchema: false);
	}

	internal DataTable[] TopLevelTables(bool forSchema)
	{
		List<DataTable> list = new List<DataTable>();
		if (forSchema)
		{
			for (int i = 0; i < Tables.Count; i++)
			{
				DataTable dataTable = Tables[i];
				if (dataTable.NestedParentsCount > 1 || dataTable.SelfNested)
				{
					list.Add(dataTable);
				}
			}
		}
		for (int j = 0; j < Tables.Count; j++)
		{
			DataTable dataTable2 = Tables[j];
			if (dataTable2.NestedParentsCount == 0 && !list.Contains(dataTable2))
			{
				list.Add(dataTable2);
			}
		}
		if (list.Count != 0)
		{
			return list.ToArray();
		}
		return Array.Empty<DataTable>();
	}

	public virtual void Reset()
	{
		long scopeId = DataCommonEventSource.Log.EnterScope("<ds.DataSet.Reset|API> {0}", ObjectID);
		try
		{
			for (int i = 0; i < Tables.Count; i++)
			{
				ConstraintCollection constraints = Tables[i].Constraints;
				int num = 0;
				while (num < constraints.Count)
				{
					if (constraints[num] is ForeignKeyConstraint)
					{
						constraints.Remove(constraints[num]);
					}
					else
					{
						num++;
					}
				}
			}
			Clear();
			Relations.Clear();
			Tables.Clear();
		}
		finally
		{
			DataCommonEventSource.Log.ExitScope(scopeId);
		}
	}

	internal bool ValidateCaseConstraint()
	{
		long scopeId = DataCommonEventSource.Log.EnterScope("<ds.DataSet.ValidateCaseConstraint|INFO> {0}", ObjectID);
		try
		{
			DataRelation dataRelation = null;
			for (int i = 0; i < Relations.Count; i++)
			{
				dataRelation = Relations[i];
				if (dataRelation.ChildTable.CaseSensitive != dataRelation.ParentTable.CaseSensitive)
				{
					return false;
				}
			}
			for (int j = 0; j < Tables.Count; j++)
			{
				ConstraintCollection constraints = Tables[j].Constraints;
				for (int k = 0; k < constraints.Count; k++)
				{
					if (constraints[k] is ForeignKeyConstraint)
					{
						ForeignKeyConstraint foreignKeyConstraint = (ForeignKeyConstraint)constraints[k];
						if (foreignKeyConstraint.Table.CaseSensitive != foreignKeyConstraint.RelatedTable.CaseSensitive)
						{
							return false;
						}
					}
				}
			}
			return true;
		}
		finally
		{
			DataCommonEventSource.Log.ExitScope(scopeId);
		}
	}

	internal bool ValidateLocaleConstraint()
	{
		long scopeId = DataCommonEventSource.Log.EnterScope("<ds.DataSet.ValidateLocaleConstraint|INFO> {0}", ObjectID);
		try
		{
			DataRelation dataRelation = null;
			for (int i = 0; i < Relations.Count; i++)
			{
				dataRelation = Relations[i];
				if (dataRelation.ChildTable.Locale.LCID != dataRelation.ParentTable.Locale.LCID)
				{
					return false;
				}
			}
			for (int j = 0; j < Tables.Count; j++)
			{
				ConstraintCollection constraints = Tables[j].Constraints;
				for (int k = 0; k < constraints.Count; k++)
				{
					if (constraints[k] is ForeignKeyConstraint)
					{
						ForeignKeyConstraint foreignKeyConstraint = (ForeignKeyConstraint)constraints[k];
						if (foreignKeyConstraint.Table.Locale.LCID != foreignKeyConstraint.RelatedTable.Locale.LCID)
						{
							return false;
						}
					}
				}
			}
			return true;
		}
		finally
		{
			DataCommonEventSource.Log.ExitScope(scopeId);
		}
	}

	internal static DataTable FindTable(DataTable baseTable, PropertyDescriptor[] props, int propStart)
	{
		if (props.Length < propStart + 1)
		{
			return baseTable;
		}
		PropertyDescriptor propertyDescriptor = props[propStart];
		if (baseTable == null)
		{
			if (propertyDescriptor is DataTablePropertyDescriptor)
			{
				return FindTable(((DataTablePropertyDescriptor)propertyDescriptor).Table, props, propStart + 1);
			}
			return null;
		}
		if (propertyDescriptor is DataRelationPropertyDescriptor)
		{
			return FindTable(((DataRelationPropertyDescriptor)propertyDescriptor).Relation.ChildTable, props, propStart + 1);
		}
		return null;
	}

	public static XmlSchemaComplexType GetDataSetSchema(XmlSchemaSet? schemaSet)
	{
		if (s_schemaTypeForWSDL == null)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			XmlSchemaAny item = new XmlSchemaAny
			{
				Namespace = "http://www.w3.org/2001/XMLSchema",
				MinOccurs = 0m,
				ProcessContents = XmlSchemaContentProcessing.Lax
			};
			xmlSchemaSequence.Items.Add(item);
			item = new XmlSchemaAny
			{
				Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
				MinOccurs = 0m,
				ProcessContents = XmlSchemaContentProcessing.Lax
			};
			xmlSchemaSequence.Items.Add(item);
			xmlSchemaSequence.MaxOccurs = decimal.MaxValue;
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			s_schemaTypeForWSDL = xmlSchemaComplexType;
		}
		return s_schemaTypeForWSDL;
	}

	XmlSchema IXmlSerializable.GetSchema()
	{
		_ = 0;
		throw new NotSupportedException("DataSet_XmlSerializationUnsupported");
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
}
