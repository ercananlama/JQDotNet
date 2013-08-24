using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JQDotNet.Elements
{
    internal class JFilter
    {
        public enum FilterTypes
        {
            GreaterThan,
            GreaterThanOrEqual,
            Equal,
            LessThan,
            LessThanOrEqual
        };
        public object Value { get; set; }
        public FilterTypes FilterType { get; set; }
    }
}
