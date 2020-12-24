using System;
using System.Threading;
using System.Threading.Tasks;
using Dunk.Tools.Foundation.Collections;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Collections
{
    [TestFixture]
    public class SmartThrottledProcessingQueueTests
    {

        [Test]
        public void SmartProcessingQueueInitialises()
        {
            var queue = new SmartThrottledProcessingQueue();
            Assert.IsNotNull(queue);
        }

        [Test]
        public void SmartProcessingQueueInitialisesWithSpecifiedMaxOperations()
        {
            var queue = new SmartThrottledProcessingQueue(100);
            Assert.IsNotNull(queue);
        }

        [Test]
        public void SmartProcessingQueueThrowsIfMaxOperationsIsZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SmartThrottledProcessingQueue(0));
        }

        [Test]
        public void SmartProcessingQueueThrowsIfMaxOperationsIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SmartThrottledProcessingQueue(-1));
        }


        [Test]
        public void SmartProcessingQueueStartsOperationIfProcessQueueIsNotFull()
        {
            bool operationProcessed = false;

            var queue = new SmartThrottledProcessingQueue();

            Task operation = new Task(() =>
            {
                operationProcessed = true;
            });

            queue.RegisterOperations(new[] { operation });

            operation.Wait();

            Assert.IsTrue(operationProcessed);
        }

        [Test]
        public void SmartProcessingQueueEnqueuesOperationIfProcessQueueIsFull()
        {
            bool operation1Processed = false;
            bool operation2Processed = false;

            var queue = new SmartThrottledProcessingQueue(1);
            ManualResetEventSlim pause = new ManualResetEventSlim(false);

            Task operation1 = new Task(() =>
            {
                //simulate a long running operation
                Thread.Sleep(TimeSpan.FromSeconds(1));
                operation1Processed = true;
            });
            Task operation2 = new Task(() =>
            {
                operation2Processed = true;
                pause.Set();
            });

            queue.RegisterOperation(operation1);
            queue.RegisterOperation(operation2);

            pause.Wait(TimeSpan.FromSeconds(10));

            Assert.IsTrue(operation1Processed);
            Assert.IsTrue(operation2Processed);
        }

        [Test]
        public void SmartProcessingQueueEnqueuesOperationIfProcessQueueIsFullAndCurrentlyRunningTaskFails()
        {
            bool operation1Processed = false;
            bool operation2Processed = false;
            int x = 0;

            var queue = new SmartThrottledProcessingQueue(1);
            ManualResetEventSlim pause = new ManualResetEventSlim(false);

            Task operation1 = new Task(() =>
            {
                //simulate a long running operation
                Thread.Sleep(TimeSpan.FromSeconds(1));
                operation1Processed = true;
                //divide by zero will throw exception
                int y = 32 / x;
            });
            Task operation2 = new Task(() =>
            {
                operation2Processed = true;
                pause.Set();
            });

            queue.RegisterOperation(operation1);
            queue.RegisterOperation(operation2);

            pause.Wait(TimeSpan.FromSeconds(10));

            Assert.IsTrue(operation1Processed);
            Assert.IsTrue(operation2Processed);
        }

        [Test]
        public void SmartProcessingQueueEnqueuesOperationsIfProcessQueueIsFullMultiThreaded()
        {
            bool operation1Processed = false;
            bool operation2Processed = false;

            var queue = new SmartThrottledProcessingQueue(10);
            ManualResetEventSlim pause = new ManualResetEventSlim(false);

            Parallel.For(0, 10, i => queue.RegisterOperation(new Task(() =>
            {
                //simulate long running operation
                Thread.Sleep(TimeSpan.FromSeconds(1));
                operation1Processed = true;
            })));
            queue.RegisterOperation(new Task(() =>
            {
                operation2Processed = true;
                pause.Set();
            }));

            pause.Wait(TimeSpan.FromSeconds(10));

            Assert.IsTrue(operation1Processed);
            Assert.IsTrue(operation2Processed);
        }

        [Test]
        public void SmartProcessingQueueEnqueuesOperationsIfProcessQueueIsFullMultiThreadedAndCurrentlyRunningTaskFails()
        {
            bool operation1Processed = false;
            bool operation2Processed = false;
            int x = 0;

            var queue = new SmartThrottledProcessingQueue(10);
            ManualResetEventSlim pause = new ManualResetEventSlim(false);

            Parallel.For(0, 10, i => queue.RegisterOperation(new Task(() =>
            {
                //simulate long running operation
                Thread.Sleep(TimeSpan.FromSeconds(1));
                operation1Processed = true;

                //divide by zero will throw exception
                int y = 32 / x;
            })));
            queue.RegisterOperation(new Task(() =>
            {
                operation2Processed = true;
                pause.Set();
            }));

            pause.Wait(TimeSpan.FromSeconds(10));

            Assert.IsTrue(operation1Processed);
            Assert.IsTrue(operation2Processed);
        }

        [Test]
        public void SmartProcessingQueueOperationsInProcessDoesNotExceedMaxOperations()
        {
            bool maxOperationsExceeded = false;

            var queue = new SmartThrottledProcessingQueue(10);
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                queue.RegisterOperation(new Task(() =>
                {
                    if (queue.MaxOperations > 10)
                    {
                        maxOperationsExceeded = true;
                    }

                    //simulate operation running
                    Thread.Sleep(TimeSpan.FromMilliseconds(random.Next(0, 1000)));
                }));
            }
            Assert.IsFalse(maxOperationsExceeded);
        }

        [Test]
        public void SmartProcessingQueueOperationsInProcessDoesNotExceedMaxOperationsMultiThreaded()
        {
            bool maxOperationsExceeded = false;

            var queue = new SmartThrottledProcessingQueue(10);
            Random random = new Random();
            Parallel.For(0, 20, i => queue.RegisterOperation(new Task(() =>
            {
                if (queue.MaxOperations > 10)
                {
                    maxOperationsExceeded = true;
                }

                //simulate operation running
                Thread.Sleep(TimeSpan.FromMilliseconds(random.Next(0, 1000)));
            })));

            Assert.IsFalse(maxOperationsExceeded);
        }

        [Test]
        public void SmartProcessinQueueEnqueueOperationThrowsIfTaskIsNull()
        {
            var queue = new SmartThrottledProcessingQueue();
            Assert.Throws<ArgumentNullException>(() => queue.RegisterOperation(null as Task));
        }

        [Test]
        public void SmartProcessingQueueEnqueueOperationThrowsIfTasksCollectionIsNull()
        {
            var queue = new SmartThrottledProcessingQueue();
            Assert.Throws<ArgumentNullException>(() => queue.RegisterOperations(null as Task[]));
        }

        [Test]
        public void SmartProcessingQueueEnqueueOperationThrowsIfTaskCollectionContainsNull()
        {
            var queue = new SmartThrottledProcessingQueue();
            Task[] tasks = new[] { new Task(() => { }), null, new Task(() => { }) };

            Assert.Throws<ArgumentException>(() => queue.RegisterOperations(tasks));
        }

        [Test]
        public void SmartProcessingQueueEnqueueOperationThrowsIfTaskIsAlreadyStarted()
        {
            var queue = new SmartThrottledProcessingQueue();

            Task t = Task.Factory.StartNew(() => { });

            Assert.Throws<ArgumentException>(() => queue.RegisterOperation(t));
        }

        [Test]
        public void SmartProcessingQueueEnqueueOperationThrowsIfTaskSchedulerIsNull()
        {
            var queue = new SmartThrottledProcessingQueue();

            Task t = new Task(() => { });

            Assert.Throws<ArgumentNullException>(() => queue.RegisterOperation(t, null as TaskScheduler));
        }
    }
}
