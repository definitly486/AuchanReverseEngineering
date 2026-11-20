namespace DryIoc;

public enum RegistrySharing : byte
{
	Share,
	CloneButKeepCache,
	CloneAndDropCache
}
