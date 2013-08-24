using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using JQDotNet.Data;
using JQDotNet.Extensions;

namespace JQDotNet
{
    public class JSONQuery
    {
        public static object GetValue(string jsonData, string expression)
        {
            JSONQuerySelector json = new JSONQuerySelector();
            return json.SearchValue(jsonData, expression);
        }

        public static object GetMin(string jsonData, string expression)
        {
            JSONQuerySelector json = new JSONQuerySelector();
            var results = json.SearchValue(jsonData, expression);

            Calculator calculator = new Calculator();
            return calculator.GetMin(results);
        }

        public static Nullable<T> GetMin<T>(string jsonData, string expression) 
            where T : struct
        {
            JSONQuerySelector json = new JSONQuerySelector();
            var results = json.SearchValue(jsonData, expression);

            Calculator calculator = new Calculator();
            var min = calculator.GetMin(results);
            
            return min.SafeCast<T>();
        }

        public static object GetMax(string jsonData, string expression)
        {
            JSONQuerySelector json = new JSONQuerySelector();
            var results = json.SearchValue(jsonData, expression);

            Calculator calculator = new Calculator();
            return calculator.GetMax(results);
        }

        public static Nullable<T> GetMax<T>(string jsonData, string expression)
            where T : struct
        {
            JSONQuerySelector json = new JSONQuerySelector();
            var results = json.SearchValue(jsonData, expression);

            Calculator calculator = new Calculator();
            var max = calculator.GetMax(results);

            return max.SafeCast<T>();
        }

        public static double? GetSum(string jsonData, string expression)
        {
            JSONQuerySelector json = new JSONQuerySelector();
            var results = json.SearchValue(jsonData, expression);

            Calculator calculator = new Calculator();
            return calculator.GetSum(results);
        }

        public static int GetCount(string jsonData, string expression)
        {
            JSONQuerySelector json = new JSONQuerySelector();
            var results = json.SearchValue(jsonData, expression);

            Calculator calculator = new Calculator();
            return calculator.GetCount(results);
        }

        public static double? GetAvg(string jsonData, string expression)
        {
            JSONQuerySelector json = new JSONQuerySelector();
            var results = json.SearchValue(jsonData, expression);

            Calculator calculator = new Calculator();
            return calculator.GetAverage(results);
        }
    }
}
