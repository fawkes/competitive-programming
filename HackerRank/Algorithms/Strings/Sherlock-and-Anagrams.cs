// HackerRank/Algorithms/Strings
// Sherlock and Anagrams
// Link: https://www.hackerrank.com/challenges/sherlock-and-anagrams/problem

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

  static bool IsAnagram(string s1, string s2)
  {
    int[] first = new int[26];
    int[] second = new int[26];

    foreach (var c in s1.ToCharArray())
    {
      first[c - 'a']++;
    }

    foreach (var c in s2.ToCharArray())
    {
      second[c - 'a']++;
    }

    for (int i = 0; i < 26; i++)
    {
      if (first[i] != second[i])
        return false;
    }

    return true;
  }

  // Complete the sherlockAndAnagrams function below.
  static int sherlockAndAnagrams(string s)
  {
    int result = 0;

    for (int length = 1; length < s.Length; length++)
    {
      var substrings = new List<string>();
      for (int i = 0; i < s.Length - length + 1; i++)
      {
        string sub = s.Substring(i, length);
        result += substrings.Count(str => IsAnagram(sub, str));
        substrings.Add(sub);
      }
    }
    return result;
  }

  static void Main(string[] args)
  {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    int q = Convert.ToInt32(Console.ReadLine());

    for (int qItr = 0; qItr < q; qItr++)
    {
      string s = Console.ReadLine();

      int result = sherlockAndAnagrams(s);

      textWriter.WriteLine(result);
    }

    textWriter.Flush();
    textWriter.Close();
  }
}
