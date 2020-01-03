using Xunit;
using RelationApp.Services;
using System.Collections.Generic;
using System.Collections;

namespace RelationApp.Tests
{   
    public class TestGenerator : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            return values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private List<object[]> values = new List<object[]>
            {
                new object[] { "ma523", "LLNNN", "MA523" },
                new object[] { "Mda421asdasdasd", "lLLNNN", "mDA421" },
                new object[] { null, "NLNNN", null },
                new object[] { "dfs1", null, "dfs1" },
                new object[] { "f1a", "LL", "FA" },
                new object[] { "rl11", "l---lNN", "r---l11" },
                new object[] { "sdf", " ", "sdf" },
                new object[] { "abc1", "L--N", "A--1" },
            };
    }

    public class RelationServiceTests
    {
        [Theory]
        [ClassData(typeof(TestGenerator))]
        public void ProperlyValidates(string code, string format, string expected)
        {
            //act
            string result = RelationService.ValidateAgainstFormat(format, code);
            //assert
            Assert.Equal(expected, result);
        }
    }
}
