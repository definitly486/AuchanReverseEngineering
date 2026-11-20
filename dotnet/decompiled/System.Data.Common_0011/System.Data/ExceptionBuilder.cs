using System.ComponentModel;
using System.Data.Common;
using System.Globalization;

namespace System.Data;

internal static class ExceptionBuilder
{
	private static void TraceException(string trace, Exception e)
	{
		if (e != null)
		{
			DataCommonEventSource.Log.Trace(trace, e);
		}
	}

	internal static Exception TraceExceptionAsReturnValue(Exception e)
	{
		TraceException("<comm.ADP.TraceException|ERR|THROW> '{0}'", e);
		return e;
	}

	internal static Exception TraceExceptionForCapture(Exception e)
	{
		TraceException("<comm.ADP.TraceException|ERR|CATCH> '{0}'", e);
		return e;
	}

	internal static Exception TraceExceptionWithoutRethrow(Exception e)
	{
		TraceException("<comm.ADP.TraceException|ERR|CATCH> '{0}'", e);
		return e;
	}

	internal static Exception _Argument(string error)
	{
		return TraceExceptionAsReturnValue(new ArgumentException(error));
	}

	internal static Exception _Argument(string error, Exception innerException)
	{
		return TraceExceptionAsReturnValue(new ArgumentException(error, innerException));
	}

	private static Exception _ArgumentNull(string paramName, string msg)
	{
		return TraceExceptionAsReturnValue(new ArgumentNullException(paramName, msg));
	}

	internal static Exception _ArgumentOutOfRange(string paramName, string msg)
	{
		return TraceExceptionAsReturnValue(new ArgumentOutOfRangeException(paramName, msg));
	}

	private static Exception _IndexOutOfRange(string error)
	{
		return TraceExceptionAsReturnValue(new IndexOutOfRangeException(error));
	}

	private static Exception _InvalidOperation(string error)
	{
		return TraceExceptionAsReturnValue(new InvalidOperationException(error));
	}

	private static Exception _InvalidEnumArgumentException(string error)
	{
		return TraceExceptionAsReturnValue(new InvalidEnumArgumentException(error));
	}

	private static Exception _InvalidEnumArgumentException<T>(T value) where T : Enum
	{
		return _InvalidEnumArgumentException(System.SR.Format("ADP_InvalidEnumerationValue", typeof(T).Name, value.ToString()));
	}

	private static void ThrowDataException(string error, Exception innerException)
	{
		throw TraceExceptionAsReturnValue(new DataException(error, innerException));
	}

	private static Exception _Data(string error)
	{
		return TraceExceptionAsReturnValue(new DataException(error));
	}

	private static Exception _Constraint(string error)
	{
		return TraceExceptionAsReturnValue(new ConstraintException(error));
	}

	private static Exception _InvalidConstraint(string error)
	{
		return TraceExceptionAsReturnValue(new InvalidConstraintException(error));
	}

	private static Exception _DeletedRowInaccessible(string error)
	{
		return TraceExceptionAsReturnValue(new DeletedRowInaccessibleException(error));
	}

	private static Exception _DuplicateName(string error)
	{
		return TraceExceptionAsReturnValue(new DuplicateNameException(error));
	}

	private static Exception _InRowChangingEvent(string error)
	{
		return TraceExceptionAsReturnValue(new InRowChangingEventException(error));
	}

	private static Exception _NoNullAllowed(string error)
	{
		return TraceExceptionAsReturnValue(new NoNullAllowedException(error));
	}

	private static Exception _ReadOnly(string error)
	{
		return TraceExceptionAsReturnValue(new ReadOnlyException(error));
	}

	private static Exception _RowNotInTable(string error)
	{
		return TraceExceptionAsReturnValue(new RowNotInTableException(error));
	}

	private static Exception _VersionNotFound(string error)
	{
		return TraceExceptionAsReturnValue(new VersionNotFoundException(error));
	}

	public static Exception ArgumentNull(string paramName)
	{
		return _ArgumentNull(paramName, System.SR.Format("Data_ArgumentNull", paramName));
	}

	public static Exception ArgumentOutOfRange(string paramName)
	{
		return _ArgumentOutOfRange(paramName, System.SR.Format("Data_ArgumentOutOfRange", paramName));
	}

	public static Exception BadObjectPropertyAccess(string error)
	{
		return _InvalidOperation(System.SR.Format("DataConstraint_BadObjectPropertyAccess", error));
	}

	public static Exception TypeNotAllowed(Type type)
	{
		return _InvalidOperation(System.SR.Format("Data_TypeNotAllowed", type.AssemblyQualifiedName));
	}

	public static Exception CannotModifyCollection()
	{
		return _Argument("Data_CannotModifyCollection");
	}

	public static Exception CaseInsensitiveNameConflict(string name)
	{
		return _Argument(System.SR.Format("Data_CaseInsensitiveNameConflict", name));
	}

	public static Exception NamespaceNameConflict(string name)
	{
		return _Argument(System.SR.Format("Data_NamespaceNameConflict", name));
	}

