// HackerRank/Data Structures/Stacks
// Equal Stacks
// Link: https://www.hackerrank.com/challenges/equal-stacks/problem

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
  static void Reduce(int[] s, ref int index, ref long sum, long targetSum)
  {
    while (sum > targetSum)
    {
      sum -= s[index];
      index++;
    }
  }
  static int equalStacks(int[] h1, int[] h2, int[] h3)
  {
    long s1 = h1.Sum(i => (long)i);
    long s2 = h2.Sum(i => (long)i);
    long s3 = h3.Sum(i => (long)i);

    int i1 = 0;
    int i2 = 0;
    int i3 = 0;

    while (i1 < h1.Length && (s1 != s2 || s2 != s3))
    {
      Reduce(h2, ref i2, ref s2, s1);
      Reduce(h3, ref i3, ref s3, s1);
      if (s1 == s2 && s2 == s3)
        break;

      s1 -= h1[i1];
      i1++;
    }

    return (int)s1;
  }

  static void Main(string[] args)
  {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    string[] n1N2N3 = Console.ReadLine().Split(' ');

    int n1 = Convert.ToInt32(n1N2N3[0]);

    int n2 = Convert.ToInt32(n1N2N3[1]);

    int n3 = Convert.ToInt32(n1N2N3[2]);

    int[] h1 = Array.ConvertAll(Console.ReadLine().Split(' '), h1Temp => Convert.ToInt32(h1Temp));

    int[] h2 = Array.ConvertAll(Console.ReadLine().Split(' '), h2Temp => Convert.ToInt32(h2Temp));

    int[] h3 = Array.ConvertAll(Console.ReadLine().Split(' '), h3Temp => Convert.ToInt32(h3Temp));
    int result = equalStacks(h1, h2, h3);

    textWriter.WriteLine(result);

    textWriter.Flush();
    textWriter.Close();
  }
}
