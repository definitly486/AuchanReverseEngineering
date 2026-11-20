namespace Auchan.Common.Profile.Stores.Models;

public class FullStoreServiceModel
{
	public int Id { get; set; }

	public string Name { get; set; } = string.Empty;

	public string Icon { get; set; } = string.Empty;

	public override bool Equals(object obj)
	{
		if (!(obj is FullStoreServiceModel fullStoreServiceModel))
		{
			return false;
		}
		if (this == fullStoreServiceModel)
		{
			return true;
		}
		return Id.Equals(fullStoreServiceModel.Id);
	}

	public override int GetHashCode()
	{
		int hashCode = Name.GetHashCode();
		int hashCode2 = Id.GetHashCode();
		return hashCode ^ hashCode2;
	}
}