	public static Exception InvalidOffsetLength()
	{
		return _Argument("Data_InvalidOffsetLength");
	}

	public static Exception ColumnNotInTheTable(string column, string table)
	{
		return _Argument(System.SR.Format("DataColumn_NotInTheTable", column, table));
	}

	public static Exception ColumnNotInAnyTable()
	{
		return _Argument("DataColumn_NotInAnyTable");
	}

	public static Exception ColumnOutOfRange(int index)
	{
		return _IndexOutOfRange(System.SR.Format("DataColumns_OutOfRange", index.ToString(CultureInfo.InvariantCulture)));
	}

	public static Exception ColumnOutOfRange(string column)
	{
		return _IndexOutOfRange(System.SR.Format("DataColumns_OutOfRange", column));
	}

	public static Exception CannotAddColumn1(string column)
	{
		return _Argument(System.SR.Format("DataColumns_Add1", column));
	}

	public static Exception CannotAddColumn2(string column)
	{
		return _Argument(System.SR.Format("DataColumns_Add2", column));
	}

	public static Exception CannotAddColumn3()
	{
		return _Argument("DataColumns_Add3");
	}

	public static Exception CannotAddColumn4(string column)
	{
		return _Argument(System.SR.Format("DataColumns_Add4", column));
	}

	public static Exception CannotAddDuplicate(string column)
	{
		return _DuplicateName(System.SR.Format("DataColumns_AddDuplicate", column));
	}

	public static Exception CannotAddDuplicate2(string table)
	{
		return _DuplicateName(System.SR.Format("DataColumns_AddDuplicate2", table));
	}

	public static Exception CannotAddDuplicate3(string table)
	{
		return _DuplicateName(System.SR.Format("DataColumns_AddDuplicate3", table));
	}

	public static Exception CannotRemoveColumn()
	{
		return _Argument("DataColumns_Remove");
	}

	public static Exception CannotRemovePrimaryKey()
	{
		return _Argument("DataColumns_RemovePrimaryKey");
	}

	public static Exception CannotRemoveChildKey(string relation)
	{
		return _Argument(System.SR.Format("DataColumns_RemoveChildKey", relation));
	}

	public static Exception CannotRemoveConstraint(string constraint, string table)
	{
		return _Argument(System.SR.Format("DataColumns_RemoveConstraint", constraint, table));
	}

	public static Exception CannotRemoveExpression(string column, string expression)
	{
		return _Argument(System.SR.Format("DataColumns_RemoveExpression", column, expression));
	}

	public static Exception AddPrimaryKeyConstraint()
	{
		return _Argument("DataConstraint_AddPrimaryKeyConstraint");
	}

	public static Exception NoConstraintName()
	{
		return _Argument("DataConstraint_NoName");
	}

	public static Exception ConstraintViolation(string constraint)
	{
		return _Constraint(System.SR.Format("DataConstraint_Violation", constraint));
	}

	public static string KeysToString(object[] keys)
	{
		string text = string.Empty;
		for (int i = 0; i < keys.Length; i++)
		{
			text = text + Convert.ToString(keys[i], null) + ((i < keys.Length - 1) ? ", " : string.Empty);
		}
		return text;
	}

	public static string UniqueConstraintViolationText(DataColumn[] columns, object[] values)
	{
		if (columns.Length > 1)
		{
			string text = string.Empty;
			for (int i = 0; i < columns.Length; i++)
			{
				text = text + columns[i].ColumnName + ((i < columns.Length - 1) ? ", " : "");
			}
			return System.SR.Format("DataConstraint_ViolationValue", text, KeysToString(values));
		}
		return System.SR.Format("DataConstraint_ViolationValue", columns[0].ColumnName, Convert.ToString(values[0], null));
	}

	public static Exception ConstraintViolation(DataColumn[] columns, object[] values)
	{
		return _Constraint(UniqueConstraintViolationText(columns, values));
	}

	public static Exception ConstraintOutOfRange(int index)
	{
		return _IndexOutOfRange(System.SR.Format("DataConstraint_OutOfRange", index.ToString(CultureInfo.InvariantCulture)));
	}

	public static Exception DuplicateConstraint(string constraint)
	{
		return _Data(System.SR.Format("DataConstraint_Duplicate", constraint));
	}

	public static Exception DuplicateConstraintName(string constraint)
	{
		return _DuplicateName(System.SR.Format("DataConstraint_DuplicateName", constraint));
	}

	public static Exception NeededForForeignKeyConstraint(UniqueConstraint key, ForeignKeyConstraint fk)
	{
		return _Argument(System.SR.Format("DataConstraint_NeededForForeignKeyConstraint", key.ConstraintName, fk.ConstraintName));
	}

	public static Exception UniqueConstraintViolation()
	{
		return _Argument("DataConstraint_UniqueViolation");
	}

	public static Exception ConstraintForeignTable()
	{
		return _Argument("DataConstraint_ForeignTable");
	}

	public static Exception ConstraintParentValues()
	{
		return _Argument("DataConstraint_ParentValues");
	}

	public static Exception ConstraintAddFailed(DataTable table)
	{
		return _InvalidConstraint(System.SR.Format("DataConstraint_AddFailed", table.TableName));
	}

