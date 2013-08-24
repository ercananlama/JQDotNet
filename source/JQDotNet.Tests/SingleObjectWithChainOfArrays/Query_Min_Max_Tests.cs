using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
//
using JQDotNet.Extensions;

namespace JQDotNet.Tests.SingleObjectWithChainOfArrays
{
    [TestFixture]
    public class Query_Min_Max_Tests : Base_Query_Tests
    {
        [Test]
        [TestCaseSource("ChainOfArrayItemsForMinAganistExpectedValues")]
        public void When_element_in_chain_of_arrays_requested_return_min_of_all_values(string expression, object expected)
        {
            var found = JSONQuery.GetMin(JsonTestData, expression);

            Assert.AreEqual(expected, found);
        }

        [Test]
        [TestCaseSource("ChainOfArrayItemsForMaxAganistExpectedValues")]
        public void When_element_in_chain_of_arrays_requested_return_max_of_all_values(string expression, object expected)
        {
            var found = JSONQuery.GetMax(JsonTestData, expression);

            Assert.AreEqual(expected, found);
        }

        [Test]
        [TestCaseSource("NotCalculatedElements")]
        public void When_element_not_able_to_aggregated_return_null(string expression)
        {
            var foundMaxValue = JSONQuery.GetMax(JsonTestData, expression);
            var foundMinValue = JSONQuery.GetMin(JsonTestData, expression);

            Assert.IsNull(foundMaxValue, "Max value calculated");
            Assert.IsNull(foundMinValue, "Min value calculated");
        }

        public static IEnumerable<TestCaseData> ChainOfArrayItemsForMinAganistExpectedValues
        {
            get
            {
                yield return new TestCaseData("Messages.Sends.AttachmentCount", 1).
                    SetName("No indexed arrays").
                    SetDescription("Check the min of attachment counts in all sends in all messages");
                yield return new TestCaseData("Messages[0].Receives.AttachmentCount", 0).
                    SetName("Only first array indexed").
                    SetDescription("Check the min of attachment counts in all receives in first message");
                yield return new TestCaseData("Messages.Sends[0].AttachmentCount", 1).
                    SetName("Second array indexed along with first array with multiple elements").
                    SetDescription("Check the min of attachment counts in first elements of all sends in all messages");
                yield return new TestCaseData("Messages[1].Sends[0].AttachmentCount", 1).
                    SetName("Single element").
                    SetDescription("Check the min of attachment counts in first send in second message, which should be only 1 item");
                yield return new TestCaseData("Messages.Receives.SendDate", new DateTime(2013, 1, 21)).
                    SetName("Date type value").
                    SetDescription("Check the min value for date type value");
            }
        }

        public static IEnumerable<TestCaseData> ChainOfArrayItemsForMaxAganistExpectedValues
        {
            get
            {
                yield return new TestCaseData("Messages.Sends.AttachmentCount", 2).
                    SetName("No indexed arrays").
                    SetDescription("Check the max of attachment counts in all sends in all messages");
                yield return new TestCaseData("Messages[0].Receives.AttachmentCount", 1).
                    SetName("Only first array indexed").
                    SetDescription("Check the max of attachment counts in all receives in first message");
                yield return new TestCaseData("Messages.Sends[0].AttachmentCount", 1).
                    SetName("Second array indexed along with first array with multiple elements").
                    SetDescription("Check the max of attachment counts in first elements of all sends in all messages");
                yield return new TestCaseData("Messages[1].Sends[0].AttachmentCount", 1).
                    SetName("Single element").
                    SetDescription("Check the max of attachment counts in first send in second message, which should be only 1 item");
                yield return new TestCaseData("Messages.Receives.SendDate", new DateTime(2013, 3, 12)).
                    SetName("Date type value").
                    SetDescription("Check the max value for date type value");
            }
        }

        public static IEnumerable<TestCaseData> NotCalculatedElements
        {
            get
            {
                yield return new TestCaseData("Messages.Receives.Content").SetName("Text value");
                yield return new TestCaseData("Messages.Receives").SetName("Complex value");
            }
        }
    }
}
