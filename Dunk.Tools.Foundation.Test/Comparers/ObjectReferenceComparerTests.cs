using System;
using System.Collections.Generic;
using Dunk.Tools.Foundation.Comparers;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Comparers
{
    [TestFixture]
    public class ObjectReferenceComparerTests
    {
        [Test]
        public void ComparerInitialises()
        {
            var comparer = new ObjectReferenceComparer<ObjRefComparerTestStub>();
            Assert.IsNotNull(comparer);
        }

        [Test]
        public void ComparerReturnsTrueIfOjectsAreSameInstance()
        {
            var comparer = new ObjectReferenceComparer<ObjRefComparerTestStub>();

            var x = new ObjRefComparerTestStub(1);
            var y = x;

            bool result = comparer.Equals(x, y);

            Assert.IsTrue(result);
        }

        [Test]
        public void ComparerReturnsFalseIfObjectsAreNotSame()
        {
            var comparer = new ObjectReferenceComparer<ObjRefComparerTestStub>();

            var x = new ObjRefComparerTestStub(1);
            var y = new ObjRefComparerTestStub(2);

            bool result = comparer.Equals(x, y);

            Assert.IsFalse(result);
        }

        [Test]
        public void ComparerReturnsFalseIfObjectsAreNotSameInstanceIgnoringEqualsOverride()
        {
            var comparer = new ObjectReferenceComparer<ObjRefComparerTestStub>();

            var x = new ObjRefComparerTestStub(1);
            var y = new ObjRefComparerTestStub(1);

            bool comparerResult = comparer.Equals(x, y);
            bool equalsResult = x.Equals((object)y);

            Assert.IsFalse(comparerResult);
            Assert.IsTrue(equalsResult);
        }

        [Test]
        public void ComparerReturnsFalseIfObjectsAreNotSameInstanceIgnoringEquatableImplementation()
        {
            var comparer = new ObjectReferenceComparer<ObjRefComparerTestStub>();

            var x = new ObjRefComparerTestStub(1);
            var y = new ObjRefComparerTestStub(1);

            bool comparerResult = comparer.Equals(x, y);
            bool equalsResult = x.Equals(y);

            Assert.IsFalse(comparerResult);
            Assert.IsTrue(equalsResult);
        }

        [Test]
        public void DefaultComparerReturnsTrueIfOjectsAreSameInstance()
        {
            var comparer = ObjectReferenceComparer<ObjRefComparerTestStub>.Default;

            var x = new ObjRefComparerTestStub(1);
            var y = x;

            bool result = comparer.Equals(x, y);

            Assert.IsTrue(result);
        }

        [Test]
        public void DefaultComparerReturnsFalseIfObjectsAreNotSame()
        {
            var comparer = ObjectReferenceComparer<ObjRefComparerTestStub>.Default;

            var x = new ObjRefComparerTestStub(1);
            var y = new ObjRefComparerTestStub(2);

            bool result = comparer.Equals(x, y);

            Assert.IsFalse(result);
        }


        [Test]
        public void DefaultComparerReturnsFalseIfObjectsAreNotSameInstanceIgnoringEqualsOverride()
        {
            var comparer = ObjectReferenceComparer<ObjRefComparerTestStub>.Default;

            var x = new ObjRefComparerTestStub(1);
            var y = new ObjRefComparerTestStub(1);

            bool comparerResult = comparer.Equals(x, y);
            bool equalsResult = x.Equals((object)y);

            Assert.IsFalse(comparerResult);
            Assert.IsTrue(equalsResult);
        }

        [Test]
        public void DefaultComparerReturnsFalseIfObjectsAreNotSameInstanceIgnoringEquatableImplementation()
        {
            var comparer = ObjectReferenceComparer<ObjRefComparerTestStub>.Default;

            var x = new ObjRefComparerTestStub(1);
            var y = new ObjRefComparerTestStub(1);

            bool comparerResult = comparer.Equals(x, y);
            bool equalsResult = x.Equals(y);

            Assert.IsFalse(comparerResult);
            Assert.IsTrue(equalsResult);
        }

        [Test]
        public void ObjectReferenceComparerGetHashCodeReturnsSameHashCodeForObject()
        {
            var comparer = ObjectReferenceComparer<IEquatable<ObjRefComparerTestStub>>.Default;

            IEquatable<ObjRefComparerTestStub> obj = new ObjRefComparerTestStub(2);

            //get the HashCode 2000 times to confirm it is consistent for lifetime of the object
            HashSet<int> hashes = new HashSet<int>();
            for (int i = 0; i < 2000; i++)
            {
                hashes.Add(comparer.GetHashCode(obj));
            }

            Assert.AreEqual(1, hashes.Count);
        }

        [Test]
        public void ObjectReferenceComparerGetHashCodeReturnsSameHashCodeForNullObject()
        {
            var comparer = ObjectReferenceComparer<IEquatable<ObjRefComparerTestStub>>.Default;

            IEquatable<ObjRefComparerTestStub> obj = null;

            //get the HashCode 2000 times to confirm it is consistent for lifetime of the object
            HashSet<int> hashes = new HashSet<int>();
            for (int i = 0; i < 2000; i++)
            {
                hashes.Add(comparer.GetHashCode(obj));
            }
            Assert.AreEqual(1, hashes.Count);
        }


        private sealed class ObjRefComparerTestStub : IEquatable<ObjRefComparerTestStub>
        {
            public ObjRefComparerTestStub(int id)
            {
                Id = id;
            }

            public int Id 
            {
                get;
                set;
            }

            public override int GetHashCode()
            {
                return Id.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }
                return Equals((ObjRefComparerTestStub)obj);
            }

            public bool Equals(ObjRefComparerTestStub other)
            {
                if (other == null)
                {
                    return false;
                }
                return Id == other.Id;
            }
        }
    }
}