	public static Exception ConstraintRemoveFailed()
	{
		return _Argument("DataConstraint_RemoveFailed");
	}

	public static Exception FailedCascadeDelete(string constraint)
	{
		return _InvalidConstraint(System.SR.Format("DataConstraint_CascadeDelete", constraint));
	}

	public static Exception FailedCascadeUpdate(string constraint)
	{
		return _InvalidConstraint(System.SR.Format("DataConstraint_CascadeUpdate", constraint));
	}

	public static Exception FailedClearParentTable(string table, string constraint, string childTable)
	{
		return _InvalidConstraint(System.SR.Format("DataConstraint_ClearParentTable", table, constraint, childTable));
	}

	public static Exception ForeignKeyViolation(string constraint, object[] keys)
	{
		return _InvalidConstraint(System.SR.Format("DataConstraint_ForeignKeyViolation", constraint, KeysToString(keys)));
	}

	public static Exception RemoveParentRow(ForeignKeyConstraint constraint)
	{
		return _InvalidConstraint(System.SR.Format("DataConstraint_RemoveParentRow", constraint.ConstraintName));
	}

	public static string MaxLengthViolationText(string columnName)
	{
		return System.SR.Format("DataColumn_ExceedMaxLength", columnName);
	}

	public static string NotAllowDBNullViolationText(string columnName)
	{
		return System.SR.Format("DataColumn_NotAllowDBNull", columnName);
	}

	public static Exception CantAddConstraintToMultipleNestedTable(string tableName)
	{
		return _Argument(System.SR.Format("DataConstraint_CantAddConstraintToMultipleNestedTable", tableName));
	}

	public static Exception AutoIncrementAndExpression()
	{
		return _Argument("DataColumn_AutoIncrementAndExpression");
	}

	public static Exception AutoIncrementAndDefaultValue()
	{
		return _Argument("DataColumn_AutoIncrementAndDefaultValue");
	}

	public static Exception AutoIncrementSeed()
	{
		return _Argument("DataColumn_AutoIncrementSeed");
	}

	public static Exception CantChangeDataType()
	{
		return _Argument("DataColumn_ChangeDataType");
	}

	public static Exception NullDataType()
	{
		return _Argument("DataColumn_NullDataType");
	}

	public static Exception ColumnNameRequired()
	{
		return _Argument("DataColumn_NameRequired");
	}

	public static Exception DefaultValueAndAutoIncrement()
	{
		return _Argument("DataColumn_DefaultValueAndAutoIncrement");
	}

	public static Exception DefaultValueDataType(string column, Type defaultType, Type columnType, Exception inner)
	{
		if (column.Length != 0)
		{
			return _Argument(System.SR.Format("DataColumn_DefaultValueDataType", column, defaultType.FullName, columnType.FullName), inner);
		}
		return _Argument(System.SR.Format("DataColumn_DefaultValueDataType1", defaultType.FullName, columnType.FullName), inner);
	}

	public static Exception DefaultValueColumnDataType(string column, Type defaultType, Type columnType, Exception inner)
	{
		return _Argument(System.SR.Format("DataColumn_DefaultValueColumnDataType", column, defaultType.FullName, columnType.FullName), inner);
	}

	public static Exception ExpressionAndUnique()
	{
		return _Argument("DataColumn_ExpressionAndUnique");
	}

	public static Exception ExpressionAndReadOnly()
	{
		return _Argument("DataColumn_ExpressionAndReadOnly");
	}

	public static Exception ExpressionAndConstraint(DataColumn column, Constraint constraint)
	{
		return _Argument(System.SR.Format("DataColumn_ExpressionAndConstraint", column.ColumnName, constraint.ConstraintName));
	}

	public static Exception ExpressionInConstraint(DataColumn column)
	{
		return _Argument(System.SR.Format("DataColumn_ExpressionInConstraint", column.ColumnName));
	}

	public static Exception ExpressionCircular()
	{
		return _Argument("DataColumn_ExpressionCircular");
	}

	public static Exception NonUniqueValues(string column)
	{
		return _InvalidConstraint(System.SR.Format("DataColumn_NonUniqueValues", column));
	}

	public static Exception NullKeyValues(string column)
	{
		return _Data(System.SR.Format("DataColumn_NullKeyValues", column));
	}

	public static Exception NullValues(string column)
	{
		return _NoNullAllowed(System.SR.Format("DataColumn_NullValues", column));
	}

	public static Exception ReadOnlyAndExpression()
	{
		return _ReadOnly("DataColumn_ReadOnlyAndExpression");
	}

	public static Exception ReadOnly(string column)
	{
		return _ReadOnly(System.SR.Format("DataColumn_ReadOnly", column));
	}

	public static Exception UniqueAndExpression()
	{
		return _Argument("DataColumn_UniqueAndExpression");
	}

	public static Exception SetFailed(object value, DataColumn column, Type type, Exception innerException)
	{
		return _Argument(innerException.Message + System.SR.Format("DataColumn_SetFailed", value?.ToString(), column.ColumnName, type.Name), innerException);
	}

