using DataAccessLayer;

namespace ServiceLayer.Service
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        public IUnitOfWork _uow { get; set; }
        public UnitOfWorkService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public int Commit()
        {
            return _uow.Commit();
        }
    }

    public interface IUnitOfWorkService
    {
        int Commit();
    }
}
