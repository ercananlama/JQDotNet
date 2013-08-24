using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace JQDotNet.Tests
{
    public class Base_Query_Tests
    {
        protected virtual string JsonTestDataFilePath { get; private set; }
        protected string JsonTestData { get; private set; }

        [TestFixtureSetUp]
        public void Base_Query_Tests_SetUp()
        {
            using (StreamReader reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, JsonTestDataFilePath)))
            {
                JsonTestData = reader.ReadToEnd();
            }
        }
    }
}