	public static Exception CannotSetToNull(DataColumn column)
	{
		return _Argument(System.SR.Format("DataColumn_CannotSetToNull", column.ColumnName));
	}

	public static Exception LongerThanMaxLength(DataColumn column)
	{
		return _Argument(System.SR.Format("DataColumn_LongerThanMaxLength", column.ColumnName));
	}

	public static Exception CannotSetMaxLength(DataColumn column, int value)
	{
		return _Argument(System.SR.Format("DataColumn_CannotSetMaxLength", column.ColumnName, value.ToString(CultureInfo.InvariantCulture)));
	}

	public static Exception CannotSetMaxLength2(DataColumn column)
	{
		return _Argument(System.SR.Format("DataColumn_CannotSetMaxLength2", column.ColumnName));
	}

	public static Exception CannotSetSimpleContentType(string columnName, Type type)
	{
		return _Argument(System.SR.Format("DataColumn_CannotSimpleContentType", columnName, type));
	}

	public static Exception CannotSetSimpleContent(string columnName, Type type)
	{
		return _Argument(System.SR.Format("DataColumn_CannotSimpleContent", columnName, type));
	}

	public static Exception CannotChangeNamespace(string columnName)
	{
		return _Argument(System.SR.Format("DataColumn_CannotChangeNamespace", columnName));
	}

	public static Exception HasToBeStringType(DataColumn column)
	{
		return _Argument(System.SR.Format("DataColumn_HasToBeStringType", column.ColumnName));
	}

	public static Exception AutoIncrementCannotSetIfHasData(string typeName)
	{
		return _Argument(System.SR.Format("DataColumn_AutoIncrementCannotSetIfHasData", typeName));
	}

	public static Exception INullableUDTwithoutStaticNull(string typeName)
	{
		return _Argument(System.SR.Format("DataColumn_INullableUDTwithoutStaticNull", typeName));
	}

	public static Exception IComparableNotImplemented(string typeName)
	{
		return _Data(System.SR.Format("DataStorage_IComparableNotDefined", typeName));
	}

	public static Exception UDTImplementsIChangeTrackingButnotIRevertible(string typeName)
	{
		return _InvalidOperation(System.SR.Format("DataColumn_UDTImplementsIChangeTrackingButnotIRevertible", typeName));
	}

	public static Exception InvalidDataColumnMapping(Type type)
	{
		return _Argument(System.SR.Format("DataColumn_InvalidDataColumnMapping", type.AssemblyQualifiedName));
	}

	public static Exception CannotSetDateTimeModeForNonDateTimeColumns()
	{
		return _InvalidOperation("DataColumn_CannotSetDateTimeModeForNonDateTimeColumns");
	}

	public static Exception InvalidDateTimeMode(DataSetDateTime mode)
	{
		return _InvalidEnumArgumentException(mode);
	}

	public static Exception CantChangeDateTimeMode(DataSetDateTime oldValue, DataSetDateTime newValue)
	{
		return _InvalidOperation(System.SR.Format("DataColumn_DateTimeMode", oldValue.ToString(), newValue.ToString()));
	}

	public static Exception ColumnTypeNotSupported()
	{
		return ADP.NotSupported("DataColumn_NullableTypesNotSupported");
	}

	public static Exception SetFailed(string name)
	{
		return _Data(System.SR.Format("DataView_SetFailed", name));
	}

	public static Exception SetDataSetFailed()
	{
		return _Data("DataView_SetDataSetFailed");
	}

	public static Exception SetRowStateFilter()
	{
		return _Data("DataView_SetRowStateFilter");
	}

	public static Exception CanNotSetDataSet()
	{
		return _Data("DataView_CanNotSetDataSet");
	}

	public static Exception CanNotUseDataViewManager()
	{
		return _Data("DataView_CanNotUseDataViewManager");
	}

	public static Exception CanNotSetTable()
	{
		return _Data("DataView_CanNotSetTable");
	}

	public static Exception CanNotUse()
	{
		return _Data("DataView_CanNotUse");
	}

	public static Exception CanNotBindTable()
	{
		return _Data("DataView_CanNotBindTable");
	}

	public static Exception SetTable()
	{
		return _Data("DataView_SetTable");
	}

	public static Exception SetIListObject()
	{
		return _Argument("DataView_SetIListObject");
	}

	public static Exception AddNewNotAllowNull()
	{
		return _Data("DataView_AddNewNotAllowNull");
	}

	public static Exception NotOpen()
	{
		return _Data("DataView_NotOpen");
	}

	public static Exception CreateChildView()
	{
		return _Argument("DataView_CreateChildView");
	}

	public static Exception CanNotDelete()
	{
		return _Data("DataView_CanNotDelete");
	}

	public static Exception CanNotEdit()
	{
		return _Data("DataView_CanNotEdit");
	}

	public static Exception GetElementIndex(int index)
	{
		return _IndexOutOfRange(System.SR.Format("DataView_GetElementIndex", index.ToString(CultureInfo.InvariantCulture)));
	}

