// 901. Online Stock Span
// Link: https://leetcode.com/problems/online-stock-span/

public class StockSpanner
{
	Stack<Tuple<int, int>> _stack;

	public StockSpanner()
	{
		_stack = new Stack<Tuple<int, int>>();
	}

	public int Next(int price)
	{
		int result = 1;
		if (_stack.Count == 0)
		{
			_stack.Push(new Tuple<int, int>(price, result));
		}
		else
		{
			while (_stack.Count > 0 && _stack.Peek().Item1 <= price)
			{
				var top = _stack.Pop();
				result += top.Item2;
			}
			_stack.Push(new Tuple<int, int>(price, result));
		}
		return result;
	}
}
