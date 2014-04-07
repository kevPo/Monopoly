using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    public static class Extensions
    {
        public static List<T> Shuffle<T>(this List<T> values)
        {
            return values.OrderBy(a => Guid.NewGuid()).ToList();
        }
    }
}
