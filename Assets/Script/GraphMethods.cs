using System;
using System.Collections.Generic;

namespace Script
{
    public abstract class GraphMethods
    {
        /// <summary>
        /// Determines whether any element of a sequence satisfies a condition.
        /// Time: O(n)
        /// Space: O(1)
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static bool All<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (TSource item in source)
                if (!predicate(item))
                    return false;

            return true;
        }

        /// <summary>
        /// Determines whether any element of a sequence satisfies a condition.
        /// Time: O(n)
        /// Space: O(1)
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static bool Any<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (TSource item in source)
                if (predicate(item))
                    return true;

            return false;
        }

        /// <summary>
        /// Determines whether a sequence contains a specified element by using the default equality comparer.
        /// Time: O(n)
        /// Space: O(1)
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Contains<TSource>(IEnumerable<TSource> source, TSource item)
        {
            EqualityComparer<TSource> comparer = EqualityComparer<TSource>.Default;

            foreach (TSource element in source)
                if (comparer.Equals(element, item))
                    return true;

            return false;
        }

        /// <summary>
        /// Determines whether a sequence contains a specified element by using a specified IEqualityComparer<T>.
        /// Time: O(n)
        /// Space: O(1)
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static bool Contains<TSource>(IEnumerable<TSource> source, TSource item, IEqualityComparer<TSource> comparer)
        {
            comparer ??= EqualityComparer<TSource>.Default;

            foreach (TSource element in source)
                if (comparer.Equals(element, item))
                    return true;

            return false;
        }

        /// <summary>
        /// Returns distinct elements from a sequence by using the default equality comparer to compare values.
        /// Time: O(n)
        /// Space: O(n)
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Distinct<TSource>(IEnumerable<TSource> source) =>
            Distinct(source, EqualityComparer<TSource>.Default);


        /// <summary>
        /// Returns distinct elements from a sequence by using a specified IEqualityComparer<T> to compare values.
        /// Time: O(n)
        /// Space: O(n)
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Distinct<TSource>(IEnumerable<TSource> source,
            IEqualityComparer<TSource> comparer)
        {
            HashSet<TSource> seen = new(comparer);
        
            foreach (TSource item in source)
                if (seen.Add(item))
                    yield return item;
        }

        /// <summary>
        /// Returns the element at a specified index in a sequence.
        /// Time: O(n)
        /// Space: O(1)
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static TSource ElementAt<TSource>(IEnumerable<TSource> source, int index)
        {
            int i = 0;

            foreach (TSource item in source)
            {
                if (i == index)
                    return item;

                i++;
            }

            throw new ArgumentOutOfRangeException(nameof(index));
        }

        /// <summary>
        /// Produces the set difference of two sequences by using the specified IEqualityComparer<T>.Default to compare values.
        /// Time: O(n + m)
        /// Space: O(m)
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source1"></param>
        /// <param name="source2"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Except<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2) =>
            Except(source1, source2, EqualityComparer<TSource>.Default);


        /// <summary>
        /// Produces the set difference of two sequences by using the specified IEqualityComparer<T> to compare values.
        /// Time: O(n + m)
        /// Space: O(m)
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source1"></param>
        /// <param name="source2"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Except<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2,
            IEqualityComparer<TSource> comparer)
        {
            HashSet<TSource> excluded = new(source2, comparer);

            foreach (TSource item in source1)
                if (excluded.Add(item)) // Add returns false if already present
                    yield return item;
        }

        /// <summary>
        /// Returns the first element in a sequence that satisfies a specified condition.
        /// Time: O(n)
        /// Space: O(1)
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static TSource First<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (TSource item in source)
                if (predicate(item))
                    return item;

            throw new InvalidOperationException("No element satisfies the condition.");
        }

        /// <summary>
        /// Returns the last element of a sequence that satisfies a specified condition.
        /// Time: O(n)
        /// Space: O(1)
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static TSource Last<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            TSource last = default;
            bool found = false;

            foreach (TSource item in source)
                if (predicate(item))
                {
                    last = item;
                    found = true;
                }

            if (!found)
                throw new InvalidOperationException("No element satisfies the condition.");

            return last;
        }

        /// <summary>
        /// Produces the set intersection of two sequences by using the default equality comparer to compare values.
        /// Time: O(n + m)
        /// Space: O(m)
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source1"></param>
        /// <param name="source2"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Intersect<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2) =>
            Intersect(source1, source2, EqualityComparer<TSource>.Default);


        /// <summary>
        /// Produces the set intersection of two sequences by using the specified IEqualityComparer<T> to compare values.
        /// Time: O(n + m)
        /// Space: O(m)
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source1"></param>
        /// <param name="source2"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Intersect<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2,
            IEqualityComparer<TSource> comparer)
        {
            HashSet<TSource> set = new(source2, comparer);
            HashSet<TSource> yielded = new(comparer);

            foreach (TSource item in source1)
                if (set.Contains(item) && yielded.Add(item))
                    yield return item;
        }

        /// <summary>
        /// Returns a number that represents how many elements in the specified sequence satisfy a condition.
        /// Time: O(n)
        /// Space: O(1)
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static int Count<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            int count = 0;

            foreach (TSource item in source)
                if (predicate(item))
                    count++;

            return count;
        }

        /// <summary>
        /// Determines whether two sequences are equal by comparing their elements by using a specified IEqualityComparer<T>.
        /// Time: O(n)
        /// Space: O(1)
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source1"></param>
        /// <param name="source2"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static bool SequenceEqual<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2,
            IEqualityComparer<TSource> comparer)
        {
            comparer ??= EqualityComparer<TSource>.Default;

            using IEnumerator<TSource> e1 = source1.GetEnumerator();
            using IEnumerator<TSource> e2 = source2.GetEnumerator();

            while (true)
            {
                bool m1 = e1.MoveNext();
                bool m2 = e2.MoveNext();

                if (!m1 && !m2)
                    return true;

                if (m1 != m2)
                    return false;

                if (!comparer.Equals(e1.Current, e2.Current))
                    return false;
            }
        }

        /// <summary>
        /// Returns the only element of a sequence that satisfies a specified condition, and throws an exception if more than one such element exists.
        /// Time: O(n)
        /// Space: O(1)
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static TSource Single<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            TSource result = default;
            bool found = false;

            foreach (TSource item in source)
                if (predicate(item))
                {
                    if (found)
                        throw new InvalidOperationException("More than one element satisfies the condition.");

                    result = item;
                    found = true;
                }

            if (!found)
                throw new InvalidOperationException("No element satisfies the condition.");

            return result;
        }

        /// <summary>
        /// Bypasses elements in a sequence as long as a specified condition is true and then returns the remaining elements.
        /// Time: O(n)
        /// Space: O(1)
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> SkipWhile<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            bool skipping = true;

            foreach (TSource item in source)
            {
                if (skipping && !predicate(item))
                    skipping = false;

                if (!skipping)
                    yield return item;
            }
        }

        /// <summary>
        /// Produces the set union of two sequences by using the default equality comparer.
        /// Time: O(n + m)
        /// Space: O(n + m)
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source1"></param>
        /// <param name="source2"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Union<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2) =>
            Union(source1, source2, EqualityComparer<TSource>.Default);


        /// <summary>
        /// Produces the set union of two sequences by using a specified IEqualityComparer<T>.
        /// Time: O(n + m)
        /// Space: O(n + m)
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source1"></param>
        /// <param name="source2"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Union<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2,
            IEqualityComparer<TSource> comparer)
        {
            HashSet<TSource> seen = new(comparer);

            foreach (TSource item in source1)
                if (seen.Add(item))
                    yield return item;

            foreach (TSource item in source2)
                if (seen.Add(item))
                    yield return item;
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate. Each element's index is used in the logic of the predicate function.
        /// Time: O(n)
        /// Space: O(1)
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Where<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (TSource item in source)
                if (predicate(item))
                    yield return item;
        }
    }
}