using System;
using Dunk.Tools.Foundation.Pools;

namespace Dunk.Tools.Foundation.Test.Stubs
{
    /// <summary>
    /// A stub class intended for testing the object pools.
    /// </summary>
    public class TestPoolObject : IObjectPoolItem
    {
        public TestPoolObject()
        {
            Numbers = new int[10000];
            Random rand = new Random();

            for (int i = 0; i < Numbers.Length; i++)
            {
                Numbers[i] = rand.Next();
            }
        }

        public int[] Numbers
        {
            get;
            private set;
        }

        public bool StateReset
        {
            get;
            private set;
        }

        public bool ResourcesRelated
        {
            get;
            private set;
        }

        public double GetValue(long index)
        {
            return Math.Sqrt(Numbers[index]);
        }

        public void ResetState()
        {
            StateReset = true;
        }

        public void ReleaseResources()
        {
            ResourcesRelated = true;
        }
    }
}
