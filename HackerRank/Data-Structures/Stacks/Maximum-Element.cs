// HackerRank/Data Structures/Stacks
// Maximum Element
// Link: https://www.hackerrank.com/challenges/maximum-element/problem

using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
class Solution
{
  static void Main(String[] args)
  {
    var stack = new Stack<int>();
    var maxStack = new Stack<int>();
    int n = Convert.ToInt32(Console.ReadLine());

    for (int i = 0; i < n; i++)
    {
      var values = Console.ReadLine().Split(' ').Select(v => Convert.ToInt32(v)).ToArray();
      if (values[0] == 1)
      {
        if (maxStack.Count == 0 || values[1] >= maxStack.Peek())
        {
          maxStack.Push(values[1]);
        }
        stack.Push(values[1]);
      }
      else if (values[0] == 2)
      {
        if (stack.Peek() == maxStack.Peek())
        {
          maxStack.Pop();
        }
        stack.Pop();
      }
      else if (values[0] == 3)
      {
        Console.WriteLine(maxStack.Peek());
      }
    }

  }
}

