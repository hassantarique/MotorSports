using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common;

public static class Operators
{
    public static IEnumerable<T> Once<T>(this IEnumerable<T> sequence) =>
        new SinglePassSequence<T>(sequence);

    public static IEnumerable<string> ToGrid<T>
        (this IEnumerable<T> sequence, int width, int gap) =>
        new GridFormatter<T>(sequence).Format(width, gap);
}