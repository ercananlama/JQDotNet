using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace JQDotNet.Tests.SingleObjectWithChainOfArrays
{
    [TestFixture]
    public class Query_Value_Tests : Base_Query_Tests
    {
        [Test]
        [TestCaseSource("RootProperties")]
        public void When_root_property_supplied_return_correct_value(object expected, string expression)
        {
            var found = JSONQuery.GetValue(JsonTestData, expression);

            Assert.AreEqual(expected, found);
        }

        [Test]
        [TestCaseSource("ChildProperties")]
        public void When_child_property_supplied_return_correct_value(object expected, string expression)
        {
            var found = JSONQuery.GetValue(JsonTestData, expression);

            Assert.AreEqual(expected, found);
        }

        [Test]
        public void When_given_property_not_found_return_null()
        {
            var found = JSONQuery.GetValue(JsonTestData, "Messages[0].Receives[1].TestProperty");

            Assert.IsNull(found);
        }

        [Test]
        public void When_given_property_refers_an_object_return_it_as_object()
        {
            var expected = "{\"Content\":\"Ok bye\",\"SendDate\":\"2013-01-25\",\"AttachmentCount\":1}";
            var found = JSONQuery.GetValue(JsonTestData, "Messages[0].Receives[1]");

            Assert.AreEqual(expected, found.ToString());
        }

        [TestCaseSource("AttributeProperties")]
        public void When_given_property_supplied_with_attribute_filter_values(object expected, string expression)
        {
            var found = JSONQuery.GetValue(JsonTestData, expression);

            Assert.AreEqual(expected, found);
        }

        public static IEnumerable<TestCaseData> RootProperties
        {
            get
            {
                yield return new TestCaseData("Chris", "FirstName").SetName("FirstName");
                yield return new TestCaseData("Brown", "LastName").SetName("LastName");
                yield return new TestCaseData("France", "Country").SetName("Country");
                yield return new TestCaseData(26, "Age").SetName("Age");
                yield return new TestCaseData("Theking", "Nickname").SetName("Nickname");
                yield return new TestCaseData("Single", "MaritalStatus").SetName("MaritalStatus");
            }
        }

        public static IEnumerable<TestCaseData> ChildProperties
        {
            get
            {
                yield return new TestCaseData("Heyy", "Messages[0].Title").SetName("MessageTitle");
                yield return new TestCaseData("Thelove", "Messages[0].To").SetName("MessageReceiver");
                yield return new TestCaseData("Whats up?", "Messages[0].Sends[0].Content").SetName("FirstSentMessageContent");
                yield return new TestCaseData("2013-01-25", "Messages[0].Receives[1].SendDate").SetName("SecondReceivedMessageDate");
            }
        }

        public static IEnumerable<TestCaseData> AttributeProperties
        {
            get
            {
                yield return new TestCaseData("2013-01-22", "Messages.Sends[AttachmentCount > 1].SendDate").SetName("GreaterThanForInt");
                yield return new TestCaseData("How is life going on?", "Messages.Sends[SendDate >= \"2013-03-01\"].Content").SetName("GreaterThanOrEqualForDate");
                yield return new TestCaseData("Thelove", "Messages[Title = \"Heyy\"].To").SetName("EqualForString");
                yield return new TestCaseData("Whats up?", "Messages.Sends[SendDate <= \"2013-01-20\"].Content").SetName("LessThanOrEqualForDate");
                yield return new TestCaseData("Great you?", "Messages.Receives[AttachmentCount < 1].Content").SetName("LessThanForInt");
                yield return new TestCaseData("2013-01-25", "Messages[0].Receives[AttachmentCount > 0].SendDate").SetName("IndexAttributeSeperate");
                yield return new TestCaseData("Ok bye", "Messages.Receives[SendDate > \"2013-01-20\"][1].Content").SetName("IndexAttributeTogether");
            }
        }
    }
}
