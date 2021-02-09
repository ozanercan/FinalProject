using Core.DataAccess.EntityRepository.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EntityRepositoryBase<Order, NorthwindContext>, IOrderDal
    {

    }
}
