// HackerRank/Data Structures/Stacks
// Largest Rectangle
// Link: https://www.hackerrank.com/challenges/largest-rectangle/problem
//
// Notes:
// 
// This is Maximum Histogram Area problem
// Links:
// https://stackoverflow.com/questions/4311694/maximize-the-rectangular-area-under-histogram
// https://tech.pic-collage.com/algorithm-largest-area-in-histogram-84cc70500f0c
// https://leetcode.com/problems/largest-rectangle-in-histogram/submissions/

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

  static long largestRectangle(int[] h)
  {
    var stack = new Stack<int>();
    long maxArea = 0;
    int[] arr = new int[h.Length + 2];
    arr[0] = -1;
    arr[arr.Length - 1] = -1;
    for (int i = 0; i < h.Length; i++)
    {
      arr[i + 1] = h[i];
    }

    for (int i = 0; i < arr.Length; i++)
    {
      while (stack.Any() && arr[i] < arr[stack.Peek()])
      {
        int height = arr[stack.Pop()];
        if (stack.Any())
        {
          long area = height * (i - stack.Peek() - 1);
          if (area > maxArea)
            maxArea = area;
        }
      }

      stack.Push(i);
    }

    return maxArea;
  }

  static void Main(string[] args)
  {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    int n = Convert.ToInt32(Console.ReadLine());

    int[] h = Array.ConvertAll(Console.ReadLine().Split(' '), hTemp => Convert.ToInt32(hTemp))
    ;
    long result = largestRectangle(h);

    textWriter.WriteLine(result);

    textWriter.Flush();
    textWriter.Close();
  }
}
