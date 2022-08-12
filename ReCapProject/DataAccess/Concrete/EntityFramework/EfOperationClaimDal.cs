using Core.DataAccess;
using Core.Entities.Concrete;
using DataAccess.Absract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOperationClaimDal:EfEntityRepositoryBase<OperationClaim,CarRentalContext>,IOperationClaimDal
    {
    }
}
