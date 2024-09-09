namespace LeetCodeSolveWithTest._1001_1100
{
    public class _1046_Last_Stone_Weight
    {
        public int LastStoneWeight(int[] stones)
        {
            PriorityQueue<int, int> priorityQueue = new();
            foreach (int stone in stones)
                priorityQueue.Enqueue(stone, -stone);

            while (priorityQueue.Count > 1)
            {
                var largest = priorityQueue.Dequeue();
                var secondLargest = priorityQueue.Dequeue();

                if (largest == secondLargest)
                    continue;
                else
                {
                    var diff = largest - secondLargest;
                    priorityQueue.Enqueue(diff, -diff);
                }
            }

            if (priorityQueue.Count > 0)
            {
                return priorityQueue.Dequeue();
            }
            else
            {
                return 0;
            }
        }

        [Theory]
        [InlineData((int[])[2, 7, 4, 1, 8, 1], 1)]
        [InlineData((int[])[1], 1)]
        public void _1046_Last_Stone_Weight_Test(int[] nums, int expected)
        {
            // Arrange
            var sut = LastStoneWeight;

            // Act
            var result = sut(nums);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
