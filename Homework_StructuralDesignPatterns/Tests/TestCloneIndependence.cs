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
    /// Класс для тестирования функциональности паттерна Прототип
    /// </summary>
    public static class PrototypeTests
    {
        /// <summary>
        /// Запуск всех тестов
        /// </summary>
        public static void RunAllTests()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nЗопускаю тесты паттерна Прототип\n");
            

            var testResults = new List<bool>();

            testResults.Add(TestMyCloneableInterface());
            testResults.Add(TestICloneableInterface());
            testResults.Add(TestCloneIndependence());
            testResults.Add(TestInheritanceCloning());
            testResults.Add(TestCloneEquality());

            int passed = testResults.FindAll(x => x).Count;
            int total = testResults.Count;

            Console.WriteLine($"\nРезультаты тестов: {passed} из {total} пройдено");
            Console.ResetColor();

            if (passed == total)
                Console.WriteLine("Усе пройдено успешно!");
            else
                Console.WriteLine("Что-то пошло не так");
        }

        /// <summary>
        /// Тест пользовательского интерфейса IMyCloneable
        /// </summary>
        private static bool TestMyCloneableInterface()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Тест интерфейса IMyCloneable<T>");
            Console.ResetColor();

            try
            {
                var originalCar = CreateTestSportsCar();
                var clonedCar = ((IMyCloneable<SportsCar>)originalCar).Clone();

                bool success = !ReferenceEquals(originalCar, clonedCar) &&
                              originalCar.Equals(clonedCar);

                Console.WriteLine($"Оригинал: {originalCar}");
                Console.WriteLine($"Клон: {clonedCar}");
                Console.WriteLine($"Разные объекты: {!ReferenceEquals(originalCar, clonedCar)}");
                Console.WriteLine($"Одинаковые данные: {originalCar.Equals(clonedCar)}");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Результат: {(success ? "Пройдено" : "Прошляплено")}\n");
                Console.ResetColor();

                return success;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ахтунг, ошибка: {ex.Message}\n");
                Console.ResetColor();
                return false;
            }
        }

        /// <summary>
        /// Тест стандартного интерфейса ICloneable
        /// </summary>
        private static bool TestICloneableInterface()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Тест интерфейса ICloneable");
            Console.ResetColor();

            try
            {
                var originalMotorcycle = CreateTestSportMotorcycle();
                var clonedMotorcycle = (SportMotorcycle)((ICloneable)originalMotorcycle).Clone();

                bool success = !ReferenceEquals(originalMotorcycle, clonedMotorcycle) &&
                              originalMotorcycle.Equals(clonedMotorcycle);

                Console.WriteLine($"Оригинал: {originalMotorcycle}");
                Console.WriteLine($"Клон: {clonedMotorcycle}");
                Console.WriteLine($"Разные объекты: {!ReferenceEquals(originalMotorcycle, clonedMotorcycle)}");
                Console.WriteLine($"Одинаковые данные: {originalMotorcycle.Equals(clonedMotorcycle)}");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Результат: {(success ? "Пройдено" : "Прошляплено")}\n");
                Console.ResetColor();

                return success;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ахтунг, ошибка: {ex.Message}\n");
                Console.ResetColor();
                return false;
            }
        }

        /// <summary>
        /// Тест независимости клонов от оригинала
        /// </summary>
        private static bool TestCloneIndependence()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Тест независимости клонов");
            Console.ResetColor();

            try
            {
                var original = CreateTestSportsCar();
                var clone = original.Clone() as SportsCar;

                string originalBrand = original.Brand;
                string originalModel = original.Model;

                // Изменяем клон
                clone.Brand = "Modified Brand";
                clone.Model = "Modified Model";
                clone.MaxSpeed = 999;

                bool success = original.Brand == originalBrand &&
                              original.Model == originalModel &&
                              !original.Equals(clone);

                Console.WriteLine($"Оригинал после изменения клона: {original}");
                Console.WriteLine($"Измененный клон: {clone}");
                Console.WriteLine($"Оригинал не изменился: {success}");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Результат: {(success ? "Пройдено" : "Прошляплено")}\n");
                Console.ResetColor();

                return success;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ахтунг, ошибка: {ex.Message}\n");
                Console.ResetColor();
                return false;
            }
        }

        /// <summary>
        /// Тест клонирования на разных уровнях наследования
        /// </summary>
        private static bool TestInheritanceCloning()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Тест клонирования наследования");
            Console.ResetColor();

            try
            {
                var vehicles = new List<Vehicle>
            {
                new Car("Toyota", "Corolla", 2023, 25000m, 4, "Petrol", true),
                CreateTestSportsCar(),
                new Motorcycle("Honda", "CBR600", 2023, 12000m, 600, "Sport", false),
                CreateTestSportMotorcycle()
            };

                bool allSuccess = true;

                foreach (var vehicle in vehicles)
                {
                    var clone = vehicle.Clone();
                    bool success = !ReferenceEquals(vehicle, clone) &&
                                  vehicle.Equals(clone) &&
                                  vehicle.GetType() == clone.GetType();

                    Console.WriteLine($"{vehicle.GetType().Name}: {(success ? "Да" : "Нет")}");

                    if (!success) allSuccess = false;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Результат: {(allSuccess ? "Пройдено" : "Прошляплено")}\n");
                Console.ResetColor();
                return allSuccess;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ахтунг, ошибка: {ex.Message}\n");
                Console.ResetColor();
                return false;
            }
        }

        /// <summary>
        /// Тест корректности метода Equals для клонов
        /// </summary>
        private static bool TestCloneEquality()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Тест корректности Equals");
            Console.ResetColor();

            try
            {
                var original = CreateTestSportsCar();
                var clone = original.Clone();
                var different = new SportsCar("Different", "Car", 2020, 50000m, 2, "Electric", true, 200, 5.0, false);

                bool equalityWorks = original.Equals(clone) && !original.Equals(different);
                bool hashCodesMatch = original.GetHashCode() == clone.GetHashCode();

                Console.WriteLine($"Оригинал равен клону: {original.Equals(clone)}");
                Console.WriteLine($"Оригинал не равен другому объекту: {!original.Equals(different)}");
                Console.WriteLine($"Hash коды совпадают: {hashCodesMatch}");

                bool success = equalityWorks && hashCodesMatch;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Результат: {(success ? "Пройдено" : "Прошляплено")}\n");
                Console.ResetColor();

                return success;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ахтунг, ошибка: {ex.Message}\n");
                Console.ResetColor();
                return false;
            }
        }

        private static SportsCar CreateTestSportsCar()
        {
            return new SportsCar("Ferrari", "F488", 2023, 300000m, 2, "Petrol", true, 330, 3.4, true);
        }

        private static SportMotorcycle CreateTestSportMotorcycle()
        {
            return new SportMotorcycle("Yamaha", "YZF-R1", 2023, 18000m, 1000, "Sport", false, 299, true, "Race");
        }
    }
}
