﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolveWithTest._201_300
{
    public class _217_Contains_Duplicates
    {
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> visited = new HashSet<int>(nums);
            return visited.Count != nums.Length;
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3, 1 }, true)]
        [InlineData(new[] { 1, 2, 3, 4 }, false)]
        [InlineData(new[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 }, true)]
        public void _217_Contains_Duplicates_Tests(int[] nums, bool expected)
        {
            // Arrange
            var sut = ContainsDuplicate;

            // Act
            var result = sut(nums);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