	public static Exception AddExternalObject()
	{
		return _Argument("DataView_AddExternalObject");
	}

	public static Exception CanNotClear()
	{
		return _Argument("DataView_CanNotClear");
	}

	public static Exception InsertExternalObject()
	{
		return _Argument("DataView_InsertExternalObject");
	}

	public static Exception RemoveExternalObject()
	{
		return _Argument("DataView_RemoveExternalObject");
	}

	public static Exception PropertyNotFound(string property, string table)
	{
		return _Argument(System.SR.Format("DataROWView_PropertyNotFound", property, table));
	}

	public static Exception KeyTableMismatch()
	{
		return _InvalidConstraint("DataKey_TableMismatch");
	}

	public static Exception KeyNoColumns()
	{
		return _InvalidConstraint("DataKey_NoColumns");
	}

	public static Exception KeyTooManyColumns(int cols)
	{
		return _InvalidConstraint(System.SR.Format("DataKey_TooManyColumns", cols.ToString(CultureInfo.InvariantCulture)));
	}

	public static Exception KeyDuplicateColumns(string columnName)
	{
		return _InvalidConstraint(System.SR.Format("DataKey_DuplicateColumns", columnName));
	}

	public static Exception RelationDataSetMismatch()
	{
		return _InvalidConstraint("DataRelation_DataSetMismatch");
	}

	public static Exception NoRelationName()
	{
		return _Argument("DataRelation_NoName");
	}

	public static Exception ColumnsTypeMismatch()
	{
		return _InvalidConstraint("DataRelation_ColumnsTypeMismatch");
	}

	public static Exception KeyLengthMismatch()
	{
		return _Argument("DataRelation_KeyLengthMismatch");
	}

	public static Exception KeyLengthZero()
	{
		return _Argument("DataRelation_KeyZeroLength");
	}

	public static Exception ForeignRelation()
	{
		return _Argument("DataRelation_ForeignDataSet");
	}

	public static Exception KeyColumnsIdentical()
	{
		return _InvalidConstraint("DataRelation_KeyColumnsIdentical");
	}

	public static Exception RelationForeignTable(string t1, string t2)
	{
		return _InvalidConstraint(System.SR.Format("DataRelation_ForeignTable", t1, t2));
	}

	public static Exception GetParentRowTableMismatch(string t1, string t2)
	{
		return _InvalidConstraint(System.SR.Format("DataRelation_GetParentRowTableMismatch", t1, t2));
	}

	public static Exception SetParentRowTableMismatch(string t1, string t2)
	{
		return _InvalidConstraint(System.SR.Format("DataRelation_SetParentRowTableMismatch", t1, t2));
	}

	public static Exception RelationForeignRow()
	{
		return _Argument("DataRelation_ForeignRow");
	}

	public static Exception RelationNestedReadOnly()
	{
		return _Argument("DataRelation_RelationNestedReadOnly");
	}

	public static Exception TableCantBeNestedInTwoTables(string tableName)
	{
		return _Argument(System.SR.Format("DataRelation_TableCantBeNestedInTwoTables", tableName));
	}

	public static Exception LoopInNestedRelations(string tableName)
	{
		return _Argument(System.SR.Format("DataRelation_LoopInNestedRelations", tableName));
	}

	public static Exception RelationDoesNotExist()
	{
		return _Argument("DataRelation_DoesNotExist");
	}

	public static Exception ParentOrChildColumnsDoNotHaveDataSet()
	{
		return _InvalidConstraint("DataRelation_ParentOrChildColumnsDoNotHaveDataSet");
	}

	public static Exception InValidNestedRelation(string childTableName)
	{
		return _InvalidOperation(System.SR.Format("DataRelation_InValidNestedRelation", childTableName));
	}

	public static Exception InvalidParentNamespaceinNestedRelation(string childTableName)
	{
		return _InvalidOperation(System.SR.Format("DataRelation_InValidNamespaceInNestedRelation", childTableName));
	}

	public static Exception RowNotInTheDataSet()
	{
		return _Argument("DataRow_NotInTheDataSet");
	}

	public static Exception RowNotInTheTable()
	{
		return _RowNotInTable("DataRow_NotInTheTable");
	}

	public static Exception EditInRowChanging()
	{
		return _InRowChangingEvent("DataRow_EditInRowChanging");
	}

	public static Exception EndEditInRowChanging()
	{
		return _InRowChangingEvent("DataRow_EndEditInRowChanging");
	}

	public static Exception BeginEditInRowChanging()
	{
		return _InRowChangingEvent("DataRow_BeginEditInRowChanging");
	}

	public static Exception CancelEditInRowChanging()
	{
		return _InRowChangingEvent("DataRow_CancelEditInRowChanging");
	}

	public static Exception DeleteInRowDeleting()
	{
		return _InRowChangingEvent("DataRow_DeleteInRowDeleting");
	}

	public static Exception ValueArrayLength()
	{
		return _Argument("DataRow_ValuesArrayLength");
	}

	public static Exception NoCurrentData()
	{
		return _VersionNotFound("DataRow_NoCurrentData");
	}

