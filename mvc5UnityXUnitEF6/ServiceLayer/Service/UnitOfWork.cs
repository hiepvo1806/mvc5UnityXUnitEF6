using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        int SaveChanges()
        {
            return 
        }
    }

    public interface IUnitOfWorkService
    {
        int SaveChanges();
    }
}
