using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JQDotNet.Extensions
{
    public static class Conversion
    {
        private static double? ConvertToDouble(this object valueToConvert)
        {
            if (valueToConvert == null)
                return null;

            double cValue;
            if (double.TryParse(valueToConvert.ToString(), out cValue))
                return cValue;

            return null;
        }

        private static DateTime? ConvertToDateTime(this object valueToConvert)
        {
            if (valueToConvert == null)
                return null;

            DateTime cValue;
            if (DateTime.TryParse(valueToConvert.ToString(), out cValue))
                return cValue;

            return null;
        }

        private static bool? ConvertToBoolean(this object valueToConvert)
        {
            if (valueToConvert == null)
                return null;

            bool cValue;
            if (bool.TryParse(valueToConvert.ToString(), out cValue))
                return cValue;

            return null;
        }

        private static int? ConvertToInt(this object valueToConvert)
        {
            if (valueToConvert == null)
                return null;

            int cValue;
            if (int.TryParse(valueToConvert.ToString(), out cValue))
                return cValue;

            return null;
        }

        private static long? ConvertToLong(this object valueToConvert)
        {
            if (valueToConvert == null)
                return null;

            long cValue;
            if (long.TryParse(valueToConvert.ToString(), out cValue))
                return cValue;

            return null;
        }

        public static Nullable<T> SafeCast<T>(this object valueToConvert) where T : struct
        {
            object val = null;
            if (typeof(T) == typeof(double))
            {
                val = valueToConvert.ConvertToDouble();
            }
            else if (typeof(T) == typeof(DateTime))
            {
                val = valueToConvert.ConvertToDateTime();
            }
            else if (typeof(T) == typeof(bool))
            {
                val = valueToConvert.ConvertToBoolean();
            }
            else if (typeof(T) == typeof(int))
            {
                val = valueToConvert.ConvertToInt();
            }
            else if (typeof(T) == typeof(long))
            {
                val = valueToConvert.ConvertToLong();
            }

            if (val != null)
            {
                return (T)Convert.ChangeType(val, typeof(T));
            }

            return null;
        }

        internal static bool IsTypeof<T>(this object value)
        {
            return (value != null && value is T);
        }

        /// <summary>
        /// Check if given value is a primitive type such as int, string in the context
        /// </summary>
        /// <param name="value">Value to be checked</param>
        /// <returns>Primitive status</returns>
        public static bool IsPrimitive(this object value)
        {
            return !(value is SimpleJson.JsonArray || value is SimpleJson.JsonObject);
        }

        internal static bool IsNumeric(this string value)
        {
            return SafeCast<int>(value) == null;
        }

        internal static string ToValueString(this object value)
        {
            if (value == null)
            {
                return null;
            }

            if (value is DateTime)
            {
                return value.SafeCast<DateTime>().Value.ToString("yyyy-MM-dd hh:mm");
            }

            return value.ToString();
        }
    }
}
