using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class RunStringTraversalByBrackets
    {
        private const string SuccessAnswer = "YES";
        private const string UnSuccessAnswer = "NO";

        [SetUp]
        public void Init()
        {
        }
        

        [Test]
        public void RunStringTraversalByBracketsTest()
        {
            var lines = new[]
            {
                "{[()]}",
                "{[(])}",
                "{{[[(())]]}}"
            };

            var expectedResults = new[]
            {
                SuccessAnswer,
                UnSuccessAnswer,
                SuccessAnswer
            };

            for(var i = 0; i < lines.Length; i++)
            {
                var result = StringTraversalByBrackets.Traverse(lines[i], SuccessAnswer, UnSuccessAnswer);
                Assert.AreEqual(result, expectedResults[i]);
            }
        }
    }
}
