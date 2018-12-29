namespace DataAccessLayer
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}