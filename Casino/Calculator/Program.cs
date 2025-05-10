public class Calculator
{
    public static double Calculate(double a, double b, char op)
    {
        switch (op)
        {
            case '+':
                return Add(a, b);
            case '-':
                return Sub(a, b);
            case '*':
                return Multiple(a, b);
            case '/':
                return Divide(a, b);
            default:
                throw new ArgumentException("Неверный оператор");
        }
    }

    private static double Add(double a, double b)
    {
        try
        {
            return a + b;
        }
        catch (OverflowException)
        {
            throw new OverflowException("Переполнение при сложении");
        }
    }

    private static double Sub(double a, double b)
    {
        try
        {
            return a - b;
        }
        catch (OverflowException)
        {
            throw new OverflowException("Переполнение при сложении");
        }
    }

    private static double Multiple(double a, double b)
    {
        try
        {
            return a * b;
        }
        catch (OverflowException)
        {
            throw new OverflowException("Переполнение при сложении");
        }
    }

    private static double Divide(double a, double b)
    {
        try
        {
            return a / b;
        }
        catch (DivideByZeroException)
        {
            throw new DivideByZeroException("Деление на 0");
        }
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("КАЛЬКУЛЯТОР");
        Console.WriteLine("Доступные операции: {+, -, *, /}");
        Console.WriteLine("Выражение для вычисления должно быть в формате: {число}{операция}{число}");

        double result;
        bool isContinue = true;
        string input;

        while (isContinue)
        {
            Console.WriteLine("Введите выражение для вычисления (или если вы хотите завершить введите: стоп)");
            input = Console.ReadLine();
            if (input != "")
            {
                if (input.ToLower() == "стоп")
                {
                    isContinue = false;
                }
                else
                {
                    var (arg1, arg2, operation) = ParseInput(input);
                    result = Calculator.Calculate(arg1, arg2, operation);
                    Console.WriteLine($"Результат: {result}");
                }
            }
        }
    }

    private static (double a, double b, char operation) ParseInput(string input)
    {
        char[] operators = { '+', '-', '*', '/' };
        input = input.Replace(" ", "");

        int operatorIndex = input.IndexOfAny(operators);
        if (operatorIndex == -1)
        {
            throw new ArgumentException("Оператор не найден");
        }

        string aStr = input.Substring(0, operatorIndex);
        bool aParsed = double.TryParse(aStr, out double a);
        if (!aParsed)
        {
            throw new ArgumentException("Ошибка в первом числе");
        }

        char operation = input[operatorIndex];
        string bStr = input.Substring(operatorIndex + 1);
        bool bParsed = double.TryParse(bStr, out double b);
        if (!bParsed)
        {
            throw new ArgumentException("Ошибка во втором числе");
        }

        return (a, b, operation);
    }
}