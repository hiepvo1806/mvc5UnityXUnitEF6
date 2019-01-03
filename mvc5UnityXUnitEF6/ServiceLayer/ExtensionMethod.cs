using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public static class ExtensionMethod
    {
        public static T GetFirstCreateItem<T>(this IQueryable<T> source)
        {
            return source.FirstOrDefault();
        }
    }
}
