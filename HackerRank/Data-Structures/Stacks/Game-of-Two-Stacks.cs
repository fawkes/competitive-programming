// HackerRank/Data Structures/Stacks
// Game of Two Stacks
// Link: https://www.hackerrank.com/challenges/game-of-two-stacks/problem

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
 static int twoStacks(int x, int[] a, int[] b)
  {
    int i = 0;
    int j = 0;
    int sum = 0;

    while (i < a.Length && sum + a[i] <= x)
    {
      sum += a[i];
      i++;
    }

    int result = i;

    while (j < b.Length && i >= 0)
    {
      sum += b[j];
      j++;
      while (sum > x && i > 0)
      {
        i--;
        sum -= a[i];
      }

      if (sum <= x && i + j > result)
      {
        result = i + j;
      }
    }

    return result;
  }

  static void Main(string[] args)
  {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    int g = Convert.ToInt32(Console.ReadLine());

    for (int gItr = 0; gItr < g; gItr++)
    {
      string[] nmx = Console.ReadLine().Split(' ');

      int n = Convert.ToInt32(nmx[0]);

      int m = Convert.ToInt32(nmx[1]);

      int x = Convert.ToInt32(nmx[2]);

      int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));

      int[] b = Array.ConvertAll(Console.ReadLine().Split(' '), bTemp => Convert.ToInt32(bTemp));
      int result = twoStacks(x, a, b);

      textWriter.WriteLine(result);
    }

    textWriter.Flush();
    textWriter.Close();
  }
}
