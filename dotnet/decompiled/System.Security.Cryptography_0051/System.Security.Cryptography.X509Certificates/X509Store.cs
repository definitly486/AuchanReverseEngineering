namespace System.Security.Cryptography.X509Certificates;

public sealed class X509Store : IDisposable
{
	private IStorePal _storePal;

	public StoreLocation Location { get; }

	public string? Name { get; }

	public X509Certificate2Collection Certificates
	{
		get
		{
			X509Certificate2Collection x509Certificate2Collection = new X509Certificate2Collection();
			_storePal?.CloneTo(x509Certificate2Collection);
			return x509Certificate2Collection;
		}
	}

	public X509Store(StoreName storeName, StoreLocation storeLocation)
	{
		if (storeLocation != StoreLocation.CurrentUser && storeLocation != StoreLocation.LocalMachine)
		{
			throw new ArgumentException(System.SR.Format("Arg_EnumIllegalVal", "storeLocation"));
		}
		Name = storeName switch
		{
			StoreName.AddressBook => "AddressBook", 
			StoreName.AuthRoot => "AuthRoot", 
			StoreName.CertificateAuthority => "CA", 
			StoreName.Disallowed => "Disallowed", 
			StoreName.My => "My", 
			StoreName.Root => "Root", 
			StoreName.TrustedPeople => "TrustedPeople", 
			StoreName.TrustedPublisher => "TrustedPublisher", 
			_ => throw new ArgumentException(System.SR.Format("Arg_EnumIllegalVal", "storeName")), 
		};
		Location = storeLocation;
	}

	public void Open(OpenFlags flags)
	{
		Close();
		_storePal = StorePal.FromSystemStore(Name, Location, flags);
	}

	public void Dispose()
	{
		Close();
	}

	public void Close()
	{
		IStorePal storePal = _storePal;
		if (storePal != null)
		{
			_storePal = null;
			storePal.Dispose();
		}
	}
}
