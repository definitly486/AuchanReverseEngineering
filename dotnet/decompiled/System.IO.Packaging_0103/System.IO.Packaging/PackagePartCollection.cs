using System.Collections;
using System.Collections.Generic;

namespace System.IO.Packaging;

public class PackagePartCollection : IEnumerable<PackagePart>, IEnumerable
{
	private SortedList<PackUriHelper.ValidatedPartUri, PackagePart> _partList;

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	IEnumerator<PackagePart> IEnumerable<PackagePart>.GetEnumerator()
	{
		return GetEnumerator();
	}

	public IEnumerator<PackagePart> GetEnumerator()
	{
		return _partList.Values.GetEnumerator();
	}

	internal PackagePartCollection(SortedList<PackUriHelper.ValidatedPartUri, PackagePart> partList)
	{
		_partList = partList;
	}
}
