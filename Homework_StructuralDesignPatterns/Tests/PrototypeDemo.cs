using Homework_StructuralDesignPatterns.Interfaces;
using Homework_StructuralDesignPatterns.Models.Cars;
using Homework_StructuralDesignPatterns.Models.Motorcycles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_StructuralDesignPatterns.Tests
{
    /// <summary>
    /// Демонстрационный сервис для показа работы паттерна Прототип
    /// </summary>
    public static class PrototypeDemo
    {
        /// <summary>
        /// Запуск демонстрации всех возможностей
        /// </summary>
        public static void RunDemo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Демка паттерна Прототип\n");
            Console.ResetColor();

            DemonstrateBasicCloning();
            DemonstratePolymorphicCloning();
            DemonstratePerformance();
            ShowConclusion();
        }

        /// <summary>
        /// Демонстрация базового клонирования
        /// </summary>
        private static void DemonstrateBasicCloning()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Базовое клонирование");
            Console.ResetColor();

            var ferrari = new SportsCar("Ferrari", "F488", 2023, 300000m, 2, "Petrol", true, 330, 3.4, true);
            var yamaha = new SportMotorcycle("Yamaha", "YZF-R1", 2023, 18000m, 1000, "Sport", false, 299, true, "Race");

            Console.WriteLine("Оригинальные объекты:");
            Console.WriteLine($"  {ferrari}");
            Console.WriteLine($"  {yamaha}");

            var ferrariClone = ((IMyCloneable<SportsCar>)ferrari).Clone();
            var yamahaClone = ((IMyCloneable<SportMotorcycle>)yamaha).Clone();

            Console.WriteLine("\nКлонированные объекты:");
            Console.WriteLine($"  {ferrariClone}");
            Console.WriteLine($"  {yamahaClone}");

            Console.WriteLine($"\nПроверка независимости:");
            Console.WriteLine($"  Ferrari: разные объекты = {!ReferenceEquals(ferrari, ferrariClone)}");
            Console.WriteLine($"  Yamaha: разные объекты = {!ReferenceEquals(yamaha, yamahaClone)}");
            Console.WriteLine();
        }

        /// <summary>
        /// Демонстрация полиморфного клонирования
        /// </summary>
        private static void DemonstratePolymorphicCloning()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Полиморфное клонирование");
            Console.ResetColor();

            var vehicles = new List<Vehicle>
        {
            new Car("Toyota", "Camry", 2023, 35000m, 4, "Hybrid", true),
            new SportsCar("Porsche", "911", 2023, 120000m, 2, "Petrol", false, 310, 3.8, true),
            new Motorcycle("Harley", "Street", 2023, 15000m, 750, "Cruiser", false),
            new SportMotorcycle("Ducati", "Panigale", 2023, 25000m, 1200, "Sport", false, 320, true, "Track")
        };

            Console.WriteLine("Клонирование разных типов через базовый интерфейс:");

            foreach (var vehicle in vehicles)
            {
                var clone = vehicle.Clone();
                Console.WriteLine($"  {vehicle.GetType().Name}: Клонирован успешно");
                Console.WriteLine($"    Оригинал: {vehicle}");
                Console.WriteLine($"    Клон:     {clone}");
                Console.WriteLine($"    Равны:    {vehicle.Equals(clone)}");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Демонстрация производительности клонирования
        /// </summary>
        private static void DemonstratePerformance()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Сравнение производительности");
            Console.ResetColor();

            var original = new SportsCar("Test", "Car", 2023, 50000m, 2, "Petrol", true, 250, 4.0, false);
            const int iterations = 100000;

            // Тест клонирования
            var startTime = DateTime.Now;
            for (int i = 0; i < iterations; i++)
            {
                var clone = original.Clone();
            }
            var cloneTime = DateTime.Now - startTime;

            // Тест создания через конструктор
            startTime = DateTime.Now;
            for (int i = 0; i < iterations; i++)
            {
                var newObj = new SportsCar("Test", "Car", 2023, 50000m, 2, "Petrol", true, 250, 4.0, false);
            }
            var constructorTime = DateTime.Now - startTime;

            Console.WriteLine($"Создано {iterations:N0} объектов:");
            Console.WriteLine($"  Через клонирование: {cloneTime.TotalMilliseconds:F2} мс");
            Console.WriteLine($"  Через конструктор:  {constructorTime.TotalMilliseconds:F2} мс");
            Console.WriteLine($"  Разница: {(cloneTime.TotalMilliseconds / constructorTime.TotalMilliseconds):F2}x");
            Console.WriteLine();
        }

        /// <summary>
        /// Здесь много текстов с красивыми заключениями, ну чтоб було
        /// </summary>
        private static void ShowConclusion()
        {
            Console.WriteLine("Выводы о паттерне Прототип");
            Console.WriteLine(@"Сравнение интерфейсов IMyCloneable<T> и ICloneable:

                                IMyCloneable<T> (пользовательский):
                                  - Типобезопасность - возвращает конкретный тип
                                  - Отсутствие приведений типов
                                  - Поддержка множественных версий для иерархии
                                  - Проверка типов на этапе компиляции                                  
                                  - Усложняет код при работе с коллекциями

                                ICloneable (стандартный):
                                  - Стандартный интерфейс .NET
                                  - Совместимость с существующим кодом
                                  - Поддержка инструментами и библиотеками
                                  - Единый интерфейс для всех объектов
                                  - Возвращает object - требует приведения
                                  - Отсутствие типобезопасности
                                  - Возможны ошибки времени выполнения
                                
                                Но, как это часто бывает, лучшее решение - реализация обоих интерфейсов.
                                Можно делегировать ICloneable к типизированному методу. 
                                Тут подвозят:
                                - Совместимость со стандартным интерфейсом .NET
                                - Типобезопасность
                                - Выбор подходящего интерфейса

                                Польза от паттерна прототип видна, когда:
                                - Создание объекта трудоемко
                                - Нужно избежать тесной связанности с конкретными классами
                                - Объекты различаются только состоянием, а не поведением");
        }
    }
}
