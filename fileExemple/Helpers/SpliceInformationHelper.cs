using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fileExemple.Helpers
{
    public static class SpliceInformationHelper
    {
        public static ReadOnlySpan<char> slice(ref ReadOnlySpan<char> span, ref int scanned, ref int position)
        {
            scanned += position + 1;

            position = span.Slice(scanned, span.Length - scanned).IndexOf(";");
            if(position < 0)
            {
                position = span.Slice(scanned, span.Length - scanned).Length;
            }
            return span.Slice(scanned, position);
        }
    }
}