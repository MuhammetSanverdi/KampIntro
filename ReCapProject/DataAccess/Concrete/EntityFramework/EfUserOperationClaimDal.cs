using Core.DataAccess;
using Core.Entities.Concrete;
using DataAccess.Absract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, CarRentalContext>, IUserOperationClaimDal
    {
    }
}
