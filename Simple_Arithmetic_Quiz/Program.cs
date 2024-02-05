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
            Console.WriteLine($"Question {question}: What is {num1} {op} {num2}?");
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

        // Show results 
        private void Results(int correctAnswers, int totalQuestions)
        {
            double percentage = (double)correctAnswers / totalQuestions * 100;

            Console.WriteLine("Results:");
            Console.WriteLine($"Total Correct Answers: {correctAnswers}");
            Console.WriteLine($"Percentage of Correct Answers: {Math.Round(percentage)}%\n");
        }

        // Display all
        public void Display()
        {
            int correctAnswers = 0;

            // Looping until it reaches its random limit number
            do
            {
                Random();
                Question();
                Console.WriteLine(Check());

                // Count correct answers
                if (answer == CalculateAnswer(num1, num2, op))
                {
                    correctAnswers++;
                }
            } while (question <= limit);

            Results(correctAnswers, limit);
        }

        // Calculate the question
        private static double CalculateAnswer(int num1, int num2, char op)
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