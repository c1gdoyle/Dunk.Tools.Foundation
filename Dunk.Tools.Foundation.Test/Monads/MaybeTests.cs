using System;
using System.Collections.Generic;
using System.Linq;
using Dunk.Tools.Foundation.Monads;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Monads
{
    [TestFixture]
    public class MaybeTests
    {
        [Test]
        public void MaybeInitialises()
        {
            var instance = new TestChildItem();

            var maybe = new Maybe<TestChildItem>(instance);

            Assert.IsNotNull(maybe);
        }

        [Test]
        public void MaybeThrowsIfValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Maybe<TestChildItem>(null as TestChildItem));
        }


        [Test]
        public void MaybeContainingInstanceHasValue()
        {
            var maybe = new Maybe<TestChildItem>(new TestChildItem());
            Assert.IsTrue(maybe.HasValue);
        }

        [Test]
        public void MaybeContainingNoInstanceDoesNotHaveValue()
        {
            var maybe = Maybe<TestChildItem>.None();
            Assert.IsFalse(maybe.HasValue);
        }

        [Test]
        public void InstanceCanBeConvertedToMaybe()
        {
            TestChildItem instance = new TestChildItem();
            Maybe<TestChildItem> maybe = (Maybe<TestChildItem>)instance;

            Assert.IsNotNull(maybe);
            Assert.IsTrue(maybe.HasValue);
        }

        [Test]
        public void NullCanBeConvertedToMaybe()
        {
            TestChildItem instance = null;
            Maybe<TestChildItem> maybe = (Maybe<TestChildItem>)instance;

            Assert.IsNotNull(maybe);
            Assert.IsFalse(maybe.HasValue);
        }

        [Test]
        public void MaybeSupportsChaining()
        {
            var parent = new TestParentItem
            {
                Id = 111,
                Items = new List<TestChildItem>
                {
                    new TestChildItem {Id = 1 },
                    new TestChildItem {Id = 2 },
                    new TestChildItem {Id = 3 },
                    new TestChildItem {Id = 4 },
                    new TestChildItem {Id = 5 },
                    new TestChildItem {Id = 6 },
                }
            };

            var maybe = new Maybe<TestParentItem>(parent);

            Func<TestParentItem, Maybe<TestChildItem>> chainFunc = p =>
            {
                return new Maybe<TestChildItem>(p.Items.FirstOrDefault(i => i.Id == 2));
            };

            var resultMaybe = maybe.Chain(chainFunc);

            Assert.IsTrue(resultMaybe.HasValue);
        }

        [Test]
        public void MaybeSupportsMultiLevelChaining()
        {
            var items = GetTestItems();
            var maybe1 = new Maybe<IEnumerable<TestGrandParentItem>>(items);

            Func<IEnumerable<TestGrandParentItem>, TestGrandParentItem> chainFunc1 =
                sequence => sequence.FirstOrDefault(i => i.Id == 1);
            Func<TestGrandParentItem, TestParentItem> chainFunc2 =
                i => i.Items.FirstOrDefault(p => p.Id == 11);
            Func<TestParentItem, TestChildItem> chainFunc3 =
                i => i.Items.FirstOrDefault();

            var resultMaybe = maybe1
                .Chain(chainFunc1)
                .Chain(chainFunc2)
                .Chain(chainFunc3);

            Assert.IsTrue(resultMaybe.HasValue);
            Assert.AreEqual(111, resultMaybe.Value.Id);
        }

        private IEnumerable<TestGrandParentItem> GetTestItems()
        {
            return new List<TestGrandParentItem>
            {
                new TestGrandParentItem
                {
                    Id = 1,
                    Items = new List<TestParentItem>
                    {
                        new TestParentItem
                        {
                            Id = 11,
                            Items = new List<TestChildItem>
                            {
                                new TestChildItem {Id = 111 }
                            }
                        }
                    }
                },
                new TestGrandParentItem
                {
                    Id = 2,
                    Items = new List<TestParentItem>
                    {
                        new TestParentItem
                        {
                            Id = 22,
                            Items = new List<TestChildItem>
                            {
                                new TestChildItem {Id = 222 }
                            }
                        }
                    }
                }
            };
        }

        private class TestChildItem
        {
            public int Id { get; set; }
        }

        private class TestParentItem
        {
            public int Id { get; set; }

            public IList<TestChildItem> Items { get; set; }
        }

        private class TestGrandParentItem
        {
            public int Id { get; set; }

            public IList<TestParentItem> Items { get; set; }
        }
    }
}
