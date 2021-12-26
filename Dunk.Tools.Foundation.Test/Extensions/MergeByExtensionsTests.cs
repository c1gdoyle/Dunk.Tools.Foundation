using System.Linq;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class MergeByExtensionsTests
    {
        [Test]
        public void MergeByOrderedByCombinesSequences()
        {
            const int expectedCount = 14;

            var a = new MergeByTestItem[]
            {
                new MergeByTestItem{ Id =1 },
                new MergeByTestItem{ Id =8 },
                new MergeByTestItem{ Id =13 },
                new MergeByTestItem{ Id =19 },
                new MergeByTestItem{ Id =40 },
            };
            var b = new MergeByTestItem[]
            {
                new MergeByTestItem{ Id =0 },
                new MergeByTestItem{ Id =4 },
                new MergeByTestItem{ Id =12 },
                new MergeByTestItem{ Id =41 }
            };
            var c = new MergeByTestItem[]
            {
                new MergeByTestItem{ Id =3 },
                new MergeByTestItem{ Id =22 },
                new MergeByTestItem{ Id =30 },
                new MergeByTestItem{ Id =37 },
                new MergeByTestItem{ Id =43 },
            };
            var combined = new MergeByTestItem[][] { a, b, c };

            var mergeOrdered = combined.MergeOrderedBy(m => m.Id);

            Assert.AreEqual(expectedCount, mergeOrdered.Count());
        }

        [Test]
        public void MergeByOrderedByLastItemIsLargest()
        {
            const int expectedLast = 43;

            var a = new MergeByTestItem[]
            {
                new MergeByTestItem{ Id =1 },
                new MergeByTestItem{ Id =8 },
                new MergeByTestItem{ Id =13 },
                new MergeByTestItem{ Id =19 },
                new MergeByTestItem{ Id =40 },
            };
            var b = new MergeByTestItem[]
            {
                new MergeByTestItem{ Id =0 },
                new MergeByTestItem{ Id =4 },
                new MergeByTestItem{ Id =12 },
                new MergeByTestItem{ Id =41 }
            };
            var c = new MergeByTestItem[]
            {
                new MergeByTestItem{ Id =3 },
                new MergeByTestItem{ Id =22 },
                new MergeByTestItem{ Id =30 },
                new MergeByTestItem{ Id =37 },
                new MergeByTestItem{ Id =43 },
            };
            var combined = new MergeByTestItem[][] { a, b, c };

            var mergeOrdered = combined.MergeOrderedBy(m => m.Id);

            Assert.AreEqual(expectedLast, mergeOrdered.Last().Id);
        }

        [Test]
        public void MergeByOrderedByFirstItemIsSmallest()
        {
            const int expectedFirst = 0;

            var a = new MergeByTestItem[]
            {
                new MergeByTestItem{ Id =1 },
                new MergeByTestItem{ Id =8 },
                new MergeByTestItem{ Id =13 },
                new MergeByTestItem{ Id =19 },
                new MergeByTestItem{ Id =40 },
            };
            var b = new MergeByTestItem[]
            {
                new MergeByTestItem{ Id =0 },
                new MergeByTestItem{ Id =4 },
                new MergeByTestItem{ Id =12 },
                new MergeByTestItem{ Id =41 }
            };
            var c = new MergeByTestItem[]
            {
                new MergeByTestItem{ Id =3 },
                new MergeByTestItem{ Id =22 },
                new MergeByTestItem{ Id =30 },
                new MergeByTestItem{ Id =37 },
                new MergeByTestItem{ Id =43 },
            };
            var combined = new MergeByTestItem[][] { a, b, c };

            var mergeOrdered = combined.MergeOrderedBy(m => m.Id);

            Assert.AreEqual(expectedFirst, mergeOrdered.First().Id);
        }

        [Test]
        public void MergeByOrderedByDescendingCombinesSequences()
        {
            const int expectedCount = 14;

            var a = new MergeByTestItem[]
            {
                new MergeByTestItem{ Id =40 },
                new MergeByTestItem{ Id =19},
                new MergeByTestItem{ Id =13 },
                new MergeByTestItem{ Id =8 },
                new MergeByTestItem{ Id =1 },
            };
            var b = new MergeByTestItem[]
            {
                new MergeByTestItem{ Id =41 },
                new MergeByTestItem{ Id =12 },
                new MergeByTestItem{ Id =4 },
                new MergeByTestItem{ Id =0 }
            };
            var c = new MergeByTestItem[]
            {
                new MergeByTestItem{ Id =43 },
                new MergeByTestItem{ Id =37 },
                new MergeByTestItem{ Id =30 },
                new MergeByTestItem{ Id =22 },
                new MergeByTestItem{ Id =3 },
            };
            var combined = new MergeByTestItem[][] { a, b, c };

            var mergeOrdered = combined.MergeOrderedByDescending(m => m.Id);

            Assert.AreEqual(expectedCount, mergeOrdered.Count());
        }

        [Test]
        public void MergeByOrderedDescendindgByLastItemIsSmallest()
        {
            const int expectedLast = 0;

            var a = new MergeByTestItem[]
            {
                new MergeByTestItem{ Id =40 },
                new MergeByTestItem{ Id =19},
                new MergeByTestItem{ Id =13 },
                new MergeByTestItem{ Id =8 },
                new MergeByTestItem{ Id =1 },
            };
            var b = new MergeByTestItem[]
            {
                new MergeByTestItem{ Id =41 },
                new MergeByTestItem{ Id =12 },
                new MergeByTestItem{ Id =4 },
                new MergeByTestItem{ Id =0 }
            };
            var c = new MergeByTestItem[]
            {
                new MergeByTestItem{ Id =43 },
                new MergeByTestItem{ Id =37 },
                new MergeByTestItem{ Id =30 },
                new MergeByTestItem{ Id =22 },
                new MergeByTestItem{ Id =3 },
            };
            var combined = new MergeByTestItem[][] { a, b, c };

            var mergeOrdered = combined.MergeOrderedByDescending(m => m.Id);

            Assert.AreEqual(expectedLast, mergeOrdered.Last().Id);
        }

        [Test]
        public void MergeByOrderedDescendingByFirstItemIsLargest()
        {
            const int expectedFirst = 43;

            var a = new MergeByTestItem[]
            {
                new MergeByTestItem{ Id =40 },
                new MergeByTestItem{ Id =19},
                new MergeByTestItem{ Id =13 },
                new MergeByTestItem{ Id =8 },
                new MergeByTestItem{ Id =1 },
            };
            var b = new MergeByTestItem[]
            {
                new MergeByTestItem{ Id =41 },
                new MergeByTestItem{ Id =12 },
                new MergeByTestItem{ Id =4 },
                new MergeByTestItem{ Id =0 }
            };
            var c = new MergeByTestItem[]
            {
                new MergeByTestItem{ Id =43 },
                new MergeByTestItem{ Id =37 },
                new MergeByTestItem{ Id =30 },
                new MergeByTestItem{ Id =22 },
                new MergeByTestItem{ Id =3 },
            };
            var combined = new MergeByTestItem[][] { a, b, c };

            var mergeOrdered = combined.MergeOrderedByDescending(m => m.Id);

            Assert.AreEqual(expectedFirst, mergeOrdered.First().Id);
        }

        private sealed class MergeByTestItem
        {
            public int Id { get; set; }
        }
    }
}
