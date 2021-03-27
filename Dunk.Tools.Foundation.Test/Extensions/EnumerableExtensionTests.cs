using System;
using System.Collections.Generic;
using System.Linq;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class EnumerableExtensionTests
    {
        [Test]
        public void EnumerableToSynchronisedHashSetReturnsHashSet()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var set = EnumerableExtensions.ToSynchronisedHashSet(list);

            Assert.IsNotNull(set);
        }

        [Test]
        public void EnumerableToSynchronisedHashSetReturnsUniqueValues()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 9 };

            var set = EnumerableExtensions.ToSynchronisedHashSet(list);

            Assert.AreEqual(9, set.Count);
        }

        [Test]
        public void EnumerableToSynchronisedHashSetThrowsIfSourceCollectionIsNull()
        {
            List<int> list = null;

            Assert.Throws<ArgumentNullException>(() => EnumerableExtensions.ToSynchronisedHashSet(list));
        }

        [Test]
        public void EnumerableToSynchronisedHashSetThrowsIfComparerIsNull()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 9 };

            Assert.Throws<ArgumentNullException>(() => EnumerableExtensions.ToSynchronisedHashSet(list, null));
        }

        [Test]
        public void EnumerableToConcurrentHashSetReturnsHashSet()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var set = EnumerableExtensions.ToConcurrentHashSet(list);

            Assert.IsNotNull(set);
        }

        [Test]
        public void EnumerableToConcurrentHashSetReturnsUniqueValues()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 9 };

            var set = EnumerableExtensions.ToConcurrentHashSet(list);

            Assert.AreEqual(9, set.Count);
        }

        [Test]
        public void EnumerableToConcurrentHashSetThrowsIfSourceCollectionIsNull()
        {
            List<int> list = null;

            Assert.Throws<ArgumentNullException>(() => EnumerableExtensions.ToConcurrentHashSet(list));
        }

        [Test]
        public void EnumerableToConcurrentHashSetThrowsIfComparerIsNull()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 9 };

            Assert.Throws<ArgumentNullException>(() => EnumerableExtensions.ToConcurrentHashSet(list, null));
        }

        [Test]
        public void EnumerableToSmartEnumerableReturnsSmartEnumerable()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 9 };

            var smart = list.ToSmartEnumerable();

            Assert.IsNotNull(smart);
        }

        [Test]
        public void EnumerableToSmartEnumerableThrowsIfSourceCollectionIsNull()
        {
            List<int> list = null;

            Assert.Throws<ArgumentNullException>(() => list.ToSmartEnumerable());
        }

        [Test]
        public void IsNullOrEmptyReturnsTrueForNullSequence()
        {
            IEnumerable<int> sequence = null;

            bool result = sequence.IsNullOrEmtpty();

            Assert.IsTrue(result);
        }

        [Test]
        public void IsNullOrEmptyReturnsTrueForEmptySequence()
        {
            int[] array = { 1, 2, 3 };
            IEnumerable<int> sequence = array.Where(i => i == 0);

            bool result = sequence.IsNullOrEmtpty();

            Assert.IsTrue(result);
        }

        [Test]
        public void IsNullOrEmptyReturnsTrueForEmptyCollection()
        {
            ICollection<int> sequence = new List<int>();

            bool result = sequence.IsNullOrEmtpty();

            Assert.IsTrue(result);
        }

        [Test]
        public void IsNullOrEmptyReturnsFalseForSequenceWithItems()
        {
            int[] array = { 1, 2, 3 };
            IEnumerable<int> sequence = array.Where(i => i != 0);

            bool result = sequence.IsNullOrEmtpty();

            Assert.IsFalse(result);
        }

        [Test]
        public void IsNullOrEmptyReturnsFalseForCollectionWithItems()
        {
            ICollection<int> sequence = new List<int> { 1, 2, 3 };

            bool result = sequence.IsNullOrEmtpty();

            Assert.IsFalse(result);
        }

        [Test]
        public void PartitionDividesSequenceIntoBatches()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            IEnumerable<IEnumerable<int>> partitions = array.Partition(2);

            Assert.IsNotNull(partitions);
        }

        [Test]
        public void PartitionDividesSequenceIntoExpectedNumberOfBatches()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            IEnumerable<IEnumerable<int>> partitions = array.Partition(2);

            Assert.AreEqual(5, partitions.Count());
        }

        [Test]
        public void PartitionDividesSequencesIntoBatchesOfExpectedSize()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            IEnumerable<IEnumerable<int>> partitions = array.Partition(2);

            Assert.IsTrue(partitions.All(p => p.Count() == 2));
        }

        [Test]
        public void PartitionDividesSequenceThatIsNotExactlyDivisbleBySize()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            IEnumerable<IEnumerable<int>> partitions = array.Partition(3);

            Assert.AreEqual(4, partitions.Count());
            Assert.AreEqual(1, partitions.Last().Count());
        }

        [Test]
        public void PartitionThrowsIfSequenceIsNull()
        {
            int[] array = null;

            Assert.Throws<ArgumentNullException>(() => array.Partition(10).ToList());
        }

        [Test]
        public void PartitionThrowsIfSizeIsZero()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Assert.Throws<ArgumentException>(() => array.Partition(0).ToList());
        }

        [Test]
        public void PartitionThrowsIfSizeIsNegative()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Assert.Throws<ArgumentException>(() => array.Partition(-1).ToList());
        }

        [Test]
        public void DistincyByThrowsIfSequenceIsNull()
        {
            TestItem[] array = null;
            Assert.Throws<ArgumentNullException>(() => array.DistinctBy(i => i.Id).ToList());
        }

        [Test]
        public void DistinctByThrowsIfKeySelectorIsNull()
        {
            TestItem[] array = new TestItem[0];
            Assert.Throws<ArgumentNullException>(() => array.DistinctBy(null as Func<TestItem, int>).ToList());
        }

        [Test]
        public void DistinctByReturnsDistinctForASingleProperty()
        {
            TestItem[] array =
            {
                new TestItem {Id = 1, Name="Tom" },
                new TestItem {Id = 2, Name="Dick" },
                new TestItem {Id = 3, Name="Harry" },
                new TestItem {Id = 3, Name="Archer" },
            };

            var distinctItems = array.DistinctBy(t => t.Id);

            Assert.AreEqual(3, distinctItems.Count());
        }

        [Test]
        public void DistinctByReturnsDistinctForMultipleProperties()
        {
            TestItem[] array =
            {
                new TestItem {Id = 1, Name="Tom" },
                new TestItem {Id = 2, Name="Dick" },
                new TestItem {Id = 3, Name="Harry" },
                new TestItem {Id = 3, Name="Archer" },
            };

            var distinctItems = array.DistinctBy(t => new { t.Id, t.Name });

            Assert.AreEqual(4, distinctItems.Count());
        }

        [Test]
        public void ConcatenateThrowsIfSequencesAreNull()
        {
            Assert.Throws<ArgumentNullException>(() => EnumerableExtensions.Concatenate<TestItem>(null));
        }

        [Test]
        public void ConcatentateCombinesSingleArrayOfSequences()
        {
            List<int>[] sequences = new List<int>[]
            {
                new List<int> {1,2,3,4,5 },
                new List<int> {6,7,8,9,10 },
                new List<int> {11,12,13,14,15 }
            };

            var combined = EnumerableExtensions.Concatenate(sequences);

            Assert.AreEqual(15, combined.Count());
        }

        [Test]
        public void ConcatenateCombinesMultipleSequences()
        {
            var sequence1 = new List<int> { 1, 2, 3, 4, 5 };
            var sequence2 = new List<int> { 6, 7, 8, 9, 10 };
            var sequence3 = new List<int> { 11, 12, 13, 14, 15 };

            var combined = EnumerableExtensions.Concatenate(sequence1, sequence2, sequence3);

            Assert.AreEqual(15, combined.Count());
        }

        [Test]
        public void EnumerableBetweenThrowsIfSequenceIsNull()
        {
            List<int> list = null;

            Assert.Throws<ArgumentNullException>(() => list.Between(i => i, 5, 15));
        }

        [Test]
        public void EnumerableBetweenThrowsIfKeySelectorIsNull()
        {
            List<int> list = new List<int>(); ;

            Assert.Throws<ArgumentNullException>(() => list.Between(null, 5, 15));
        }

        [Test]
        public void EnumerableBetweenReturnsCollectionWithLowerLimit()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            var between = list.Between(i => i, 5, 15);

            Assert.AreEqual(5, between.Min());
        }

        [Test]
        public void EnumerableBetweenReturnsCollectionWithUpperLimit()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            var between = list.Between(i => i, 5, 15);

            Assert.AreEqual(15, between.Max());
        }

        [Test]
        public void EnumerablePivotThrowsIfSourceIsNull()
        {
            IEnumerable<TestEmployee> source = null;
            Func<TestEmployee, string> firstKeySelector = emp => emp.Department;
            Func<TestEmployee, string> secondKeySelector = emp => emp.Function;
            Func<IEnumerable<TestEmployee>, decimal> aggregator = l => l.Sum(emp => emp.Salary);

            Assert.Throws<ArgumentNullException>(() => source.Pivot(firstKeySelector, secondKeySelector, aggregator));
        }

        [Test]
        public void EnumerablePivotThrowsIfFirstKeySelectorIsNull()
        {
            IEnumerable<TestEmployee> source = new List<TestEmployee>();
            Func<TestEmployee, string> firstKeySelector = null;
            Func<TestEmployee, string> secondKeySelector = emp => emp.Function;
            Func<IEnumerable<TestEmployee>, decimal> aggregator = l => l.Sum(emp => emp.Salary);

            Assert.Throws<ArgumentNullException>(() => source.Pivot(firstKeySelector, secondKeySelector, aggregator));
        }

        [Test]
        public void EnumerablePivotThrowsIfSecondKeySelectorIsNull()
        {
            IEnumerable<TestEmployee> source = new List<TestEmployee>();
            Func<TestEmployee, string> firstKeySelector = emp => emp.Department;
            Func<TestEmployee, string> secondKeySelector = null;
            Func<IEnumerable<TestEmployee>, decimal> aggregator = l => l.Sum(emp => emp.Salary);

            Assert.Throws<ArgumentNullException>(() => source.Pivot(firstKeySelector, secondKeySelector, aggregator));
        }

        [Test]
        public void EnumerablePivoutThrowsIfAggregatorIsNull()
        {
            IEnumerable<TestEmployee> source = new List<TestEmployee>();
            Func<TestEmployee, string> firstKeySelector = emp => emp.Department;
            Func<TestEmployee, string> secondKeySelector = emp => emp.Function;
            Func<IEnumerable<TestEmployee>, decimal> aggregator = null;

            Assert.Throws<ArgumentNullException>(() => source.Pivot(firstKeySelector, secondKeySelector, aggregator));
        }

        [Test]
        public void EnumerablePivotKeysByFirstKey()
        {
            IEnumerable<TestEmployee> source = new List<TestEmployee>
            {
                new TestEmployee {Name = "Fons", Department = "R&D", Function  ="Trainer", Salary = 2000 },
                new TestEmployee {Name = "Jim", Department = "R&D", Function  ="Trainer", Salary = 3000 },
                new TestEmployee {Name = "Ellen", Department = "Dev", Function  ="Developer", Salary = 4000 },
                new TestEmployee {Name = "Mike", Department = "Dev", Function  ="Consultant", Salary = 5000 },
                new TestEmployee {Name = "Jack", Department = "R&D", Function  ="Trainer", Salary = 6000 },
                new TestEmployee {Name = "Demy", Department = "Dev", Function  ="Consultant", Salary = 2000 },
            };
            Func<TestEmployee, string> firstKeySelector = emp => emp.Department;
            Func<TestEmployee, string> secondKeySelector = emp => emp.Function;
            Func<IEnumerable<TestEmployee>, decimal> aggregator = l => l.Sum(emp => emp.Salary);

            var resultsByDepartment = source.Pivot(firstKeySelector, secondKeySelector, aggregator);

            Assert.IsTrue(resultsByDepartment.ContainsKey("R&D"));
        }

        [Test]
        public void EnumerablePivotKeysBySecondKey()
        {
            IEnumerable<TestEmployee> source = new List<TestEmployee>
            {
                new TestEmployee {Name = "Fons", Department = "R&D", Function  ="Trainer", Salary = 2000 },
                new TestEmployee {Name = "Jim", Department = "R&D", Function  ="Trainer", Salary = 3000 },
                new TestEmployee {Name = "Ellen", Department = "Dev", Function  ="Developer", Salary = 4000 },
                new TestEmployee {Name = "Mike", Department = "Dev", Function  ="Consultant", Salary = 5000 },
                new TestEmployee {Name = "Jack", Department = "R&D", Function  ="Trainer", Salary = 6000 },
                new TestEmployee {Name = "Demy", Department = "Dev", Function  ="Consultant", Salary = 2000 },
            };
            Func<TestEmployee, string> firstKeySelector = emp => emp.Department;
            Func<TestEmployee, string> secondKeySelector = emp => emp.Function;
            Func<IEnumerable<TestEmployee>, decimal> aggregator = l => l.Sum(emp => emp.Salary);

            var resultsByDepartment = source.Pivot(firstKeySelector, secondKeySelector, aggregator);

            Assert.IsTrue(resultsByDepartment["R&D"].ContainsKey("Trainer"));
        }

        [Test]
        public void EnumerablePivotPerformsAggregation()
        {
            IEnumerable<TestEmployee> source = new List<TestEmployee>
            {
                new TestEmployee {Name = "Fons", Department = "R&D", Function  ="Trainer", Salary = 2000 },
                new TestEmployee {Name = "Jim", Department = "R&D", Function  ="Trainer", Salary = 3000 },
                new TestEmployee {Name = "Ellen", Department = "Dev", Function  ="Developer", Salary = 4000 },
                new TestEmployee {Name = "Mike", Department = "Dev", Function  ="Consultant", Salary = 5000 },
                new TestEmployee {Name = "Jack", Department = "R&D", Function  ="Trainer", Salary = 6000 },
                new TestEmployee {Name = "Demy", Department = "Dev", Function  ="Consultant", Salary = 2000 },
            };
            Func<TestEmployee, string> firstKeySelector = emp => emp.Department;
            Func<TestEmployee, string> secondKeySelector = emp => emp.Function;
            Func<IEnumerable<TestEmployee>, decimal> aggregator = l => l.Sum(emp => emp.Salary);

            var resultsByDepartment = source.Pivot(firstKeySelector, secondKeySelector, aggregator);

            Assert.AreEqual(7000, resultsByDepartment["Dev"]["Consultant"]);
        }

        private class TestItem
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }

        private class TestEmployee
        {
            public string Name { get; set; }

            public string Department { get; set; }

            public string Function { get; set; }

            public decimal Salary { get; set; }
        }
    }
}
