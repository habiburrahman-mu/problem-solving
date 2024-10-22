using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolveWithTest._0001_0100
{
    public class _017_Letter_Combinations_of_a_Phone_Number
    {
        private Dictionary<char, List<string>> _map = new()
        {
            {'2', new() {"a", "b", "c"}},
            {'3', new() {"d", "e", "f"}},
            {'4', new() {"g", "h", "i"}},
            {'5', new() {"j", "k", "l"}},
            {'6', new() {"m", "n", "o"}},
            {'7', new() {"p", "q", "r", "s"}},
            {'8', new() {"t", "u", "v"}},
            {'9', new() {"w", "x", "y", "z"}},
        };

        public IList<string> LetterCombinations(string digits)
        {
            var result = new List<string>();
            if (digits.Length > 0)
            {
                BackTrack(digits, 0, result, "");
            }
            return result;
        }

        private void BackTrack(string digits, int index, List<string> result, string currentCombination)
        {
            if (currentCombination.Length == digits.Length)
            {
                result.Add(currentCombination);
                return;
            }

            var characters = _map[digits[index]];

            for (int i = 0; i < characters.Count; i++)
            {
                currentCombination += characters[i];
                BackTrack(digits, index + 1, result, currentCombination);
                currentCombination = currentCombination.Substring(0, currentCombination.Length - 1);
            }
        }

        public static IEnumerable<object[]> LetterCombinationsOfAPhoneNumberTest()
        {
            yield return new object[]
            {
                "23",
                new string[] { "ad","ae","af","bd","be","bf","cd","ce","cf" }
            };

            yield return new object[]
            {
                "",
                new string[] { }
            };

            yield return new object[]
            {
                "2",
                new string[] { "a","b","c" }
            };
        }

        [Theory]
        [MemberData(nameof(LetterCombinationsOfAPhoneNumberTest))]
        public void _017_Letter_Combinations_of_a_Phone_Number_Test(string digits, string[] expected)
        {
            var sut = LetterCombinations;

            var result = sut(digits);

            result = result.OrderBy(x => x).ToList();
            expected = expected.ToList().OrderBy(x => x).ToArray();

            Assert.Equal(expected, result);
        }
    }
}
