namespace Lab2;
public class Program
{
    public static void Main(string[] args)
    {
        IsBalanced("{ ( < > ) }");  // true
        IsBalanced("<> {(})");      // false
    }

    public static bool IsBalanced(string s)
    {
        Stack<char> stack = new Stack<char>();

        // iterate over all chars in string
        foreach(var c in s)
        {
            // if char is an open thing, push it
            if ( c=='<' || c=='(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }

            // if char is a close thing,
            // compare it to top of stack;
            else if (c == '>' || c == ')' || c == '}' || c == ']')
            {
                char top;
                bool result = stack.TryPeek(out top);
                // handle result == false

                // if they match, pop()
                if (Matches(c, top) ) 
                {
                    stack.Pop();
                }
                // else, return false
                else
                {
                    return false;
                }
            }
            
        }

        // if stack is empty, return true
        if( stack.Count ==0)
        {
            return true;
        }

        return false;

    }

    private static bool Matches(char closing, char opening)
    {
        if (opening == '(' && closing == ')')
        {
            return true;
        }

        if (opening == '{' && closing == '}')
        {
            return true;
        }

        if (opening == '[' && closing == ']')
        {
            return true;
        }

        if (opening =='<' && closing == '>')
        {
            return true;
        }



        return false;
    }


    public static double? Evaluate(string s)
    {

        Stack<char> stack = new Stack<char>();
        // parse string into tokens
        string[] tokens = s.Split();
        

        
        // foreach token
        // if it's a number, push to stack
        
        foreach(var c in tokens)
        {

            int numericValue;
            bool isNumber = int.TryParse(c, out numericValue);
            if (isNumber == true)
            {
                char ch = Convert.ToChar(numericValue);
                stack.Push(ch);
                
            }
            //else if (isNumber == false && (stack.Count == 0 || stack.Count == 1))
            //{
                
            //}
            else
            {
                if (c == "+")
                {

                    stack.Push(Convert.ToChar(Convert.ToInt32(stack.Pop()) + Convert.ToInt32(stack.Pop())));
                }
                else if (c == "-")
                {
                    stack.Push(Convert.ToChar((Convert.ToInt32(stack.Pop()) * -1) + Convert.ToInt32(stack.Pop())));
                }
                else if (c == "*")
                {

                    stack.Push(Convert.ToChar(Convert.ToInt32(stack.Pop()) * Convert.ToInt32(stack.Pop())));
                }
                else if (c == "/")
                {
                    int x = Convert.ToInt32(stack.Pop());
                    int y = Convert.ToInt32(stack.Pop());

                    stack.Push(Convert.ToChar(y / x));
                    
                }
            }

        }

        // if it's a math operator, pop twice;
        // compute result;
        // push result onto stack

        // return top of stack (if the stack has 1 element)

        if (stack.Count == 1)
        {
            int x = stack.Peek();
            return x;
        }
        else
        {
            return null;
        }
    }

}

