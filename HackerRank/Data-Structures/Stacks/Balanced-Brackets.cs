// HackerRank/Data Structures/Stacks
// Balanced Brackets
// Link: https://www.hackerrank.com/challenges/balanced-brackets/problem

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

  // Complete the isBalanced function below.
  static string isBalanced(string s)
  {
    var closingBrackers = new Dictionary<char, char>();
    closingBrackers.Add(')', '(');
    closingBrackers.Add('}', '{');
    closingBrackers.Add(']', '[');

    var stack = new Stack<char>();
    for (int i = 0; i < s.Length; i++)
    {
      if (closingBrackers.ContainsKey(s[i]))
      {
        if (stack.Count == 0 || stack.Peek() != closingBrackers[s[i]])
        {
          return "NO";
        }

        stack.Pop();
      }
      else
      {
        stack.Push(s[i]);
      }
    }

    return stack.Count == 0 ? "YES" : "NO";
  }

  static void Main(string[] args)
  {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    int t = Convert.ToInt32(Console.ReadLine());

    for (int tItr = 0; tItr < t; tItr++)
    {
      string s = Console.ReadLine();

      string result = isBalanced(s);

      textWriter.WriteLine(result);
    }

    textWriter.Flush();
    textWriter.Close();
  }
}
