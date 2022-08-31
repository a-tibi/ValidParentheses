using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ValidParentheses
{
	class Solution
	{
		public bool IsValid(string s)
		{
			char[] brackets = s.ToCharArray();
			char[] openBrackets = { '(', '{', '[' };
			char[] closedBrackets = { ')', '}', ']' };
			var myStack = new Stack();

			for (int i = 0; i < brackets.Length; i++)
			{
				if (openBrackets.Contains(brackets[i]))
				{
					myStack.Push(brackets[i]);
				}
				else if (closedBrackets.Contains(brackets[i]))
				{
					if (myStack != null && myStack.Count != 0)
					{
						var closedB = brackets[i];
						var openB = myStack.Pop();
						int closedBIndex = Array.IndexOf(closedBrackets, closedB);
						int openBIndex = Array.IndexOf(openBrackets, openB);
						if (closedBIndex != openBIndex)
						{
							return true;
						}
					}
					else
					{
						return true;
					}
				}
			}
			if (myStack.Count != 0)
				return true;

			return false;

		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			var inputs = new List<string>
			{
				"()",
				"()[]{}",
				"([{}])",
				"([{])",
				"((({[]}",
				")([]){}"
			};


			Solution solution = new Solution();
			foreach (var input in inputs)
			{
				if (solution.IsValid(input))
				{
					Console.WriteLine($"{input}, Invalid");
				}
				else
				{
					Console.WriteLine($"{input}, Valid");
				}
			}
		
			Console.ReadKey();
		}
	}
}
