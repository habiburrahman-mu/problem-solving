using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolveWithTest._0901_1000
{
    public class _0997_Find_the_Town_Judge
    {
        public int FindJudge(int n, int[][] trust)
        {
            return default;
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[]
            {
                2,
                new int[][] {[1,2]},
                2
            };

            yield return new object[]
            {
                3,
                new int[][] {[1,3],[2,3]},
                3
            };

            yield return new object[]
            {
                3,
                new int[][] {[1,3],[2,3],[3,1]},
                -1
            };
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void _0997_Find_the_Town_Judge_Test(int n, int[][] trust, int expected)
        {
            var sut = FindJudge;

            var result = sut(n, trust);

            Assert.Equal(expected, result);
        }
    }
}
