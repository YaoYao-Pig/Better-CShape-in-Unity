using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better
{
    namespace Utils
    {
        struct Value<T>
        {
            public bool isNull { get; }
            public T value { get; }
            public Value(bool isNull=true)
            {
                this.isNull = isNull;
                value = default(T);
            }
            public Value(T value)
            {
                isNull = false;
                this.value = value;
            }
        }
    }
}
