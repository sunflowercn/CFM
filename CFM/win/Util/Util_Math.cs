using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace win.Util
{
    public class Util_Math
    {
        static Stack<string> _Stack = new Stack<string>();
        static StringBuilder OutPutExpression = new StringBuilder();
        /// <summary>
        /// 从中缀表达式得到后缀表达式
        /// </summary>
        /// <param name="nifixexp">中缀表达式</param>
        /// <returns></returns>
        private static string GetPostfixExp(string nifixexp) //以逗号分割
        {
            OutPutExpression.Remove(0, OutPutExpression.Length);
            _Stack.Clear();

            if (string.IsNullOrEmpty(nifixexp))
                return string.Empty;

            string[] result = Regex.Split(nifixexp, @"([+\-*/()])").ToArray();

            //1*sin(2)/3*5

            foreach (string ch in result)
            {
                if (string.IsNullOrEmpty(ch))
                    continue;

                switch (ch.ToLower())
                {
                    case "+":
                    case "-":
                        DoOperate(ch, 1, _Stack);
                        break;
                    case "*":
                    case "/":
                        DoOperate(ch, 2, _Stack);
                        break;
                    case "aqrt":
                    case "sqr":
                    case "ln":
                    case "sin":
                    case "cos":
                        DoOperate(ch, 3, _Stack);
                        break;

                    case "(":
                        _Stack.Push(ch);
                        break;

                    case ")":
                        DoOperate(_Stack);
                        break;

                    default:
                        OutPutExpression.Append("," + ch);
                        break;
                }

            }

            DoOperate(_Stack);

            return OutPutExpression.ToString();
        }
        private static void DoOperate(string str, int level, Stack<string> _Stack)
        {
            while (_Stack.Count > 0)
            {
                string popChar = _Stack.Pop();
                if (popChar == "(")
                {
                    _Stack.Push(popChar); break;
                }
                else
                {
                    int popCharlevel;

                    if (popChar == "+" || popChar == "-")
                        popCharlevel = 1;
                    else if (popChar == "*" || popChar == "/")
                        popCharlevel = 2;
                    else
                        popCharlevel = 3;

                    if (level > popCharlevel)
                    {
                        _Stack.Push(popChar); break;
                    }
                    else
                    { OutPutExpression.Append("," + popChar); }
                }
            }
            _Stack.Push(str);
        }
        private static void DoOperate(Stack<string> _Stack)
        {
            while (_Stack.Count > 0)
            {
                string topOper = _Stack.Pop();
                if (topOper == "(")
                    break;
                else
                    OutPutExpression.Append("," + topOper);
            }
        }
        private static string Calculate(string postfixexp)
        {
            try
            {
                if (string.IsNullOrEmpty(postfixexp))
                {
                    return string.Empty;
                }

                _Stack.Clear();
                decimal r;
                string[] result = Regex.Split(postfixexp, ",").ToArray();

                foreach (string ch in result)
                {
                    if (string.IsNullOrEmpty(ch))
                        continue;

                    switch (ch.ToLower())
                    {
                        case "+":
                            double num1 = double.Parse(_Stack.Pop());
                            double num2 = double.Parse(_Stack.Pop());
                            _Stack.Push((num2 + num1).ToString());
                            break;
                        case "-":
                            num1 = double.Parse(_Stack.Pop());
                            num2 = double.Parse(_Stack.Pop());
                            _Stack.Push((num2 - num1).ToString());
                            break;
                        case "*":
                            num1 = double.Parse(_Stack.Pop());
                            num2 = double.Parse(_Stack.Pop());
                            _Stack.Push((num2 * num1).ToString());
                            break;
                        case "/":
                            num1 = double.Parse(_Stack.Pop());
                            num2 = double.Parse(_Stack.Pop());
                            if (num1 == 0)
                                throw new Exception("表达式错误！");
                            _Stack.Push((num2 / num1).ToString());
                            break;
                        case "aqrt":
                            num1 = double.Parse(_Stack.Pop());
                            _Stack.Push((num1 * num1).ToString());
                            break;
                        case "sqr":
                            num1 = double.Parse(_Stack.Pop());
                            _Stack.Push(Math.Sqrt(num1).ToString());
                            break;
                        case "ln":
                            num1 = double.Parse(_Stack.Pop());
                            _Stack.Push(Math.Log10(num1).ToString());
                            break;
                        case "sin":
                            num1 = double.Parse(_Stack.Pop());
                            _Stack.Push(Math.Sin(num1).ToString());
                            break;
                        case "cos":
                            num1 = double.Parse(_Stack.Pop());
                            _Stack.Push(Math.Cos(num1).ToString());
                            break;

                        default:
                            _Stack.Push(ch);
                            break;
                    }
                }

                if (_Stack.Count != 1)
                    throw new Exception("表达式错误");

                return _Stack.Pop();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nifixexp">中缀表达式</param>
        /// <returns></returns>
        public static string CalculateValue(string nifixexp)
        {
            return Calculate(GetPostfixExp(nifixexp));
        }
    }
}
