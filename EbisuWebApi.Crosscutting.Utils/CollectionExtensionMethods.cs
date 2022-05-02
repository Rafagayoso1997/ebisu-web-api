using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Crosscutting.Utils
{
    public static class CollectionExtensionMethods
    {
        public static void AddRangeToCollection<T>(this ICollection<T> collection, IEnumerable<T> dataList)
        {

            foreach (var item in dataList)
            {
                collection.Add(item);
            }
        }
    }
}
