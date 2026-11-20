using System.Collections.Generic;

namespace System.Data;

internal sealed class RelatedView : DataView, IFilter
{
	private readonly DataKey? _parentKey;

	private readonly DataKey _childKey;

	private readonly DataRowView _parentRowView;

	private readonly object[] _filterValues;

	public RelatedView(DataColumn[] columns, object[] values)
		: base(columns[0].Table, locked: false)
	{
		if (values == null)
		{
			throw ExceptionBuilder.ArgumentNull("values");
		}
		_parentRowView = null;
		_parentKey = null;
		_childKey = new DataKey(columns, copyColumns: true);
		_filterValues = values;
		ResetRowViewCache();
	}

	public RelatedView(DataRowView parentRowView, DataKey parentKey, DataColumn[] childKeyColumns)
		: base(childKeyColumns[0].Table, locked: false)
	{
		_filterValues = null;
		_parentRowView = parentRowView;
		_parentKey = parentKey;
		_childKey = new DataKey(childKeyColumns, copyColumns: true);
		ResetRowViewCache();
	}

	private object[] GetParentValues()
	{
		if (_filterValues != null)
		{
			return _filterValues;
		}
		if (!_parentRowView.HasRecord())
		{
			return null;
		}
		return _parentKey.Value.GetKeyValues(_parentRowView.GetRecord());
	}

	public bool Invoke(DataRow row, DataRowVersion version)
	{
		object[] parentValues = GetParentValues();
		if (parentValues == null)
		{
			return false;
		}
		bool flag = ((ReadOnlySpan<object>)row.GetKeyValues(_childKey, version).AsSpan()).SequenceEqual((ReadOnlySpan<object>)parentValues, (IEqualityComparer<object>?)null);
		IFilter filter = base.GetFilter();
		if (filter != null)
		{
			flag &= filter.Invoke(row, version);
		}
		return flag;
	}

	internal override IFilter GetFilter()
	{
		return this;
	}

	public override DataRowView AddNew()
	{
		DataRowView dataRowView = base.AddNew();
		dataRowView.Row.SetKeyValues(_childKey, GetParentValues());
		return dataRowView;
	}

	internal override void SetIndex(string newSort, DataViewRowState newRowStates, IFilter newRowFilter)
	{
		SetIndex2(newSort, newRowStates, newRowFilter, fireEvent: false);
		Reset();
	}
}
