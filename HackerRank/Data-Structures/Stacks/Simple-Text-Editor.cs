// HackerRank/Data Structures/Stacks
// Simple Text Editor
// Link: https://www.hackerrank.com/challenges/simple-text-editor/problem

using System;
using System.Collections.Generic;
using System.IO;

class Action
{
	private readonly int _type;
	private readonly string _value;

	public Action(int type, string value)
	{
		_type = type;
		_value = value;
	}

	public void Undo(ref string input)
	{
		if (_type == 1)
		{
			input = input.Substring(0, input.Length - _value.Length);
		}
		else if (_type == 2)
		{
			input += _value;
		}
	}
}

class Solution
{
	static void Main(String[] args)
	{
		//TextReader textReader = new StreamReader("D:\\Temp\\input-c#.txt");
		//TextWriter textWriter = new StreamWriter("D:\\Temp\\output-C#.txt", false);

		TextReader textReader = Console.In;
		TextWriter textWriter = Console.Out;

		var stack = new Stack<Action>();
		int n = Convert.ToInt32(textReader.ReadLine());
		string s = string.Empty;

		for (int i = 0; i < n; i++)
		{
			var query = textReader.ReadLine().Split(' ');
			switch (query[0])
			{
				case "1":
				{
					s += query[1];
					stack.Push(new Action(1, query[1]));
					break;
				}

				case "2":
				{
					int count = Convert.ToInt32(query[1]);
					stack.Push(new Action(2, s.Substring(s.Length - count, count)));
					s = s.Substring(0, s.Length - count);
					break;
				}

				case "3":
				{
					textWriter.WriteLine(s[Convert.ToInt32(query[1]) - 1]);
					break;
				}

				case "4":
				{
					if (stack.Count > 0)
					{
						var action = stack.Pop();
						action.Undo(ref s);
					}
					break;
				}
			}
		}

		textReader.Close();
		textWriter.Flush();
		textWriter.Close();
	}
}

