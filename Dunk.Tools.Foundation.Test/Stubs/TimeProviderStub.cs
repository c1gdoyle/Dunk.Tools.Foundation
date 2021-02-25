using System;
using Dunk.Tools.Foundation.Contexts;

namespace Dunk.Tools.Foundation.Test.Stubs
{
    public class TimeProviderStub : TimeProvider
    {
        private readonly DateTime _testDateTimeNow;

        public TimeProviderStub(DateTime testDateTimeNow)
        {
            _testDateTimeNow = testDateTimeNow;
        }

        public override DateTime UtcNow
        {
            get
            {
                return _testDateTimeNow;
            }
        }
    }
}
