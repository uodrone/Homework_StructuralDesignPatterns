using Homework_StructuralDesignPatterns.Tests;

namespace Homework_StructuralDesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Запуск демонстрации
                PrototypeDemo.RunDemo();

                // Запуск тестов
                PrototypeTests.RunAllTests();

                Console.WriteLine("\nНажмите любую кнопу для выходу");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"Стек вызовов: {ex.StackTrace}");
                Console.ReadKey();
            }
        }
    }
}
