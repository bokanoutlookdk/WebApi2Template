using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi2Template.Utils.Extensions
{
    public static class ExtensionOperation
    {
        public static bool HasValue<T>(this T entity)
        {
            return entity != null;
        }

        public static bool IsNull<T>(this T entity)
        {
            return entity == null;
        }

        public static bool IsNull<T>(this IEnumerable<T> sequence)
        {
            return sequence == null;
        }

        public static bool Empty<T>(this IEnumerable<T> sequence)
        {
            return !sequence.Any();
        }

    }
}