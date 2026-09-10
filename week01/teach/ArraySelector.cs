public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        // The result has one slot for every entry in the selector array.
        var result = new int[select.Length];

        // Two "bookmarks" that remember how far we have read into each source list.
        var index1 = 0;
        var index2 = 0;

        for (var i = 0; i < select.Length; i++)
        {
            if (select[i] == 1)
            {
                // Take the next unused value from list1, then move that bookmark forward.
                result[i] = list1[index1];
                index1++;
            }
            else
            {
                // Otherwise the selector is 2: take the next unused value from list2.
                result[i] = list2[index2];
                index2++;
            }
        }

        return result;
    }
}