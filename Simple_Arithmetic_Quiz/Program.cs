using System;

namespace ArithmeticQuiz
{
    class Execute
    {
        static void Main(string[] args)
        {
            // To loop if user want to quiz again 
            do
            {
                Console.Clear();
                Arithmetic a = new Arithmetic();
                a.Display();

                Console.Write("Re-do Quiz? (Press 'Y' to coninue, any key to exit): ");
            } while (Console.ReadKey().Key == ConsoleKey.Y);
        }
    }
    class Arithmetic
    {
        // Variable initialize
        int num1, num2, answer;
        int question = 1;
        int limit;
        char op;

        // To give random values, operator, and limit of questions
        public void Random()
        {
            Random random = new Random();
            num1 = random.Next(1, 101);
            num2 = random.Next(1, 101);
            limit = random.Next(5, 16);

            char[] operators = { '+', '-', '*', '/' };
            op = operators[random.Next(operators.Length)];
        }

        // Generate a set of Questions for user to answer
        public void Question()
        {
            Console.WriteLine("Question {0}: What is {1} {2} {3}?", question, num1, op, num2);
            Console.Write("Your Answer: ");
            bool isValidInput = int.TryParse(Console.ReadLine(), out answer);

            if (!isValidInput)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.\n");
                Question();
            }
            else
            {
                question++;
            }
        }

        // Check if user answered correct or not
        public string Check()
        {
            double correctAnswer = CalculateAnswer(num1, num2, op);
            return answer == correctAnswer ? "Correct!\n" : $"Incorrect. The correct answer is {correctAnswer}.\n";
        }

        // Display all
        public void Display()
        {
            // Looping until it reaches its random limit number
            do
            {
                Random();
                Question();
                Console.WriteLine(Check());
            } while (question <= limit);
        }

        // Calculate the question
        static double CalculateAnswer(int num1, int num2, char op)
        {
            switch (op)
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                case '*':
                    return num1 * num2;
                case '/':
                    return num1 / num2;
                default:
                    throw new ArgumentException("Invalid operator");
            }
        }
    }
}