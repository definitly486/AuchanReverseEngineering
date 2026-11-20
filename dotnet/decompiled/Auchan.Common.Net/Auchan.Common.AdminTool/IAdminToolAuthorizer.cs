using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Service;
using CSharpFunctionalExtensions;

namespace Auchan.Common.AdminTool;

public interface IAdminToolAuthorizer
{
	void InitializeUdidKeyAtAppStart(string udidKey);

	Task<Result<string, ServiceError>> UdidKey(CancellationToken cancellationToken = default(CancellationToken));
}
