public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN:
        // 1. Create a new double array with 'length' slots, since we know the exact size up front.
        // 2. Loop with an index i from 0 up to (but not including) length.
        // 3. The multiple at position i is number * (i + 1). Position 0 holds number * 1,
        //    position 1 holds number * 2, and so on.
        // 4. Store that value at result[i].
        // 5. After the loop finishes, return the filled array.

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN:
        // Rotating right by 'amount' means the last 'amount' items move to the front
        // and everything else shifts after them.
        // 1. Find where the tail starts: startIndex = data.Count - amount.
        // 2. Copy the tail using GetRange(startIndex, amount). That is the last 'amount' items.
        // 3. Remove that tail from the end of data using RemoveRange(startIndex, amount).
        // 4. Insert the saved tail at the front of data using InsertRange(0, tail).
        // 5. The list is modified in place, so nothing needs to be returned.
        // Example with {1..9} and amount 3: tail = {7,8,9}, data becomes {1..6},
        // then inserting the tail at 0 gives {7,8,9,1,2,3,4,5,6}.

        int startIndex = data.Count - amount;
        List<int> tail = data.GetRange(startIndex, amount);
        data.RemoveRange(startIndex, amount);
        data.InsertRange(0, tail);    }
}