	public static Exception NoOriginalData()
	{
		return _VersionNotFound("DataRow_NoOriginalData");
	}

	public static Exception NoProposedData()
	{
		return _VersionNotFound("DataRow_NoProposedData");
	}

	public static Exception RowRemovedFromTheTable()
	{
		return _RowNotInTable("DataRow_RemovedFromTheTable");
	}

	public static Exception DeletedRowInaccessible()
	{
		return _DeletedRowInaccessible("DataRow_DeletedRowInaccessible");
	}

	public static Exception RowAlreadyDeleted()
	{
		return _DeletedRowInaccessible("DataRow_AlreadyDeleted");
	}

	public static Exception RowEmpty()
	{
		return _Argument("DataRow_Empty");
	}

	public static Exception InvalidRowVersion()
	{
		return _Data("DataRow_InvalidVersion");
	}

	public static Exception RowOutOfRange(int index)
	{
		return _IndexOutOfRange(System.SR.Format("DataRow_OutOfRange", index.ToString(CultureInfo.InvariantCulture)));
	}

	public static Exception RowInsertTwice(int index, string tableName)
	{
		return _IndexOutOfRange(System.SR.Format("DataRow_RowInsertTwice", index.ToString(CultureInfo.InvariantCulture), tableName));
	}

	public static Exception RowInsertMissing(string tableName)
	{
		return _IndexOutOfRange(System.SR.Format("DataRow_RowInsertMissing", tableName));
	}

	public static Exception RowAlreadyRemoved()
	{
		return _Data("DataRow_AlreadyRemoved");
	}

	public static Exception MultipleParents()
	{
		return _Data("DataRow_MultipleParents");
	}

	public static Exception InvalidRowState(DataRowState state)
	{
		return _InvalidEnumArgumentException(state);
	}

	public static Exception InvalidRowBitPattern()
	{
		return _Argument("DataRow_InvalidRowBitPattern");
	}

	internal static Exception SetDataSetNameToEmpty()
	{
		return _Argument("DataSet_SetNameToEmpty");
	}

	internal static Exception SetDataSetNameConflicting(string name)
	{
		return _Argument(System.SR.Format("DataSet_SetDataSetNameConflicting", name));
	}

	public static Exception DataSetUnsupportedSchema(string ns)
	{
		return _Argument(System.SR.Format("DataSet_UnsupportedSchema", ns));
	}

	public static Exception MergeMissingDefinition(string obj)
	{
		return _Argument(System.SR.Format("DataMerge_MissingDefinition", obj));
	}

	public static Exception TablesInDifferentSets()
	{
		return _Argument("DataRelation_TablesInDifferentSets");
	}

	public static Exception RelationAlreadyExists()
	{
		return _Argument("DataRelation_AlreadyExists");
	}

	public static Exception RowAlreadyInOtherCollection()
	{
		return _Argument("DataRow_AlreadyInOtherCollection");
	}

	public static Exception RowAlreadyInTheCollection()
	{
		return _Argument("DataRow_AlreadyInTheCollection");
	}

	public static Exception RecordStateRange()
	{
		return _Argument("DataIndex_RecordStateRange");
	}

	public static Exception IndexKeyLength(int length, int keyLength)
	{
		if (length != 0)
		{
			return _Argument(System.SR.Format("DataIndex_KeyLength", length.ToString(CultureInfo.InvariantCulture), keyLength.ToString(CultureInfo.InvariantCulture)));
		}
		return _Argument("DataIndex_FindWithoutSortOrder");
	}

	public static Exception RemovePrimaryKey(DataTable table)
	{
		if (table.TableName.Length != 0)
		{
			return _Argument(System.SR.Format("DataKey_RemovePrimaryKey1", table.TableName));
		}
		return _Argument("DataKey_RemovePrimaryKey");
	}

	public static Exception RelationAlreadyInOtherDataSet()
	{
		return _Argument("DataRelation_AlreadyInOtherDataSet");
	}

	public static Exception RelationAlreadyInTheDataSet()
	{
		return _Argument("DataRelation_AlreadyInTheDataSet");
	}

	public static Exception RelationNotInTheDataSet(string relation)
	{
		return _Argument(System.SR.Format("DataRelation_NotInTheDataSet", relation));
	}

	public static Exception RelationOutOfRange(object index)
	{
		return _IndexOutOfRange(System.SR.Format("DataRelation_OutOfRange", Convert.ToString(index, null)));
	}

	public static Exception DuplicateRelation(string relation)
	{
		return _DuplicateName(System.SR.Format("DataRelation_DuplicateName", relation));
	}

	public static Exception RelationTableNull()
	{
		return _Argument("DataRelation_TableNull");
	}

	public static Exception RelationDataSetNull()
	{
		return _Argument("DataRelation_TableNull");
	}

	public static Exception RelationTableWasRemoved()
	{
		return _Argument("DataRelation_TableWasRemoved");
	}

	public static Exception ParentTableMismatch()
	{
		return _Argument("DataRelation_ParentTableMismatch");
	}

	public static Exception ChildTableMismatch()
	{
		return _Argument("DataRelation_ChildTableMismatch");
	}

