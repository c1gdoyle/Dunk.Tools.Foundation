using System;
using System.Threading;
using System.Threading.Tasks;
using Dunk.Tools.Foundation.Collections;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Collections
{
    [TestFixture]
    public class ThrottledProcessingQueueTests
    {
        [Test]
        public void ProcessingQueueInitialises()
        {
            var queue = new ThrottledProcessingQueue();
            Assert.IsNotNull(queue);
        }

        [Test]
        public void ProcessingQueueInitialisesWithSpecifiedMaxOperations()
        {
            var queue = new ThrottledProcessingQueue(100);
            Assert.IsNotNull(queue);
        }

        [Test]
        public void ProcessingQueueThrowsIfMaxOperationsIsZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ThrottledProcessingQueue(0));
        }

        [Test]
        public void ProcessingQueueThrowsIfMaxOperationsIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ThrottledProcessingQueue(-1));
        }

        [Test]
        public void ProcessingQueueStartsOperationIfProcessQueueIsNotFull()
        {
            bool operationProcessed = false;

            var queue = new ThrottledProcessingQueue();

            Task operation = new Task(() =>
            {
                operationProcessed = true;
            });

            queue.RegisterOperations(new[] { operation });

            operation.Wait();

            Assert.IsTrue(operationProcessed);
        }

        [Test]
        public void ProcessingQueueEnqueuesOperationIfProcessQueueIsFull()
        {
            bool operation1Processed = false;
            bool operation2Processed = false;

            var queue = new ThrottledProcessingQueue(1);
            ManualResetEventSlim pause = new ManualResetEventSlim(false);

            Task operation1 = new Task(() =>
            {
                //simulate a long running operation
                Thread.Sleep(TimeSpan.FromMilliseconds(100));
                operation1Processed = true;
            });
            Task operation2 = new Task(() =>
            {
                operation2Processed = true;
                pause.Set();
            });

            queue.RegisterOperation(operation1);
            queue.RegisterOperation(operation2);
            operation1.ContinueWith(t => queue.UpdateProcessingQueue());

            pause.Wait(TimeSpan.FromSeconds(10));

            Assert.IsTrue(operation1Processed);
            Assert.IsTrue(operation2Processed);
        }

        [Test]
        public void ProcessingQueueEnqueuesOperationIfProcessQueueIsFullAndCurrentlyRunningTaskFails()
        {
            bool operation1Processed = false;
            bool operation2Processed = false;
            int x = 0;

            var queue = new ThrottledProcessingQueue(1);
            ManualResetEventSlim pause = new ManualResetEventSlim(false);

            Task operation1 = new Task(() =>
            {
                //simulate a long running operation
                Thread.Sleep(TimeSpan.FromMilliseconds(100));
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
            operation1.ContinueWith(t => queue.UpdateProcessingQueue());

            pause.Wait(TimeSpan.FromSeconds(10));

            Assert.IsTrue(operation1Processed);
            Assert.IsTrue(operation2Processed);
        }

        [Test]
        public void ProcessingQueueEnqueuesOperationsIfProcessQueueIsFullMultiThreaded()
        {
            bool operation1Processed = false;
            bool operation2Processed = false;

            var queue = new ThrottledProcessingQueue(10);
            ManualResetEventSlim pause = new ManualResetEventSlim(false);

            Parallel.For(0, 10, i => queue.RegisterOperation(new Task(() =>
            {
                //simulate long running operation
                Thread.Sleep(TimeSpan.FromMilliseconds(100));
                operation1Processed = true;

                queue.UpdateProcessingQueue();
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
        public void ProcessingQueueEnqueuesOperationsIfProcessQueueIsFullMultiThreadedAndCurrentlyRunningTaskFails()
        {
            bool operation1Processed = false;
            bool operation2Processed = false;
            int x = 0;

            var queue = new ThrottledProcessingQueue(10);
            ManualResetEventSlim pause = new ManualResetEventSlim(false);

            Parallel.For(0, 10, i => queue.RegisterOperation(new Task(() =>
            {
                //simulate long running operation
                Thread.Sleep(TimeSpan.FromMilliseconds(100));
                operation1Processed = true;

                queue.UpdateProcessingQueue();

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
        public void ProcessingQueueOperationsInProcessDoesNotExceedMaxOperations()
        {
            const int expected = 20;

            bool maxOperationsExceeded = false;
            int operationsProcessed = 0;

            ManualResetEventSlim pause = new ManualResetEventSlim(false);

            var queue = new ThrottledProcessingQueue(10);
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                queue.RegisterOperation(new Task(() =>
                {
                    if (queue.OperationsInProcess == 20)
                    {
                        maxOperationsExceeded = true;
                    }

                    //simulate operation running
                    Thread.Sleep(TimeSpan.FromMilliseconds(random.Next(0, 200)));

                    Interlocked.Increment(ref operationsProcessed);
                    if(operationsProcessed == 20)
                    {
                        pause.Set();
                    }

                    queue.UpdateProcessingQueue();
                }));
            }

            pause.Wait(TimeSpan.FromSeconds(10));

            Assert.IsFalse(maxOperationsExceeded);
            Assert.AreEqual(expected, operationsProcessed);
        }

        [Test]
        public void ProcessingQueueOperationsInProcessDoesNotExceedMaxOperationsMultiThreaded()
        {
            const int expected = 20;

            bool maxOperationsExceeded = false;
            int operationsProcessed = 0;

            ManualResetEventSlim pause = new ManualResetEventSlim(false);

            var queue = new ThrottledProcessingQueue(10);
            Random random = new Random();
            Parallel.For(0, 20, i => queue.RegisterOperation(new Task(() =>
            {
                if (queue.MaxOperations == 20)
                {
                    maxOperationsExceeded = true;
                }

                //simulate operation running
                Thread.Sleep(TimeSpan.FromMilliseconds(random.Next(0, 200)));

                Interlocked.Increment(ref operationsProcessed);
                if (operationsProcessed == 20)
                {
                    pause.Set();
                }
                queue.UpdateProcessingQueue();
            })));

            pause.Wait(TimeSpan.FromSeconds(10));

            Assert.IsFalse(maxOperationsExceeded);
            Assert.AreEqual(expected, operationsProcessed);
        }

        [Test]
        public void ProcessinQueueEnqueueOperationThrowsIfTaskIsNull()
        {
            var queue = new ThrottledProcessingQueue();
            Assert.Throws<ArgumentNullException>(() => queue.RegisterOperation(null as Task));
        }

        [Test]
        public void ProcessingQueueEnqueueOperationThrowsIfTasksCollectionIsNull()
        {
            var queue = new ThrottledProcessingQueue();
            Assert.Throws<ArgumentNullException>(() => queue.RegisterOperations(null as Task[]));
        }

        [Test]
        public void ProcessingQueueEnqueueOperationThrowsIfTaskCollectionContainsNull()
        {
            var queue = new ThrottledProcessingQueue();
            Task[] tasks = new[] { new Task(() => { }), null, new Task(() => { }) };

            Assert.Throws<ArgumentException>(() => queue.RegisterOperations(tasks));
        }

        [Test]
        public void ProcessingQueueEnqueueOperationThrowsIfTaskIsAlreadyStarted()
        {
            var queue = new ThrottledProcessingQueue();

            Task t = Task.Factory.StartNew(() => { });

            Assert.Throws<ArgumentException>(() => queue.RegisterOperation(t));
        }

        [Test]
        public void ProcessingQueueEnqueueOperationThrowsIfTaskSchedulerIsNull()
        {
            var queue = new ThrottledProcessingQueue();

            Task t = new Task(() => { });

            Assert.Throws<ArgumentNullException>(() => queue.RegisterOperation(t, null as TaskScheduler));
        }
    }
}
