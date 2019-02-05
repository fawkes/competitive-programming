// HackerRank/Algorithms/Greedy
// Min Max
// Link: https://www.hackerrank.com/challenges/angry-children/problem

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{
  // Complete the maxMin function below.
  static int maxMin(int k, int[] arr)
  {
    int result = int.MaxValue;

    var sortedArray = arr.OrderByDescending(i => i).ToArray();
    for (int i = 0; i < sortedArray.Length - k + 1; i++)
    {
      result = Math.Min(result, sortedArray[i] - sortedArray[i + k - 1]);
    }

    return result;

  }

  static void Main(string[] args)
  {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    int n = Convert.ToInt32(Console.ReadLine());

    int k = Convert.ToInt32(Console.ReadLine());

    int[] arr = new int[n];

    for (int i = 0; i < n; i++)
    {
      int arrItem = Convert.ToInt32(Console.ReadLine());
      arr[i] = arrItem;
    }

    int result = maxMin(k, arr);

    textWriter.WriteLine(result);

    textWriter.Flush();
    textWriter.Close();
  }
}
