using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class GraphTest : MonoBehaviour
    {
        private void Start()
        {
            List<int> numbers = new() { 1, 2, 3, 4, 5, 5 };
            List<int> otherNumbers = new() { 4, 5, 6 };

            Debug.Log("Numbers: " + string.Join(", ", numbers));

            Debug.Log("All positive: " + GraphMethods.All(numbers, n => n > 0));

            Debug.Log("Any > 4: " + GraphMethods.Any(numbers, n => n > 4));

            Debug.Log("Contains 3: " + GraphMethods.Contains(numbers, 3));

            Debug.Log("Distinct ints: " + string.Join(", ", GraphMethods.Distinct(numbers)));

            Debug.Log("Element at index 3 (2 from 0): " + GraphMethods.ElementAt(numbers, 2));

            Debug.Log("Except (numbers - otherNumbers): " +
                      string.Join(", ", GraphMethods.Except(numbers, otherNumbers)));

            Debug.Log("First > 2: " + GraphMethods.First(numbers, n => n > 2));

            Debug.Log("Last even: " + GraphMethods.Last(numbers, n => n % 2 == 0));

            Debug.Log("Intersect: " +
                      string.Join(", ", GraphMethods.Intersect(numbers, otherNumbers)));

            Debug.Log("Count > 2: " + GraphMethods.Count(numbers, n => n > 2));

            Debug.Log("SequenceEqual (numbers == numbers): " +
                      GraphMethods.SequenceEqual(numbers, numbers,
                          EqualityComparer<int>.Default));

            try
            {
                Debug.Log("Single == 4: " +
                          GraphMethods.Single(numbers, n => n == 4));
            }
            catch (System.Exception e)
            {
                Debug.Log("Single error: " + e.Message);
            }

            Debug.Log("SkipWhile < 3: " +
                      string.Join(", ", GraphMethods.SkipWhile(numbers, n => n < 3)));

            Debug.Log("Union: " +
                      string.Join(", ", GraphMethods.Union(numbers, otherNumbers)));

            Debug.Log("Where even numbers: " +
                      string.Join(", ", GraphMethods.Where(numbers, n => n % 2 == 0)));


            List<string> names = new() { "Alice", "Bob", "Charlie", "Alice" };
            List<string> otherNames = new() { "Bob", "Eve" };

            Debug.Log("//////////////////////////////////////////////////////////");
            Debug.Log("\nNames: " + string.Join(", ", names));

            Debug.Log("Contains 'Bob': " + GraphMethods.Contains(names, "Bob"));

            Debug.Log("Distinct strings: " +
                      string.Join(", ", GraphMethods.Distinct(names)));

            Debug.Log("First starting with A: " +
                      GraphMethods.First(names, s => s.StartsWith("A")));

            Debug.Log("Last starting with A: " +
                      GraphMethods.Last(names, s => s.StartsWith("A")));

            Debug.Log("Intersect names: " +
                      string.Join(", ", GraphMethods.Intersect(names, otherNames)));

            Debug.Log("Except names - otherNames: " +
                      string.Join(", ", GraphMethods.Except(names, otherNames)));

            Debug.Log("Union names: " +
                      string.Join(", ", GraphMethods.Union(names, otherNames)));

            Debug.Log("Count names with length > 3: " +
                      GraphMethods.Count(names, s => s.Length > 3));

            Debug.Log("SequenceEqual(names, names): " +
                      GraphMethods.SequenceEqual(names, names,
                          EqualityComparer<string>.Default));

            try
            {
                Debug.Log("Single == 'Charlie': " +
                          GraphMethods.Single(names, s => s == "Charlie"));
            }
            catch (System.Exception e)
            {
                Debug.Log("Single error: " + e.Message);
            }

            Debug.Log("SkipWhile name length < 5: " +
                      string.Join(", ", GraphMethods.SkipWhile(names, s => s.Length < 5)));

            Debug.Log("Where contains 'a': " +
                      string.Join(", ", GraphMethods.Where(names, s => s.Contains('a') || s.Contains('A'))));
        }
    }
}