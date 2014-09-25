using System.Collections.Generic;
using System.Linq;
using CMModEvaluator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace CMModEvaluatorTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestModEvalNormal()
        {
            var parameters = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(3, "fizz"),
                new KeyValuePair<int, string>(5,"buzz")
            };
            const int start = 1;
            const int end = 100;
            var unit = ModEvaluator.ModEval(start, end, parameters);
            unit.ShouldNotBeNull();
            unit.Count.ShouldBeGreaterThan(start);
            unit.Count.ShouldBeLessThan(end + 1);
            unit[2].ShouldEqual(parameters[0].Value);
            unit[4].ShouldEqual(parameters[1].Value);
            unit[14].ShouldEqual(parameters[0].Value + parameters[1].Value);
            unit[96].ShouldEqual("97");
            unit[0].ShouldEqual("1");
        }

        [TestMethod]
        public void TestModEvalAddedParams()
        {
            var parameters = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(3, "fizz"),
                new KeyValuePair<int, string>(5,"buzz"),
                new KeyValuePair<int, string>(10,"sudz")
            };
            const int start = 1;
            const int end = 100;
            var unit = ModEvaluator.ModEval(start, end, parameters);
            unit.ShouldNotBeNull();
            unit.ShouldBeType<List<string>>();
            unit.Contains(parameters[0].Value + parameters[2].Value).ShouldBeFalse();
            unit.Count(n => n.Equals(parameters[1].Value + parameters[2].Value)).ShouldEqual(7);
            unit.Count.ShouldBeGreaterThan(start);
            unit.Count.ShouldBeLessThan(end + 1);
            unit[2].ShouldEqual(parameters[0].Value);
            unit[9].ShouldEqual(parameters[1].Value + parameters[2].Value);
            unit[29].ShouldEqual(parameters[0].Value + parameters[1].Value + parameters[2].Value);
            unit[4].ShouldEqual(parameters[1].Value);
            unit[14].ShouldEqual(parameters[0].Value + parameters[1].Value);
            unit[96].ShouldEqual("97");
            unit[0].ShouldEqual("1");
        }
    }
}
