using System;
using System.Collections.Generic;

namespace Interpreter
{
    public interface Expression
    {
        void Interpret(Stack<int> context);
    }
    
    public class TerminalExpression_Number : Expression
    {
        private int number;
        public TerminalExpression_Number(int number) => this.number = number;
        public void Interpret(Stack<int> context) => context.Push(number);
    }
    class TerminalExpression_Plus : Expression
    {
        public void Interpret(Stack<int> context) => context.Push(context.Pop() + context.Pop());
    }
    class TerminalExpression_Minus : Expression
    {
        public void Interpret(Stack<int> context) => context.Push(-context.Pop() + context.Pop());
    }

    class Parser
    {
        private List<Expression> parseTree = new List<Expression>(); // only one NonTerminal Expression here

        public Parser(String s)
        {
            foreach (String token in s.Split(" "))
            {
                if (token.Equals("+"))
                    parseTree.Add(new TerminalExpression_Plus());
                else if (token.Equals("-"))
                    parseTree.Add(new TerminalExpression_Minus());
                else
                    parseTree.Add(new TerminalExpression_Number(int.Parse(token)));
            }
        }

        public int evaluate()
        {
            Stack<int> context = new Stack<int>();
            foreach (Expression e in parseTree)
                e.Interpret(context);
            return context.Pop();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<Interpreter>");
            String input = "42 2 1 - +";
            Console.WriteLine($"Input: {input}");
            Console.WriteLine("Output: " + new Parser(input).evaluate());
        }
    }
}
