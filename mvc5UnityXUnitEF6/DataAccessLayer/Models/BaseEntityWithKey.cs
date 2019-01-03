using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class BaseEntityWithKey<T>
    {
        public T Id { get; set; }
    }
}
