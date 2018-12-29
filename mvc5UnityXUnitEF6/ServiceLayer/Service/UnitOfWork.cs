using DataAccessLayer;

namespace ServiceLayer.Service
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        public IUnitOfWork uow = new UnitOfWork();
        public int Commit()
        {
            return uow.Commit();
        }
    }

    public interface IUnitOfWorkService
    {
        int Commit();
    }
}
