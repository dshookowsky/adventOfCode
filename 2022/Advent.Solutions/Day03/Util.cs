namespace Advent.Solutions.Day03
{
    internal static class Util
    {

        /// <summary>
        /// Break a list of items into chunks of a specific size
        /// </summary>
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunksize)
        {
            while (source.Any())
            {
                yield return source.Take(chunksize);
                source = source.Skip(chunksize);
            }
        }

        public static (T[] left, T[] right) Split<T>(T[] array, int index)
        {
            var left = array.Take(index).ToArray();
            var right = array.Skip(index).ToArray();

            return (left, right);
        }

        public static (T[] left, T[] right) SplitMidPoint<T>(T[] array)
        {
            return Split(array, array.Length / 2);
        }
    }
}