	public static Exception EnforceConstraint()
	{
		return _Constraint("Data_EnforceConstraints");
	}

	public static Exception CaseLocaleMismatch()
	{
		return _Argument("DataRelation_CaseLocaleMismatch");
	}

	public static Exception CannotChangeCaseLocale()
	{
		return CannotChangeCaseLocale(null);
	}

	public static Exception CannotChangeCaseLocale(Exception innerException)
	{
		return _Argument("DataSet_CannotChangeCaseLocale", innerException);
	}

	public static Exception CannotChangeSchemaSerializationMode()
	{
		return _InvalidOperation("DataSet_CannotChangeSchemaSerializationMode");
	}

	public static Exception InvalidRemotingFormat(SerializationFormat mode)
	{
		return _InvalidEnumArgumentException(mode);
	}

	public static Exception SerializationFormatBinaryNotSupported()
	{
		return _InvalidEnumArgumentException(SerializationFormat.Binary);
	}

	public static Exception TableForeignPrimaryKey()
	{
		return _Argument("DataTable_ForeignPrimaryKey");
	}

	public static Exception TableCannotAddToSimpleContent()
	{
		return _Argument("DataTable_CannotAddToSimpleContent");
	}

	public static Exception NoTableName()
	{
		return _Argument("DataTable_NoName");
	}

	public static Exception MultipleTextOnlyColumns()
	{
		return _Argument("DataTable_MultipleSimpleContentColumns");
	}

	public static Exception InvalidSortString(string sort)
	{
		return _Argument(System.SR.Format("DataTable_InvalidSortString", sort));
	}

	public static Exception DuplicateTableName(string table)
	{
		return _DuplicateName(System.SR.Format("DataTable_DuplicateName", table));
	}

	public static Exception DuplicateTableName2(string table, string ns)
	{
		return _DuplicateName(System.SR.Format("DataTable_DuplicateName2", table, ns));
	}

	public static Exception SelfnestedDatasetConflictingName(string table)
	{
		return _DuplicateName(System.SR.Format("DataTable_SelfnestedDatasetConflictingName", table));
	}

	public static Exception DatasetConflictingName(string table)
	{
		return _DuplicateName(System.SR.Format("DataTable_DatasetConflictingName", table));
	}

	public static Exception TableAlreadyInOtherDataSet()
	{
		return _Argument("DataTable_AlreadyInOtherDataSet");
	}

	public static Exception TableAlreadyInTheDataSet()
	{
		return _Argument("DataTable_AlreadyInTheDataSet");
	}

	public static Exception TableOutOfRange(int index)
	{
		return _IndexOutOfRange(System.SR.Format("DataTable_OutOfRange", index.ToString(CultureInfo.InvariantCulture)));
	}

	public static Exception TableNotInTheDataSet(string table)
	{
		return _Argument(System.SR.Format("DataTable_NotInTheDataSet", table));
	}

	public static Exception TableInRelation()
	{
		return _Argument("DataTable_InRelation");
	}

	public static Exception TableInConstraint(DataTable table, Constraint constraint)
	{
		return _Argument(System.SR.Format("DataTable_InConstraint", table.TableName, constraint.ConstraintName));
	}

	public static Exception CanNotRemoteDataTable()
	{
		return _InvalidOperation("DataTable_CanNotRemoteDataTable");
	}

	public static Exception CanNotSetRemotingFormat()
	{
		return _Argument("DataTable_CanNotSetRemotingFormat");
	}

	public static Exception AggregateException(AggregateType aggregateType, Type type)
	{
		return _Data(System.SR.Format("DataStorage_AggregateException", aggregateType, type.Name));
	}

	public static Exception InvalidStorageType(TypeCode typecode)
	{
		return _Data(System.SR.Format("DataStorage_InvalidStorageType", typecode.ToString()));
	}

	public static Exception RangeArgument(int min, int max)
	{
		return _Argument(System.SR.Format("Range_Argument", min.ToString(CultureInfo.InvariantCulture), max.ToString(CultureInfo.InvariantCulture)));
	}

	public static Exception NullRange()
	{
		return _Data("Range_NullRange");
	}

	public static Exception NegativeMinimumCapacity()
	{
		return _Argument("RecordManager_MinimumCapacity");
	}

	public static Exception ProblematicChars(char charValue)
	{
		return _Argument(System.SR.Format("DataStorage_ProblematicChars", $"0x{charValue:X}"));
	}

	public static Exception StorageSetFailed()
	{
		return _Argument("DataStorage_SetInvalidDataType");
	}

	public static Exception SimpleTypeNotSupported()
	{
		return _Data("Xml_SimpleTypeNotSupported");
	}

	public static Exception MissingAttribute(string attribute)
	{
		return MissingAttribute(string.Empty, attribute);
	}

	public static Exception MissingAttribute(string element, string attribute)
	{
		return _Data(System.SR.Format("Xml_MissingAttribute", element, attribute));
	}

	public static Exception InvalidAttributeValue(string name, string value)
	{
		return _Data(System.SR.Format("Xml_ValueOutOfRange", name, value));
	}

