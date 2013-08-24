using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using NUnit.Framework;

namespace JQDotNet.Tests.SingleObjectWithChainOfArrays
{
    public class Base_Query_Tests : Tests.Base_Query_Tests
    {
        private const string jsonTestDataFilePath = @"SingleObjectWithChainOfArrays\TestData.json";

        protected override string JsonTestDataFilePath
        {
            get
            {
                return jsonTestDataFilePath;
            }
        }
    }
}
