namespace System.IO.Packaging;

public class PackageRelationship
{
	private Package _package;

	private PackagePart _source;

	private Uri _targetUri;

	private string _relationshipType;

	private TargetMode _targetMode;

	private string _id;

	private static readonly Uri s_containerRelationshipPartName = PackUriHelper.CreatePartUri(new Uri("/_rels/.rels", UriKind.Relative));

	public Uri TargetUri => _targetUri;

	public string RelationshipType => _relationshipType;

	public TargetMode TargetMode => _targetMode;

	public string Id => _id;

	internal static Uri ContainerRelationshipPartName => s_containerRelationshipPartName;

	internal PackageRelationship(Package package, PackagePart sourcePart, Uri targetUri, TargetMode targetMode, string relationshipType, string id)
	{
		if (package == null)
		{
			throw new ArgumentNullException("package");
		}
		if (targetUri == null)
		{
			throw new ArgumentNullException("targetUri");
		}
		if (relationshipType == null)
		{
			throw new ArgumentNullException("relationshipType");
		}
		if (id == null)
		{
			throw new ArgumentNullException("id");
		}
		_package = package;
		_source = sourcePart;
		_targetUri = targetUri;
		_relationshipType = relationshipType;
		_targetMode = targetMode;
		_id = id;
	}
}