	public static Exception AttributeValues(string name, string value1, string value2)
	{
		return _Data(System.SR.Format("Xml_AttributeValues", name, value1, value2));
	}

	public static Exception ElementTypeNotFound(string name)
	{
		return _Data(System.SR.Format("Xml_ElementTypeNotFound", name));
	}

	public static Exception RelationParentNameMissing(string rel)
	{
		return _Data(System.SR.Format("Xml_RelationParentNameMissing", rel));
	}

	public static Exception RelationChildNameMissing(string rel)
	{
		return _Data(System.SR.Format("Xml_RelationChildNameMissing", rel));
	}

	public static Exception RelationTableKeyMissing(string rel)
	{
		return _Data(System.SR.Format("Xml_RelationTableKeyMissing", rel));
	}

	public static Exception RelationChildKeyMissing(string rel)
	{
		return _Data(System.SR.Format("Xml_RelationChildKeyMissing", rel));
	}

	public static Exception UndefinedDatatype(string name)
	{
		return _Data(System.SR.Format("Xml_UndefinedDatatype", name));
	}

	public static Exception DatatypeNotDefined()
	{
		return _Data("Xml_DatatypeNotDefined");
	}

	public static Exception MismatchKeyLength()
	{
		return _Data("Xml_MismatchKeyLength");
	}

	public static Exception InvalidField(string name)
	{
		return _Data(System.SR.Format("Xml_InvalidField", name));
	}

	public static Exception InvalidSelector(string name)
	{
		return _Data(System.SR.Format("Xml_InvalidSelector", name));
	}

	public static Exception CircularComplexType(string name)
	{
		return _Data(System.SR.Format("Xml_CircularComplexType", name));
	}

	public static Exception CannotInstantiateAbstract(string name)
	{
		return _Data(System.SR.Format("Xml_CannotInstantiateAbstract", name));
	}

	public static Exception InvalidKey(string name)
	{
		return _Data(System.SR.Format("Xml_InvalidKey", name));
	}

	public static Exception DiffgramMissingSQL()
	{
		return _Data("Xml_MissingSQL");
	}

	public static Exception DuplicateConstraintRead(string str)
	{
		return _Data(System.SR.Format("Xml_DuplicateConstraint", str));
	}

	public static Exception ColumnTypeConflict(string name)
	{
		return _Data(System.SR.Format("Xml_ColumnConflict", name));
	}

	public static Exception CannotConvert(string name, string type)
	{
		return _Data(System.SR.Format("Xml_CannotConvert", name, type));
	}

	public static Exception MissingRefer(string name)
	{
		return _Data(System.SR.Format("Xml_MissingRefer", "refer", "keyref", name));
	}

	public static Exception InvalidPrefix(string name)
	{
		return _Data(System.SR.Format("Xml_InvalidPrefix_SpecialCharacters", name));
	}

	public static Exception CanNotDeserializeObjectType()
	{
		return _InvalidOperation("Xml_CanNotDeserializeObjectType");
	}

	public static Exception IsDataSetAttributeMissingInSchema()
	{
		return _Data("Xml_IsDataSetAttributeMissingInSchema");
	}

	public static Exception TooManyIsDataSetAttributesInSchema()
	{
		return _Data("Xml_TooManyIsDataSetAttributesInSchema");
	}

	public static Exception NestedCircular(string name)
	{
		return _Data(System.SR.Format("Xml_NestedCircular", name));
	}

	public static Exception MultipleParentRows(string tableQName)
	{
		return _Data(System.SR.Format("Xml_MultipleParentRows", tableQName));
	}

	public static Exception PolymorphismNotSupported(string typeName)
	{
		return _InvalidOperation(System.SR.Format("Xml_PolymorphismNotSupported", typeName));
	}

	internal static void ThrowMultipleTargetConverter(Exception innerException)
	{
		ThrowDataException((innerException != null) ? "Xml_MultipleTargetConverterError" : "Xml_MultipleTargetConverterEmpty", innerException);
	}

	public static Exception DuplicateDeclaration(string name)
	{
		return _Data(System.SR.Format("Xml_MergeDuplicateDeclaration", name));
	}

	public static Exception FoundEntity()
	{
		return _Data("Xml_FoundEntity");
	}

	public static Exception MergeFailed(string name)
	{
		return _Data(name);
	}

	public static Exception ConvertFailed(Type type1, Type type2)
	{
		return _Data(System.SR.Format("SqlConvert_ConvertFailed", type1.FullName, type2.FullName));
	}

	internal static Exception InvalidDuplicateNamedSimpleTypeDelaration(string stName, string errorStr)
	{
		return _Argument(System.SR.Format("NamedSimpleType_InvalidDuplicateNamedSimpleTypeDelaration", stName, errorStr));
	}

	internal static Exception InternalRBTreeError(RBTreeError internalError)
	{
		return _InvalidOperation(System.SR.Format("RbTree_InvalidState", (int)internalError));
	}

	public static Exception EnumeratorModified()
	{
		return _InvalidOperation("RbTree_EnumerationBroken");
	}
}
