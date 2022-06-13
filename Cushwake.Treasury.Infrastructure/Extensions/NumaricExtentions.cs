using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cushwake.Treasury.Infrastructure.Extensions
{
    public static class NumaricExtentions
    {
        public static int ToInteger(this string source) { 
            int.TryParse(source,out int holder);
            return holder;
        }
    }
}
