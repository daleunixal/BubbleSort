using NUnit.Framework;

namespace BubbleSort
{
    class Tests
    {
        [Test]
        public void SimpleSort()
        {
            var q = new int[] {15, 8, 456, 35, 18, 156, 5, 0, 1, 3, 5};
            var sortedArray = SortProvider.BubbleSort(q);
            Assert.AreEqual(q, new int[] {0,1,3,5, 5,8,15,18,35,156,456 });
            Assert.AreEqual(sortedArray, 154);
        }

        [Test]
        public void NegativeSort()
        {
            var q = new int[] {1, 0, -1};
            SortProvider.BubbleSort(q);
            Assert.AreEqual(q, new int[] {-1, 0, 1});
        }
    }
}