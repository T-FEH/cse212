using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities where the highest priority
    // item is at the back: Low (1), Medium (2), High (3). Dequeue once.
    // Expected Result: "High" is returned.
    // Defect(s) Found: Got "Medium". The search loop stopped at Count - 1, so the last item in the
    // queue was never checked.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 2);
        priorityQueue.Enqueue("High", 3);

        Assert.AreEqual("High", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items where two share the same highest priority: First (5), Second (5), Third (1).
    // Dequeue once.
    // Expected Result: "First" is returned because it is closest to the front (FIFO among ties).
    // Defect(s) Found: Got "Second". The comparison used >= so a later item with an equal priority
    // replaced the earlier one. Changed to > so the first one wins.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 1);

        Assert.AreEqual("First", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue A (1), B (3), C (2). Dequeue three times.
    // Expected Result: B, then C, then A. Each dequeue must actually remove the item.
    // Defect(s) Found: Got B twice. Dequeue read the value but never called RemoveAt, so the item
    // stayed in the queue.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue High (3) then Low (1) and check the string form of the queue.
    // Expected Result: "[High (Pri:3), Low (Pri:1)]" showing items are added to the back in order.
    // Defect(s) Found: None. Enqueue already added to the back.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("High", 3);
        priorityQueue.Enqueue("Low", 1);

        Assert.AreEqual("[High (Pri:3), Low (Pri:1)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: InvalidOperationException is thrown with the message "The queue is empty."
    // Defect(s) Found: None. The empty check and message were already correct.
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                    e.GetType(), e.Message)
            );
        }
    }
}
