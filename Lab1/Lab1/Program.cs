namespace Lab1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Введите три числа через \"Enter\"");

            int firstNumber = int.Parse(System.Console.ReadLine() ?? string.Empty);
            int secondNumber = int.Parse(System.Console.ReadLine() ?? string.Empty);
            int thirdNumber = int.Parse(System.Console.ReadLine() ?? string.Empty);

            int resultFirst, resultSecond, resultThird;

            if (firstNumber > secondNumber)
            {
                if (firstNumber > thirdNumber)
                {
                    resultFirst = firstNumber;
                    if (secondNumber > thirdNumber)
                    {
                        resultSecond = secondNumber;
                        resultThird = thirdNumber;
                    }
                    else
                    {
                        resultSecond = thirdNumber;
                        resultThird = secondNumber;
                    }
                }
                else
                {
                    resultFirst = thirdNumber;
                    resultSecond = firstNumber;
                    resultThird = secondNumber;
                }
            }
            else
            {
                if (secondNumber > thirdNumber)
                {
                    resultFirst = secondNumber;
                    if (firstNumber > thirdNumber)
                    {
                        resultSecond = firstNumber;
                        resultThird = thirdNumber;
                    }
                    else
                    {
                        resultSecond = thirdNumber;
                        resultThird = firstNumber;
                    }
                }
                else
                {
                    resultFirst = thirdNumber;
                    resultSecond = secondNumber;
                    resultThird = firstNumber;
                }
            }

            System.Console.WriteLine(resultFirst + ", " + resultSecond + ", " + resultThird);
            System.Console.WriteLine(resultThird + ", " + resultSecond + ", " + resultFirst);
        }
    }
}
